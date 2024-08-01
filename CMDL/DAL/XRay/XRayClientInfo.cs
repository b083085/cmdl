using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Data;

namespace CMDL
{
    public class XRayClientInfo:CyberPropertyChanged
    {

        public string Marker
        {
            get;
            set;
        }

        public string RadioReport
        {
            get;
            set;
        }

        public string Conclusion
        {
            get;
            set;
        }

        public string Radiologist
        {
            get;
            set;
        }

        public string RadiologistTitle { get; set; }

        public string PrintedBy
        {
            get;
            set;
        }

        public string UpControlNo
        {
            get;
            set;
        }


    }

}
