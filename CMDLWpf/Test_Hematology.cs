using System;


namespace CMDLWpf
{
    public class Test_Hematology : NotifyPropertyChanged
    {
        private ulong _testID;
        private string _controlNo;
        private string _wbc;
        private string _lymphPound;
        private string _midPound;
        private string _granPound;
        private string _lymphPercent;
        private string _midPercent;
        private string _granPercent;
        private string _hgb;
        private string _rbc;
        private string _hct;
        private string _mcv;
        private string _mch;
        private string _mchc;
        private string _rdw_Cv;
        private string _rdw_Sd;
        private string _plt;
        private string _mpv;
        private string _pdw;
        private string _pct;
        private string _wbc_Ref;
        private string _lymphPound_Ref;
        private string _midPound_Ref;
        private string _granPound_Ref;
        private string _lymphPercent_Ref;
        private string _midPercent_Ref;
        private string _granPercent_Ref;
        private string _hgb_Ref;
        private string _rbc_Ref;
        private string _hct_Ref;
        private string _mcv_Ref;
        private string _mch_Ref;
        private string _mchc_Ref;
        private string _rdw_Cv_Ref;
        private string _rdw_Sd_Ref;
        private string _plt_Ref;
        private string _mpv_Ref;
        private string _pdw_Ref;
        private string _pct_Ref;
        private string _remarks;
        private string _note;
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
        public string LymphPound
        {
            get { return _lymphPound; }
            set
            {
                if (_lymphPound != value)
                {
                    _lymphPound = value;
                    Notify("LymphPound");
                }
            }
        }
        public string MidPound
        {
            get { return _midPound; }
            set
            {
                if (_midPound != value)
                {
                    _midPound = value;
                    Notify("MidPound");
                }
            }
        }
        public string GranPound
        {
            get { return _granPound; }
            set
            {
                if (_granPound != value)
                {
                    _granPound = value;
                    Notify("GranPound");
                }
            }
        }
        public string LymphPercent
        {
            get { return _lymphPercent; }
            set
            {
                if (_lymphPercent != value)
                {
                    _lymphPercent = value;
                    Notify("LymphPercent");
                }
            }
        }
        public string MidPercent
        {
            get { return _midPercent; }
            set
            {
                if (_midPercent != value)
                {
                    _midPercent = value;
                    Notify("MidPercent");
                }
            }
        }
        public string GranPercent
        {
            get { return _granPercent; }
            set
            {
                if (_granPercent != value)
                {
                    _granPercent = value;
                    Notify("GranPercent");
                }
            }
        }
        public string Hgb
        {
            get { return _hgb; }
            set
            {
                if (_hgb != value)
                {
                    _hgb = value;
                    Notify("Hgb");
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
        public string Hct
        {
            get { return _hct; }
            set
            {
                if (_hct != value)
                {
                    _hct = value;
                    Notify("Hct");
                }
            }
        }
        public string Mcv
        {
            get { return _mcv; }
            set
            {
                if (_mcv != value)
                {
                    _mcv = value;
                    Notify("Mcv");
                }
            }
        }
        public string Mch
        {
            get { return _mch; }
            set
            {
                if (_mch != value)
                {
                    _mch = value;
                    Notify("Mch");
                }
            }
        }
        public string Mchc
        {
            get { return _mchc; }
            set
            {
                if (_mchc != value)
                {
                    _mchc = value;
                    Notify("Mchc");
                }
            }
        }
        public string Rdw_Cv
        {
            get { return _rdw_Cv; }
            set
            {
                if (_rdw_Cv != value)
                {
                    _rdw_Cv = value;
                    Notify("Rdw_Cv");
                }
            }
        }
        public string Rdw_Sd
        {
            get { return _rdw_Sd; }
            set
            {
                if (_rdw_Sd != value)
                {
                    _rdw_Sd = value;
                    Notify("Rdw_Sd");
                }
            }
        }
        public string Plt
        {
            get { return _plt; }
            set
            {
                if (_plt != value)
                {
                    _plt = value;
                    Notify("Plt");
                }
            }
        }
        public string Mpv
        {
            get { return _mpv; }
            set
            {
                if (_mpv != value)
                {
                    _mpv = value;
                    Notify("Mpv");
                }
            }
        }
        public string Pdw
        {
            get { return _pdw; }
            set
            {
                if (_pdw != value)
                {
                    _pdw = value;
                    Notify("Pdw");
                }
            }
        }
        public string Pct
        {
            get { return _pct; }
            set
            {
                if (_pct != value)
                {
                    _pct = value;
                    Notify("Pct");
                }
            }
        }
        public string Wbc_Ref
        {
            get { return _wbc_Ref; }
            set
            {
                if (_wbc_Ref != value)
                {
                    _wbc_Ref = value;
                    Notify("Wbc_Ref");
                }
            }
        }
        public string LymphPound_Ref
        {
            get { return _lymphPound_Ref; }
            set
            {
                if (_lymphPound_Ref != value)
                {
                    _lymphPound_Ref = value;
                    Notify("LymphPound_Ref");
                }
            }
        }
        public string MidPound_Ref
        {
            get { return _midPound_Ref; }
            set
            {
                if (_midPound_Ref != value)
                {
                    _midPound_Ref = value;
                    Notify("MidPound_Ref");
                }
            }
        }
        public string GranPound_Ref
        {
            get { return _granPound_Ref; }
            set
            {
                if (_granPound_Ref != value)
                {
                    _granPound_Ref = value;
                    Notify("GranPound_Ref");
                }
            }
        }
        public string LymphPercent_Ref
        {
            get { return _lymphPercent_Ref; }
            set
            {
                if (_lymphPercent_Ref != value)
                {
                    _lymphPercent_Ref = value;
                    Notify("LymphPercent_Ref");
                }
            }
        }
        public string MidPercent_Ref
        {
            get { return _midPercent_Ref; }
            set
            {
                if (_midPercent_Ref != value)
                {
                    _midPercent_Ref = value;
                    Notify("MidPercent_Ref");
                }
            }
        }
        public string GranPercent_Ref
        {
            get { return _granPercent_Ref; }
            set
            {
                if (_granPercent_Ref != value)
                {
                    _granPercent_Ref = value;
                    Notify("GranPercent_Ref");
                }
            }
        }
        public string Hgb_Ref
        {
            get { return _hgb_Ref; }
            set
            {
                if (_hgb_Ref != value)
                {
                    _hgb_Ref = value;
                    Notify("Hgb_Ref");
                }
            }
        }
        public string Rbc_Ref
        {
            get { return _rbc_Ref; }
            set
            {
                if (_rbc_Ref != value)
                {
                    _rbc_Ref = value;
                    Notify("Rbc_Ref");
                }
            }
        }
        public string Hct_Ref
        {
            get { return _hct_Ref; }
            set
            {
                if (_hct_Ref != value)
                {
                    _hct_Ref = value;
                    Notify("Hct_Ref");
                }
            }
        }
        public string Mcv_Ref
        {
            get { return _mcv_Ref; }
            set
            {
                if (_mcv_Ref != value)
                {
                    _mcv_Ref = value;
                    Notify("Mcv_Ref");
                }
            }
        }
        public string Mch_Ref
        {
            get { return _mch_Ref; }
            set
            {
                if (_mch_Ref != value)
                {
                    _mch_Ref = value;
                    Notify("Mch_Ref");
                }
            }
        }
        public string Mchc_Ref
        {
            get { return _mchc_Ref; }
            set
            {
                if (_mchc_Ref != value)
                {
                    _mchc_Ref = value;
                    Notify("Mchc_Ref");
                }
            }
        }
        public string Rdw_Cv_Ref
        {
            get { return _rdw_Cv_Ref; }
            set
            {
                if (_rdw_Cv_Ref != value)
                {
                    _rdw_Cv_Ref = value;
                    Notify("Rdw_Cv_Ref");
                }
            }
        }
        public string Rdw_Sd_Ref
        {
            get { return _rdw_Sd_Ref; }
            set
            {
                if (_rdw_Sd_Ref != value)
                {
                    _rdw_Sd_Ref = value;
                    Notify("Rdw_Sd_Ref");
                }
            }
        }
        public string Plt_Ref
        {
            get { return _plt_Ref; }
            set
            {
                if (_plt_Ref != value)
                {
                    _plt_Ref = value;
                    Notify("Plt_Ref");
                }
            }
        }
        public string Mpv_Ref
        {
            get { return _mpv_Ref; }
            set
            {
                if (_mpv_Ref != value)
                {
                    _mpv_Ref = value;
                    Notify("Mpv_Ref");
                }
            }
        }
        public string Pdw_Ref
        {
            get { return _pdw_Ref; }
            set
            {
                if (_pdw_Ref != value)
                {
                    _pdw_Ref = value;
                    Notify("Pdw_Ref");
                }
            }
        }
        public string Pct_Ref
        {
            get { return _pct_Ref; }
            set
            {
                if (_pct_Ref != value)
                {
                    _pct_Ref = value;
                    Notify("Pct_Ref");
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
