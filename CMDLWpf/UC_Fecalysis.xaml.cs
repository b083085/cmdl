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
    /// Interaction logic for UC_Fecalysis.xaml
    /// </summary>
    public partial class UC_Fecalysis : UserControl
    {
        List<MedicalTechnologist> medtechList;
        List<Pathologist> pathoList;
        
        public UC_Fecalysis(Test_Fecalysis obj)
        {
            InitializeComponent();
            this.DataContext = obj;
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
