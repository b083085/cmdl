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
    /// Interaction logic for UC_BloodTest.xaml
    /// </summary>
    public partial class UC_Serology : UserControl
    {
        BackgroundWorker bgworker = new BackgroundWorker();
        

        LabClientInfo data;

        string type = "";

        

        Serology_PrintDoc doc = new Serology_PrintDoc();


        public UC_Serology(LabClientInfo data, string type, bool allowPrint, string userName)
        {
            InitializeComponent();

            Enabled(data.Serology[type]);

            this.DataContext = data.Serology[type];
            this.data = data;
            this.type = type;
            this.AllowPrint = allowPrint;
            this.UserName = userName;

            BtSaveRecord.Click += new RoutedEventHandler(BtSaveRecord_Click);
            BtPreview.Click += new RoutedEventHandler(BtPreview_Click);

            bgworker.WorkerSupportsCancellation = true;
            bgworker.DoWork += new DoWorkEventHandler(bgworker_DoWork);
            bgworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgworker_RunWorkerCompleted);


            CbAntiHIVResults.SelectionChanged += new SelectionChangedEventHandler(CbAntiHIVResults_SelectionChanged);
            CbHBsAgResults.SelectionChanged += new SelectionChangedEventHandler(CbHBsAgResults_SelectionChanged);
            CbSyphilisResults.SelectionChanged += new SelectionChangedEventHandler(CbSyphilisResults_SelectionChanged);
            cbAntiHCVResults.SelectionChanged += new SelectionChangedEventHandler(cbAntiHCVResults_SelectionChanged);
           
        }

        void cbAntiHCVResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = CbSyphilisResults.SelectedItem as ComboBoxItem;
                if (Convert.ToString(item.Content) == "REACTIVE")
                {
                    tbAntiHCVRemarks.Text = "REPEATED IN DUPLICATE. RECOMMEND FOR CONFIRMATORY";
                    data.Serology[type].AntiHCV_Remarks = "REPEATED IN DUPLICATE. RECOMMEND FOR CONFIRMATORY";
                }
                else
                {
                    tbAntiHCVRemarks.Text = "NONE";
                    data.Serology[type].AntiHCV_Remarks = "NONE";

                }
            }
            catch (Exception)
            {
                //none
            }
        }
        void CbSyphilisResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = CbSyphilisResults.SelectedItem as ComboBoxItem;
                if (Convert.ToString(item.Content) == "REACTIVE")
                {
                    TbSyphilisRemarks.Text = "REPEATED IN DUPLICATE. RECOMMEND FOR CONFIRMATORY";
                    data.Serology[type].AntiTP_Remarks = "REPEATED IN DUPLICATE. RECOMMEND FOR CONFIRMATORY";
                }
                else
                {
                    TbSyphilisRemarks.Text = "NONE";
                    data.Serology[type].AntiTP_Remarks = "NONE";

                }
            }
            catch (Exception)
            {
                //none
            }
        }
        void CbHBsAgResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = CbHBsAgResults.SelectedItem as ComboBoxItem;
                if (Convert.ToString(item.Content) == "REACTIVE")
                {
                    TbHBsAgRemarks.Text = "REPEATED IN DUPLICATE. RECOMMEND FOR CONFIRMATORY";
                    data.Serology[type].HBsAg_Remarks = "REPEATED IN DUPLICATE. RECOMMEND FOR CONFIRMATORY";
                }
                else
                {
                    TbHBsAgRemarks.Text = "NONE";
                    data.Serology[type].HBsAg_Remarks = "NONE";

                }

            }
            catch (Exception)
            {
                //none
            }
        }
        void CbAntiHIVResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var item = CbAntiHIVResults.SelectedItem as ComboBoxItem;
                if (Convert.ToString(item.Content) == "REACTIVE")
                {
                    TbAntiHIVRemarks.Text = "REPEATED IN DUPLICATE. REFER TO SACCL FOR CONFIRMATORY";
                    data.Serology[type].AntiHIV_Remarks = "REPEATED IN DUPLICATE. REFER TO SACCL FOR CONFIRMATORY";
                }
                else
                {
                    TbAntiHIVRemarks.Text = "NONE";
                    data.Serology[type].AntiHIV_Remarks = "NONE";
                }
            }
            catch (Exception)
            {
                //none
            }
        }
        public void ReadOnly()
        {

            BtSaveRecord.Content = "PRINT";
            BtSaveRecord.IsEnabled = true;
            SPanelResults.IsEnabled = false;
            SPanelRemarks.IsEnabled = false;
            GBoxSignatories.IsEnabled = false;

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
                    data.Serology[type].Enabled = false;
                    data.Count += 1;
                    data.Status = (data.Count == data.Total_Count ? "DONE" : "NOT DONE");
                    ReadOnly();
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
                SerologyDB argumentest = e.Argument as SerologyDB;
                argumentest.Select("select * from serology where serology_controlno='000000000000'", "serology");
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
        public DataTable MedTech_2
        {
            set
            {
                foreach (DataRow d in value.Rows)
                    CbMedTech_2.Items.Add(Convert.ToString(d["name"]));            
            }
        }
        public void Enabled(Serology_Data d)
        {
            TbPathologist.Text = d.Pathologist;
            TbMedTech_1.Text = d.MedTech_1;
            CbMedTech_2.SelectedIndex = 0;

            if (!d.Enabled)
            {
                ReadOnly();
            }


            switch (d.Type)
            {
                case "BLOOD TEST": 
                            break;
                case "HEP A": 
                            CbHBsAgResults.IsEnabled = false;
                            CbSyphilisResults.IsEnabled = false;
                            cbAntiHCVResults.IsEnabled = false;

                            TbHBsAgRemarks.IsEnabled = false;
                            TbSyphilisRemarks.IsEnabled = false;
                            tbAntiHCVRemarks.IsEnabled = false;

                            lbAntiHIV.Text = "Anti HAV";
                            lbHBsAg.Text = "";
                            lbSyphilis.Text = "";
                            lbAntiHCV.Text = "";
                            break;

                case "HIV": CbHBsAgResults.IsEnabled = false;
                            CbSyphilisResults.IsEnabled = false;
                            cbAntiHCVResults.IsEnabled = false;

                            TbHBsAgRemarks.IsEnabled = false;
                            TbSyphilisRemarks.IsEnabled = false;
                            tbAntiHCVRemarks.IsEnabled = false;

                            lbAntiHIV.Text = "Anti HIV 1/2";
                            lbHBsAg.Text = "";
                            lbSyphilis.Text = "";
                            lbAntiHCV.Text = "";
                            break;

                case "HEP B": 
                case "ANTI-HBS":
                            CbAntiHIVResults.IsEnabled = false;
                            CbSyphilisResults.IsEnabled = false;
                            cbAntiHCVResults.IsEnabled = false;
                            
                            TbAntiHIVRemarks.IsEnabled = false;
                            TbSyphilisRemarks.IsEnabled = false;
                            tbAntiHCVRemarks.IsEnabled = false;

                            lbAntiHIV.Text = "";
                            lbHBsAg.Text = d.Type;
                            lbSyphilis.Text = "";
                            lbAntiHCV.Text = "";
                            break;
                case "RPR":
                case "VDRL": CbAntiHIVResults.IsEnabled = false;
                             CbHBsAgResults.IsEnabled = false;
                             cbAntiHCVResults.IsEnabled = false;

                            TbAntiHIVRemarks.IsEnabled = false;
                            TbHBsAgRemarks.IsEnabled = false;
                            tbAntiHCVRemarks.IsEnabled = false;

                            lbAntiHIV.Text = "";
                            lbHBsAg.Text = "";
                            lbSyphilis.Text = "Syphilis";
                            lbAntiHCV.Text = "";
                            break;

                case "HEP C": 
                            CbAntiHIVResults.IsEnabled = false;
                            CbHBsAgResults.IsEnabled = false;
                            CbSyphilisResults.IsEnabled = false;

                            TbAntiHIVRemarks.IsEnabled = false;
                            TbHBsAgRemarks.IsEnabled = false;
                            TbSyphilisRemarks.IsEnabled = false;

                            lbAntiHIV.Text = "";
                            lbHBsAg.Text = "";
                            lbSyphilis.Text = "";
                            lbAntiHCV.Text = "Anti-HCV";
                            break;
            }

            

        }
        public void Save()
        {
            if (!String.IsNullOrWhiteSpace(TbMedTech_1.Text))
            {
                if (!String.IsNullOrWhiteSpace(TbPathologist.Text))
                {
                    PasswordPage ppage = new PasswordPage();
                    ppage.TableName = "office_user";

                    if (ppage.ShowDialog() == true)
                    {
                        SerologyDB db = new SerologyDB(Properties.Settings.Default.Server,
                                                         Properties.Settings.Default.Database,
                                                         Properties.Settings.Default.UserID,
                                                         Properties.Settings.Default.Port,
                                                         Properties.Settings.Default.Password);

                        BtSaveRecord.Content = "SAVING...";
                        BtSaveRecord.IsEnabled = false;

                        data.Serology[type].PrintedBy = ppage.User;
                        db.ControlNo = data.ControlNo;
                        db.Data = data.Serology[type];

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
        public void Preview()
        {
            doc.CyberPreview(new List<LabClientInfo>() { data },type); ;
        }
        public void Print()
        {
            doc.Preview(new List<LabClientInfo>() { data }, type);
        }
        private void SetSerologyResults(DataTable results)
        {
            foreach (DataRow res in results.Rows)
            {
                CbAntiHIVResults.Items.Add(Convert.ToString(res["results"]));
                CbHBsAgResults.Items.Add(Convert.ToString(res["results"]));
                CbSyphilisResults.Items.Add(Convert.ToString(res["results"]));
                cbAntiHCVResults.Items.Add(Convert.ToString(res["results"]));
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
