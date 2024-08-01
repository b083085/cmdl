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
    /// Interaction logic for CCFNoForm.xaml
    /// </summary>
    public partial class CCFNoForm : Window
    {
        int total = 0;
        public CCFNoForm(int count)
        {
            InitializeComponent();

            total = count + 1;
            this.Loaded += new RoutedEventHandler(CCFNoForm_Loaded);

            btOK.Click += new RoutedEventHandler(btOK_Click);
        }

        void btOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        void CCFNoForm_Loaded(object sender, RoutedEventArgs e)
        {
            tbDate.Text = string.Format("{0:yyyyMMdd}",DateTime.Now);
            tbNo.Text = total.ToString("0000");

            tbNo.Focus();
        }

        public string CCfNo
        {
            get
            {
                return tbDate.Text + tbNo.Text;
            }
        }
    }
}
