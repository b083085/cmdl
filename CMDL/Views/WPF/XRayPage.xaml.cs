using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;
using System.Data;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for XRayForm.xaml
    /// </summary>
    public partial class XRayPage : Window
    {
        XRay_PrintDoc doc = new XRay_PrintDoc();
        XRayClientInfo info;


        DataTable templates;
        DataTable radiologist;

        public XRayPage(XRayClientInfo info, DataTable radiologist, DataTable templates)
        {
            InitializeComponent();

            this.DataContext = info;
            this.info = info;
            this.templates = templates;
            this.radiologist = radiologist;


            foreach (DataRow d in radiologist.Rows)
                CbRadiologist.Items.Add(Convert.ToString(d["name"]));

            if (info.Status == "NOT DONE")
            {
                info.RadioReport = Properties.Settings.Default.RadioReport;
                info.Conclusion = Properties.Settings.Default.XRayRemarks;
                CbRadiologist.SelectedIndex = 0;
            }

            IsReadOnly(info.Status == "DONE");

            BtTemplates.Click += new RoutedEventHandler(BtTemplates_Click);
            BtSaveRecord.Click += new RoutedEventHandler(BtSaveRecord_Click);
            BtPreview.Click += new RoutedEventHandler(BtPreview_Click);

        }

        private void SaveRecord(string user)
        {
            XRayDB db = new XRayDB(Properties.Settings.Default.Server,
                                          Properties.Settings.Default.Database,
                                          Properties.Settings.Default.UserID,
                                          Properties.Settings.Default.Port,
                                          Properties.Settings.Default.Password);

            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, (Action)delegate
           {
               try
               {
                   try
                   {
                       info.RadiologistTitle = Convert.ToString(radiologist.Rows.Find(CbRadiologist.Text)["title"]);
                   }
                   catch (Exception)
                   {
                       //none
                   }

                   info.PrintedBy = user;
                   db.Data = info;

                   if (db.Insert())
                   {
                       info.Status = "DONE";
                       MessageBox.Show("RECORD SAVED!");

                       IsReadOnly(true);
                       doc.Preview(new List<XRayClientInfo>() { info });
                   }
                   else
                   {
                       MessageBox.Show("Unable to Save this Record. Please contact your Database Administrator for further assistance!");
                       BtSaveRecord.Content = "SAVE RECORD";
                   }


               }
               catch (Exception)
               {
                   MessageBox.Show("Unable to Connect to the Database. Please contact your Database Administrator for further assistance!");
                   BtSaveRecord.Content = "SAVE RECORD";
               }

               BtSaveRecord.IsEnabled = true;
           });
        }

        private void ValidateEntries()
        {
            if (!String.IsNullOrWhiteSpace(TbRadioReport.Text))
            {
                if (!String.IsNullOrWhiteSpace(TbConclusion.Text))
                {
                    if (!String.IsNullOrWhiteSpace(CbRadiologist.Text))
                    {
                        PasswordPage ppage = new PasswordPage();
                        ppage.TableName = "office_user";
                        if (ppage.ShowDialog() == true)
                        {
                            BtSaveRecord.Content = "SAVING...";
                            BtSaveRecord.IsEnabled = false;
                            SaveRecord(ppage.User);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Radiologist not specified!");
                    }
                }
                else
                {
                    MessageBox.Show("Conclusion not specified!");
                }
            }
            else
            {
                MessageBox.Show("Radiological Report not specified!");
            }
        }

        void BtPreview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                info.RadiologistTitle = Convert.ToString(radiologist.Rows.Find(CbRadiologist.Text)["title"]);
            }
            catch (Exception)
            {
                //none
            }
            doc.CyberPreview(new List<XRayClientInfo>() { info });
        }

        void BtSaveRecord_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(BtSaveRecord.Content) == "SAVE RECORD")
            {
                ValidateEntries();
            }
            else if (Convert.ToString(BtSaveRecord.Content) == "PRINT")
            {
                if (AllowPrint)
                {
                    doc.Preview(new List<XRayClientInfo>() { info });
                }
                else
                {
                    MessageBox.Show("User '" + UserName + "' is not allowed to print xray result(s)!", "Print Result Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }

        }

        void BtTemplates_Click(object sender, RoutedEventArgs e)
        {
            XRayTemplatesPage xtpage = new XRayTemplatesPage(templates);
            xtpage.XPage = this;
            xtpage.ShowDialog();
        }

        public void IsReadOnly(bool value)
        {
            TbRadioReport.IsEnabled = !value;
            TbConclusion.IsEnabled = !value;
            CbRadiologist.IsEnabled = !value;
            BtTemplates.IsEnabled = !value;
            BtSaveRecord.Content = value ? "PRINT" : "SAVE RECORD";
        }

        public string UserName
        {
            set;
            get;
        }

        public bool AllowPrint
        {
            set;
            get;
        }




    }
}
