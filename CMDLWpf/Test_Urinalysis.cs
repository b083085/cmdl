using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDLWpf
{
    public class Test_Urinalysis : NotifyPropertyChanged
    {
        private ulong _testID;
        private string _controlNo;
        private string _collection;
        private string _color;
        private string _transparency;
        private string _specificGravity;
        private string _pH;
        private string _glucose;
        private string _protein;
        private string _blood;
        private string _leukocytes;
        private string _nitrite;
        private string _ketone;
        private string _urobilinogen;
        private string _ascorbic_Acid;
        private string _rbc;
        private string _wbc;
        private string _epithelialCells;
        private string _bacteria;
        private string _mucusThread;
        private string _aUrates;
        private string _uricAcid;
        private string _calciumOxalate;
        private string _fineGranularCast;
        private string _coarseGranularCast;
        private string _wbcCast;
        private string _rbcCast;
        private string _others;
        private string _note;
        private string _remarks;
        private string _medTech;
        private string _medtechTitle;
        private string _pathologist;
        private string _pathologistTitle;
        private string _createdBy;
        private DateTime _dateCreated;
        private string _updatedBy;
        private DateTime _dateUpdated;

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
        public string ControlNo
        {
            get { return _controlNo; }
            set
            {
                if (_controlNo != value)
                {
                    _controlNo = value;
                    Notify("ControlNo");
                }
            }
        }
        public string Collection
        {
            get { return _collection; }
            set
            {
                if (_collection != value)
                {
                    _collection = value;
                    Notify("Collection");
                }
            }
        }
        public string Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    Notify("Color");
                }
            }
        }
        public string Transparency
        {
            get { return _transparency; }
            set
            {
                if (_transparency != value)
                {
                    _transparency = value;
                    Notify("Transparency");
                }
            }
        }
        public string SpecificGravity
        {
            get { return _specificGravity; }
            set
            {
                if (_specificGravity != value)
                {
                    _specificGravity = value;
                    Notify("SpecificGravity");
                }
            }
        }
        public string PH
        {
            get { return _pH; }
            set
            {
                if (_pH != value)
                {
                    _pH = value;
                    Notify("PH");
                }
            }
        }
        public string Glucose
        {
            get { return _glucose; }
            set
            {
                if (_glucose != value)
                {
                    _glucose = value;
                    Notify("Glucose");
                }
            }
        }
        public string Protein
        {
            get { return _protein; }
            set
            {
                if (_protein != value)
                {
                    _protein = value;
                    Notify("Protein");
                }
            }
        }
        public string Blood
        {
            get { return _blood; }
            set
            {
                if (_blood != value)
                {
                    _blood = value;
                    Notify("Blood");
                }
            }
        }
        public string Leukocytes
        {
            get { return _leukocytes; }
            set
            {
                if (_leukocytes != value)
                {
                    _leukocytes = value;
                    Notify("Leukocytes");
                }
            }
        }
        public string Nitrite
        {
            get { return _nitrite; }
            set
            {
                if (_nitrite != value)
                {
                    _nitrite = value;
                    Notify("Nitrite");
                }
            }
        }
        public string Ketone
        {
            get { return _ketone; }
            set
            {
                if (_ketone != value)
                {
                    _ketone = value;
                    Notify("Ketone");
                }
            }
        }
        public string Urobilinogen
        {
            get { return _urobilinogen; }
            set
            {
                if (_urobilinogen != value)
                {
                    _urobilinogen = value;
                    Notify("Urobilinogen");
                }
            }
        }
        public string Ascorbic_Acid
        {
            get { return _ascorbic_Acid; }
            set
            {
                if (_ascorbic_Acid != value)
                {
                    _ascorbic_Acid = value;
                    Notify("Ascorbic_Acid");
                }
            }
        }
        public string Rbc
        {
            get { return _rbc; }
            set
            {
                if (_rbc != value)
                {
                    _rbc = value;
                    Notify("Rbc");
                }
            }
        }
        public string Wbc
        {
            get { return _wbc; }
            set
            {
                if (_wbc != value)
                {
                    _wbc = value;
                    Notify("Wbc");
                }
            }
        }
        public string EpithelialCells
        {
            get { return _epithelialCells; }
            set
            {
                if (_epithelialCells != value)
                {
                    _epithelialCells = value;
                    Notify("EpithelialCells");
                }
            }
        }
        public string Bacteria
        {
            get { return _bacteria; }
            set
            {
                if (_bacteria != value)
                {
                    _bacteria = value;
                    Notify("Bacteria");
                }
            }
        }
        public string MucusThread
        {
            get { return _mucusThread; }
            set
            {
                if (_mucusThread != value)
                {
                    _mucusThread = value;
                    Notify("MucusThread");
                }
            }
        }
        public string AUrates
        {
            get { return _aUrates; }
            set
            {
                if (_aUrates != value)
                {
                    _aUrates = value;
                    Notify("AUrates");
                }
            }
        }
        public string UricAcid
        {
            get { return _uricAcid; }
            set
            {
                if (_uricAcid != value)
                {
                    _uricAcid = value;
                    Notify("UricAcid");
                }
            }
        }
        public string CalciumOxalate
        {
            get { return _calciumOxalate; }
            set
            {
                if (_calciumOxalate != value)
                {
                    _calciumOxalate = value;
                    Notify("CalciumOxalate");
                }
            }
        }
        public string FineGranularCast
        {
            get { return _fineGranularCast; }
            set
            {
                if (_fineGranularCast != value)
                {
                    _fineGranularCast = value;
                    Notify("FineGranularCast");
                }
            }
        }
        public string CoarseGranularCast
        {
            get { return _coarseGranularCast; }
            set
            {
                if (_coarseGranularCast != value)
                {
                    _coarseGranularCast = value;
                    Notify("CoarseGranularCast");
                }
            }
        }
        public string WbcCast
        {
            get { return _wbcCast; }
            set
            {
                if (_wbcCast != value)
                {
                    _wbcCast = value;
                    Notify("WbcCast");
                }
            }
        }
        public string RbcCast
        {
            get { return _rbcCast; }
            set
            {
                if (_rbcCast != value)
                {
                    _rbcCast = value;
                    Notify("RbcCast");
                }
            }
        }
        public string Others
        {
            get { return _others; }
            set
            {
                if (_others != value)
                {
                    _others = value;
                    Notify("Others");
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
        public string Remarks
        {
            get { return _remarks; }
            set
            {
                if (_remarks != value)
                {
                    _remarks = value;
                    Notify("Remarks");
                }
            }
        }
        public string MedTech
        {
            get { return _medTech; }
            set
            {
                if (_medTech != value)
                {
                    _medTech = value;
                    Notify("MedTech");
                }
            }
        }
        public string MedtechTitle
        {
            get { return _medtechTitle; }
            set
            {
                if (_medtechTitle != value)
                {
                    _medtechTitle = value;
                    Notify("MedtechTitle");
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
        public string PathologistTitle
        {
            get { return _pathologistTitle; }
            set
            {
                if (_pathologistTitle != value)
                {
                    _pathologistTitle = value;
                    Notify("PathologistTitle");
                }
            }
        }
        public string CreatedBy
        {
            get { return _createdBy; }
            set
            {
                if (_createdBy != value)
                {
                    _createdBy = value;
                    Notify("CreatedBy");
                }
            }
        }
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set
            {
                if (_dateCreated != value)
                {
                    _dateCreated = value;
                    Notify("DateCreated");
                }
            }
        }
        public string UpdatedBy
        {
            get { return _updatedBy; }
            set
            {
                if (_updatedBy != value)
                {
                    _updatedBy = value;
                    Notify("UpdatedBy");
                }
            }
        }
        public DateTime DateUpdated
        {
            get { return _dateUpdated; }
            set
            {
                if (_dateUpdated != value)
                {
                    _dateUpdated = value;
                    Notify("DateUpdated");
                }
            }
        }
    }
}
