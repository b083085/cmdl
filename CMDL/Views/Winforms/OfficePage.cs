using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    public partial class OfficePage : Form
    {
        SettingsDB db = new SettingsDB(Properties.Settings.Default.Server,
                                     Properties.Settings.Default.Database,
                                     Properties.Settings.Default.UserID,
                                     Properties.Settings.Default.Port,
                                     Properties.Settings.Default.Password);

        delegate void DelOfficeUser();

        BindingSource bs = new BindingSource();
        
        public OfficePage()
        {
            InitializeComponent();
            this.Load += new EventHandler(OfficePage_Load);
            BtDelete.Click += new EventHandler(BtDelete_Click);
            BtAdd.Click += new EventHandler(BtAdd_Click);
            BtUpdate.Click += new EventHandler(BtUpdate_Click);

            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
        }

        void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    TbUserName.Text = Convert.ToString(db.returnrow[listBox1.SelectedIndex]["user_name"]);
            //    TbPassword.Text = Convert.ToString(db.returnrow[listBox1.SelectedIndex]["user_pwd"]);
            //}
            //catch (Exception)
            //{
            //    //do nothing
            //}
        }

        void BtUpdate_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelOfficeUser(UpdateUser));
            }
            else
            {
                UpdateUser();
            }
        }

        void BtAdd_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelOfficeUser(AddUser));
            }
            else
            {
                AddUser();
            }
        }

        void BtDelete_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DelOfficeUser(DeleteUser));
            }
            else
            {
                DeleteUser();
            }
        }

        void AddUser()
        {
            if (db.Insert(TbUserName.Text, TbPassword.Text))
            {
                MessageBox.Show("User Added Successfully!");
            }
        }

        void DeleteUser()
        {
            if (db.Delete(listBox1.SelectedIndex))
            {
                MessageBox.Show("User Deleted Successfully!");
            }
        }

        void UpdateUser()
        {
            if (db.Update(listBox1.SelectedIndex, TbUserName.Text, TbPassword.Text))
            {
                MessageBox.Show("User Updated Successfully!");
            }
        }

        void OfficePage_Load(object sender, EventArgs e)
        {
            db.Select("select * from office_user","office_user");

            bs.DataSource = db.ds.Tables["office_user"];

            listBox1.DataSource = bs;
            listBox1.DisplayMember = "user_name";

            TbUserName.DataBindings.Add("Text",bs,"user_name");
            TbPassword.DataBindings.Add("Text",bs,"user_pwd");
        }
    }
}
