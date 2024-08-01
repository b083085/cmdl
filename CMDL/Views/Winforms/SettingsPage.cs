using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace CMDL
{
    public partial class SettingsPage : Form
    {
        public SettingsPage()
        {
            InitializeComponent();
            BtUpdate.Click += new EventHandler(BtUpdate_Click);
            btUser.Click += new EventHandler(btUser_Click);

            try
            {
                TbServer.Text = Properties.Settings.Default.Server;
                TbDatabase.Text = Properties.Settings.Default.Database;
                TbUserID.Text = Properties.Settings.Default.UserID;
                TbPort.Text = Properties.Settings.Default.Port;
                TbPassword.Text = Properties.Settings.Default.Password;

                checkedListBox1.SetItemChecked(0, Properties.Settings.Default.Ck_Reg);
                checkedListBox1.SetItemChecked(1, Properties.Settings.Default.Ck_XRay);
                checkedListBox1.SetItemChecked(2, Properties.Settings.Default.Ck_Neuro);
                checkedListBox1.SetItemChecked(3, Properties.Settings.Default.Ck_Lab);
                checkedListBox1.SetItemChecked(4, Properties.Settings.Default.Ck_Update);
                checkedListBox1.SetItemChecked(5, Properties.Settings.Default.Ck_Settings);
                checkedListBox1.SetItemChecked(6, Properties.Settings.Default.Ck_Reports);
                checkedListBox1.SetItemChecked(7, Properties.Settings.Default.Ck_About);
            }
            catch (Exception)
            {
                //do nothing
            }
        }

        void btUser_Click(object sender, EventArgs e)
        {
            UserForm userFrm = new UserForm();
            userFrm.ShowDialog();
        }
        void BtUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.Server = TbServer.Text;
                Properties.Settings.Default.Database = TbDatabase.Text;
                Properties.Settings.Default.UserID = TbUserID.Text;
                Properties.Settings.Default.Port = TbPort.Text;
                Properties.Settings.Default.Password = TbPassword.Text;

                Properties.Settings.Default.Ck_Reg = checkedListBox1.GetItemChecked(0);
                Properties.Settings.Default.Ck_XRay = checkedListBox1.GetItemChecked(1);
                Properties.Settings.Default.Ck_Neuro = checkedListBox1.GetItemChecked(2);
                Properties.Settings.Default.Ck_Lab = checkedListBox1.GetItemChecked(3);
                Properties.Settings.Default.Ck_Update = checkedListBox1.GetItemChecked(4);
                Properties.Settings.Default.Ck_Settings = checkedListBox1.GetItemChecked(5);
                Properties.Settings.Default.Ck_Reports = checkedListBox1.GetItemChecked(6);
                Properties.Settings.Default.Ck_About = checkedListBox1.GetItemChecked(7);

                Properties.Settings.Default.Save();

                CyberModelConnectionString();

                MessageBox.Show("Settings Updated Succesfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message,"Settings Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void CyberModelConnectionString()
        {

            string str = "metadata=res://*/Models.CyberModel.csdl|res://*/Models.CyberModel.ssdl|res://*/Models.CyberModel.msl;provider=MySql.Data.MySqlClient;provider connection string=&quot;server=" + TbServer.Text + ";user id=" + TbUserID.Text + ";password=" + TbPassword.Text + ";persistsecurityinfo=True;database=" + TbDatabase.Text + "&quot;";


            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement element in XmlDoc.DocumentElement)
            {
                if (element.Name == "connectionStrings")
                {
                    //element.FirstChild.Attributes[2].Value = str;
                    //MessageBox.Show(element.FirstChild.Attributes["name"].Value + "," + element.FirstChild.Attributes["connectionString"].Value);

                    foreach (XmlNode child in element.ChildNodes)
                    {
                        XmlAttribute xmlName = child.Attributes[0]; //connection string

                        if (xmlName.Value == "CyberContext")
                        {
                            XmlAttribute xmlCS = child.Attributes[1];
                            xmlCS.Value = str;
                            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                            break;
                        }
                    }
                }
            }
        }





    }
}
