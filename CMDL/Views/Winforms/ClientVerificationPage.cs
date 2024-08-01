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
    public partial class ClientVerificationPage : Form
    {
        ClientDB db = new ClientDB(Properties.Settings.Default.Server,
                                   Properties.Settings.Default.Database,
                                   Properties.Settings.Default.UserID,
                                   Properties.Settings.Default.Port,
                                   Properties.Settings.Default.Password);

        BackgroundWorker bgload = new BackgroundWorker();

        public ClientVerificationPage()
        {
            InitializeComponent();

            bgload.WorkerSupportsCancellation = true;
            bgload.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgload_RunWorkerCompleted);
            bgload.DoWork += new DoWorkEventHandler(bgload_DoWork);

            BtSearch.Click += new EventHandler(BtSearch_Click);
            BtNewRecord.Click += new EventHandler(BtNewRecord_Click);
            BtCancel.Click += new EventHandler(BtCancel_Click);

            
        }

        public DataRow Record
        {
            get
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    return db.returnrow[row.Index];

                return null;
            }
        }

        void BtCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void BtNewRecord_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
        }

        void BtSearch_Click(object sender, EventArgs e)
        {
            BtSearch.Text = "Searching...";
            BtSearch.Enabled = false;

            TbLastName.Tag = TbLastName.Text;
            TbFirstName.Tag = TbFirstName.Text;
            dateTimePicker1.Tag = string.Format("{0:yyyy-MM-dd}",dateTimePicker1.Value);

            bgload.RunWorkerAsync(db);
        }

        void bgload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ClientDB argumentest = e.Argument as ClientDB;
                argumentest.Select("select * from reg where lastname='" + TbLastName.Tag.ToString() + "' and firstname='" + TbFirstName.Tag.ToString() + "' and bdate='" + dateTimePicker1.Tag.ToString() + "'", "reg");
                e.Result = argumentest;
                e.Cancel = false;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }

        }

        void bgload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Unable to connect to the database!Please contact your Database Administrator");
            }
            else
            {
                ClientDB test = e.Result as ClientDB;
                if (test.length > 0)
                {
                    foreach (DataRow d in test.returnrow)
                        dataGridView1.Rows.Add(DateTime.Parse(d["date_reg"].ToString()).ToShortDateString(),
                                               Edit.Resize(Edit.ByteArrayToImage((byte[])d["photo"]), new Size(50, 50)),
                                               d["lastname"].ToString(),
                                               d["firstname"].ToString(),
                                               d["mi"].ToString(),
                                               d["age"].ToString(),
                                               d["sex"].ToString());
                }
                else
                {
                    MessageBox.Show("No Record(s) found!");
                }
            }

            BtSearch.Text = "Search";
            BtSearch.Enabled = true;
        }


    }
}
