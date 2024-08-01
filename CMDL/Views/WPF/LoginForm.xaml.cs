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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Reflection;
using System.Windows.Threading;
using CMDL.DAL;
using CMDL.Common;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {

        LoginControl loginControl;
        ConnectionControl connectionControl;

        public LoginForm()
        {
            InitializeComponent();

            loginControl = new LoginControl();
            connectionControl = new ConnectionControl();

            Loaded += LoginForm_Loaded;
            loginControl.LoginClickEvent += loginControl_LoginClickEvent;
            connectionControl.CancelClickEvent += connectionControl_CancelClickEvent;
        }


        #region EVENTS
        private void LoginForm_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                contentControl1.Content = loginControl;
                LbVersion.Content = Global.AppVersion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(CyberMessage.GetException(ex), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
        #region FUNCTIONS
        void connectionControl_CancelClickEvent()
        {
            contentControl1.Content = loginControl;
        }
        void loginControl_CancelClickEvent()
        {
            if (MessageBox.Show("Are you sure you want to exit?[Y/N]", "Cancel", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
        void loginControl_LoginClickEvent()
        {
            Search();
        }
        void Search()
        {
            string userName = loginControl.UserName;
            string password = loginControl.Password;

            try
            {
                if (userName?.ToLower() == "admin" && password == "000")
                {
                    contentControl1.Content = connectionControl;
                }
                else
                {
                    using (var db = new DataContext())
                    {
                        var pUserName = new MySqlParam();
                        pUserName.Key = "@userName";
                        pUserName.Value = userName?.ToLower();

                        var pPassword = new MySqlParam();
                        pPassword.Key = "@password";
                        pPassword.Value = password;

                        var ds = db.Get("SELECT * FROM office_user WHERE LOWER(user_name)=@userName and user_pwd=@password", pUserName, pPassword);

                        if (db.HasRecords(ds))
                        {
                            var dr = db.First(ds);

                            GlobalInstance.Instance.SetUser(dr);

                            var mainForm = new MainForm();
                            mainForm.Cmdl = LoadSettings();

                            mainForm.Show();
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Invalid user name or password. Please try again.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(Global.GetInnerException(ex), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                loginControl.UserNameFocus();
            }
        }
        private cmdldbDataSet LoadSettings()
        {
            try
            {
                //var db = new MySqlDB(Properties.Settings.Default.Server,
                //                     Properties.Settings.Default.Database,
                //                     Properties.Settings.Default.UserID,
                //                     Properties.Settings.Default.Port,
                //                     Properties.Settings.Default.Password);

                var ds = new cmdldbDataSet();

                //db.Select("select * from office_user", "office_user");
                //foreach (var d in db.returnrow)
                //    ds.Tables["office_user"].Rows.Add(d.ItemArray);


                //db.Select("select * from admin_user", "admin_user");
                //foreach (var d in db.returnrow)
                //    ds.Tables["admin_user"].Rows.Add(d.ItemArray);


                //db.Select("select * from exam order by type,test ASC", "exam");
                //foreach (var d in db.returnrow)
                //    ds.Tables["exam"].Rows.Add(d.ItemArray);


                //db.Select("select * from package", "package");
                //foreach (var d in db.returnrow)
                //    ds.Tables["package"].Rows.Add(d.ItemArray);


                //db.Select("select * from radiologist order by name ASC", "radiologist");
                //foreach (var d in db.returnrow)
                //    ds.Tables["radiologist"].Rows.Add(d.ItemArray);


                //db.Select("select * from psychologist order by name ASC", "psychologist");
                //foreach (var d in db.returnrow)
                //    ds.Tables["psychologist"].Rows.Add(d.ItemArray);


                //db.Select("select * from psychiatrist order by name ASC", "psychiatrist");
                //foreach (var d in db.returnrow)
                //    ds.Tables["psychiatrist"].Rows.Add(d.ItemArray);

                //db.Select("select distinct marker,radio_report,conclusion from xray", "xray");
                //foreach (var d in db.returnrow)
                //    ds.Tables["xray_templates"].Rows.Add(d.ItemArray);

                //db.Select("select distinct remarks,psychometrician from neuro", "neuro");
                //foreach (var d in db.returnrow)
                //    ds.Tables["neuro_templates"].Rows.Add(d.ItemArray);


                //db.Select("select * from medtech", "medtech");
                //foreach (var d in db.returnrow)
                //{
                //    ds.Tables["medtech"].Rows.Add(Edit.CheckTilde(Convert.ToString(d["name"])),
                //                                    Edit.CheckTilde(Convert.ToString(d["user_name"])),
                //                                    Edit.CheckTilde(Convert.ToString(d["title"])));
                //}


                //db.Select("select * from pathologist", "pathologist");
                //foreach (var d in db.returnrow)
                //{
                //    ds.Tables["pathologist"].Rows.Add(Edit.CheckTilde(Convert.ToString(d["name"])),
                //                                        Edit.CheckTilde(Convert.ToString(d["title"])),
                //                                        Convert.ToChar(d["default"]));
                //}


                //db.Select("select * from testkit", "testkit");
                //foreach (var d in db.returnrow)
                //{
                //    DateTime exp = Convert.ToDateTime(Convert.ToString(d["exp"]));

                //    if (exp.Month >= DateTime.Now.Month && exp.Year >= DateTime.Now.Year)
                //        ds.Tables["testkit"].Rows.Add(d.ItemArray);
                //}


                //db.Select("select * from physician", "physician");
                //foreach (var d in db.returnrow)
                //{
                //    ds.Tables["physician"].Rows.Add(Edit.CheckTilde(Convert.ToString(d["name"])),
                //                                      Edit.CheckTilde(Convert.ToString(d["license_no"])));

                //}

                //db.Select("select * from reqparty", "reqparty");
                //foreach (var d in db.returnrow)
                //    ds.Tables["reqparty"].Rows.Add(d.ItemArray);

                //db.Select("select * from company", "company");
                //foreach (var d in db.returnrow)
                //{
                //    ds.Tables["company"].Rows.Add(d.ItemArray);
                //    Properties.Settings.Default.Company = Convert.ToString(d["company_name"]);
                //    Properties.Settings.Default.Company_Profile = Convert.ToString(d["company_profile"]);
                //    Properties.Settings.Default.Company_Addr = Convert.ToString(d["company_address"]);
                //    Properties.Settings.Default.Company_TelNo = Convert.ToString(d["company_contact_no"]);

                //    Properties.Settings.Default.Save();
                //}

                //db.Select("select * from dict_GramStain", "dict_GramStain");
                //foreach (var d in db.returnrow)
                //    ds.Tables["dict_gramstain"].Rows.Add(d.ItemArray);

                //db.Select("select * from dict_IDO", "dict_IDO");
                //foreach (var d in db.returnrow)
                //    ds.Tables["dict_ido"].Rows.Add(d.ItemArray);

                //db.Select("select * from dict_sensitivity", "dict_sensitivity");
                //foreach (var d in db.returnrow)
                //    ds.Tables["dict_sensitivity"].Rows.Add(d.ItemArray);


                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
