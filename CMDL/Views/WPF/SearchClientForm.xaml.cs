using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CMDLWpf;


namespace CMDL
{
    /// <summary>
    /// Interaction logic for SearchClientForm.xaml
    /// </summary>
    public partial class SearchClientForm : Window
    {
        CMDLWpf.MySqlDB host = new CMDLWpf.MySqlDB(Properties.Settings.Default.Server,
                                                   Properties.Settings.Default.Database,
                                                   Properties.Settings.Default.UserID,
                                                   Properties.Settings.Default.Port,
                                                   Properties.Settings.Default.Password);

        Database db = new Database();
        List<SearchClientInfo> clientList = new List<SearchClientInfo>();
        string publicDate = string.Empty;

        public SearchClientForm()
        {
            InitializeComponent();

            BtSearch.Click += new RoutedEventHandler(BtSearch_Click);
            TbKeyWord.KeyDown += new KeyEventHandler(TbKeyWord_KeyDown);

            CbFilter.SelectionChanged += new SelectionChangedEventHandler(CbFilter_SelectionChanged);

            dataGrid1.DataContext = clientList;

        }

        void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((ComboBox)sender).SelectedItem as ComboBoxItem;

            if (Convert.ToString(item.Content) == "DATE" || Convert.ToString(item.Content) == "BIRTH DATE")
            {
                DatePage dp = new DatePage();
                if (dp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    TbKeyWord.Text = dp.GetDate;
            }
            else if (Convert.ToString(item.Content) == "EXAM")
            {
                DatePage dp = new DatePage();
                if (dp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    publicDate = dp.GetDate;
            }

            TbKeyWord.Focus();
        }

        void Search()
        {
            var obj = TbKeyWord.Text;
            DateTime dt = new DateTime();

            switch (CbFilter.Text)
            {
                case "TODAY": host.Search("select * from reg where date_reg='" + DateTime.Now.ToString("yyyy-MM-dd") + "'", "reg");
                    break;
                case "CONTROL NO.": host.SearchWithParametrizedQuery("select * from reg where controlno=@controlno", "reg", new Dictionary<string, object>() { { "@controlno", obj } });
                    break;
                case "DATE": host.SearchWithParametrizedQuery("select * from reg where date_reg=@date_reg", "reg", new Dictionary<string, object>() { { "@date_reg", obj } });
                    break;
                case "LAST NAME": host.SearchWithParametrizedQuery("select * from reg where lastname=@lastname", "reg", new Dictionary<string, object>() { { "@lastname", obj } });
                    break;
                case "FIRST NAME": host.SearchWithParametrizedQuery("select * from reg where firstname=@firstname", "reg", new Dictionary<string, object>() { { "@firstname", obj } });
                    break;
                case "MIDDLE INITIAL": host.SearchWithParametrizedQuery("select * from reg where mi=@mi", "reg", new Dictionary<string, object>() { { "@mi", obj } });
                    break;
                case "SUFFIX": host.SearchWithParametrizedQuery("select * from reg where suffix=@suffix", "reg", new Dictionary<string, object>() { { "@suffix", obj } });
                    break;
                case "ADDRESS": host.SearchWithParametrizedQuery("select * from reg where address=@address", "reg", new Dictionary<string, object>() { { "@address", obj } });
                    break;
                case "AGE": host.SearchWithParametrizedQuery("select * from reg where age=@age", "reg", new Dictionary<string, object>() { { "@age", obj } });
                    break;
                case "SEX": host.SearchWithParametrizedQuery("select * from reg where sex=@sex", "reg", new Dictionary<string, object>() { { "@sex", obj } });
                    break;
                case "CIVIL STATUS": host.SearchWithParametrizedQuery("select * from reg where civil_status=@civil_status", "reg", new Dictionary<string, object>() { { "@civil_status", obj } });
                    break;
                case "BIRTH DATE": host.SearchWithParametrizedQuery("select * from reg where bdate=@bdate", "reg", new Dictionary<string, object>() { { "@bdate", obj } });
                    break;
                case "BIRTH PLACE": host.SearchWithParametrizedQuery("select * from reg where bplace=@bplace", "reg", new Dictionary<string, object>() { { "@bplace", obj } });
                    break;
                case "REQUESTING PARTY": host.SearchWithParametrizedQuery("select * from reg where reqparty like '%@reqparty%'", "reg", new Dictionary<string, object>() { { "@reqparty", obj } });
                    break;
                case "PURPOSE": host.SearchWithParametrizedQuery("select * from reg where purpose=@purpose", "reg", new Dictionary<string, object>() { { "@purpose", obj } });
                    break;
                case "TELEPHONE NO.": host.SearchWithParametrizedQuery("select * from reg where telno=@telno", "reg", new Dictionary<string, object>() { { "@telno", obj } });
                    break;
                case "MOBILE NO.": host.SearchWithParametrizedQuery("select * from reg where celno=@celno", "reg", new Dictionary<string, object>() { { "@celno", obj } });
                    break;
                case "DISTRICT/BRANCH": host.SearchWithParametrizedQuery("select * from reg where district_branch=@district_branch", "reg", new Dictionary<string, object>() { { "@district_branch", obj } });
                    break;
                case "EXAM": host.SearchWithParametrizedQuery("select * from reg where exam like @exam and date_reg=@date_reg", "reg", new Dictionary<string, object>() { { "@exam", obj }, { "@date_reg", publicDate } });
                    break;
            }

            db = host["reg"];

            if (db.Length > 0)
            {
                clientList.Clear();

                foreach (var dr in db.ReturnRow)
                {
                    var sc = new SearchClientInfo();
                    sc.ControlNo = Convert.ToString(dr["controlno"]);
                    sc.Lastname = Convert.ToString(dr["lastname"]);
                    sc.Firstname = Convert.ToString(dr["firstname"]);
                    sc.Mi = Convert.ToString(dr["mi"]);
                    sc.Suffix = Convert.ToString(dr["suffix"]);
                    sc.Age = Convert.ToString(dr["age"]);
                    sc.Gender = Convert.ToString(dr["sex"]);
                    sc.Address = Convert.ToString(dr["address"]);
                    sc.CivilStatus = Convert.ToString(dr["civil_status"]);
                    sc.BirthPlace = Convert.ToString(dr["bplace"]);
                    sc.RequestingParty = Convert.ToString(dr["reqparty"]);
                    sc.Purpose = Convert.ToString(dr["purpose"]);
                    sc.TelephoneNo = Convert.ToString(dr["telNo"]);
                    sc.MobileNo = Convert.ToString(dr["celNo"]);
                    sc.DistrictBranch = Convert.ToString(dr["district_branch"]);

                    if (DateTime.TryParse(Convert.ToString(dr["date_reg"]), out dt))
                        sc.DateRegistered = Convert.ToDateTime(dr["date_reg"]);
                    if (DateTime.TryParse(Convert.ToString(dr["bdate"]), out dt))
                        sc.BirthDate = Convert.ToDateTime(dr["bdate"]);
                    if (DateTime.TryParse(Convert.ToString(dr["time_in"]), out dt))
                        sc.TimeIn = Convert.ToDateTime(dr["time_in"]);
                    if (dr["photo"] != DBNull.Value)
                        sc.Photo = (byte[])dr["photo"];

                    ParseExam(Convert.ToString(dr["exam"]), sc.ExaminationList);
                    CheckTest(sc);
                    clientList.Add(sc);
                }
            }
            else
            {
                MessageBox.Show("No Record(s) Found!", "Search Message", MessageBoxButton.OK, MessageBoxImage.Stop);
                clientList.Clear();
            }

            TbResults.Text = string.Format("TOTAL: {0}", clientList.Count);
            dataGrid1.Items.Refresh();
        }

        void ParseExam(string exam, List<Examination> examList)
        {
            string test = string.Empty;

            foreach (char c in exam)
            {
                if (c != ',')
                    test += c;
                else
                {
                    examList.Add(new Examination { Test = test });
                    test = string.Empty;
                }
            }
        }

        void CheckTest(SearchClientInfo sc)
        {
            sc.TotalTestToEncode = sc.ExaminationList.Count;

            DateTime dt = new DateTime();

            foreach (var exam in sc.ExaminationList)
            {
                host.Search("select * from cmdl_exam where test='" + exam.Test + "'", "cmdl_exam");
                Database db = host["cmdl_exam"];
                if (db.Length > 0)
                {
                    var dr = db.ReturnRow[0];
                    Database db1 = null;
                    switch (Convert.ToString(dr["tablename"]).ToLower())
                    {
                        case "test_xray":
                            #region CODE
                            if (sc.Xray == null)
                                sc.Xray = new List<Test_XRay>();

                            host.Search("select * from test_xray where controlno='" + sc.ControlNo + "' and marker='" + dr["marker"] + "'", "test_xray");
                            db1 = host["test_xray"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.Xray.Add(new Test_XRay()
                                    {
                                        TestID = Convert.ToUInt64(d["testID"]),
                                        ControlNo = Convert.ToString(d["controlno"]),
                                        FilmNo = Convert.ToString(d["filmNo"]),
                                        Marker = Convert.ToString(d["marker"]),
                                        RadioReport = Convert.ToString(d["radioReport"]),
                                        Remarks = Convert.ToString(d["remarks"]),
                                        PreparedBy = Convert.ToString(d["preparedBy"]),
                                        Radiologist = Convert.ToString(d["radiologist"]),
                                        RadTitle = Convert.ToString(d["radTitle"]),
                                        CreatedBy = Convert.ToString(d["createdBy"]),
                                        DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime(),
                                        UpdatedBy = Convert.ToString(d["updatedBy"]),
                                        DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime(),
                                    });
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.Xray.Add(new Test_XRay()
                                {
                                    ControlNo = sc.ControlNo,
                                    Marker = Convert.ToString(dr["marker"])
                                });

                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_serology":
                            #region CODE
                            if (sc.Serology == null)
                                sc.Serology = new Test_Serology();

                            host.Search("select * from test_serology where controlno='" + sc.ControlNo + "'", "test_serology");
                            db1 = host["test_serology"];

                            if (db1.Length > 0)
                            {

                                var d = db1.ReturnRow[0];

                                if (sc.Serology.objectExist == false)
                                {
                                    sc.Serology.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.Serology.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.Serology.MedTech = Convert.ToString(d["medtech"]);
                                    sc.Serology.Pathologist = Convert.ToString(d["pathologist"]);
                                    sc.Serology.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.Serology.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.Serology.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.Serology.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                    sc.TotalTestToEncode -= 1;
                                }

                                #region ITEMS
                                host.Search("select * from test_serology_item where testID='" + d["testID"] + "' and test='" + exam.Test + "'", "test_serology_item");
                                Database itemDB = host["test_serology_item"];

                                if (itemDB.Length > 0)
                                {
                                    foreach (var item in itemDB.ReturnRow)
                                    {
                                        sc.Serology.ItemList.Add(new Test_Serology_Item()
                                        {
                                            ItemID = Convert.ToUInt64(item["itemID"]),
                                            TestID = Convert.ToUInt64(item["testID"]),
                                            Test = Convert.ToString(item["test"]),
                                            Result = Convert.ToString(item["result"]),
                                            Kit = Convert.ToString(item["kit"]),
                                            Lotno = Convert.ToString(item["lotno"]),
                                            Exp = Convert.ToDateTime(item["exp"]),
                                            Recommendation = Convert.ToString(item["recommendation"]),
                                            Note = Convert.ToString(item["note"])
                                        });
                                    }
                                }
                                #endregion

                            }
                            else
                            {
                                if (Convert.ToString(dr["test"]) == "BLOOD TEST")
                                {
                                    sc.Serology.ItemList.Add(new Test_Serology_Item()
                                    {
                                        ItemID = 0,
                                        TestID = sc.Serology.TestID,
                                        Test = "Anti-HIV 1 / HIV 2",
                                        Result = "NONREACTIVE",
                                        Kit = "",
                                        Lotno = "",
                                        Exp = DateTime.Now,
                                        Recommendation = "NONE",
                                        Note = "NONE"
                                    });
                                    sc.Serology.ItemList.Add(new Test_Serology_Item()
                                    {
                                        ItemID = 1,
                                        TestID = sc.Serology.TestID,
                                        Test = "HBsAg",
                                        Result = "NONREACTIVE",
                                        Kit = "",
                                        Lotno = "",
                                        Exp = DateTime.Now,
                                        Recommendation = "NONE",
                                        Note = "NONE"
                                    });
                                    sc.Serology.ItemList.Add(new Test_Serology_Item()
                                    {
                                        ItemID = 2,
                                        TestID = sc.Serology.TestID,
                                        Test = "Anti-TP(Syphilis)",
                                        Result = "NONREACTIVE",
                                        Kit = "",
                                        Lotno = "",
                                        Exp = DateTime.Now,
                                        Recommendation = "NONE",
                                        Note = "NONE"
                                    });
                                }
                                else
                                {
                                    sc.Serology.ItemList.Add(new Test_Serology_Item()
                                    {
                                        ItemID = 0,
                                        TestID = sc.Serology.TestID,
                                        Test = Convert.ToString(dr["test"]),
                                        Result = "NONREACTIVE",
                                        Kit = "",
                                        Lotno = "",
                                        Exp = DateTime.Now,
                                        Recommendation = "NONE",
                                        Note = "NONE"
                                    });
                                }

                                sc.Serology.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_bloodchemistry":
                            #region CODE
                            if (sc.BloodChemistry == null)
                                sc.BloodChemistry = new Test_BloodChemistry();

                            host.Search("select * from test_bloodchemistry where controlno='" + sc.ControlNo + "'", "test_bloodchemistry");
                            db1 = host["test_bloodchemistry"];

                            if (db1.Length > 0)
                            {
                                var d = db1.ReturnRow[0];

                                if (sc.BloodChemistry.objectExist == false)
                                {
                                    sc.BloodChemistry.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.BloodChemistry.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.BloodChemistry.MedTech = Convert.ToString(d["medtech"]);
                                    sc.BloodChemistry.Pathologist = Convert.ToString(d["pathologist"]);
                                    sc.BloodChemistry.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.BloodChemistry.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.BloodChemistry.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.BloodChemistry.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                    sc.TotalTestToEncode -= 1;
                                }

                                #region ITEMS
                                host.Search("select * from test_bloodChemistry_item where testID='" + d["testID"] + "' and chemistry='" + exam.Test + "'", "test_bloodChemistry_item");
                                Database itemDB = host["test_bloodChemistry_item"];

                                if (itemDB.Length > 0)
                                {
                                    foreach (var item in itemDB.ReturnRow)
                                    {
                                        sc.BloodChemistry.ItemList.Add(new Test_BloodChemistry_Item()
                                        {
                                            ItemID = Convert.ToUInt64(item["itemID"]),
                                            TestID = Convert.ToUInt64(item["testID"]),
                                            Category = Convert.ToString(item["category"]),
                                            Chemistry = Convert.ToString(item["chemistry"]),
                                            CuHL = Convert.ToString(item["CuHL"]),
                                            CuRes = Convert.ToString(item["CuRes"]),
                                            CuUnit = Convert.ToString(item["CuUnit"]),
                                            CuValue = Convert.ToString(item["CuValue"]),
                                            SiHL = Convert.ToString(item["SiHL"]),
                                            SiRes = Convert.ToString(item["SiRes"]),
                                            SiUnit = Convert.ToString(item["SiUnit"]),
                                            SiValue = Convert.ToString(item["SiValue"])
                                        });
                                    }
                                }
                                #endregion

                            }
                            else
                            {
                                sc.BloodChemistry.ControlNo = sc.ControlNo;
                                sc.BloodChemistry.ItemList.Add(new Test_BloodChemistry_Item()
                                {
                                    Chemistry = Convert.ToString(dr["test"])
                                });
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_bloodtyping":
                            #region CODE
                            if (sc.BloodTyping == null)
                                sc.BloodTyping = new Test_BloodTyping();

                            host.Search("select * from test_bloodtyping where controlno='" + sc.ControlNo + "'", "test_bloodtyping");
                            db1 = host["test_bloodtyping"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.BloodTyping.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.BloodTyping.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.BloodTyping.Result = Convert.ToString(d["result"]);
                                    sc.BloodTyping.Remarks = Convert.ToString(d["remarks"]);
                                    sc.BloodTyping.Note = Convert.ToString(d["note"]);
                                    sc.BloodTyping.MedTech = Convert.ToString(d["medtech"]);
                                    sc.BloodTyping.Pathologist = Convert.ToString(d["pathologist"]);
                                    sc.BloodTyping.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.BloodTyping.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.BloodTyping.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.BloodTyping.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.BloodTyping.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_pe":
                            #region CODE
                            if (sc.PhysicalExamination == null)
                                sc.PhysicalExamination = new Test_PE();

                            host.Search("select * from test_pe where controlno='" + sc.ControlNo + "'", "test_pe");
                            db1 = host["test_pe"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.PhysicalExamination.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.PhysicalExamination.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.PhysicalExamination.NatureOfWork = Convert.ToString(d["natureofwork"]);
                                    sc.PhysicalExamination.GrowthDevelopment = Convert.ToString(d["growthdev"]);
                                    sc.PhysicalExamination.Bp = Convert.ToString(d["bp"]);
                                    sc.PhysicalExamination.Hr = Convert.ToString(d["hr"]);
                                    sc.PhysicalExamination.Pr = Convert.ToString(d["pr"]);
                                    sc.PhysicalExamination.Ft = Convert.ToString(d["ft"]);
                                    sc.PhysicalExamination.Inch = Convert.ToString(d["inch"]);
                                    sc.PhysicalExamination.Weight = Convert.ToString(d["weight"]);
                                    sc.PhysicalExamination.Eyes = Convert.ToString(d["eyes"]);
                                    sc.PhysicalExamination.Od = Convert.ToString(d["od"]);
                                    sc.PhysicalExamination.Os = Convert.ToString(d["os"]);
                                    sc.PhysicalExamination.Ishihara = Convert.ToString(d["ishihara"]);
                                    sc.PhysicalExamination.Ears = Convert.ToString(d["ears"]);
                                    sc.PhysicalExamination.NoseThroat = Convert.ToString(d["nosethroat"]);
                                    sc.PhysicalExamination.Dental = Convert.ToString(d["dental"]);
                                    sc.PhysicalExamination.Breast = Convert.ToString(d["breast"]);
                                    sc.PhysicalExamination.Extremities = Convert.ToString(d["extremities"]);
                                    sc.PhysicalExamination.Neurolog = Convert.ToString(d["neurolog"]);
                                    sc.PhysicalExamination.Heart = Convert.ToString(d["heart"]);
                                    sc.PhysicalExamination.Lungs = Convert.ToString(d["lungs"]);
                                    sc.PhysicalExamination.Abdomen = Convert.ToString(d["abdomen"]);
                                    sc.PhysicalExamination.Genitalia = Convert.ToString(d["genitalia"]);
                                    sc.PhysicalExamination.Anorectal = Convert.ToString(d["anorectal"]);
                                    sc.PhysicalExamination.Skin = Convert.ToString(d["skin"]);
                                    sc.PhysicalExamination.OtherBodyParts = Convert.ToString(d["otherbodyparts"]);
                                    sc.PhysicalExamination.PastMedicalHistory = Convert.ToString(d["pastmedhistory"]);
                                    sc.PhysicalExamination.CxrExist = Convert.ToChar(d["cxrExist"]);
                                    sc.PhysicalExamination.CxrDate = DateTime.TryParse(Convert.ToString(d["cxrdate"]), out dt) ? Convert.ToDateTime(d["cxrdate"]) : DateTime.Now;
                                    sc.PhysicalExamination.FilmNo = Convert.ToString(d["filmno"]);
                                    sc.PhysicalExamination.CxrNegative = Convert.ToChar(d["cxrnegative"]);
                                    sc.PhysicalExamination.CxrFindings = Convert.ToString(d["cxrfindings"]);
                                    sc.PhysicalExamination.Cbc = Convert.ToString(d["cbc"]);
                                    sc.PhysicalExamination.Urine = Convert.ToString(d["urine"]);
                                    sc.PhysicalExamination.Stool = Convert.ToString(d["stool"]);
                                    sc.PhysicalExamination.BloodChemistry = Convert.ToString(d["bloodchem"]);
                                    sc.PhysicalExamination.PregnancyTest = Convert.ToString(d["pregtest"]);
                                    sc.PhysicalExamination.Vdrl = Convert.ToString(d["vdrl"]);
                                    sc.PhysicalExamination.HepA = Convert.ToString(d["hepa"]);
                                    sc.PhysicalExamination.HepB = Convert.ToString(d["hepb"]);
                                    sc.PhysicalExamination.Hiv = Convert.ToString(d["hiv"]);
                                    sc.PhysicalExamination.DrugTest = Convert.ToString(d["drugtest"]);
                                    sc.PhysicalExamination.BloodType = Convert.ToString(d["bloodtype"]);
                                    sc.PhysicalExamination.OtherTest = Convert.ToString(d["othertest"]);
                                    sc.PhysicalExamination.NeuroPsychology = Convert.ToString(d["neuropsycho"]);
                                    sc.PhysicalExamination.NeuroPsychiatric = Convert.ToString(d["neuropsychia"]);
                                    sc.PhysicalExamination.Remarks = Convert.ToString(d["remarks"]);
                                    sc.PhysicalExamination.Recommendation = Convert.ToString(d["recommendation"]);
                                    sc.PhysicalExamination.RecommendationNote = Convert.ToString(d["recnote"]);
                                    sc.PhysicalExamination.RefBy = Convert.ToString(d["refby"]);
                                    sc.PhysicalExamination.WorkType = Convert.ToString(d["worktype"]);
                                    sc.PhysicalExamination.CountryOfDestination = Convert.ToString(d["countryofdest"]);
                                    sc.PhysicalExamination.DateOfDeployment = DateTime.TryParse(Convert.ToString(d["dateofdeployment"]), out dt) ? Convert.ToDateTime(d["dateofdeployment"]) : DateTime.Now;
                                    sc.PhysicalExamination.DateOfRepatriation = DateTime.TryParse(Convert.ToString(d["dateofrepatriation"]), out dt) ? Convert.ToDateTime(d["dateofrepatriation"]) : DateTime.Now;
                                    sc.PhysicalExamination.CausesOfRepatriation = Convert.ToString(d["causesofrepatriation"]);
                                    sc.PhysicalExamination.FinalDiagnosis = Convert.ToString(d["finaldiagnosis"]);
                                    sc.PhysicalExamination.VesselType = Convert.ToString(d["vesseltype"]);
                                    sc.PhysicalExamination.SeaTrade = Convert.ToString(d["seatrade"]);
                                    sc.PhysicalExamination.Physician = Convert.ToString(d["physician"]);
                                    sc.PhysicalExamination.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.PhysicalExamination.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.PhysicalExamination.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.PhysicalExamination.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.PhysicalExamination.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_hematology":
                            #region CODE
                            if (sc.Hematology == null)
                                sc.Hematology = new Test_Hematology();

                            host.Search("select * from test_hematology where controlno='" + sc.ControlNo + "'", "test_hematology");
                            db1 = host["test_hematology"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.Hematology.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.Hematology.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.Hematology.Wbc = Convert.ToString(d["wbc"]);
                                    sc.Hematology.LymphPound = Convert.ToString(d["lymphPound"]);
                                    sc.Hematology.MidPound = Convert.ToString(d["midPound"]);
                                    sc.Hematology.GranPound = Convert.ToString(d["granPound"]);
                                    sc.Hematology.LymphPercent = Convert.ToString(d["lymphPercent"]);
                                    sc.Hematology.MidPercent = Convert.ToString(d["midpercent"]);
                                    sc.Hematology.GranPercent = Convert.ToString(d["granPercent"]);
                                    sc.Hematology.Hgb = Convert.ToString(d["hgb"]);
                                    sc.Hematology.Rbc = Convert.ToString(d["rbc"]);
                                    sc.Hematology.Hct = Convert.ToString(d["hct"]);
                                    sc.Hematology.Mcv = Convert.ToString(d["mcv"]);
                                    sc.Hematology.Mch = Convert.ToString(d["mch"]);
                                    sc.Hematology.Mchc = Convert.ToString(d["mchc"]);
                                    sc.Hematology.Rdw_Cv = Convert.ToString(d["rdw_cv"]);
                                    sc.Hematology.Rdw_Sd = Convert.ToString(d["rdw_sd"]);
                                    sc.Hematology.Plt = Convert.ToString(d["plt"]);
                                    sc.Hematology.Mpv = Convert.ToString(d["mpv"]);
                                    sc.Hematology.Pdw = Convert.ToString(d["pdw"]);
                                    sc.Hematology.Pct = Convert.ToString(d["pct"]);
                                    sc.Hematology.Wbc_Ref = Convert.ToString(d["wbc_ref"]);
                                    sc.Hematology.LymphPound_Ref = Convert.ToString(d["lymphPound_ref"]);
                                    sc.Hematology.MidPound_Ref = Convert.ToString(d["midPound_ref"]);
                                    sc.Hematology.GranPound_Ref = Convert.ToString(d["granPound_ref"]);
                                    sc.Hematology.LymphPercent_Ref = Convert.ToString(d["lymphPercent_ref"]);
                                    sc.Hematology.MidPercent_Ref = Convert.ToString(d["midpercent_ref"]);
                                    sc.Hematology.GranPercent_Ref = Convert.ToString(d["granPercent_ref"]);
                                    sc.Hematology.Hgb_Ref = Convert.ToString(d["hgb_ref"]);
                                    sc.Hematology.Rbc_Ref = Convert.ToString(d["rbc_ref"]);
                                    sc.Hematology.Hct_Ref = Convert.ToString(d["hct_ref"]);
                                    sc.Hematology.Mcv_Ref = Convert.ToString(d["mcv_Ref"]);
                                    sc.Hematology.Mch_Ref = Convert.ToString(d["mch_ref"]);
                                    sc.Hematology.Mchc_Ref = Convert.ToString(d["mchc_ref"]);
                                    sc.Hematology.Rdw_Cv_Ref = Convert.ToString(d["rdw_cv_ref"]);
                                    sc.Hematology.Rdw_Sd_Ref = Convert.ToString(d["rdw_sd_ref"]);
                                    sc.Hematology.Plt_Ref = Convert.ToString(d["plt_ref"]);
                                    sc.Hematology.Mpv_Ref = Convert.ToString(d["mpv_ref"]);
                                    sc.Hematology.Pdw_Ref = Convert.ToString(d["pdw_ref"]);
                                    sc.Hematology.Pct_Ref = Convert.ToString(d["pct_ref"]);
                                    sc.Hematology.Remarks = Convert.ToString(d["remarks"]);
                                    sc.Hematology.Note = Convert.ToString(d["note"]);
                                    sc.Hematology.MedTech = Convert.ToString(d["medtech"]);
                                    sc.Hematology.Pathologist = Convert.ToString(d["pathologist"]);
                                    sc.Hematology.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.Hematology.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.Hematology.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.Hematology.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.Hematology.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_cultureandsensitivity":
                            #region CODE
                            if (sc.CultureAndSensitivity == null)
                                sc.CultureAndSensitivity = new Test_CultureAndSensitivity();

                            host.Search("select * from test_cultureandsensitivity where controlno='" + sc.ControlNo + "'", "test_cultureandsensitivity");
                            db1 = host["test_cultureandsensitivity"];

                            if (db1.Length > 0)
                            {

                                var d = db1.ReturnRow[0];

                                sc.CultureAndSensitivity.TestID = Convert.ToUInt64(d["testID"]);
                                sc.CultureAndSensitivity.ControlNo = Convert.ToString(d["controlno"]);
                                sc.CultureAndSensitivity.Note = Convert.ToString(d["note"]);
                                sc.CultureAndSensitivity.MedTech = Convert.ToString(d["medtech"]);
                                sc.CultureAndSensitivity.Pathologist = Convert.ToString(d["pathologist"]);
                                sc.CultureAndSensitivity.CreatedBy = Convert.ToString(d["createdBy"]);
                                sc.CultureAndSensitivity.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                sc.CultureAndSensitivity.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                sc.CultureAndSensitivity.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();

                                #region ITEMS
                                host.Search("select * from test_cultureandsensitivity_item where testID='" + d["testID"] + "'", "test_cultureandsensitivity_item");
                                Database itemDB = host["test_cultureandsensitivity_item"];

                                if (itemDB.Length > 0)
                                {
                                    foreach (var item in itemDB.ReturnRow)
                                    {
                                        sc.CultureAndSensitivity.ItemList.Add(new Test_CultureAndSensitivity_Item()
                                        {
                                            ItemID = Convert.ToUInt64(item["itemID"]),
                                            TestID = Convert.ToUInt64(item["testID"]),
                                            Result = Convert.ToString(item["result"]),
                                            Count = Convert.ToString(item["count"])
                                        });
                                    }
                                }
                                #endregion

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.CultureAndSensitivity.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_dentalcertificate":
                            #region CODE
                            if (sc.DentalCertificate == null)
                                sc.DentalCertificate = new Test_DentalCertificate();

                            host.Search("select * from test_dentalcertificate where controlno='" + sc.ControlNo + "'", "test_dentalcertificate");
                            db1 = host["test_dentalcertificate"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.DentalCertificate.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.DentalCertificate.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.DentalCertificate.DateExamine = DateTime.TryParse(Convert.ToString(d["dateexamine"]), out dt) ? Convert.ToDateTime(d["dateexamine"]) : new DateTime();
                                    sc.DentalCertificate.Remarks = Convert.ToString(d["remarks"]);
                                    sc.DentalCertificate.Note = Convert.ToString(d["note"]);
                                    sc.DentalCertificate.Dentist = Convert.ToString(d["dentist"]);
                                    sc.DentalCertificate.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.DentalCertificate.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.DentalCertificate.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.DentalCertificate.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.DentalCertificate.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_gramstaining":
                            #region CODE
                            if (sc.GramStaining == null)
                                sc.GramStaining = new Test_GramStaining();

                            host.Search("select * from test_gramstaining where controlno='" + sc.ControlNo + "'", "test_gramstaining");
                            db1 = host["test_gramstaining"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.GramStaining.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.GramStaining.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.GramStaining.Result = Convert.ToString(d["result"]);
                                    sc.GramStaining.Remarks = Convert.ToString(d["remarks"]);
                                    sc.GramStaining.Note = Convert.ToString(d["note"]);
                                    sc.GramStaining.MedTech = Convert.ToString(d["medtech"]);
                                    sc.GramStaining.Pathologist = Convert.ToString(d["pathologist"]);
                                    sc.GramStaining.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.GramStaining.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.GramStaining.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.GramStaining.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.GramStaining.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_medicalcertificate":
                            #region CODE
                            if (sc.MedicalCertificate == null)
                                sc.MedicalCertificate = new Test_MedicalCertificate();

                            host.Search("select * from test_medicalCertificate where controlno='" + sc.ControlNo + "'", "test_medicalCertificate");
                            db1 = host["test_medicalCertificate"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.MedicalCertificate.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.MedicalCertificate.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.MedicalCertificate.DateExamine = DateTime.TryParse(Convert.ToString(d["dateexamine"]), out dt) ? Convert.ToDateTime(d["dateexamine"]) : new DateTime();
                                    sc.MedicalCertificate.Remarks = Convert.ToString(d["remarks"]);
                                    sc.MedicalCertificate.Note = Convert.ToString(d["note"]);
                                    sc.MedicalCertificate.Physician = Convert.ToString(d["physician"]);
                                    sc.MedicalCertificate.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.MedicalCertificate.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.MedicalCertificate.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.MedicalCertificate.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.MedicalCertificate.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_neuro":
                            #region CODE
                            if (sc.Neuro == null)
                                sc.Neuro = new Test_Neuro();

                            host.Search("select * from test_neuro where controlno='" + sc.ControlNo + "'", "test_neuro");
                            db1 = host["test_neuro"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.Neuro.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.Neuro.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.Neuro.Occupation = Convert.ToString(d["occupation"]);
                                    sc.Neuro.PlaceOfWork = Convert.ToString(d["place_of_work"]);
                                    sc.Neuro.Education = Convert.ToString(d["education"]);
                                    sc.Neuro.Religion = Convert.ToString(d["religion"]);
                                    sc.Neuro.A = Convert.ToByte(d["a"]);
                                    sc.Neuro.B1 = Convert.ToByte(d["b1"]);
                                    sc.Neuro.B2 = Convert.ToByte(d["b2"]);
                                    sc.Neuro.C1 = Convert.ToByte(d["c1"]);
                                    sc.Neuro.C2 = Convert.ToByte(d["c2"]);
                                    sc.Neuro.C3 = Convert.ToByte(d["c3"]);
                                    sc.Neuro.C4 = Convert.ToByte(d["c4"]);
                                    sc.Neuro.D1 = Convert.ToByte(d["d1"]);
                                    sc.Neuro.D2 = Convert.ToByte(d["d2"]);
                                    sc.Neuro.D3 = Convert.ToByte(d["d3"]);
                                    sc.Neuro.D4 = Convert.ToByte(d["d4"]);
                                    sc.Neuro.JobExperience = Convert.ToString(d["job_exp"]);
                                    sc.Neuro.Eligibility = Convert.ToString(d["eligibility"]);
                                    sc.Neuro.Remarks = Convert.ToString(d["remarks"]);
                                    sc.Neuro.Recommendation = Convert.ToString(d["recommendation"]);
                                    sc.Neuro.GeneralAppearance = Convert.ToByte(d["genapp"]);
                                    sc.Neuro.Attitude = Convert.ToByte(d["attitude"]);
                                    sc.Neuro.Memory = Convert.ToByte(d["memory"]);
                                    sc.Neuro.Speech = Convert.ToByte(d["speech"]);
                                    sc.Neuro.AffectAndMood = Convert.ToByte(d["affectandmood"]);
                                    sc.Neuro.ThoughtContent = Convert.ToByte(d["thoughtcontent"]);
                                    sc.Neuro.Suicidality = Convert.ToByte(d["suicidality"]);
                                    sc.Neuro.PreOccupations = Convert.ToByte(d["preoccupations"]);
                                    sc.Neuro.CognitionThinking = Convert.ToByte(d["cognitionthinking"]);
                                    sc.Neuro.Halucination = Convert.ToByte(d["halucination"]);
                                    sc.Neuro.Psychometrician = Convert.ToString(d["psychologist"]);
                                    sc.Neuro.Psychiatrist = Convert.ToString(d["psychiatrist"]);
                                    sc.Neuro.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.Neuro.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.Neuro.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.Neuro.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.Neuro.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_pregnancy":
                            #region CODE
                            if (sc.PregnancyTest == null)
                                sc.PregnancyTest = new Test_Pregnancy();

                            host.Search("select * from test_pregnancy where controlno='" + sc.ControlNo + "'", "test_pregnancy");
                            db1 = host["test_pregnancy"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.PregnancyTest.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.PregnancyTest.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.PregnancyTest.Result = Convert.ToString(d["result"]);
                                    sc.PregnancyTest.Remarks = Convert.ToString(d["remarks"]);
                                    sc.PregnancyTest.Note = Convert.ToString(d["note"]);
                                    sc.PregnancyTest.MedTech = Convert.ToString(d["medtech"]);
                                    sc.PregnancyTest.Pathologist = Convert.ToString(d["pathologist"]);
                                    sc.PregnancyTest.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.PregnancyTest.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.PregnancyTest.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.PregnancyTest.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.PregnancyTest.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_fecalysis":
                            #region CODE
                            if (sc.Fecalysis == null)
                                sc.Fecalysis = new Test_Fecalysis();

                            host.Search("select * from test_fecalysis where controlno='" + sc.ControlNo + "'", "test_fecalysis");
                            db1 = host["test_fecalysis"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.Fecalysis.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.Fecalysis.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.Fecalysis.Consistency = Convert.ToString(d["consistency"]);
                                    sc.Fecalysis.Color = Convert.ToString(d["color"]);
                                    sc.Fecalysis.Leukocytes = Convert.ToString(d["leukocytes"]);
                                    sc.Fecalysis.Erythrocytes = Convert.ToString(d["erythrocytes"]);
                                    sc.Fecalysis.FatGlobules = Convert.ToString(d["fat_globules"]);
                                    sc.Fecalysis.YeastCells = Convert.ToString(d["yeast_cells"]);
                                    sc.Fecalysis.OvaOfParasite = Convert.ToString(d["ova_of_parasite"]);
                                    sc.Fecalysis.Protozoan = Convert.ToString(d["protozoan"]);
                                    sc.Fecalysis.OccultBlood = Convert.ToString(d["occult_blood"]);
                                    sc.Fecalysis.Remarks = Convert.ToString(d["remarks"]);
                                    sc.Fecalysis.Note = Convert.ToString(d["note"]);
                                    sc.Fecalysis.MedTech = Convert.ToString(d["medtech"]);
                                    sc.Fecalysis.Pathologist = Convert.ToString(d["pathologist"]);
                                    sc.Fecalysis.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.Fecalysis.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.Fecalysis.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.Fecalysis.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.Fecalysis.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                        case "test_urinalysis":
                            #region CODE
                            if (sc.Urinalysis == null)
                                sc.Urinalysis = new Test_Urinalysis();

                            host.Search("select * from test_urinalysis where controlno='" + sc.ControlNo + "'", "test_urinalysis");
                            db1 = host["test_urinalysis"];

                            if (db1.Length > 0)
                            {
                                foreach (var d in db1.ReturnRow)
                                {
                                    sc.Urinalysis.TestID = Convert.ToUInt64(d["testID"]);
                                    sc.Urinalysis.ControlNo = Convert.ToString(d["controlno"]);
                                    sc.Urinalysis.Collection = Convert.ToString(d["collection"]);
                                    sc.Urinalysis.Color = Convert.ToString(d["color"]);
                                    sc.Urinalysis.Transparency = Convert.ToString(d["transparency"]);
                                    sc.Urinalysis.SpecificGravity = Convert.ToString(d["specific_gravity"]);
                                    sc.Urinalysis.PH = Convert.ToString(d["ph"]);
                                    sc.Urinalysis.Glucose = Convert.ToString(d["glucose"]);
                                    sc.Urinalysis.Protein = Convert.ToString(d["protein"]);
                                    sc.Urinalysis.Blood = Convert.ToString(d["blood"]);
                                    sc.Urinalysis.Leukocytes = Convert.ToString(d["leukocytes"]);
                                    sc.Urinalysis.Nitrite = Convert.ToString(d["nitrite"]);
                                    sc.Urinalysis.Ketone = Convert.ToString(d["ketone"]);
                                    sc.Urinalysis.Urobilinogen = Convert.ToString(d["urobilinogen"]);
                                    sc.Urinalysis.Ascorbic_Acid = Convert.ToString(d["ascorbic_acid"]);
                                    sc.Urinalysis.Rbc = Convert.ToString(d["rbc"]);
                                    sc.Urinalysis.Wbc = Convert.ToString(d["wbc"]);
                                    sc.Urinalysis.EpithelialCells = Convert.ToString(d["epithelial_cells"]);
                                    sc.Urinalysis.Bacteria = Convert.ToString(d["bacteria"]);
                                    sc.Urinalysis.MucusThread = Convert.ToString(d["mucus_thread"]);
                                    sc.Urinalysis.AUrates = Convert.ToString(d["a_urates"]);
                                    sc.Urinalysis.UricAcid = Convert.ToString(d["uric_acid"]);
                                    sc.Urinalysis.CalciumOxalate = Convert.ToString(d["calcium_oxalate"]);
                                    sc.Urinalysis.FineGranularCast = Convert.ToString(d["fine_granular_cast"]);
                                    sc.Urinalysis.CoarseGranularCast = Convert.ToString(d["coarse_granular_cast"]);
                                    sc.Urinalysis.WbcCast = Convert.ToString(d["wbc_cast"]);
                                    sc.Urinalysis.RbcCast = Convert.ToString(d["rbc_cast"]);
                                    sc.Urinalysis.Others = Convert.ToString(d["others"]);
                                    sc.Urinalysis.Remarks = Convert.ToString(d["remarks"]);
                                    sc.Urinalysis.Note = Convert.ToString(d["note"]);
                                    sc.Urinalysis.MedTech = Convert.ToString(d["medtech"]);
                                    sc.Urinalysis.Pathologist = Convert.ToString(d["pathologist"]);
                                    sc.Urinalysis.CreatedBy = Convert.ToString(d["createdBy"]);
                                    sc.Urinalysis.DateCreated = DateTime.TryParse(Convert.ToString(d["dateCreated"]), out dt) ? Convert.ToDateTime(d["dateCreated"]) : new DateTime();
                                    sc.Urinalysis.UpdatedBy = Convert.ToString(d["updatedBy"]);
                                    sc.Urinalysis.DateUpdated = DateTime.TryParse(Convert.ToString(d["dateUpdated"]), out dt) ? Convert.ToDateTime(d["dateUpdated"]) : new DateTime();
                                }

                                sc.TotalTestToEncode -= 1;
                            }
                            else
                            {
                                sc.Urinalysis.ControlNo = sc.ControlNo;
                                sc.TotalTestToEncode += 1;
                            }
                            #endregion
                            break;
                    }
                }
            }
        }

        void TbKeyWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Search();
        }

        void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void BtStatus_Click(object sender, RoutedEventArgs e)
        {
            SearchClientInfo sc = dataGrid1.SelectedItem as SearchClientInfo;
            if (sc != null)
            {
                ResultForm resForm = new ResultForm(sc);
                resForm.ShowDialog();
            }

        }
    }

    public class ByteToImageSourceConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                ImageSource img = (ImageSource)Edit.BmpSource(Edit.ByteArrayToImage((byte[])value));
                return img;
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                byte[] img = Edit.ImageToStream((System.Drawing.Image)Edit.BitmapSourceToBitmap((BitmapSource)value));
                return img;
            }
            else
                return null;
        }
    }
}
