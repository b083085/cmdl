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
    public partial class SalesStatusPage : Form
    {
        MySqlDB db = new MySqlDB(Properties.Settings.Default.Server,
                                   Properties.Settings.Default.Database,
                                   Properties.Settings.Default.UserID,
                                   Properties.Settings.Default.Port,
                                   Properties.Settings.Default.Password);
        public SalesStatusPage()
        {
            InitializeComponent();
            this.Load += new EventHandler(SalesStatusPage_Load);
            bgSearch.DoWork += new DoWorkEventHandler(bgSearch_DoWork);
            bgSearch.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgSearch_RunWorkerCompleted);
            BtSearch.Click += new EventHandler(BtSearch_Click);
        }

        void BtSearch_Click(object sender, EventArgs e)
        {
            BtSearch.Text = "Searching...";
            BtSearch.Enabled = false;

            dateTimePicker1.Tag = string.Format("{0:yyyy-MM-dd}",dateTimePicker1.Value);
            dateTimePicker2.Tag = string.Format("{0:yyyy-MM-dd}", dateTimePicker2.Value);
            bgSearch.RunWorkerAsync(db);
        }

        void bgSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Unable to connect to the database!Please contact your Database Administrator for further assistance.","Search Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                MySqlDB test = e.Result as MySqlDB;
                if (test.length > 0)
                {
                    LbTotalClient.Text = Convert.ToString(db.returnrow[0]["count(*)"]);
                    LbTotalSales.Text = String.Format("{0:0.00}", db.returnrow[0]["sum(amt_paid)"]);
                    LbTotalBalance.Text = String.Format("{0:0.00}", db.returnrow[0]["sum(amt_balance)"]);
                    LbTotalChange.Text = String.Format("{0:0.00}", db.returnrow[0]["sum(amt_change)"]);
                }
            }

            BtSearch.Text = "Search";
            BtSearch.Enabled = true;
        }

        void bgSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MySqlDB arg = e.Argument as MySqlDB;
                arg.Select("select count(*),sum(amt_paid),sum(amt_balance),sum(amt_change) from reg where date_reg >='" + dateTimePicker1.Tag.ToString() + "' and date_reg <='" + dateTimePicker2.Tag.ToString() + "'", "reg");
                e.Result = arg;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }

        void SalesStatusPage_Load(object sender, EventArgs e)
        {
            try
            {
                db.Select("select count(*),sum(amt_paid),sum(amt_balance),sum(amt_change) from reg where date_reg='" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "'", "reg");
                LbTotalClient.Text = Convert.ToString(db.returnrow[0]["count(*)"]);
                LbTotalSales.Text = String.Format("{0:0.00}", db.returnrow[0]["sum(amt_paid)"]);
                LbTotalBalance.Text = String.Format("{0:0.00}", db.returnrow[0]["sum(amt_balance)"]);
                LbTotalChange.Text = String.Format("{0:0.00}", db.returnrow[0]["sum(amt_change)"]);
            }
            catch (Exception)
            {
                //none
            }
        }
    }
}
