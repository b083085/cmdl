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
using System.Data;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for XRayTemplates.xaml
    /// </summary>
    public partial class XRayTemplatesPage : Window
    {
        DataTable templates;
        public XRayTemplatesPage(DataTable templates)
        {
            InitializeComponent();
            dataGrid1.AutoGenerateColumns = false;
            dataGrid1.CanUserDeleteRows = false;
            dataGrid1.CanUserAddRows = false;

            dataGrid1.DataContext = templates;
            this.templates = templates;

        }

        private void BtImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow temp = templates.Rows[dataGrid1.SelectedIndex];
                XPage.TbRadioReport.Text = Convert.ToString(temp["radio_report"]);
                XPage.TbConclusion.Text = Convert.ToString(temp["conclusion"]);
            }
            catch (Exception)
            {
 
            }

        }

        public XRayPage XPage
        {
            set;
            get;
        }
    }
}
