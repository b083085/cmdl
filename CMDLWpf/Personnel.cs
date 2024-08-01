using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDLWpf
{
    public class Personnel
    {
        private uint _id;

        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _isAvailable;

        public string IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }
        private string _licenseNo;

        public string LicenseNo
        {
            get { return _licenseNo; }
            set { _licenseNo = value; }
        }
        private string _department;

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        private byte[] _signature;

        public byte[] Signature
        {
            get { return _signature; }
            set { _signature = value; }
        }
        private byte[] _photo;

        public byte[] Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }


    }
}
