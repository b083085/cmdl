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
    public partial class DatePage : Form
    {
        public DatePage()
        {
            InitializeComponent();
            BtOK.Click += new EventHandler(BtOK_Click);
            BtCancel.Click += new EventHandler(BtCancel_Click);
        }

        void BtCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void BtOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public string GetDate
        {
            get
            {
                return string.Format("{0:yyyy-MM-dd}", dateTimePicker1.Value);
            }
        }


    }
}
