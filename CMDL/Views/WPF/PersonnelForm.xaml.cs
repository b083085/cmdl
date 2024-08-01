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
    /// Interaction logic for PersonnelForm.xaml
    /// </summary>
    public partial class PersonnelForm : Window
    {
        List<Personnel> personnelList = new List<Personnel>();

        CMDLWpf.MySqlDB host = new CMDLWpf.MySqlDB(Properties.Settings.Default.Server,
                                                   Properties.Settings.Default.Database,
                                                   Properties.Settings.Default.UserID,
                                                   Properties.Settings.Default.Port,
                                                   Properties.Settings.Default.Password);

        public PersonnelForm()
        {
            InitializeComponent();

            btSaveRecord.Click += new RoutedEventHandler(btSaveRecord_Click);
            btClearRecord.Click += new RoutedEventHandler(btClearRecord_Click);
            lbList.DataContext = personnelList;
            lbList.SelectionChanged += new SelectionChangedEventHandler(lbList_SelectionChanged);

            GetAllPersonnel();

            tbName.Focus();
        }

        void btClearRecord_Click(object sender, RoutedEventArgs e)
        {
            tbID.Clear();
            tbName.Clear();
            tbTitle.Clear();
            tbLicenseNo.Clear();
            cbDepartment.Text = null;
            imgPhoto.Source = null;
            imgSignature.Source = null;
            cbIsAvailable.IsChecked = false;
            btSaveRecord.Content = "Save Record";
        }

        void lbList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = lbList.SelectedItem as Personnel;
            if (item != null)
            {
                tbID.Text = Convert.ToString(item.Id);
                tbName.Text = Convert.ToString(item.Name);
                tbTitle.Text = Convert.ToString(item.Title);
                tbLicenseNo.Text = Convert.ToString(item.LicenseNo);
                cbDepartment.Text = Convert.ToString(item.Department);

                if(item.Photo != null)
                    imgPhoto.Source = (ImageSource)Edit.BmpSource(Edit.ByteArrayToImage(item.Photo));
                if(item.Signature != null)
                    imgSignature.Source = (ImageSource)Edit.BmpSource(Edit.ByteArrayToImage(item.Signature));

                btSaveRecord.Content = "Update Record";
            }
        }

        void btSaveRecord_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(btSaveRecord.Content) == "Save Record")
            {

            }
            else if (Convert.ToString(btSaveRecord.Content) == "Update Record")
            {

            }
        }

        void GetAllPersonnel()
        {
            host.Search("select * from cmdl_personnel", "cmdl_personnel");
            Database db = host["cmdl_personnel"];

            if (db.Length > 0)
            {
                foreach (var dr in db.ReturnRow)
                {
                    personnelList.Add(new Personnel()
                    {
                        Id = Convert.ToUInt32(dr["id"]),
                        Name = Convert.ToString(dr["name"]),
                        Title = Convert.ToString(dr["title"]),
                        IsAvailable = Convert.ToString(dr["isAvailable"]),
                        LicenseNo = Convert.ToString(dr["licenseNo"]),
                        Department = Convert.ToString(dr["category"]),
                        Photo = dr["photo"] != DBNull.Value ? (byte[])dr["photo"] : null,
                        Signature = dr["signature"] != DBNull.Value ? (byte[])dr["signature"] : null
                    });
                }
            }


        }
    }
}
