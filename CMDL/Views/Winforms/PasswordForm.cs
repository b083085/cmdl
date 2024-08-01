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
    public partial class PasswordForm : Form
    {
        DataTable tb;
        
        public PasswordForm(DataTable tb)
        {
            InitializeComponent();

            this.tb = tb;

            btOK.Click += new EventHandler(btOK_Click);
            tbPassword.KeyDown += new KeyEventHandler(tbPassword_KeyDown);

            this.Load += new EventHandler(PasswordForm_Load);

        }

        void PasswordForm_Load(object sender, EventArgs e)
        {
            tbPassword.Focus();
        }

        void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidatePassword();
            }
        }

        void btOK_Click(object sender, EventArgs e)
        {
            ValidatePassword();
        }

        void ValidatePassword()
        {
            if (!String.IsNullOrWhiteSpace(tbPassword.Text))
            {
                bool exist = false;

                foreach (DataRow dr in tb.Rows)
                {
                    if (Convert.ToString(dr["user_pwd"]) == tbPassword.Text)
                    {
                        exist = true;
                        break;
                    }

                }

                if (exist == true)
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                else
                {
                    MessageBox.Show("Invalid Password!", "Password Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbPassword.Clear();
                    tbPassword.Focus();
                }
            }
            else
            {
                MessageBox.Show("Invalid Password!", "Password Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPassword.Clear();
                tbPassword.Focus();
            }
        }
    }
}
