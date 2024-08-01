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
    /// Interaction logic for UC_Urinalysis.xaml
    /// </summary>
    public partial class UC_Urinalysis : UserControl
    {
        List<MedicalTechnologist> medtechList;
        List<Pathologist> pathoList;
        
        public UC_Urinalysis(Test_Urinalysis obj)
        {
            InitializeComponent();
            SetSpecificGravity();
            SetCast();

            this.DataContext = obj;
        }

        private void SetSpecificGravity()
        {
            for (decimal d = 1.005m; d < 1.032m; d += 0.001m)
            {
                cbSpecificGravity.Items.Add(Convert.ToString(d));
            }
        }

        private void SetCast()
        {
            cbFineGranularCast.Items.Add("0");
            cbCoarseGranularCast.Items.Add("0");
            cbWBCCast.Items.Add("0");
            cbRBCCast.Items.Add("0");
            cbBlood.Items.Add("0");
            cbLeukocytes.Items.Add("0");
            cbNitrite.Items.Add("0");
            cbKetone.Items.Add("0");
            cbUrobilinogen.Items.Add("0");
            cbAscorbicAcid.Items.Add("0");

            for (double i = 0.0; i <= 0.05; i += 0.01)
            {
                cbFineGranularCast.Items.Add(string.Format("{0:0.00}", i));
                cbCoarseGranularCast.Items.Add(string.Format("{0:0.00}", i));
                cbWBCCast.Items.Add(string.Format("{0:0.00}", i));
                cbRBCCast.Items.Add(string.Format("{0:0.00}", i));
                cbBlood.Items.Add(string.Format("{0:0.00}", i));
                cbLeukocytes.Items.Add(string.Format("{0:0.00}", i));
                cbNitrite.Items.Add(string.Format("{0:0.00}", i));
                cbKetone.Items.Add(string.Format("{0:0.00}", i));
                cbUrobilinogen.Items.Add(string.Format("{0:0.00}", i));
                cbAscorbicAcid.Items.Add(string.Format("{0:0.00}", i));
            }

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
