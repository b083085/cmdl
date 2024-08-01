using System;


namespace CMDLWpf
{
    public class Test_Fecalysis : NotifyPropertyChanged
    {
        private ulong _testID;
        private string _controlNo;
        private string _consistency;
        private string _color;
        private string _leukocytes;
        private string _erythrocytes;
        private string _fatGlobules;
        private string _yeastCells;
        private string _ovaOfParasite;
        private string _protozoan;
        private string _occultBlood;
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
        public string Consistency
        {
            get { return _consistency; }
            set
            {
                if (_consistency != value)
                {
                    _consistency = value;
                    Notify("Consistency");
                }
            }
        }
        public string Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    Notify("Color");
                }
            }
        }
        public string Leukocytes
        {
            get { return _leukocytes; }
            set
            {
                if (_leukocytes != value)
                {
                    _leukocytes = value;
                    Notify("Leukocytes");
                }
            }
        }
        public string Erythrocytes
        {
            get { return _erythrocytes; }
            set
            {
                if (_erythrocytes != value)
                {
                    _erythrocytes = value;
                    Notify("Erythrocytes");
                }
            }
        }
        public string FatGlobules
        {
            get { return _fatGlobules; }
            set
            {
                if (_fatGlobules != value)
                {
                    _fatGlobules = value;
                    Notify("FatGlobules");
                }
            }
        }
        public string YeastCells
        {
            get { return _yeastCells; }
            set
            {
                if (_yeastCells != value)
                {
                    _yeastCells = value;
                    Notify("YeastCells");
                }
            }
        }
        public string OvaOfParasite
        {
            get { return _ovaOfParasite; }
            set
            {
                if (_ovaOfParasite != value)
                {
                    _ovaOfParasite = value;
                    Notify("OvaOfParasite");
                }
            }
        }
        public string Protozoan
        {
            get { return _protozoan; }
            set
            {
                if (_protozoan != value)
                {
                    _protozoan = value;
                    Notify("Protozoan");
                }
            }
        }
        public string OccultBlood
        {
            get { return _occultBlood; }
            set
            {
                if (_occultBlood != value)
                {
                    _occultBlood = value;
                    Notify("OccultBlood");
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
