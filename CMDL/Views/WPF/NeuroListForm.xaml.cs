using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using CMDL.Common;
using CMDL.Models;
using System.Collections.ObjectModel;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for NeuroListForm.xaml
    /// </summary>
    public partial class NeuroListForm : Window
    {
        #region Querystrings
        private const string examQuery = "r.exam LIKE '%NEURO PSYCHOLOGICAL%'";
        private const string orderByQuery = "ORDER BY r.time_in ASC";

        private const string query = @"SELECT r.ControlNo,
                                        r.LastName,
                                        r.FirstName,
                                        r.MI,
                                        r.Suffix AS ExtName,
                                        r.Age,
                                        r.Sex AS Gender,
                                        r.Address,
                                        r.Purpose,
                                        r.ReqParty,
                                        r.time_in AS TimeIn,
                                        r.photo AS Photo,
                                        rn.IsDraft,
                                        IF(n.neuro_controlno,'Yes','No') AS Version1,
                                        IF(rn.ControlNo AND rn.B1 > 0,'Yes','No') AS Version2,
                                        IF(rn.ControlNo AND rn.B1 = 0,'Yes','No') AS Version3
                                        FROM reg r
                                        LEFT JOIN neuro n
                                        on r.controlno = n.neuro_controlno
                                        LEFT JOIN rev_neuro rn
                                        on r.controlno = rn.ControlNo";
        #endregion


        public NeuroListForm()
        {
            InitializeComponent();

            cbFilter.Items.Add(FilterConstants.TODAY);
            cbFilter.Items.Add(FilterConstants.CONTROL_NO);
            cbFilter.Items.Add(FilterConstants.DATE_RANGE);
            cbFilter.Items.Add(FilterConstants.LAST_NAME);
            cbFilter.Items.Add(FilterConstants.FIRST_NAME);
            cbFilter.Items.Add(FilterConstants.DONE);
            cbFilter.Items.Add(FilterConstants.NOT_DONE);

            Items = new ObservableCollection<NeuroItemV2>();

            Loaded += NeuroListForm_Loaded;
            tbKeywords.KeyDown += TbKeywords_KeyDown;
            cbFilter.SelectionChanged += CbFilter_SelectionChanged;
            btnSearch.Click += BtnSearch_Click;

            DataContext = this;
        }

        #region EVENTS
        private void NeuroListForm_Loaded(object sender, RoutedEventArgs e)
        {
            dpDateFrom.SelectedDate = DateTime.Now;
            dpDateTo.SelectedDate = DateTime.Now;
            cbFilter.SelectedItem = FilterConstants.TODAY;
        }
        private void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbKeywords.Focus();
        }
        private void TbKeywords_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Search();
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
        private void BtnStatus_Click(object sender, RoutedEventArgs e)
        {
            var item = dgItems.SelectedItem as NeuroItemV2;

            var frm = new NeuroEditForm();
            frm.SetBinding(item);
            frm.SaveRecordEvent += Frm_SaveRecordEvent;

            frm.ShowDialog();
        }
        private void Frm_SaveRecordEvent()
        {
            Search();
        }
        #endregion
        #region FUNCTIONS
        private void Search()
        {
            try
            {
                neuroGrid.IsEnabled = false;

                var filter = Convert.ToString(cbFilter.SelectedItem);
                var paramList = new List<MySqlParam>();
                var filterQuery = string.Empty;

                switch (filter)
                {
                    case FilterConstants.TODAY:
                        var today = DateTime.Now.ToString("yyyy-MM-dd");
                        filterQuery = $"{query} WHERE {examQuery} AND r.date_reg = @dt {orderByQuery}";

                        paramList.Add(new MySqlParam() { Key = "@dt", Value = today });
                        break;
                    case FilterConstants.CONTROL_NO:
                        var controlNo = tbKeywords.Text;
                        filterQuery = $"{query} WHERE {examQuery} AND r.ControlNo = @controlNo {orderByQuery}";

                        paramList.Add(new MySqlParam() { Key = "@controlNo", Value = controlNo });
                        break;
                    case FilterConstants.DATE_RANGE:
                    case FilterConstants.DONE:
                    case FilterConstants.NOT_DONE:
                        var dateFrom = dpDateFrom.SelectedDate.Value.ToString("yyyy-MM-dd");
                        var dateTo = dpDateTo.SelectedDate.Value.ToString("yyyy-MM-dd");
                        if (filter == FilterConstants.DATE_RANGE)
                        {
                            filterQuery = $"{query} WHERE {examQuery} AND r.date_reg BETWEEN @dtFrom AND @dtTo  {orderByQuery}";
                        }
                        else if (filter == FilterConstants.DONE)
                        {
                            filterQuery = $"{query} WHERE {examQuery} AND r.date_reg BETWEEN @dtFrom AND @dtTo AND (n.neuro_controlno IS NOT NULL OR (rn.ControlNo IS NOT NULL OR rn.IsDraft='0')) {orderByQuery}";
                        }
                        else if (filter == FilterConstants.NOT_DONE)
                        {
                            filterQuery = $"{query} WHERE {examQuery} AND r.date_reg BETWEEN @dtFrom AND @dtTo AND (n.neuro_controlno IS NULL AND (rn.ControlNo IS NULL OR rn.IsDraft='1')) {orderByQuery}";
                        }

                        paramList.Add(new MySqlParam() { Key = "@dtFrom", Value = dateFrom });
                        paramList.Add(new MySqlParam() { Key = "@dtTo", Value = dateTo });
                        break;
                    case FilterConstants.FIRST_NAME:
                        var firstName = tbKeywords.Text;
                        filterQuery = $"{query} WHERE {examQuery} AND r.firstName = @firstName {orderByQuery}";

                        paramList.Add(new MySqlParam() { Key = "@firstName", Value = firstName });
                        break;
                    case FilterConstants.LAST_NAME:
                        var lastName = tbKeywords.Text;
                        filterQuery = $"{query} WHERE {examQuery} AND r.lastName = @lastName {orderByQuery}";

                        paramList.Add(new MySqlParam() { Key = "@lastName", Value = lastName });
                        break;

                }

                using (var dc = new DataContext())
                {
                    var parameters = paramList.ToArray();
                    var ds = dc.Get(filterQuery, parameters);
                    if (dc.HasRecords(ds))
                    {
                        Items.Clear();

                        var drc = dc.GetRecords(ds);
                        foreach (DataRow dr in drc)
                        {
                            var item = new NeuroItemV2();

                            var client = new ClientV2();
                            client.ControlNo = dr.IsNull("ControlNo") ? string.Empty : dr.Field<string>("ControlNo");
                            client.LastName = dr.IsNull("LastName") ? string.Empty : dr.Field<string>("LastName");
                            client.FirstName = dr.IsNull("FirstName") ? string.Empty : dr.Field<string>("FirstName");
                            client.MiddleInitial = dr.IsNull("MI") ? string.Empty : dr.Field<string>("MI");
                            client.ExtName = dr.IsNull("ExtName") ? string.Empty : dr.Field<string>("ExtName");
                            client.Age = dr.IsNull("Age") ? 0 : Convert.ToInt32(dr.Field<string>("Age"));
                            client.Gender = dr.IsNull("Gender") ? string.Empty : dr.Field<string>("Gender");
                            client.HomeAddress = dr.IsNull("Address") ? string.Empty : dr.Field<string>("Address");
                            client.Purpose = dr.IsNull("Purpose") ? string.Empty : dr.Field<string>("Purpose");
                            client.RequestingParty = dr.IsNull("ReqParty") ? string.Empty : dr.Field<string>("ReqParty");
                            client.TimeIn = dr.IsNull("TimeIn") ? null : new DateTime?(dr.Field<DateTime>("TimeIn"));
                            client.Photo = dr.IsNull("Photo") ? null : Edit.BmpSource(Edit.ByteArrayToImage(dr.Field<byte[]>("photo")));

                            item.Client = client;

                            item.Version1 = dr.IsNull("Version1") ? false : dr.Field<string>("Version1") == "Yes";
                            item.Version2 = dr.IsNull("Version2") ? false : dr.Field<string>("Version2") == "Yes";
                            item.Version3 = dr.IsNull("Version3") ? false : dr.Field<string>("Version3") == "Yes";
                            item.IsDraft = dr.IsNull("IsDraft") ? false : dr.Field<ulong>("IsDraft") > 0;

                            Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(CyberMessage.GetException(ex), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                neuroGrid.IsEnabled = true;
            }
        }

        #endregion
        #region PROPERTIES
        public ObservableCollection<NeuroItemV2> Items
        {
            get;
            set;
        }
        #endregion


    }
}







