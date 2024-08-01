using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMDL
{
    public class PE_Data
    {
        public PE_Data(bool enabled)
        {
            Enabled = enabled;
        }

        public string cxrdate;


        public bool Enabled { set; get; }
        public string Nature_Of_Work { set; get; }
        public string Growth_Development { set; get; }
        public string BP { set; get; }
        public string HR { set; get; }
        public string PR { set; get; }
        public string Height { set; get; }
        public string Weight { set; get; }
        public string Eyes { set; get; }
        public string OD { set; get; }
        public string OS { set; get; }
        public string Ishi_OD { set; get; }
        public string Ishi_OS { set; get; }
        public string Ears { set; get; }
        public string Nose_Throat { set; get; }
        public string Dentals { set; get; }
        public string Breast { set; get; }
        public string Extremities { set; get; }
        public string NeuroLog { set; get; }
        public string Heart { set; get; }
        public string Lungs { set; get; }
        public string Abdomen { set; get; }
        public string Genitalia { set; get; }
        public string Ano_Rectal { set; get; }
        public string Skin { set; get; }
        public string Other_Body_Parts { set; get; }
        public string Past_Med_History { set; get; }
        public string CXR_Date
        {
            set
            {
                try
                {
                    cxrdate = string.Format("{0:MM-dd-yyyy}", DateTime.Parse(value));
                }
                catch (Exception)
                {
                    cxrdate = value;
                }
            }
            get
            {
                return cxrdate;
            }

        }
        public string Film_No { set; get; }
        public string CXR_Negative
        {
            set
            {
                switch (value)
                {
                    case "0": CXRNegative_Check = false;
                        break;
                    case "1": CXRNegative_Check = true;
                        break;
                }
            }
            get
            {
                if (CXRNegative_Check)
                    return "1";
                else
                    return "0";
            }
        }
        public bool CXRNegative_Check
        {
            set;
            get;
        }
        public string CXR_Findings { set; get; }
        public string CBC { set; get; }
        public string Urine { set; get; }
        public string Stool { set; get; }
        public string Blood_Chemistry { set; get; }
        public string Pregnancy_Test { set; get; }
        public string VDRL { set; get; }
        public string HepA { set; get; }
        public string HepB { set; get; }
        public string HIV { set; get; }
        public string Drug_Test { set; get; }
        public string Blood_Typing { set; get; }
        public string Other_Test { set; get; }
        public string Neuro_Psychological { set; get; }
        public string Neuro_Psychiatric { set; get; }
        public string Remarks { set; get; }
        public string Recommendation { set; get; }
        public string Rec_Note { set; get; }
        public string Ref_By { set; get; }
        public string Physician { set; get; }
        public string PrintedBy { set; get; }

        public DataTable GetPhysician
        {
            set;
            get;
        }

    }
}
