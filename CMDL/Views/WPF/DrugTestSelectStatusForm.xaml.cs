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
    /// Interaction logic for DrugTestSelectStatusForm.xaml
    /// </summary>
    public partial class DrugTestSelectStatusForm : Window
    {
        public DrugTestSelectStatusForm()
        {
            InitializeComponent();

            btDone.Click += new RoutedEventHandler(btDone_Click);
            btSkipped.Click += new RoutedEventHandler(btSkipped_Click);
        }

        void btSkipped_Click(object sender, RoutedEventArgs e)
        {
            Status = DrugTestSelectStatus.Skipped;
            this.DialogResult = true;
           
        }

        void btDone_Click(object sender, RoutedEventArgs e)
        {
            Status = DrugTestSelectStatus.Done;
            this.DialogResult = true;
        }

        public DrugTestSelectStatus Status
        {
            set;
            get;
        }
    }

    public enum DrugTestSelectStatus
    {
        Done,
        Skipped
    }
}
