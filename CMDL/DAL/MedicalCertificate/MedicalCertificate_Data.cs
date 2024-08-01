using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL
{
    public class MedicalCertificate_Data
    {
        public MedicalCertificate_Data(bool enabled)
        {
            Enabled = enabled;
        }

        public bool Enabled { set; get; }
        
        public string Date_approved { set; get; }
        public string Remarks { set; get; }
        public string Physician { set; get; }
        public string License_No { set; get; }
        public string PrintedBy { set; get; }
    }
}
