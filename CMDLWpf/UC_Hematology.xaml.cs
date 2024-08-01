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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UC_Hematology : UserControl
    {
        List<MedicalTechnologist> medtechList;
        List<Pathologist> pathoList;
        
        public UC_Hematology(Test_Hematology obj)
        {
            InitializeComponent();

            this.DataContext = obj;
            uC_Hematology_Control1.Data = obj;
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
