using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMDL.WINFORMS;
using CMDL.DAL;

namespace CMDL
{
    public partial class TestPage : Form
    {
        cmdldbDataSet cmdl;

        public TestPage(cmdldbDataSet cmdl, ListView.ListViewItemCollection items)
        {
            InitializeComponent();

            this.cmdl = cmdl;

            SetPatientTestItems(items);
            SetComboBoxItems(cmdl);

            BtClearItem.Click += new EventHandler(BtClearItem_Click);
            BtSetPrice.Click += new EventHandler(BtSetPrice_Click);
            BtSetToZero.Click += new EventHandler(BtSetToZero_Click);
            BtPackageAdd.Click += new EventHandler(BtPackageAdd_Click);
            btNewItem.Click += new EventHandler(btNewItem_Click);
            BtOK.Click += new EventHandler(BtOK_Click);
            BtCancel.Click += new EventHandler(BtCancel_Click);
            btExaminationAdd.Click += new EventHandler(btExaminationAdd_Click);

            TbTotal.TextChanged += new EventHandler(TbTotal_TextChanged);
            TbAmountPaid.TextChanged += new EventHandler(TbAmountPaid_TextChanged);
            cbExaminations.KeyDown += new KeyEventHandler(cbExaminations_KeyDown);
            CbPackage.KeyDown += new KeyEventHandler(CbPackage_KeyDown);
            LbBalance.TextChanged += new EventHandler(LbBalance_TextChanged);
            LbChange.TextChanged += new EventHandler(LbChange_TextChanged);
            this.Load += new EventHandler(TestPage_Load);

            cbExaminations.SelectedValueChanged += new EventHandler(cbExaminations_SelectedValueChanged);
            CbPackage.SelectedValueChanged += new EventHandler(CbPackage_SelectedValueChanged);
        }



        #region EVENTS
        void CbPackage_SelectedValueChanged(object sender, EventArgs e)
        {
            var item = cbExaminations.SelectedItem as DataRow;

            if (item != null)
            {
                LbPackagePrice.Text = Convert.ToString(item["price"]);
            }
        }

        void cbExaminations_SelectedValueChanged(object sender, EventArgs e)
        {
            var item = cbExaminations.SelectedItem as DataRow;

            if (item != null)
            {
                lbExaminationPrice.Text = Convert.ToString(item["price"]);
            }
        }

        void TestPage_Load(object sender, EventArgs e)
        {
            var width1 = Convert.ToInt32(listView1.Width * .80);
            var width2 = Convert.ToInt32(listView1.Width * .20);

            listView1.Columns[0].Width = width1;
            listView1.Columns[1].Width = width2;
        }

