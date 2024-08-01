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
    /// Interaction logic for UC_Urinalysis.xaml
    /// </summary>
    public partial class UC_Urinalysis : UserControl
    {
        BackgroundWorker bgworker = new BackgroundWorker();
        

        LabClientInfo data;
        Urine_PrintDoc doc = new Urine_PrintDoc();
        cmdldbDataSet cmdl;

        List<string> collection = new List<string>
        {
            "RANDOM",
            "EARLY MORNING",
        };

        List<string> color = new List<string>
        {
            "LIGHT YELLOW",
            "YELLOW",
            "PALE YELLOW",
            "DARK YELLOW",
            "STRAW",
            "AMBER"
        };

        List<string> transparency = new List<string>
        {
            "CLEAR",
            "HAZY",
            "CLOUDY",
            "SLIGHTLY CLOUDY",
            "TURBID",
            "MILKY"
        };


        List<string> glucose = new List<string>
        {
            "NEGATIVE",
            "TRACE",
            "+1",
            "+2",
            "+3",
            "+4"
        };

        List<string> epithelialcells = new List<string>
        {
            "NONE",
            "RARE",
            "FEW",
            "MODERATE",
            "MANY"
        };




        public UC_Urinalysis(LabClientInfo data, cmdldbDataSet cmdl, bool allowPrint, string userName)
        {
            InitializeComponent();
            this.DataContext = data.Urinalysis;
            this.data = data;
            this.cmdl = cmdl;
            this.AllowPrint = allowPrint;
            this.UserName = userName;

            ReadOnly(data.Urinalysis.Enabled);

            bgworker.WorkerSupportsCancellation = true;
            bgworker.DoWork += new DoWorkEventHandler(bgworker_DoWork);
            bgworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgworker_RunWorkerCompleted);

            BtSaveRecord.Click += new RoutedEventHandler(BtSaveRecord_Click);
            BtPreview.Click += new RoutedEventHandler(BtPreview_Click);

            SetCollection();
            SetColor();
            SetTransaparency();
            SpecificGravity();
            PH();
            Glucose();
            EpithelialCells();
            SetCast();

            TbNote.Items.Add("WITH MENSTRUATION");
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
                    data.Urinalysis.Enabled = false;
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
                UrineDB argumentest = e.Argument as UrineDB;
                argumentest.Select("select * from urinalysis where urine_controlno='000000000000'", "urinalysis");
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
            SpanelResult_1.IsEnabled = value;
            SpanelResult_2.IsEnabled = value;
            BtSaveRecord.Content = value ? "SAVE RECORD" : "PRINT";

        }

        public void Save()
        {
            if (!String.IsNullOrWhiteSpace(TbMedTech.Text))
            {
                if (!String.IsNullOrWhiteSpace(TbPathologist.Text))
                {
                    if (!String.IsNullOrWhiteSpace(CbUrineCollection.Text))
                    {
                        PasswordPage ppage = new PasswordPage();
                        ppage.TableName = "office_user";

                        if (ppage.ShowDialog() == true)
                        {
                            UrineDB db = new UrineDB(Properties.Settings.Default.Server,
                                                        Properties.Settings.Default.Database,
                                                         Properties.Settings.Default.UserID,
                                                         Properties.Settings.Default.Port,
                                                         Properties.Settings.Default.Password);

                            BtSaveRecord.Content = "SAVING...";
                            BtSaveRecord.IsEnabled = false;

                            data.Urinalysis.PrintedBy = ppage.User;
                            db.ControlNo = data.ControlNo;
                            db.Data = data.Urinalysis;

                            bgworker.RunWorkerAsync(db);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Collection not specified!");
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
            doc.CyberPreview(new List<LabClientInfo>(){ data });
        }

        //other methods



        private void SetCast()
        {
            CbFineGranularCast.Items.Add("0");
            CbCoarseGranularCast.Items.Add("0");
            CbWBCCast.Items.Add("0");
            CbRBCCast.Items.Add("0");
            CbBlood.Items.Add("0");
            CbLeukocytes.Items.Add("0");
            CbNitrite.Items.Add("0");
            CbKetone.Items.Add("0");
            CbUrobilinogen.Items.Add("0");
            CbAscorbicAcid.Items.Add("0");

            for (double i = 0.0; i <= 0.05; i += 0.01)
            {
                CbFineGranularCast.Items.Add(string.Format("{0:0.00}", i));
                CbCoarseGranularCast.Items.Add(string.Format("{0:0.00}", i));
                CbWBCCast.Items.Add(string.Format("{0:0.00}", i));
                CbRBCCast.Items.Add(string.Format("{0:0.00}", i));
                CbBlood.Items.Add(string.Format("{0:0.00}", i));
                CbLeukocytes.Items.Add(string.Format("{0:0.00}", i));
                CbNitrite.Items.Add(string.Format("{0:0.00}", i));
                CbKetone.Items.Add(string.Format("{0:0.00}", i));
                CbUrobilinogen.Items.Add(string.Format("{0:0.00}", i));
                CbAscorbicAcid.Items.Add(string.Format("{0:0.00}", i));
            }

        }

        private void SetCollection()
        {
            foreach (string s in collection)
            {
                CbUrineCollection.Items.Add(s);
            }
        }

        private void SetColor()
        {
            foreach (string s in color)
            {
                CBColor.Items.Add(s);
            }
        }

        private void SetTransaparency()
        {
            foreach (string s in transparency)
            {
                CbTransparency.Items.Add(s);
            }
        }

        private void SpecificGravity()
        {
            for (decimal d = 1.005m; d < 1.032m; d += 0.001m)
            {
                CBSpecificGravity.Items.Add(Convert.ToString(d));
            }
        }

        private void PH()
        {
            CbPH.Items.Add("5.0");
            CbPH.Items.Add("6.0");
            CbPH.Items.Add("7.0");
            CbPH.Items.Add("8.0");
            CbPH.Items.Add("9.0");
        }

        private void Glucose()
        {
            foreach (string s in glucose)
            {
                CbGlucose.Items.Add(s);
                CbProtein.Items.Add(s);
            }
        }

        private void EpithelialCells()
        {
            foreach (string s in epithelialcells)
            {
                CBEpithelialCells.Items.Add(s);
                CBBacteria.Items.Add(s);
                CBMucusThread.Items.Add(s);
                CBAUrates.Items.Add(s);
                CBCalciumOX.Items.Add(s);
                CbUricAcid.Items.Add(s);
            }
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
