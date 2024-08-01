using System;


namespace CMDLWpf
{
    public class Test_Pregnancy: NotifyPropertyChanged
    {
        private ulong _testID;
        private string _controlNo;
        private string _result;
        private string _remarks;
        private string _note;
        private string _medTech;
        private string _medtechTitle;
        private string _pathologist;
        private string _pathologistTitle;
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
        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    Notify("Result");
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
        public string MedTech
        {
            get { return _medTech; }
            set
            {
                if (_medTech != value)
                {
                    _medTech = value;
                    Notify("MedTech");
                }
            }
        }
        public string MedtechTitle
        {
            get { return _medtechTitle; }
            set
            {
                if (_medtechTitle != value)
                {
                    _medtechTitle = value;
                    Notify("MedtechTitle");
                }
            }
        }
        public string Pathologist
        {
            get { return _pathologist; }
            set
            {
                if (_pathologist != value)
                {
                    _pathologist = value;
                    Notify("Pathologist");
                }
            }
        }
        public string PathologistTitle
        {
            get { return _pathologistTitle; }
            set
            {
                if (_pathologistTitle != value)
                {
                    _pathologistTitle = value;
                    Notify("PathologistTitle");
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
