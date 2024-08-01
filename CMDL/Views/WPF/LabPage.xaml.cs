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
using CMDL.WPF;
using CMDL.DAL;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for LabPage.xaml
    /// </summary>
    public partial class LabPage : Window
    {
        public LabPage(LabClientInfo client,cmdldbDataSet cmdldb,bool AllowPrint, string UserName)
        {
            InitializeComponent();
            this.DataContext = client;

            foreach (string t in Test.Parse(cmdldb.Tables["exam"], client.Exam, "LAB"))
            {
                switch (Test.TableName(cmdldb.Tables["exam"], t))
                {
                    case "blood_typing": tabControl1.Items.Add(new TabItem() { Header = t, Content = new Viewbox() { Child = new UC_BloodTyping(client, AllowPrint, UserName) } });
                        break;
                    case "cbc": tabControl1.Items.Add(new TabItem() { Header = t, Content = new Viewbox() { Child = new UC_CBC(client,AllowPrint,UserName) } });
                        break;
                    case "cultureandsensitivity": tabControl1.Items.Add(new TabItem() { Header = t, Content = new ScrollViewer() { Content = new Viewbox() { Child = new UC_CultureAndSensitivity(client, cmdldb, AllowPrint, UserName) } } });
                        break;
                    case "grams_staining": tabControl1.Items.Add(new TabItem() { Header = t, Content = new Viewbox() { Child = new UC_GramsStaining(client, AllowPrint, UserName) } });
                        break;
                    case "medical_certificate": tabControl1.Items.Add(new TabItem() { Header = t, Content = new Viewbox() { Child = new UC_MedicalCertificate(client, AllowPrint, UserName)  } });
                        break;
                    case "pe": tabControl1.Items.Add(new TabItem() { Header = t, Content = new ScrollViewer() { Content = new Viewbox() { Child = new UC_PE(client, cmdldb, AllowPrint, UserName)  } } });
                        break;
                    case "preg_test": tabControl1.Items.Add(new TabItem() { Header = t, Content = new Viewbox() { Child = new UC_PregTest(client, AllowPrint, UserName)  } });
                        break;
                    case "serology":
                        tabControl1.Items.Add(new TabItem() { Header = t, Content = new Viewbox() { Child = new UC_Serology(client, t, AllowPrint, UserName) { MedTech_2 = cmdldb.Tables["medtech"] } } });
                        //tabControl1.Items.Add(new TabItem() { Header = t, Content = new Viewbox() { Child = new UC_Serology1(client, AllowPrint, UserName) } });
                        break;
                    case "stool": tabControl1.Items.Add(new TabItem() { Header = t, Content = new ScrollViewer() { Content = new Viewbox() { Child = new UC_StoolExam(client, AllowPrint, UserName)  } } });
                        break;
                    case "urinalysis": tabControl1.Items.Add(new TabItem() { Header = t, Content = new ScrollViewer() { Content = new Viewbox() { Child = new UC_Urinalysis(client, cmdldb, AllowPrint, UserName)  } } });
                        break;
                    case "bloodchemistry": tabControl1.Items.Add(new TabItem() { Header = t, Content = new ScrollViewer() { Content = new Viewbox() { Child = new UC_BloodChemistry(client, cmdldb, AllowPrint, UserName)  } } });
                        break;
                    case "papsmear": tabControl1.Items.Add(new TabItem() { Header = t, Content = new ScrollViewer() { Content = new Viewbox() { Child = new UC_PapSmear(client, AllowPrint, UserName)  } } });
                        break;
                    

                }
            }
            
        }

    }
}