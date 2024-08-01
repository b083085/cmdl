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

namespace CMDL
{
    /// <summary>
    /// Interaction logic for PasswordPage.xaml
    /// </summary>
    public partial class PasswordPage : Window
    {
        MySqlDB db;
        BackgroundWorker bgworker = new BackgroundWorker();

        object pwd = null;
        object tbname = null;

        public PasswordPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PasswordPage_Loaded);
            BtOK.Click += new RoutedEventHandler(BtOK_Click);
            passwordBox1.KeyDown += new KeyEventHandler(passwordBox1_KeyDown);

            bgworker.WorkerSupportsCancellation = true;
            bgworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgworker_RunWorkerCompleted);
            bgworker.DoWork += new DoWorkEventHandler(bgworker_DoWork);
        }

        public string TableName
        {
            set;
            get;
        }

        public string User
        {
            set;
            get;
        }

        void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MySqlDB argumentest = e.Argument as MySqlDB;
                argumentest.Select("select * from " + tbname + " where user_pwd='" + Convert.ToString(pwd) + "'", TableName);
                e.Result = argumentest;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }

        void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Unable to connect to the Database!Please contact your Database Administrator for further assistance!");
            }
            else
            {
                MySqlDB test = e.Result as MySqlDB;
                if (test.length > 0)
                {
                    System.Data.DataRow d = test.returnrow[0];
                    User = Convert.ToString(d["user_name"]);
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Invalid Password!Please try again...");
                    passwordBox1.Clear();
                }
            }
            passwordBox1.IsEnabled = true;
            BtOK.Content = "OK";
            BtOK.IsEnabled = true;
            passwordBox1.Focus();
        }

        void passwordBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Validate();
        }

        void BtOK_Click(object sender, RoutedEventArgs e)
        {
            Validate();
        }

        private void Validate()
        {
            passwordBox1.IsEnabled = false;
            BtOK.Content = "Validating...";
            BtOK.IsEnabled = false;
            

            pwd = passwordBox1.Password;
            tbname = TableName;

            bgworker.RunWorkerAsync(db);
        }

        void PasswordPage_Loaded(object sender, RoutedEventArgs e)
        {
            db = new MySqlDB(Properties.Settings.Default.Server,
                                 Properties.Settings.Default.Database,
                                 Properties.Settings.Default.UserID,
                                 Properties.Settings.Default.Port,
                                 Properties.Settings.Default.Password);

            passwordBox1.Focus();
        }

    }
}
