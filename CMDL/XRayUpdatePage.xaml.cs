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

namespace CMDL
{
    /// <summary>
    /// Interaction logic for XRayUpdatePage.xaml
    /// </summary>
    public partial class XRayUpdatePage : Window
    {
        MySqlDB db = new MySqlDB(Properties.Settings.Default.Server,
                                  Properties.Settings.Default.Database,
                                  Properties.Settings.Default.UserID,
                                  Properties.Settings.Default.Port,
                                  Properties.Settings.Default.Password);

        List<Radiologist> radList = new List<Radiologist>();

        cmdldbDataSet cmdldb;

        
        
        public XRayUpdatePage(cmdldbDataSet cmdldb)
        {
            InitializeComponent();

            BtSearch.Click += new RoutedEventHandler(BtSearch_Click);
            BtTemplates.Click += new RoutedEventHandler(BtTemplates_Click);
            btUpdateRecord.Click += new RoutedEventHandler(btUpdateRecord_Click);
            btPrint.Click += new RoutedEventHandler(btPrint_Click);

            this.Loaded += new RoutedEventHandler(XRayUpdatePage_Loaded);

            this.cmdldb = cmdldb;
        }

        void btPrint_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void btUpdateRecord_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void XRayUpdatePage_Loaded(object sender, RoutedEventArgs e)
        {
            db.Select("select * from radiologist", "radiologist");
            if (db.length > 0)
            {
                foreach (var d in db.returnrow)
                {
                    CbRadiologist.Items.Add(d["name"]);
                    radList.Add(new Radiologist
                    {
                         Name = Convert.ToString(d["name"]),
                         Title = Convert.ToString(d["title"])
                    });
                }
            }
        }

        void BtTemplates_Click(object sender, RoutedEventArgs e)
        {

        }

        void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void LoadInfo()
        {
            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, (Action)delegate
            {
                try
                {
                    db.Select("select reg.*,xray.* from xray right join reg on reg.controlno=xray.xray_controlno where xray_controlno='" + TbKeyWord.Text + "'", "xray");

                    if (db.length > 0)
                    {
                        tbDisplayCounter.Text = db.length + "";
                        this.DataContext = db.returnrow;
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

    }

    public class Radiologist
    {
        public string Name { set; get; }
        public string Title { set; get; }
    }
}
