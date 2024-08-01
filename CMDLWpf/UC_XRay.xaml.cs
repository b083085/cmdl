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
    /// Interaction logic for UC_XRay.xaml
    /// </summary>
    public partial class UC_XRay : UserControl
    {
        List<Radiologist> radiologistList;

        public UC_XRay(Test_XRay obj)
        {
            InitializeComponent();

            this.DataContext = obj;
        }

        public List<string> RadTechList
        {
            set
            {
                foreach (var r in value)
                {
                    cbPreparedBy.Items.Add(r);
                }
            }
        }

        public List<Radiologist> RadiologistList
        {
            set
            {
                foreach (var r in value)
                {
                    cbRadiologist.Items.Add(r.Name);
                }

                radiologistList = value;
            }
        }
    }
}
