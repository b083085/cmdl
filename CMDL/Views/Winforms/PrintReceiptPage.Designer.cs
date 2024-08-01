namespace CMDL
{
    partial class PrintReceiptPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintReceiptPage));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbControlNo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbLastName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbfname = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbFirstName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LbMI = new System.Windows.Forms.ToolStripStatusLabel();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CbFilter = new System.Windows.Forms.ToolStripComboBox();
            this.TbKeyword = new System.Windows.Forms.ToolStripTextBox();
            this.BtSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.LbNoOfResults = new System.Windows.Forms.ToolStripLabel();
            this.LbRecordCounter = new System.Windows.Forms.ToolStripLabel();
            this.BtFirstRec = new System.Windows.Forms.ToolStripButton();
            this.BtPrevious = new System.Windows.Forms.ToolStripButton();
            this.BtNextRec = new System.Windows.Forms.ToolStripButton();
            this.BtLastRec = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.BtPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtMagnifier = new System.Windows.Forms.ToolStripSplitButton();
            this.Mag100Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Mag150Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Mag200Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Mag250Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Mag300Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Mag350Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Mag400Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Mag450Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Mag500Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.ActualSizeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.bgSearch = new System.ComponentModel.BackgroundWorker();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.printPreviewControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(784, 490);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(784, 562);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.LbControlNo,
            this.toolStripStatusLabel2,
            this.LbLastName,
            this.lbfname,
            this.LbFirstName,
            this.toolStripStatusLabel4,
            this.LbMI});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabel1.Text = "Control No.";
            // 
            // LbControlNo
            // 
            this.LbControlNo.AutoSize = false;
            this.LbControlNo.ForeColor = System.Drawing.Color.Red;
            this.LbControlNo.Name = "LbControlNo";
            this.LbControlNo.Size = new System.Drawing.Size(118, 17);
            this.LbControlNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabel2.Text = "Last Name:";
            // 
            // LbLastName
            // 
            this.LbLastName.AutoSize = false;
            this.LbLastName.Name = "LbLastName";
            this.LbLastName.Size = new System.Drawing.Size(118, 17);
            this.LbLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbfname
            // 
            this.lbfname.Name = "lbfname";
            this.lbfname.Size = new System.Drawing.Size(67, 17);
            this.lbfname.Text = "First Name:";
            // 
            // LbFirstName
            // 
            this.LbFirstName.AutoSize = false;
            this.LbFirstName.Name = "LbFirstName";
            this.LbFirstName.Size = new System.Drawing.Size(118, 17);
            this.LbFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(24, 17);
            this.toolStripStatusLabel4.Text = "MI:";
            // 
            // LbMI
            // 
            this.LbMI.AutoSize = false;
            this.LbMI.Name = "LbMI";
            this.LbMI.Size = new System.Drawing.Size(118, 17);
            this.LbMI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(784, 490);
            this.printPreviewControl1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CbFilter,
            this.TbKeyword,
            this.BtSearch,
            this.toolStripLabel1,
            this.LbNoOfResults,
            this.LbRecordCounter,
            this.BtFirstRec,
            this.BtPrevious,
            this.BtNextRec,
            this.BtLastRec});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(765, 25);
            this.toolStrip1.TabIndex = 166;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CbFilter
            // 
            this.CbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFilter.Items.AddRange(new object[] {
            "TODAY",
            "CONTROL NO.",
            "DATE",
            "LAST NAME",
            "FIRST NAME",
            "MIDDLE INITIAL",
            "SUFFIX",
            "ADDRESS",
            "AGE",
            "SEX",
            "CIVIL STATUS",
            "BIRTH DATE",
            "BIRTH PLACE",
            "REQUESTING PARTY",
            "PURPOSE",
            "TELEPHONE NO.",
            "MOBILE NO.",
            "DISTRICT/BRANCH",
            "EXAM",
            "CUSTOM QUERY"});
            this.CbFilter.Margin = new System.Windows.Forms.Padding(1, 0, 5, 0);
            this.CbFilter.Name = "CbFilter";
            this.CbFilter.Size = new System.Drawing.Size(140, 25);
            // 
            // TbKeyword
            // 
            this.TbKeyword.AutoSize = false;
            this.TbKeyword.BackColor = System.Drawing.Color.LightYellow;
            this.TbKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbKeyword.Margin = new System.Windows.Forms.Padding(1, 0, 5, 0);
            this.TbKeyword.Name = "TbKeyword";
            this.TbKeyword.Size = new System.Drawing.Size(200, 23);
            // 
            // BtSearch
            // 
            this.BtSearch.AutoSize = false;
            this.BtSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtSearch.ForeColor = System.Drawing.Color.Blue;
            this.BtSearch.Image = ((System.Drawing.Image)(resources.GetObject("BtSearch.Image")));
            this.BtSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtSearch.Name = "BtSearch";
            this.BtSearch.Size = new System.Drawing.Size(100, 22);
            this.BtSearch.Text = "Search";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(37, 22);
            this.toolStripLabel1.Text = "Total:";
            // 
            // LbNoOfResults
            // 
            this.LbNoOfResults.AutoSize = false;
            this.LbNoOfResults.ForeColor = System.Drawing.Color.Blue;
            this.LbNoOfResults.Name = "LbNoOfResults";
            this.LbNoOfResults.Size = new System.Drawing.Size(86, 22);
            this.LbNoOfResults.Text = "0";
            this.LbNoOfResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbRecordCounter
            // 
            this.LbRecordCounter.AutoSize = false;
            this.LbRecordCounter.Name = "LbRecordCounter";
            this.LbRecordCounter.Size = new System.Drawing.Size(86, 22);
            this.LbRecordCounter.Text = "0 of 0";
            // 
            // BtFirstRec
            // 
            this.BtFirstRec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtFirstRec.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtFirstRec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtFirstRec.Name = "BtFirstRec";
            this.BtFirstRec.Size = new System.Drawing.Size(23, 22);
            this.BtFirstRec.Text = "|<";
            // 
            // BtPrevious
            // 
            this.BtPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtPrevious.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtPrevious.Name = "BtPrevious";
            this.BtPrevious.Size = new System.Drawing.Size(23, 22);
            this.BtPrevious.Text = "<";
            // 
            // BtNextRec
            // 
            this.BtNextRec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtNextRec.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtNextRec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtNextRec.Name = "BtNextRec";
            this.BtNextRec.Size = new System.Drawing.Size(23, 22);
            this.BtNextRec.Text = ">";
            // 
            // BtLastRec
            // 
            this.BtLastRec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtLastRec.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtLastRec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtLastRec.Name = "BtLastRec";
            this.BtLastRec.Size = new System.Drawing.Size(23, 22);
            this.BtLastRec.Text = ">|";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtPrint,
            this.toolStripSeparator1,
            this.BtMagnifier});
            this.toolStrip2.Location = new System.Drawing.Point(6, 25);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip2.Size = new System.Drawing.Size(118, 25);
            this.toolStrip2.TabIndex = 167;
            // 
            // BtPrint
            // 
            this.BtPrint.AutoSize = false;
            this.BtPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtPrint.Name = "BtPrint";
            this.BtPrint.Size = new System.Drawing.Size(50, 22);
            this.BtPrint.Text = "Print";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtMagnifier
            // 
            this.BtMagnifier.AutoSize = false;
            this.BtMagnifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtMagnifier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BtMagnifier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Mag100Menu,
            this.Mag150Menu,
            this.Mag200Menu,
            this.Mag250Menu,
            this.Mag300Menu,
            this.Mag350Menu,
            this.Mag400Menu,
            this.Mag450Menu,
            this.Mag500Menu,
            this.ActualSizeMenu});
            this.BtMagnifier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtMagnifier.Name = "BtMagnifier";
            this.BtMagnifier.Size = new System.Drawing.Size(50, 22);
            this.BtMagnifier.Text = "Zoom";
            // 
            // Mag100Menu
            // 
            this.Mag100Menu.Name = "Mag100Menu";
            this.Mag100Menu.Size = new System.Drawing.Size(131, 22);
            this.Mag100Menu.Text = "100%";
            // 
            // Mag150Menu
            // 
            this.Mag150Menu.Name = "Mag150Menu";
            this.Mag150Menu.Size = new System.Drawing.Size(131, 22);
            this.Mag150Menu.Text = "150%";
            // 
            // Mag200Menu
            // 
            this.Mag200Menu.Name = "Mag200Menu";
            this.Mag200Menu.Size = new System.Drawing.Size(131, 22);
            this.Mag200Menu.Text = "200%";
            // 
            // Mag250Menu
            // 
            this.Mag250Menu.Name = "Mag250Menu";
            this.Mag250Menu.Size = new System.Drawing.Size(131, 22);
            this.Mag250Menu.Text = "250%";
            // 
            // Mag300Menu
            // 
            this.Mag300Menu.Name = "Mag300Menu";
            this.Mag300Menu.Size = new System.Drawing.Size(131, 22);
            this.Mag300Menu.Text = "300%";
            // 
            // Mag350Menu
            // 
            this.Mag350Menu.Name = "Mag350Menu";
            this.Mag350Menu.Size = new System.Drawing.Size(131, 22);
            this.Mag350Menu.Text = "350%";
            // 
            // Mag400Menu
            // 
            this.Mag400Menu.Name = "Mag400Menu";
            this.Mag400Menu.Size = new System.Drawing.Size(131, 22);
            this.Mag400Menu.Text = "400%";
            // 
            // Mag450Menu
            // 
            this.Mag450Menu.Name = "Mag450Menu";
            this.Mag450Menu.Size = new System.Drawing.Size(131, 22);
            this.Mag450Menu.Text = "450%";
            // 
            // Mag500Menu
            // 
            this.Mag500Menu.Name = "Mag500Menu";
            this.Mag500Menu.Size = new System.Drawing.Size(131, 22);
            this.Mag500Menu.Text = "500%";
            // 
            // ActualSizeMenu
            // 
            this.ActualSizeMenu.Name = "ActualSizeMenu";
            this.ActualSizeMenu.Size = new System.Drawing.Size(131, 22);
            this.ActualSizeMenu.Text = "Actual Size";
            // 
            // bgSearch
            // 
            this.bgSearch.WorkerReportsProgress = true;
            this.bgSearch.WorkerSupportsCancellation = true;
            // 
            // printDialog1
            // 
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.UseEXDialog = true;
            // 
            // PrintReceiptPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "PrintReceiptPage";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRINT RECEIPT";
            this.Load += new System.EventHandler(this.PrintReceiptPage_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox CbFilter;
        private System.Windows.Forms.ToolStripTextBox TbKeyword;
        private System.Windows.Forms.ToolStripButton BtSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel LbNoOfResults;
        private System.Windows.Forms.ToolStripLabel LbRecordCounter;
        private System.Windows.Forms.ToolStripButton BtFirstRec;
        private System.Windows.Forms.ToolStripButton BtPrevious;
        private System.Windows.Forms.ToolStripButton BtNextRec;
        private System.Windows.Forms.ToolStripButton BtLastRec;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel LbControlNo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel LbLastName;
        private System.Windows.Forms.ToolStripStatusLabel lbfname;
        private System.Windows.Forms.ToolStripStatusLabel LbFirstName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel LbMI;
        private System.ComponentModel.BackgroundWorker bgSearch;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton BtPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton BtMagnifier;
        private System.Windows.Forms.ToolStripMenuItem Mag100Menu;
        private System.Windows.Forms.ToolStripMenuItem Mag150Menu;
        private System.Windows.Forms.ToolStripMenuItem Mag200Menu;
        private System.Windows.Forms.ToolStripMenuItem Mag250Menu;
        private System.Windows.Forms.ToolStripMenuItem Mag300Menu;
        private System.Windows.Forms.ToolStripMenuItem Mag350Menu;
        private System.Windows.Forms.ToolStripMenuItem Mag400Menu;
        private System.Windows.Forms.ToolStripMenuItem Mag450Menu;
        private System.Windows.Forms.ToolStripMenuItem Mag500Menu;
        private System.Windows.Forms.ToolStripMenuItem ActualSizeMenu;
        private System.Windows.Forms.PrintDialog printDialog1;

    }
}