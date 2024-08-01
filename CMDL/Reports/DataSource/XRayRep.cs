using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL.Reports.DataSource
{
    public class XRayRep : ClientRep
    {
        public string Marker { get; set; }
        public string RadiographicReport { get; set; }
        public string Conclusion { get; set; }
        public string Radiologist { get; set; }
        public string PrintedBy { get; set; }
    }
}
