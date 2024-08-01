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
    public partial class CrystalReportForm : Form
    {
        public CrystalReportForm(object rep,bool showbutton)
        {
            InitializeComponent();

            crystalReportViewer1.ShowPrintButton = showbutton;
            crystalReportViewer1.ShowExportButton = showbutton;
            crystalReportViewer1.ReportSource = rep;
            crystalReportViewer1.Zoom(2);
            crystalReportViewer1.Refresh();
            
        }
    }
}
