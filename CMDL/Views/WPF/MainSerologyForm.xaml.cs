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
using System.Windows.Shapes;
using System.ComponentModel;
using CMDL.Models;
using System.Data.Objects.DataClasses;
using System.Windows.Threading;

namespace CMDL.WPF
{
    /// <summary>
    /// Interaction logic for MainSerologyForm.xaml
    /// </summary>
    public partial class MainSerologyForm : Window
    {
        BackgroundWorker bgWorker = new BackgroundWorker();
        BackgroundWorker bgWorkerLoading = new BackgroundWorker();
        DateTime selectedDate;
        string selectedTest;

        public MainSerologyForm()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainSerologyForm_Loaded);
            cbSearchItem.SelectionChanged += new SelectionChangedEventHandler(cbSearchItem_SelectionChanged);
            bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
            bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
            bgWorker.WorkerReportsProgress = true;

            bgWorkerLoading.DoWork += new DoWorkEventHandler(bgWorkerLoading_DoWork);
            bgWorkerLoading.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorkerLoading_RunWorkerCompleted);
            bgWorkerLoading.WorkerSupportsCancellation = true;
        }

        void bgWorkerLoading_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        void bgWorkerLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            var x = 0;

            while (x < 3)
            {
                if (x == 0)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                        {
                            lbMessage.Content = "Please Wait.";
                        }), DispatcherPriority.Background);

                    System.Threading.Thread.Sleep(500);
                    x += 1;
                }
                else if (x == 1)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lbMessage.Content = "Please Wait..";
                    }), DispatcherPriority.Background);

                    System.Threading.Thread.Sleep(500);

                    x += 1;
                }
                else if (x == 2)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        lbMessage.Content = "Please Wait...";
                    }), DispatcherPriority.Background);

                    System.Threading.Thread.Sleep(500);

                    x = 0;
                }
            }
        }
        void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                if(!bgWorkerLoading.IsBusy)
                    bgWorkerLoading.RunWorkerAsync();
            }
        }
        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgWorkerLoading.CancelAsync();
            border1.Visibility = Visibility.Collapsed;
        }
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var filter = e.Argument as string;
            List<reg> regs = new List<reg>();
            bgWorker.ReportProgress(0);
            using (var db = new CyberContext())
            {
                db.CommandTimeout = 600;
                switch (filter)
                {
                    case "TODAY":
                        regs = Today(regs, db);
                        break;
                    case "DATE":
                        regs = Date(regs, db);
                        break;
                    case "TEST":
                        Test(regs, db);
                        break;
                }

                Dispatcher.BeginInvoke(new Action(() =>
                    {
                        dgList.DataContext = regs;
                    }), DispatcherPriority.Background);
            }
        }
        private void Test(List<reg> regs, CyberContext db)
        {
            var serologyItems = db.test_serology_item
                .Include("test_serology")
                .Include("test_serology.reg")
                .Where(p => p.test == selectedTest)
                .ToList();

            foreach (var si in serologyItems)
            {
                var reg = db.regs.Where(p => p.controlno == si.test_serology.reg.controlno)
                        .FirstOrDefault();

                if (reg != null)
                {
                    #region NEW REG
                    var newReg = new reg();
                    newReg.controlno = reg.controlno;
                    newReg.date_reg = reg.date_reg;
                    newReg.photo = reg.photo;
                    newReg.lastname = reg.lastname;
                    newReg.firstname = reg.firstname;
                    newReg.mi = reg.mi;
                    newReg.suffix = reg.suffix;
                    newReg.address = reg.address;
                    newReg.age = reg.age;
                    newReg.sex = reg.sex;
                    newReg.civil_status = reg.civil_status;
                    newReg.bdate = reg.bdate;
                    newReg.bplace = reg.bplace;
                    newReg.reqparty = reg.reqparty;
                    newReg.purpose = reg.purpose;
                    newReg.telno = reg.telno;
                    newReg.celno = reg.celno;
                    newReg.district_branch = reg.district_branch;
                    newReg.exam = reg.exam;
                    newReg.price = reg.price;
                    newReg.total = reg.total;
                    newReg.amt_paid = reg.amt_paid;
                    newReg.amt_balance = reg.amt_balance;
                    newReg.amt_change = reg.amt_change;
                    newReg.time_in = reg.time_in;
                    newReg.time_out = reg.time_out;
                    newReg.exam_type = reg.exam_type;
                    #endregion

                    regs.Add(newReg);
                }
            }
        }
        private List<reg> Date(List<reg> regs, CyberContext db)
        {
            regs = db.regs
                .Where(p => p.date_reg.Value.Month == selectedDate.Month
                && p.date_reg.Value.Day == selectedDate.Day
                && p.date_reg.Value.Year == selectedDate.Year)
                .ToList();
            return regs;
        }
        private List<reg> Today(List<reg> regs, CyberContext db)
        {
            regs = db.regs
                .Where(p => p.date_reg.Value.Month == DateTime.Now.Month
                && p.date_reg.Value.Day == DateTime.Now.Day
                && p.date_reg.Value.Year == DateTime.Now.Year)
                .ToList();

            return regs;
        }
        void cbSearchItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = cbSearchItem.SelectedItem as string;
            switch (item)
            {
                case "TODAY":
                    if (!bgWorker.IsBusy)
                    {
                        border1.Visibility = Visibility.Visible;
                        contentControl1.Content = null;
                        bgWorker.RunWorkerAsync("TODAY");
                    }
                    break;
                case "DATE":
                    var dp = new DatePicker();
                    dp.SelectedDateChanged += new EventHandler<SelectionChangedEventArgs>(dp_SelectedDateChanged);
                    contentControl1.Content = dp;
                    break;
                case "TEST":
                    var cb = new ComboBox();
                    cb.Items.Add("HEP C");
                    cb.Items.Add("ANTI-HBS");
                    cb.Items.Add("BLOOD TEST");
                    cb.Items.Add("HEP A");
                    cb.Items.Add("HEP B");
                    cb.Items.Add("HIV");
                    cb.Items.Add("RPR");
                    cb.Items.Add("VDRL");
                    cb.SelectionChanged += new SelectionChangedEventHandler(cb_SelectionChanged);
                    contentControl1.Content = cb;
                    break;
            }
        }
        void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                border1.Visibility = Visibility.Visible;
                var cb = sender as ComboBox;
                selectedTest = cb.SelectedItem as string;
                bgWorker.RunWorkerAsync("TEST");
            }
        }
        void dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!bgWorker.IsBusy)
            {
                border1.Visibility = Visibility.Visible;
                var dp = sender as DatePicker;
                selectedDate = dp.SelectedDate.Value;
                bgWorker.RunWorkerAsync("DATE");
            }
        }
        void MainSerologyForm_Loaded(object sender, RoutedEventArgs e)
        {
            cbSearchItem.Items.Add("TODAY");
            cbSearchItem.Items.Add("DATE");
            cbSearchItem.Items.Add("TEST");
        }
        public string UserName
        {
            set;
            get;
        }
        public bool AllowPrint
        {
            set;
            get;
        }
        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            var reg = dgList.SelectedItem as reg;
            if (reg != null)
            {
                var frm = new SerologyForm(reg, UserName, AllowPrint);
                frm.Owner = this;
                frm.ShowDialog();
            }
        }
    }
}
