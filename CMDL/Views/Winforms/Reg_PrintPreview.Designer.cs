namespace CMDL
{
    partial class Reg_PrintPreview
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
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
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.printPreviewControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(584, 337);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(584, 362);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Columns = 4;
            this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(584, 337);
            this.printPreviewControl1.TabIndex = 0;
            this.printPreviewControl1.UseAntiAlias = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtPrint,
            this.toolStripSeparator1,
            this.BtMagnifier});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(218, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // BtPrint
            // 
            this.BtPrint.AutoSize = false;
            this.BtPrint.BackgroundImage = global::CMDL.Properties.Resources.print_icon;
            this.BtPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtPrint.Name = "BtPrint";
            this.BtPrint.Size = new System.Drawing.Size(50, 22);
            this.BtPrint.ToolTipText = "Print";
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
            this.BtMagnifier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.BtMagnifier.Size = new System.Drawing.Size(150, 22);
            this.BtMagnifier.Text = "Zoom";
            this.BtMagnifier.ToolTipText = "Zoom";
            // 
            // Mag100Menu
            // 
            this.Mag100Menu.Name = "Mag100Menu";
            this.Mag100Menu.Size = new System.Drawing.Size(123, 22);
            this.Mag100Menu.Text = "100%";
            // 
            // Mag150Menu
            // 
            this.Mag150Menu.Name = "Mag150Menu";
            this.Mag150Menu.Size = new System.Drawing.Size(123, 22);
            this.Mag150Menu.Text = "150%";
            // 
            // Mag200Menu
            // 
            this.Mag200Menu.Name = "Mag200Menu";
            this.Mag200Menu.Size = new System.Drawing.Size(123, 22);
            this.Mag200Menu.Text = "200%";
            // 
            // Mag250Menu
            // 
            this.Mag250Menu.Name = "Mag250Menu";
            this.Mag250Menu.Size = new System.Drawing.Size(123, 22);
            this.Mag250Menu.Text = "250%";
            // 
            // Mag300Menu
            // 
            this.Mag300Menu.Name = "Mag300Menu";
            this.Mag300Menu.Size = new System.Drawing.Size(123, 22);
            this.Mag300Menu.Text = "300%";
            // 
            // Mag350Menu
            // 
            this.Mag350Menu.Name = "Mag350Menu";
            this.Mag350Menu.Size = new System.Drawing.Size(123, 22);
            this.Mag350Menu.Text = "350%";
            // 
            // Mag400Menu
            // 
            this.Mag400Menu.Name = "Mag400Menu";
            this.Mag400Menu.Size = new System.Drawing.Size(123, 22);
            this.Mag400Menu.Text = "400%";
            // 
            // Mag450Menu
            // 
            this.Mag450Menu.Name = "Mag450Menu";
            this.Mag450Menu.Size = new System.Drawing.Size(123, 22);
            this.Mag450Menu.Text = "450%";
            // 
            // Mag500Menu
            // 
            this.Mag500Menu.Name = "Mag500Menu";
            this.Mag500Menu.Size = new System.Drawing.Size(123, 22);
            this.Mag500Menu.Text = "500%";
            // 
            // ActualSizeMenu
            // 
            this.ActualSizeMenu.Name = "ActualSizeMenu";
            this.ActualSizeMenu.Size = new System.Drawing.Size(123, 22);
            this.ActualSizeMenu.Text = "Auto Size";
            // 
            // printDialog1
            // 
            this.printDialog1.AllowPrintToFile = false;
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.UseEXDialog = true;
            // 
            // Reg_PrintPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Reg_PrintPreview";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRINT PREVIEW";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtPrint;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
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