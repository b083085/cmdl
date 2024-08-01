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

namespace CMDL.WPF
{
    /// <summary>
    /// Interaction logic for UC_Serology1.xaml
    /// </summary>
    public partial class UC_Serology1 : UserControl
    {

        private bool allowPrint;
        private string userName;
        private LabClientInfo client;
        
        public UC_Serology1(LabClientInfo client, bool allowPrint,string userName)
        {
            InitializeComponent();

            this.client = client;
            this.allowPrint = allowPrint;
            this.userName = userName;


            this.DataContext = client.TestSerology;

            BtSaveRecord.Click += new RoutedEventHandler(BtSaveRecord_Click);
            BtPreview.Click += new RoutedEventHandler(BtPreview_Click);
        }


        #region EVENTS
        void BtPreview_Click(object sender, RoutedEventArgs e)
        {
        }
        void BtSaveRecord_Click(object sender, RoutedEventArgs e)
        {
        }
        #endregion

        #region FUNCTIONS

        #endregion
    }
}
