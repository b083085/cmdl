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
using System.ComponentModel;
using System.Data;
using CMDL.CLASS;
using CMDL.DAL;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for LabSearchClient.xaml
    /// </summary>
    public partial class LabSearchClient : Window
    {
        List<LabClientInfo> info = new List<LabClientInfo>();
        cmdldbDataSet cmdldb;

        string sqlquery;
        string user;

        public LabSearchClient(cmdldbDataSet cmdldb, string user)
        {
            InitializeComponent();

            this.cmdldb = cmdldb;
            this.user = user;

            dataGrid1.AutoGenerateColumns = false;
            dataGrid1.CanUserAddRows = false;
            dataGrid1.CanUserDeleteRows = false;

            dataGrid1.DataContext = info;

            TbKeyWord.KeyDown += new KeyEventHandler(TbKeyWord_KeyDown);

            CbFilter.SelectionChanged += new SelectionChangedEventHandler(CbFilter_SelectionChanged);
            BtSearch.Click += new RoutedEventHandler(BtSearch_Click);
            BtClearCheck.Click += new RoutedEventHandler(BtClearCheck_Click);
        }

        void BtClearCheck_Click(object sender, RoutedEventArgs e)
        {
            foreach (LabClientInfo client in info)
                if (client.Select == true)
                    client.Select = false;
        }
        void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
        void CbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = CbFilter.SelectedItem as ComboBoxItem;

            if (item.Content.ToString() == "DATE" || item.Content.ToString() == "BIRTH DATE")
            {
                DatePage dpage = new DatePage();
                if (dpage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    TbKeyWord.Text = dpage.GetDate;
            }
            TbKeyWord.Focus();
        }
        void TbKeyWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Search();
        }
        private string MedTechName()
        {
            foreach (DataRow m in cmdldb.Tables["medtech"].Rows)
            {
                if (Convert.ToString(m["user_name"]) == user)
                {
                    return Convert.ToString(m["name"]);
                }
            }

            return "";
        }
        private void SetBloodTyping(LabClientInfo lab_client, DataRow[] returnrow, int length)
        {
            if (length > 0)
            {
                DataRow d = returnrow[0];
                lab_client.Blood_Typing = new BloodTyping_Data(false)
                {
                    ReqPhysician = Convert.ToString(d["req_physician"]),
                    Results = Convert.ToString(d["results"]),
                    Remarks = Convert.ToString(d["remarks"]),
                    Pathologist = Convert.ToString(d["pathologist"]),
                    MedTech = Convert.ToString(d["medtech"]),
                    PrintedBy = Convert.ToString(d["printedby"])
                };

                lab_client.Count += 1;
            }
            else
            {
                BloodTyping_Data data = new BloodTyping_Data(true);

                foreach (DataRow p in cmdldb.Tables["pathologist"].Rows)
                {
                    if (Convert.ToChar(p["default"]) == '1')
                        data.Pathologist = Convert.ToString(p["name"]);
                }

                data.MedTech = MedTechName();
                lab_client.Blood_Typing = data;
            }
        }
        private void SetCBC(LabClientInfo lab_client, DataRow[] returnrow, int length)
        {
            if (length > 0)
            {
                DataRow d = returnrow[0];
                lab_client.CBC = new CBC_Data(false)
                {
                    Erythrocyte_Count = Convert.ToString(d["erythrocyte_count"]),
                    Hemoglobin = Convert.ToString(d["hemoglobin"]),
                    Hematocrit = Convert.ToString(d["hematocrit"]),
                    Leukocyte_Count = Convert.ToString(d["leukocyte_count"]),
                    Segmenters = Convert.ToString(d["segmenters"]),
                    Stabs = Convert.ToString(d["stabs"]),
                    Lymphocytes = Convert.ToString(d["lymphocytes"]),
                    Monocytes = Convert.ToString(d["monocytes"]),
                    Basophils = Convert.ToString(d["basophils"]),
                    Eosinophils = Convert.ToString(d["eosinophils"]),
                    Platelet = Convert.ToString(d["platelet"]),
                    Remarks = Convert.ToString(d["remarks"]),
                    Pathologist = Convert.ToString(d["pathologist"]),
                    MedTech = Convert.ToString(d["medtech"]),
                    PrintedBy = Convert.ToString(d["printedby"])
                };

                lab_client.Count += 1;


            }
            else
            {
                CBC_Data data = new CBC_Data(true);

                foreach (DataRow p in cmdldb.Tables["pathologist"].Rows)
                {
                    if (Convert.ToChar(p["default"]) == '1')
                        data.Pathologist = Convert.ToString(p["name"]);
                }
                data.MedTech = MedTechName();

                lab_client.CBC = data;
            }
        }
        private void SetGramsStaining(LabClientInfo lab_client, DataRow[] returnrow, int length)
        {
            if (length > 0)
            {
                DataRow d = returnrow[0];
                lab_client.Grams_Staining = new GramsStaining_Data(false)
                {

                    ReqPhysician = Convert.ToString(d["req_physician"]),
                    Results = Convert.ToString(d["results"]),
                    Remarks = Convert.ToString(d["remarks"]),
                    Pathologist = Convert.ToString(d["pathologist"]),
                    MedTech = Convert.ToString(d["medtech"]),
                    PrintedBy = Convert.ToString(d["printedby"])
                };
                lab_client.Count += 1;
            }
            else
            {
                GramsStaining_Data data = new GramsStaining_Data(true);
                foreach (DataRow p in cmdldb.Tables["pathologist"].Rows)
                {
                    if (Convert.ToChar(p["default"]) == '1')
                        data.Pathologist = Convert.ToString(p["name"]);
                }
                data.MedTech = MedTechName();

                lab_client.Grams_Staining = data;
            }
        }
        private void SetMedicalCertificate(LabClientInfo lab_client, DataRow[] returnrow, int length)
        {
            if (length > 0)
            {
                DataRow d = returnrow[0];
                lab_client.Medical_Certificate = new MedicalCertificate_Data(false)
                {
                    Date_approved = Convert.ToString(d["dateapproved"]),
                    Remarks = Convert.ToString(d["remarks"]),
                    Physician = Convert.ToString(d["physician"]),
                    License_No = Convert.ToString(d["license_no"]),
                    PrintedBy = Convert.ToString(d["printedby"])
                };
                lab_client.Count += 1;
            }
            else
            {
                lab_client.Medical_Certificate = new MedicalCertificate_Data(true);
            }
        }
        private void SetPE(LabClientInfo lab_client, DataRow[] returnrow, int length, string refby)
        {
            if (length > 0)
            {
                DataRow d = returnrow[0];
                lab_client.Physical_Examination = new PE_Data(false)
                    {
                        Nature_Of_Work = Convert.ToString(d["nature_of_work"]),
                        Growth_Development = Convert.ToString(d["growth_dev"]),
                        BP = Convert.ToString(d["bp"]),
                        HR = Convert.ToString(d["hr"]),
                        PR = Convert.ToString(d["pr"]),
                        Height = Convert.ToString(d["height"]),
                        Weight = Convert.ToString(d["weight"]),
                        Eyes = Convert.ToString(d["eyes"]),
                        OD = Convert.ToString(d["od"]),
                        OS = Convert.ToString(d["os"]),
                        Ishi_OD = Convert.ToString(d["ishi_od"]),
                        Ishi_OS = Convert.ToString(d["ishi_os"]),
                        Ears = Convert.ToString(d["ears"]),
                        Nose_Throat = Convert.ToString(d["nose_throat"]),
                        Dentals = Convert.ToString(d["dentals"]),
                        Breast = Convert.ToString(d["breast"]),
                        Extremities = Convert.ToString(d["extremities"]),
                        NeuroLog = Convert.ToString(d["neurolog"]),
                        Heart = Convert.ToString(d["heart"]),
                        Lungs = Convert.ToString(d["lungs"]),
                        Abdomen = Convert.ToString(d["abdomen"]),
                        Genitalia = Convert.ToString(d["genitalia"]),
                        Ano_Rectal = Convert.ToString(d["ano_rectal"]),
                        Skin = Convert.ToString(d["skin"]),
                        Other_Body_Parts = Convert.ToString(d["other_body_parts"]),
                        Past_Med_History = Convert.ToString(d["past_med_history"]),
                        CXR_Date = Convert.ToString(d["cxr_date"]),
                        Film_No = Convert.ToString(d["film_no"]),
                        CXR_Negative = Convert.ToString(d["cxr_negative"]),
                        CXR_Findings = Convert.ToString(d["cxr_findings"]),
                        CBC = Convert.ToString(d["cbc"]),
                        Urine = Convert.ToString(d["urine"]),
                        Stool = Convert.ToString(d["stool"]),
                        Blood_Chemistry = Convert.ToString(d["blood_chem"]),
                        Pregnancy_Test = Convert.ToString(d["preg_test"]),
                        VDRL = Convert.ToString(d["vdrl"]),
                        HepA = Convert.ToString(d["hep_a"]),
                        HepB = Convert.ToString(d["hep_b"]),
                        HIV = Convert.ToString(d["hiv"]),
                        Drug_Test = Convert.ToString(d["drug_test"]),
                        Blood_Typing = Convert.ToString(d["blood_type"]),
                        Other_Test = Convert.ToString(d["other_test"]),
                        Neuro_Psychological = Convert.ToString(d["neuro_psycho"]),
                        Neuro_Psychiatric = Convert.ToString(d["neuro_psychia"]),
                        Remarks = Convert.ToString(d["remarks"]),
                        Recommendation = Convert.ToString(d["recommendation"]),
                        Rec_Note = Convert.ToString(d["rec_note"]),
                        Ref_By = Convert.ToString(d["ref_by"]),
                        Physician = Convert.ToString(d["physician"]),
                        PrintedBy = Convert.ToString(d["printedby"]),
                    };

                lab_client.Count += 1;
            }
            else
            {
                PE_Data data = new PE_Data(true);
                data.Ref_By = refby;
                data.Physician = Convert.ToString(cmdldb.Tables["physician"].Rows[0]["name"]);
                data.GetPhysician = cmdldb.Tables["physician"];
                lab_client.Physical_Examination = data;
            }
        }
        private void SetPregTest(LabClientInfo lab_client, DataRow[] returnrow, int length)
        {
            if (length > 0)
            {
                DataRow d = returnrow[0];
                lab_client.Pregnancy_Test = new PregnancyTest_Data(false)
                {
                    ReqPhysician = Convert.ToString(d["req_physician"]),
                    Results = Convert.ToString(d["results"]),
                    Remarks = Convert.ToString(d["remarks"]),
                    Pathologist = Convert.ToString(d["pathologist"]),
                    MedTech = Convert.ToString(d["medtech"]),
                    PrintedBy = Convert.ToString(d["printedby"])


                };

                lab_client.Count += 1;
            }
            else
            {
                PregnancyTest_Data data = new PregnancyTest_Data(true);
                foreach (DataRow p in cmdldb.Tables["pathologist"].Rows)
                {
                    if (Convert.ToChar(p["default"]) == '1')
                        data.Pathologist = Convert.ToString(p["name"]);
                }
                data.MedTech = MedTechName();

                lab_client.Pregnancy_Test = data;
            }
        }
        private void SetSerology(LabClientInfo lab_client, DataRow[] returnrow, int length, string test, string controlno)
        {
            if (length > 0)
            {
                foreach (var d in returnrow)
                {
                    lab_client.Serology.Add(test, new Serology_Data(false)
                    {
                        Type = Convert.ToString(d["type"]),
                        AntiHIV_results = Convert.ToString(d["anti_hiv_res"]),
                        AntiHIV_Kit = Convert.ToString(d["anti_hiv_kit"]),
                        AntiHIV_LotNo = Convert.ToString(d["anti_hiv_lotno"]),
                        AntiHIV_Exp = Convert.ToString(d["anti_hiv_exp"]),
                        AntiHIV_Remarks = Convert.ToString(d["anti_hiv_remarks"]),
                        HBsAg_results = Convert.ToString(d["HBsAg_res"]),
                        HBsAg_Kit = Convert.ToString(d["HBsAg_kit"]),
                        HBsAg_LotNo = Convert.ToString(d["HBsAg_lotno"]),
                        HBsAg_Exp = Convert.ToString(d["HBsAg_exp"]),
                        HBsAg_Remarks = Convert.ToString(d["HBsAg_remarks"]),

                        AntiTP_results = Convert.ToString(d["anti_TP_res"]),
                        AntiTP_Kit = Convert.ToString(d["anti_TP_kit"]),
                        AntiTP_LotNo = Convert.ToString(d["anti_TP_lotno"]),
                        AntiTP_Exp = Convert.ToString(d["anti_TP_exp"]),
                        AntiTP_Remarks = Convert.ToString(d["anti_TP_remarks"]),

                        AntiHCV_results = Convert.ToString(d["antihcv_res"]),
                        AntiHCV_Kit = Convert.ToString(d["antihcv_kit"]),
                        AntiHCV_LotNo = Convert.ToString(d["antihcv_lotno"]),
                        AntiHCV_Exp = Convert.ToString(d["antihcv_exp"]),
                        AntiHCV_Remarks = Convert.ToString(d["antihcv_remarks"]),

                        Pathologist = Convert.ToString(d["pathologist"]),
                        MedTech_1 = Convert.ToString(d["medtech_1"]),
                        MedTech_2 = Convert.ToString(d["medtech_2"]),
                        PrintedBy = Convert.ToString(d["printedby"]),
                        Up_Controlno = Convert.ToString(d["up_controlno"]),

                    });
                    lab_client.Count += 1;
                }
            }
            else
            {
                Serology_Data sd = new Serology_Data(true);
                sd.Type = test;
                foreach (DataRow p in cmdldb.Tables["pathologist"].Rows)
                {
                    if (Convert.ToChar(p["default"]) == '1')
                        sd.Pathologist = Convert.ToString(p["name"]);
                }
                sd.MedTech_1 = MedTechName();

                switch (test)
                {
                    case "BLOOD TEST":
                        SetNewBloodTest(test, controlno, sd);
                        break;
                    case "HEP A":
                        SetNewHepA(test, controlno, sd);
                        break;
                    case "HIV":
                        SetNewHIV(test, controlno, sd);
                        break;
                    case "HEP B":
                    case "ANTI-HBS":
                        SetNewHepB(test, controlno, sd);
                        break;
                    case "RPR":
                    case "VDRL":
                        SetNewRPR(test, controlno, sd);
                        break;
                    case "SYPHILIS":
                        SetNewSyphilis(test, controlno, sd);
                        break;
                    case "HEP C":
                        #region CODE
                        SetNewHepC(test, controlno, sd);
                        #endregion
                        break;
                }

                lab_client.Serology.Add(test, sd);
            }
        }
        private void SetNewHepB(string test, string controlno, Serology_Data sd)
        {
            var hbsag1Kit = GetTestKit("HEP B");
            if (hbsag1Kit != null)
            {
                sd.HBsAg_Kit = hbsag1Kit.KitName;
                sd.HBsAg_LotNo = hbsag1Kit.LotNo;
                sd.HBsAg_Exp = hbsag1Kit.Expiry;
            }
            else
            {
                //sd.HBsAg_Kit = "EXPIRED";
                //sd.HBsAg_LotNo = "EXPIRED";
                //sd.HBsAg_Exp = "EXPIRED";
            }
            sd.HBsAg_Remarks = "NONE";
            sd.HBsAg_results = "NONREACTIVE";
            sd.Up_Controlno = test + "-" + controlno;
        }
        private void SetNewRPR(string test, string controlno, Serology_Data sd)
        {
            sd.AntiTP_Kit = string.Empty;
            sd.AntiTP_LotNo = string.Empty;
            sd.AntiTP_Exp = string.Empty;
            sd.AntiTP_Remarks = "NONE";
            sd.AntiTP_results = "NONREACTIVE";
            sd.Up_Controlno = test + "-" + controlno;
        }
        private void SetNewHepC(string test, string controlno, Serology_Data sd)
        {
            var hepc1Kit = GetTestKit("HEP C");
            if (hepc1Kit != null)
            {
                sd.AntiHCV_Kit = hepc1Kit.KitName;
                sd.AntiHCV_LotNo = hepc1Kit.LotNo;
                sd.AntiHCV_Exp = hepc1Kit.Expiry;
            }
            else
            {
                //sd.AntiHCV_Kit = "EXPIRED";
                //sd.AntiHCV_LotNo = "EXPIRED";
                //sd.AntiHCV_Exp = "EXPIRED";
            }
            sd.AntiHCV_Remarks = "NONE";
            sd.AntiHCV_results = "NONREACTIVE";
            sd.Up_Controlno = test + "-" + controlno;
        }
        private void SetNewSyphilis(string test, string controlno, Serology_Data sd)
        {
            var antitp1Kit = GetTestKit("SYPHILIS");
            if (antitp1Kit != null)
            {
                sd.AntiTP_Kit = antitp1Kit.KitName;
                sd.AntiTP_LotNo = antitp1Kit.LotNo;
                sd.AntiTP_Exp = antitp1Kit.Expiry;
            }
            else
            {
                //sd.AntiTP_Kit = "EXPIRED";
                //sd.AntiTP_LotNo = "EXPIRED";
                //sd.AntiTP_Exp = "EXPIRED";
            }
            sd.AntiTP_Remarks = "NONE";
            sd.AntiTP_results = "NONREACTIVE";
            sd.Up_Controlno = test + "-" + controlno;
        }
        private void SetNewHIV(string test, string controlno, Serology_Data sd)
        {
            var hiv1Kit = GetTestKit("HIV");
            if (hiv1Kit != null)
            {
                sd.AntiHIV_Kit = hiv1Kit.KitName;
                sd.AntiHIV_LotNo = hiv1Kit.LotNo;
                sd.AntiHIV_Exp = hiv1Kit.Expiry;
            }
            else
            {
                //sd.AntiHIV_Kit = "EXPIRED";
                //sd.AntiHIV_LotNo = "EXPIRED";
                //sd.AntiHIV_Exp = "EXPIRED";
            }
            sd.AntiHIV_Remarks = "NONE";
            sd.AntiHIV_results = "NONREACTIVE";
            sd.Up_Controlno = test + "-" + controlno;
        }
        private void SetNewHepA(string test, string controlno, Serology_Data sd)
        {
            sd.AntiHIV_Kit = string.Empty;
            sd.AntiHIV_LotNo = string.Empty;
            sd.AntiHIV_Exp = string.Empty;
            sd.AntiHIV_Remarks = "NONE";
            sd.AntiHIV_results = "NONREACTIVE";
            sd.Up_Controlno = test + "-" + controlno;
        }
        private void SetNewBloodTest(string test, string controlno, Serology_Data sd)
        {
            var hivKit = GetTestKit("HIV");
            if (hivKit != null)
            {
                sd.AntiHIV_Kit = hivKit.KitName;
                sd.AntiHIV_LotNo = hivKit.LotNo;
                sd.AntiHIV_Exp = hivKit.Expiry;
            }
            else
            {
                //sd.AntiHIV_Kit = "EXPIRED";
                //sd.AntiHIV_LotNo = "EXPIRED";
                //sd.AntiHIV_Exp = "EXPIRED";
            }
            sd.AntiHIV_Remarks = "NONE";

            var hbsagKit = GetTestKit("HEP B");
            if (hbsagKit != null)
            {
                sd.HBsAg_Kit = hbsagKit.KitName;
                sd.HBsAg_LotNo = hbsagKit.LotNo;
                sd.HBsAg_Exp = hbsagKit.Expiry;
            }
            else
            {
                //sd.HBsAg_Kit = "EXPIRED";
                //sd.HBsAg_LotNo = "EXPIRED";
                //sd.HBsAg_Exp = "EXPIRED";
            }

            sd.HBsAg_Remarks = "NONE";

            var antitpKit = GetTestKit("SYPHILIS");
            if (antitpKit != null)
            {
                sd.AntiTP_Kit = antitpKit.KitName;
                sd.AntiTP_LotNo = antitpKit.LotNo;
                sd.AntiTP_Exp = antitpKit.Expiry;
            }
            else
            {
                //sd.AntiTP_Kit = "EXPIRED";
                //sd.AntiTP_LotNo = "EXPIRED";
                //sd.AntiTP_Exp = "EXPIRED";
            }
            sd.AntiTP_Remarks = "NONE";

            var hepcKit = GetTestKit("HEP C");
            if (hepcKit != null)
            {
                sd.AntiHCV_Kit = hepcKit.KitName;
                sd.AntiHCV_LotNo = hepcKit.LotNo;
                sd.AntiHCV_Exp = hepcKit.Expiry;
            }
            else
            {
                //sd.AntiHCV_Kit = "EXPIRED";
                //sd.AntiHCV_LotNo = "EXPIRED";
                //sd.AntiHCV_Exp = "EXPIRED";
            }
            sd.AntiHCV_Remarks = "NONE";

            sd.AntiHIV_results = "NONREACTIVE";
            sd.HBsAg_results = "NONREACTIVE";
            sd.AntiTP_results = "NONREACTIVE";
            sd.AntiHCV_results = "NONREACTIVE";
            sd.Up_Controlno = test + "-" + controlno;
        }
        private void SetStoolExam(LabClientInfo lab_client, DataRow[] returnrow, int length)
        {
            if (length > 0)
            {
                DataRow d = returnrow[0];
                lab_client.Stool = new Stool_Data(false)
                {
                    Consistency = Convert.ToString(d["consistency"]),
                    Color = Convert.ToString(d["color"]),
                    Leukocytes = Convert.ToString(d["leukocytes"]),
                    Erythrocytes = Convert.ToString(d["erythrocytes"]),
                    Fat_Globules = Convert.ToString(d["fat_globules"]),
                    Yeast_Cells = Convert.ToString(d["yeast_cells"]),
                    Ova_Of_Parasite = Convert.ToString(d["ova_of_parasite"]),
                    Protozoan = Convert.ToString(d["protozoan"]),
                    Occult_Blood = Convert.ToString(d["occult_blood"]),
                    Remarks = Convert.ToString(d["remarks"]),
                    Pathologist = Convert.ToString(d["pathologist"]),
                    MedTech = Convert.ToString(d["medtech"]),
                    PrintedBy = Convert.ToString(d["printedby"])
                };

                lab_client.Count += 1;
            }
            else
            {
                Stool_Data data = new Stool_Data(true);

                foreach (DataRow p in cmdldb.Tables["pathologist"].Rows)
                {
                    if (Convert.ToChar(p["default"]) == '1')
                        data.Pathologist = Convert.ToString(p["name"]);
                }
                data.MedTech = MedTechName();
                lab_client.Stool = data;
            }
        }
        private void SetUrinalysis(LabClientInfo lab_client, DataRow[] returnrow, int length)
        {
            if (length > 0)
            {
                DataRow d = returnrow[0];
                lab_client.Urinalysis = new Urinalysis_Data(false)
                {
                    Collection = Convert.ToString(d["collection"]),
                    Color = Convert.ToString(d["color"]),
                    Transparency = Convert.ToString(d["transparency"]),
                    Specific_Gravity = Convert.ToString(d["specific_gravity"]),
                    PH = Convert.ToString(d["ph"]),
                    Glucose = Convert.ToString(d["glucose"]),
                    Protein = Convert.ToString(d["protein"]),
                    Blood = Convert.ToString(d["blood"]),
                    Leukocytes = Convert.ToString(d["leukocytes"]),
                    Nitrite = Convert.ToString(d["nitrite"]),
                    Ketone = Convert.ToString(d["ketone"]),
                    Urobilinogen = Convert.ToString(d["urobilinogen"]),
                    Ascorbic_Acid = Convert.ToString(d["ascorbic_acid"]),
                    RBC = Convert.ToString(d["rbc"]),
                    WBC = Convert.ToString(d["wbc"]),
                    Epithelial_Cells = Convert.ToString(d["epithelial_cells"]),
                    Bacteria = Convert.ToString(d["bacteria"]),
                    Mucus_Thread = Convert.ToString(d["mucus_thread"]),
                    A_Urates = Convert.ToString(d["a_urates"]),
                    Uric_Acid = Convert.ToString(d["uric_acid"]),
                    Calcium_Oxalate = Convert.ToString(d["calcium_oxalate"]),
                    Fine_Granular_Cast = Convert.ToString(d["fine_granular_cast"]),
                    Coarse_Granular_Cast = Convert.ToString(d["coarse_granular_cast"]),
                    WBC_Cast = Convert.ToString(d["wbc_cast"]),
                    RBC_Cast = Convert.ToString(d["rbc_cast"]),
                    Others = Convert.ToString(d["others"]),
                    Note = Convert.ToString(d["note"]),
                    Remarks = Convert.ToString(d["remarks"]),
                    Pathologist = Convert.ToString(d["pathologist"]),
                    MedTech = Convert.ToString(d["medtech"]),
                    PrintedBy = Convert.ToString(d["printedby"]),
                };

                lab_client.Count += 1;
            }
            else
            {
                Urinalysis_Data data = new Urinalysis_Data(true);
                foreach (DataRow p in cmdldb.Tables["pathologist"].Rows)
                {
                    if (Convert.ToChar(p["default"]) == '1')
                        data.Pathologist = Convert.ToString(p["name"]);
                }
                data.MedTech = MedTechName();
                lab_client.Urinalysis = data;
            }
        }
        private void SetCultAndSens(LabClientInfo lab_client, DataRow[] returnrow, int length, string controlNo)
        {


            if (length > 0)
            {
                DataRow d = returnrow[0];
                var csNo = Convert.ToString(d["csNo"]);
                var cs = new MySqlDB(Properties.Settings.Default.Server,
                                     Properties.Settings.Default.Database,
                                     Properties.Settings.Default.UserID,
                                     Properties.Settings.Default.Port,
                                     Properties.Settings.Default.Password);



                cs.Select("select * from cs_gramstain where gramNo='" + csNo + "'", "cs_gramstain");
                var gsList = new List<CS_GramStain>();
                if (cs.length > 0)
                {
                    foreach (var gs in cs.returnrow)
                    {
                        gsList.Add(new CS_GramStain
                        {
                            GSNo = Convert.ToString(gs["gsNo"]),
                            GramNo = Convert.ToString(gs["gramNo"]),
                            Result = Convert.ToString(gs["result"])
                        });
                    }
                }

                cs.Select("select * from cs_ido where IDONo='" + csNo + "'", "cs_ido");
                var idoList = new List<IDO>();
                if (cs.length > 0)
                {
                    foreach (var ido in cs.returnrow)
                    {
                        idoList.Add(new IDO
                        {
                            csIDONo = Convert.ToString(ido["csIDONo"]),
                            IDONo = Convert.ToString(ido["IDONo"]),
                            Organism = Convert.ToString(ido["results"]),
                            Count = Convert.ToString(ido["counts"])
                        });
                    }
                }

                cs.Select("select * from cs_sensitivities where senseNo='" + csNo + "'", "cs_sensitivities");
                var sensList = new List<Sensitivity>();
                if (cs.length > 0)
                {
                    foreach (var sen in cs.returnrow)
                    {
                        sensList.Add(new Sensitivity
                        {
                            cssNo = Convert.ToString(sen["cssNo"]),
                            senseNo = Convert.ToString(sen["senseNo"]),
                            Sensitivities = Convert.ToString(sen["results"]),
                            Count = Convert.ToString(sen["counts"])
                        });
                    }
                }


                lab_client.CultureAndSensitivity = new CultureAndSensitivity_Data(false)
                {
                    CSNo = csNo,
                    GramStainResult = gsList,
                    IDOResult = idoList,
                    SensitivityResult = sensList,
                    Note = Convert.ToString(d["note"]),
                    Sample = Convert.ToString(d["sample"]),
                    Pathologist = Convert.ToString(d["pathologist"]),
                    MedTech = Convert.ToString(d["medtech"]),
                    PrintedBy = Convert.ToString(d["printedby"]),
                };

                lab_client.Count += 1;
            }
            else
            {
                var data = new CultureAndSensitivity_Data(true)
                {
                    CSNo = controlNo,
                    GramStainResult = new List<CS_GramStain>(),
                    IDOResult = new List<IDO>(),
                    SensitivityResult = new List<Sensitivity>()
                };

                foreach (DataRow p in cmdldb.Tables["pathologist"].Rows)
                {
                    if (Convert.ToChar(p["default"]) == '1')
                        data.Pathologist = Convert.ToString(p["name"]);
                }
                data.MedTech = MedTechName();
                lab_client.CultureAndSensitivity = data;
            }
        }
        private void SetBloodChemistry(LabClientInfo lab_client, DataRow[] returnrow, int length, string controlNo)
        {


            if (length > 0)
            {
                DataRow d = returnrow[0];
                var bcID = Convert.ToString(d["bcID"]);
                var bc = new MySqlDB(Properties.Settings.Default.Server,
                                     Properties.Settings.Default.Database,
                                     Properties.Settings.Default.UserID,
                                     Properties.Settings.Default.Port,
                                     Properties.Settings.Default.Password);



                bc.Select("select * from blood_chemistry_items where bcID='" + bcID + "'", "blood_chemistry_items");
                var itemList = new List<Blood_Chemistry_Items_Data>();
                if (bc.length > 0)
                {
                    foreach (var dr in bc.returnrow)
                    {
                        itemList.Add(new Blood_Chemistry_Items_Data(false)
                        {
                            ItemID = Convert.ToUInt32(dr["itemID"]),
                            BcID = Convert.ToString(dr["bcID"]),
                            Category = Convert.ToString(dr["category"]),
                            Chemistry = Convert.ToString(dr["chemistry"]),
                            CUHL = Convert.ToString(dr["cuHL"]),
                            CURes = Convert.ToString(dr["cuRes"]),
                            CUUnit = Convert.ToString(dr["cuUnit"]),
                            CUValue = Convert.ToString(dr["cuValue"]),
                            SIHL = Convert.ToString(dr["siHL"]),
                            SIRes = Convert.ToString(dr["siRes"]),
                            SIUnit = Convert.ToString(dr["siUnit"]),
                            SIValue = Convert.ToString(dr["siValue"])
                        });
                    }
                }

                BloodChemistry_Data bcd = new BloodChemistry_Data(false);

                foreach (var i in itemList)
                    bcd.ItemList.Add(i);

                bcd.Note = Convert.ToString(d["note"]);
                bcd.Pathologist = Convert.ToString(d["pathologist"]);
                bcd.MedTech = Convert.ToString(d["medtech"]);
                bcd.PrintedBy = Convert.ToString(d["printedby"]);


                lab_client.BloodChemistry = bcd;
                lab_client.Count += 1;
            }
            else
            {
                var data = new BloodChemistry_Data(true)
                {
                    BCId = controlNo,

                };

                foreach (DataRow p in cmdldb.Tables["pathologist"].Rows)
                {
                    if (Convert.ToChar(p["default"]) == '1')
                        data.Pathologist = Convert.ToString(p["name"]);
                }

                data.MedTech = MedTechName();
                lab_client.BloodChemistry = data;
            }
        }
        private void SetPapSmear(LabClientInfo lab_client, DataRow[] returnrow, int length, string controlNo)
        {
            if (length > 0)
            {
                DataRow d = returnrow[0];
                lab_client.PapSmear = new PapSmear(false)
                {
                    testId = Convert.ToInt32(d["testId"]),
                    ControlNo = Convert.ToString(d["controlno"]),
                    System = Convert.ToString(d["system"]),
                    SpecimenType = Convert.ToString(d["specimen_type"]),
                    AdequacyOfSpecimen = Convert.ToString(d["adequacy_of_specimen"]),
                    GeneralCategorization = Convert.ToString(d["general_categorization"]),
                    Interpretation = Convert.ToString(d["interpretation"]),
                    InterpretedBy = Convert.ToString(d["interpretedBy"]),
                    InterpretedByTitle = Convert.ToString(d["interpretedByTitle"]),
                    Note = Convert.ToString(d["note"]),
                    Pathologist = Convert.ToString(d["pathologist"]),
                    Medtech = Convert.ToString(d["medtech"]),
                    PrintedBy = Convert.ToString(d["printedby"])
                };

                lab_client.Count += 1;


            }
            else
            {
                PapSmear data = new PapSmear(true);

                foreach (DataRow p in cmdldb.Tables["pathologist"].Rows)
                {
                    if (Convert.ToChar(p["default"]) == '1')
                        data.Pathologist = Convert.ToString(p["name"]);
                }

                data.ControlNo = controlNo;
                data.Medtech = MedTechName();

                lab_client.PapSmear = data;
            }
        }
        private void LoadInfo()
        {
            MySqlDB clients = new MySqlDB(Properties.Settings.Default.Server,
                             Properties.Settings.Default.Database,
                             Properties.Settings.Default.UserID,
                             Properties.Settings.Default.Port,
                             Properties.Settings.Default.Password);

            MySqlDB lab = new MySqlDB(Properties.Settings.Default.Server,
                                         Properties.Settings.Default.Database,
                                         Properties.Settings.Default.UserID,
                                         Properties.Settings.Default.Port,
                                         Properties.Settings.Default.Password);

            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, (Action)delegate
            {
                try
                {
                    clients.Select(Convert.ToString(sqlquery), "reg");
                    info.Clear();

                    if (clients.length > 0)
                    {
                        int priorityNo = 1;
                        foreach (DataRow client in clients.returnrow)
                        {
                            List<string> client_test = Test.Parse(cmdldb.Tables["exam"], Convert.ToString(client["exam"]), "LAB");

                            if (client_test.Contains("DRUG TEST") && client_test.Count == 1)
                            {

                            }
                            else
                            {
                                LabClientInfo lab_client = new LabClientInfo();
                                lab_client.Select = false;
                                lab_client.TimeIn = client["time_in"].ToString();
                                lab_client.Photo = (ImageSource)Edit.BmpSource(Edit.ByteArrayToImage((byte[])client["photo"]));
                                lab_client.ControlNo = client["controlno"].ToString();
                                lab_client.LastName = client["lastname"].ToString();
                                lab_client.FirstName = client["firstname"].ToString();
                                lab_client.MI = client["mi"].ToString();
                                lab_client.Suffix = client["suffix"].ToString();
                                lab_client.Age = client["age"].ToString();
                                lab_client.Sex = client["sex"].ToString();
                                lab_client.Exam = client["exam"].ToString();
                                lab_client.CivilStatus = client["civil_status"].ToString();
                                lab_client.RequestingParty = client["reqparty"].ToString();
                                lab_client.DistrictBranch = client["district_branch"].ToString();
                                lab_client.Address = client["address"].ToString();
                                lab_client.PriorityNo = priorityNo;

                                string tbname = "";

                                foreach (string t in client_test)
                                {
                                    #region CODES
                                    tbname = Test.TableName(cmdldb.Tables["exam"], t);

                                    if (tbname != "")
                                        lab_client.Total_Count += 1;

                                    switch (tbname)
                                    {

                                        case "blood_typing": lab.Select("select * from blood_typing where btype_controlno='" + Convert.ToString(client["controlno"]) + "'", "blood_typing");
                                            SetBloodTyping(lab_client, lab.returnrow, lab.length);
                                            break;

                                        case "cbc": lab.Select("select * from cbc where cbc_controlno='" + Convert.ToString(client["controlno"]) + "'", "cbc");
                                            SetCBC(lab_client, lab.returnrow, lab.length);
                                            break;
                                        case "grams_staining": lab.Select("select * from grams_staining where grams_controlno='" + Convert.ToString(client["controlno"]) + "'", "grams_staining");
                                            SetGramsStaining(lab_client, lab.returnrow, lab.length);
                                            break;
                                        case "medical_certificate": lab.Select("select * from medical_certificate where med_controlno='" + Convert.ToString(client["controlno"]) + "'", "medical_certificate");
                                            SetMedicalCertificate(lab_client, lab.returnrow, lab.length);
                                            break;
                                        case "pe": lab.Select("select * from pe where pe_controlno='" + Convert.ToString(client["controlno"]) + "'", "pe");
                                            SetPE(lab_client, lab.returnrow, lab.length, Convert.ToString(client["reqparty"]) + " - " + Convert.ToString(client["district_branch"]));
                                            break;
                                        case "preg_test": lab.Select("select * from preg_test where preg_test_controlno='" + Convert.ToString(client["controlno"]) + "'", "preg_test");
                                            SetPregTest(lab_client, lab.returnrow, lab.length);
                                            break;
                                        case "serology": lab.Select("select * from serology where serology_controlno='" + Convert.ToString(client["controlno"]) + "' and type='" + t + "'", "serology");
                                            SetSerology(lab_client, lab.returnrow, lab.length, t, Convert.ToString(client["controlno"]));
                                            break;
                                        case "stool": lab.Select("select * from stool where stool_controlno='" + Convert.ToString(client["controlno"]) + "'", "stool");
                                            SetStoolExam(lab_client, lab.returnrow, lab.length);
                                            break;
                                        case "urinalysis": lab.Select("select * from urinalysis where urine_controlno='" + Convert.ToString(client["controlno"]) + "'", "urinalysis");
                                            SetUrinalysis(lab_client, lab.returnrow, lab.length);
                                            break;
                                        case "cultureandsensitivity": lab.Select("select * from cultureandsensitivity where csNo='" + Convert.ToString(client["controlno"]) + "'", "cultureandsensitivity");
                                            SetCultAndSens(lab_client, lab.returnrow, lab.length, Convert.ToString(client["controlno"]));
                                            break;
                                        case "bloodchemistry": lab.Select("select * from bloodchemistry where bcID='" + Convert.ToString(client["controlno"]) + "'", "bloodchemistry");
                                            SetBloodChemistry(lab_client, lab.returnrow, lab.length, Convert.ToString(client["controlno"]));
                                            break;
                                        case "papsmear":
                                            lab.Select("select * from papsmear where controlNo='" + Convert.ToString(client["controlno"]) + "'", "papsmear");
                                            SetPapSmear(lab_client, lab.returnrow, lab.length, Convert.ToString(client["controlno"]));
                                            break;

                                    }
                                    #endregion

                                }
                                lab_client.Status = (lab_client.Count == lab_client.Total_Count ? "DONE" : "NOT DONE");
                                info.Add(lab_client);
                                priorityNo += 1;
                            }
                        }

                        dataGrid1.Items.Refresh();
                        TbResults.Text = "RESULT(S): " + Convert.ToString(info.Count);
                    }
                    else
                    {
                        MessageBox.Show("No Record(s) Found!");
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                }

                TbKeyWord.IsEnabled = true;
                BtSearch.Content = "SEARCH";
                BtSearch.IsEnabled = true;
            });
        }
        private void Search()
        {
            TbKeyWord.IsEnabled = false;
            BtSearch.Content = "SEARCHING...";
            BtSearch.IsEnabled = false;

            if (CbFilter.Text == "TODAY")
            {
                sqlquery = "select * from reg where date_reg='" + string.Format("{0:yyyy-MM-dd}", DateTime.Now) + "' and exam_type like '%LAB%'";
            }
            else if (CbFilter.Text == "ADDRESS" || CbFilter.Text == "BPLACE")
            {
                sqlquery = "select * from reg where " + CbFilter.Text + " like '%" + TbKeyWord.Text + "%' and exam_type like '%LAB%'";
            }
            else if (CbFilter.Text == "EXAM")
            {
                sqlquery = "select * from reg where exam like '%" + TbKeyWord.Text + "%' and exam_type like '%LAB%'";
            }
            else if (CbFilter.Text == "CUSTOM QUERY")
            {
                sqlquery = TbKeyWord.Text;
            }
            else
            {
                sqlquery = "select * from reg where " + ClientMethod.ConvertTableName(CbFilter.Text) + "='" + TbKeyWord.Text + "' and exam_type like '%LAB%'";
            }

            LoadInfo();
        }
        private void BtStatus_Click(object sender, RoutedEventArgs e)
        {
            var client = dataGrid1.SelectedItem as LabClientInfo;
            var page = new LabPage(client, cmdldb,AllowPrint,UserName);
            page.ShowDialog();
        }
        private SerologyTestKit GetTestKit(string test)
        {
            foreach (DataRow dr in cmdldb.Tables["testkit"].Rows)
            {
                if (Convert.ToString(dr["test"]) == test)
                {
                    return new SerologyTestKit()
                    {
                        TestName = Convert.ToString(dr["test"]),
                        KitName = Convert.ToString(dr["kit"]),
                        LotNo = Convert.ToString(dr["lotno"]),
                        Expiry = Convert.ToString(dr["exp"])
                    };
                }
            }

            return null;
        }
        public bool AllowPrint
        {
            set;
            get;
        }
        public string UserName
        {
            set;
            get;
        }

    }

    public class SerologyTestKit
    {
        private string testName;

        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }
        private string kitName;

        public string KitName
        {
            get { return kitName; }
            set { kitName = value; }
        }
        private string lotNo;

        public string LotNo
        {
            get { return lotNo; }
            set { lotNo = value; }
        }
        private string expiry;

        public string Expiry
        {
            get { return expiry; }
            set { expiry = value; }
        }
    }
}
