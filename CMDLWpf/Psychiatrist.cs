using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDLWpf
{
    public class Psychiatrist
    {
        private string _name;
        private string _title;
        private bool _isAvailable;

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
    }
}
