using System;


namespace CMDLWpf
{
    public class Test_Serology_Item : NotifyPropertyChanged
    {
        private ulong _itemID;
        private ulong _testID;
        private string _test;
        private string _result;
        private string _kit;
        private string _lotno;
        private DateTime _exp;
        private string _recommendation;
        private string _note;

        public ulong ItemID
        {
            get { return _itemID; }
            set
            {
                if (_itemID != value)
                {
                    _itemID = value;
                    Notify("ItemID");
                }
            }
        }
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
        public string Test
        {
            get { return _test; }
            set
            {
                if (_test != value)
                {
                    _test = value;
                    Notify("Test");
                }
            }
        }
        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    Notify("Result");
                }
            }
        }
        public string Kit
        {
            get { return _kit; }
            set
            {
                if (_kit != value)
                {
                    _kit = value;
                    Notify("Kit");
                }
            }
        }
        public string Lotno
        {
            get { return _lotno; }
            set
            {
                if (_lotno != value)
                {
                    _lotno = value;
                    Notify("Lotno");
                }
            }
        }
        public DateTime Exp
        {
            get { return _exp; }
            set
            {
                if (_exp != value)
                {
                    _exp = value;
                    Notify("Exp");
                }
            }
        }
        public string Recommendation
        {
            get { return _recommendation; }
            set
            {
                if (_recommendation != value)
                {
                    _recommendation = value;
                    Notify("Recommendation");
                }
            }
        }
        public string Note
        {
            get { return _note; }
            set
            {
                if (_note != value)
                {
                    _note = value;
                    Notify("Note");
                }
            }
        }

    }
}
