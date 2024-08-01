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
using CMDL.DAL;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for UC_PE.xaml
    /// </summary>
    public partial class UC_PE : UserControl
    {
        BackgroundWorker bgworker = new BackgroundWorker();

        

        LabClientInfo data;
        cmdldbDataSet cmdldb;

        PE_PrintDoc doc = new PE_PrintDoc();

        List<string> bloodGroup = new List<string>
        {
            "'A' RH NEGATIVE",
            "'A' RH POSITIVE",
            "'AB' RH NEGATIVE",
            "'AB' RH POSITIVE",
            "'B' RH NEGATIVE",
            "'B' RH POSITIVE",
            "'O' RH NEGATIVE",
            "'O' RH POSITIVE",
            
        };

        public UC_PE(LabClientInfo data, cmdldbDataSet cmdldb, bool allowPrint, string userName)
        {
            InitializeComponent();
            this.DataContext = data.Physical_Examination;
            this.data = data;
            this.cmdldb = cmdldb;
            this.AllowPrint = allowPrint;
            this.UserName = userName;

            ReadOnly(data.Physical_Examination.Enabled);

            bgworker.WorkerSupportsCancellation = true;
            bgworker.DoWork += new DoWorkEventHandler(bgworker_DoWork);
            bgworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgworker_RunWorkerCompleted);

            BtSaveRecord.Click += new RoutedEventHandler(BtSaveRecord_Click);
            BtPreview.Click += new RoutedEventHandler(BtPreview_Click);

            CbRecommendation.SelectionChanged += new SelectionChangedEventHandler(CbRecommendation_SelectionChanged);

            SetHeight();
            SetWeight();
            SetVAandIshi();
            SetBloodType();
            SetLabItems();
            SetPhysician();

            CboxEssNegative.Checked += new RoutedEventHandler(CboxEssNegative_Checked);
            CboxEssNegative.Unchecked += new RoutedEventHandler(CboxEssNegative_Unchecked);
           
        }

        void CboxEssNegative_Unchecked(object sender, RoutedEventArgs e)
        {
            TbCXRFindings.IsEnabled = true;
        }

        void CboxEssNegative_Checked(object sender, RoutedEventArgs e)
        {
            TbCXRFindings.IsEnabled = false;
        }

        void CbRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = CbRecommendation.SelectedItem as ComboBoxItem;
            if (item.Content.ToString() == "UNFIT")
            {
                TbUnfit.IsEnabled = true;
            }
            else
            {
                TbUnfit.IsEnabled = false;
            }
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
            }
            else
            {
                MessageBox.Show((string)e.Result);

                if ((string)e.Result == "RECORD SAVED!")
                {
                    data.Physical_Examination.Enabled = false;
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
                PEDB argumentest = e.Argument as PEDB;
                argumentest.Select("select * from pe where pe_controlno='000000000000'", "pe");
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
            GboxPosition.IsEnabled = value;
            GboxGrowthDev.IsEnabled = value;
            GboxVitalSigns.IsEnabled = value;
            GboxEyes.IsEnabled = value;
            GboxVisualAcuity.IsEnabled = value;
            GboxIshihara.IsEnabled = value;
            GboxPhysical.IsEnabled = value;
            GboxIshihara.IsEnabled = value;
            GboxCXR.IsEnabled = value;
            GboxLab.IsEnabled = value;
            GboxPsycho.IsEnabled = value;
            GboxPsychia.IsEnabled = value;
            GboxRemarks.IsEnabled = value;
            GboxRecommendation.IsEnabled = value;
            GboxRefBy.IsEnabled = value;
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
                    PEDB db = new PEDB(Properties.Settings.Default.Server,
                                                     Properties.Settings.Default.Database,
                                                     Properties.Settings.Default.UserID,
                                                     Properties.Settings.Default.Port,
                                                     Properties.Settings.Default.Password);

                    BtSaveRecord.Content = "SAVING...";
                    BtSaveRecord.IsEnabled = false;

                    data.Physical_Examination.PrintedBy = ppage.User;
                    db.ControlNo = data.ControlNo;
                    db.Data = data.Physical_Examination;

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
            doc.Physician = cmdldb.Tables["physician"];
            doc.Preview(new List<LabClientInfo>() { data });
        }

        public void Preview()
        {
            doc.Physician = cmdldb.Tables["physician"];
            doc.CyberPreview(new List<LabClientInfo>() { data });
        }

        public void SetHeight()
        {
            for (int ft = 1; ft <= 9; ft++)
            {
                for (int inches = 0; inches <= 11; inches++)
                {
                    CbHeight.Items.Add(ft.ToString() + "'" + inches.ToString() + "\"");
                }
            }
        }

        public void SetWeight()
        {
            for (decimal wt = 10.0m; wt <= 250.0m; wt += 0.1m )
            {
                CbWeight.Items.Add(wt.ToString() + " kg.");
            }
        }

        public void SetVAandIshi()
        {
            CbEyes.Items.Add("NORMAL");
            CbEyes.Items.Add("BLINDNESS");
            CbEyes.Items.Add("BLURRED");
        }

        public void SetBloodType()
        {
            foreach (string s in bloodGroup)
            {
                CbBloodType.Items.Add(s);
            }
            CbBloodType.Items.Add("NOT DONE");
        }

        public void SetLabItems()
        {
            foreach (string s in new List<string>() { "NOT DONE","NORMAL" })
            {
                
                CbCBC.Items.Add(s);
                CbUrinalysis.Items.Add(s);
                CbStool.Items.Add(s);
                CbBloodChemistry.Items.Add(s);
            }

            foreach (string s in new List<string>() { "NOT DONE","POSITIVE","NEGATIVE"})
            {
                CbPregnancyTest.Items.Add(s);
            }

            foreach (string s in new List<string> { "REACTIVE","NONREACTIVE","NOT DONE"})
            {
                CbVDRL.Items.Add(s);
                CbHepA.Items.Add(s);
                CbHepB.Items.Add(s);
                CbHIV.Items.Add(s);
            }


            CbDrugTest.Items.Add("NEGATIVE");
            CbDrugTest.Items.Add("POSITIVE");
            CbDrugTest.Items.Add("CONFIRMATORY");
            CbDrugTest.Items.Add("NOT DONE");
        }

        public void SetPhysician()
        {
            foreach(DataRow p in cmdldb.Tables["physician"].Rows)
                CbPhysician.Items.Add(Convert.ToString(p["name"]));
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
