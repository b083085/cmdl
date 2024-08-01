namespace CMDL
{
    partial class SettingsPage
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TbPassword = new System.Windows.Forms.TextBox();
            this.TbPort = new System.Windows.Forms.TextBox();
            this.TbUserID = new System.Windows.Forms.TextBox();
            this.TbDatabase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TbServer = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btUser = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.58491F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.41509F));
            this.tableLayoutPanel1.Controls.Add(this.TbPassword, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.TbPort, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.TbUserID, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TbDatabase, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.TbServer, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(265, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TbPassword
            // 
            this.TbPassword.BackColor = System.Drawing.Color.LightYellow;
            this.TbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbPassword.Location = new System.Drawing.Point(92, 99);
            this.TbPassword.Name = "TbPassword";
            this.TbPassword.PasswordChar = 'X';
            this.TbPassword.Size = new System.Drawing.Size(170, 22);
            this.TbPassword.TabIndex = 9;
            // 
            // TbPort
            // 
            this.TbPort.BackColor = System.Drawing.Color.LightYellow;
            this.TbPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbPort.Location = new System.Drawing.Point(92, 75);
            this.TbPort.Name = "TbPort";
            this.TbPort.Size = new System.Drawing.Size(170, 22);
            this.TbPort.TabIndex = 8;
            // 
            // TbUserID
            // 
            this.TbUserID.BackColor = System.Drawing.Color.LightYellow;
            this.TbUserID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbUserID.Location = new System.Drawing.Point(92, 51);
            this.TbUserID.Name = "TbUserID";
            this.TbUserID.Size = new System.Drawing.Size(170, 22);
            this.TbUserID.TabIndex = 7;
            // 
            // TbDatabase
            // 
            this.TbDatabase.BackColor = System.Drawing.Color.LightYellow;
            this.TbDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbDatabase.Location = new System.Drawing.Point(92, 27);
            this.TbDatabase.Name = "TbDatabase";
            this.TbDatabase.Size = new System.Drawing.Size(170, 22);
            this.TbDatabase.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 101);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "User ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port:";
            // 
            // TbServer
            // 
            this.TbServer.BackColor = System.Drawing.Color.LightYellow;
            this.TbServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbServer.Location = new System.Drawing.Point(92, 3);
            this.TbServer.Name = "TbServer";
            this.TbServer.Size = new System.Drawing.Size(170, 22);
            this.TbServer.TabIndex = 5;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "REGISTRATION",
            "XRAY",
            "NEURO",
            "LABORATORY",
            "UPDATE",
            "SETTINGS",
            "REPORTS",
            "ABOUT"});
            this.checkedListBox1.Location = new System.Drawing.Point(18, 198);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(289, 123);
            this.checkedListBox1.TabIndex = 1;
            // 
            // BtUpdate
            // 
            this.BtUpdate.ForeColor = System.Drawing.Color.Blue;
            this.BtUpdate.Location = new System.Drawing.Point(232, 328);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtUpdate.TabIndex = 2;
            this.BtUpdate.Text = "Update";
            this.BtUpdate.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(314, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "*Check which Menu Items should be remove from this application";
            // 
            // btUser
            // 
            this.btUser.ForeColor = System.Drawing.Color.Blue;
            this.btUser.Location = new System.Drawing.Point(18, 328);
            this.btUser.Name = "btUser";
            this.btUser.Size = new System.Drawing.Size(75, 23);
            this.btUser.TabIndex = 4;
            this.btUser.Text = "Users";
            this.btUser.UseVisualStyleBackColor = true;
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 362);
            this.Controls.Add(this.btUser);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(340, 400);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(340, 400);
            this.Name = "SettingsPage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SETTINGS";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TbPassword;
        private System.Windows.Forms.TextBox TbPort;
        private System.Windows.Forms.TextBox TbUserID;
        private System.Windows.Forms.TextBox TbDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TbServer;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button BtUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btUser;
    }
}