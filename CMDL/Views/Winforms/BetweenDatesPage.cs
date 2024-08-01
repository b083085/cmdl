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
    public partial class BetweenDatesPage : Form
    {
        public BetweenDatesPage()
        {
            InitializeComponent();
        }

        public DateTime InitialDate
        {
            get
            {
                return dateTimePicker1.Value;
            }
        }

        public DateTime EndingDate
        {
            get
            {
                return dateTimePicker2.Value;
            }
        }
    }
}
