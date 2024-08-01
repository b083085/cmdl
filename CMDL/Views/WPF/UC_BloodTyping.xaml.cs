using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for UC_BloodTyping.xaml
    /// </summary>
    public partial class UC_BloodTyping : UserControl
    {
        BackgroundWorker bgworker = new BackgroundWorker();
        

        LabClientInfo data;
        BloodTyping_PrintDoc doc = new BloodTyping_PrintDoc();

        List<string> bloodGroup = new List<string>
        {
            "'A' RH NEGATIVE",
            "'A' RH POSITIVE'",
            "'AB' RH NEGATIVE'",
            "'AB' RH POSITIVE'",
            "'B' RH NEGATIVE'",
            "'B' RH POSITIVE'",
            "'O' RH NEGATIVE'",
            "'O' RH POSITIVE'",
            
        };
        
        
        public UC_BloodTyping(LabClientInfo data,bool allowPrint, string userName)
        {
            InitializeComponent();

            this.AllowPrint = allowPrint;
            this.UserName = userName;

            foreach (string s in bloodGroup)
                CbResults.Items.Add(s);

            this.DataContext = data.Blood_Typing;
            this.data = data;
            ReadOnly(data.Blood_Typing.Enabled);

            bgworker.WorkerSupportsCancellation = true;
            bgworker.DoWork += new DoWorkEventHandler(bgworker_DoWork);
            bgworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgworker_RunWorkerCompleted);

            BtSaveRecord.Click += new RoutedEventHandler(BtSaveRecord_Click);
            BtPreview.Click += new RoutedEventHandler(BtPreview_Click);
        }

        void BtPreview_Click(object sender, RoutedEventArgs e)
        {
            Preview();
        }

        void BtSaveRecord_Click(object sender, RoutedEventArgs e)
        {
            if (BtSaveRecord.Content.ToString() == "SAVE RECORD")
                Save();
            else if (BtSaveRecord.Content.ToString() == "PRINT")
            {
                if (AllowPrint)
                    Print();
                else
                    MessageBox.Show("User: " + UserName + " is not allowed to print laboratory result(s)!","Print Result Message",MessageBoxButton.OK,MessageBoxImage.Stop);
            }
        }

        void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Unable to connect to the database!Please contact your Database Administrator for further assistance!");
                BtSaveRecord.Content = "SAVE RECORD";
            }
            else
            {
                MessageBox.Show((string)e.Result);

                if ((string)e.Result == "RECORD SAVED!")
                {
                    data.Blood_Typing.Enabled = false;
                    data.Count += 1;
                    data.Status = (data.Count == data.Total_Count ? "DONE" : "NOT DONE");
                    ReadOnly(false);
                    Print();
                }
                else
                {
                    BtSaveRecord.Content = "SAVE RECORD";
                }
            }
            BtSaveRecord.IsEnabled = true;
        }

        void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BloodTypingDB argumentest = e.Argument as BloodTypingDB;
                argumentest.Select("select * from blood_typing where btype_controlno='000000000000'", "blood_typing");
                if (argumentest.Save())
                {
                    e.Result = "RECORD SAVED!";
                }
                else
                {
                    e.Result = "Unable to save this record!";
                }
            }
            catch (Exception)
            {
                e.Cancel = true;
            }

        }

        public void ReadOnly(bool value)
        {
            CbResults.IsEnabled = value;
            TbRemarks.IsEnabled = value;
            TbReqPhysician.IsEnabled = value;
            BtSaveRecord.Content = value ? "SAVE RECORD" : "PRINT";

        }

        public void Save()
        {
            if (!String.IsNullOrWhiteSpace(TbMedTech.Text))
            {
                if (!String.IsNullOrWhiteSpace(TbPathologist.Text))
                {
                    PasswordPage ppage = new PasswordPage();
                    ppage.TableName = "office_user";

                    if (ppage.ShowDialog() == true)
                    {
                        BloodTypingDB db = new BloodTypingDB(Properties.Settings.Default.Server,
                                                 Properties.Settings.Default.Database,
                                                 Properties.Settings.Default.UserID,
                                                 Properties.Settings.Default.Port,
                                                 Properties.Settings.Default.Password);

                        BtSaveRecord.Content = "SAVING...";
                        BtSaveRecord.IsEnabled = false;

                        data.Blood_Typing.PrintedBy = ppage.User;
                        db.ControlNo = data.ControlNo;
                        db.Data = data.Blood_Typing;

                        bgworker.RunWorkerAsync(db);
                    }
                }
                else
                {
                    MessageBox.Show("Pathologist not specified!");
                }
            }
            else
            {
                MessageBox.Show("Medical Technologist not specified!");
            }
            
        }

        public void Print()
        {
            doc.Preview(new List<LabClientInfo>() { data });
        }

        public void Preview()
        {
            doc.CyberPreview(new List<LabClientInfo>() { data });
        }

        public bool AllowPrint
        {
            set;
            get;
        }

        public string UserName
        {
            set;
            get;
        }














    }
}
