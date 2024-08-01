using CMDL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    public enum DocTestType
    {
        BloodTest=0,
        BloodTyping,
        CBC,
        GramsStaining,
        HepA,
        HepB,
        HepC,
        HIV,
        Neuro,
        PE,
        PregnancyTest,
        Sales,
        Stool,
        Urinalysis,
        XRay
    }
    
    public partial class ReportPage : Form
    {
        DocTestType type;
        object sqlquery = null;
        MySqlDB db = new MySqlDB(Properties.Settings.Default.Server,
                               "cmdldb",
                               Properties.Settings.Default.UserID,
                               Properties.Settings.Default.Port,
                               Properties.Settings.Default.Password);

        private Font printFont = new Font("Arial", 9.75F);
        private Font printFont_bold = new Font("Arial", 9.75F, FontStyle.Bold);

        private int ctr = 0, ctr2 = 0;
        private double noofpages = 1.0;

        public ReportPage(DocTestType type)
        {
            InitializeComponent();
            this.type = type;

            SetReportTitle(type);
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            BtSearch.Click += new EventHandler(BtSearch_Click);
            BtPrint.Click += new EventHandler(BtPrint_Click);

            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom Size", 816, 1248);
            printDocument1.EndPrint += new PrintEventHandler(printDocument1_EndPrint);
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
        }

        void SetReportTitle(DocTestType type)
        {
            switch (type)
            {
                case DocTestType.BloodTest:
                    lbTitle.Text = "Blood Test";
                    break;
                case DocTestType.BloodTyping:
                    lbTitle.Text = "Blood Typing";
                    break;
                case DocTestType.CBC:
                    lbTitle.Text = "CBC";
                    break;
                case DocTestType.GramsStaining:
                    lbTitle.Text = "Gram Staining";
                    break;
                case DocTestType.HepA:
                    lbTitle.Text = "Hep A";
                    break;
                case DocTestType.HepB:
                    lbTitle.Text = "Hep B";
                    break;
                case DocTestType.HepC:
                    lbTitle.Text = "Hep C";
                    break;
                case DocTestType.HIV:
                    lbTitle.Text = "HIV";
                    break;
                case DocTestType.Neuro:
                    lbTitle.Text = "Neuro";
                    break;
                case DocTestType.PE:
                    lbTitle.Text = "PE";
                    break;
                case DocTestType.PregnancyTest:
                    lbTitle.Text = "Pregnancy Test";
                    break;
                case DocTestType.Sales:
                    lbTitle.Text = "Sales";
                    break;
                case DocTestType.Stool:
                    lbTitle.Text = "Stool";
                    break;
                case DocTestType.Urinalysis:
                    lbTitle.Text = "Urinalysis";
                    break;
                case DocTestType.XRay:
                    lbTitle.Text = "X-Ray";
                    break;
                default:
                    break;
            }
        }

        void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            ctr = 0;
            ctr2 = 0;
            noofpages = 1.0;
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Unable to connect to the database!Please contact your database Administrator for further assistance!");
            }
            else
            {
                var test = e.Result as MySqlDB;
                if (test.length > 0)
                {
                    dataGridView1.DataSource = test.ds.Tables["reg"];
                    lbTotal.Text = test.length.ToString();
                }
                else
                {
                    MessageBox.Show("No Record(s) Found!");
                    lbTotal.Text = "0";
                }
            }

            BtSearch.Text = "Search";
            BtSearch.Enabled = true;
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MySqlDB argumentest = e.Argument as MySqlDB;
                argumentest.Select(sqlquery.ToString(), "reg");
                e.Result = argumentest;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }

        void BtPrint_Click(object sender, EventArgs e)
        {
            ctr = 0;
            ctr2 = 0;
            noofpages = 1.0;

            if (GlobalInstance.Instance.User.CanPrint)
            {
                printDocument1.DefaultPageSettings.Landscape = true;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("User: " + UserName + " is not allowed to print reports!", "Print Result Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        void BtSearch_Click(object sender, EventArgs e)
        {
            BtSearch.Text = "Searching...";
            BtSearch.Enabled = false;

            switch(type)
            {
                case DocTestType.BloodTest: sqlquery = "select reg.*,serology.* from reg left join serology on reg.controlno=serology.serology_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%BLOOD TEST%'";
                    break;
                case DocTestType.BloodTyping: sqlquery = "select reg.*,blood_typing.* from reg left join blood_typing on reg.controlno=blood_typing.btype_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%BLOOD TYPING%'";
                    break;
                case DocTestType.CBC: sqlquery = "select reg.*,cbc.* from reg left join cbc on reg.controlno=cbc.cbc_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%CBC%'";
                    break;
                case DocTestType.GramsStaining: sqlquery = "select reg.*,grams_staining.* from reg left join grams_staining on reg.controlno=grams_staining.grams_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%GRAMS STAINING%'";
                    break;
                case DocTestType.HepA: sqlquery = "select reg.*,serology.* from reg left join serology on reg.controlno=serology.serology_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%HEP A%'";
                    break;
                case DocTestType.HepB: sqlquery = "select reg.*,serology.* from reg left join serology on reg.controlno=serology.serology_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%HEP B%'";
                    break;
                case DocTestType.HepC: sqlquery = "select reg.*,serology.* from reg left join serology on reg.controlno=serology.serology_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%HEP C%'";
                    break;
                case DocTestType.HIV: sqlquery = "select reg.*,serology.* from reg left join serology on reg.controlno=serology.serology_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%HIV%'";
                    break;
                case DocTestType.Neuro: sqlquery = "select reg.*,neuro.* from reg left join neuro on reg.controlno=neuro.neuro_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%NEURO%'";
                    break;
                case DocTestType.PE: sqlquery = "select reg.*,pe.* from reg left join pe on reg.controlno=pe.pe_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%PHYSICAL EXAMINATION%'";
                    break;
                case DocTestType.PregnancyTest: sqlquery = "select reg.*,preg_test.* from reg left join preg_test on reg.controlno=preg_test.preg_test_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%PREGNANCY TEST%'";
                    break;
                case DocTestType.Sales: sqlquery = "select * from reg where reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "'";
                    break;
                case DocTestType.Stool: sqlquery = "select reg.*,stool.* from reg left join stool on reg.controlno=stool.stool_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%STOOL EXAM%'";
                    break;
                case DocTestType.Urinalysis: sqlquery = "select reg.*,urinalysis.* from reg left join urinalysis on reg.controlno=urinalysis.urine_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam like '%URINALYSIS%'";
                    break;
                case DocTestType.XRay: sqlquery = "select reg.*,xray.* from reg left join xray on reg.controlno=xray.xray_controlno where (reg.date_reg >='" + dateTimePicker1.Text + "' and reg.date_reg <='" + dateTimePicker2.Text + "') and exam_type like '%XRAY%'";
                    break;
            }

            backgroundWorker1.RunWorkerAsync(db);
        }

        private void BloodTest(PrintPageEventArgs e,int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("BLOOD TEST " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(20, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(193, 40));
            e.Graphics.DrawString("ANTI HIV 1/2", printFont_bold, Brushes.Black, new Point(537, 40));
            e.Graphics.DrawString("HBsAg", printFont_bold, Brushes.Black, new Point(710, 40));
            e.Graphics.DrawString("SYPHILIS", printFont_bold, Brushes.Black, new Point(883, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(1056, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["time_in"].ToString(), printFont, Brushes.Black, new Point(20, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(193, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["anti_hiv_res"].ToString(), printFont, Brushes.Black, new Point(537, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["hbsag_res"].ToString(), printFont, Brushes.Black, new Point(710, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["anti_tp_res"].ToString(), printFont, Brushes.Black, new Point(883, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1056, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void BloodTyping(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("BLOOD TYPING " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(20, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(193, 40));
            e.Graphics.DrawString("RESULT", printFont_bold, Brushes.Black, new Point(537, 40));
            e.Graphics.DrawString("REMARKS", printFont_bold, Brushes.Black, new Point(710, 40));
            e.Graphics.DrawString("REQ. PHYSICIAN", printFont_bold, Brushes.Black, new Point(883, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(1150, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["time_in"].ToString(), printFont, Brushes.Black, new Point(20, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(193, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["results"].ToString(), printFont, Brushes.Black, new Point(537, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["remarks"].ToString(), printFont, Brushes.Black, new Point(710, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["req_physician"].ToString(), printFont, Brushes.Black, new Point(883, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1150, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void CBC(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("CBC " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("DATE", printFont_bold, Brushes.Black, new Point(10, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(92, 40));
            e.Graphics.DrawString("ERYTHRO.", printFont_bold, Brushes.Black, new Point(256, 40));
            e.Graphics.DrawString("HEMO.", printFont_bold, Brushes.Black, new Point(338, 40));
            e.Graphics.DrawString("HEMA.", printFont_bold, Brushes.Black, new Point(420, 40));
            e.Graphics.DrawString("LEUKO.", printFont_bold, Brushes.Black, new Point(502, 40));
            e.Graphics.DrawString("SEG.", printFont_bold, Brushes.Black, new Point(584, 40));
            e.Graphics.DrawString("STABS", printFont_bold, Brushes.Black, new Point(666, 40));
            e.Graphics.DrawString("LYMPHO.", printFont_bold, Brushes.Black, new Point(748, 40));
            e.Graphics.DrawString("MONO.", printFont_bold, Brushes.Black, new Point(830, 40));
            e.Graphics.DrawString("EOSI.", printFont_bold, Brushes.Black, new Point(912, 40));
            e.Graphics.DrawString("BASO.", printFont_bold, Brushes.Black, new Point(994, 40));
            e.Graphics.DrawString("PLT", printFont_bold, Brushes.Black, new Point(1076, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Black, new Point(1150, 40));



            while (ctr < db.length)
            {
                e.Graphics.DrawString(DateTime.Parse(db.returnrow[ctr]["date_reg"].ToString()).ToShortDateString(), printFont, Brushes.Black, new Point(10, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new RectangleF(new Point(92, ypos),new SizeF(164,15)));
                e.Graphics.DrawString(db.returnrow[ctr]["erythrocyte_count"].ToString(), printFont, Brushes.Black, new Point(256, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["hemoglobin"].ToString(), printFont, Brushes.Black, new Point(338, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["hematocrit"].ToString(), printFont, Brushes.Black, new Point(420, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["leukocyte_count"].ToString(), printFont, Brushes.Black, new Point(502, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["segmenters"].ToString(), printFont, Brushes.Black, new Point(584, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["stabs"].ToString(), printFont, Brushes.Black, new Point(666, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lymphocytes"].ToString(), printFont, Brushes.Black, new Point(748, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["monocytes"].ToString(), printFont, Brushes.Black, new Point(830, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["eosinophils"].ToString(), printFont, Brushes.Black, new Point(912, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["basophils"].ToString(), printFont, Brushes.Black, new Point(994, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["platelet"].ToString(), printFont, Brushes.Black, new Point(1076, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1150, ypos));


                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void GramsStaining(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("GRAMS STAINING " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(20, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(193, 40));
            e.Graphics.DrawString("RESULT", printFont_bold, Brushes.Black, new Point(537, 40));
            e.Graphics.DrawString("REMARKS", printFont_bold, Brushes.Black, new Point(710, 40));
            e.Graphics.DrawString("REQ. PHYSICIAN", printFont_bold, Brushes.Black, new Point(883, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(1056, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["time_in"].ToString(), printFont, Brushes.Black, new Point(20, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(193, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["results"].ToString(), printFont, Brushes.Black, new Point(537, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["remarks"].ToString(), printFont, Brushes.Black, new Point(710, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["req_physician"].ToString(), printFont, Brushes.Black, new Point(883, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1056, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void HepA(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("HEP A " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(20, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(193, 40));
            e.Graphics.DrawString("RESULT", printFont_bold, Brushes.Black, new Point(537, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(881, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["time_in"].ToString(), printFont, Brushes.Black, new Point(20, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(193, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["anti_hiv_res"].ToString(), printFont, Brushes.Black, new Point(537, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(881, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void HepB(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("HEP B " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(20, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(193, 40));
            e.Graphics.DrawString("RESULT", printFont_bold, Brushes.Black, new Point(537, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(881, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["time_in"].ToString(), printFont, Brushes.Black, new Point(20, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(193, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["hbsag_res"].ToString(), printFont, Brushes.Black, new Point(537, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(881, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }
            }
        }

        private void HepC(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("HEP C " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(20, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(193, 40));
            e.Graphics.DrawString("RESULT", printFont_bold, Brushes.Black, new Point(537, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(881, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["time_in"].ToString(), printFont, Brushes.Black, new Point(20, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(193, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["anti_tp_res"].ToString(), printFont, Brushes.Black, new Point(537, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(881, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }
            }
        }

        private void HIV(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("HIV " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(20, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(193, 40));
            e.Graphics.DrawString("RESULT", printFont_bold, Brushes.Black, new Point(537, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(881, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["time_in"].ToString(), printFont, Brushes.Black, new Point(20, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(193, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["anti_hiv_res"].ToString(), printFont, Brushes.Black, new Point(537, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(881, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void Neuro(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("NEURO " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }
            
            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(10, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(211, 40));
            e.Graphics.DrawString("REMARKS", printFont_bold, Brushes.Black, new Point(412, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(1115, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["time_in"].ToString(), printFont, Brushes.Black, new Point(10, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(211, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["remarks"].ToString(), printFont, Brushes.Black, new RectangleF(new Point(412, ypos),new SizeF(700,140)));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1115, ypos));

                ypos += 140;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 5);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void PE(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("PHYSICAL EXAMINATION " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(10, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(211, 40));
            e.Graphics.DrawString("REMARKS", printFont_bold, Brushes.Black, new Point(412, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(1115, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["time_in"].ToString(), printFont, Brushes.Black, new Point(10, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(211, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["remarks"].ToString(), printFont, Brushes.Black, new RectangleF(new Point(412, ypos), new SizeF(700, 140)));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1115, ypos));

                ypos += 140;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 5);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void PregnancyTest(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("PREGNANCY TEST " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(20, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(193, 40));
            e.Graphics.DrawString("RESULT", printFont_bold, Brushes.Black, new Point(537, 40));
            e.Graphics.DrawString("REMARKS", printFont_bold, Brushes.Black, new Point(710, 40));
            e.Graphics.DrawString("REQ. PHYSICIAN", printFont_bold, Brushes.Black, new Point(883, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(1150, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["time_in"].ToString(), printFont, Brushes.Black, new Point(20, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(193, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["results"].ToString(), printFont, Brushes.Black, new Point(537, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["remarks"].ToString(), printFont, Brushes.Black, new Point(710, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["req_physician"].ToString(), printFont, Brushes.Black, new Point(883, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1150, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void Sales(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("SALES " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }
            
            e.Graphics.DrawString("DATE", printFont_bold, Brushes.Black, new Point(10, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(90, 40));
            e.Graphics.DrawString("REQ.PARTY", printFont_bold, Brushes.Black, new Point(252, 40));
            e.Graphics.DrawString("EXAM", printFont_bold, Brushes.Black, new Point(373, 40));
            e.Graphics.DrawString("PAID", printFont_bold, Brushes.Black, new Point(950, 40));
            e.Graphics.DrawString("BAL.", printFont_bold, Brushes.Black, new Point(1000, 40));
            e.Graphics.DrawString("CHANGE.", printFont_bold, Brushes.Black, new Point(1050, 40));
            e.Graphics.DrawString("CTRL.NO.", printFont_bold, Brushes.Black, new Point(1150, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(DateTime.Parse(db.returnrow[ctr]["date_reg"].ToString()).ToShortDateString(), printFont, Brushes.Black, new Point(10, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new RectangleF(new Point(90, ypos), new SizeF(162, 15)));
                e.Graphics.DrawString(db.returnrow[ctr]["reqparty"].ToString(), printFont, Brushes.Black, new RectangleF(new Point(252, ypos), new SizeF(162, 15)));
                e.Graphics.DrawString(db.returnrow[ctr]["exam"].ToString(), printFont, Brushes.Black, new RectangleF(new Point(373, ypos), new SizeF(577, 15)));
                e.Graphics.DrawString(db.returnrow[ctr]["amt_paid"].ToString(), printFont, Brushes.Black, new Point(950, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["amt_balance"].ToString(), printFont, Brushes.Black, new Point(1000, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["amt_change"].ToString(), printFont, Brushes.Black, new Point(1050, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1150, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    
                    if (ctr == db.length - 1)
                    {
                        var amtpaid = 0;
                        var bal = 0;
                        var change = 0;

                        foreach (var d in db.returnrow)
                        {
                            amtpaid += Convert.ToInt32(d["amt_paid"]);
                            bal += Convert.ToInt32(d["amt_balance"]);
                            change += Convert.ToInt32(d["amt_change"]);
                        }

                        e.Graphics.DrawString("Total Amt.Paid: " + amtpaid + Environment.NewLine +
                                              "Total Balance: " + bal + Environment.NewLine + 
                                              "Total Change: " + change, printFont, Brushes.Black, new Point(1000, (ypos + 20)));
                        e.HasMorePages = false;
                    }

                    
                       
                }


            }
        }

        private void Stool(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("STOOL " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("DATE", printFont_bold, Brushes.Black, new Point(20, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(121, 40));
            e.Graphics.DrawString("CONSIST.", printFont_bold, Brushes.Black, new Point(323, 40));
            e.Graphics.DrawString("COLOR", printFont_bold, Brushes.Black, new Point(424, 40));
            e.Graphics.DrawString("LEUKO.", printFont_bold, Brushes.Black, new Point(525, 40));
            e.Graphics.DrawString("ERYTH.", printFont_bold, Brushes.Black, new Point(625, 40));
            e.Graphics.DrawString("FAT GLOB.", printFont_bold, Brushes.Black, new Point(727, 40));
            e.Graphics.DrawString("YEAST.", printFont_bold, Brushes.Black, new Point(828, 40));
            e.Graphics.DrawString("OVA.", printFont_bold, Brushes.Black, new Point(909, 40));
            e.Graphics.DrawString("PROTO.", printFont_bold, Brushes.Black, new Point(1010, 40));
            e.Graphics.DrawString("OCC.", printFont_bold, Brushes.Black, new Point(1111, 40));
            e.Graphics.DrawString("CTRL. NO.", printFont_bold, Brushes.Black, new Point(1150, 40));



            while (ctr < db.length)
            {
                e.Graphics.DrawString(DateTime.Parse(db.returnrow[ctr]["date_reg"].ToString()).ToShortDateString(), printFont, Brushes.Black, new Point(20, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(121, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["consistency"].ToString(), printFont, Brushes.Black, new Point(323, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["color"].ToString(), printFont, Brushes.Black, new Point(424, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["leukocytes"].ToString(), printFont, Brushes.Black, new Point(525, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["erythrocytes"].ToString(), printFont, Brushes.Black, new Point(625, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["fat_globules"].ToString(), printFont, Brushes.Black, new Point(727, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["yeast_cells"].ToString(), printFont, Brushes.Black, new Point(828, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["ova_of_parasite"].ToString(), printFont, Brushes.Black, new Point(909, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["protozoan"].ToString(), printFont, Brushes.Black, new Point(1010, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["occult_blood"].ToString(), printFont, Brushes.Black, new Point(1111, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1150, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void Urinalysis(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("URINALYSIS " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("DATE", printFont_bold, Brushes.Black, new Point(20, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(121, 40));
            e.Graphics.DrawString("COLOR.", printFont_bold, Brushes.Black, new Point(323, 40));
            e.Graphics.DrawString("TRANS.", printFont_bold, Brushes.Black, new Point(424, 40));
            e.Graphics.DrawString("SP.GRAV.", printFont_bold, Brushes.Black, new Point(525, 40));
            e.Graphics.DrawString("PH.", printFont_bold, Brushes.Black, new Point(625, 40));
            e.Graphics.DrawString("GLU.", printFont_bold, Brushes.Black, new Point(727, 40));
            e.Graphics.DrawString("PROTEIN.", printFont_bold, Brushes.Black, new Point(828, 40));
            e.Graphics.DrawString("RBC.", printFont_bold, Brushes.Black, new Point(909, 40));
            e.Graphics.DrawString("WBC.", printFont_bold, Brushes.Black, new Point(1010, 40));
            e.Graphics.DrawString("E.C.", printFont_bold, Brushes.Black, new Point(1111, 40));
            e.Graphics.DrawString("CTRL. NO.", printFont_bold, Brushes.Black, new Point(1150, 40));



            while (ctr < db.length)
            {
                e.Graphics.DrawString(DateTime.Parse(db.returnrow[ctr]["date_reg"].ToString()).ToShortDateString(), printFont, Brushes.Black, new Point(20, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new Point(121, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["color"].ToString(), printFont, Brushes.Black, new Point(323, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["transparency"].ToString(), printFont, Brushes.Black, new Point(424, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["specific_gravity"].ToString(), printFont, Brushes.Black, new Point(525, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["ph"].ToString(), printFont, Brushes.Black, new Point(625, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["glucose"].ToString(), printFont, Brushes.Black, new Point(727, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["protein"].ToString(), printFont, Brushes.Black, new Point(828, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["rbc"].ToString(), printFont, Brushes.Black, new Point(909, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["wbc"].ToString(), printFont, Brushes.Black, new Point(1010, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["epithelial_cells"].ToString(), printFont, Brushes.Black, new Point(1111, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1150, ypos));

                ypos += 20;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 37);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void XRay(PrintPageEventArgs e, int ypos)
        {
            try
            {
                if (noofpages == 1.0)
                    e.Graphics.DrawString("XRAY " + DateTime.Parse(db.returnrow[0]["date_reg"].ToString()).ToShortDateString() + " - " + DateTime.Parse(db.returnrow[db.length - 1]["date_reg"].ToString()).ToShortDateString() + "\t Result(s): " + db.length.ToString(), printFont_bold, Brushes.Black, new Point(10, 20));
            }
            catch (Exception)
            {
                //do nothing
            }

            e.Graphics.DrawString("TRANSACTION TIME", printFont_bold, Brushes.Black, new Point(10, 40));
            e.Graphics.DrawString("NAME", printFont_bold, Brushes.Black, new Point(183, 40));
            e.Graphics.DrawString("MARKER", printFont_bold, Brushes.Black, new Point(356, 40));
            e.Graphics.DrawString("REMARKS", printFont_bold, Brushes.Black, new Point(529, 40));
            e.Graphics.DrawString("CONTROL NO.", printFont_bold, Brushes.Red, new Point(1115, 40));


            while (ctr < db.length)
            {
                e.Graphics.DrawString(db.returnrow[ctr]["date_reg"].ToString(), printFont, Brushes.Black, new Point(10, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["lastname"].ToString() + ", " + db.returnrow[ctr]["firstname"].ToString() + " " + db.returnrow[ctr]["mi"].ToString(), printFont, Brushes.Black, new RectangleF(new Point(183, ypos), new SizeF(173, 80)));
                e.Graphics.DrawString(db.returnrow[ctr]["marker"].ToString(), printFont, Brushes.Black, new Point(356, ypos));
                e.Graphics.DrawString(db.returnrow[ctr]["conclusion"].ToString(), printFont, Brushes.Black, new RectangleF(new Point(529, ypos), new SizeF(586, 60)));
                e.Graphics.DrawString(db.returnrow[ctr]["controlno"].ToString(), printFont, Brushes.Red, new Point(1115, ypos));

                ypos += 60;
                ctr += 1;
                ctr2 += 1;
                var divdb = ((double)ctr2 / 13);

                if (Math.Floor(divdb) == 1.0)
                {
                    e.HasMorePages = true;
                    ctr2 = 0;
                    break;
                }
                else
                {

                    e.HasMorePages = false;
                }


            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int ypos = 60;

            switch (type)
            {
                case DocTestType.BloodTest: BloodTest(e, ypos);                   
                    break;
                case DocTestType.BloodTyping: BloodTyping(e, ypos);               
                    break;
                case DocTestType.CBC: CBC(e, ypos);                    
                    break;
                case DocTestType.GramsStaining: GramsStaining(e, ypos);                    
                    break;
                case DocTestType.HepA: HepA(e, ypos);                    
                    break;
                case DocTestType.HepB: HepB(e, ypos);                  
                    break;
                case DocTestType.HepC: HepC(e, ypos);
                    break;
                case DocTestType.HIV: HIV(e, ypos);              
                    break;
                case DocTestType.Neuro: Neuro(e, ypos);                 
                    break;
                case DocTestType.PE: PE(e, ypos);                  
                    break;
                case DocTestType.PregnancyTest: PregnancyTest(e, ypos);                     
                    break;
                case DocTestType.Sales: Sales(e, ypos);                  
                    break;
                case DocTestType.Stool: Stool(e, ypos);              
                    break;
                case DocTestType.Urinalysis: Urinalysis(e, ypos);                    
                    break;
                case DocTestType.XRay: XRay(e, ypos);                  
                    break;
            }
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
