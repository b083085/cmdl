using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDLWpf
{
    public class Test_XRay : NotifyPropertyChanged
    {
        private ulong _testID;
        private string _controlNo;
        private string _filmNo;
        private string _marker;
        private string _radioReport;
        private string _remarks;
        private string _preparedBy;
        private string _radiologist;
        private string _radTitle;

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
        public string Marker
        {
            get { return _marker; }
            set
            {
                if (_marker != value)
                {
                    _marker = value;
                    Notify("Marker");
                }
            }
        }
        public string RadioReport
        {
            get { return _radioReport; }
            set
            {
                if (_radioReport != value)
                {
                    _radioReport = value;
                    Notify("RadioReport");
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
        public string PreparedBy
        {
            get { return _preparedBy; }
            set
            {
                if (_preparedBy != value)
                {
                    _preparedBy = value;
                    Notify("PreparedBy");
                }
            }
        }
        public string Radiologist
        {
            get { return _radiologist; }
            set
            {
                if (_radiologist != value)
                {
                    _radiologist = value;
                    Notify("Radiologist");
                }
            }
        }
        public string RadTitle
        {
            get { return _radTitle; }
            set
            {
                if (_radTitle != value)
                {
                    _radTitle = value;
                    Notify("RadTitle");
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
