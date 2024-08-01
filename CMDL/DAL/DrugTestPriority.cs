using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CMDL
{
    public class DrugTestPriority : CyberPropertyChanged
    {
        private ulong _drugTestID;
        private int _priorityNo;
        private string _ccfNo;
        private string _status;

        private DateTime _dateRegistered;

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
        private string _controlNo;

        public new string ControlNo
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
        private string _lastName;

        public new string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    Notify("LastName");
                }
            }
        }
        private string _firstName;

        public new string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    Notify("FirstName");
                }
            }
        }
        private string _middleName;

        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    Notify("MiddleName");
                }
            }
        }
        private string _requestingParty;

        public new string RequestingParty
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


        public ulong DrugTestID
        {
            get { return _drugTestID; }
            set
            {
                if (_drugTestID != value)
                {
                    _drugTestID = value;
                    Notify("DrugTestID");
                }
            }
        }
        public new int PriorityNo
        {
            get { return _priorityNo; }
            set
            {
                if (_priorityNo != value)
                {
                    _priorityNo = value;
                    Notify("PriorityNo");
                }
            }
        }
        public string CcfNo
        {
            get { return _ccfNo; }
            set
            {
                if (_ccfNo != value)
                {
                    _ccfNo = value;
                    Notify("CcfNo");
                }
            }
        }
        public new string Status
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


    }
}
