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

namespace CMDL.WINFORMS
{
    public partial class ExamForm : Form
    {
        Dictionary<string, string> tableRefList = new Dictionary<string, string>();
        cmdldbDataSet ds;

        public ExamForm(cmdldbDataSet ds)
        {
            InitializeComponent();

            this.ds = ds;
            btAdd.Click += new EventHandler(btAdd_Click);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Load += new EventHandler(ExamForm_Load);


            tableRefList.Add("XRAY","xray");
            tableRefList.Add("NEURO","neuro");
            tableRefList.Add("CBC","cbc");
            tableRefList.Add("URINALYSIS","urinalysis");
            tableRefList.Add("STOOL EXAM","stool");
            tableRefList.Add("PREGNANCY TEST","preg_test");
            tableRefList.Add("BLOOD TYPING","blood_typing");
            tableRefList.Add("GRAM STAINING","grams_staining");
            tableRefList.Add("SEROLOGY","serology");
            tableRefList.Add("CULTURE AND SENSITIVITY","cultureandsensitivity");
            tableRefList.Add("BLOOD CHEMISTRY","bloodchemistry");
            tableRefList.Add("PAP SMEAR","papsmear");
            tableRefList.Add("PHYSICAL EXAMINATION","pe");

            foreach (var tb in tableRefList)
                cbClassification.Items.Add(tb);

            cbClassification.DisplayMember = "Key";
        }

        void ExamForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = new CyberContext())
                {
                    var examList = db.exams.OrderBy(p => p.type).ThenBy(p => p.test).ToList();
                    dgList.DataSource = examList;
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

        void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgList.SelectedRows)
                {
                    using (var db = new CyberContext())
                    {
                        var item = row.DataBoundItem as exam;

                        var exam = db.exams.Where(p => p.test == item.test).FirstOrDefault();
                        if (exam != null)
                        {
                            db.exams.DeleteObject(exam);

                            if (db.SaveChanges() == 1)
                            {
                                var examList = db.exams.OrderBy(p => p.type).ThenBy(p => p.test).ToList();
                                dgList.DataSource = examList;

                                MessageBox.Show("Record has been deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Unable to delete this record!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            MessageBox.Show("Unable to delete because this record doesn't exist in the database!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
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

        void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new CyberContext())
                {
                    if (ValidateEntries())
                    {
                        var exam = new exam();
                        exam.type = cbCategory.Text;
                        exam.test = tbTest.Text;
                        exam.price = Convert.ToDouble(tbPrice.Text);
                        exam.marker = tbMarker.Text;
                        exam.tablename = tableRefList[cbClassification.Text];

                        db.exams.AddObject(exam);

                        if (db.SaveChanges() == 1)
                        {
                            var examList = db.exams.OrderBy(p => p.type).ThenBy(p => p.test).ToList();
                            dgList.DataSource = examList;

                            var row = ds.Tables["exam"].NewRow();
                            row[0] = cbCategory.Text;
                            row[1] = tbTest.Text;
                            row[2] = Convert.ToDouble(tbPrice.Text);
                            row[3] = tbMarker.Text;
                            row[4] = tableRefList[cbClassification.Text];

                            ds.Tables["exam"].Rows.Add(row);

                            cbCategory.Text = null;
                            tbTest.Clear();
                            tbPrice.Clear();
                            tbMarker.Clear();
                            cbClassification.Text = null;

                            MessageBox.Show("Record saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        else
                            MessageBox.Show("Unable to save this record!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        bool ValidateEntries()
        {
            if (!String.IsNullOrEmpty(cbCategory.Text))
            {
                if (!String.IsNullOrEmpty(tbTest.Text))
                {
                    double doubleDump = 0;
                    
                    if (double.TryParse(tbPrice.Text,out doubleDump))
                    {
                        if (!String.IsNullOrEmpty(cbClassification.Text))
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Classification not specified!", "Validate Entries", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Price not specified!", "Validate Entries", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("Test not specified!", "Validate Entries", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Category not specified!","Validate Entries",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }

            return false;
        }
    }
}
