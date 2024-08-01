using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL
{
    public class Blood_Chemistry_Items_Data : CyberPropertyChanged
    {
        public Blood_Chemistry_Items_Data(bool enabled)
        {
            Enabled = enabled;
        }

        public bool Enabled {set;get;}


        private uint _itemID;
        private string _bcID;
        private string _category;
        private string _chemistry;
        private string _CUHL;
        private string _CURes;
        private string _CUUnit;
        private string _CUValue;
        private string _SIHL;
        private string _SIRes;
        private string _SIUnit;
        private string _SIValue;



        public uint ItemID
        {
            get { return _itemID; }
            set { _itemID = value; Notify("ItemID"); }
        }
        public string BcID
        {
            get { return _bcID; }
            set { _bcID = value; Notify("BcID"); }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; Notify("Category"); }
        }
        public string Chemistry
        {
            get { return _chemistry; }
            set { _chemistry = value; Notify("Chemistry"); }
        }
        public string CUHL
        {
            get { return _CUHL; }
            set { _CUHL = value; Notify("CUHL"); }
        }
        public string CURes
        {
            get { return _CURes; }
            set { _CURes = value; Notify("CURes"); }
        }
        public string CUUnit
        {
            get { return _CUUnit; }
            set { _CUUnit = value; Notify("CUUnit"); }
        }
        public string CUValue
        {
            get { return _CUValue; }
            set { _CUValue = value; Notify("CUValue"); }
        }
        public string SIHL
        {
            get { return _SIHL; }
            set { _SIHL = value; Notify("SIHL"); }
        }
        public string SIRes
        {
            get { return _SIRes; }
            set { _SIRes = value; Notify("SIRes"); }
        }
        public string SIUnit
        {
            get { return _SIUnit; }
            set { _SIUnit = value; Notify("SIUnit"); }
        }
        public string SIValue
        {
            get { return _SIValue; }
            set { _SIValue = value; Notify("SIValue"); }
        }
        
    }
}
