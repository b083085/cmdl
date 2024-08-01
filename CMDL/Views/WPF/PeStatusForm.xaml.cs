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
    /// Interaction logic for PeStatusForm.xaml
    /// </summary>
    public partial class PeStatusForm : Window
    {
        public PeStatusForm()
        {
            InitializeComponent();
            btDone.Click += new RoutedEventHandler(btDone_Click);
            btEvaluationPending.Click += new RoutedEventHandler(btEvaluationPending_Click);
        }

        void btEvaluationPending_Click(object sender, RoutedEventArgs e)
        {
            Status = "EVALUATION PENDING";
            this.DialogResult = true;
        }

        void btDone_Click(object sender, RoutedEventArgs e)
        {
            Status = "DONE";
            this.DialogResult = true;
        }

        public string Status
        {
            set;
            get;
        }
    }


}
