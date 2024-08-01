using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Xml;
using CMDL.DAL;

namespace CMDL
{
    public partial class NewClientPage : Form
    {
        ClientModel model;
        cmdldbDataSet cmdl;
        ClientDB db = new ClientDB(Properties.Settings.Default.Server,
                                   Properties.Settings.Default.Database,
                                   Properties.Settings.Default.UserID,
                                   Properties.Settings.Default.Port,
                                   Properties.Settings.Default.Password);



        Reg_PrintDoc print_doc = new Reg_PrintDoc();

        public NewClientPage(ClientModel model, cmdldbDataSet cmdl)
        {
            InitializeComponent();

            this.model = model;
            this.cmdl = cmdl;
            db.Cmdl = cmdl;

            TbLastName.TextChanged += new EventHandler(TbLastName_TextChanged);
            TbFirstName.TextChanged += new EventHandler(TbFirstName_TextChanged);
            TbMI.TextChanged += new EventHandler(TbMI_TextChanged);
            TbSuffix.TextChanged += new EventHandler(TbSuffix_TextChanged);
            TbAddress.TextChanged += new EventHandler(TbAddress_TextChanged);
            TbAge.TextChanged += new EventHandler(TbAge_TextChanged);
            CbSex.SelectionChangeCommitted += new EventHandler(CbSex_SelectionChangeCommitted);
            CbCivilStatus.SelectionChangeCommitted += new EventHandler(CbCivilStatus_SelectionChangeCommitted);
            BirthDate.ValueChanged += new EventHandler(BirthDate_ValueChanged);
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
            BtSaveRecord.Click += new EventHandler(BtSaveRecord_Click);
            BtCopyAddr.Click += new EventHandler(BtCopyAddr_Click);
            BtNewReqParty.Click += new EventHandler(BtNewReqParty_Click);
            BtDelete.Click += new EventHandler(BtDelete_Click);
            CbSex.SelectedIndexChanged += new EventHandler(CbSex_SelectedIndexChanged);
            CbCivilStatus.SelectedIndexChanged += new EventHandler(CbCivilStatus_SelectedIndexChanged);
            CbPurpose.SelectedIndexChanged += new EventHandler(CbPurpose_SelectedIndexChanged);

            bgSave.DoWork += new DoWorkEventHandler(bgSave_DoWork);
            bgSave.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgSave_RunWorkerCompleted);

            this.Load += new EventHandler(NewClientPage_Load);
            this.FormClosed += new FormClosedEventHandler(NewClientPage_FormClosed);

            btDisplayInformation.Click += new EventHandler(btDisplayInformation_Click);
            btList.Click += new EventHandler(btList_Click);

        }

        #region EVENTS
        void btDisplayInformation_Click(object sender, EventArgs e)
        {
            DisplayInformation disp_info = new DisplayInformation(model);

            if (Screen.AllScreens.Length > 1)
            {
                foreach (var s in Screen.AllScreens)
                {
                    if (!s.Primary)
                    {

                        disp_info.Left = s.WorkingArea.X;
                        disp_info.Top = 0;
                        disp_info.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
                        disp_info.Width = s.WorkingArea.Width;
                        disp_info.Height = s.WorkingArea.Height;
                        disp_info.Show();
                    }
                }
            }
            else
            {
                disp_info.Show();
            }
        }

