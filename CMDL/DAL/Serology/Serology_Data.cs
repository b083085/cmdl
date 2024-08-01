using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL
{
    public class Serology_Data
    {

        public Serology_Data(bool enabled)
        {
            Enabled = enabled;
        }

        public bool Enabled { set; get; }      
        public string Type { set; get; }
        public string AntiHAV_results { set; get; }
        public string AntiHAV_Kit { set; get; }
        public string AntiHAV_LotNo { set; get; }
        public string AntiHAV_Exp { set; get; }
        public string AntiHAV_Remarks { set; get; }

        public string AntiHIV_results { set; get; }
        public string AntiHIV_Kit { set; get; }
        public string AntiHIV_LotNo { set; get; }
        public string AntiHIV_Exp { set; get; }
        public string AntiHIV_Remarks { set; get; }

        public string HBsAg_results { set; get; }
        public string HBsAg_Kit { set; get; }
        public string HBsAg_LotNo { set; get; }
        public string HBsAg_Exp { set; get; }
        public string HBsAg_Remarks { set; get; }

        public string AntiHBS_results { set; get; }
        public string AntiHBS_Kit { set; get; }
        public string AntiHBS_LotNo { set; get; }
        public string AntiHBS_Exp { set; get; }
        public string AntiHBS_Remarks { set; get; }

        public string AntiTP_results { set; get; }
        public string AntiTP_Kit { set; get; }
        public string AntiTP_LotNo { set; get; }
        public string AntiTP_Exp { set; get; }
        public string AntiTP_Remarks { set; get; }

        public string AntiHCV_results { set; get; }
        public string AntiHCV_Kit { set; get; }
        public string AntiHCV_LotNo { set; get; }
        public string AntiHCV_Exp { set; get; }
        public string AntiHCV_Remarks { set; get; }

        public string Syphilis_results { set; get; }
        public string Syphilis_Kit { set; get; }
        public string Syphilis_LotNo { set; get; }
        public string Syphilis_Exp { set; get; }
        public string Syphilis_Remarks { set; get; }

        public string Pathologist { set; get; }
        public string MedTech_1 { set; get; }
        public string MedTech_2 { set; get; }
        public string PrintedBy { set; get; }

        public string Up_Controlno { set; get; }


    }
}
