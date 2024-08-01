namespace CMDL.WINFORMS
{
    partial class TestPageForm
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
            this.TbAmountPaid = new System.Windows.Forms.TextBox();
            this.TbTotal = new System.Windows.Forms.TextBox();
            this.BtSetToZero = new System.Windows.Forms.Button();
            this.BtSetPrice = new System.Windows.Forms.Button();
            this.BtClearItem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LbPackagePrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CbPackage = new System.Windows.Forms.ComboBox();
            this.BtPackageAddItem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtSingleAddItem = new System.Windows.Forms.Button();
            this.BtSingleNewItem = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.BtOK = new System.Windows.Forms.Button();
            this.labelBalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbAmountPaid
            // 
            this.TbAmountPaid.BackColor = System.Drawing.Color.LightYellow;
            this.TbAmountPaid.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbAmountPaid.Location = new System.Drawing.Point(532, 356);
            this.TbAmountPaid.MaxLength = 15;
            this.TbAmountPaid.Multiline = true;
            this.TbAmountPaid.Name = "TbAmountPaid";
            this.TbAmountPaid.Size = new System.Drawing.Size(215, 41);
            this.TbAmountPaid.TabIndex = 36;
            this.TbAmountPaid.Text = "0";
            this.TbAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TbTotal
            // 
            this.TbTotal.BackColor = System.Drawing.Color.LightYellow;
            this.TbTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTotal.Location = new System.Drawing.Point(534, 310);
            this.TbTotal.MaxLength = 15;
            this.TbTotal.Multiline = true;
            this.TbTotal.Name = "TbTotal";
            this.TbTotal.Size = new System.Drawing.Size(215, 40);
            this.TbTotal.TabIndex = 35;
            this.TbTotal.Text = "0";
            this.TbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtSetToZero
            // 
            this.BtSetToZero.ForeColor = System.Drawing.Color.Black;
            this.BtSetToZero.Location = new System.Drawing.Point(753, 83);
            this.BtSetToZero.Name = "BtSetToZero";
            this.BtSetToZero.Size = new System.Drawing.Size(75, 23);
            this.BtSetToZero.TabIndex = 34;
            this.BtSetToZero.Text = "Set To 0";
            this.BtSetToZero.UseVisualStyleBackColor = true;
            // 
            // BtSetPrice
            // 
            this.BtSetPrice.ForeColor = System.Drawing.Color.Black;
            this.BtSetPrice.Location = new System.Drawing.Point(753, 54);
            this.BtSetPrice.Name = "BtSetPrice";
            this.BtSetPrice.Size = new System.Drawing.Size(75, 23);
            this.BtSetPrice.TabIndex = 33;
            this.BtSetPrice.Text = "Set Price";
            this.BtSetPrice.UseVisualStyleBackColor = true;
            // 
            // BtClearItem
            // 
            this.BtClearItem.ForeColor = System.Drawing.Color.Black;
            this.BtClearItem.Location = new System.Drawing.Point(753, 25);
            this.BtClearItem.Name = "BtClearItem";
            this.BtClearItem.Size = new System.Drawing.Size(75, 23);
            this.BtClearItem.TabIndex = 32;
            this.BtClearItem.Text = "Clear Test";
            this.BtClearItem.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LbPackagePrice);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CbPackage);
            this.groupBox2.Controls.Add(this.BtPackageAddItem);
            this.groupBox2.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox2.Location = new System.Drawing.Point(6, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 85);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PACKAGE";
            // 
            // LbPackagePrice
            // 
            this.LbPackagePrice.AutoSize = true;
            this.LbPackagePrice.ForeColor = System.Drawing.Color.Black;
            this.LbPackagePrice.Location = new System.Drawing.Point(46, 54);
            this.LbPackagePrice.Name = "LbPackagePrice";
            this.LbPackagePrice.Size = new System.Drawing.Size(26, 17);
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
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Price:";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // CbPackage
            // 
            this.CbPackage.BackColor = System.Drawing.Color.LightYellow;
            this.CbPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPackage.FormattingEnabled = true;
            this.CbPackage.Location = new System.Drawing.Point(6, 22);
            this.CbPackage.Name = "CbPackage";
            this.CbPackage.Size = new System.Drawing.Size(335, 21);
            this.CbPackage.TabIndex = 0;
            // 
            // BtPackageAddItem
            // 
            this.BtPackageAddItem.ForeColor = System.Drawing.Color.Black;
            this.BtPackageAddItem.Location = new System.Drawing.Point(266, 49);
            this.BtPackageAddItem.Name = "BtPackageAddItem";
            this.BtPackageAddItem.Size = new System.Drawing.Size(75, 23);
            this.BtPackageAddItem.TabIndex = 1;
            this.BtPackageAddItem.Text = "Add";
            this.BtPackageAddItem.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.BtSingleAddItem);
            this.groupBox1.Controls.Add(this.BtSingleNewItem);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox1.Location = new System.Drawing.Point(6, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 96);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INDIVIDUAL";
            // 
            // BtSingleAddItem
            // 
            this.BtSingleAddItem.ForeColor = System.Drawing.Color.Black;
            this.BtSingleAddItem.Location = new System.Drawing.Point(266, 46);
            this.BtSingleAddItem.Name = "BtSingleAddItem";
            this.BtSingleAddItem.Size = new System.Drawing.Size(75, 23);
            this.BtSingleAddItem.TabIndex = 2;
            this.BtSingleAddItem.Text = "Add";
            this.BtSingleAddItem.UseVisualStyleBackColor = true;
            // 
            // BtSingleNewItem
            // 
            this.BtSingleNewItem.ForeColor = System.Drawing.Color.Black;
            this.BtSingleNewItem.Location = new System.Drawing.Point(6, 46);
            this.BtSingleNewItem.Name = "BtSingleNewItem";
            this.BtSingleNewItem.Size = new System.Drawing.Size(75, 23);
            this.BtSingleNewItem.TabIndex = 1;
            this.BtSingleNewItem.Text = "New";
            this.BtSingleNewItem.UseVisualStyleBackColor = true;
            // 
            // BtCancel
            // 
            this.BtCancel.ForeColor = System.Drawing.Color.Black;
            this.BtCancel.Location = new System.Drawing.Point(666, 479);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(81, 23);
            this.BtCancel.TabIndex = 39;
            this.BtCancel.Text = "Cancel";
            this.BtCancel.UseVisualStyleBackColor = true;
            // 
            // BtOK
            // 
            this.BtOK.ForeColor = System.Drawing.Color.Black;
            this.BtOK.Location = new System.Drawing.Point(666, 450);
            this.BtOK.Name = "BtOK";
            this.BtOK.Size = new System.Drawing.Size(81, 23);
            this.BtOK.TabIndex = 37;
            this.BtOK.Text = "OK";
            this.BtOK.UseVisualStyleBackColor = true;
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBalance.Location = new System.Drawing.Point(365, 406);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(105, 34);
            this.labelBalance.TabIndex = 41;
            this.labelBalance.Text = "Balance:";
            this.labelBalance.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(365, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 34);
            this.label4.TabIndex = 40;
            this.label4.Text = "Amount Paid:";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(365, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 34);
            this.label3.TabIndex = 38;
            this.label3.Text = "Total:";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LightYellow;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(365, 25);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(382, 278);
            this.listView1.TabIndex = 31;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Test";
            this.columnHeader1.Width = 305;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Price";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LightYellow;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(532, 403);
            this.textBox1.MaxLength = 15;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(215, 41);
            this.textBox1.TabIndex = 42;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.LightYellow;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(335, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(46, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "0.00";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Price:";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // TestPageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 518);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TbAmountPaid);
            this.Controls.Add(this.TbTotal);
            this.Controls.Add(this.BtSetToZero);
            this.Controls.Add(this.BtSetPrice);
            this.Controls.Add(this.BtClearItem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtOK);
            this.Controls.Add(this.labelBalance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Name = "TestPageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEST";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbAmountPaid;
        private System.Windows.Forms.TextBox TbTotal;
        private System.Windows.Forms.Button BtSetToZero;
        private System.Windows.Forms.Button BtSetPrice;
        private System.Windows.Forms.Button BtClearItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LbPackagePrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbPackage;
        private System.Windows.Forms.Button BtPackageAddItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtSingleAddItem;
        private System.Windows.Forms.Button BtSingleNewItem;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.Button BtOK;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}