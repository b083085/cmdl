using CMDL.Common;
using CMDL.DAL.Neuro;
using CMDL.Models;
using CMDL.Views.WPF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for NeuroV2Page.xaml
    /// </summary>
    public partial class NeuroV2Page : UserControl
    {
        public event Action SaveRecordEvent;

        public NeuroV2Page()
        {
            InitializeComponent();

            btnTemplates.Click += BtnTemplates_Click;
            btnSave.Click += BtnSave_Click;
            btnPreview.Click += BtnPreview_Click;
            Loaded += NeuroV2Page_Loaded;
        }



        #region EVENTS
        private void BtnTemplates_Click(object sender, RoutedEventArgs e)
        {
            var templatesForm = new NeuroTemplatesForm();
            templatesForm.CopyToRemarksEvent += TemplatesForm_CopyToRemarksEvent;
            templatesForm.ShowDialog();
        }
        private void TemplatesForm_CopyToRemarksEvent(string obj)
        {
            Neuro.Remarks = obj;
        }
        private void NeuroV2Page_Loaded(object sender, RoutedEventArgs e)
        {
            tbOccupation.Focus();
        }
        private void BtnPreview_Click(object sender, RoutedEventArgs e)
        {
            GetCheckItems();
            Preview();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnSave.Content != null)
                {
                    var saveContent = Convert.ToString(btnSave.Content).ToLower();
                    if (saveContent == "save record")
                    {
                        Save();
                    }
                    else if (saveContent == "print")
                    {
                        Print();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(CyberMessage.GetException(ex), "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
        #endregion
        #region FUNCTIONS
        private void Save()
        {
            GetCheckItems();

            if (ValidateEntries())
            {
                var frm = new CMDL.Views.WPF.PasswordForm();
                if (frm.ShowDialog().Value)
                {
                    using (var db = new DataContext())
                    {
                        var query = "INSERT INTO rev_neuro(ControlNo,Occupation,Education,JobExperience,Eligibility,IQTest,Retake,PersonalityTest,Others,Intelligence,Neuroticism," +
                                    "Extraversion,Openness,Agreeableness,Conscientiousness,GeneralAppearance,Emotions,Thoughts,Cognition,JudgmentAndInsight," +
                                    "SignificantRemarks,Remarks,Recommendation,Psychometrician,Psychologist,PrintedBy,B1,B2,C1,C2,C3,C4,D1,D2,D3,D4) " +
                                    "VALUES(@ControlNo,@Occupation,@Education,@JobExperience,@Eligibility,@IQTest,@Retake,@PersonalityTest,@Others,@Intelligence,@Neuroticism," +
                                    "@Extraversion,@Openness,@Agreeableness,@Conscientiousness,@GeneralAppearance,@Emotions,@Thoughts,@Cognition,@JudgmentAndInsight," +
                                    "@SignificantRemarks,@Remarks,@Recommendation,@Psychometrician,@Psychologist,@PrintedBy,@B1,@B2,@C1,@C2,@C3,@C4,@D1,@D2,@D3,@D4)";

                        Neuro.PrintedBy = GlobalInstance.Instance.User.UserName;

                        var parameters = new List<MySqlParam>();

                        parameters.Add(new MySqlParam() { Key = "@ControlNo", Value = Neuro.Client.ControlNo });
                        parameters.Add(new MySqlParam() { Key = "@Occupation", Value = Neuro.Occupation });
                        parameters.Add(new MySqlParam() { Key = "@Education", Value = Neuro.EducationalAttainment });
                        parameters.Add(new MySqlParam() { Key = "@JobExperience", Value = Neuro.JobExperience });
                        parameters.Add(new MySqlParam() { Key = "@Eligibility", Value = Neuro.Eligibility });
                        parameters.Add(new MySqlParam() { Key = "@IQTest", Value = Neuro.IQTest });
                        parameters.Add(new MySqlParam() { Key = "@Retake", Value = Neuro.Retake });
                        parameters.Add(new MySqlParam() { Key = "@PersonalityTest", Value = Neuro.PersonalityTest });
                        parameters.Add(new MySqlParam() { Key = "@Others", Value = Neuro.Others });
                        parameters.Add(new MySqlParam() { Key = "@Intelligence", Value = Neuro.Intelligence });
                        parameters.Add(new MySqlParam() { Key = "@Neuroticism", Value = Neuro.Neuroticism });
                        parameters.Add(new MySqlParam() { Key = "@Extraversion", Value = Neuro.Extraversion });
                        parameters.Add(new MySqlParam() { Key = "@Openness", Value = Neuro.Openness });
                        parameters.Add(new MySqlParam() { Key = "@Agreeableness", Value = Neuro.Agreeableness });
                        parameters.Add(new MySqlParam() { Key = "@Conscientiousness", Value = Neuro.Conscientiousness });
                        parameters.Add(new MySqlParam() { Key = "@GeneralAppearance", Value = Neuro.GeneralAppearance });
                        parameters.Add(new MySqlParam() { Key = "@Emotions", Value = Neuro.Emotions });
                        parameters.Add(new MySqlParam() { Key = "@Thoughts", Value = Neuro.Thoughts });
                        parameters.Add(new MySqlParam() { Key = "@Cognition", Value = Neuro.Cognition });
                        parameters.Add(new MySqlParam() { Key = "@JudgmentAndInsight", Value = Neuro.JudgmentAndInsight });
                        parameters.Add(new MySqlParam() { Key = "@SignificantRemarks", Value = Neuro.SignificantRemarks });
                        parameters.Add(new MySqlParam() { Key = "@Remarks", Value = Neuro.Remarks });
                        parameters.Add(new MySqlParam() { Key = "@Recommendation", Value = Neuro.Recommendation });
                        parameters.Add(new MySqlParam() { Key = "@Psychometrician", Value = Neuro.Psychometrician });
                        parameters.Add(new MySqlParam() { Key = "@Psychologist", Value = Neuro.Psychologist });
                        parameters.Add(new MySqlParam() { Key = "@PrintedBy", Value = Neuro.PrintedBy });
                        parameters.Add(new MySqlParam() { Key = "@B1", Value = Neuro.B1 });
                        parameters.Add(new MySqlParam() { Key = "@B2", Value = Neuro.B2 });
                        parameters.Add(new MySqlParam() { Key = "@C1", Value = Neuro.C1 });
                        parameters.Add(new MySqlParam() { Key = "@C2", Value = Neuro.C2 });
                        parameters.Add(new MySqlParam() { Key = "@C3", Value = Neuro.C3 });
                        parameters.Add(new MySqlParam() { Key = "@C4", Value = Neuro.C4 });
                        parameters.Add(new MySqlParam() { Key = "@D1", Value = Neuro.D1 });
                        parameters.Add(new MySqlParam() { Key = "@D2", Value = Neuro.D2 });
                        parameters.Add(new MySqlParam() { Key = "@D3", Value = Neuro.D3 });
                        parameters.Add(new MySqlParam() { Key = "@D4", Value = Neuro.D4 });

                        if (db.Save(query, parameters.ToArray()))
                        {
                            Neuro.IsReadOnly = true;
                            MessageBox.Show("Record Saved!");
                            Print();

                            SaveRecordEvent?.Invoke();
                        }
                    }
                }
            }
        }
        private void Print()
        {
            var doc = new NeuroV2_PrintDoc();
            GetSignatories(doc);

            doc.Print(Neuro);
        }
        private void Preview()
        {
            var doc = new NeuroV2_PrintDoc();
            GetSignatories(doc);

            doc.Preview(Neuro);
        }
        private void GetSignatories(NeuroV2_PrintDoc doc)
        {
            if (!string.IsNullOrEmpty(Neuro.Psychometrician))
            {
                foreach (var item in cbPsychometrician.Items)
                {
                    if (((Signatory)item).Name.ToLower() == Neuro.Psychometrician.ToLower())
                    {
                        doc.Psychometrician = item as Signatory;
                    }
                }
            }

            if (!string.IsNullOrEmpty(Neuro.Psychologist))
            {
                foreach (var item in cbPsychologist.Items)
                {
                    if (((Signatory)item).Name.ToLower() == Neuro.Psychologist.ToLower())
                    {
                        doc.Psychologist = item as Signatory;
                    }
                }
            }
        }
        private void GetSignatories(NeuroV3_PrintDoc doc)
        {
            if (!string.IsNullOrEmpty(Neuro.Psychometrician))
            {
                foreach (var item in cbPsychometrician.Items)
                {
                    if (((Signatory)item).Name.ToLower() == Neuro.Psychometrician.ToLower())
                    {
                        doc.Psychometrician = item as Signatory;
                    }
                }
            }

            if (!string.IsNullOrEmpty(Neuro.Psychologist))
            {
                foreach (var item in cbPsychologist.Items)
                {
                    if (((Signatory)item).Name.ToLower() == Neuro.Psychologist.ToLower())
                    {
                        doc.Psychologist = item as Signatory;
                    }
                }
            }
        }
        private bool ValidateEntries()
        {
            try
            {
                if (!string.IsNullOrEmpty(Neuro.Occupation))
                {
                    if (!string.IsNullOrEmpty(Neuro.EducationalAttainment))
                    {
                        if (!string.IsNullOrEmpty(Neuro.JobExperience))
                        {
                            if (!string.IsNullOrEmpty(Neuro.Eligibility))
                            {
                                if (!string.IsNullOrEmpty(Neuro.IQTest))
                                {
                                    if (!string.IsNullOrEmpty(Neuro.PersonalityTest))
                                    {
                                        if (Neuro.Intelligence > 0)
                                        {
                                            if (Neuro.B1 > 0)
                                            {
                                                if (Neuro.B2 > 0)
                                                {
                                                    if (Neuro.C1 > 0)
                                                    {
                                                        if (Neuro.C2 > 0)
                                                        {
                                                            if (Neuro.C3 > 0)
                                                            {
                                                                if (Neuro.C4 > 0)
                                                                {
                                                                    if (Neuro.D1 > 0)
                                                                    {
                                                                        if (Neuro.D2 > 0)
                                                                        {
                                                                            if (Neuro.D3 > 0)
                                                                            {
                                                                                if (Neuro.D4 > 0)
                                                                                {
                                                                                    if (Neuro.GeneralAppearance > 0)
                                                                                    {
                                                                                        if (Neuro.Emotions > 0)
                                                                                        {
                                                                                            if (Neuro.Thoughts > 0)
                                                                                            {
                                                                                                if (Neuro.Cognition > 0)
                                                                                                {
                                                                                                    if (Neuro.JudgmentAndInsight > 0)
                                                                                                    {
                                                                                                        if (!string.IsNullOrEmpty(Neuro.Remarks))
                                                                                                        {
                                                                                                            if (Neuro.Recommendation > 0)
                                                                                                            {
                                                                                                                if (!string.IsNullOrEmpty(Neuro.Psychometrician))
                                                                                                                {
                                                                                                                    if (!string.IsNullOrEmpty(Neuro.Psychologist))
                                                                                                                    {
                                                                                                                        return true;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        throw new Exception("Psychologist not specified.");
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    throw new Exception("Psychometrician not specified.");
                                                                                                                }
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                throw new Exception("Recommendation not specified.");
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            throw new Exception("Summary not specified.");
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        throw new Exception("Mental Status Examination: Judgment and Insight not specified.");
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    throw new Exception("Mental Status Examination: Cognition not specified.");
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                throw new Exception("Mental Status Examination: Thoughts not specified.");
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            throw new Exception("Mental Status Examination: Emotions not specified.");
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        throw new Exception("Mental Status Examination: General Appearance not specified.");
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    throw new Exception("D. WORK ATTITUDES, 4. Flexibility not specified.");
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                throw new Exception("D. WORK ATTITUDES, 3. Perseverance not specified.");
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            throw new Exception("D. WORK ATTITUDES, 2. Loyalty not specified.");
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        throw new Exception("D. WORK ATTITUDES, 1. Responsibility/Dependability not specified.");
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    throw new Exception("C. SOCIAL ADAPTABILITY, 4. with subordinates not specified.");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                throw new Exception("C. SOCIAL ADAPTABILITY, 3. with superior not specified.");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            throw new Exception("C. SOCIAL ADAPTABILITY, 2. with peers not specified.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        throw new Exception("C. SOCIAL ADAPTABILITY, 1. with people in general not specified.");
                                                    }
                                                }
                                                else
                                                {
                                                    throw new Exception("B. EMOTIONAL STABILITY, 2. Control of aggressive/hostile impulses not specified.");
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception("B. Emotional Stability, 1. Coping with stress not specified.");
                                            }
                                        }
                                        else
                                        {
                                            throw new Exception("Intelligence Test not specified.");
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Personality Test not specified.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("IQ Test not specified.");
                                }
                            }
                            else
                            {
                                throw new Exception("Eligibility not specified.");
                            }
                        }
                        else
                        {
                            throw new Exception("Job Experience not specified.");
                        }
                    }
                    else
                    {
                        throw new Exception("Educational Attainment not specified.");
                    }
                }
                else
                {
                    throw new Exception("Occupation not specified.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(CyberMessage.GetException(ex), "Validation", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            return false;
        }
        public void SetBinding(NeuroItemV2 item)
        {
            using (var db = new DataContext())
            {
                var psychometrianDS = db.Get("SELECT * FROM psychologist ORDER BY name ASC");
                if (db.HasRecords(psychometrianDS))
                {
                    var drc = db.GetRecords(psychometrianDS);
                    foreach (DataRow dr in drc)
                    {
                        if (!dr.IsNull("name"))
                        {
                            cbPsychometrician.Items.Add(new Signatory()
                            {
                                Name = dr.Field<string>("name"),
                                Title = dr.Field<string>("title")
                            });
                        }
                    }
                }

                var psychologistDS = db.Get("SELECT * FROM psychiatrist ORDER BY name ASC");
                if (db.HasRecords(psychologistDS))
                {
                    var drc = db.GetRecords(psychologistDS);
                    foreach (DataRow dr in drc)
                    {
                        if (!dr.IsNull("name"))
                        {
                            cbPsychologist.Items.Add(new Signatory()
                            {
                                Name = dr.Field<string>("name"),
                                Title = dr.Field<string>("title")
                            });
                        }
                    }
                }

                var tests = db.Get(@"SELECT distinct IQTest as 'Value','IQTest' as Test FROM rev_NEURO
                                    WHERE IQTest IS NOT NULL
                                    UNION
                                    SELECT distinct Retake as 'Value','Retake' as Test FROM rev_NEURO
                                    WHERE Retake IS NOT NULL
                                    UNION
                                    SELECT distinct PersonalityTest as 'Value','PersonalityTest' as Test FROM rev_NEURO
                                    WHERE PersonalityTest IS NOT NULL
                                    UNION
                                    SELECT distinct Others as 'Value','Others' as Test FROM rev_NEURO
                                    WHERE Others IS NOT NULL");


                if (db.HasRecords(tests))
                {
                    var drc = db.GetRecords(tests);
                    foreach (DataRow dr in drc)
                    {
                        var t = dr.Field<string>("Test");
                        var v = dr.Field<string>("Value");

                        switch (t.ToLower())
                        {
                            case "iqtest":
                                cbIQTest.Items.Add(v);
                                break;
                            case "retake":
                                cbRetake.Items.Add(v);
                                break;
                            case "personalitytest":
                                cbPersonalityTest.Items.Add(v);
                                break;
                            case "others":
                                cbOthers.Items.Add(v);
                                break;
                        }

                    }
                }


                var query = $"SELECT * FROM rev_neuro WHERE ControlNo = @neuroControlNo LIMIT 1";

                var parameter = new MySqlParam();
                parameter.Key = "@neuroControlNo";
                parameter.Value = item.Client.ControlNo;

                var ds = db.Get(query, parameter);
                if (db.HasRecords(ds))
                {
                    var drc = db.GetRecords(ds);
                    var dr = drc[0];

                    Neuro = new NeuroV2();
                    Neuro.IsReadOnly = true;

                    Neuro.Client = item.Client;
                    Neuro.Occupation = dr.IsNull("Occupation") ? string.Empty : dr.Field<string>("Occupation");
                    Neuro.EducationalAttainment = dr.IsNull("Education") ? string.Empty : dr.Field<string>("Education");
                    Neuro.JobExperience = dr.IsNull("JobExperience") ? string.Empty : dr.Field<string>("JobExperience");
                    Neuro.Eligibility = dr.IsNull("Eligibility") ? string.Empty : dr.Field<string>("Eligibility");
                    Neuro.IQTest = dr.IsNull("IQTest") ? string.Empty : dr.Field<string>("IQTest");
                    Neuro.Retake = dr.IsNull("Retake") ? string.Empty : dr.Field<string>("Retake");
                    Neuro.PersonalityTest = dr.IsNull("PersonalityTest") ? string.Empty : dr.Field<string>("PersonalityTest");
                    Neuro.Others = dr.IsNull("Others") ? string.Empty : dr.Field<string>("Others");

                    Neuro.Intelligence = dr.IsNull("Intelligence") ? (byte)0 : dr.Field<byte>("Intelligence");
                    Neuro.B1 = dr.IsNull("B1") ? (byte)0 : dr.Field<byte>("B1");
                    Neuro.B2 = dr.IsNull("B2") ? (byte)0 : dr.Field<byte>("B2");
                    Neuro.C1 = dr.IsNull("C1") ? (byte)0 : dr.Field<byte>("C1");
                    Neuro.C2 = dr.IsNull("C2") ? (byte)0 : dr.Field<byte>("C2");
                    Neuro.C3 = dr.IsNull("C3") ? (byte)0 : dr.Field<byte>("C3");
                    Neuro.C4 = dr.IsNull("C4") ? (byte)0 : dr.Field<byte>("C4");
                    Neuro.D1 = dr.IsNull("C1") ? (byte)0 : dr.Field<byte>("D1");
                    Neuro.D2 = dr.IsNull("C2") ? (byte)0 : dr.Field<byte>("D2");
                    Neuro.D3 = dr.IsNull("C3") ? (byte)0 : dr.Field<byte>("D3");
                    Neuro.D4 = dr.IsNull("C4") ? (byte)0 : dr.Field<byte>("D4");

                    Neuro.Neuroticism = dr.IsNull("Neuroticism") ? (byte)0 : dr.Field<byte>("Neuroticism");
                    Neuro.Extraversion = dr.IsNull("Extraversion") ? (byte)0 : dr.Field<byte>("Extraversion");
                    Neuro.Openness = dr.IsNull("Openness") ? (byte)0 : dr.Field<byte>("Openness");
                    Neuro.Agreeableness = dr.IsNull("Agreeableness") ? (byte)0 : dr.Field<byte>("Agreeableness");
                    Neuro.Conscientiousness = dr.IsNull("Conscientiousness") ? (byte)0 : dr.Field<byte>("Conscientiousness");
                    Neuro.GeneralAppearance = dr.IsNull("GeneralAppearance") ? (byte)0 : dr.Field<byte>("GeneralAppearance");
                    Neuro.Emotions = dr.IsNull("Emotions") ? (byte)0 : dr.Field<byte>("Emotions");
                    Neuro.Thoughts = dr.IsNull("Thoughts") ? (byte)0 : dr.Field<byte>("Thoughts");
                    Neuro.Cognition = dr.IsNull("Cognition") ? (byte)0 : dr.Field<byte>("Cognition");
                    Neuro.JudgmentAndInsight = dr.IsNull("JudgmentAndInsight") ? (byte)0 : dr.Field<byte>("JudgmentAndInsight");

                    Neuro.SignificantRemarks = dr.IsNull("SignificantRemarks") ? string.Empty : dr.Field<string>("SignificantRemarks");
                    Neuro.Remarks = dr.IsNull("Remarks") ? string.Empty : dr.Field<string>("Remarks");
                    Neuro.Recommendation = dr.IsNull("Recommendation") ? (byte)0 : dr.Field<byte>("Recommendation");
                    Neuro.Psychometrician = dr.IsNull("psychometrician") ? string.Empty : dr.Field<string>("psychometrician");
                    Neuro.Psychologist = dr.IsNull("psychologist") ? string.Empty : dr.Field<string>("psychologist");
                    Neuro.PrintedBy = dr.IsNull("printedby") ? string.Empty : dr.Field<string>("printedby");


                    SetCheckItems();

                }
                else
                {
                    Neuro = new NeuroV2();
                    Neuro.IsReadOnly = false;
                    Neuro.Client = item.Client;
                }

                this.DataContext = this;
            }
        }

        private void SetCheckItems()
        {
            SetIntelligenceTest();
            SetB1();
            SetB2();
            SetC1();
            SetC2();
            SetC3();
            SetC4();
            SetD1();
            SetD2();
            SetD3();
            SetD4();
            SetNeuroticism();
            SetExtraversion();
            SetOpenness();
            SetAgreeableness();
            SetConscientiousness();
            SetGeneralAppearance();
            SetEmotions();
            SetThoughts();
            SetCognition();
            SetJudgmentAndInsight();
            SetRecommendation();
        }
        private void GetCheckItems()
        {
            GetIntelligenceTest();
            GetB1();
            GetB2();
            GetC1();
            GetC2();
            GetC3();
            GetC4();
            GetD1();
            GetD2();
            GetD3();
            GetD4();
            GetNeuroticism();
            GetExtraversion();
            GetOpenness();
            GetAgreeableness();
            GetConscientiousness();
            GetGeneralAppearance();
            GetEmotions();
            GetThoughts();
            GetCognition();
            GetJudgmentAndInsight();
            GetRecommendation();
        }

        private void SetIntelligenceTest()
        {
            switch (Neuro.Intelligence)
            {
                case 1:
                    rb_IntTest_BelowAverage.IsChecked = true;
                    break;
                case 2:
                    rb_IntTest_LowerAverage.IsChecked = true;
                    break;
                case 3:
                    rb_IntTest_Average.IsChecked = true;
                    break;
                case 4:
                    rb_IntTest_AboveAverage.IsChecked = true;
                    break;
                case 5:
                    rb_IntTest_Superior.IsChecked = true;
                    break;
            }
        }
        private void SetB1()
        {
            switch (Neuro.B1)
            {
                case 1:
                    rb_B1_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_B1_Low.IsChecked = true;
                    break;
                case 3:
                    rb_B1_Average.IsChecked = true;
                    break;
                case 4:
                    rb_B1_High.IsChecked = true;
                    break;
                case 5:
                    rb_B1_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetB2()
        {
            switch (Neuro.B2)
            {
                case 1:
                    rb_B2_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_B2_Low.IsChecked = true;
                    break;
                case 3:
                    rb_B2_Average.IsChecked = true;
                    break;
                case 4:
                    rb_B2_High.IsChecked = true;
                    break;
                case 5:
                    rb_B2_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetC1()
        {
            switch (Neuro.C1)
            {
                case 1:
                    rb_C1_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_C1_Low.IsChecked = true;
                    break;
                case 3:
                    rb_C1_Average.IsChecked = true;
                    break;
                case 4:
                    rb_C1_High.IsChecked = true;
                    break;
                case 5:
                    rb_C1_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetC2()
        {
            switch (Neuro.C2)
            {
                case 1:
                    rb_C2_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_C2_Low.IsChecked = true;
                    break;
                case 3:
                    rb_C2_Average.IsChecked = true;
                    break;
                case 4:
                    rb_C2_High.IsChecked = true;
                    break;
                case 5:
                    rb_C2_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetC3()
        {
            switch (Neuro.C3)
            {
                case 1:
                    rb_C3_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_C3_Low.IsChecked = true;
                    break;
                case 3:
                    rb_C3_Average.IsChecked = true;
                    break;
                case 4:
                    rb_C3_High.IsChecked = true;
                    break;
                case 5:
                    rb_C3_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetC4()
        {
            switch (Neuro.C4)
            {
                case 1:
                    rb_C4_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_C4_Low.IsChecked = true;
                    break;
                case 3:
                    rb_C4_Average.IsChecked = true;
                    break;
                case 4:
                    rb_C4_High.IsChecked = true;
                    break;
                case 5:
                    rb_C4_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetD1()
        {
            switch (Neuro.D1)
            {
                case 1:
                    rb_D1_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_D1_Low.IsChecked = true;
                    break;
                case 3:
                    rb_D1_Average.IsChecked = true;
                    break;
                case 4:
                    rb_D1_High.IsChecked = true;
                    break;
                case 5:
                    rb_D1_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetD2()
        {
            switch (Neuro.D2)
            {
                case 1:
                    rb_D2_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_D2_Low.IsChecked = true;
                    break;
                case 3:
                    rb_D2_Average.IsChecked = true;
                    break;
                case 4:
                    rb_D2_High.IsChecked = true;
                    break;
                case 5:
                    rb_D2_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetD3()
        {
            switch (Neuro.D3)
            {
                case 1:
                    rb_D3_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_D3_Low.IsChecked = true;
                    break;
                case 3:
                    rb_D3_Average.IsChecked = true;
                    break;
                case 4:
                    rb_D3_High.IsChecked = true;
                    break;
                case 5:
                    rb_D3_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetD4()
        {
            switch (Neuro.D4)
            {
                case 1:
                    rb_D4_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_D4_Low.IsChecked = true;
                    break;
                case 3:
                    rb_D4_Average.IsChecked = true;
                    break;
                case 4:
                    rb_D4_High.IsChecked = true;
                    break;
                case 5:
                    rb_D4_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetNeuroticism()
        {
            switch (Neuro.Neuroticism)
            {
                case 1:
                    rb_Neuroticism_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_Neuroticism_Low.IsChecked = true;
                    break;
                case 3:
                    rb_Neuroticism_Average.IsChecked = true;
                    break;
                case 4:
                    rb_Neuroticism_High.IsChecked = true;
                    break;
                case 5:
                    rb_Neuroticism_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetExtraversion()
        {
            switch (Neuro.Extraversion)
            {
                case 1:
                    rb_Extraversion_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_Extraversion_Low.IsChecked = true;
                    break;
                case 3:
                    rb_Extraversion_Average.IsChecked = true;
                    break;
                case 4:
                    rb_Extraversion_High.IsChecked = true;
                    break;
                case 5:
                    rb_Extraversion_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetOpenness()
        {
            switch (Neuro.Openness)
            {
                case 1:
                    rb_Openness_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_Openness_Low.IsChecked = true;
                    break;
                case 3:
                    rb_Openness_Average.IsChecked = true;
                    break;
                case 4:
                    rb_Openness_High.IsChecked = true;
                    break;
                case 5:
                    rb_Openness_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetAgreeableness()
        {
            switch (Neuro.Agreeableness)
            {
                case 1:
                    rb_Agreeableness_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_Agreeableness_Low.IsChecked = true;
                    break;
                case 3:
                    rb_Agreeableness_Average.IsChecked = true;
                    break;
                case 4:
                    rb_Agreeableness_High.IsChecked = true;
                    break;
                case 5:
                    rb_Agreeableness_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetConscientiousness()
        {
            switch (Neuro.Conscientiousness)
            {
                case 1:
                    rb_Conscientiousness_VeryLow.IsChecked = true;
                    break;
                case 2:
                    rb_Conscientiousness_Low.IsChecked = true;
                    break;
                case 3:
                    rb_Conscientiousness_Average.IsChecked = true;
                    break;
                case 4:
                    rb_Conscientiousness_High.IsChecked = true;
                    break;
                case 5:
                    rb_Conscientiousness_VeryHigh.IsChecked = true;
                    break;
            }
        }
        private void SetGeneralAppearance()
        {
            switch (Neuro.GeneralAppearance)
            {
                case 1:
                    rb_GenApp_Well_groomed.IsChecked = true;
                    break;
                case 2:
                    rb_GenApp_Disheveled.IsChecked = true;
                    break;
                case 3:
                    rb_GenApp_PoorHygiene.IsChecked = true;
                    break;
            }
        }
        private void SetEmotions()
        {
            switch (Neuro.Emotions)
            {
                case 1:
                    rb_Emotions_Appropriate.IsChecked = true;
                    break;
                case 2:
                    rb_Emotions_Heightened.IsChecked = true;
                    break;
                case 3:
                    rb_Emotions_NonReactive.IsChecked = true;
                    break;
            }
        }
        private void SetThoughts()
        {
            switch (Neuro.Thoughts)
            {
                case 1:
                    rb_Thoughts_Logical.IsChecked = true;
                    break;
                case 2:
                    rb_Thoughts_Incoherent.IsChecked = true;
                    break;
                case 3:
                    rb_Thoughts_Suicidal.IsChecked = true;
                    break;
            }
        }
        private void SetCognition()
        {
            switch (Neuro.Cognition)
            {
                case 1:
                    rb_Cognition_Focused.IsChecked = true;
                    break;
                case 2:
                    rb_Cognition_Confused.IsChecked = true;
                    break;
                case 3:
                    rb_Cognition_Disoriented.IsChecked = true;
                    break;
            }
        }
        private void SetJudgmentAndInsight()
        {
            switch (Neuro.JudgmentAndInsight)
            {
                case 1:
                    rb_Judgment_Good.IsChecked = true;
                    break;
                case 2:
                    rb_Judgment_Fair.IsChecked = true;
                    break;
                case 3:
                    rb_Judgment_Poor.IsChecked = true;
                    break;
            }
        }
        private void SetRecommendation()
        {
            switch (Neuro.Recommendation)
            {
                case 1:
                    rbRecommended.IsChecked = true;
                    break;
                case 2:
                    rbMinimallyRecommended.IsChecked = true;
                    break;
                case 3:
                    rbNotRecommended.IsChecked = true;
                    break;
            }
        }

        private void GetIntelligenceTest()
        {
            if (rb_IntTest_BelowAverage.IsChecked.Value)
            {
                Neuro.Intelligence = 1;

            }
            else if (rb_IntTest_LowerAverage.IsChecked.Value)
            {
                Neuro.Intelligence = 2;

            }
            else if (rb_IntTest_Average.IsChecked.Value)
            {
                Neuro.Intelligence = 3;
            }
            else if (rb_IntTest_AboveAverage.IsChecked.Value)
            {
                Neuro.Intelligence = 4;

            }
            else if (rb_IntTest_Superior.IsChecked.Value)
            {
                Neuro.Intelligence = 5;
            }

        }
        private void GetB1()
        {
            if (rb_B1_VeryLow.IsChecked.Value)
            {
                Neuro.B1 = 1;

            }
            else if (rb_B1_Low.IsChecked.Value)
            {
                Neuro.B1 = 2;

            }
            else if (rb_B1_Average.IsChecked.Value)
            {
                Neuro.B1 = 3;

            }
            else if (rb_B1_High.IsChecked.Value)
            {
                Neuro.B1 = 4;

            }
            else if (rb_B1_VeryHigh.IsChecked.Value)
            {
                Neuro.B1 = 5;
            }
        }
        private void GetB2()
        {
            if (rb_B2_VeryLow.IsChecked.Value)
            {
                Neuro.B2 = 1;

            }
            else if (rb_B2_Low.IsChecked.Value)
            {
                Neuro.B2 = 2;

            }
            else if (rb_B2_Average.IsChecked.Value)
            {
                Neuro.B2 = 3;

            }
            else if (rb_B2_High.IsChecked.Value)
            {
                Neuro.B2 = 4;

            }
            else if (rb_B2_VeryHigh.IsChecked.Value)
            {
                Neuro.B2 = 5;
            }
        }
        private void GetC1()
        {
            if (rb_C1_VeryLow.IsChecked.Value)
            {
                Neuro.C1 = 1;

            }
            else if (rb_C1_Low.IsChecked.Value)
            {
                Neuro.C1 = 2;

            }
            else if (rb_C1_Average.IsChecked.Value)
            {
                Neuro.C1 = 3;

            }
            else if (rb_C1_High.IsChecked.Value)
            {
                Neuro.C1 = 4;

            }
            else if (rb_C1_VeryHigh.IsChecked.Value)
            {
                Neuro.C1 = 5;
            }
        }
        private void GetC2()
        {
            if (rb_C2_VeryLow.IsChecked.Value)
            {
                Neuro.C2 = 1;

            }
            else if (rb_C2_Low.IsChecked.Value)
            {
                Neuro.C2 = 2;

            }
            else if (rb_C2_Average.IsChecked.Value)
            {
                Neuro.C2 = 3;

            }
            else if (rb_C2_High.IsChecked.Value)
            {
                Neuro.C2 = 4;

            }
            else if (rb_C2_VeryHigh.IsChecked.Value)
            {
                Neuro.C2 = 5;
            }
        }
        private void GetC3()
        {
            if (rb_C3_VeryLow.IsChecked.Value)
            {
                Neuro.C3 = 1;

            }
            else if (rb_C3_Low.IsChecked.Value)
            {
                Neuro.C3 = 2;

            }
            else if (rb_C3_Average.IsChecked.Value)
            {
                Neuro.C3 = 3;

            }
            else if (rb_C3_High.IsChecked.Value)
            {
                Neuro.C3 = 4;

            }
            else if (rb_C3_VeryHigh.IsChecked.Value)
            {
                Neuro.C3 = 5;
            }
        }
        private void GetC4()
        {
            if (rb_C4_VeryLow.IsChecked.Value)
            {
                Neuro.C4 = 1;

            }
            else if (rb_C4_Low.IsChecked.Value)
            {
                Neuro.C4 = 2;

            }
            else if (rb_C4_Average.IsChecked.Value)
            {
                Neuro.C4 = 3;

            }
            else if (rb_C4_High.IsChecked.Value)
            {
                Neuro.C4 = 4;

            }
            else if (rb_C4_VeryHigh.IsChecked.Value)
            {
                Neuro.C4 = 5;
            }
        }
        private void GetD1()
        {
            if (rb_D1_VeryLow.IsChecked.Value)
            {
                Neuro.D1 = 1;

            }
            else if (rb_D1_Low.IsChecked.Value)
            {
                Neuro.D1 = 2;

            }
            else if (rb_D1_Average.IsChecked.Value)
            {
                Neuro.D1 = 3;

            }
            else if (rb_D1_High.IsChecked.Value)
            {
                Neuro.D1 = 4;

            }
            else if (rb_D1_VeryHigh.IsChecked.Value)
            {
                Neuro.D1 = 5;
            }
        }
        private void GetD2()
        {
            if (rb_D2_VeryLow.IsChecked.Value)
            {
                Neuro.D2 = 1;

            }
            else if (rb_D2_Low.IsChecked.Value)
            {
                Neuro.D2 = 2;

            }
            else if (rb_D2_Average.IsChecked.Value)
            {
                Neuro.D2 = 3;

            }
            else if (rb_D2_High.IsChecked.Value)
            {
                Neuro.D2 = 4;

            }
            else if (rb_D2_VeryHigh.IsChecked.Value)
            {
                Neuro.D2 = 5;
            }
        }
        private void GetD3()
        {
            if (rb_D3_VeryLow.IsChecked.Value)
            {
                Neuro.D3 = 1;

            }
            else if (rb_D3_Low.IsChecked.Value)
            {
                Neuro.D3 = 2;

            }
            else if (rb_D3_Average.IsChecked.Value)
            {
                Neuro.D3 = 3;

            }
            else if (rb_D3_High.IsChecked.Value)
            {
                Neuro.D3 = 4;

            }
            else if (rb_D3_VeryHigh.IsChecked.Value)
            {
                Neuro.D3 = 5;
            }
        }
        private void GetD4()
        {
            if (rb_D4_VeryLow.IsChecked.Value)
            {
                Neuro.D4 = 1;

            }
            else if (rb_D4_Low.IsChecked.Value)
            {
                Neuro.D4 = 2;

            }
            else if (rb_D4_Average.IsChecked.Value)
            {
                Neuro.D4 = 3;

            }
            else if (rb_D4_High.IsChecked.Value)
            {
                Neuro.D4 = 4;

            }
            else if (rb_D4_VeryHigh.IsChecked.Value)
            {
                Neuro.D4 = 5;
            }
        }
        private void GetNeuroticism()
        {
            if (rb_Neuroticism_VeryLow.IsChecked.Value)
            {
                Neuro.Neuroticism = 1;

            }
            else if (rb_Neuroticism_Low.IsChecked.Value)
            {
                Neuro.Neuroticism = 2;

            }
            else if (rb_Neuroticism_Average.IsChecked.Value)
            {
                Neuro.Neuroticism = 3;

            }
            else if (rb_Neuroticism_High.IsChecked.Value)
            {
                Neuro.Neuroticism = 4;

            }
            else if (rb_Neuroticism_VeryHigh.IsChecked.Value)
            {
                Neuro.Neuroticism = 5;
            }
        }
        private void GetExtraversion()
        {
            if (rb_Extraversion_VeryLow.IsChecked.Value)
            {
                Neuro.Extraversion = 1;

            }
            else if (rb_Extraversion_Low.IsChecked.Value)
            {
                Neuro.Extraversion = 2;

            }
            else if (rb_Extraversion_Average.IsChecked.Value)
            {
                Neuro.Extraversion = 3;

            }
            else if (rb_Extraversion_High.IsChecked.Value)
            {
                Neuro.Extraversion = 4;

            }
            else if (rb_Extraversion_VeryHigh.IsChecked.Value)
            {
                Neuro.Extraversion = 5;
            }
        }
        private void GetOpenness()
        {
            if (rb_Openness_VeryLow.IsChecked.Value)
            {
                Neuro.Openness = 1;

            }
            else if (rb_Openness_Low.IsChecked.Value)
            {
                Neuro.Openness = 2;

            }
            else if (rb_Openness_Average.IsChecked.Value)
            {
                Neuro.Openness = 3;

            }
            else if (rb_Openness_High.IsChecked.Value)
            {
                Neuro.Openness = 4;

            }
            else if (rb_Openness_VeryHigh.IsChecked.Value)
            {
                Neuro.Openness = 5;
            }
        }
        private void GetAgreeableness()
        {
            if (rb_Agreeableness_VeryLow.IsChecked.Value)
            {
                Neuro.Agreeableness = 1;

            }
            else if (rb_Agreeableness_Low.IsChecked.Value)
            {
                Neuro.Agreeableness = 2;

            }
            else if (rb_Agreeableness_Average.IsChecked.Value)
            {
                Neuro.Agreeableness = 3;

            }
            else if (rb_Agreeableness_High.IsChecked.Value)
            {
                Neuro.Agreeableness = 4;

            }
            else if (rb_Agreeableness_VeryHigh.IsChecked.Value)
            {
                Neuro.Agreeableness = 5;
            }
        }
        private void GetConscientiousness()
        {
            if (rb_Conscientiousness_VeryLow.IsChecked.Value)
            {
                Neuro.Conscientiousness = 1;

            }
            else if (rb_Conscientiousness_Low.IsChecked.Value)
            {
                Neuro.Conscientiousness = 2;

            }
            else if (rb_Conscientiousness_Average.IsChecked.Value)
            {
                Neuro.Conscientiousness = 3;

            }
            else if (rb_Conscientiousness_High.IsChecked.Value)
            {
                Neuro.Conscientiousness = 4;

            }
            else if (rb_Conscientiousness_VeryHigh.IsChecked.Value)
            {
                Neuro.Conscientiousness = 5;
            }
        }
        private void GetGeneralAppearance()
        {
            if (rb_GenApp_Well_groomed.IsChecked.Value)
            {
                Neuro.GeneralAppearance = 1;
            }
            else if (rb_GenApp_Disheveled.IsChecked.Value)
            {
                Neuro.GeneralAppearance = 2;
            }
            else if (rb_GenApp_PoorHygiene.IsChecked.Value)
            {
                Neuro.GeneralAppearance = 3;
            }
        }
        private void GetEmotions()
        {
            if (rb_Emotions_Appropriate.IsChecked.Value)
            {
                Neuro.Emotions = 1;
            }
            else if (rb_Emotions_Heightened.IsChecked.Value)
            {
                Neuro.Emotions = 2;
            }
            else if (rb_Emotions_NonReactive.IsChecked.Value)
            {
                Neuro.Emotions = 3;
            }
        }
        private void GetThoughts()
        {
            if (rb_Thoughts_Logical.IsChecked.Value)
            {
                Neuro.Thoughts = 1;
            }
            else if (rb_Thoughts_Incoherent.IsChecked.Value)
            {
                Neuro.Thoughts = 2;
            }
            else if (rb_Thoughts_Suicidal.IsChecked.Value)
            {
                Neuro.Thoughts = 3;
            }
        }
        private void GetCognition()
        {
            if (rb_Cognition_Focused.IsChecked.Value)
            {
                Neuro.Cognition = 1;
            }
            else if (rb_Cognition_Confused.IsChecked.Value)
            {
                Neuro.Cognition = 2;
            }
            else if (rb_Cognition_Disoriented.IsChecked.Value)
            {
                Neuro.Cognition = 3;
            }
        }
        private void GetJudgmentAndInsight()
        {
            if (rb_Judgment_Good.IsChecked.Value)
            {
                Neuro.JudgmentAndInsight = 1;
            }
            else if (rb_Judgment_Fair.IsChecked.Value)
            {
                Neuro.JudgmentAndInsight = 2;
            }
            else if (rb_Judgment_Poor.IsChecked.Value)
            {
                Neuro.JudgmentAndInsight = 3;
            }
        }
        private void GetRecommendation()
        {
            if (rbRecommended.IsChecked.Value)
            {
                Neuro.Recommendation = 1;
            }
            else if (rbMinimallyRecommended.IsChecked.Value)
            {
                Neuro.Recommendation = 2;
            }
            else if (rbNotRecommended.IsChecked.Value)
            {
                Neuro.Recommendation = 3;
            }
        }
        #endregion
        #region PROPERTIES
        public NeuroV2 Neuro
        {
            get;
            set;
        }
        #endregion

    }
}
