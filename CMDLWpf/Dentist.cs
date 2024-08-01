using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDLWpf
{
    public class Dentist
    {
        private string _name;
        private string _title;
        private bool _isAvailable;
        private string _licenseNo;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }
        public string LicenseNo
        {
            get { return _licenseNo; }
            set { _licenseNo = value; }
        }
    }
}
