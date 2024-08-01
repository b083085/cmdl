using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL
{
    public class BloodChemistry_Data : CyberPropertyChanged
    {
        public BloodChemistry_Data(bool enabled)
        {
            Enabled = enabled;
        }

        public bool Enabled {set;get;}


        private List<Blood_Chemistry_Items_Data> _itemList = new List<Blood_Chemistry_Items_Data>();
        public List<Blood_Chemistry_Items_Data> ItemList
        {
            get { return _itemList; }
        }


        private string _BCId;
        private string _note;
        private string _pathologist;
        private string _medTech;
        private string _printedBy;

        public string BCId
        {
            get { return _BCId; }
            set { _BCId = value; Notify("BCId"); }
        }
        public string Note
        {
            get { return _note; }
            set { _note = value; Notify("Note"); }
        }
        public string Pathologist
        {
            get { return _pathologist; }
            set { _pathologist = value; Notify("Pathologist"); }
        }
        public string MedTech
        {
            get { return _medTech; }
            set { _medTech = value; Notify("MedTech"); }
        }
        public string PrintedBy
        {
            get { return _printedBy; }
            set { _printedBy = value; Notify("PrintedBy"); }
        }
        
    }
}
