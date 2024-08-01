namespace CMDL
{
    partial class TestForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.BtSetToZero = new System.Windows.Forms.Button();
            this.BtSetPrice = new System.Windows.Forms.Button();
            this.BtClearItem = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TbAmountPaid = new System.Windows.Forms.TextBox();
            this.TbTotal = new System.Windows.Forms.TextBox();
            this.LbChange = new System.Windows.Forms.Label();
            this.LbBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TEST AND PACKAGE";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(19, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(516, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(460, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TbAmountPaid);
            this.groupBox2.Controls.Add(this.TbTotal);
            this.groupBox2.Controls.Add(this.LbChange);
            this.groupBox2.Controls.Add(this.LbBalance);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.BtSetToZero);
            this.groupBox2.Controls.Add(this.BtSetPrice);
            this.groupBox2.Controls.Add(this.BtClearItem);
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 353);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TEST DETAILS";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LightYellow;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(19, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(516, 208);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Test";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Price";
            this.columnHeader2.Width = 109;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "(+) New Test";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BtSetToZero
            // 
            this.BtSetToZero.ForeColor = System.Drawing.Color.Black;
            this.BtSetToZero.Location = new System.Drawing.Point(19, 302);
            this.BtSetToZero.Name = "BtSetToZero";
            this.BtSetToZero.Size = new System.Drawing.Size(75, 23);
            this.BtSetToZero.TabIndex = 8;
            this.BtSetToZero.Text = "Set To 0";
            this.BtSetToZero.UseVisualStyleBackColor = true;
            // 
            // BtSetPrice
            // 
            this.BtSetPrice.ForeColor = System.Drawing.Color.Black;
            this.BtSetPrice.Location = new System.Drawing.Point(19, 273);
            this.BtSetPrice.Name = "BtSetPrice";
            this.BtSetPrice.Size = new System.Drawing.Size(75, 23);
            this.BtSetPrice.TabIndex = 7;
            this.BtSetPrice.Text = "Set Price";
            this.BtSetPrice.UseVisualStyleBackColor = true;
            // 
            // BtClearItem
            // 
            this.BtClearItem.ForeColor = System.Drawing.Color.Black;
            this.BtClearItem.Location = new System.Drawing.Point(19, 244);
            this.BtClearItem.Name = "BtClearItem";
            this.BtClearItem.Size = new System.Drawing.Size(75, 23);
            this.BtClearItem.TabIndex = 6;
            this.BtClearItem.Text = "Clear Test";
            this.BtClearItem.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(497, 477);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TbAmountPaid
            // 
            this.TbAmountPaid.BackColor = System.Drawing.Color.LightYellow;
            this.TbAmountPaid.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbAmountPaid.Location = new System.Drawing.Point(456, 269);
            this.TbAmountPaid.MaxLength = 6;
            this.TbAmountPaid.Name = "TbAmountPaid";
            this.TbAmountPaid.Size = new System.Drawing.Size(78, 22);
            this.TbAmountPaid.TabIndex = 30;
            this.TbAmountPaid.Text = "0";
            this.TbAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TbTotal
            // 
            this.TbTotal.BackColor = System.Drawing.Color.LightYellow;
            this.TbTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTotal.Location = new System.Drawing.Point(456, 242);
            this.TbTotal.MaxLength = 6;
            this.TbTotal.Name = "TbTotal";
            this.TbTotal.Size = new System.Drawing.Size(78, 22);
            this.TbTotal.TabIndex = 29;
            this.TbTotal.Text = "0";
            this.TbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LbChange
            // 
            this.LbChange.Location = new System.Drawing.Point(485, 318);
            this.LbChange.Name = "LbChange";
            this.LbChange.Size = new System.Drawing.Size(49, 13);
            this.LbChange.TabIndex = 36;
            this.LbChange.Text = "0";
            this.LbChange.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LbBalance
            // 
            this.LbBalance.Location = new System.Drawing.Point(485, 296);
            this.LbBalance.Name = "LbBalance";
            this.LbBalance.Size = new System.Drawing.Size(49, 13);
            this.LbBalance.TabIndex = 35;
            this.LbBalance.Text = "0";
            this.LbBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(402, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Change:";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(402, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Balance:";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(374, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 32;
            this.label4.Text = "Amount Paid:";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(415, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Total:";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 512);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEST FORM";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtSetToZero;
        private System.Windows.Forms.Button BtSetPrice;
        private System.Windows.Forms.Button BtClearItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox TbAmountPaid;
        private System.Windows.Forms.TextBox TbTotal;
        private System.Windows.Forms.Label LbChange;
        private System.Windows.Forms.Label LbBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}