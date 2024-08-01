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
    /// Interaction logic for UC_PhysicalExamination.xaml
    /// </summary>
    public partial class UC_PhysicalExamination : UserControl
    {
        List<Physician> _physicianList;
        
        public UC_PhysicalExamination(Test_PE obj)
        {
            InitializeComponent();

            this.DataContext = obj;
            uC_BodyParts1.BindingDataContext(obj);
            
        }


        public List<Physician> PhysicianList
        {
            set
            {
                foreach (var p in value)
                    cbPhysician.Items.Add(p.Name);

                _physicianList = value;
            }
        }
    }

    public class RecordExistConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                char val = (char)value;
                if (val == '1')
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                bool val = (bool)value;
                if (val)
                    return '1';
                else
                    return '0';
            }
            else
                return '0';
        }
    }
}
