using CMDL.DAL;
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
    public partial class PrintReceiptPage : Form
    {
        ClientDB db = new ClientDB(Properties.Settings.Default.Server,
                                   Properties.Settings.Default.Database,
                                   Properties.Settings.Default.UserID,
                                   Properties.Settings.Default.Port,
                                   Properties.Settings.Default.Password);
        cmdldbDataSet cmdl;

        int ctr = 0;

        DataRow dr;

        Reg_PrintDoc print_doc = new Reg_PrintDoc();

        public PrintReceiptPage(cmdldbDataSet cmdl)
        {
            InitializeComponent();
            this.cmdl = cmdl;

            CbFilter.SelectedIndexChanged += new EventHandler(CbFilter_SelectedIndexChanged);
            BtSearch.Click += new EventHandler(BtSearch_Click);
            TbKeyword.KeyDown += new KeyEventHandler(TbKeyword_KeyDown);

            BtFirstRec.Click += new EventHandler(BtFirstRec_Click);
            BtPrevious.Click += new EventHandler(BtPrevious_Click);
            BtNextRec.Click += new EventHandler(BtNextRec_Click);
            BtLastRec.Click += new EventHandler(BtLastRec_Click);

            bgSearch.DoWork += new DoWorkEventHandler(bgSearch_DoWork);
            bgSearch.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgSearch_RunWorkerCompleted);

            BtPrint.Click += new EventHandler(BtPrint_Click);
            BtMagnifier.Click += new EventHandler(BtMagnifier_Click);
            Mag100Menu.Click += new EventHandler(Mag100Menu_Click);
            Mag150Menu.Click += new EventHandler(Mag150Menu_Click);
            Mag200Menu.Click += new EventHandler(Mag200Menu_Click);
            Mag250Menu.Click += new EventHandler(Mag250Menu_Click);
            Mag300Menu.Click += new EventHandler(Mag300Menu_Click);
            Mag350Menu.Click += new EventHandler(Mag350Menu_Click);
            Mag400Menu.Click += new EventHandler(Mag400Menu_Click);
            Mag450Menu.Click += new EventHandler(Mag450Menu_Click);
            Mag500Menu.Click += new EventHandler(Mag500Menu_Click);
            ActualSizeMenu.Click += new EventHandler(ActualSizeMenu_Click);
        }



        void bgSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Unable to connect to the Database!Please contact your Database Administrator for further assistance!");
            }
            else
            {
                ClientDB test = e.Result as ClientDB;

                if (test.length > 0)
                {
                    LbNoOfResults.Text = test.length.ToString();
                    ctr = 0;
                    DisplayInfo(ctr);
                }
                else
                {
                    MessageBox.Show("No Record(s) Found!", "Search Message");
                    LbNoOfResults.Text = "0";
                    ctr = 0;
                    //ClearEntries();
                }
            }

            TbKeyword.Enabled = true;
            BtSearch.Text = "Search";
            BtSearch.Enabled = true;
        }

        void bgSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ClientDB arg = e.Argument as ClientDB;
                arg.Select(TbKeyword.Tag.ToString(), "reg");
                e.Result = arg;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }

        }

        void BtLastRec_Click(object sender, EventArgs e)
        {
            if (db.length != 0)
            {
                ctr = db.returnrow.Length - 1;
                DisplayInfo(ctr);
            }
        }

        void BtNextRec_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctr < db.length - 1)
                {
                    ctr++;
                    DisplayInfo(ctr);
                }
                else
                {

                    MessageBox.Show("Last Record", "Update Message");
                }
            }
            catch
            {
                //do nothing
            }
        }

        void BtPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (ctr > 0)
                {
                    ctr--;
                    DisplayInfo(ctr);

                }
                else
                {
                    MessageBox.Show("First Record", "Update Message");
                }
            }
            catch
            {
                //do nothing
            }
        }

        void BtFirstRec_Click(object sender, EventArgs e)
        {
            if (db.length != 0)
            {
                ctr = 0;
                DisplayInfo(0);
            }
        }

        void TbKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        void BtSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbFilter.Text == "DATE" || CbFilter.Text == "BIRTH DATE")
            {
                DatePage dpage = new DatePage();
                if (dpage.ShowDialog() == DialogResult.OK)
                {
                    TbKeyword.Text = dpage.GetDate;
                }
            }

            TbKeyword.Focus();
        }

        private void Search()
        {
            BtSearch.Text = "Searching...";
            TbKeyword.Enabled = false;
            BtSearch.Enabled = false;

            if (CbFilter.Text == "TODAY")
            {
                TbKeyword.Tag = "select * from reg where date_reg='" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "'";
            }
            else if (CbFilter.Text == "CUSTOM QUERY")
            {
                TbKeyword.Tag = TbKeyword.Text;
            }
            else
            {
                TbKeyword.Tag = "select * from reg where " + ClientMethod.ConvertTableName(CbFilter.Text) + "='" + TbKeyword.Text + "'";
            }

            bgSearch.RunWorkerAsync(db);
        }

        private void DisplayInfo(int inc)
        {
            dr = db.returnrow[inc];

            LbControlNo.Text = Convert.ToString(dr["controlno"]);
            LbLastName.Text = Convert.ToString(dr["lastname"]);
            LbFirstName.Text = Convert.ToString(dr["firstname"]);
            LbMI.Text = Convert.ToString(dr["mi"]);

            LbRecordCounter.Text = (inc + 1).ToString() + " of " + db.returnrow.Length.ToString();

            Preview();
        }

        void Preview()
        {
            List<Examination> exams = new List<Examination>();
   
            print_doc.ControlNo = Convert.ToString(dr["controlno"]);
            print_doc.Date_Registered = DateTime.Parse(Convert.ToString(dr["time_in"]));
            print_doc.LastName = Convert.ToString(dr["lastname"]);
            print_doc.FirstName = Convert.ToString(dr["firstname"]);
            print_doc.MI = Convert.ToString(dr["mi"]);
            print_doc.Suffix = Convert.ToString(dr["suffix"]);
            print_doc.Address = Convert.ToString(dr["address"]);
            print_doc.Age = Convert.ToString(dr["age"]);
            print_doc.Sex = Convert.ToString(dr["sex"]);
            print_doc.ReqParty = Convert.ToString(dr["reqparty"]);
            print_doc.Exam = Convert.ToString(dr["exam"]);
            print_doc.Price = Convert.ToString(dr["price"]);
            print_doc.Total = Convert.ToDouble(dr["total"]);
            print_doc.AmountPaid = Convert.ToDouble(dr["amt_paid"]);
            print_doc.Balance = Convert.ToDouble(dr["amt_balance"]);
            print_doc.Change = Convert.ToDouble(dr["amt_change"]);
            print_doc.Photo = Edit.ByteArrayToImage((byte[])dr["photo"]);
            print_doc.TbSingle = cmdl.Tables["exam"];

            string test = "";
            string price = "";
            int i = 0;

            foreach (char c in Convert.ToString(dr["exam"]))
            {
                if (c.ToString() != ",")
                    test += c.ToString();
                else
                {
                    exams.Add(new Examination() { Test = test });
                    test = "";
                }
            }

            foreach (char c in Convert.ToString(dr["price"]))
            {
                if (c.ToString() != ",")
                    price += c.ToString();
                else
                {
                    exams[i].Price = price;
                    price = "";
                    i += 1;
                }
            }

            
            
            print_doc.Exam_Type = ClientMethod.TestType(exams, cmdl);

            this.printPreviewControl1.Document = print_doc.Document();
            this.printPreviewControl1.Columns = print_doc.page.Count;
        }

        void ActualSizeMenu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 0.3;
        }

        void Mag500Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 5.0;
        }

        void Mag450Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 4.50;
        }

        void Mag400Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 4.0;
        }

        void Mag350Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 3.50;
        }

        void Mag300Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 3.0;
        }

        void Mag250Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 2.50;
        }

        void Mag200Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 2.0;
        }

        void Mag150Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 1.50;
        }

        void Mag100Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 1.0;
        }

        void BtMagnifier_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom += 0.3;
        }

        void BtPrint_Click(object sender, EventArgs e)
        {
            if (AllowPrint)
            {
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    print_doc.FinalPrint(printDialog1.PrinterSettings);
                }
            }
            else
            {
                MessageBox.Show("User '" + UserName + "' is not allowed to print stub!", "Print Stub Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void PrintReceiptPage_Load(object sender, EventArgs e)
        {

        }

        public bool AllowPrint
        {
            set;
            get;
        }

        public string UserName
        {
            set;
            get;
        }
  
    }
}
