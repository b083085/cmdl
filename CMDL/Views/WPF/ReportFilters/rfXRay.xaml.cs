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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CMDL.Common;
using CMDL.Reports;
using CMDL.Reports.DataSource;
using CrystalDecisions.CrystalReports.Engine;

namespace CMDL.Views.WPF.ReportFilters
{
    /// <summary>
    /// Interaction logic for rfXRay.xaml
    /// </summary>
    public partial class rfXRay : UserControl, IFilterEvent
    {
        public event Action<ReportClass, object> SearchEvent;

        public rfXRay()
        {
            InitializeComponent();

            Loaded += RfXRay_Loaded;
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var query = "SELECT * FROM xray LIMIT 10";
                    var ds = db.Get(query);
                    if (db.HasRecords(ds))
                    {
                        var drc = db.GetRecords(ds);
                        var list = new List<XRayRep>();
                        foreach (DataRow dr in drc)
                        {
                            var x = new XRayRep();
                            x.Marker = dr.IsNull("marker") ? string.Empty : dr.Field<string>("marker");
                            x.RadiographicReport = dr.IsNull("radio_report") ? string.Empty : dr.Field<string>("radio_report");
                            x.Conclusion = dr.IsNull("conclusion") ? string.Empty : dr.Field<string>("conclusion");
                            x.Radiologist = dr.IsNull("radiologist") ? string.Empty : dr.Field<string>("radiologist");
                            x.PrintedBy = dr.IsNull("printedby") ? string.Empty : dr.Field<string>("printedby");

                            list.Add(x);
                        }
                        var rep = new XRaySummaryReport();
                        rep.SetDataSource(list);

                        SearchEvent?.Invoke(rep, list);
                    }
                    else
                    {
                        throw new Exception("No records found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(CyberMessage.GetException(ex), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            
            //SearchEvent?.Invoke();
        }
        private void RfXRay_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                GetDropDownItems();

                DateFrom = DateTime.Now;
                DateTo = DateTime.Now;

                cbGender.Items.Add("All");
                cbGender.Items.Add("Male");
                cbGender.Items.Add("Female");
            }
            catch (Exception)
            {
                //none
            }
        }
        private void GetDropDownItems()
        {
            using (var db = new DataContext())
            {
                var query = "SELECT * FROM Radiologist ORDER BY Name ASC";

                var ds = db.Get(query);
                if (db.HasRecords(ds))
                {
                    var drc = db.GetRecords(ds);

                    foreach (DataRow dr in drc)
                    {
                        if (!dr.IsNull("name"))
                        {
                            cbRadiologist.Items.Add(dr.Field<string>("name"));
                        }
                    }
                }
            }


        }

        public DateTime? DateFrom
        {
            get
            {
                return dpDateFrom.SelectedDate;
            }
            set
            {
                dpDateFrom.SelectedDate = value;
            }
        }
        public DateTime? DateTo
        {
            get
            {
                return dpDateTo.SelectedDate;
            }
            set
            {
                dpDateTo.SelectedDate = value;
            }
        }
        public string Gender
        {
            get
            {
                return cbGender.Text;
            }
            set
            {
                cbGender.Text = value;
            }
        }
        public string Radiologist
        {
            get
            {
                return cbRadiologist.Text;
            }
            set
            {
                cbRadiologist.Text = value;
            }
        }
    }
}
