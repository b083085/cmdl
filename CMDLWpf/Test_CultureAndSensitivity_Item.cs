using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDLWpf
{
    public class Test_CultureAndSensitivity_Item : NotifyPropertyChanged
    {
        private ulong _itemID;
        private ulong _testID;
        private string _result;
        private string _category;
        private string _count;

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
        public string Category
        {
            get { return _category; }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    Notify("Category");
                }
            }
        }
        public string Count
        {
            get { return _count; }
            set
            {
                if (_count != value)
                {
                    _count = value;
                    Notify("Count");
                }
            }
        }

    }
}
