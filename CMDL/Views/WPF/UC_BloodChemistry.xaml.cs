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
using CMDL.Reports;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for UC_BloodChemistry.xaml
    /// </summary>
    public partial class UC_BloodChemistry : UserControl
    {


        LabClientInfo data;
        cmdldbDataSet cmdl;

        BloodChemistryDB db = new BloodChemistryDB(Properties.Settings.Default.Server,
                                                                 Properties.Settings.Default.Database,
                                                                 Properties.Settings.Default.UserID,
                                                                 Properties.Settings.Default.Port,
                                                                 Properties.Settings.Default.Password);

        BackgroundWorker bgworker = new BackgroundWorker();

        public UC_BloodChemistry(LabClientInfo data, cmdldbDataSet cmdl, bool allowPrint, string userName)
        {
            InitializeComponent();

            this.data = data;
            this.cmdl = cmdl;
            this.AllowPrint = allowPrint;
            this.UserName = userName;

            lvChemistry.DataContext = data.BloodChemistry.ItemList;


            this.DataContext = data.BloodChemistry;


            btAdd.Click += new RoutedEventHandler(btAdd_Click);

            btRemoveChemistry.Click += new RoutedEventHandler(btRemoveChemistry_Click);
            btSaveRecord.Click += new RoutedEventHandler(btSaveRecord_Click);
            btPreview.Click += new RoutedEventHandler(btPreview_Click);

            bgworker.WorkerSupportsCancellation = true;
            bgworker.DoWork += new DoWorkEventHandler(bgworker_DoWork);
            bgworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgworker_RunWorkerCompleted);

            ReadOnly(data.BloodChemistry.Enabled);

            tbCUValue.KeyDown += new KeyEventHandler(tbCUValue_KeyDown);
            tbSIValue.KeyDown += new KeyEventHandler(tbSIValue_KeyDown);

            foreach (DataRow dr in cmdl.Tables["medtech"].Rows)
                cbMedicalTechnologist.Items.Add(Convert.ToString(dr["name"]));

            foreach (DataRow dr in cmdl.Tables["pathologist"].Rows)
                cbPathologist.Items.Add(Convert.ToString(dr["name"]));
        
        }

        void tbSIValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                tbSIValue.Text += " ` ";
        }

        void tbCUValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                tbCUValue.Text += " ` ";
        }

        void btPreview_Click(object sender, RoutedEventArgs e)
        {
            Preview();
        }

        void btSaveRecord_Click(object sender, RoutedEventArgs e)
        {
            if (btSaveRecord.Content.ToString() == "Save Record")
                Save();
            else if (btSaveRecord.Content.ToString() == "Print")
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
                    data.BloodChemistry.Enabled = false;
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
                var arg = e.Argument as BloodChemistryDB;
                arg.Select("select * from bloodchemistry where bcID='000000000000'", "bloodchemistry");
                if (arg.Save_BC())
                {
                    arg.Select("select * from blood_chemistry_items where bcID='000000000000'", "blood_chemistry_items");
                    if (arg.Save_BC_Item())
                    {
                        e.Result = "RECORD SAVED!";

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

        void btRemoveChemistry_Click(object sender, RoutedEventArgs e)
        {
            var item = lvChemistry.SelectedItem as Blood_Chemistry_Items_Data;
            data.BloodChemistry.ItemList.Remove(item);
            lvChemistry.Items.Refresh();
            
        }

        void btAdd_Click(object sender, RoutedEventArgs e)
        {

            var item = new Blood_Chemistry_Items_Data(true);
            item.BcID = data.ControlNo;
            item.Category = cbCategory.Text;
            item.Chemistry = tbChemistry.Text;
            item.CUHL = cbCUHL.Text;
            item.CURes = tbCUResult.Text;
            item.CUUnit = tbCUUnit.Text;
            item.CUValue = tbCUValue.Text;
            item.SIHL = tbSIHL.Text;
            item.SIRes = tbSIResult.Text;
            item.SIUnit = tbSIUnit.Text;
            item.SIValue = tbSIValue.Text;

             data.BloodChemistry.ItemList.Add(item);
            lvChemistry.Items.Refresh();
        }

        public void Save()
        {
            var ppage = new PasswordPage();
            ppage.TableName = "office_user";

            if (ppage.ShowDialog() == true)
            {
                btSaveRecord.Content = "SAVING...";
                btSaveRecord.IsEnabled = false;

                data.BloodChemistry.PrintedBy = ppage.User;
                db.Data = data.BloodChemistry;

                bgworker.RunWorkerAsync(db);
            }
        }

        public void ReadOnly(bool value)
        {
            tbChemistry.IsEnabled = value;
            cbCUHL.IsEnabled = value;
            tbCUResult.IsEnabled = value;
            tbCUUnit.IsEnabled = value;
            tbCUValue.IsEnabled = value;
            tbSIHL.IsEnabled = value;
            tbSIResult.IsEnabled = value;
            tbSIUnit.IsEnabled = value;
            tbSIValue.IsEnabled = value;
            cbCategory.IsEnabled = value;
            btAdd.IsEnabled = value;
            btRemoveChemistry.IsEnabled = value;
            tbNote.IsEnabled = value;
            cbMedicalTechnologist.IsEnabled = value;
            cbPathologist.IsEnabled = value;
            btSaveRecord.Content = value ? "Save Record" : "Print";
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
            var ds = new cmdldbDataSet();

            db.Select("select * from reg where controlno='" + data.ControlNo + "'", "reg");
            foreach (var d in db.returnrow)
                ds.Tables["reg"].Rows.Add(d.ItemArray);

            db.Select("select * from bloodchemistry where bcID='" + data.ControlNo + "'", "bloodchemistry");
            foreach (var d in db.returnrow)
                ds.Tables["bloodchemistry"].Rows.Add(d.ItemArray);

            db.Select("select * from blood_chemistry_items where bcID='" + data.ControlNo + "'", "blood_chemistry_items");
            foreach (var d in db.returnrow)
                ds.Tables["blood_chemistry_items"].Rows.Add(d.ItemArray);



            var bcRep = new BloodChemistryReport();
            bcRep.SetDataSource((cmdldbDataSet)ds);

            CrystalReportForm csrepform = new CrystalReportForm(bcRep, showbutton);
            csrepform.ShowDialog();
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
