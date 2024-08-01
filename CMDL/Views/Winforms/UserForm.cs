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
    public partial class UserForm : Form
    {
        MySqlDB db;
        
        public UserForm()
        {
            InitializeComponent();
            btAdd.Click += new EventHandler(btAdd_Click);
            btAdd.Enabled = false;

            this.Load += new EventHandler(UserForm_Load);

            tbConfirmPassword.TextChanged += new EventHandler(tbConfirmPassword_TextChanged);
  
        }

        void tbConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbPassword.Text == tbConfirmPassword.Text)
            {
                btAdd.Enabled = true;
                errorProvider1.SetError(tbConfirmPassword, "");
            }
            else
            {
                btAdd.Enabled = false;
                errorProvider1.SetError(tbConfirmPassword, "Invalid Password!");
            }
        }

        void UserForm_Load(object sender, EventArgs e)
        {
            try
            {
                db = new MySqlDB(Properties.Settings.Default.Server,
                                 Properties.Settings.Default.Database,
                                 Properties.Settings.Default.UserID,
                                 Properties.Settings.Default.Port,
                                 Properties.Settings.Default.Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        void btAdd_Click(object sender, EventArgs e)
        {
            office_userTableAdapter1.Connection = db.connection;
            if (office_userTableAdapter1.Insert(tbUserName.Text, tbConfirmPassword.Text) == 1)
            {
                MessageBox.Show(tbUserName.Text + "has been inserted!", "User Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
