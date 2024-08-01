using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL
{
    public class CBC_Data
    {

        public CBC_Data(bool enabled)
        {
            Enabled = enabled;
        }
        
        public bool Enabled { set; get; }
        public string Erythrocyte_Count { set; get; }
        public string Hemoglobin { set; get; }
        public string Hematocrit { set; get; }
        public string Leukocyte_Count { set; get; }
        public string Segmenters { set; get; }
        public string Stabs { set; get; }
        public string Lymphocytes { set; get; }
        public string Monocytes { set; get; }
        public string Basophils { set; get; }
        public string Eosinophils { set; get; }
        public string Platelet { set; get; }
        public string Remarks { set; get; }
        public string Pathologist { set; get; }
        public string MedTech { set; get; }
        public string PrintedBy { set; get; }
    }
}
