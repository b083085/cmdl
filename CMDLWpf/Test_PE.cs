using System;

namespace CMDLWpf
{

    public class Test_PE : NotifyPropertyChanged
    {  
      
        #region PRIVATE
        private ulong _testID;
        private string _controlNo;
        private string _natureOfWork;
        private string _growthDevelopment;
        private string _bp;
        private string _hr;
        private string _pr;
        private string _ft;
        private string _inch;
        private string _weight;
        private string _eyes;
        private string _od;
        private string _os;
        private string _ishihara;
        private string _ears;
        private string _noseThroat;
        private string _dental;
        private string _breast;
        private string _extremities;
        private string _neurolog;
        private string _heart;
        private string _lungs;
        private string _abdomen;
        private string _genitalia;
        private string _anorectal;
        private string _skin;
        private string _otherBodyParts;
        private string _pastMedicalHistory;
        private char _cxrExist;
        private DateTime _cxrDate;
        private string _filmNo;
        private char _cxrNegative;
        private string _cxrFindings;
        private string _cbc;
        private string _urine;
        private string _stool;
        private string _bloodChemistry;
        private string _pregnancyTest;
        private string _vdrl;
        private string _hepA;
        private string _hepB;
        private string _hiv;
        private string _drugTest;
        private string _bloodType;
        private string _otherTest;
        private string _neuroPsychology;
        private string _neuroPsychiatric;
        private string _remarks;
        private string _recommendation;
        private string _recommendationNote;
        private string _refBy;
        private string _countryOfDestination;
        private DateTime _dateOfDeployment;
        private DateTime _dateOfRepatriation;
        private string _causesOfRepatriation;
        private string _finalDiagnosis;
        private string _vesselType;
        private string _seaTrade;
        private string _workType;
        private string _physician;
        private string _title;
        private string _licenseNo;
        private string _createdBy;
        private DateTime _dateCreated;
        private string _updatedBy;
        private DateTime _dateUpdated;
        #endregion

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
        public string NatureOfWork
        {
            get { return _natureOfWork; }
            set
            {
                if (_natureOfWork != value)
                {
                    _natureOfWork = value;
                    Notify("NatureOfWork");
                }
            }
        }
        public string GrowthDevelopment
        {
            get { return _growthDevelopment; }
            set
            {
                if (_growthDevelopment != value)
                {
                    _growthDevelopment = value;
                    Notify("GrowthDevelopment");
                }
            }
        }
        public string Bp
        {
            get { return _bp; }
            set
            {
                if (_bp != value)
                {
                    _bp = value;
                    Notify("Bp");
                }
            }
        }
        public string Hr
        {
            get { return _hr; }
            set
            {
                if (_hr != value)
                {
                    _hr = value;
                    Notify("Hr");
                }
            }
        }
        public string Pr
        {
            get { return _pr; }
            set
            {
                if (_pr != value)
                {
                    _pr = value;
                    Notify("Pr");
                }
            }
        }
        public string Ft
        {
            get { return _ft; }
            set
            {
                if (_ft != value)
                {
                    _ft = value;
                    Notify("Ft");
                }
            }
        }
        public string Inch
        {
            get { return _inch; }
            set
            {
                if (_inch != value)
                {
                    _inch = value;
                    Notify("Inch");
                }
            }
        }
        public string Weight
        {
            get { return _weight; }
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    Notify("Weight");
                }
            }
        }
        public string Eyes
        {
            get { return _eyes; }
            set
            {
                if (_eyes != value)
                {
                    _eyes = value;
                    Notify("Eyes");
                }
            }
        }
        public string Od
        {
            get { return _od; }
            set
            {
                if (_od != value)
                {
                    _od = value;
                    Notify("Od");
                }
            }
        }
        public string Os
        {
            get { return _os; }
            set
            {
                if (_os != value)
                {
                    _os = value;
                    Notify("Os");
                }
            }
        }
        public string Ishihara
        {
            get { return _ishihara; }
            set
            {
                if (_ishihara != value)
                {
                    _ishihara = value;
                    Notify("Ishihara");
                }
            }
        }
        public string Ears
        {
            get { return _ears; }
            set
            {
                if (_ears != value)
                {
                    _ears = value;
                    Notify("Ears");
                }
            }
        }
        public string NoseThroat
        {
            get { return _noseThroat; }
            set
            {
                if (_noseThroat != value)
                {
                    _noseThroat = value;
                    Notify("NoseThroat");
                }
            }
        }
        public string Dental
        {
            get { return _dental; }
            set
            {
                if (_dental != value)
                {
                    _dental = value;
                    Notify("Dental");
                }
            }
        }
        public string Breast
        {
            get { return _breast; }
            set
            {
                if (_breast != value)
                {
                    _breast = value;
                    Notify("Breast");
                }
            }
        }
        public string Extremities
        {
            get { return _extremities; }
            set
            {
                if (_extremities != value)
                {
                    _extremities = value;
                    Notify("Extremities");
                }
            }
        }
        public string Neurolog
        {
            get { return _neurolog; }
            set
            {
                if (_neurolog != value)
                {
                    _neurolog = value;
                    Notify("Neurolog");
                }
            }
        }
        public string Heart
        {
            get { return _heart; }
            set
            {
                if (_heart != value)
                {
                    _heart = value;
                    Notify("Heart");
                }
            }
        }
        public string Lungs
        {
            get { return _lungs; }
            set
            {
                if (_lungs != value)
                {
                    _lungs = value;
                    Notify("Lungs");
                }
            }
        }
        public string Abdomen
        {
            get { return _abdomen; }
            set
            {
                if (_abdomen != value)
                {
                    _abdomen = value;
                    Notify("Abdomen");
                }
            }
        }
        public string Genitalia
        {
            get { return _genitalia; }
            set
            {
                if (_genitalia != value)
                {
                    _genitalia = value;
                    Notify("Genitalia");
                }
            }
        }
        public string Anorectal
        {
            get { return _anorectal; }
            set
            {
                if (_anorectal != value)
                {
                    _anorectal = value;
                    Notify("Anorectal");
                }
            }
        }
        public string Skin
        {
            get { return _skin; }
            set
            {
                if (_skin != value)
                {
                    _skin = value;
                    Notify("Skin");
                }
            }
        }
        public string OtherBodyParts
        {
            get { return _otherBodyParts; }
            set
            {
                if (_otherBodyParts != value)
                {
                    _otherBodyParts = value;
                    Notify("OtherBodyParts");
                }
            }
        }
        public string PastMedicalHistory
        {
            get { return _pastMedicalHistory; }
            set
            {
                if (_pastMedicalHistory != value)
                {
                    _pastMedicalHistory = value;
                    Notify("PastMedicalHistory");
                }
            }
        }
        public char CxrExist
        {
            get { return _cxrExist; }
            set
            {
                if (_cxrExist != value)
                {
                    _cxrExist = value;
                    Notify("CxrExist");
                }
            }
        }
        public DateTime CxrDate
        {
            get { return _cxrDate; }
            set
            {
                if (_cxrDate != value)
                {
                    _cxrDate = value;
                    Notify("CxrDate");
                }
            }
        }
        public string FilmNo
        {
            get { return _filmNo; }
            set
            {
                if (_filmNo != value)
                {
                    _filmNo = value;
                    Notify("FilmNo");
                }
            }
        }
        public char CxrNegative
        {
            get { return _cxrNegative; }
            set
            {
                if (_cxrNegative != value)
                {
                    _cxrNegative = value;
                    Notify("CxrNegative");
                }
            }
        }
        public string CxrFindings
        {
            get { return _cxrFindings; }
            set
            {
                if (_cxrFindings != value)
                {
                    _cxrFindings = value;
                    Notify("CxrFindings");
                }
            }
        }
        public string Cbc
        {
            get { return _cbc; }
            set
            {
                if (_cbc != value)
                {
                    _cbc = value;
                    Notify("Cbc");
                }
            }
        }
        public string Urine
        {
            get { return _urine; }
            set
            {
                if (_urine != value)
                {
                    _urine = value;
                    Notify("Urine");
                }
            }
        }
        public string Stool
        {
            get { return _stool; }
            set
            {
                if (_stool != value)
                {
                    _stool = value;
                    Notify("Stool");
                }
            }
        }
        public string BloodChemistry
        {
            get { return _bloodChemistry; }
            set
            {
                if (_bloodChemistry != value)
                {
                    _bloodChemistry = value;
                    Notify("BloodChemistry");
                }
            }
        }
        public string PregnancyTest
        {
            get { return _pregnancyTest; }
            set
            {
                if (_pregnancyTest != value)
                {
                    _pregnancyTest = value;
                    Notify("PregnancyTest");
                }
            }
        }
        public string Vdrl
        {
            get { return _vdrl; }
            set
            {
                if (_vdrl != value)
                {
                    _vdrl = value;
                    Notify("Vdrl");
                }
            }
        }
        public string HepA
        {
            get { return _hepA; }
            set
            {
                if (_hepA != value)
                {
                    _hepA = value;
                    Notify("HepA");
                }
            }
        }
        public string HepB
        {
            get { return _hepB; }
            set
            {
                if (_hepB != value)
                {
                    _hepB = value;
                    Notify("HepB");
                }
            }
        }
        public string Hiv
        {
            get { return _hiv; }
            set
            {
                if (_hiv != value)
                {
                    _hiv = value;
                    Notify("Hiv");
                }
            }
        }
        public string DrugTest
        {
            get { return _drugTest; }
            set
            {
                if (_drugTest != value)
                {
                    _drugTest = value;
                    Notify("DrugTest");
                }
            }
        }
        public string BloodType
        {
            get { return _bloodType; }
            set
            {
                if (_bloodType != value)
                {
                    _bloodType = value;
                    Notify("BloodType");
                }
            }
        }
        public string OtherTest
        {
            get { return _otherTest; }
            set
            {
                if (_otherTest != value)
                {
                    _otherTest = value;
                    Notify("OtherTest");
                }
            }
        }
        public string NeuroPsychology
        {
            get { return _neuroPsychology; }
            set
            {
                if (_neuroPsychology != value)
                {
                    _neuroPsychology = value;
                    Notify("NeuroPsychology");
                }
            }
        }
        public string NeuroPsychiatric
        {
            get { return _neuroPsychiatric; }
            set
            {
                if (_neuroPsychiatric != value)
                {
                    _neuroPsychiatric = value;
                    Notify("NeuroPsychiatric");
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
        public string RecommendationNote
        {
            get { return _recommendationNote; }
            set
            {
                if (_recommendationNote != value)
                {
                    _recommendationNote = value;
                    Notify("RecommendationNote");
                }
            }
        }
        public string RefBy
        {
            get { return _refBy; }
            set
            {
                if (_refBy != value)
                {
                    _refBy = value;
                    Notify("RefBy");
                }
            }
        }
        public string CountryOfDestination
        {
            get { return _countryOfDestination; }
            set
            {
                if (_countryOfDestination != value)
                {
                    _countryOfDestination = value;
                    Notify("CountryOfDestination");
                }
            }
        }
        public DateTime DateOfDeployment
        {
            get { return _dateOfDeployment; }
            set
            {
                if (_dateOfDeployment != value)
                {
                    _dateOfDeployment = value;
                    Notify("DateOfDeployment");
                }
            }
        }
        public DateTime DateOfRepatriation
        {
            get { return _dateOfRepatriation; }
            set
            {
                if (_dateOfRepatriation != value)
                {
                    _dateOfRepatriation = value;
                    Notify("DateOfRepatriation");
                }
            }
        }
        public string CausesOfRepatriation
        {
            get { return _causesOfRepatriation; }
            set
            {
                if (_causesOfRepatriation != value)
                {
                    _causesOfRepatriation = value;
                    Notify("CausesOfRepatriation");
                }
            }
        }
        public string FinalDiagnosis
        {
            get { return _finalDiagnosis; }
            set
            {
                if (_finalDiagnosis != value)
                {
                    _finalDiagnosis = value;
                    Notify("FinalDiagnosis");
                }
            }
        }
        public string VesselType
        {
            get { return _vesselType; }
            set
            {
                if (_vesselType != value)
                {
                    _vesselType = value;
                    Notify("VesselType");
                }
            }
        }
        public string SeaTrade
        {
            get { return _seaTrade; }
            set
            {
                if (_seaTrade != value)
                {
                    _seaTrade = value;
                    Notify("SeaTrade");
                }
            }
        }
        public string WorkType
        {
            get { return _workType; }
            set
            {
                if (_workType != value)
                {
                    _workType = value;
                    Notify("WorkType");
                }
            }
        }
        public string Physician
        {
            get { return _physician; }
            set
            {
                if (_physician != value)
                {
                    _physician = value;
                    Notify("Physician");
                }
            }
        }
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    Notify("Title");
                }
            }
        }
        public string LicenseNo
        {
            get { return _licenseNo; }
            set
            {
                if (_licenseNo != value)
                {
                    _licenseNo = value;
                    Notify("LicenseNo");
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
