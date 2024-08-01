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
    public partial class RequestingPartyListForm : Form
    {
        public RequestingPartyListForm()
        {
            InitializeComponent();

            listBox1.MouseDoubleClick += listBox1_MouseDoubleClick;
            listBox1.KeyDown += listBox1_KeyDown;


            Load += RequestingPartyListForm_Load;
        }



        void RequestingPartyListForm_Load(object sender, EventArgs e)
        {
            using (var db = new DataContext())
            {
                var ds = db.Get("select * from tblReqParties order by ReqPartyName asc");

                foreach (DataRow dr in ds.Tables["Table"].Rows)
                {
                    listBox1.Items.Add(dr.Field<string>("ReqPartyName"));
                }
            }
        }
        void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.SelectedItem != null)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
        void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        public string SelectedRequestingParty
        {
            get
            {
                return Convert.ToString(listBox1.SelectedItem);
            }
        }
    }
}
