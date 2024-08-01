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
    /// Interaction logic for UC_DentalCertificate.xaml
    /// </summary>
    public partial class UC_DentalCertificate : UserControl
    {
        List<Dentist> dentistList;

        public UC_DentalCertificate(Test_DentalCertificate obj)
        {
            InitializeComponent();
            this.DataContext = obj;
        }

        public List<Dentist> DentistList
        {
            set
            {
                foreach (var d in value)
                    cbDentist.Items.Add(d.Name);

                dentistList = value;
            }
        }
    }
}
