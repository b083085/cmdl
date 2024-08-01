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
    /// Interaction logic for PhysicalExaminationSearchForm.xaml
    /// </summary>
    public partial class PhysicalExaminationSearchForm : Window
    {

        List<PhysicalExaminationPriority> pepList = new List<PhysicalExaminationPriority>();
        List<PhysicalExaminationPriority> statusList = new List<PhysicalExaminationPriority>();

        Dictionary<string, string> refTableField = new Dictionary<string, string>();
        string server;
        string database;
        string userID;
        string password;
        string port;
        string username;


        public PhysicalExaminationSearchForm(string username, string server, string database, string userID, string port, string password)
        {
            InitializeComponent();

            dgClientList.DataContext = pepList;
            dgStatusList.DataContext = statusList;

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
                    int priorityNo = 1;

                    pepList.Clear();
                    statusList.Clear();

                    #region CODE
                    foreach (var dr in record.ReturnRow)
                    {
                        if (Convert.ToString(dr["exam"]).Contains("PHYSICAL EXAMINATION"))
                        {
                            db.SearchWithParametrizedQuery("select * from pelist where controlno=@controlno", "pelist", new Dictionary<string, object>() { { "@controlno", dr["controlno"] } });
                            Database db_dtl = db["pelist"];

                            #region PE LIST
                            DateTime dt;
                            if (db_dtl.Length > 0)
                            {
                                foreach (var dr2 in db_dtl.ReturnRow)
                                {
                                    var pep = new PhysicalExaminationPriority();
                                    pep.PeID = Convert.ToUInt64(dr2["peID"]);
                                    pep.ControlNo = Convert.ToString(dr2["controlno"]);
                                    pep.PriorityNo = Convert.ToInt32(dr2["priorityNo"]);

                                    if (DateTime.TryParse(Convert.ToString(dr2["date_reg"]), out dt))
                                        pep.DateRegistered = Convert.ToDateTime(dr2["date_reg"]);

                                    pep.LastName = Convert.ToString(dr2["lastname"]);
                                    pep.FirstName = Convert.ToString(dr2["firstname"]);
                                    pep.MiddleName = Convert.ToString(dr2["mi"]);
                                    pep.Status = Convert.ToString(dr2["status"]);
                                    pep.RequestingParty = Convert.ToString(dr["reqparty"]);

                                    statusList.Add(pep);
                                }
                            }
                            else
                            {
                                var pep = new PhysicalExaminationPriority();
                                pep.ControlNo = Convert.ToString(dr["controlno"]);
                                pep.PriorityNo = priorityNo;

                                if (DateTime.TryParse(Convert.ToString(dr["date_reg"]), out dt))
                                    pep.DateRegistered = Convert.ToDateTime(dr["date_reg"]);

                                pep.LastName = Convert.ToString(dr["lastname"]);
                                pep.FirstName = Convert.ToString(dr["firstname"]);
                                pep.MiddleName = Convert.ToString(dr["mi"]);
                                pep.RequestingParty = Convert.ToString(dr["reqparty"]);

                                pepList.Add(pep);
                            }
                            #endregion

                            priorityNo += 1;
                        }
                    }
                    #endregion

                    dgClientList.Items.Refresh();
                    dgStatusList.Items.Refresh();

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
            tbTotal.Text = pepList.Count + "";
            tbTotalDone.Text = Convert.ToString(statusList.Where(p => p.Status == "DONE").Count());
            tbTotalEvalPending.Text = Convert.ToString(statusList.Where(p => p.Status == "EVALUATION PENDING").Count());
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
                    case "TODAY": db.SearchWithParametrizedQuery("select * from reg where date_reg=@date_reg", "reg", new Dictionary<string, object>() { { "@date_reg", string.Format("{0:yyyy-MM-dd}", DateTime.Now) } });
                        break;
                    case "DATE REGISTERED":
                    case "BIRTH DATE":
                        var dForm = new DateForm();
                        if (dForm.ShowDialog() == true)
                            if (dForm.SelectedDate.HasValue)
                                db.SearchWithParametrizedQuery("select * from reg where " + refTableField[content] + "=@item", "reg", new Dictionary<string, object>() { { "@item", dForm.SelectedDate.Value } });
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
            var item = dgClientList.SelectedItem as PhysicalExaminationPriority;

            if (item != null)
            {
                
                //add to the database
                //add to the statuslist
                //remove the item to the peplist
                //update the client datagrid list
                //update the status datagrid list
                PeStatusForm pesForm = new PeStatusForm();
                if (pesForm.ShowDialog() == true)
                {
                    item.Status = pesForm.Status;

                    CMDLWpf.MySqlDB db = new CMDLWpf.MySqlDB(server, database, userID, port, password);
                    var res = db.CRUD("insert into pelist(controlno,priorityNo,date_reg,lastname,firstname,mi,status) values(@controlno,@priorityNo,@date_reg,@lastname,@firstname,@mi,@status)",
                                      "pelist",
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

                    if (res)
                    {
                        statusList.Add(item);
                        pepList.Remove(item);
                        dgClientList.Items.Refresh();
                        dgStatusList.Items.Refresh();
                        UpdateCount();

                    }
                    else
                    {
                        MessageBox.Show("There was a problem in saving this record!", "Physical Examination Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
            }
        }
    }


   
}
