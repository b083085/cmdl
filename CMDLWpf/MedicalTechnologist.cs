using System;


namespace CMDLWpf
{
    public class MedicalTechnologist
    {
        private string _name;
        private string _title;
        private bool _isAvailable;
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

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
