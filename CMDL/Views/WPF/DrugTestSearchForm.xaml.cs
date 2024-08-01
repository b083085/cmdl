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
using CMDLWpf;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for DrugTestSearchForm.xaml
    /// </summary>
    public partial class DrugTestSearchForm : Window
    {

        List<DrugTestPriority> dtpList = new List<DrugTestPriority>();
        List<DrugTestPriority> doneList = new List<DrugTestPriority>();
        List<DrugTestPriority> skippedList = new List<DrugTestPriority>();

        Dictionary<string, string> refTableField = new Dictionary<string, string>();
        string server;
        string database;
        string userID;
        string password;
        string port;
        string username;


        public DrugTestSearchForm(string username, string server, string database, string userID, string port, string password)
        {
            InitializeComponent();

            dgList.DataContext = dtpList;
            dgDoneList.DataContext = doneList;
            dgSkippedList.DataContext = skippedList;


            this.username = username;
            this.server = server;
            this.database = database;
            this.userID = userID;
            this.password = password;
            this.port = port;

            cbSearch.SelectionChanged += new SelectionChangedEventHandler(cbSearch_SelectionChanged);

            refTableField.Add("TODAY", "date_reg");
            refTableField.Add("DATE REGISTERED", "date_reg");
            refTableField.Add("CONTROL NO", "controlno");
            refTableField.Add("LASTNAME", "lastname");
            refTableField.Add("FIRSTNAME", "firstname");
            refTableField.Add("MIDDLENAME", "middlename");
            refTableField.Add("AGE", "age");
            refTableField.Add("GENDER", "gender");
            refTableField.Add("CIVIL STATUS", "civilstatus");
            refTableField.Add("BIRTH DATE", "bdate");
            refTableField.Add("PURPOSE", "purpose");
            refTableField.Add("EMPLOYER", "employername");
            refTableField.Add("DISTRICT / BRANCH", "districtBranch");
            refTableField.Add("TEST", "testname");

        }

        void Processing(Database record, CMDLWpf.MySqlDB db)
        {
            if (record != null)
            {
                if (record.Length > 0)
                {
                    int priorityNo =1;

                    dtpList.Clear();
                    doneList.Clear();
                    skippedList.Clear();

                    #region CODE
                    foreach (var dr in record.ReturnRow)
                    {
                        if (Convert.ToString(dr["exam"]).Contains("DRUG TEST"))
                        {
                            db.SearchWithParametrizedQuery("select * from drugtestlist where controlno=@controlno", "drugtestlist", new Dictionary<string, object>() { { "@controlno", dr["controlno"] } });
                            Database db_dtl = db["drugtestlist"];

                            #region DRUG TEST LIST
                            DateTime dt;
                            if (db_dtl.Length > 0)
                            {
                                foreach (var dr2 in db_dtl.ReturnRow)
                                {
                                    var dtp = new DrugTestPriority();
                                    dtp.DrugTestID = Convert.ToUInt64(dr2["drugtestID"]);
                                    dtp.ControlNo = Convert.ToString(dr2["controlno"]);
                                    dtp.PriorityNo = Convert.ToInt32(dr2["priorityNo"]);
                                    dtp.CcfNo = Convert.ToString(dr2["ccfNo"]);

                                    if (DateTime.TryParse(Convert.ToString(dr2["date_reg"]), out dt))
                                        dtp.DateRegistered = Convert.ToDateTime(dr2["date_reg"]);

                                    dtp.LastName = Convert.ToString(dr2["lastname"]);
                                    dtp.FirstName = Convert.ToString(dr2["firstname"]);
                                    dtp.MiddleName = Convert.ToString(dr2["mi"]);
                                    dtp.Status = Convert.ToString(dr2["status"]);
                                    dtp.RequestingParty = Convert.ToString(dr["reqParty"]);


                                    if (dtp.Status == "D")
                                        doneList.Add(dtp);
                                    else if (dtp.Status == "S")
                                        skippedList.Add(dtp);
                                }
                            }
                            else
                            {
                                var dtp = new DrugTestPriority();
                                dtp.ControlNo = Convert.ToString(dr["controlno"]);
                                dtp.PriorityNo = priorityNo;
                                if (DateTime.TryParse(Convert.ToString(dr["date_reg"]), out dt))
                                    dtp.DateRegistered = Convert.ToDateTime(dr["date_reg"]);

                                dtp.LastName = Convert.ToString(dr["lastname"]);
                                dtp.FirstName = Convert.ToString(dr["firstname"]);
                                dtp.MiddleName = Convert.ToString(dr["mi"]);
                                dtp.RequestingParty = Convert.ToString(dr["reqParty"]);


                                dtpList.Add(dtp);
                            }
                            #endregion

                            priorityNo += 1;
                        }

                    }
                    #endregion

                    dgList.Items.Refresh();
                    dgDoneList.Items.Refresh();
                    dgSkippedList.Items.Refresh();

                    UpdateCount();
                }
                else
                {
                    MessageBox.Show("No Record(s) Found!", "Search Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
        }

        void UpdateCount()
        {
            tbTotal.Text = dtpList.Count.ToString();
            tbTotalDone.Text = doneList.Count.ToString();
            tbTotalSkipped.Text = skippedList.Count.ToString();
        }

        void cbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = cbSearch.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                CMDLWpf.MySqlDB db = new CMDLWpf.MySqlDB(server, database, userID, port, password);
                Database record = null;
                string content = Convert.ToString(item.Content);

                switch (content)
                {
                    case "TODAY": db.SearchWithParametrizedQuery("select * from reg where date_reg=@date_reg", "reg", new Dictionary<string, object>() { { "@date_reg", string.Format("{0:yyyy-MM-dd}",DateTime.Now) } });
                        break;
                    case "DATE REGISTERED":
                    case "BIRTH DATE":
                        var dForm = new DateForm();
                        if (dForm.ShowDialog() == true)
                            if (dForm.SelectedDate.HasValue)
                                db.SearchWithParametrizedQuery("select * from reg where " + refTableField[content] + "s=@item", "reg", new Dictionary<string, object>() { { "@item", dForm.SelectedDate.Value } });
                        break;
                    case "CONTROL NO":
                    case "LASTNAME":
                    case "FIRSTNAME":
                    case "MIDDLENAME":
                    case "AGE":
                    case "GENDER":
                    case "CIVIL STATUS":
                    case "PURPOSE":
                    case "EMPLOYER":
                    case "DISTRICT / BRANCH":
                    case "TEST":
                        SearchBoxForm sbForm = new SearchBoxForm();
                        if (sbForm.ShowDialog() == true)
                            db.SearchWithParametrizedQuery("select * from reg where " + refTableField[content] + "=@item", "reg", new Dictionary<string, object>() { { "@item", sbForm.Keyword } });
                        break;
                }

                record = db["reg"];
                Processing(record, db);
            }

            cbSearch.Text = null;
        }

        private void btStatus_Click(object sender, RoutedEventArgs e)
        {
            var item = dgList.SelectedItem as DrugTestPriority;

            if (item != null)
            {
                DrugTestSelectStatusForm dtssForm = new DrugTestSelectStatusForm();
                if (dtssForm.ShowDialog() == true)
                {
                    switch (dtssForm.Status)
                    {
                        case DrugTestSelectStatus.Done:
                            #region CODE
                            CCFNoForm ccfForm = new CCFNoForm(doneList.Count);
                            if (ccfForm.ShowDialog() == true)
                            {
                                //add to the database
                                //add to the done list
                                //delete from the dtp list
                                //update the main datagrid list
                                //update the total number of drug test list

                                item.CcfNo = ccfForm.CCfNo;
                                item.Status = "D";

                                CMDLWpf.MySqlDB db = new CMDLWpf.MySqlDB(server, database, userID, port, password);
                                var res = db.CRUD("insert into drugtestlist(controlno,priorityNo,ccfNo,date_reg,lastname,firstname,mi,status) values(@controlno,@priorityNo,@ccfNo,@date_reg,@lastname,@firstname,@mi,@status)",
                                                  "drugtestlist",
                                                    new Dictionary<string, object>() 
                                                {
                                                    {"@controlno",item.ControlNo},
                                                    {"@priorityNo",item.PriorityNo},
                                                    {"@ccfNo",item.CcfNo},
                                                    {"@date_reg",item.DateRegistered},
                                                    {"@lastname",item.LastName},
                                                    {"@firstname",item.FirstName},
                                                    {"@mi",item.MiddleName},
                                                    {"@status",item.Status}
                                                });

                                if (res)
                                {
                                    doneList.Add(item);
                                    dtpList.Remove(item);

                                    dgList.Items.Refresh();
                                    dgDoneList.Items.Refresh();
                                    dgSkippedList.Items.Refresh();

                                    UpdateCount();
                                }
                                else
                                {
                                    MessageBox.Show("There was a problem in saving this record!", "Drug Test Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                }
                            }
                            #endregion
                            break;
                        case DrugTestSelectStatus.Skipped:
                            #region CODE
                            //add to the skip list
                            //delete from the dtp list
                            //update the main datagrid list
                            //update the total number of drug test list
                                item.Status = "S";

                                CMDLWpf.MySqlDB db2 = new CMDLWpf.MySqlDB(server, database, userID, port, password);
                                var res2 = db2.CRUD("insert into drugtestlist(controlno,priorityNo,date_reg,lastname,firstname,mi,status) values(@controlno,@priorityNo,@date_reg,@lastname,@firstname,@mi,@status)",
                                                  "drugtestlist",
                                                    new Dictionary<string, object>() 
                                                {
                                                    {"@controlno",item.ControlNo},
                                                    {"@priorityNo",item.PriorityNo},
                                                    {"@date_reg",item.DateRegistered},
                                                    {"@lastname",item.LastName},
                                                    {"@firstname",item.FirstName},
                                                    {"@mi",item.MiddleName},
                                                    {"@status",item.Status}
                                                });

                                if (res2)
                                {
                                    skippedList.Add(item);
                                    dtpList.Remove(item);

                                    dgList.Items.Refresh();
                                    dgDoneList.Items.Refresh();
                                    dgSkippedList.Items.Refresh();

                                    UpdateCount();
                                }
                                else
                                {
                                    MessageBox.Show("There was a problem in saving this record!", "Drug Test Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                }
                            #endregion
                            break;
                    }
                }
            }
        }

        private void btDone_Click(object sender, RoutedEventArgs e)
        {
            var item = dgSkippedList.SelectedItem as DrugTestPriority;

            if (item != null)
            {
                #region CODE
                CCFNoForm ccfForm = new CCFNoForm(doneList.Count);
                if (ccfForm.ShowDialog() == true)
                {
                    //add to the database
                    //add to the done list
                    //remove the item in the skipped list
                    //update the done datagrid list and the skipped datagrid list
                    //update the total number of drug test list

                    CMDLWpf.MySqlDB db = new CMDLWpf.MySqlDB(server, database, userID, port, password);

                    item.CcfNo = ccfForm.CCfNo;
                    item.Status = "D";

                    var res = db.CRUD("update drugtestlist set status='D',ccfNo=@ccfNo where controlno=@controlno",
                                      "drugtestlist",
                                        new Dictionary<string, object>() 
                                                {
                                                    {"@controlno",item.ControlNo},
                                                    {"@ccfNo",item.CcfNo},
                                                });

                    if (res)
                    {
                        doneList.Add(item);
                        skippedList.Remove(item);
                        dgList.Items.Refresh();
                        dgDoneList.Items.Refresh();
                        dgSkippedList.Items.Refresh();
                        UpdateCount();
                        
                    }
                    else
                        MessageBox.Show("There was a problem in updating this record!", "Drug Test Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
                #endregion
            }
        }
    }
}
