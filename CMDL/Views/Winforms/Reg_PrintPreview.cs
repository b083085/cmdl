using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    public partial class Reg_PrintPreview : Form
    {
        Reg_PrintDoc reg_doc;
        public Reg_PrintPreview(Reg_PrintDoc reg_doc)
        {
            InitializeComponent();
            this.reg_doc = reg_doc;
            this.printPreviewControl1.Document = reg_doc.Document();
            this.printPreviewControl1.Columns = reg_doc.page.Count;

            BtPrint.Click += new EventHandler(BtPrint_Click);
            BtMagnifier.Click += new EventHandler(BtMagnifier_Click);
            Mag100Menu.Click += new EventHandler(Mag100Menu_Click);
            Mag150Menu.Click += new EventHandler(Mag150Menu_Click);
            Mag200Menu.Click += new EventHandler(Mag200Menu_Click);
            Mag250Menu.Click += new EventHandler(Mag250Menu_Click);
            Mag300Menu.Click += new EventHandler(Mag300Menu_Click);
            Mag350Menu.Click += new EventHandler(Mag350Menu_Click);
            Mag400Menu.Click += new EventHandler(Mag400Menu_Click);
            Mag450Menu.Click += new EventHandler(Mag450Menu_Click);
            Mag500Menu.Click += new EventHandler(Mag500Menu_Click);
            ActualSizeMenu.Click += new EventHandler(ActualSizeMenu_Click);

        }

        void BtMagnifier_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom += 0.3;
        }

        void ActualSizeMenu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 0.3;
        }

        void Mag500Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 5.0;
        }

        void Mag450Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 4.50;
        }

        void Mag400Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 4.0;
        }

        void Mag350Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 3.50;
        }

        void Mag300Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 3.0;
        }

        void Mag250Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 2.50;
        }

        void Mag200Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 2.0;
        }

        void Mag150Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 1.50;
        }

        void Mag100Menu_Click(object sender, EventArgs e)
        {
            printPreviewControl1.Zoom = 1.0;
        }

        void BtPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                reg_doc.FinalPrint(printDialog1.PrinterSettings);
            }
        }
    }
}
