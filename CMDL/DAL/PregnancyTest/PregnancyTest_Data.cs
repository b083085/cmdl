using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL
{
    public class PregnancyTest_Data
    {

        public PregnancyTest_Data(bool enabled)
        {
            Enabled = enabled;
        }

        public bool Enabled { set; get; }
        
        public string ReqPhysician { set; get; }
        public string Results { set; get; }
        public string Remarks { set; get; }
        public string Pathologist { set; get; }
        public string MedTech { set; get; }
        public string PrintedBy { set; get; }
    }
}
