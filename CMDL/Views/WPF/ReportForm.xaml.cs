using CMDL.Views.WPF.ReportFilters;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace CMDL.Views.WPF
{
    /// <summary>
    /// Interaction logic for ReportForm.xaml
    /// </summary>
    public partial class ReportForm : Window
    {
        ReportClass _report;

        public ReportForm(UserControl filter)
        {
            InitializeComponent();

            if (filter != null)
            {
                var searchFilter = filter as IFilterEvent;
                searchFilter.SearchEvent -= SearchFilter_SearchEvent;
                searchFilter.SearchEvent += SearchFilter_SearchEvent;

                filterContent.Content = filter;

                btnPrint.Click += BtnPrint_Click;
            }
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            if(_report == null)
            {
                MessageBox.Show("data is empty.");
                return;
            }

            var rf = new CrystalReportForm(_report, true);
            rf.ShowDialog();
        }
        private void SearchFilter_SearchEvent(ReportClass report, object dt)
        {
            _report = report;
            dgList.DataContext = dt;
        }
    }
}
