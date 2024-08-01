using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using CMDLWpf;

namespace CMDL
{
    public class SearchClientInfo : NotifyPropertyChanged
    {
        private string _controlNo;
        private DateTime _dateRegistered;
        private byte[] _photo;
        private string _lastname;
        private string _firstname;
        private string _mi;
        private string _suffix;
        private string _address;
        private string _age;
        private string _gender;
        private string _civilStatus;
        private DateTime _birthDate;
        private string _birthPlace;
        private string _requestingParty;
        private string _purpose;
        private string _telephoneNo;
        private string _mobileNo;
        private string _districtBranch;
        private List<Examination> _examinationList = new List<Examination>();
        private double _total;
        private double _amountPaid;
        private double _amountBalance;
        private double _amountChange;
        private DateTime _timeIn;
        private DateTime _timeOut;
        private string _examType;
        private string _fullName;
        private string _status;
        private int _totalTestToEncode;






        private Test_BloodChemistry _bloodChemistry;
        private Test_BloodTyping _bloodTyping;
        private Test_CultureAndSensitivity _cultureAndSensitivity;
        private Test_Fecalysis _fecalysis;
        private Test_GramStaining _gramStaining;
        private Test_Hematology _hematology;
        private Test_Neuro _Neuro;
        private Test_PE _PhysicalExamination;
        private Test_Pregnancy _PregnancyTest;
        private Test_Serology _serology;
        private Test_Urinalysis _urinalysis;
        private List<Test_XRay> _xray;
        private Test_MedicalCertificate _medicalCertificate;
        private Test_DentalCertificate _dentalCertificate;

