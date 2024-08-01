using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL
{
    public class CultureAndSensitivity_Data
    {

        
        public CultureAndSensitivity_Data(bool enabled)
        {
            Enabled = enabled;
        }

        public bool Enabled {set;get;}

        public string CSNo
        {
            set;
            get;
        }

        public List<CS_GramStain> GramStainResult
        {
            set;
            get;
        }
        public List<IDO> IDOResult
        {
            set;
            get;
        }
        public List<Sensitivity> SensitivityResult
        {
            set;
            get;
        }
        public string Note { set; get; }
        public string Sample { set; get; }
        public string Pathologist { set; get; }
        public string MedTech { set; get; }
        public string PrintedBy { set; get; }
    }
}
