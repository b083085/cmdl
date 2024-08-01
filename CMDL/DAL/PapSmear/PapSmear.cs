using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL.CLASS
{
    public class PapSmear: CyberPropertyChanged
    {

        public PapSmear(bool enabled)
        {
            Enabled = enabled;
        }


        public int testId
        {
            set;
            get;
        }
        //public string ControlNo { get; set; }
        //public string System { get; set; }
        //public string specimenType { get; set; }
        //public string adequacyOfSpecimen { get; set; }
        //public string generalCategorization { get; set; }
        //public string interpretation { get; set; }
        //public string interpretedBy { get; set; }
        //public string interpretedByTitle { get; set; }
        //public string note { get; set; }
        //public string Pathologist { set; get; }
        //public string MedTech { set; get; }
        //public string PrintedBy { set; get; }


        private int _testId;
        private string _system;
        private string _specimenType;
        private string _adequacyOfSpecimen;
        private string _generalCategorization;
        private string _interpretation;
        private string _interpretedBy;
        private string _interpretedByTitle;
        private string _note;
        private string _pathologist;
        private string _medtech;
        private string _printedBy;
        private bool _enabled;
        
        public int TestId
        {
            get { return _testId; }
            set
            {
                if (_testId != value)
                {
                    _testId = value;
                    Notify("TestId");
                }
            }
        }
        public string System
        {
            get { return _system; }
            set
            {
                if (_system != value)
                {
                    _system = value;
                    Notify("System");
                }
            }
        }
        public string SpecimenType
        {
            get { return _specimenType; }
            set
            {
                if (_specimenType != value)
                {
                    _specimenType = value;
                    Notify("SpecimenType");
                }
            }
        }
        public string AdequacyOfSpecimen
        {
            get { return _adequacyOfSpecimen; }
            set
            {
                if (_adequacyOfSpecimen != value)
                {
                    _adequacyOfSpecimen = value;
                    Notify("AdequacyOfSpecimen");
                }
            }
        }
        public string GeneralCategorization
        {
            get { return _generalCategorization; }
            set
            {
                if (_generalCategorization != value)
                {
                    _generalCategorization = value;
                    Notify("GeneralCategorization");
                }
            }
        }
        public string Interpretation
        {
            get { return _interpretation; }
            set
            {
                if (_interpretation != value)
                {
                    _interpretation = value;
                    Notify("Interpretation");
                }
            }
        }
        public string InterpretedBy
        {
            get { return _interpretedBy; }
            set
            {
                if (_interpretedBy != value)
                {
                    _interpretedBy = value;
                    Notify("InterpretedBy");
                }
            }
        }
        public string InterpretedByTitle
        {
            get { return _interpretedByTitle; }
            set
            {
                if (_interpretedByTitle != value)
                {
                    _interpretedByTitle = value;
                    Notify("InterpretedByTitle");
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
        public string Pathologist
        {
            get { return _pathologist; }
            set
            {
                if (_pathologist != value)
                {
                    _pathologist = value;
                    Notify("Pathologist");
                }
            }
        }
        public string Medtech
        {
            get { return _medtech; }
            set
            {
                if (_medtech != value)
                {
                    _medtech = value;
                    Notify("Medtech");
                }
            }
        }
        public string PrintedBy
        {
            get { return _printedBy; }
            set
            {
                if (_printedBy != value)
                {
                    _printedBy = value;
                    Notify("PrintedBy");
                }
            }
        }
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    Notify("Enabled");
                }
            }
        }
    }
}
