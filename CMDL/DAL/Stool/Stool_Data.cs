using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL
{
    public class Stool_Data
    {
        public Stool_Data(bool enabled)
        {
            Enabled = enabled;
        }

        public bool Enabled { set; get; }
        
        public string Consistency { set; get; }
        public string Color { set; get; }
        public string Leukocytes { set; get; }
        public string Erythrocytes { set; get; }
        public string Fat_Globules { set; get; }
        public string Yeast_Cells { set; get; }
        public string Ova_Of_Parasite { set; get; }
        public string Protozoan { set; get; }
        public string Occult_Blood { set; get; }
        public string Remarks { set; get; }
        public string Pathologist { set; get; }
        public string MedTech { set; get; }
        public string PrintedBy { set; get; }
    }
}
