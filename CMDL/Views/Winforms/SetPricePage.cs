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
    public partial class SetPricePage : Form
    {
        public SetPricePage(string test,string price)
        {
            InitializeComponent();
            BtOK.Click += new EventHandler(BtOK_Click);
            BtCancel.Click += new EventHandler(BtCancel_Click);

            tbPrice.KeyDown += new KeyEventHandler(tbPrice_KeyDown);

            gbTest.Text = test;
            tbPrice.Text = Convert.ToDouble(price).ToString();

            tbPrice.Focus();
        }

        void tbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidatePrice())
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        void BtCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        void BtOK_Click(object sender, EventArgs e)
        {
            if(ValidatePrice())
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public string Price
        {
            get
            {
                return tbPrice.Text;
            }
        }

        public bool ValidatePrice()
        {
            double doubleDump = 0;

            if (double.TryParse(tbPrice.Text, out doubleDump))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Price not valid!","Validate Price",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return false;
            }
        }
    }
}
