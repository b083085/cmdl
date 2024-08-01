using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMDL.Models;
using CMDL.DAL;

namespace CMDL
{
    public partial class EditRecordsPage : Form
    {
        ClientModel model;
        cmdldbDataSet cmdl;
        ClientDB db = new ClientDB(Properties.Settings.Default.Server,
                                   Properties.Settings.Default.Database,
                                   Properties.Settings.Default.UserID,
                                   Properties.Settings.Default.Port,
                                   Properties.Settings.Default.Password);

        DataRow dr;

        private int ctr = 0;
        private object obj_idx = 0;

        List<Examination> rec_exam = new List<Examination>();

        public EditRecordsPage(ClientModel model,cmdldbDataSet cmdl)
        {
            InitializeComponent();

            this.model = model;
            this.cmdl = cmdl;
            db.Cmdl = cmdl;

            TbKeyword.KeyDown += new KeyEventHandler(TbKeyword_KeyDown);
            BtSearch.Click += new EventHandler(BtSearch_Click);
            bgSearch.DoWork += new DoWorkEventHandler(bgSearch_DoWork);
            bgSearch.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgSearch_RunWorkerCompleted);

            bgUpdate.DoWork += new DoWorkEventHandler(bgUpdate_DoWork);
            bgUpdate.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgUpdate_RunWorkerCompleted);

            BtFirstRec.Click += new EventHandler(BtFirstRec_Click);
            BtPrevious.Click += new EventHandler(BtPrevious_Click);
            BtNextRec.Click += new EventHandler(BtNextRec_Click);
            BtLastRec.Click += new EventHandler(BtLastRec_Click);
            btDeleteRecord.Click += new EventHandler(btDeleteRecord_Click);

            TbLastName.TextChanged += new EventHandler(TbLastName_TextChanged);
            TbFirstName.TextChanged += new EventHandler(TbFirstName_TextChanged);
            TbMI.TextChanged += new EventHandler(TbMI_TextChanged);
            TbSuffix.TextChanged += new EventHandler(TbSuffix_TextChanged);
            TbAddress.TextChanged += new EventHandler(TbAddress_TextChanged);
            TbAge.TextChanged += new EventHandler(TbAge_TextChanged);
            CbSex.SelectionChangeCommitted += new EventHandler(CbSex_SelectionChangeCommitted);
            CbCivilStatus.SelectionChangeCommitted += new EventHandler(CbCivilStatus_SelectionChangeCommitted);
            BirthDate.ValueChanged += new EventHandler(BirthDate_ValueChanged);
            DateReg.ValueChanged += new EventHandler(DateReg_ValueChanged);
            TbBirthPlace.TextChanged += new EventHandler(TbBirthPlace_TextChanged);
            CbPurpose.SelectionChangeCommitted += new EventHandler(CbPurpose_SelectionChangeCommitted);
            TbTelNo.TextChanged += new EventHandler(TbTelNo_TextChanged);
            TbMobileNo.TextChanged += new EventHandler(TbMobileNo_TextChanged);
            TbDistrictBranch.TextChanged += new EventHandler(TbDistrictBranch_TextChanged);
            LbTotal.TextChanged += new EventHandler(LbTotal_TextChanged);
            LbAmountPaid.TextChanged += new EventHandler(LbAmountPaid_TextChanged);
            LbBalance.TextChanged += new EventHandler(LbBalance_TextChanged);
            LbChange.TextChanged += new EventHandler(LbChange_TextChanged);
            BtCapture.Click += new EventHandler(BtCapture_Click);
            BtTest.Click += new EventHandler(BtTest_Click);
            BtUpdateRecord.Click += new EventHandler(BtUpdateRecord_Click);
            BtCopyAddr.Click += new EventHandler(BtCopyAddr_Click);
            BtNewReqParty.Click += new EventHandler(BtNewReqParty_Click);
            BtDelete.Click += new EventHandler(BtDelete_Click);
            CbSex.SelectedIndexChanged += new EventHandler(CbSex_SelectedIndexChanged);
            CbCivilStatus.SelectedIndexChanged += new EventHandler(CbCivilStatus_SelectedIndexChanged);
            CbPurpose.SelectedIndexChanged += new EventHandler(CbPurpose_SelectedIndexChanged);
            LbControlNo.TextChanged += new EventHandler(LbControlNo_TextChanged);

            this.FormClosed += new FormClosedEventHandler(EditRecordsPage_FormClosed);
            this.Load += new EventHandler(EditRecordsPage_Load);

