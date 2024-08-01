using CMDL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CMDL.Models
{
    public class ClientV2 : NotifyPropertyChanged
    {
        private ImageSource photo;
        private DateTime? timeIn;
        private string requestingParty;
        private string purpose;
        private string homeAddress;
        private string gender;
        private int age;
        private string fullName;



        private string lastName;
        private string firstName;
        private string middleInitial;
        private string extName;
        private string controlNo;

        public string ControlNo
        {
            get { return controlNo; }
            set
            {
                controlNo = value;
                OnPropertyChanged(nameof(ControlNo));
            }
        }
        public string ExtName
        {
            get { return extName; }
            set
            {
                extName = value;
                OnPropertyChanged(nameof(ExtName));
                SetFullName();
            }
        }
        public string MiddleInitial
        {
            get { return middleInitial; }
            set
            {
                middleInitial = value;
                OnPropertyChanged(nameof(MiddleInitial));
                SetFullName();
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
                SetFullName();
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
                SetFullName();
            }
        }
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string HomeAddress
        {
            get { return homeAddress; }
            set
            {
                homeAddress = value;
                OnPropertyChanged(nameof(HomeAddress));
            }
        }
        public string Purpose
        {
            get { return purpose; }
            set
            {
                purpose = value;
                OnPropertyChanged(nameof(Purpose));
            }
        }
        public string RequestingParty
        {
            get { return requestingParty; }
            set
            {
                requestingParty = value;
                OnPropertyChanged(nameof(RequestingParty));
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }
        public string Gender
        {
            get { return gender; }
            set
            {
                if (gender != value)
                {
                    gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }
        public DateTime? TimeIn
        {
            get { return timeIn; }
            set
            {
                if (timeIn != value)
                {
                    timeIn = value;
                    OnPropertyChanged(nameof(TimeIn));
                }
            }
        }
        public ImageSource Photo
        {
            get { return photo; }
            set
            {
                photo = value;
                OnPropertyChanged(nameof(Photo));
            }
        }

        private void SetFullName()
        {
            FullName = $"{lastName}, {firstName}";
            if (!string.IsNullOrEmpty(middleInitial))
                FullName += $" {middleInitial}";
            if (!string.IsNullOrEmpty(extName))
                FullName += $" {extName}";
        }
    }
}
