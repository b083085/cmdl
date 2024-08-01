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
    public partial class RadiologistPage : Form
    {
        


        public RadiologistPage(DataTable radiologist)
        {
            InitializeComponent();
            

            BtOK.Click += new EventHandler(BtOK_Click);
            BtCancel.Click += new EventHandler(BtCancel_Click);


            foreach (DataRow d in radiologist.Rows)
                listBox1.Items.Add(Convert.ToString(d["name"]));
        }

        void BtCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void BtOK_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count > 0)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("You haven't selected a Radiologist!");
        }

        public string Radiologist
        {
            get
            {
                return Convert.ToString(listBox1.SelectedItem);
            }
        }

    }
}
