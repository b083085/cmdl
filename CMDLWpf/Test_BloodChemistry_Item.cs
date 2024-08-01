using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDLWpf
{
    public class Test_BloodChemistry_Item : NotifyPropertyChanged
    {
        private ulong _itemID;
        private ulong _testID;
        private string _category;
        private string _chemistry;
        private string _cuHL;
        private string _cuRes;
        private string _cuUnit;
        private string _cuValue;
        private string _siHL;
        private string _siRes;
        private string _siUnit;
        private string _siValue;

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
        public string Chemistry
        {
            get { return _chemistry; }
            set
            {
                if (_chemistry != value)
                {
                    _chemistry = value;
                    Notify("Chemistry");
                }
            }
        }
        public string CuHL
        {
            get { return _cuHL; }
            set
            {
                if (_cuHL != value)
                {
                    _cuHL = value;
                    Notify("CuHL");
                }
            }
        }
        public string CuRes
        {
            get { return _cuRes; }
            set
            {
                if (_cuRes != value)
                {
                    _cuRes = value;
                    Notify("CuRes");
                }
            }
        }
        public string CuUnit
        {
            get { return _cuUnit; }
            set
            {
                if (_cuUnit != value)
                {
                    _cuUnit = value;
                    Notify("CuUnit");
                }
            }
        }
        public string CuValue
        {
            get { return _cuValue; }
            set
            {
                if (_cuValue != value)
                {
                    _cuValue = value;
                    Notify("CuValue");
                }
            }
        }
        public string SiHL
        {
            get { return _siHL; }
            set
            {
                if (_siHL != value)
                {
                    _siHL = value;
                    Notify("SiHL");
                }
            }
        }
        public string SiRes
        {
            get { return _siRes; }
            set
            {
                if (_siRes != value)
                {
                    _siRes = value;
                    Notify("SiRes");
                }
            }
        }
        public string SiUnit
        {
            get { return _siUnit; }
            set
            {
                if (_siUnit != value)
                {
                    _siUnit = value;
                    Notify("SiUnit");
                }
            }
        }
        public string SiValue
        {
            get { return _siValue; }
            set
            {
                if (_siValue != value)
                {
                    _siValue = value;
                    Notify("SiValue");
                }
            }
        }
    }
}
