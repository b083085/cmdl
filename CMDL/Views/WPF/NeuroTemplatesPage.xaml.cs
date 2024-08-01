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
    /// Interaction logic for NeuroTemplatesPage.xaml
    /// </summary>
    public partial class NeuroTemplatesPage : Window
    {
        DataTable neuro_temp;

        public NeuroTemplatesPage(DataTable neuro_temp)
        {
            InitializeComponent();
            dataGrid1.AutoGenerateColumns = false;
            dataGrid1.CanUserDeleteRows = false;
            dataGrid1.CanUserAddRows = false;
            this.neuro_temp = neuro_temp;

            dataGrid1.DataContext = neuro_temp;
    
        }

        private void BtImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRow temp = neuro_temp.Rows[dataGrid1.SelectedIndex];
                //NPage.TbRemarks.Text = Convert.ToString(temp["remarks"]);
            }
            catch (Exception)
            {
                //DONE
            }
        }

        public NeuroV1Page NPage
        {
            set;
            get;
        }

    }
}
