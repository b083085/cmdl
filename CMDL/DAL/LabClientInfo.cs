using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using CMDL.CLASS;

namespace CMDL
{
    public class LabClientInfo:CyberPropertyChanged
    {
        public BloodTyping_Data Blood_Typing { set; get; }

        public Dictionary<string, Serology_Data> Serology = new Dictionary<string, Serology_Data>();

        public Serology_Data1 TestSerology
        {
            set;
            get;
        }

        public CultureAndSensitivity_Data CultureAndSensitivity { set; get; }

        public CBC_Data CBC { set; get; }

        public GramsStaining_Data Grams_Staining { set; get; }

        public MedicalCertificate_Data Medical_Certificate { set; get; }

        public PE_Data Physical_Examination { set; get; }

        public PregnancyTest_Data Pregnancy_Test { set; get; }

        public Stool_Data Stool { set; get; }

        public Urinalysis_Data Urinalysis { set; get; }

        public BloodChemistry_Data BloodChemistry { set; get; }

        public PapSmear PapSmear { set; get; }

        public int Count { set; get; }

        public int Total_Count { set; get; }
    }
}
