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
using System.Windows.Shapes;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for DateForm.xaml
    /// </summary>
    public partial class DateForm : Window
    {
        public DateForm()
        {
            InitializeComponent();

            btOK.Click += new RoutedEventHandler(btOK_Click);
            dpDateSearch.KeyDown += new KeyEventHandler(dpDateSearch_KeyDown);
        }

        void dpDateSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.DialogResult = true;
        }

        void btOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }


        public DateTime? SelectedDate
        {
            get
            {
                return dpDateSearch.SelectedDate;
            }
        }
    }
}
