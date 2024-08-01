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

namespace CMDL
{
    /// <summary>
    /// Interaction logic for UC_MedicalCertificate.xaml
    /// </summary>
    public partial class UC_MedicalCertificate : UserControl
    {
        BackgroundWorker bgworker = new BackgroundWorker();
        

        LabClientInfo data;

        public UC_MedicalCertificate(LabClientInfo data, bool allowPrint, string userName)
        {
            InitializeComponent();
            this.DataContext = data.Medical_Certificate;
            this.data = data;
            this.AllowPrint = allowPrint;
            this.UserName = userName;

            ReadOnly(data.Medical_Certificate.Enabled);

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
                    MessageBox.Show("User: " + UserName + " is not allowed to print laboratory result(s)!", "Print Result Message", MessageBoxButton.OK, MessageBoxImage.Stop);


            }
        }

        void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Unable to connect to the database!Please contact your Database Administrator for further assistance!");
                BtSaveRecord.Content = "SAVE RECORD";
                BtSaveRecord.IsEnabled = true;
            }
            else
            {
                MessageBox.Show((string)e.Result);

                if ((string)e.Result == "RECORD SAVED!")
                {
                    data.Medical_Certificate.Enabled = false;
                    data.Count += 1;
                    data.Status = (data.Count == data.Total_Count ? "DONE" : "NOT DONE");
                    ReadOnly(false);
                    Print();
                }
                else
                {
                    BtSaveRecord.Content = "SAVE RECORD";
                    BtSaveRecord.IsEnabled = true;
                }
            }
        }

        void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MedicalCertifiateDB argumentest = e.Argument as MedicalCertifiateDB;
                argumentest.Select("select * from medical_certificate where med_controlno='000000000000'", "medical_certificate");
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
            GboxDateApproved.IsEnabled = value;
            TbRemarks.IsEnabled = value;
            GboxPhysician.IsEnabled = value;
            GboxLicenseNo.IsEnabled = value;
            BtSaveRecord.Content = value ? "SAVE RECORD" : "PRINT";

        }

        public void Save()
        {
            if (!String.IsNullOrWhiteSpace(CbPhysician.Text))
            {
                PasswordPage ppage = new PasswordPage();
                ppage.TableName = "office_user";

                if (ppage.ShowDialog() == true)
                {
                    MedicalCertifiateDB db = new MedicalCertifiateDB(Properties.Settings.Default.Server,
                                                     Properties.Settings.Default.Database,
                                                     Properties.Settings.Default.UserID,
                                                     Properties.Settings.Default.Port,
                                                     Properties.Settings.Default.Password);

                    BtSaveRecord.Content = "SAVING...";
                    BtSaveRecord.IsEnabled = false;

                    data.Medical_Certificate.PrintedBy = ppage.User;
                    db.ControlNo = data.ControlNo;
                    db.Data = data.Medical_Certificate;

                    bgworker.RunWorkerAsync(db);
                }
            }
            else
            {
                MessageBox.Show("Physician not specified!");
            }

            
        }

        public void Print()
        {
        }

        public void Preview()
        {
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
