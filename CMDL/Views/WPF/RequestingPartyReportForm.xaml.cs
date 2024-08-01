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
using CMDL.Models;
using MySql.Data.MySqlClient;


namespace CMDL.WPF
{
    /// <summary>
    /// Interaction logic for RequestingPartyReportForm.xaml
    /// </summary>
    public partial class RequestingPartyReportForm : Window
    {
        public RequestingPartyReportForm()
        {
            InitializeComponent();
            tbSearch.KeyDown += new KeyEventHandler(tbSearch_KeyDown);
            btSearch.Click += new RoutedEventHandler(btSearch_Click);
            this.Loaded += new RoutedEventHandler(RequestingPartyReportForm_Loaded);
        }

        void RequestingPartyReportForm_Loaded(object sender, RoutedEventArgs e)
        {
            cbMonth.Items.Add("January");
            cbMonth.Items.Add("February");
            cbMonth.Items.Add("March");
            cbMonth.Items.Add("April");
            cbMonth.Items.Add("May");
            cbMonth.Items.Add("June");
            cbMonth.Items.Add("July");
            cbMonth.Items.Add("August");
            cbMonth.Items.Add("September");
            cbMonth.Items.Add("October");
            cbMonth.Items.Add("November");
            cbMonth.Items.Add("December");

            for (int i = 2012; i < 3000; i++)
            {
                cbYear.Items.Add(i.ToString());
            }

            tbSearch.Focus();
        }
        void btSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();            
        }
        void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search();
            }
        }
        void Search()
        {
            if (!String.IsNullOrWhiteSpace(tbSearch.Text))
            {
                if (!String.IsNullOrWhiteSpace(cbMonth.Text))
                {
                    if (!String.IsNullOrWhiteSpace(cbYear.Text))
                    {
                        using (var db = new CyberContext())
                        {
                            db.CommandTimeout = 600;
                            var reqPartyList = db.ExecuteStoreQuery<reg>("select * from reg where reqparty like @reqParty and month(date_reg)=@dateReg and year(date_reg)=@dateYear", new MySqlParameter("@reqParty", tbSearch.Text + '%'),
                                                                            new MySqlParameter("@dateReg", MonthConverter()),
                                                                            new MySqlParameter("@dateYear", cbYear.Text)
                                                                            ).ToList();

                            if (reqPartyList.Count > 0)
                                dgList.DataContext = reqPartyList;
                            else
                            {
                                dgList.DataContext = null;
                                MessageBox.Show("No record(s) found!", "Search", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }

                            dgList.Items.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Year not specified!", "Search", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Month not specified!", "Search", MessageBoxButton.OK, MessageBoxImage.Stop);
                }

            }
            else
            {
                MessageBox.Show("Requesting party not specified!", "Search", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        string MonthConverter()
        {
            switch (cbMonth.Text)
            {
                case "January":
                    return "1";
                case "February":
                    return "2";
                case "March":
                    return "3";
                case "April":
                    return "4";
                case "May":
                    return "5";
                case "June":
                    return "6";
                case "July":
                    return "7";
                case "August":
                    return "8";
                case "September":
                    return "9";
                case "October":
                    return "10";
                case "November":
                    return "11";
                case "December":
                    return "12";
                default:
                    return "0";
            }
        }


    }
}
