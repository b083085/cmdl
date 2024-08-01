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
using System.Data;
using System.ComponentModel;
using CMDL.DAL;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for XRaySearchClient.xaml
    /// </summary>
    public partial class XRaySearchClient : Window
    {
        List<XRayClientInfo> info = new List<XRayClientInfo>();
        XRay_PrintDoc print = new XRay_PrintDoc();
        cmdldbDataSet cmdldb;

        

        string sqlquery = "";
        
        public XRaySearchClient(cmdldbDataSet cmdldb)
        {
            InitializeComponent();

            this.cmdldb = cmdldb;

            dataGrid1.AutoGenerateColumns = false;
            dataGrid1.CanUserAddRows = false;
            dataGrid1.CanUserDeleteRows = false;

            dataGrid1.DataContext = info;

            TbKeyWord.KeyDown += new KeyEventHandler(TbKeyWord_KeyDown);

            CbFilter.SelectionChanged += new SelectionChangedEventHandler(CbFilter_SelectionChanged);

            BtSearch.Click += new RoutedEventHandler(BtSearch_Click);

            BtClearCheck.Click += new RoutedEventHandler(BtClearCheck_Click);
            BtCXRNormal.Click += new RoutedEventHandler(BtCXRNormal_Click);
        }

        void BtCXRNormal_Click(object sender, RoutedEventArgs e)
        {
            if (info.Count > 0)
            {
                PasswordPage ppage = new PasswordPage();
                ppage.TableName = "office_user";
                if (ppage.ShowDialog() == true)
                {
                    RadiologistPage radpage = new RadiologistPage(cmdldb.Tables["radiologist"]);
                    if (radpage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        SaveCXRNormal(ppage.User,radpage.Radiologist);
                    }
                }
            }
        }

        void BtClearCheck_Click(object sender, RoutedEventArgs e)
        {
            foreach (XRayClientInfo client in info)
                if (client.Select)
                    client.Select = false;
        }

        void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = CbFilter.SelectedItem as ComboBoxItem;

            if (item.Content.ToString() == "DATE" || item.Content.ToString() == "BIRTH PLACE")
            {
                DatePage dpage = new DatePage();
                if (dpage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    TbKeyWord.Text = dpage.GetDate;
            }
            TbKeyWord.Focus();
        }

        void TbKeyWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Search();
        }

        void LoadInfo()
        {
            MySqlDB clients = new MySqlDB(Properties.Settings.Default.Server,
                             Properties.Settings.Default.Database,
                             Properties.Settings.Default.UserID,
                             Properties.Settings.Default.Port,
                             Properties.Settings.Default.Password);

            XRayDB xray = new XRayDB(Properties.Settings.Default.Server,
                                         Properties.Settings.Default.Database,
                                         Properties.Settings.Default.UserID,
                                         Properties.Settings.Default.Port,
                                         Properties.Settings.Default.Password);
            
            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, (Action)delegate
            {
                try
                {
                    clients.Select(Convert.ToString(sqlquery), "reg");
                    //clear xrayclientinfo
                    info.Clear();

                    if (clients.length > 0)
                    {
                        int priorityNo = 1;

                        foreach (DataRow client in clients.returnrow)
                        {
                            //load xray test of this patient
                            List<string> xray_test = Test.Parse(cmdldb.Tables["exam"], Convert.ToString(client["exam"]), "XRAY");

                            foreach (string t in xray_test)
                            {
                                //get marker
                                string marker = Test.Marker(cmdldb.Tables["exam"], t, "XRAY");

                                //instantiate an xrayclientinfo to add in the list
                                XRayClientInfo xray_client = new XRayClientInfo();
                                xray_client.TimeIn = Convert.ToString(client["time_in"]);
                                xray_client.Photo = (ImageSource)Edit.BmpSource(Edit.ByteArrayToImage((byte[])client["photo"]));
                                xray_client.ControlNo = Convert.ToString(client["controlno"]);
                                xray_client.LastName = Convert.ToString(client["lastname"]);
                                xray_client.FirstName = Convert.ToString(client["firstname"]);
                                xray_client.MI = Convert.ToString(client["mi"]);
                                xray_client.Suffix = Convert.ToString(client["suffix"]);
                                xray_client.Age = Convert.ToString(client["age"]);
                                xray_client.Sex = Convert.ToString(client["sex"]);
                                xray_client.PriorityNo = priorityNo;

                                xray.Select("select * from xray where up_controlno='" + marker + "-" + Convert.ToString(client["controlno"]) + "'", "xray");

                                if (xray.length > 0)
                                {
                                    DataRow d = xray.returnrow[0];

                                    xray_client.Select = false;
                                    xray_client.Marker = Convert.ToString(d["marker"]);
                                    xray_client.RadioReport = Convert.ToString(d["radio_report"]);
                                    xray_client.Conclusion = Convert.ToString(d["conclusion"]);
                                    xray_client.Radiologist = Convert.ToString(d["radiologist"]);
                                    xray_client.RadiologistTitle = FindTitle(Convert.ToString(d["radiologist"]));
                                    xray_client.PrintedBy = Convert.ToString(d["printedby"]);
                                    xray_client.UpControlNo = Convert.ToString(d["up_controlno"]);
                                    xray_client.Status = "DONE";
                                }
                                else
                                {
                                    xray_client.Select = false;
                                    xray_client.Marker = Test.Marker(cmdldb.Tables["exam"], t, "XRAY");
                                    xray_client.UpControlNo = marker + "-" + Convert.ToString(client["controlno"]);
                                    xray_client.Status = "NOT DONE";    
                                }

                                info.Add(xray_client);
                                priorityNo += 1;
                            }
                        }

                        dataGrid1.Items.Refresh();
                        TbResults.Text = "RESULT(S): " + Convert.ToString(info.Count);
                    }
                    else
                    {
                        MessageBox.Show("No Record(s) Found!");
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Unable to connect to the database. Please contact your Database Administrator for further assistance!");
                }

                TbKeyWord.IsEnabled = true;
                BtSearch.Content = "SEARCH";
                BtSearch.IsEnabled = true;
            });
        }

        void Search()
        {
            TbKeyWord.IsEnabled = false;
            BtSearch.Content = "SEARCHING...";
            BtSearch.IsEnabled = false;

            if (CbFilter.Text == "TODAY")
            {
                sqlquery = "select * from reg where date_reg='" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "' and (exam_type like '%XRAY%' or exam like '%X-RAY%')";
            }
            else if (CbFilter.Text == "ADDRESS" || CbFilter.Text == "BPLACE")
            {
                sqlquery = "select * from reg where " + CbFilter.Text + " like '%" + TbKeyWord.Text + "%' and (exam_type like '%XRAY%' or exam like '%X-RAY%')";
            }
            else if (CbFilter.Text == "EXAM")
            {
                sqlquery = "select * from reg where exam like '%" + TbKeyWord.Text + "%' and (exam_type like '%XRAY%' or exam like '%X-RAY%')";
            }
            else if (CbFilter.Text == "CUSTOM QUERY")
            {
                sqlquery = TbKeyWord.Text;
            }
            else
            {
                sqlquery = "select * from reg where " + ClientMethod.ConvertTableName(CbFilter.Text) + "='" + TbKeyWord.Text + "' and (exam_type like '%XRAY%' or exam like '%X-RAY%')";
            }

            LoadInfo();
        }

        void SaveCXRNormal(string user, string radiologist)
        {
            XRayDB xray = new XRayDB(Properties.Settings.Default.Server,
                                         Properties.Settings.Default.Database,
                                         Properties.Settings.Default.UserID,
                                         Properties.Settings.Default.Port,
                                         Properties.Settings.Default.Password);

            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, (Action)delegate
            {
                try
                {
                    int ctr = 0;

                    foreach (XRayClientInfo x in info)
                    {

                        if (x.Select)
                        {
                            if (x.Status == "NOT DONE" && x.Marker == "CHEST PA")
                            {

                                x.Marker = "CHEST PA";
                                x.RadioReport = Properties.Settings.Default.RadioReport;
                                x.Conclusion = Properties.Settings.Default.XRayRemarks;
                                x.Radiologist = radiologist;
                                x.RadiologistTitle = FindTitle(radiologist);
                                x.PrintedBy = user;
                                x.UpControlNo = x.Marker + "-" + x.ControlNo;

                                xray.Data = x;

                                if (xray.Insert())
                                {
                                    x.Status = "DONE";
                                    ctr += 1;
                                }
                            }
                            else
                            {
                                MessageBox.Show(x.FullName + " already exist in the Record!");
                            }

                        }

                    }

                    MessageBox.Show(Convert.ToString(ctr) + " RECORD(S) SAVED!");

                    List<XRayClientInfo> getinfo = new List<XRayClientInfo>();
                    foreach (XRayClientInfo i in info)
                    {
                        if (i.Select && i.Marker == "CHEST PA")
                            getinfo.Add(i);

                    }

                    if (AllowPrint)
                    {
                        print.Preview(getinfo);
                    }
                    else
                    {
                        MessageBox.Show("User '" + UserName + "' is not allowed to print xray result(s)!", "Print Result Message", MessageBoxButton.OK, MessageBoxImage.Stop);

                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to connect to the Database!Please contact your Database Administrator for further assistance!");
                }
            });
        }

        private void BtStatus_Click(object sender, RoutedEventArgs e)
        {
            XRayClientInfo client = dataGrid1.SelectedItem as XRayClientInfo;
            XRayPage page = new XRayPage(client,cmdldb.Tables["radiologist"],cmdldb.Tables["xray_templates"]);
            page.AllowPrint = AllowPrint;
            page.UserName = UserName;
            page.ShowDialog();
        }

        private string FindTitle(string radiologist)
        {
            foreach (DataRow dr in cmdldb.Tables["radiologist"].Rows)
            {
                if (dr["title"] != DBNull.Value)
                {
                    if (Convert.ToString(dr["name"]) == radiologist)
                    {
                        return Convert.ToString(dr["title"]);
                    }
                }
            }

            return string.Empty;
        }

        public bool AllowPrint
        {
            set;
            get;
        }

        public string UserName
        {
            set;
            get;
        }

    }
}
