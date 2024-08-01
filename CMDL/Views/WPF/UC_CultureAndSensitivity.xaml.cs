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
using System.Data;
using System.ComponentModel;
using CMDL.DAL;
using CMDL.Reports;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for UC_CultureAndSensitivity.xaml
    /// </summary>
    public partial class UC_CultureAndSensitivity : UserControl
    {
        List<IDO> idoList = new List<IDO>();
        List<Sensitivity> sensList = new List<Sensitivity>();
        List<CS_GramStain> csGSList = new List<CS_GramStain>();

        BackgroundWorker bgworker = new BackgroundWorker();
        

        LabClientInfo data;

        
        public UC_CultureAndSensitivity(LabClientInfo data,cmdldbDataSet cmdl,bool allowPrint, string userName)
        {
            InitializeComponent();
            this.data = data;
            this.AllowPrint = allowPrint;
            this.UserName = userName;

            lbGramStainResults.DataContext = data.CultureAndSensitivity.GramStainResult;
            lvIDO.DataContext = data.CultureAndSensitivity.IDOResult;
            lvSensitivities.DataContext = data.CultureAndSensitivity.SensitivityResult;
            this.DataContext = data.CultureAndSensitivity;

            foreach (DataRow dr in cmdl.Tables["medtech"].Rows)
                cbMedTech.Items.Add(Convert.ToString(dr["name"]));

            foreach (DataRow dr in cmdl.Tables["pathologist"].Rows)
                cbPathologist.Items.Add(Convert.ToString(dr["name"]));


            foreach (DataRow d in cmdl.Tables["dict_gramstain"].Rows)
                cbGramStainResults.Items.Add(d["note"]);

            foreach (DataRow d in cmdl.Tables["dict_IDO"].Rows)
            {
                cbIdentifiedOrganisms.Items.Add(d["note"]);
                cbIDOCount.Items.Add(d["counts"]); 
            }

            foreach (DataRow d in cmdl.Tables["dict_sensitivity"].Rows)
            {
                cbSensitivities.Items.Add(d["sensitivities"]);
                cbCountSensitivity.Items.Add(d["counts"]);
                cbCount2Sensitivity.Items.Add(d["counts"]);
            }

            btGramStainAdd.Click += new RoutedEventHandler(btGramStainAdd_Click);
            btIDOAdd.Click += new RoutedEventHandler(btIDOAdd_Click);
            btSensitivityAdd.Click += new RoutedEventHandler(btSensitivityAdd_Click);
            btGramStainRemove.Click += new RoutedEventHandler(btGramStainRemove_Click);
            btIDORemove.Click += new RoutedEventHandler(btIDORemove_Click);
            btSensitivityRemove.Click += new RoutedEventHandler(btSensitivityRemove_Click);
            btSaveRecord.Click += new RoutedEventHandler(btSaveRecord_Click);
            btPreview.Click += new RoutedEventHandler(btPreview_Click);

            cbIdentifiedOrganisms.SelectionChanged += new SelectionChangedEventHandler(cbIdentifiedOrganisms_SelectionChanged);
            cbSensitivities.SelectionChanged += new SelectionChangedEventHandler(cbSensitivities_SelectionChanged);

            bgworker.WorkerSupportsCancellation = true;
            bgworker.DoWork += new DoWorkEventHandler(bgworker_DoWork);
            bgworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgworker_RunWorkerCompleted);

            ReadOnly(data.CultureAndSensitivity.Enabled);

        }

        void btSensitivityRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sel = lvSensitivities.SelectedItem as Sensitivity;
                data.CultureAndSensitivity.SensitivityResult.Remove(sel);

                lvSensitivities.Items.Refresh();
            }
            catch (Exception)
            {
            }
        }

        void btIDORemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sel = lvIDO.SelectedItem as IDO;
                data.CultureAndSensitivity.IDOResult.Remove(sel);

                lvIDO.Items.Refresh();
            }
            catch (Exception)
            {
            }
        }

        void btGramStainRemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sel = lbGramStainResults.SelectedItem as CS_GramStain;
                data.CultureAndSensitivity.GramStainResult.Remove(sel);
                lbGramStainResults.Items.Refresh();
            }
            catch (Exception)
            {
            }
        }

        void btPreview_Click(object sender, RoutedEventArgs e)
        {
            Preview();
        }

        void btSaveRecord_Click(object sender, RoutedEventArgs e)
        {
            if (btSaveRecord.Content.ToString() == "SAVE RECORD")
                Save();
            else if (btSaveRecord.Content.ToString() == "PRINT")
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
                btSaveRecord.Content = "SAVE RECORD";
            }
            else
            {
                MessageBox.Show((string)e.Result);

                if ((string)e.Result == "RECORD SAVED!")
                {
                    data.CultureAndSensitivity.Enabled = false;
                    data.Count += 1;
                    data.Status = (data.Count == data.Total_Count ? "DONE" : "NOT DONE");
                    ReadOnly(false);
                    Print();
                }
                else
                {
                    btSaveRecord.Content = "SAVE RECORD";
                }
            }

            btSaveRecord.IsEnabled = true;
        }

        void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var arg = e.Argument as CultureAndSensitivityDB;
                arg.Select("select * from cultureandsensitivity where csNo='000000000000'", "cultureandsensitivity");
                if (arg.Save_CS())
                {
                    arg.Select("select * from cs_gramstain where gsNo='000000000000'", "cs_gramstain");
                    if (arg.Save_CS_GramStain())
                    {
                        arg.Select("select * from cs_ido where csIDONo='000000000000'", "cs_ido");
                        if (arg.Save_CS_IDO())
                        {
                            arg.Select("select * from cs_sensitivities where cssNo='000000000000'", "cs_sensitivities");
                            if (arg.Save_CS_Sensitivity())
                            {
                                e.Result = "RECORD SAVED!";
                            }
                            else
                            {
                                e.Result = "Unable to save sensitivity record!";
                            }
                        }
                        else
                        {
                            e.Result = "Unable to save identified organism record!";
                        }

                    }
                    else
                    {
                        e.Result = "Unable to save gram stain record!";
                    }
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
            cbGramStainResults.IsEnabled = value;
            cbIdentifiedOrganisms.IsEnabled = value;
            cbIDOCount.IsEnabled = value;
            cbSensitivities.IsEnabled = value;
            cbCountSensitivity.IsEnabled = value;
            tbNote.IsEnabled = value;
            btGramStainAdd.IsEnabled = value;
            btIDOAdd.IsEnabled = value;
            btSensitivityAdd.IsEnabled = value;
            btGramStainRemove.IsEnabled = value;
            btIDORemove.IsEnabled = value;
            btSensitivityRemove.IsEnabled = value;
            tbSample.IsEnabled = value;
            cbMedTech.IsEnabled = value;
            cbPathologist.IsEnabled = value;
            btSaveRecord.Content = value ? "SAVE RECORD" : "PRINT";
        }

        public void Save()
        {
            if (!String.IsNullOrWhiteSpace(cbMedTech.Text))
            {
                if (!String.IsNullOrWhiteSpace(cbPathologist.Text))
                {
                    PasswordPage ppage = new PasswordPage();
                    ppage.TableName = "office_user";

                    if (ppage.ShowDialog() == true)
                    {
                        CultureAndSensitivityDB db = new CultureAndSensitivityDB(Properties.Settings.Default.Server,
                                                                         Properties.Settings.Default.Database,
                                                                         Properties.Settings.Default.UserID,
                                                                         Properties.Settings.Default.Port,
                                                                         Properties.Settings.Default.Password);

                        btSaveRecord.Content = "SAVING...";
                        btSaveRecord.IsEnabled = false;

                        data.CultureAndSensitivity.PrintedBy = ppage.User;


                        db.Data = data.CultureAndSensitivity;

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
            SamplePreview(true);   
        }

        public void Preview()
        {
            SamplePreview(false);
        }

        public void SamplePreview(bool showbutton)
        {
            CultureAndSensitivityDB db = new CultureAndSensitivityDB(Properties.Settings.Default.Server,
                                                                         Properties.Settings.Default.Database,
                                                                         Properties.Settings.Default.UserID,
                                                                         Properties.Settings.Default.Port,
                                                                         Properties.Settings.Default.Password);

            var ds = new cmdldbDataSet(); 
            db.Select("select * from reg where controlno='" + data.CultureAndSensitivity.CSNo + "'", "reg");
            foreach (var d in db.returnrow)
            {
                ds.Tables["reg"].Rows.Add(d.ItemArray);
            }

            db.Select("select * from cultureandsensitivity where csNo='" + data.CultureAndSensitivity.CSNo + "'", "cultureandsensitivity");
            foreach (var d in db.returnrow)
            {
                ds.Tables["cultureandsensitivity"].Rows.Add(d.ItemArray);
            }

            db.Select("select * from cs_gramstain where gramNo='" + data.CultureAndSensitivity.CSNo + "'", "cs_gramstain");
            foreach (var d in db.returnrow)
            {
                ds.Tables["cs_gramstain"].Rows.Add(d.ItemArray);
            }

            db.Select("select * from cs_ido where idoNo='" + data.CultureAndSensitivity.CSNo + "'", "cs_ido");
            foreach (var d in db.returnrow)
            {
                ds.Tables["cs_ido"].Rows.Add(d.ItemArray);
            }

            db.Select("select * from cs_sensitivities where senseNo='" + data.CultureAndSensitivity.CSNo + "'", "cs_sensitivities");
            foreach (var d in db.returnrow)
            {
                ds.Tables["cs_sensitivities"].Rows.Add(d.ItemArray);
            }

            var csRep = new CultureAndSensitivityReport();
            csRep.SetDataSource((cmdldbDataSet)ds);

            CrystalReportForm csrepform = new CrystalReportForm(csRep,showbutton);
            csrepform.ShowDialog();
        }

        void cbSensitivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbCountSensitivity.SelectedIndex = cbSensitivities.SelectedIndex;
        }

        void cbIdentifiedOrganisms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbIDOCount.SelectedIndex = cbIdentifiedOrganisms.SelectedIndex;
        }

        void btSensitivityAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.CultureAndSensitivity.SensitivityResult.Add(new Sensitivity
                {
                    senseNo = data.CultureAndSensitivity.CSNo,
                    Sensitivities = cbSensitivities.Text,
                    Count = cbCountSensitivity.Text,
                    Count2 = cbCount2Sensitivity.Text
                });

                lvSensitivities.Items.Refresh();
            }
            catch (Exception)
            {
            }
        }

        void btIDOAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.CultureAndSensitivity.IDOResult.Add(new IDO
                {
                    IDONo = data.CultureAndSensitivity.CSNo,
                    Organism = Convert.ToString(cbIdentifiedOrganisms.Text),
                    Count = Convert.ToString(cbIDOCount.Text)
                });

                lvIDO.Items.Refresh();
            }
            catch (Exception)
            {
            }
        }

        void btGramStainAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                data.CultureAndSensitivity.GramStainResult.Add(new CS_GramStain
                {
                    GramNo = data.CultureAndSensitivity.CSNo,
                    Result = cbGramStainResults.Text
                });
                lbGramStainResults.Items.Refresh();
            }
            catch (Exception)
            {
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

    public class CS_GramStain
    {
        public string GSNo
        {
            set;
            get;
        }

        public string GramNo
        {
            set;
            get;
        }

        public string Result
        {
            set;
            get;
        }
    }

    public class IDO
    {
        public string csIDONo
        {
            set;
            get;
        }

        public string IDONo
        {
            set;
            get;
        }

        public string Organism
        {
            set;
            get;
        }

        public string Count
        {
            set;
            get;
        }
    }

    public class Sensitivity
    {
        public string cssNo
        {
            set;
            get;
        }

        public string senseNo
        {
            set;
            get;
        }
        
        public string Sensitivities
        {
            set;
            get;
        }

        public string Count
        {
            set;
            get;
        }

        public string Count2
        {
            set;
            get;
        }
    }
}
