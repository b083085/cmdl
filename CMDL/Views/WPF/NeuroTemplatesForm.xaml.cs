using CMDL.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for NeuroTemplatesForm.xaml
    /// </summary>
    public partial class NeuroTemplatesForm : Window
    {
        public event Action<string> CopyToRemarksEvent;

        public ObservableCollection<NeuroTemplate> Remarks
        {
            get;
            set;
        }

        public NeuroTemplatesForm()
        {
            InitializeComponent();

            Remarks = new ObservableCollection<NeuroTemplate>();

            btnSearch.Click += BtnSearch_Click;
            tbRemarks.KeyDown += TbRemarks_KeyDown;
            Loaded += NeuroTemplatesForm_Loaded;

            cbGender.Items.Add(new { Code = "M", Gender = "Male" });
            cbGender.Items.Add(new { Code = "F", Gender = "Female" });

            cbGender.DisplayMemberPath = "Gender";
            cbGender.SelectedValuePath = "Code";
            cbGender.SelectedIndex = 0;

            DataContext = this;
        }



        #region EVENTS
        private void NeuroTemplatesForm_Loaded(object sender, RoutedEventArgs e)
        {
            tbRemarks.Focus();
        }
        private void TbRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Search();
        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
        private void HpCopyToRemarks_Click(object sender, RoutedEventArgs e)
        {
            var item = dgRemarks.SelectedItem;
            if (item != null)
            {
                var template = item as NeuroTemplate;

                CopyToRemarksEvent?.Invoke(template.Remarks);
                this.DialogResult = true;
            }
        }
        #endregion
        #region FUNCTIONS
        void Search()
        {
            try
            {
                using (var db = new DataContext())
                {
                    var query = @"SELECT v2.Remarks
                            FROM rev_neuro v2
                            LEFT JOIN reg r
                            ON v2.ControlNo = r.ControlNo
                            WHERE r.sex = @gender
                            AND v2.Remarks LIKE @remarks
                            AND v2.Remarks IS NOT NULL
                            UNION
                            SELECT v1.Remarks
                            FROM neuro v1
                            LEFT JOIN reg r
                            ON v1.neuro_ControlNo = r.ControlNo
                            WHERE r.sex = @gender
                            AND v1.Remarks LIKE @remarks
                            AND v1.Remarks IS NOT NULL";

                    var gender = new MySqlParam();
                    gender.Key = "@gender";
                    gender.Value = cbGender.SelectedValue;

                    var remarks = new MySqlParam();
                    remarks.Key = "@remarks";
                    remarks.Value = string.Format("%{0}%", tbRemarks.Text);


                    var ds = db.Get(query, gender, remarks);
                    if (db.HasRecords(ds))
                    {
                        Remarks.Clear();

                        var drc = db.GetRecords(ds);
                        foreach (DataRow dr in drc)
                        {
                            Remarks.Add(new NeuroTemplate() { Remarks = dr.Field<string>("Remarks") });
                        }
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
        }
        #endregion

    }

    public class NeuroTemplate : NotifyPropertyChanged
    {
        private string remarks;

        public string Remarks
        {
            get { return remarks; }
            set
            {
                remarks = value;
                OnPropertyChanged(nameof(Remarks));
            }
        }

    }
}
