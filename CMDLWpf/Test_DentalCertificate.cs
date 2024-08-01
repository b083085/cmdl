using System;


namespace CMDLWpf
{
    public class Test_DentalCertificate : NotifyPropertyChanged
    {
        private ulong _testID;
        private string _controlNo;
        private DateTime _dateExamine;
        private string _remarks;
        private string _note;
        private string _dentist;
        private string _dentistTitle;
        private string _licenseNo;
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
        public DateTime DateExamine
        {
            get { return _dateExamine; }
            set
            {
                if (_dateExamine != value)
                {
                    _dateExamine = value;
                    Notify("DateExamine");
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
        public string Note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value;
                    Notify("Note");
                }
            }
        }
        public string Dentist
        {
            get { return _dentist; }
            set
            {
                if (_dentist != value)
                {
                    _dentist = value;
                    Notify("Dentist");
                }
            }
        }
        public string DentistTitle
        {
            get { return _dentistTitle; }
            set
            {
                if (_dentistTitle != value)
                {
                    _dentistTitle = value;
                    Notify("DentistTitle");
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
