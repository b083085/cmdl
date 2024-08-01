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
    /// Interaction logic for UC_MedicalCertificate.xaml
    /// </summary>
    public partial class UC_MedicalCertificate : UserControl
    {
        List<Physician> physicianList;

        public UC_MedicalCertificate(Test_MedicalCertificate obj)
        {
            InitializeComponent();
            this.DataContext = obj;
        }

        public List<Physician> PhysicianList
        {
            set
            {
                foreach (var d in value)
                    cbPhysician.Items.Add(d.Name);

                physicianList = value;
            }
        }
    }
}
