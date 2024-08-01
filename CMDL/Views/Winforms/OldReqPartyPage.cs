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
    public partial class OldReqPartyPage : Form
    {
        public OldReqPartyPage(DataTable tbreqparty)
        {
            InitializeComponent();

            foreach (DataRow d in tbreqparty.Rows)
                listBox1.Items.Add(d["name"]);

            listBox1.Sorted = true;

            BtOK.Click += new EventHandler(BtOK_Click);
            BtCancel.Click += new EventHandler(BtCancel_Click);

            listBox1.KeyDown += new KeyEventHandler(listBox1_KeyDown);
            listBox1.DoubleClick += new EventHandler(listBox1_DoubleClick);
        }

        void listBox1_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        void BtCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void BtOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public string RequestingParty
        {
            get
            {
                if(String.IsNullOrEmpty(Convert.ToString(listBox1.SelectedItem)))
                    return "NONE";
                else
                return Convert.ToString(listBox1.SelectedItem);
            }
        }

    }
}
