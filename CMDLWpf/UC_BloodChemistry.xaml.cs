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
    /// Interaction logic for UC_BloodChemistry.xaml
    /// </summary>
    public partial class UC_BloodChemistry : UserControl
    {
        Test_BloodChemistry bloodChemistry;
        List<MedicalTechnologist> medtechList;
        List<Pathologist> pathoList;

        public UC_BloodChemistry(Test_BloodChemistry obj)
        {
            InitializeComponent();

            this.DataContext = obj;
            this.dgList.DataContext = obj.ItemList;
            bloodChemistry = obj;
            btAdd.Click += new RoutedEventHandler(btAdd_Click);
            btDelete.Click += new RoutedEventHandler(btDelete_Click);
        }

        void btDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = dgList.SelectedItem as Test_BloodChemistry_Item;
            if (obj != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this item?[Y/N]", "Delete Message", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    obj.Category = null;
                    obj.CuHL = null;
                    obj.CuRes = null;
                    obj.CuUnit = null;
                    obj.CuValue = null;
                    obj.SiHL = null;
                    obj.SiRes = null;
                    obj.SiUnit = null;
                    obj.SiValue = null;
                }
            }
        }

        void btAdd_Click(object sender, RoutedEventArgs e)
        {
            var obj = dgList.SelectedItem as Test_BloodChemistry_Item;
            if (obj != null)
            {
                BloodChemistryItemForm bcForm = new BloodChemistryItemForm(obj);
                bcForm.ShowDialog();
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