        void NewClientPage_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DataContext())
                {
                    var ds = db.Get("select * from tblpurposes order by purpose asc");

                    CbPurpose.Items.Clear();
                    foreach (DataRow dr in ds.Tables["Table"].Rows)
                    {
                        CbPurpose.Items.Add(dr.Field<string>("purpose"));
                    }
                }
            }
            catch (Exception)
            {

            }

            TbLastName.Focus();
        }

        void NewClientPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearEntries();
        }

        void bgSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BtSaveRecord.Enabled = true;

            if (e.Cancelled)
            {
                MessageBox.Show("Unable to connect to the database!Please contact your database administrator for further assistance!");
            }
            else
            {
                if ((bool)e.Result)
                {
                    MessageBox.Show("CLIENT RECORD SAVED!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Print();
                    if (MessageBox.Show("Would you like to create another record?[Y/N]", "New Client Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClearEntries();
                        TbLastName.Focus();
                    }
                    else
                        this.Close();
                }
                else
                    MessageBox.Show("Unable to save this record!", "Save Record Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void bgSave_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var arg = e.Argument as ClientDB;
                if (arg.Insert())
                    e.Result = true;
                else
                    e.Result = false;
            }
            catch (Exception)
            {
                e.Cancel = true;
            }
        }

        void BtSaveRecord_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (ValidateEntries())
            //    {
            //        var pwdform = new PasswordForm(cmdl.Tables["office_user"]);
            //        if (pwdform.ShowDialog() == DialogResult.OK)
            //        {
            //            string ctrlNo = NewControlNo1();
            //            if (ctrlNo != string.Empty)
            //            {
            //                BtSaveRecord.Enabled = false;
            //                db.controlno = ctrlNo;
            //                db.date = DateTime.Now;
            //                bgSave.RunWorkerAsync(db);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    if (ex.InnerException != null)
            //        MessageBox.Show(ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    else
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            //    BtSaveRecord.Enabled = true;
            //}
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

        void btList_Click(object sender, EventArgs e)
        {
            var listForm = new RequestingPartyListForm();
            if (listForm.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrWhiteSpace(listForm.SelectedRequestingParty))
                {
                    ListOfParties.Items.Add(listForm.SelectedRequestingParty);
                    model.ReqParty = ClientMethod.ParseRequestingParty(ListOfParties.Items);
                    db.reqparty = ClientMethod.ParseRequestingParty(ListOfParties.Items);
                }
            }
        }

        void BtNewReqParty_Click(object sender, EventArgs e)
        {
            var nrpForm = new NewRequestingPartyForm();
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
            var testPage = new TestPage(cmdl, listView1.Items);

            testPage.Total = Convert.ToDouble(LbTotal.Text);
            testPage.AmountPaid = Convert.ToDouble(LbAmountPaid.Text);
            testPage.Balance = Convert.ToDouble(LbBalance.Text);
            testPage.Change = Convert.ToDouble(LbChange.Text);

            if (testPage.ShowDialog() == DialogResult.OK)
            {
                LbTotal.Text = String.Format("{0:0.00}", Convert.ToDouble(testPage.Total));
                LbAmountPaid.Text = String.Format("{0:0.00}", Convert.ToDouble(testPage.AmountPaid));
                LbBalance.Text = String.Format("{0:0.00}", Convert.ToDouble(testPage.Balance));
                LbChange.Text = String.Format("{0:0.00}", Convert.ToDouble(testPage.Change));

                listView1.Items.Clear();
                model.Exam.Clear();
                db.exams.Clear();

                foreach (ListViewItem i in testPage.Items)
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
            var camform = new Camera_Form();
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
        #endregion

        #region METHODS
        string NewControlNo1()
        {

            List<StoredProcedureParameter> paramList = new List<StoredProcedureParameter>();
            paramList.Add(new StoredProcedureParameter(MySqlDbType.DateTime, ParameterDirection.Input, "@dateReg", DateTime.Now));
            paramList.Add(new StoredProcedureParameter(MySqlDbType.VarChar, ParameterDirection.Output, "@lastControlNo", null));
            paramList.Add(new StoredProcedureParameter(MySqlDbType.VarChar, ParameterDirection.Output, "@validDate", null));
            db.StoredProcedure("NewControlNo1", paramList);

            string lastControlNo = Convert.ToString(paramList[1].Value);
            string validDateTime = Convert.ToString(paramList[2].Value);
            string newCtrlNo = string.Empty;

            if ((!String.IsNullOrWhiteSpace(validDateTime) || !String.IsNullOrEmpty(validDateTime)) && validDateTime == "1")
            {
                #region NEW CONTROL NO
                if (!String.IsNullOrWhiteSpace(lastControlNo) || !String.IsNullOrEmpty(lastControlNo))
                {
                    int lastNo = Convert.ToInt32(lastControlNo.Substring(8, 4));
                    newCtrlNo = String.Format("{0:yyyyMMdd}", DateTime.Now) + String.Format("{0:0000}", (lastNo + 1));
                }
                else
                {
                    newCtrlNo = String.Format("{0:yyyyMMdd}", DateTime.Now) + String.Format("{0:0000}", 1);
                }
                #endregion

                #region ADD NEW CONTROL NO TO THE DATABASE
                //temp_regnoTbAdapter.Connection = db.connection;
                //if (temp_regnoTbAdapter.Insert(DateTime.Now, newCtrlNo) == 1)
                //    return newCtrlNo;
                //else
                //    MessageBox.Show("Unable to get a new Control No.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                #endregion
            }
            else
            {
                MessageBox.Show("Invalid Date and Time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;

        }

        string NewControlNo()
        {

            List<StoredProcedureParameter> paramList = new List<StoredProcedureParameter>();
            paramList.Add(new StoredProcedureParameter(MySqlDbType.DateTime, ParameterDirection.Input, "@dateReg", DateTime.Now));
            paramList.Add(new StoredProcedureParameter(MySqlDbType.Int32, ParameterDirection.Output, "@sumTotal", null));
            paramList.Add(new StoredProcedureParameter(MySqlDbType.VarChar, ParameterDirection.Output, "@validDate", null));
            db.StoredProcedure("NewControlNo", paramList);

            if (paramList[2].Value != null)
            {
                if (Convert.ToString(paramList[2].Value) == "1")
                {
                    string ctrlNo = String.Format("{0:yyyyMMdd}", DateTime.Now) + String.Format("{0:0000}", paramList[1].Value);

                    //temp_regnoTbAdapter.Connection = db.connection;
                    //if (temp_regnoTbAdapter.Insert(DateTime.Now, ctrlNo) == 1)
                    //{
                    //    return ctrlNo;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Unable to get a new Control No.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    MessageBox.Show("Invalid Date and Time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Invalid Date and Time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return string.Empty;

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

        void Print()
        {
            print_doc.ControlNo = db.controlno;
            print_doc.Date_Registered = DateTime.Now;
            print_doc.LastName = db.lastname;
            print_doc.FirstName = db.firstname;
            print_doc.MI = db.mi;
            print_doc.Suffix = db.suffix;
            print_doc.Address = db.address;
            print_doc.Age = db.age;
            print_doc.Sex = db.sex;
            print_doc.ReqParty = db.reqparty;
            print_doc.Exam = ClientMethod.ParseTest(db.exams);
            print_doc.Price = ClientMethod.ParsePrice(db.exams);
            print_doc.Total = Convert.ToDouble(db.total);
            print_doc.AmountPaid = Convert.ToDouble(db.paid);
            print_doc.Balance = Convert.ToDouble(db.bal);
            print_doc.Change = Convert.ToDouble(db.change);
            print_doc.Photo = pictureBox1.Image;
            //print_doc.TbSingle = cmdl.Tables["exam"];
            print_doc.Exam_Type = ClientMethod.TestType(db.exams, cmdl);

            Reg_PrintPreview reg_prev = new Reg_PrintPreview(print_doc);
            reg_prev.ShowDialog();
        }

        public void SetClientInfo(DataRow dr)
        {
            try
            {
                DateTime dt;

                //---------------------------------------

                TbLastName.Text = Convert.ToString(dr["lastname"]);
                TbFirstName.Text = Convert.ToString(dr["firstname"]);
                TbMI.Text = Convert.ToString(dr["mi"]);
                TbSuffix.Text = Convert.ToString(dr["suffix"]);
                TbAddress.Text = Convert.ToString(dr["address"]);
                TbAge.Text = Convert.ToString(dr["age"]);
                CbSex.Text = Convert.ToString(dr["sex"]);
                CbCivilStatus.Text = Convert.ToString(dr["civil_status"]);
                TbBirthPlace.Text = Convert.ToString(dr["bplace"]);

                ListOfParties.Items.Clear();
                ListOfParties.Items.Add(Convert.ToString(dr["reqparty"]));
                model.ReqParty = Convert.ToString(dr["reqparty"]);
                db.reqparty = Convert.ToString(dr["reqparty"]);

                CbPurpose.Text = Convert.ToString(dr["purpose"]);
                TbTelNo.Text = Convert.ToString(dr["telno"]);
                TbMobileNo.Text = Convert.ToString(dr["celno"]);
                TbDistrictBranch.Text = Convert.ToString(dr["district_branch"]);

                if (DateTime.TryParse(Convert.ToString(dr["bdate"]), out dt))
                {
                    BirthDate.Value = Convert.ToDateTime(dr["bdate"]);
                    model.BDate = Convert.ToDateTime(dr["bdate"]).ToString("MM-dd-yyyy");
                }
                if (dr["photo"] != DBNull.Value)
                {
                    Image img = Edit.ByteArrayToImage((byte[])dr["photo"]);
                    pictureBox1.Image = Edit.Resize(img, pictureBox1.Size);

                    model.Photo = Edit.BmpSource(pictureBox1.Image);
                    db.photo = Edit.ImageToStream(pictureBox1.Image);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error:{0}", ex.Message), "Import Message", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public bool ValidateEntries()
        {
            DateTime dt = new DateTime();
            int dumpInt = 0;

            if (!String.IsNullOrWhiteSpace(TbLastName.Text))
            {
                if (!String.IsNullOrWhiteSpace(TbFirstName.Text))
                {
                    if (!String.IsNullOrWhiteSpace(TbAddress.Text))
                    {
                        if (int.TryParse(TbAge.Text,out dumpInt))
                        {
                            if (!String.IsNullOrWhiteSpace(CbSex.Text))
                            {
                                if (!String.IsNullOrWhiteSpace(CbCivilStatus.Text))
                                {
                                    if (DateTime.TryParse(BirthDate.Text, out dt))
                                    {
                                        if (!String.IsNullOrWhiteSpace(TbBirthPlace.Text))
                                        {
                                            if (!String.IsNullOrWhiteSpace(ClientMethod.ParseRequestingParty(ListOfParties.Items)))
                                            {
                                                if (!String.IsNullOrWhiteSpace(CbPurpose.Text))
                                                {
                                                    if (!String.IsNullOrWhiteSpace(TbDistrictBranch.Text))
                                                    {
                                                        if (pictureBox1.Image != null)
                                                        {
                                                            if (listView1.Items.Count > 0)
                                                            {
                                                                return true;
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("Test not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                return false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Photo not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("District/Branch not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Purpose Not Specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Requesting Party not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Birth Place not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Birth Date!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Civil Status not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Gender not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Age not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Home Address not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("FirstName not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("LastName not specified!", "Validation Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


        }
        #endregion


    }
}
