using CMDL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL.Models
{
    public class NeuroItemV2 : NotifyPropertyChanged
    {
        private bool isSelected;
        private bool version1;
        private bool version2;
        private bool version3;
        private string status;
        private ClientV2 client;

        public ClientV2 Client
        {
            get { return client; }
            set
            {
                if (client != value)
                {
                    client = value;
                    OnPropertyChanged(nameof(Client));
                }
            }
        }
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }
        public bool Version3
        {
            get { return version3; }
            set
            {
                version3 = value;
                OnPropertyChanged(nameof(Version3));
                SetStatus();
            }
        }
        public bool Version2
        {
            get { return version2; }
            set
            {
                version2 = value;
                OnPropertyChanged(nameof(Version2));
                SetStatus();
            }
        }
        public bool Version1
        {
            get { return version1; }
            set
            {
                version1 = value;
                OnPropertyChanged(nameof(Version1));
                SetStatus();
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }
        private bool isDraft;

        public bool IsDraft
        {
            get { return isDraft; }
            set
            {
                if (isDraft != value)
                {
                    isDraft = value;
                    OnPropertyChanged(nameof(IsDraft));
                    SetStatus();
                }
            }
        }



        private void SetStatus()
        {
            if (Version1 || Version2)
            {
                Status = "DONE";
            }
            else if (Version3)
            {
                if (isDraft)
                {
                    Status = "NOT DONE";
                }
                else
                {
                    Status = "DONE";
                }
            }
            else
            {
                Status = "NOT DONE";
            }

        }

    }
}
