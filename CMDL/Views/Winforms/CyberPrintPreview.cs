using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL
{
    public partial class CyberPrintPreview : Form
    {
        public CyberPrintPreview()
        {
            InitializeComponent();
        }

        public PrintDocument Document
        {
            set
            {
                printPreviewControl1.Document = value;
            }

        }
    }
}
