using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL
{
    public class Urinalysis_Data
    {
        public Urinalysis_Data(bool enabled)
        {
            Enabled = enabled;
        }
        public bool Enabled { set; get; }
        
        public string Collection { set; get; }
        public string Color { set; get; }
        public string Transparency { set; get; }
        public string Specific_Gravity { set; get; }
        public string PH { set; get; }
        public string Glucose { set; get; }
        public string Protein { set; get; }
        public string Blood { set; get; }
        public string Leukocytes { set; get; }
        public string Nitrite { set; get; }
        public string Ketone { set; get; }
        public string Urobilinogen { set; get; }
        public string Ascorbic_Acid { set; get; }
        public string RBC { set; get; }
        public string WBC { set; get; }
        public string Epithelial_Cells { set; get; }
        public string Bacteria { set; get; }
        public string Mucus_Thread { set; get; }
        public string A_Urates { set; get; }
        public string Uric_Acid { set; get; }
        public string Calcium_Oxalate { set; get; }
        public string Fine_Granular_Cast { set; get; }
        public string Coarse_Granular_Cast { set; get; }
        public string WBC_Cast { set; get; }
        public string RBC_Cast { set; get; }
        public string Others { set; get; }
        public string Note { set; get; }
        public string Remarks { set; get; }
        public string Pathologist { set; get; }
        public string MedTech { set; get; }
        public string PrintedBy { set; get; }
    }
}