        void LbChange_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(LbChange.Text) == 0)
                LbChange.ForeColor = Color.Black;
            else
                LbChange.ForeColor = Color.Red;
        }

        void LbBalance_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDouble(LbBalance.Text) == 0)
                LbBalance.ForeColor = Color.Black;
            else
                LbBalance.ForeColor = Color.Red;
        }

        void btNewItem_Click(object sender, EventArgs e)
        {
            var examForm = new ExamForm(cmdl);
            if (examForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cbExaminations.Items.Clear();
                foreach (var row in cmdl.Tables["exam"].Rows)
                    cbExaminations.Items.Add(row);
            }
        }

        void BtPackageAdd_Click(object sender, EventArgs e)
        {
            AddPackage();
        }

        void CbPackage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddPackage();
            }
        }

        void btExaminationAdd_Click(object sender, EventArgs e)
        {
            AddExamination();
        }

        void cbExaminations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddExamination();
            }
        }

        void BtCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void BtOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;   
        }

        void TbAmountPaid_TextChanged(object sender, EventArgs e)
        {
            SubtractTotal();
        }

        void TbTotal_TextChanged(object sender, EventArgs e)
        {
            SubtractTotal();
        }

        void BtSetToZero_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in listView1.SelectedItems)
                i.SubItems[1].Text = "0.00";
        }

        void BtSetPrice_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                SetPricePage spage = new SetPricePage(item.Text,item.SubItems[1].Text);
                if (spage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    double oldPrice = Convert.ToDouble(item.SubItems[1].Text);
                    double newPrice = Convert.ToDouble(spage.Price);

                    item.SubItems[1].Text = string.Format("{0:0.00}",newPrice);

                    TbTotal.Text = Convert.ToString(Convert.ToDouble(TbTotal.Text) - oldPrice);
                    TbTotal.Text = Convert.ToString(Convert.ToDouble(TbTotal.Text) + newPrice);
                }
            }

           
        }

        void BtClearItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                foreach (ListViewItem i in listView1.SelectedItems)
                {
                    TbTotal.Text = Convert.ToString(Convert.ToDouble(TbTotal.Text) - Convert.ToDouble(i.SubItems[1].Text));
                    listView1.Items.Remove(i);
                }
            }
            else
            {
                listView1.Items.Clear();
                TbTotal.Text = "0";
                TbAmountPaid.Text = "0";
            }
        }
        #endregion

        #region SETTERS AND GETTERS
        public ListView.ListViewItemCollection Items
        {
            get 
            {
                return listView1.Items;
            }
        }

        public object Total
        {
            get
            {
                return TbTotal.Text;
            }
            set
            {
                TbTotal.Text = Convert.ToString(value);
            }
        }

        public object AmountPaid
        {
            get
            {
                return TbAmountPaid.Text;
            }
            set
            {
                TbAmountPaid.Text = Convert.ToString(value);
            }
        }

        public object Balance
        {
            get
            {
                return LbBalance.Text;
            }
            set
            {
                LbBalance.Text = Convert.ToString(value);
            }
        }

        public object Change
        {
            get
            {
                return LbChange.Text;
            }
            set
            {
                LbChange.Text = Convert.ToString(value);
            }
        }
        #endregion

        #region METHODS
        private void SetPatientTestItems(ListView.ListViewItemCollection items)
        {
            foreach (ListViewItem i in items)
            {
                var item = new ListViewItem();
                item.Text = i.Text;
                item.SubItems.Add(i.SubItems[1].Text);
                listView1.Items.Add(item);
            }
        }

        private void SetComboBoxItems(cmdldbDataSet cmdl)
        {
            #region PACKAGE
            foreach (DataRow row in cmdl.Tables["package"].Rows)
                CbPackage.Items.Add(row);

            CbPackage.DisplayMember = "pack_name";
            //CbPackage.ValueMember = "ItemArray[2]";
            //LbPackagePrice.DataBindings.Add("Text", cmdl.Tables["package"], "price");
            #endregion

            #region EXAMINATIONS
            foreach (DataRow row in cmdl.Tables["exam"].Rows)
                cbExaminations.Items.Add(row);

            cbExaminations.DisplayMember = "test";
            //cbExaminations.ValueMember = "price";
            //lbExaminationPrice.DataBindings.Add("Text", cbExaminations, "SelectedValue");
            #endregion
        }

        private void AddExamination()
        {
            var item = cbExaminations.SelectedItem as DataRow;
            if (item != null)
            {
                if (TestExist(Convert.ToString(item["test"])))
                {
                    AddListViewItem(Convert.ToString(item["test"]), Convert.ToString(item["price"]));
                    TbTotal.Text = Convert.ToString(Convert.ToDouble(TbTotal.Text) + Convert.ToDouble(item["price"]));
                    cbExaminations.Text = null;
                }
                else
                {
                    MessageBox.Show(Convert.ToString(item["test"]) + " is already in the list!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void AddPackage()
        {
            var item = CbPackage.SelectedItem as DataRow;
            if (item != null)
            {
                var testList = Convert.ToString(item["items"]).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var test in testList)
                {
                    if (TestExist(test))
                    {
                        AddListViewItem(test, "0.00");
                    }
                    else
                    {
                        MessageBox.Show(test + " is already in the list!", "Add", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }

                TbTotal.Text = Convert.ToString(Convert.ToDouble(TbTotal.Text) + Convert.ToDouble(item["price"]));
                CbPackage.Text = null;

            }
        }

        private void AddListViewItem(string test, string price)
        {
            ListViewItem item = new ListViewItem();
            item.Text = test;
            item.SubItems.Add(string.Format("{0:0.00}", Convert.ToDouble(price)));
            listView1.Items.Add(item);
        }

        private void SubtractTotal()
        {
            try
            {
                var diff = Convert.ToDouble(TbAmountPaid.Text) - Convert.ToDouble(TbTotal.Text);
                if (diff < 0)
                {
                    LbBalance.Text = Convert.ToString(Math.Abs(diff));
                    LbChange.Text = "0";
                }
                else
                {
                    LbChange.Text = Convert.ToString(diff);
                    LbBalance.Text = "0";
                }
            }
            catch (Exception)
            {
                //none
            }
        }

        private bool TestExist(string test)
        {
            foreach (ListViewItem i in listView1.Items)
            {
                if (i.Text == test)
                    return false;
            }

            return true;
        }
        #endregion






    }
}
