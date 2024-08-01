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
    /// Interaction logic for UC_CultureAndSensitivity.xaml
    /// </summary>
    public partial class UC_CultureAndSensitivity : UserControl
    {
        Test_CultureAndSensitivity cultureAndSensitivity;
        List<MedicalTechnologist> medtechList;
        List<Pathologist> pathoList;

        public UC_CultureAndSensitivity(Test_CultureAndSensitivity obj)
        {
            InitializeComponent();

            this.DataContext = obj;
            this.dgList.DataContext = obj.ItemList;
            cultureAndSensitivity = obj;
            btAddGramStaining.Click += new RoutedEventHandler(btAddGramStaining_Click);
            btAddIDO.Click += new RoutedEventHandler(btAddIDO_Click);
            btAddCultureAndSensitivity.Click += new RoutedEventHandler(btAddCultureAndSensitivity_Click);
        }

        void btAddCultureAndSensitivity_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void btAddIDO_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void btAddGramStaining_Click(object sender, RoutedEventArgs e)
        {
           
        }

        public List<MedicalTechnologist> MedTechList
        {
            set
            {
                foreach (var m in value)
                    cbMedTech.Items.Add(m.Name);

                medtechList = value;
            }
        }

        public List<Pathologist> PathologistList
        {
            set
            {
                foreach (var p in value)
                    cbPathologist.Items.Add(p.Name);

                pathoList = value;
            }
        }
    }
}
