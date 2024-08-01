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
using CMDL.CLASS;


namespace CMDL.WPF
{
    /// <summary>
    /// Interaction logic for UC_PapSmear.xaml
    /// </summary>
    public partial class UC_PapSmear : UserControl
    {

        LabClientInfo data;
        PapSmear_PrintDoc doc = new PapSmear_PrintDoc();

        MySqlDB db = new MySqlDB(Properties.Settings.Default.Server,
                                Properties.Settings.Default.Database,
                                Properties.Settings.Default.UserID,
                                Properties.Settings.Default.Port,
                                Properties.Settings.Default.Password);

        public UC_PapSmear(LabClientInfo data, bool allowPrint, string userName)
        {
            InitializeComponent();

            this.DataContext = data.PapSmear;
            this.data = data;
            this.AllowPrint = allowPrint;
            this.UserName = userName;

            btSaveRecord.Click += new RoutedEventHandler(btSaveRecord_Click);
            btPreview.Click += new RoutedEventHandler(btPreview_Click);
        }

        void btPreview_Click(object sender, RoutedEventArgs e)
        {

        }

        void btSaveRecord_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(btSaveRecord.Content) == "SAVE RECORD")
            {
                if (db.OpenConnection())
                {
                    db.CloseConnection();
                    if (ValidateEntries())
                    {
                        var ppage = new PasswordPage();
                        ppage.TableName = "office_user";

                        if (ppage.ShowDialog() == true)
                        {
                            data.PapSmear.PrintedBy = ppage.User;
                            if (db.MySqlCommand("insert into papsmear(controlno,system,specimen_type,adequacy_of_specimen,general_categorization,interpretation,interpretedBy,interpretedByTitle,note,medtech,pathologist,printedBy)" +
                                                " values('" + data.PapSmear.ControlNo +
                                                         "','" + data.PapSmear.System +
                                                         "','" + data.PapSmear.SpecimenType +
                                                         "','" + data.PapSmear.AdequacyOfSpecimen +
                                                         "','" + data.PapSmear.GeneralCategorization +
                                                         "','" + data.PapSmear.Interpretation +
                                                         "','" + data.PapSmear.InterpretedBy +
                                                         "','" + data.PapSmear.InterpretedByTitle +
                                                         "','" + data.PapSmear.Note +
                                                         "','" + data.PapSmear.Medtech +
                                                         "','" + data.PapSmear.Pathologist +
                                                         "','" + data.PapSmear.PrintedBy + "')"))
                            {
                                MessageBox.Show("Record Saved!","Save Record Message",MessageBoxButton.OK,MessageBoxImage.Information);
                                data.PapSmear.Enabled = false;
                                data.Count += 1;
                                data.Status = (data.Count == data.Total_Count ? "DONE" : "NOT DONE");

                                if (AllowPrint)
                                    Print();
                                else
                                    MessageBox.Show("User: " + UserName + " is not allowed to print laboratory result(s)!", "Print Result Message", MessageBoxButton.OK, MessageBoxImage.Stop);


                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Unable to connect!");
                }
            }
            else if (Convert.ToString(btSaveRecord.Content) == "PRINT")
            {
                Print();
            }
        }

        bool ValidateEntries()
        {
            if(!String.IsNullOrWhiteSpace(data.PapSmear.System))
            {
                if (!String.IsNullOrWhiteSpace(data.PapSmear.SpecimenType))
                {
                    if (!String.IsNullOrWhiteSpace(data.PapSmear.AdequacyOfSpecimen))
                    {
                        if (!String.IsNullOrWhiteSpace(data.PapSmear.GeneralCategorization))
                        {
                            if (!String.IsNullOrWhiteSpace(data.PapSmear.Interpretation))
                            {
                                if (!String.IsNullOrWhiteSpace(data.PapSmear.InterpretedBy))
                                {
                                    if (!String.IsNullOrWhiteSpace(data.PapSmear.InterpretedByTitle))
                                    {
                                        if (!String.IsNullOrWhiteSpace(data.PapSmear.Medtech))
                                        {
                                            if (!String.IsNullOrWhiteSpace(data.PapSmear.Pathologist))
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Pathologist not specified!", "Validate Entries Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Medical Technologist not specified!", "Validate Entries Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Interpreted By Title not specified!", "Validate Entries Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Interpreted By not specified!", "Validate Entries Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Interpretation not specified!", "Validate Entries Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }
                        }
                        else
                        {
                            MessageBox.Show("General Categorization not specified!", "Validate Entries Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Adequacy Of Specimen not specified!", "Validate Entries Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Specimen Type not specified!", "Validate Entries Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            else
            {
                MessageBox.Show("System not specified!","Validate Entries Message",MessageBoxButton.OK,MessageBoxImage.Stop);
            }

            return false;
        }

        void Print()
        {
            doc.Preview(new List<LabClientInfo>() { data });
        }

        void Preview()
        {
            doc.CyberPreview(new List<LabClientInfo>() { data });
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
