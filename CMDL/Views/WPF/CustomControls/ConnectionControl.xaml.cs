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
using MySql.Data.MySqlClient;
using System.Data.Entity.Core.EntityClient;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for ConnectionControl.xaml
    /// </summary>
    public partial class ConnectionControl : UserControl
    {
        public delegate void ClickEventHandler();
        public event ClickEventHandler CancelClickEvent;
        
        public ConnectionControl()
        {
            InitializeComponent();

            tbServer.Text = Properties.Settings.Default.Server;
            tbDatabase.Text = Properties.Settings.Default.Database;
            tbUserID.Text = Properties.Settings.Default.UserID;
            pbPassword.Password = Properties.Settings.Default.Password;
            tbPort.Text = Properties.Settings.Default.Port; 
            
            btnCancel.Click += new RoutedEventHandler(btnCancel_Click);
            btnSave.Click += new RoutedEventHandler(btnSave_Click);

            this.Loaded += new RoutedEventHandler(Uc_ConnectionControl_Loaded);
        }

        void Uc_ConnectionControl_Loaded(object sender, RoutedEventArgs e)
        {
            tbServer.Focus();
        }
        void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Server = tbServer.Text;
            Properties.Settings.Default.Database = tbDatabase.Text;
            Properties.Settings.Default.UserID = tbUserID.Text;
            Properties.Settings.Default.Password = pbPassword.Password;
            Properties.Settings.Default.Port = tbPort.Text;
            Properties.Settings.Default.Save();


            MySqlConnectionStringBuilder sqlBuilder = new MySqlConnectionStringBuilder();
            sqlBuilder.Server = tbServer.Text;
            sqlBuilder.Database = tbDatabase.Text;
            sqlBuilder.UserID = tbUserID.Text;
            sqlBuilder.Password = pbPassword.Password;
            sqlBuilder.PersistSecurityInfo = true;

            EntityConnectionStringBuilder efBuilder = new EntityConnectionStringBuilder();
            efBuilder.Metadata = "res://*/Models.CyberModel.csdl|res://*/Models.CyberModel.ssdl|res://*/Models.CyberModel.msl";
            efBuilder.Provider = "MySql.Data.MySqlClient";
            efBuilder.ProviderConnectionString = sqlBuilder.ConnectionString;

            Properties.Settings.Default.EFConnectionString = efBuilder.ConnectionString;
            Properties.Settings.Default.Save();

            MessageBox.Show("Connection settings saved!");
        }
        void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (CancelClickEvent != null)
                CancelClickEvent();
        }
    }
}