            CbFilter.SelectedIndexChanged += new EventHandler(CbFilter_SelectedIndexChanged);
        }

        void btDeleteRecord_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to delete this record?[Y/N]", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                var pwdForm = new PasswordForm(cmdl.Tables["admin_user"]);
                if (pwdForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var db = new CyberContext())
                        {
                            var reg = db.regs.Where(p => p.controlno == LbControlNo.Text).FirstOrDefault();
                            if (reg != null)
                            {
                                db.regs.DeleteObject(reg);
                                if (db.SaveChanges() == 1)
                                {
                                    MessageBox.Show("Record has been deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("Unable to delete this record!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException != null)
                            MessageBox.Show(ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        else
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                }
                
                
            }
        }

        void EditRecordsPage_Load(object sender, EventArgs e)
        {
            CbFilter.SelectedIndex = 0;
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

        void BtSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        void DateReg_ValueChanged(object sender, EventArgs e)
        {
            db.date = DateReg.Value;
        }

        void EditRecordsPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearEntries();
        }

        void CbPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.Purpose = CbPurpose.Text;
            db.purpose = CbPurpose.Text;
        }

        void CbCivilStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.CivilStatus = CbCivilStatus.Text;
            db.civilstatus = CbCivilStatus.Text;
        }

        void CbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            model.Sex = CbSex.Text;
            db.sex = CbSex.Text;
        }

        void LbControlNo_TextChanged(object sender, EventArgs e)
        {
            model.ControlNo = LbControlNo.Text;
            db.controlno = LbControlNo.Text;
        }

        void BtDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ListOfParties.Items.Remove(ListOfParties.SelectedItem);
            }
            catch (Exception)
            {
                //none
            }

            model.ReqParty = ClientMethod.ParseRequestingParty(ListOfParties.Items);
            db.reqparty = ClientMethod.ParseRequestingParty(ListOfParties.Items);
        }

        void BtNewReqParty_Click(object sender, EventArgs e)
        {
            NewRequestingPartyForm nrpForm = new NewRequestingPartyForm();
            if (nrpForm.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(nrpForm.RequestingParty))
                {
                    ListOfParties.Items.Add(nrpForm.RequestingParty);
                    model.ReqParty = ClientMethod.ParseRequestingParty(ListOfParties.Items);
                    db.reqparty = ClientMethod.ParseRequestingParty(ListOfParties.Items);
                }
            }
        }

        void BtCopyAddr_Click(object sender, EventArgs e)
        {
            TbBirthPlace.Text = TbAddress.Text;
        }

        void BtTest_Click(object sender, EventArgs e)
        {
            TestPage tpage = new TestPage(cmdl, listView1.Items);
            tpage.Total = Convert.ToDouble(LbTotal.Text);
            tpage.AmountPaid = Convert.ToDouble(LbAmountPaid.Text);
            tpage.Balance = Convert.ToDouble(LbBalance.Text);
            tpage.Change = Convert.ToDouble(LbChange.Text);

            if (tpage.ShowDialog() == DialogResult.OK)
            {
                LbTotal.Text = String.Format("{0:0.00}", Convert.ToDouble(tpage.Total));
                LbAmountPaid.Text = String.Format("{0:0.00}", Convert.ToDouble(tpage.AmountPaid));
                LbBalance.Text = String.Format("{0:0.00}", Convert.ToDouble(tpage.Balance));
                LbChange.Text = String.Format("{0:0.00}", Convert.ToDouble(tpage.Change));

                listView1.Items.Clear();
                model.Exam.Clear();
                db.exams.Clear();

                foreach (ListViewItem i in tpage.Items)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { i.Text, i.SubItems[1].Text }));
                    model.Exam.Add(new Examination() { Test = i.Text, Price = i.SubItems[1].Text });
                    db.exams.Add(new Examination() { Test = i.Text, Price = i.SubItems[1].Text });
                }

                model.ListViewItemRefresh();

            }
        }

        void BtCapture_Click(object sender, EventArgs e)
        {
            Camera_Form camform = new Camera_Form();
            camform.PhotoEvent += new EventHandler(camform_PhotoEvent);
            camform.ShowDialog();
            camform.PhotoEvent -= new EventHandler(camform_PhotoEvent);
        }

        void camform_PhotoEvent(object sender, EventArgs e)
        {
            var img = sender as Image;
            pictureBox1.Image = Edit.Resize(img, pictureBox1.Size);
            model.Photo = Edit.BmpSource(pictureBox1.Image);
            db.photo = Edit.ImageToStream(pictureBox1.Image);
        }

        void LbChange_TextChanged(object sender, EventArgs e)
        {
            try
            {
                model.Change = Convert.ToDouble(LbChange.Text);
                db.change = Convert.ToDouble(LbChange.Text);
            }
            catch (Exception)
            {
                //none
            }
        }

        void LbBalance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                model.Balance = Convert.ToDouble(LbBalance.Text);
                db.bal = Convert.ToDouble(LbBalance.Text);
            }
            catch (Exception)
            {
                //none
            }
        }

        void LbAmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                model.Paid = Convert.ToDouble(LbAmountPaid.Text);
                db.paid = Convert.ToDouble(LbAmountPaid.Text);
            }
            catch (Exception)
            {
                //none
            }
        }

        void LbTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                model.Total = Convert.ToDouble(LbTotal.Text);
                db.total = Convert.ToDouble(LbTotal.Text);
            }
            catch (Exception)
            {
                //none
            }
        }

        void TbDistrictBranch_TextChanged(object sender, EventArgs e)
        {
            model.Branch = TbDistrictBranch.Text;
            db.branch = TbDistrictBranch.Text;
        }

        void TbMobileNo_TextChanged(object sender, EventArgs e)
        {
            model.CelNo = TbMobileNo.Text;
            db.celno = TbMobileNo.Text;
        }

        void TbTelNo_TextChanged(object sender, EventArgs e)
        {
            model.TelNo = TbTelNo.Text;
            db.telno = TbTelNo.Text;
        }

        void CbPurpose_SelectionChangeCommitted(object sender, EventArgs e)
        {
            model.Purpose = CbPurpose.Text;
            db.purpose = CbPurpose.Text;
        }

        void TbBirthPlace_TextChanged(object sender, EventArgs e)
        {
            model.BPlace = TbBirthPlace.Text;
            db.bplace = TbBirthPlace.Text;
        }

        void BirthDate_ValueChanged(object sender, EventArgs e)
        {
            model.BDate = BirthDate.Text;
            db.bdate = BirthDate.Value;
        }

        void CbCivilStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            model.CivilStatus = CbCivilStatus.Text;
            db.civilstatus = CbCivilStatus.Text;
        }

        void CbSex_SelectionChangeCommitted(object sender, EventArgs e)
        {
            model.Sex = CbSex.Text;
            db.sex = CbSex.Text;
        }

        void TbAge_TextChanged(object sender, EventArgs e)
        {
            model.Age = TbAge.Text;
            db.age = TbAge.Text;
        }

        void TbAddress_TextChanged(object sender, EventArgs e)
        {
            model.Address = TbAddress.Text;
            db.address = TbAddress.Text;
        }

        void TbSuffix_TextChanged(object sender, EventArgs e)
        {
            model.Suffix = TbSuffix.Text;
            db.suffix = TbSuffix.Text;
        }

        void TbMI_TextChanged(object sender, EventArgs e)
        {
            if (!TbMI.Text.Contains(".") && !String.IsNullOrWhiteSpace(TbMI.Text))
                TbMI.Text += ".";

            model.MI = TbMI.Text;
            db.mi = TbMI.Text;
        }

        void TbFirstName_TextChanged(object sender, EventArgs e)
        {
            model.FirstName = TbFirstName.Text;
            db.firstname = TbFirstName.Text;
        }

        void TbLastName_TextChanged(object sender, EventArgs e)
        {
            model.LastName = TbLastName.Text;
            db.lastname = TbLastName.Text;
        }

        void BtUpdateRecord_Click(object sender, EventArgs e)
        {
            var pwdForm = new PasswordForm(cmdl.Tables["admin_user"]);
            if (pwdForm.ShowDialog() == DialogResult.OK)
            {
                BtUpdateRecord.Text = "Updating...";
                BtUpdateRecord.Enabled = false;
                obj_idx = ctr;

                bgUpdate.RunWorkerAsync(db);
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

        void bgUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Unable to connect to the Database!Please contact your Database Administrator for further assistance!");
            }
            else
            {
                if ((bool)e.Result)
                {
                    MessageBox.Show("RECORD UPDATED SUCCESSFULLY!", "Update Message");
                }
                else
                {
                    MessageBox.Show("Unable to Update this Record!", "Update Message");
                }
            }

            BtUpdateRecord.Text = "Update Record";
            BtUpdateRecord.Enabled = true;
        }

        void bgUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ClientDB arg = e.Argument as ClientDB;
                if(arg.Update(Convert.ToInt32(obj_idx)))
                {
                    e.Result = true;
                }
                else
                {
                    e.Result = false;
                }
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
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
                    ClearEntries();
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

        void TbKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private string ConvertTableName(string name)
        {
            switch (name)
            {
                case "CONTROL NO.": return "controlno";
                case "DATE": return "date_reg";
                case "LAST NAME": return "lastname";
                case "FIRST NAME": return "firstname";
                case "MIDDLE INITIAL": return "mi";
                case "SUFFIX": return "suffix";
                case "ADDRESS": return "address";
                case "AGE": return "age";
                case "SEX": return "sex";
                case "CIVIL STATUS": return "civil_status";
                case "BIRTH DATE": return "bdate";
                case "BIRTH PLACE": return "bplace";
                case "REQUESTING PARTY": return "reqparty";
                case "PURPOSE": return "purpose";
                case "TELEPHONE NO.": return "telno";
                case "MOBILE NO.": return "celno";
                case "DISTRICT/BRANCH": return "district_branch";
                case "EXAM": return "exam";
                default: return "";
            }

           
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
                TbKeyword.Tag = "select * from reg where " + ConvertTableName(CbFilter.Text) + "='" + TbKeyword.Text + "'";
            }

            bgSearch.RunWorkerAsync(db);
        }

        void ClearEntries()
        {

            TbLastName.ResetText();
            TbFirstName.ResetText();
            TbMI.ResetText();
            TbSuffix.ResetText();
            TbAddress.ResetText();
            TbAge.ResetText();
            CbSex.Text = null;
            CbCivilStatus.Text = null;
            TbBirthPlace.ResetText();
            ListOfParties.Items.Clear();
            CbPurpose.Text = null;
            TbTelNo.ResetText();
            TbMobileNo.ResetText();
            TbDistrictBranch.ResetText();
            pictureBox1.Image = null;
            listView1.Items.Clear();
            LbTotal.Text = "0";
            LbAmountPaid.Text = "0";
            LbBalance.Text = "0";
            LbChange.Text = "0";

            if (model != null)
            {
                model.BDate = string.Empty;
                model.ReqParty = string.Empty;
                model.Photo = null;

                model.Exam.Clear();
                model.ListViewItemRefresh();
            }

        }

        private void DisplayInfo(int inc)
        {
            try
            {
                DateTime dt = new DateTime();

                dr = db.returnrow[inc];
                Image img = Edit.ByteArrayToImage((byte[])dr["photo"]);

                pictureBox1.Image = Edit.Resize(img, pictureBox1.Size);

                model.Photo = Edit.BmpSource(pictureBox1.Image);
                db.photo = Edit.ImageToStream(pictureBox1.Image);

                //---------------------------------------
                LbControlNo.Text = dr["controlno"].ToString();
                LbTimeIn.Text = string.Format("{0:hh:mm:ss tt}", DateTime.Parse(Convert.ToString(dr["time_in"])));
                TbLastName.Text = dr["lastname"].ToString();
                TbFirstName.Text = dr["firstname"].ToString();
                TbMI.Text = dr["mi"].ToString();
                TbSuffix.Text = dr["suffix"].ToString();
                TbAddress.Text = dr["address"].ToString();
                TbAge.Text = dr["age"].ToString();
                CbSex.Text = dr["sex"].ToString();
                CbCivilStatus.Text = dr["civil_status"].ToString();
                TbBirthPlace.Text = dr["bplace"].ToString();

                ListOfParties.Items.Clear();
                ListOfParties.Items.Add(Convert.ToString(dr["reqparty"]));

                model.ReqParty = Convert.ToString(dr["reqparty"]);
                db.reqparty = Convert.ToString(dr["reqparty"]);

                CbPurpose.Text = dr["purpose"].ToString();
                TbTelNo.Text = dr["telno"].ToString();
                TbMobileNo.Text = dr["celno"].ToString();
                TbDistrictBranch.Text = dr["district_branch"].ToString();

                listView1.Items.Clear();
                rec_exam.Clear();
                model.Exam.Clear();
                db.exams.Clear();

                //---------EXAM and PRICE------------------------------

                ClientMethod.SetTest(rec_exam, dr["exam"].ToString());
                ClientMethod.SetPrice(rec_exam, dr["price"].ToString());

                //----------------------------------

                foreach (Examination ex in rec_exam)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = ex.Test;
                    item.SubItems.Add(ex.Price);
                    listView1.Items.Add(item);
                    model.Exam.Add(ex);
                    db.exams.Add(ex);
                }

                model.ListViewItemRefresh();
                LbTotal.Text = string.Format("{0:0.00}", dr["total"]);
                LbAmountPaid.Text = string.Format("{0:0.00}", dr["amt_paid"]);
                LbBalance.Text = string.Format("{0:0.00}", dr["amt_balance"]);
                LbChange.Text = string.Format("{0:0.00}", dr["amt_change"]);
                LbRecordCounter.Text = (inc + 1).ToString() + " of " + db.returnrow.Length.ToString();

                if (DateTime.TryParse(Convert.ToString(dr["bdate"]), out dt))
                {
                    BirthDate.Value = Convert.ToDateTime(dr["bdate"]);
                    model.BDate = Convert.ToDateTime(dr["bdate"]).ToString("MM-dd-yyyy");
                }
                else
                {
                    MessageBox.Show("Unable to convert the date of birth of this patient. please verify the correct birthdate of this patient.", "Display Information Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                if (DateTime.TryParse(Convert.ToString(dr["date_reg"]), out dt))
                {
                    DateReg.Value = DateTime.Parse(Convert.ToString(dr["date_reg"]));
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error:{0}", ex.Message), "Display Information Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    }
}
