namespace CMDL
{
    partial class SetPricePage
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
            this.BtOK = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.gbTest = new System.Windows.Forms.GroupBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.gbTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtOK
            // 
            this.BtOK.Location = new System.Drawing.Point(98, 219);
            this.BtOK.Margin = new System.Windows.Forms.Padding(4);
            this.BtOK.Name = "BtOK";
            this.BtOK.Size = new System.Drawing.Size(100, 28);
            this.BtOK.TabIndex = 1;
            this.BtOK.Text = "OK";
            this.BtOK.UseVisualStyleBackColor = true;
            // 
            // BtCancel
            // 
            this.BtCancel.Location = new System.Drawing.Point(206, 219);
            this.BtCancel.Margin = new System.Windows.Forms.Padding(4);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(100, 28);
            this.BtCancel.TabIndex = 2;
            this.BtCancel.Text = "Cancel";
            this.BtCancel.UseVisualStyleBackColor = true;
            // 
            // gbTest
            // 
            this.gbTest.Controls.Add(this.tbPrice);
            this.gbTest.Location = new System.Drawing.Point(12, 27);
            this.gbTest.Name = "gbTest";
            this.gbTest.Size = new System.Drawing.Size(294, 161);
            this.gbTest.TabIndex = 0;
            this.gbTest.TabStop = false;
            this.gbTest.Text = "Test";
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.SystemColors.Info;
            this.tbPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.Location = new System.Drawing.Point(3, 18);
            this.tbPrice.Multiline = true;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(288, 140);
            this.tbPrice.TabIndex = 0;
            this.tbPrice.Text = "0";
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SetPricePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 260);
            this.Controls.Add(this.gbTest);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtOK);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(346, 305);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(346, 305);
            this.Name = "SetPricePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Price";
            this.gbTest.ResumeLayout(false);
            this.gbTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtOK;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.GroupBox gbTest;
        private System.Windows.Forms.TextBox tbPrice;
    }
}