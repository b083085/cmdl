using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDLWpf
{
    public class Test_Serology : NotifyPropertyChanged
    {
        private ulong _testID;
        private string _controlNo;
        private string _medTech;
        private string _pathologist;
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
        public bool objectExist
        {
            set;
            get;
        }

        private List<Test_Serology_Item> _itemList = new List<Test_Serology_Item>();
        public List<Test_Serology_Item> ItemList
        {
            get { return _itemList; }
        }

    }
}
