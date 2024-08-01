using System;


namespace CMDLWpf
{
    public class Test_Neuro : NotifyPropertyChanged
    {
        private ulong _testID;
        private string _controlNo;
        private string _occupation;
        private string _placeOfWork;
        private string _education;
        private string _religion;
        private byte _a;
        private byte _b1;
        private byte _b2;
        private byte _c1;
        private byte _c2;
        private byte _c3;
        private byte _c4;
        private byte _d1;
        private byte _d2;
        private byte _d3;
        private byte _d4;
        private string _jobExperience;
        private string _eligibility;
        private string _remarks;
        private string _recommendation;
        private string _psychiatric;
        private byte _generalAppearance;
        private byte _attitude;
        private byte _memory;
        private byte _speech;
        private byte _affectAndMood;
        private byte _thoughtContent;
        private byte _suicidality;
        private byte _preOccupations;
        private byte _cognitionThinking;
        private byte _halucination;
        private string _psychometrician;
        private string _psychiatrist;
        private string _createdBy;
        private DateTime _dateCreated;
        private string _updatedBy;
        private DateTime _dateUpdated;

        public ulong TestID
        {
            get { return _testID; }
            set
            {
                if (_testID != value)
                {
                    _testID = value;
                    Notify("TestID");
                }
            }
        }
        public string ControlNo
        {
            get { return _controlNo; }
            set
            {
                if (_controlNo != value)
                {
                    _controlNo = value;
                    Notify("ControlNo");
                }
            }
        }
        public string Occupation
        {
            get { return _occupation; }
            set
            {
                if (_occupation != value)
                {
                    _occupation = value;
                    Notify("Occupation");
                }
            }
        }
        public string PlaceOfWork
        {
            get { return _placeOfWork; }
            set
            {
                if (_placeOfWork != value)
                {
                    _placeOfWork = value;
                    Notify("PlaceOfWork");
                }
            }
        }
        public string Education
        {
            get { return _education; }
            set
            {
                if (_education != value)
                {
                    _education = value;
                    Notify("Education");
                }
            }
        }
        public string Religion
        {
            get { return _religion; }
            set
            {
                if (_religion != value)
                {
                    _religion = value;
                    Notify("Religion");
                }
            }
        }
        public byte A
        {
            get { return _a; }
            set
            {
                if (_a != value)
                {
                    _a = value;
                    Notify("A");
                }
            }
        }
        public byte B1
        {
            get { return _b1; }
            set
            {
                if (_b1 != value)
                {
                    _b1 = value;
                    Notify("B1");
                }
            }
        }
        public byte B2
        {
            get { return _b2; }
            set
            {
                if (_b2 != value)
                {
                    _b2 = value;
                    Notify("B2");
                }
            }
        }
        public byte C1
        {
            get { return _c1; }
            set
            {
                if (_c1 != value)
                {
                    _c1 = value;
                    Notify("C1");
                }
            }
        }
        public byte C2
        {
            get { return _c2; }
            set
            {
                if (_c2 != value)
                {
                    _c2 = value;
                    Notify("C2");
                }
            }
        }
        public byte C3
        {
            get { return _c3; }
            set
            {
                if (_c3 != value)
                {
                    _c3 = value;
                    Notify("C3");
                }
            }
        }
        public byte C4
        {
            get { return _c4; }
            set
            {
                if (_c4 != value)
                {
                    _c4 = value;
                    Notify("C4");
                }
            }
        }
        public byte D1
        {
            get { return _d1; }
            set
            {
                if (_d1 != value)
                {
                    _d1 = value;
                    Notify("D1");
                }
            }
        }
        public byte D2
        {
            get { return _d2; }
            set
            {
                if (_d2 != value)
                {
                    _d2 = value;
                    Notify("D2");
                }
            }
        }
        public byte D3
        {
            get { return _d3; }
            set
            {
                if (_d3 != value)
                {
                    _d3 = value;
                    Notify("D3");
                }
            }
        }
        public byte D4
        {
            get { return _d4; }
            set
            {
                if (_d4 != value)
                {
                    _d4 = value;
                    Notify("D4");
                }
            }
        }
        public string JobExperience
        {
            get { return _jobExperience; }
            set
            {
                if (_jobExperience != value)
                {
                    _jobExperience = value;
                    Notify("JobExperience");
                }
            }
        }
        public string Eligibility
        {
            get { return _eligibility; }
            set
            {
                if (_eligibility != value)
                {
                    _eligibility = value;
                    Notify("Eligibility");
                }
            }
        }
        public string Remarks
        {
            get { return _remarks; }
            set
            {
                if (_remarks != value)
                {
                    _remarks = value;
                    Notify("Remarks");
                }
            }
        }
        public string Recommendation
        {
            get { return _recommendation; }
            set
            {
                if (_recommendation != value)
                {
                    _recommendation = value;
                    Notify("Recommendation");
                }
            }
        }
        public string Psychiatric
        {
            get { return _psychiatric; }
            set
            {
                if (_psychiatric != value)
                {
                    _psychiatric = value;
                    Notify("Psychiatric");
                }
            }
        }
        public byte GeneralAppearance
        {
            get { return _generalAppearance; }
            set
            {
                if (_generalAppearance != value)
                {
                    _generalAppearance = value;
                    Notify("GeneralAppearance");
                }
            }
        }
        public byte Attitude
        {
            get { return _attitude; }
            set
            {
                if (_attitude != value)
                {
                    _attitude = value;
                    Notify("Attitude");
                }
            }
        }
        public byte Memory
        {
            get { return _memory; }
            set
            {
                if (_memory != value)
                {
                    _memory = value;
                    Notify("Memory");
                }
            }
        }
        public byte Speech
        {
            get { return _speech; }
            set
            {
                if (_speech != value)
                {
                    _speech = value;
                    Notify("Speech");
                }
            }
        }
        public byte AffectAndMood
        {
            get { return _affectAndMood; }
            set
            {
                if (_affectAndMood != value)
                {
                    _affectAndMood = value;
                    Notify("AffectAndMood");
                }
            }
        }
        public byte ThoughtContent
        {
            get { return _thoughtContent; }
            set
            {
                if (_thoughtContent != value)
                {
                    _thoughtContent = value;
                    Notify("ThoughtContent");
                }
            }
        }
        public byte Suicidality
        {
            get { return _suicidality; }
            set
            {
                if (_suicidality != value)
                {
                    _suicidality = value;
                    Notify("Suicidality");
                }
            }
        }
        public byte PreOccupations
        {
            get { return _preOccupations; }
            set
            {
                if (_preOccupations != value)
                {
                    _preOccupations = value;
                    Notify("PreOccupations");
                }
            }
        }
        public byte CognitionThinking
        {
            get { return _cognitionThinking; }
            set
            {
                if (_cognitionThinking != value)
                {
                    _cognitionThinking = value;
                    Notify("CognitionThinking");
                }
            }
        }
        public byte Halucination
        {
            get { return _halucination; }
            set
            {
                if (_halucination != value)
                {
                    _halucination = value;
                    Notify("Halucination");
                }
            }
        }
        public string Psychometrician
        {
            get { return _psychometrician; }
            set
            {
                if (_psychometrician != value)
                {
                    _psychometrician = value;
                    Notify("Psychometrician");
                }
            }
        }
        public string Psychiatrist
        {
            get { return _psychiatrist; }
            set
            {
                if (_psychiatrist != value)
                {
                    _psychiatrist = value;
                    Notify("Psychiatrist");
                }
            }
        }
        public string CreatedBy
        {
            get { return _createdBy; }
            set
            {
                if (_createdBy != value)
                {
                    _createdBy = value;
                    Notify("CreatedBy");
                }
            }
        }
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                {
                    _dateCreated = value;
                    Notify("DateCreated");
                }
            }
        }
        public string UpdatedBy
        {
            get { return _updatedBy; }
            set
            {
                if (_updatedBy != value)
                {
                    _updatedBy = value;
                    Notify("UpdatedBy");
                }
            }
        }
        public DateTime DateUpdated
        {
            get { return _dateUpdated; }
            set
            {
                if (_dateUpdated != value)
                {
                    _dateUpdated = value;
                    Notify("DateUpdated");
                }
            }
        }
    }
}
