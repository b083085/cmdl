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
    public partial class NewRequestingPartyForm : Form
    {
        public NewRequestingPartyForm()
        {
            InitializeComponent();

            this.Load += NewRequestingPartyForm_Load;
            tbRequestingParty.KeyDown += tbRequestingParty_KeyDown;
        }

        void tbRequestingParty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrWhiteSpace(tbRequestingParty.Text))
                    MessageBox.Show("Requesting party not specified!");
                else
                {
                    using (var db = new DataContext())
                    {
                        var res = db.Save("insert into tblreqparties(reqpartyname) values(@reqpartyname)", new MySqlParam() { Key = "@reqpartyname", Value = tbRequestingParty.Text });

                        if (res)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Unable to create requesting party due to database error. Please try again!");
                            tbRequestingParty.Focus();
                        }
                    }
                }
            }
        }

        void NewRequestingPartyForm_Load(object sender, EventArgs e)
        {
            tbRequestingParty.Focus();
        }

        public string RequestingParty
        {
            get
            {
                return tbRequestingParty.Text;
            }
        }
    }
}