        public string Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    Notify("Status");
                }
            }
        }
        public string FullName
        {
            get
            {
                _fullName = String.Concat(_lastname, ", ", Firstname, " ", _mi, " ", _suffix);
                return _fullName;
            }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    Notify("FullName");
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
        public DateTime DateRegistered
        {
            get { return _dateRegistered; }
            set
            {
                if (_dateRegistered != value)
                {
                    _dateRegistered = value;
                    Notify("DateRegistered");
                }
            }
        }
        public byte[] Photo
        {
            get { return _photo; }
            set
            {
                if (_photo != value)
                {
                    _photo = value;
                    Notify("Photo");
                }
            }
        }
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    Notify("Lastname");
                }
            }
        }
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    Notify("Firstname");
                }
            }
        }
        public string Mi
        {
            get { return _mi; }
            set
            {
                if (_mi != value)
                {
                    _mi = value;
                    Notify("Mi");
                }
            }
        }
        public string Suffix
        {
            get { return _suffix; }
            set
            {
                if (_suffix != value)
                {
                    _suffix = value;
                    Notify("Suffix");
                }
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    Notify("Address");
                }
            }
        }
        public string Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    Notify("Age");
                }
            }
        }
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    Notify("Gender");
                }
            }
        }
        public string CivilStatus
        {
            get { return _civilStatus; }
            set
            {
                if (_civilStatus != value)
                {
                    _civilStatus = value;
                    Notify("CivilStatus");
                }
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    Notify("BirthDate");
                }
            }
        }
        public string BirthPlace
        {
            get { return _birthPlace; }
            set
            {
                if (_birthPlace != value)
                {
                    _birthPlace = value;
                    Notify("BirthPlace");
                }
            }
        }
        public string RequestingParty
        {
            get { return _requestingParty; }
            set
            {
                if (_requestingParty != value)
                {
                    _requestingParty = value;
                    Notify("RequestingParty");
                }
            }
        }
        public string Purpose
        {
            get { return _purpose; }
            set
            {
                if (_purpose != value)
                {
                    _purpose = value;
                    Notify("Purpose");
                }
            }
        }
        public string TelephoneNo
        {
            get { return _telephoneNo; }
            set
            {
                if (_telephoneNo != value)
                {
                    _telephoneNo = value;
                    Notify("TelephoneNo");
                }
            }
        }
        public string MobileNo
        {
            get { return _mobileNo; }
            set
            {
                if (_mobileNo != value)
                {
                    _mobileNo = value;
                    Notify("MobileNo");
                }
            }
        }
        public string DistrictBranch
        {
            get { return _districtBranch; }
            set
            {
                if (_districtBranch != value)
                {
                    _districtBranch = value;
                    Notify("DistrictBranch");
                }
            }
        }
        public List<Examination> ExaminationList
        {
            get { return _examinationList; }
        }
        public double Total
        {
            get { return _total; }
            set
            {
                if (_total != value)
                {
                    _total = value;
                    Notify("Total");
                }
            }
        }
        public double AmountPaid
        {
            get { return _amountPaid; }
            set
            {
                if (_amountPaid != value)
                {
                    _amountPaid = value;
                    Notify("AmountPaid");
                }
            }
        }
        public double AmountBalance
        {
            get { return _amountBalance; }
            set
            {
                if (_amountBalance != value)
                {
                    _amountBalance = value;
                    Notify("AmountBalance");
                }
            }
        }
        public double AmountChange
        {
            get { return _amountChange; }
            set
            {
                if (_amountChange != value)
                {
                    _amountChange = value;
                    Notify("AmountChange");
                }
            }
        }
        public DateTime TimeIn
        {
            get { return _timeIn; }
            set
            {
                if (_timeIn != value)
                {
                    _timeIn = value;
                    Notify("TimeIn");
                }
            }
        }
        public DateTime TimeOut
        {
            get { return _timeOut; }
            set
            {
                if (_timeOut != value)
                {
                    _timeOut = value;
                    Notify("TimeOut");
                }
            }
        }
        public string ExamType
        {
            get { return _examType; }
            set
            {
                if (_examType != value)
                {
                    _examType = value;
                    Notify("ExamType");
                }
            }
        }
        public int TotalTestToEncode
        {
            get { return _totalTestToEncode; }
            set
            {
                if (_totalTestToEncode != value)
                {
                    _totalTestToEncode = value;
                    Notify("TotalTestToEncode");
                }

                if (_totalTestToEncode > 0)
                    Status = "NOT DONE";
                else
                    Status = "DONE";
            }
        }

        public Test_BloodChemistry BloodChemistry
        {
            get { return _bloodChemistry; }
            set { _bloodChemistry = value; }
        }
        public Test_BloodTyping BloodTyping
        {
            get { return _bloodTyping; }
            set { _bloodTyping = value; }
        }
        public Test_CultureAndSensitivity CultureAndSensitivity
        {
            get { return _cultureAndSensitivity; }
            set { _cultureAndSensitivity = value; }
        }
        public Test_Fecalysis Fecalysis
        {
            get { return _fecalysis; }
            set { _fecalysis = value; }
        }
        public Test_GramStaining GramStaining
        {
            get { return _gramStaining; }
            set { _gramStaining = value; }
        }
        public Test_Hematology Hematology
        {
            get { return _hematology; }
            set { _hematology = value; }
        }
        public Test_Neuro Neuro
        {
            get { return _Neuro; }
            set { _Neuro = value; }
        }
        public Test_PE PhysicalExamination
        {
            get { return _PhysicalExamination; }
            set { _PhysicalExamination = value; }
        }
        public Test_Pregnancy PregnancyTest
        {
            get { return _PregnancyTest; }
            set { _PregnancyTest = value; }
        }
        public Test_Serology Serology
        {
            get { return _serology; }
            set { _serology = value; }
        }
        public Test_Urinalysis Urinalysis
        {
            get { return _urinalysis; }
            set { _urinalysis = value; }
        }
        public List<Test_XRay> Xray
        {
            get { return _xray; }
            set { _xray = value; }
        }
        public Test_MedicalCertificate MedicalCertificate
        {
            get { return _medicalCertificate; }
            set { _medicalCertificate = value; }
        }
        public Test_DentalCertificate DentalCertificate
        {
            get { return _dentalCertificate; }
            set { _dentalCertificate = value; }
        }
    }
}
