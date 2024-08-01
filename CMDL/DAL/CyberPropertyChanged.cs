using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;

namespace CMDL
{
    public class CyberPropertyChanged:INotifyPropertyChanged
    {

        #region Inotifypropertychanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private bool select;
        private string status;
        private string _lastname;
        private string _firstname;
        private string _mi;
        private string _suffix;
        private string _fullName;
        private int _priorityNo;

        public bool Select
        {
            get
            {
                return select;
            }
            set
            {
                if (value != select)
                {
                    select = value;
                    Notify("Select");
                }
            }
        }

        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                if (value != status)
                {
                    status = value;
                    Notify("Status");
                }
            }
        }

        public string TimeIn
        {
            get;
            set;
        }

        public ImageSource Photo
        {
            get;
            set;
        }

        public string ControlNo
        {
            set;
            get;
        }

        public string LastName
        {
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
                    Notify("LastName");
                }
            }
            get
            {
                return _lastname;
            }
        }

        public string FirstName
        {
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    Notify("FirstName");
                }
            }
            get
            {
                return _firstname;
            }
        }

        public string MI
        {
            set
            {
                if (_mi != value)
                {
                    _mi = value;
                    Notify("MI");
                }
            }
            get
            {
                return _mi;
            }
        }

        public string Suffix
        {
            set
            {
                if (_suffix != value)
                {
                    _suffix = value;
                    Notify("Suffix");
                }
            }
            get
            {
                return _suffix;
            }
        }

        public string FullName
        {
            set
            {
                if(_fullName != value)
                {
                    _fullName = value;
                    Notify("FullName");
                }
            }
            get
            {
                _fullName = String.Concat(LastName,", ",FirstName," ",MI," ",Suffix);
                return _fullName;
            }
        }

        public string Age
        {
            get;
            set;
        }

        public string Sex
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Exam
        {
            set;
            get;
        }

        public string RequestingParty
        {
            set;
            get;
        }

        public string DistrictBranch
        {
            set;
            get;
        }

        public string CivilStatus
        {
            set;
            get;
        }

        public int PriorityNo
        {
            get
            {
                return _priorityNo;
            }
            set
            {
                if (value != _priorityNo)
                {
                    _priorityNo = value;
                    Notify("PriorityNo");
                }
            }
        }
    }
}
