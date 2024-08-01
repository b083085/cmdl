namespace CMDL
{
    partial class TestPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CbPackage = new System.Windows.Forms.ComboBox();
            this.btExaminationAdd = new System.Windows.Forms.Button();
            this.btNewItem = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtPackageAdd = new System.Windows.Forms.Button();
            this.BtOK = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LbPackagePrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtClearItem = new System.Windows.Forms.Button();
            this.BtSetPrice = new System.Windows.Forms.Button();
            this.BtSetToZero = new System.Windows.Forms.Button();
            this.LbBalance = new System.Windows.Forms.Label();
            this.LbChange = new System.Windows.Forms.Label();
            this.TbTotal = new System.Windows.Forms.TextBox();
            this.TbAmountPaid = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbExaminationPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbExaminations = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // CbPackage
            // 
            this.CbPackage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CbPackage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CbPackage.BackColor = System.Drawing.Color.LightYellow;
            this.CbPackage.FormattingEnabled = true;
            this.CbPackage.Location = new System.Drawing.Point(6, 22);
            this.CbPackage.Name = "CbPackage";
            this.CbPackage.Size = new System.Drawing.Size(335, 21);
            this.CbPackage.TabIndex = 0;
            // 
            // btExaminationAdd
            // 
            this.btExaminationAdd.ForeColor = System.Drawing.Color.Black;
            this.btExaminationAdd.Location = new System.Drawing.Point(247, 55);
            this.btExaminationAdd.Name = "btExaminationAdd";
            this.btExaminationAdd.Size = new System.Drawing.Size(75, 23);
            this.btExaminationAdd.TabIndex = 1;
            this.btExaminationAdd.Text = "Add";
            this.btExaminationAdd.UseVisualStyleBackColor = true;
            // 
            // btNewItem
            // 
            this.btNewItem.ForeColor = System.Drawing.Color.Black;
            this.btNewItem.Location = new System.Drawing.Point(166, 55);
            this.btNewItem.Name = "btNewItem";
            this.btNewItem.Size = new System.Drawing.Size(75, 23);
            this.btNewItem.TabIndex = 2;
            this.btNewItem.Text = "New";
            this.btNewItem.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LightYellow;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 121);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(694, 278);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Test";
            this.columnHeader1.Width = 231;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Price";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtPackageAdd
            // 
            this.BtPackageAdd.ForeColor = System.Drawing.Color.Black;
            this.BtPackageAdd.Location = new System.Drawing.Point(266, 49);
            this.BtPackageAdd.Name = "BtPackageAdd";
            this.BtPackageAdd.Size = new System.Drawing.Size(75, 23);
            this.BtPackageAdd.TabIndex = 1;
            this.BtPackageAdd.Text = "Add";
            this.BtPackageAdd.UseVisualStyleBackColor = true;
            // 
            // BtOK
            // 
            this.BtOK.ForeColor = System.Drawing.Color.Black;
            this.BtOK.Location = new System.Drawing.Point(536, 512);
            this.BtOK.Name = "BtOK";
            this.BtOK.Size = new System.Drawing.Size(81, 23);
            this.BtOK.TabIndex = 8;
            this.BtOK.Text = "OK";
            this.BtOK.UseVisualStyleBackColor = true;
            // 
            // BtCancel
            // 
            this.BtCancel.ForeColor = System.Drawing.Color.Black;
            this.BtCancel.Location = new System.Drawing.Point(625, 512);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(81, 23);
            this.BtCancel.TabIndex = 9;
            this.BtCancel.Text = "Cancel";
            this.BtCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LbPackagePrice);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CbPackage);
            this.groupBox2.Controls.Add(this.BtPackageAdd);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox2.Location = new System.Drawing.Point(359, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 85);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PACKAGE";
            // 
            // LbPackagePrice
            // 
            this.LbPackagePrice.AutoSize = true;
            this.LbPackagePrice.ForeColor = System.Drawing.Color.Black;
            this.LbPackagePrice.Location = new System.Drawing.Point(46, 54);
            this.LbPackagePrice.Name = "LbPackagePrice";
            this.LbPackagePrice.Size = new System.Drawing.Size(26, 20);
            this.LbPackagePrice.TabIndex = 9;
            this.LbPackagePrice.Text = "0.00";
            this.LbPackagePrice.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Price:";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // BtClearItem
            // 
            this.BtClearItem.ForeColor = System.Drawing.Color.Black;
            this.BtClearItem.Location = new System.Drawing.Point(12, 405);
            this.BtClearItem.Name = "BtClearItem";
            this.BtClearItem.Size = new System.Drawing.Size(75, 23);
            this.BtClearItem.TabIndex = 3;
            this.BtClearItem.Text = "Clear Test";
            this.BtClearItem.UseVisualStyleBackColor = true;
            // 
            // BtSetPrice
            // 
            this.BtSetPrice.ForeColor = System.Drawing.Color.Black;
            this.BtSetPrice.Location = new System.Drawing.Point(12, 434);
            this.BtSetPrice.Name = "BtSetPrice";
            this.BtSetPrice.Size = new System.Drawing.Size(75, 23);
            this.BtSetPrice.TabIndex = 4;
            this.BtSetPrice.Text = "Set Price";
            this.BtSetPrice.UseVisualStyleBackColor = true;
            // 
            // BtSetToZero
            // 
            this.BtSetToZero.ForeColor = System.Drawing.Color.Black;
            this.BtSetToZero.Location = new System.Drawing.Point(12, 463);
            this.BtSetToZero.Name = "BtSetToZero";
            this.BtSetToZero.Size = new System.Drawing.Size(75, 23);
            this.BtSetToZero.TabIndex = 5;
            this.BtSetToZero.Text = "Set To 0";
            this.BtSetToZero.UseVisualStyleBackColor = true;
            // 
            // LbBalance
            // 
            this.LbBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbBalance.Location = new System.Drawing.Point(3, 18);
            this.LbBalance.Name = "LbBalance";
            this.LbBalance.Size = new System.Drawing.Size(118, 66);
            this.LbBalance.TabIndex = 27;
            this.LbBalance.Text = "0";
            this.LbBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbChange
            // 
            this.LbChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbChange.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbChange.Location = new System.Drawing.Point(3, 18);
            this.LbChange.Name = "LbChange";
            this.LbChange.Size = new System.Drawing.Size(118, 66);
            this.LbChange.TabIndex = 28;
            this.LbChange.Text = "0";
            this.LbChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbTotal
            // 
            this.TbTotal.BackColor = System.Drawing.Color.LightYellow;
            this.TbTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbTotal.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTotal.Location = new System.Drawing.Point(3, 18);
            this.TbTotal.MaxLength = 6;
            this.TbTotal.Multiline = true;
            this.TbTotal.Name = "TbTotal";
            this.TbTotal.Size = new System.Drawing.Size(118, 66);
            this.TbTotal.TabIndex = 0;
            this.TbTotal.Text = "0";
            this.TbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TbAmountPaid
            // 
            this.TbAmountPaid.BackColor = System.Drawing.Color.LightYellow;
            this.TbAmountPaid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbAmountPaid.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbAmountPaid.Location = new System.Drawing.Point(3, 18);
            this.TbAmountPaid.MaxLength = 6;
            this.TbAmountPaid.Multiline = true;
            this.TbAmountPaid.Name = "TbAmountPaid";
            this.TbAmountPaid.Size = new System.Drawing.Size(118, 66);
            this.TbAmountPaid.TabIndex = 0;
            this.TbAmountPaid.Text = "0";
            this.TbAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbExaminationPrice);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cbExaminations);
            this.groupBox3.Controls.Add(this.btNewItem);
            this.groupBox3.Controls.Add(this.btExaminationAdd);
            this.groupBox3.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox3.Location = new System.Drawing.Point(12, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 85);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "EXAMINATIONS";
            // 
            // lbExaminationPrice
            // 
            this.lbExaminationPrice.AutoSize = true;
            this.lbExaminationPrice.ForeColor = System.Drawing.Color.Black;
            this.lbExaminationPrice.Location = new System.Drawing.Point(59, 54);
            this.lbExaminationPrice.Name = "lbExaminationPrice";
            this.lbExaminationPrice.Size = new System.Drawing.Size(26, 20);
            this.lbExaminationPrice.TabIndex = 11;
            this.lbExaminationPrice.Text = "0.00";
            this.lbExaminationPrice.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Price:";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // cbExaminations
            // 
            this.cbExaminations.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbExaminations.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbExaminations.BackColor = System.Drawing.Color.LightYellow;
            this.cbExaminations.FormattingEnabled = true;
            this.cbExaminations.Location = new System.Drawing.Point(16, 22);
            this.cbExaminations.Name = "cbExaminations";
            this.cbExaminations.Size = new System.Drawing.Size(306, 21);
            this.cbExaminations.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TbTotal);
            this.groupBox1.Location = new System.Drawing.Point(187, 407);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 87);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TbAmountPaid);
            this.groupBox4.Location = new System.Drawing.Point(317, 407);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(124, 87);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Amount Paid";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LbBalance);
            this.groupBox5.Location = new System.Drawing.Point(447, 407);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(124, 87);
            this.groupBox5.TabIndex = 32;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Balance";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LbChange);
            this.groupBox6.Location = new System.Drawing.Point(574, 407);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(124, 87);
            this.groupBox6.TabIndex = 33;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Change";
            // 
            // TestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 547);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.BtSetToZero);
            this.Controls.Add(this.BtSetPrice);
            this.Controls.Add(this.BtClearItem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtOK);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(740, 585);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(740, 585);
            this.Name = "TestPage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEST";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbPackage;
        private System.Windows.Forms.Button btExaminationAdd;
        private System.Windows.Forms.Button btNewItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button BtPackageAdd;
        private System.Windows.Forms.Button BtOK;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LbPackagePrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtClearItem;
        private System.Windows.Forms.Button BtSetPrice;
        private System.Windows.Forms.Button BtSetToZero;
        private System.Windows.Forms.Label LbBalance;
        private System.Windows.Forms.Label LbChange;
        private System.Windows.Forms.TextBox TbTotal;
        private System.Windows.Forms.TextBox TbAmountPaid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbExaminations;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbExaminationPrice;
        private System.Windows.Forms.Label label3;
    }
}