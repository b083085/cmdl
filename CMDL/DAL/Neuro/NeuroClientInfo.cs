using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CMDL
{
    public class NeuroClientInfo:CyberPropertyChanged
    {

        public string HomeAddress
        {
            set;
            get;
        }

        public string Purpose
        {
            set;
            get;
        }

        public string RefAgency
        {
            set;
            get;
        }

        public string Subject
        {
            get;
            set;
        }

        public string Occupation
        {
            get;
            set;
        }

        public string PlaceOfWork
        {
            get;
            set;
        }

        public string Education
        {
            get;
            set;
        }

        public string Religion
        {
            get;
            set;
        }

        public string A
        {
            set
            {
                switch (value)
                {
                    case "1": A1 = true;
                        break;
                    case "2": A2 = true;
                        break;
                    case "3": A3 = true;
                        break;
                    case "4": A4 = true;
                        break;
                    case "5": A5 = true;
                        break;
                }
            }
            get
            {
                if (A1)
                    return "1";
                else if (A2)
                    return "2";
                else if (A3)
                    return "3";
                else if (A4)
                    return "4";
                else if (A5)
                    return "5";
                else
                    return "";
            }
        }

        public bool A1
        {
            set;
            get;
        }

        public bool A2
        {
            set;
            get;
        }

        public bool A3
        {
            set;
            get;
        }

        public bool A4
        {
            set;
            get;
        }

        public bool A5
        {
            set;
            get;
        }

        public string B1
        {
            set
            {
                switch (value)
                {
                    case "1": B1_1 = true;
                        break;
                    case "2": B1_2 = true;
                        break;
                    case "3": B1_3 = true;
                        break;
                    case "4": B1_4 = true;
                        break;
                    case "5": B1_5 = true;
                        break;
                }
            }
            get
            {
                if (B1_1)
                    return "1";
                else if (B1_2)
                    return "2";
                else if (B1_3)
                    return "3";
                else if (B1_4)
                    return "4";
                else if (B1_5)
                    return "5";
                else
                    return "";
            }
        }

        public bool B1_1
        {
            set;
            get;
        }

        public bool B1_2
        {
            set;
            get;
        }

        public bool B1_3
        {
            set;
            get;
        }

        public bool B1_4
        {
            set;
            get;
        }

        public bool B1_5
        {
            set;
            get;
        }

        public string B2
        {
            set
            {
                switch (value)
                {
                    case "1": B2_1 = true;
                        break;
                    case "2": B2_2 = true;
                        break;
                    case "3": B2_3 = true;
                        break;
                    case "4": B2_4 = true;
                        break;
                    case "5": B2_5 = true;
                        break;
                }
            }
            get
            {
                if (B2_1)
                    return "1";
                else if (B2_2)
                    return "2";
                else if (B2_3)
                    return "3";
                else if (B2_4)
                    return "4";
                else if (B2_5)
                    return "5";
                else
                    return "";
            }
        }

        public bool B2_1
        {
            set;
            get;
        }

        public bool B2_2
        {
            set;
            get;
        }

        public bool B2_3
        {
            set;
            get;
        }

        public bool B2_4
        {
            set;
            get;
        }

        public bool B2_5
        {
            set;
            get;
        }

        public string C1
        {
            set
            {
                switch (value)
                {
                    case "1": C1_1 = true;
                        break;
                    case "2": C1_2 = true;
                        break;
                    case "3": C1_3 = true;
                        break;
                    case "4": C1_4 = true;
                        break;
                    case "5": C1_5 = true;
                        break;
                }
            }
            get
            {
                if (C1_1)
                    return "1";
                else if (C1_2)
                    return "2";
                else if (C1_3)
                    return "3";
                else if (C1_4)
                    return "4";
                else if (C1_5)
                    return "5";
                else
                    return "";
            }
        }

        public bool C1_1
        {
            set;
            get;
        }

        public bool C1_2
        {
            set;
            get;
        }

        public bool C1_3
        {
            set;
            get;
        }

        public bool C1_4
        {
            set;
            get;
        }

        public bool C1_5
        {
            set;
            get;
        }

        public string C2
        {
            set
            {
                switch (value)
                {
                    case "1": C2_1 = true;
                        break;
                    case "2": C2_2 = true;
                        break;
                    case "3": C2_3 = true;
                        break;
                    case "4": C2_4 = true;
                        break;
                    case "5": C2_5 = true;
                        break;
                }
            }
            get
            {
                if (C2_1)
                    return "1";
                else if (C2_2)
                    return "2";
                else if (C2_3)
                    return "3";
                else if (C2_4)
                    return "4";
                else if (C2_5)
                    return "5";
                else
                    return "";
            }
        }

        public bool C2_1
        {
            set;
            get;
        }

        public bool C2_2
        {
            set;
            get;
        }

        public bool C2_3
        {
            set;
            get;
        }

        public bool C2_4
        {
            set;
            get;
        }

        public bool C2_5
        {
            set;
            get;
        }

        public string C3
        {
            set
            {
                switch (value)
                {
                    case "1": C3_1 = true;
                        break;
                    case "2": C3_2 = true;
                        break;
                    case "3": C3_3 = true;
                        break;
                    case "4": C3_4 = true;
                        break;
                    case "5": C3_5 = true;
                        break;
                }
            }
            get
            {
                if (C3_1)
                    return "1";
                else if (C3_2)
                    return "2";
                else if (C3_3)
                    return "3";
                else if (C3_4)
                    return "4";
                else if (C3_5)
                    return "5";
                else
                    return "";
            }
        }

        public bool C3_1
        {
            set;
            get;
        }

        public bool C3_2
        {
            set;
            get;
        }

        public bool C3_3
        {
            set;
            get;
        }

        public bool C3_4
        {
            set;
            get;
        }

        public bool C3_5
        {
            set;
            get;
        }

        public string C4
        {
            set
            {
                switch (value)
                {
                    case "1": C4_1 = true;
                        break;
                    case "2": C4_2 = true;
                        break;
                    case "3": C4_3 = true;
                        break;
                    case "4": C4_4 = true;
                        break;
                    case "5": C4_5 = true;
                        break;
                }
            }
            get
            {
                if (C4_1)
                    return "1";
                else if (C4_2)
                    return "2";
                else if (C4_3)
                    return "3";
                else if (C4_4)
                    return "4";
                else if (C4_5)
                    return "5";
                else
                    return "";
            }
        }

        public bool C4_1
        {
            set;
            get;
        }

        public bool C4_2
        {
            set;
            get;
        }

        public bool C4_3
        {
            set;
            get;
        }

        public bool C4_4
        {
            set;
            get;
        }

        public bool C4_5
        {
            set;
            get;
        }

        public string D1
        {
            set
            {
                switch (value)
                {
                    case "1": D1_1 = true;
                        break;
                    case "2": D1_2 = true;
                        break;
                    case "3": D1_3 = true;
                        break;
                    case "4": D1_4 = true;
                        break;
                    case "5": D1_5 = true;
                        break;
                }
            }
            get
            {
                if (D1_1)
                    return "1";
                else if (D1_2)
                    return "2";
                else if (D1_3)
                    return "3";
                else if (D1_4)
                    return "4";
                else if (D1_5)
                    return "5";
                else
                    return "";
            }
        }

        public bool D1_1
        {
            set;
            get;
        }

        public bool D1_2
        {
            set;
            get;
        }

        public bool D1_3
        {
            set;
            get;
        }

        public bool D1_4
        {
            set;
            get;
        }

        public bool D1_5
        {
            set;
            get;
        }

        public string D2
        {
            set
            {
                switch (value)
                {
                    case "1": D2_1 = true;
                        break;
                    case "2": D2_2 = true;
                        break;
                    case "3": D2_3 = true;
                        break;
                    case "4": D2_4 = true;
                        break;
                    case "5": D2_5 = true;
                        break;
                }
            }
            get
            {
                if (D2_1)
                    return "1";
                else if (D2_2)
                    return "2";
                else if (D2_3)
                    return "3";
                else if (D2_4)
                    return "4";
                else if (D2_5)
                    return "5";
                else
                    return "";
            }
        }

        public bool D2_1
        {
            set;
            get;
        }

        public bool D2_2
        {
            set;
            get;
        }

        public bool D2_3
        {
            set;
            get;
        }

        public bool D2_4
        {
            set;
            get;
        }

        public bool D2_5
        {
            set;
            get;
        }

        public string D3
        {
            set
            {
                switch (value)
                {
                    case "1": D3_1 = true;
                        break;
                    case "2": D3_2 = true;
                        break;
                    case "3": D3_3 = true;
                        break;
                    case "4": D3_4 = true;
                        break;
                    case "5": D3_5 = true;
                        break;
                }
            }
            get
            {
                if (D3_1)
                    return "1";
                else if (D3_2)
                    return "2";
                else if (D3_3)
                    return "3";
                else if (D3_4)
                    return "4";
                else if (D3_5)
                    return "5";
                else
                    return "";
            }
        }

        public bool D3_1
        {
            set;
            get;
        }

        public bool D3_2
        {
            set;
            get;
        }

        public bool D3_3
        {
            set;
            get;
        }

        public bool D3_4
        {
            set;
            get;
        }

        public bool D3_5
        {
            set;
            get;
        }

        public string D4
        {
            set
            {
                switch (value)
                {
                    case "1": D4_1 = true;
                        break;
                    case "2": D4_2 = true;
                        break;
                    case "3": D4_3 = true;
                        break;
                    case "4": D4_4 = true;
                        break;
                    case "5": D4_5 = true;
                        break;
                }
            }
            get
            {
                if (D4_1)
                    return "1";
                else if (D4_2)
                    return "2";
                else if (D4_3)
                    return "3";
                else if (D4_4)
                    return "4";
                else if (D4_5)
                    return "5";
                else
                    return "";
            }
        }

        public bool D4_1
        {
            set;
            get;
        }

        public bool D4_2
        {
            set;
            get;
        }

        public bool D4_3
        {
            set;
            get;
        }

        public bool D4_4
        {
            set;
            get;
        }

        public bool D4_5
        {
            set;
            get;
        }

        public string JobExperience
        {
            get;
            set;
        }

        public string Eligibility
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public string Recommendation
        {
            set;
            get;
        }

        public string GenApp
        {
            set
            {
                switch (value)
                {
                    case "1": GenApp_1 = true;
                        break;
                    case "2": GenApp_2 = true;
                        break;
                    case "3": GenApp_3 = true;
                        break;
                }
            }
            get
            {
                if (GenApp_1)
                    return "1";
                else if (GenApp_2)
                    return "2";
                else if (GenApp_3)
                    return "3";
                else
                    return "";
            }
        }

        public bool GenApp_1
        {
            get;
            set;
        }

        public bool GenApp_2
        {
            get;
            set;
        }

        public bool GenApp_3
        {
            get;
            set;
        }

        public string Attitude
        {
            set
            {
                switch (value)
                {
                    case "1": Attitude_1 = true;
                        break;
                    case "2": Attitude_2 = true;
                        break;
                    case "3": Attitude_3 = true;
                        break;
                }
            }
            get
            {
                if (Attitude_1)
                    return "1";
                else if (Attitude_2)
                    return "2";
                else if (Attitude_3)
                    return "3";
                else
                    return "";
            }
        }

        public bool Attitude_1
        {
            get;
            set;
        }

        public bool Attitude_2
        {
            get;
            set;
        }

        public bool Attitude_3
        {
            get;
            set;
        }

        public string Memory
        {
            set
            {
                switch (value)
                {
                    case "1": Memory_1 = true;
                        break;
                    case "2": Memory_2 = true;
                        break;
                    case "3": Memory_3 = true;
                        break;
                }
            }
            get
            {
                if (Memory_1)
                    return "1";
                else if (Memory_2)
                    return "2";
                else if (Memory_3)
                    return "3";
                else
                    return "";
            }
        }

        public bool Memory_1
        {
            set;
            get;
        }

        public bool Memory_2
        {
            set;
            get;
        }

        public bool Memory_3
        {
            set;
            get;
        }

        public string Speech
        {
            set
            {
                switch (value)
                {
                    case "1": Speech_1 = true;
                        break;
                    case "2": Speech_2 = true;
                        break;
                    case "3": Speech_3 = true;
                        break;
                }
            }
            get
            {
                if (Speech_1)
                    return "1";
                else if (Speech_2)
                    return "2";
                else if (Speech_3)
                    return "3";
                else
                    return "";
            }
        }

        public bool Speech_1
        {
            set;
            get;
        }

        public bool Speech_2
        {
            set;
            get;
        }

        public bool Speech_3
        {
            set;
            get;
        }

        public string AffectAndMood
        {
            set
            {
                switch (value)
                {
                    case "1": AffectAndMood_1 = true;
                        break;
                    case "2": AffectAndMood_2 = true;
                        break;
                    case "3": AffectAndMood_3 = true;
                        break;
                }
            }
            get
            {
                if (AffectAndMood_1)
                    return "1";
                else if (AffectAndMood_2)
                    return "2";
                else if (AffectAndMood_3)
                    return "3";
                else
                    return "";
            }
        }

        public bool AffectAndMood_1
        {
            set;
            get;
        }

        public bool AffectAndMood_2
        {
            set;
            get;
        }

        public bool AffectAndMood_3
        {
            set;
            get;
        }

        public string ThoughtContent
        {
            set
            {
                switch (value)
                {
                    case "1": ThoughtContent_1 = true;
                        break;
                    case "2": ThoughtContent_2 = true;
                        break;
                    case "3": ThoughtContent_3 = true;
                        break;
                }
            }
            get
            {
                if (ThoughtContent_1)
                    return "1";
                else if (ThoughtContent_2)
                    return "2";
                else if (ThoughtContent_3)
                    return "3";
                else
                    return "";
            }
        }

        public bool ThoughtContent_1
        {
            set;
            get;
        }

        public bool ThoughtContent_2
        {
            set;
            get;
        }

        public bool ThoughtContent_3
        {
            set;
            get;
        }

        public string Suicidality
        {
            set
            {
                switch (value)
                {
                    case "1": Suicidality_1 = true;
                        break;
                    case "2": Suicidality_2 = true;
                        break;
                    case "3": Suicidality_3 = true;
                        break;
                }
            }
            get
            {
                if (Suicidality_1)
                    return "1";
                else if (Suicidality_2)
                    return "2";
                else if (Suicidality_3)
                    return "3";
                else
                    return "";
            }
        }

        public bool Suicidality_1
        {
            set;
            get;
        }

        public bool Suicidality_2
        {
            set;
            get;
        }

        public bool Suicidality_3
        {
            set;
            get;
        }

        public string Preoccupations
        {
            set
            {
                switch (value)
                {
                    case "1": Preoccupations_1 = true;
                        break;
                    case "2": Preoccupations_2 = true;
                        break;
                    case "3": Preoccupations_3 = true;
                        break;
                }
            }
            get
            {
                if (Preoccupations_1)
                    return "1";
                else if (Preoccupations_2)
                    return "2";
                else if (Preoccupations_3)
                    return "3";
                else
                    return "";
            }
        }

        public bool Preoccupations_1
        {
            set;
            get;
        }

        public bool Preoccupations_2
        {
            set;
            get;
        }

        public bool Preoccupations_3
        {
            set;
            get;
        }

        public string CognitionThinking
        {
            set
            {
                switch (value)
                {
                    case "1": CognitionThinking_1 = true;
                        break;
                    case "2": CognitionThinking_2 = true;
                        break;
                    case "3": CognitionThinking_3 = true;
                        break;
                }
            }
            get
            {
                if (CognitionThinking_1)
                    return "1";
                else if (CognitionThinking_2)
                    return "2";
                else if (CognitionThinking_3)
                    return "3";
                else
                    return "";
            }
        }

        public bool CognitionThinking_1
        {
            set;
            get;
        }

        public bool CognitionThinking_2
        {
            set;
            get;
        }

        public bool CognitionThinking_3
        {
            set;
            get;
        }

        public string Halucination
        {
            set
            {
                switch (value)
                {
                    case "1": Halucination_1 = true;
                        break;
                    case "2": Halucination_2 = true;
                        break;
                    case "3": Halucination_3 = true;
                        break;
                }
            }
            get
            {
                if (Halucination_1)
                    return "1";
                else if (Halucination_2)
                    return "2";
                else if (Halucination_3)
                    return "3";
                else
                    return "";
            }
        }

        public bool Halucination_1
        {
            set;
            get;
        }

        public bool Halucination_2
        {
            set;
            get;
        }

        public bool Halucination_3
        {
            set;
            get;
        }

        public string Psychometrician
        {
            get;
            set;
        }

        public string Psychiatrist
        {
            set;
            get;
        }

        public string PrintedBy
        {
            set;
            get;
        }

        public string Marker
        {
            set;
            get;
        }
    }

    public class Psychiatrist
    {
        public string Name { set; get; }
        public string Title { set; get; }
        public string License_No { set; get; }
        public string Ptr_No { set; get; }
        public string S2_No { set; get; }
        public string Other_No { set; get; }
    }
}
