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
    /// Interaction logic for SearchBoxForm.xaml
    /// </summary>
    public partial class SearchBoxForm : Window
    {
        public SearchBoxForm()
        {
            InitializeComponent();

            btOK.Click += new RoutedEventHandler(btOK_Click);
            tbSearchBox.KeyDown += new KeyEventHandler(tbSearchBox_KeyDown);

            this.Loaded += new RoutedEventHandler(SearchBoxForm_Loaded);
        }

        void tbSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.DialogResult = true;
        }

        void SearchBoxForm_Loaded(object sender, RoutedEventArgs e)
        {
            tbSearchBox.Focus();
        }

        void btOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string Keyword
        {
            get
            {
                return tbSearchBox.Text;
            }
        }
    }
}
