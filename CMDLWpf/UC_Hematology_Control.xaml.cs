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

namespace CMDLWpf
{
    /// <summary>
    /// Interaction logic for UC_Hematology_Control.xaml
    /// </summary>
    public partial class UC_Hematology_Control : UserControl
    {
        public UC_Hematology_Control()
        {
            InitializeComponent();
        }

        public Test_Hematology Data
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
