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

namespace CMDLWpf
{
    /// <summary>
    /// Interaction logic for IDOForm.xaml
    /// </summary>
    public partial class IDOForm : Window
    {
        public RoutedEventHandler AddClickEvent;
        
        public IDOForm()
        {
            InitializeComponent();
            btAdd.Click += new RoutedEventHandler(btAdd_Click);
            btOK.Click += new RoutedEventHandler(btOK_Click);
        }

        void btOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (AddClickEvent != null)
                AddClickEvent(this, e);
        }
    }
}
