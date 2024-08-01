using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace CMDL
{
    public class Serology_Data1 : INotifyPropertyChanged
    {
        #region Inotifypropertychanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        
        public Serology_Data1(bool enabled)
        {
            Enabled = enabled;
        }


        private ObservableCollection<SeroData> seroDataList = new ObservableCollection<SeroData>();
        public ObservableCollection<SeroData> SeroDataList
        {
            get { return seroDataList; }
        }

        private ulong testID;
        private string controlNo;
        private string createdBy;
        private DateTime dateCreated;
        private string updatedBy;
        private DateTime dateUpdated;
        private string pathologist;
        private string medtech;
        private bool enabled;


        public ulong TestID
        {
            get { return testID; }
            set
            {
                if (testID != value)
                {
                    testID = value;
                    Notify("TestID");
                }
            }
        }
        public string ControlNo
        {
            get { return controlNo; }
            set
            {
                if (controlNo != value)
                {
                    controlNo = value;
                    Notify("ControlNo");
                }
            }
        }
        public string CreatedBy
        {
            get { return createdBy; }
            set
            {
                if (createdBy != value)
                {
                    createdBy = value;
                    Notify("CreatedBy");
                }
            }
        }
        public DateTime DateCreated
        {
            get { return dateCreated; }
            set
            {
                if (dateCreated != value)
                {
                    dateCreated = value;
                    Notify("DateCreated");
                }
            }
        }
        public string UpdatedBy
        {
            get { return updatedBy; }
            set
            {
                if (updatedBy != value)
                {
                    updatedBy = value;
                    Notify("UpdatedBy");
                }
            }
        }
        public DateTime DateUpdated
        {
            get { return dateUpdated; }
            set
            {
                if (dateUpdated != value)
                {
                    dateUpdated = value;
                    Notify("DateUpdated");
                }
            }
        }
        public string Pathologist
        {
            get { return pathologist; }
            set
            {
                if (pathologist != value)
                {
                    pathologist = value;
                    Notify("Pathologist");
                }
            }
        }
        public string Medtech
        {
            get { return medtech; }
            set
            {
                if (medtech != value)
                {
                    medtech = value;
                    Notify("Medtech");
                }
            }
        }
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (enabled != value)
                {
                    enabled = value;
                    Notify("Enabled");
                }
            }
        }

    }

    public class SeroData : INotifyPropertyChanged
    {
        #region Inotifypropertychanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string seroType;
        private string test;
        private string result;
        private string testKit;
        private string lotNo;
        private string expiry;
        private string remarks;

        public string SeroType
        {
            get { return seroType; }
            set
            {
                if (seroType != value)
                {
                    seroType = value;
                    Notify("SeroType");
                }
            }
        }
        public string Test
        {
            get { return test; }
            set
            {
                if (test != value)
                {
                    test = value;
                    Notify("Test");
                }
            }
        }
        public string Result
        {
            get { return result; }
            set 
            {
                if (result != value)
                {
                    result = value;
                    Notify("Result");
                }
            }
        }
        public string TestKit
        {
            get { return testKit; }
            set
            {
                if (testKit != value)
                {
                    testKit = value;
                    Notify("TestKit");
                }
            }
        }
        public string LotNo
        {
            get { return lotNo; }
            set
            {
                if (lotNo != value)
                {
                    lotNo = value;
                    Notify("LotNo");
                }
            }
        }
        public string Expiry
        {
            get { return expiry; }
            set
            {
                if (expiry != value)
                {
                    expiry = value;
                    Notify("Expiry");
                }
            }
        }
        public string Remarks
        {
            get { return remarks; }
            set
            {
                if (remarks != value)
                {
                    remarks = value;
                    Notify("Remarks");
                }
            }
        }
    }
}
