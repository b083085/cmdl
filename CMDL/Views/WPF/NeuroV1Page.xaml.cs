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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using CMDL.Models;
using CMDL.DAL.Neuro;

namespace CMDL
{
    /// <summary>
    /// Interaction logic for NeuroV1Page.xaml
    /// </summary>
    public partial class NeuroV1Page : UserControl
    {

        private const string RECOMMENDED = "RECOMMENDED";
        private const string MINIMALLY_RECOMMENDED = "MINIMALLY RECOMMENDED";
        private const string NOT_RECOMMENDED = "NOT RECOMMENDED";

        public NeuroV1Page()
        {
            InitializeComponent();

            cbRecommendation.Items.Add(RECOMMENDED);
            cbRecommendation.Items.Add(MINIMALLY_RECOMMENDED);
            cbRecommendation.Items.Add(NOT_RECOMMENDED);

            btnTemplates.Click += BtnTemplates_Click;
            btnSaveRecord.Click += BtnSaveRecord_Click;
            btnPreview.Click += BtnPreview_Click;
        }

        #region EVENTS
        private void BtnTemplates_Click(object sender, RoutedEventArgs e)
        {
            //var ntpage = new NeuroTemplatesPage(neuro_temp);
            //ntpage.NPage = this;
            //ntpage.ShowDialog();
        }
        private void BtnPreview_Click(object sender, RoutedEventArgs e)
        {
            var doc = new NeuroV1_PrintDoc();
            GetSignatories(doc);

            doc.Print(Neuro);
        }
        private void BtnSaveRecord_Click(object sender, RoutedEventArgs e)
        {
            if (Neuro.IsReadOnly)
            {
                var doc = new NeuroV1_PrintDoc();
                GetSignatories(doc);

                doc.Preview(Neuro);
            }
            else
            {

            }


            //if (BtSaveRecord.Content.ToString() == "SAVE RECORD")
            //{
            //    ValidateEntries();
            //}
            //else if (BtSaveRecord.Content.ToString() == "PRINT")
            //{
            //    if (AllowPrint)
            //    {
            //        doc.Preview(new List<NeuroClientInfo>() { info });
            //    }
            //    else
            //    {
            //        MessageBox.Show("User: " + UserName + " is not allowed to print neuro result(s)!","Print Result Message",MessageBoxButton.OK,MessageBoxImage.Stop);
            //    }
            //}
        }
        #endregion
        #region FUNCTIONS
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
                        if (!dr.IsNull("name") && !dr.IsNull("title"))
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
                        if (!dr.IsNull("name") && !dr.IsNull("title"))
                        {
                            cbPsychologist.Items.Add(new Signatory()
                            {
                                Name = dr.Field<string>("name"),
                                Title = dr.Field<string>("title")
                            });
                        }
                    }
                }

                var query = $"SELECT * FROM neuro WHERE neuro_controlno = @neuroControlNo";

                var parameter = new MySqlParam();
                parameter.Key = "@neuroControlNo";
                parameter.Value = item.Client.ControlNo;

                var ds = db.Get(query, parameter);
                if (db.HasRecords(ds))
                {
                    var drc = db.GetRecords(ds);
                    var dr = drc[0];

                    Neuro = new NeuroV1();
                    Neuro.IsReadOnly = true;

                    Neuro.Client = item.Client;
                    Neuro.Subject = dr.IsNull("subject") ? string.Empty : dr.Field<string>("subject");
                    Neuro.Occupation = dr.IsNull("occupation") ? string.Empty : dr.Field<string>("occupation");
                    Neuro.PlaceOfWork = dr.IsNull("place_of_work") ? string.Empty : dr.Field<string>("place_of_work");
                    Neuro.Education = dr.IsNull("education") ? string.Empty : dr.Field<string>("education");
                    Neuro.Religion = dr.IsNull("religion") ? string.Empty : dr.Field<string>("religion");

                    Neuro.A = dr.IsNull("a") ? (sbyte)0 : dr.Field<sbyte>("a");

                    Neuro.B1 = dr.IsNull("b1") ? (sbyte)0 : dr.Field<sbyte>("b1");
                    Neuro.B2 = dr.IsNull("b2") ? (sbyte)0 : dr.Field<sbyte>("b2");

                    Neuro.C1 = dr.IsNull("c1") ? (sbyte)0 : dr.Field<sbyte>("c1");
                    Neuro.C2 = dr.IsNull("c2") ? (sbyte)0 : dr.Field<sbyte>("c2");
                    Neuro.C3 = dr.IsNull("c3") ? (sbyte)0 : dr.Field<sbyte>("c3");
                    Neuro.C4 = dr.IsNull("c4") ? (sbyte)0 : dr.Field<sbyte>("c4");

                    Neuro.D1 = dr.IsNull("d1") ? (sbyte)0 : dr.Field<sbyte>("d1");
                    Neuro.D2 = dr.IsNull("d2") ? (sbyte)0 : dr.Field<sbyte>("d2");
                    Neuro.D3 = dr.IsNull("d3") ? (sbyte)0 : dr.Field<sbyte>("d3");
                    Neuro.D4 = dr.IsNull("d4") ? (sbyte)0 : dr.Field<sbyte>("d4");

                    Neuro.GenApp = dr.IsNull("genapp") ? (sbyte)0 : dr.Field<sbyte>("genapp");
                    Neuro.Attitude = dr.IsNull("attitude") ? (sbyte)0 : dr.Field<sbyte>("attitude");
                    Neuro.Memory = dr.IsNull("memory") ? (sbyte)0 : dr.Field<sbyte>("memory");
                    Neuro.Speech = dr.IsNull("speech") ? (sbyte)0 : dr.Field<sbyte>("speech");
                    Neuro.AffectAndMood = dr.IsNull("affectandmood") ? (sbyte)0 : dr.Field<sbyte>("affectandmood");
                    Neuro.ThoughtContent = dr.IsNull("thoughtcontent") ? (sbyte)0 : dr.Field<sbyte>("thoughtcontent");
                    Neuro.Suicidality = dr.IsNull("suicidality") ? (sbyte)0 : dr.Field<sbyte>("suicidality");
                    Neuro.PreOccupations = dr.IsNull("preoccupations") ? (sbyte)0 : dr.Field<sbyte>("preoccupations");
                    Neuro.CognitionThinking = dr.IsNull("cognitionthinking") ? (sbyte)0 : dr.Field<sbyte>("cognitionthinking");
                    Neuro.Halucination = dr.IsNull("halucination") ? (sbyte)0 : dr.Field<sbyte>("halucination");

                    Neuro.JobExperience = dr.IsNull("job_exp") ? string.Empty : dr.Field<string>("job_exp");
                    Neuro.Eligibility = dr.IsNull("eligibility") ? string.Empty : dr.Field<string>("eligibility");
                    Neuro.Remarks = dr.IsNull("remarks") ? string.Empty : dr.Field<string>("remarks");
                    Neuro.Recommendation = dr.IsNull("recommendation") ? string.Empty : dr.Field<string>("recommendation");

                    Neuro.Psychometrician = dr.IsNull("psychometrician") ? string.Empty : dr.Field<string>("psychometrician");
                    Neuro.Psychologist = dr.IsNull("psychiatrist") ? string.Empty : dr.Field<string>("psychiatrist");
                    Neuro.PrintedBy = dr.IsNull("printedby") ? string.Empty : dr.Field<string>("printedby");


                    SetCheckItems();


                }
                else
                {
                    Neuro = new NeuroV1();
                    Neuro.IsReadOnly = false;
                    Neuro.Client = item.Client;
                }

                this.DataContext = this;

            }
        }
        private void GetSignatories(NeuroV1_PrintDoc doc)
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

        private void GetA()
        {
            if (A1.IsChecked.Value)
            {
                Neuro.A = 1;
            }
            else if (A2.IsChecked.Value)
            {
                Neuro.A = 2;
            }
            else if (A3.IsChecked.Value)
            {
                Neuro.A = 3;
            }
            else if (A4.IsChecked.Value)
            {
                Neuro.A = 4;
            }
            else if (A5.IsChecked.Value)
            {
                Neuro.A = 5;
            }
        }
        private void GetB1()
        {
            if (B1_1.IsChecked.Value)
            {
                Neuro.B1 = 1;
            }
            else if (B1_2.IsChecked.Value)
            {
                Neuro.B1 = 2;
            }
            else if (B1_3.IsChecked.Value)
            {
                Neuro.B1 = 3;
            }
            else if (B1_4.IsChecked.Value)
            {
                Neuro.B1 = 4;
            }
            else if (B1_5.IsChecked.Value)
            {
                Neuro.B1 = 5;
            }
        }
        private void GetB2()
        {
            if (B2_1.IsChecked.Value)
            {
                Neuro.B2 = 1;
            }
            else if (B2_2.IsChecked.Value)
            {
                Neuro.B2 = 2;
            }
            else if (B2_3.IsChecked.Value)
            {
                Neuro.B2 = 3;
            }
            else if (B2_4.IsChecked.Value)
            {
                Neuro.B2 = 4;
            }
            else if (B2_5.IsChecked.Value)
            {
                Neuro.B2 = 5;
            }
        }
        private void GetC1()
        {
            if (C1_1.IsChecked.Value)
            {
                Neuro.C1 = 1;
            }
            else if (C1_2.IsChecked.Value)
            {
                Neuro.C1 = 2;
            }
            else if (C1_3.IsChecked.Value)
            {
                Neuro.C1 = 3;
            }
            else if (C1_4.IsChecked.Value)
            {
                Neuro.C1 = 4;
            }
            else if (C1_5.IsChecked.Value)
            {
                Neuro.C1 = 5;
            }
        }
        private void GetC2()
        {
            if (C2_1.IsChecked.Value)
            {
                Neuro.C2 = 1;
            }
            else if (C2_2.IsChecked.Value)
            {
                Neuro.C2 = 2;
            }
            else if (C2_3.IsChecked.Value)
            {
                Neuro.C2 = 3;
            }
            else if (C2_4.IsChecked.Value)
            {
                Neuro.C2 = 4;
            }
            else if (C2_5.IsChecked.Value)
            {
                Neuro.C2 = 5;
            }
        }
        private void GetC3()
        {
            if (C3_1.IsChecked.Value)
            {
                Neuro.C3 = 1;
            }
            else if (C3_2.IsChecked.Value)
            {
                Neuro.C3 = 2;
            }
            else if (C3_3.IsChecked.Value)
            {
                Neuro.C3 = 3;
            }
            else if (C3_4.IsChecked.Value)
            {
                Neuro.C3 = 4;
            }
            else if (C3_5.IsChecked.Value)
            {
                Neuro.C3 = 5;
            }
        }
        private void GetC4()
        {
            if (C4_1.IsChecked.Value)
            {
                Neuro.C4 = 1;
            }
            else if (C4_2.IsChecked.Value)
            {
                Neuro.C4 = 2;
            }
            else if (C4_3.IsChecked.Value)
            {
                Neuro.C4 = 3;
            }
            else if (C4_4.IsChecked.Value)
            {
                Neuro.C4 = 4;
            }
            else if (C4_5.IsChecked.Value)
            {
                Neuro.C4 = 5;
            }
        }
        private void GetD1()
        {
            if (D1_1.IsChecked.Value)
            {
                Neuro.D1 = 1;
            }
            else if (D1_2.IsChecked.Value)
            {
                Neuro.D1 = 2;
            }
            else if (D1_3.IsChecked.Value)
            {
                Neuro.D1 = 3;
            }
            else if (D1_4.IsChecked.Value)
            {
                Neuro.D1 = 4;
            }
            else if (D1_5.IsChecked.Value)
            {
                Neuro.D1 = 5;
            }
        }
        private void GetD2()
        {
            if (D2_1.IsChecked.Value)
            {
                Neuro.D2 = 1;
            }
            else if (D2_2.IsChecked.Value)
            {
                Neuro.D2 = 2;
            }
            else if (D2_3.IsChecked.Value)
            {
                Neuro.D2 = 3;
            }
            else if (D2_4.IsChecked.Value)
            {
                Neuro.D2 = 4;
            }
            else if (D2_5.IsChecked.Value)
            {
                Neuro.D2 = 5;
            }
        }
        private void GetD3()
        {
            if (D3_1.IsChecked.Value)
            {
                Neuro.D3 = 1;
            }
            else if (D3_2.IsChecked.Value)
            {
                Neuro.D3 = 2;
            }
            else if (D3_3.IsChecked.Value)
            {
                Neuro.D3 = 3;
            }
            else if (D3_4.IsChecked.Value)
            {
                Neuro.D3 = 4;
            }
            else if (D3_5.IsChecked.Value)
            {
                Neuro.D3 = 5;
            }
        }
        private void GetD4()
        {
            if (D4_1.IsChecked.Value)
            {
                Neuro.D4 = 1;
            }
            else if (D4_2.IsChecked.Value)
            {
                Neuro.D4 = 2;
            }
            else if (D4_3.IsChecked.Value)
            {
                Neuro.D4 = 3;
            }
            else if (D4_4.IsChecked.Value)
            {
                Neuro.D4 = 4;
            }
            else if (D4_5.IsChecked.Value)
            {
                Neuro.D4 = 5;
            }
        }
        private void GetGenApp()
        {
            if (rbWellGroomed.IsChecked.Value)
            {
                Neuro.GenApp = 1;
            }
            else if (rbUnkept.IsChecked.Value)
            {
                Neuro.GenApp = 2;
            }
            else if (rbVeryPoor.IsChecked.Value)
            {
                Neuro.GenApp = 3;
            }
        }
        private void GetAttitude()
        {
            if (rbCooperative.IsChecked.Value)
            {
                Neuro.Attitude = 1;
            }
            else if (rbUncooperative.IsChecked.Value)
            {
                Neuro.Attitude = 2;
            }
            else if (rbVeryAngry.IsChecked.Value)
            {
                Neuro.Attitude = 3;
            }
        }
        private void GetMemory()
        {
            if (rbMemoryNormal.IsChecked.Value)
            {
                Neuro.Memory = 1;
            }
            else if (rbMemorySlowed.IsChecked.Value)
            {
                Neuro.Memory = 2;
            }
            else if (rbDifficult.IsChecked.Value)
            {
                Neuro.Memory = 3;
            }
        }
        private void GetSpeech()
        {
            if (rbFluent.IsChecked.Value)
            {
                Neuro.Speech = 1;
            }
            else if (rbSpeechSlowed.IsChecked.Value)
            {
                Neuro.Speech = 2;
            }
            else if (rbBroken.IsChecked.Value)
            {
                Neuro.Speech = 3;
            }
        }
        private void GetAffectAndMood()
        {
            if (rbAffectAndMoodNormal.IsChecked.Value)
            {
                Neuro.AffectAndMood = 1;
            }
            else if (rbSad.IsChecked.Value)
            {
                Neuro.AffectAndMood = 2;
            }
            else if (rbManic.IsChecked.Value)
            {
                Neuro.AffectAndMood = 3;
            }
        }
        private void GetThoughtContent()
        {
            if (rbSpontaneous.IsChecked.Value)
            {
                Neuro.ThoughtContent = 1;
            }
            else if (rbIllogical.IsChecked.Value)
            {
                Neuro.ThoughtContent = 2;
            }
            else if (rbFlightOfIdeas.IsChecked.Value)
            {
                Neuro.ThoughtContent = 3;
            }
        }
        private void GetSuicidality()
        {
            if (rbNoPattern.IsChecked.Value)
            {
                Neuro.Suicidality = 1;
            }
            else if (rbThreats.IsChecked.Value)
            {
                Neuro.Suicidality = 2;
            }
            else if (rbPlanAttempt.IsChecked.Value)
            {
                Neuro.Suicidality = 3;
            }
        }
        private void GetPreoccupations()
        {
            if (rbPreoccupationNone.IsChecked.Value)
            {
                Neuro.PreOccupations = 1;
            }
            else if (rbAntiSocial.IsChecked.Value)
            {
                Neuro.PreOccupations = 2;
            }
            else if (rbObsessions.IsChecked.Value)
            {
                Neuro.PreOccupations = 3;
            }
        }
        private void GetCognition()
        {
            if (rbOrientation.IsChecked.Value)
            {
                Neuro.CognitionThinking = 1;
            }
            else if (rbIncomplete.IsChecked.Value)
            {
                Neuro.CognitionThinking = 2;
            }
            else if (rbDifficult.IsChecked.Value)
            {
                Neuro.CognitionThinking = 3;
            }
        }
        private void GetHalucination()
        {
            if (rbHalucinationNone.IsChecked.Value)
            {
                Neuro.Halucination = 1;
            }
            else if (rbVoice.IsChecked.Value)
            {
                Neuro.Halucination = 2;
            }
            else if (rbPersecutions.IsChecked.Value)
            {
                Neuro.Halucination = 3;
            }
        }

        private void GetCheckItems()
        {
            GetA();
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
            GetGenApp();
            GetAttitude();
            GetMemory();
            GetSpeech();
            GetAffectAndMood();
            GetThoughtContent();
            GetSuicidality();
            GetPreoccupations();
            GetCognition();
            GetHalucination();
        }


        private void SetA()
        {
            switch (Neuro.A)
            {
                case 1:
                    A1.IsChecked = true;
                    break;
                case 2:
                    A2.IsChecked = true;
                    break;
                case 3:
                    A3.IsChecked = true;
                    break;
                case 4:
                    A4.IsChecked = true;
                    break;
                case 5:
                    A5.IsChecked = true;
                    break;

            }
        }
        private void SetB1()
        {
            switch (Neuro.B1)
            {
                case 1:
                    B1_1.IsChecked = true;
                    break;
                case 2:
                    B1_2.IsChecked = true;
                    break;
                case 3:
                    B1_3.IsChecked = true;
                    break;
                case 4:
                    B1_4.IsChecked = true;
                    break;
                case 5:
                    B1_5.IsChecked = true;
                    break;

            }
        }
        private void SetB2()
        {
            switch (Neuro.B2)
            {
                case 1:
                    B2_1.IsChecked = true;
                    break;
                case 2:
                    B2_2.IsChecked = true;
                    break;
                case 3:
                    B2_3.IsChecked = true;
                    break;
                case 4:
                    B2_4.IsChecked = true;
                    break;
                case 5:
                    B2_5.IsChecked = true;
                    break;
            }
        }
        private void SetC1()
        {
            switch (Neuro.C1)
            {
                case 1:
                    C1_1.IsChecked = true;
                    break;
                case 2:
                    C1_2.IsChecked = true;
                    break;
                case 3:
                    C1_3.IsChecked = true;
                    break;
                case 4:
                    C1_4.IsChecked = true;
                    break;
                case 5:
                    C1_5.IsChecked = true;
                    break;
            }
        }
        private void SetC2()
        {
            switch (Neuro.C2)
            {
                case 1:
                    C2_1.IsChecked = true;
                    break;
                case 2:
                    C2_2.IsChecked = true;
                    break;
                case 3:
                    C2_3.IsChecked = true;
                    break;
                case 4:
                    C2_4.IsChecked = true;
                    break;
                case 5:
                    C2_5.IsChecked = true;
                    break;
            }
        }
        private void SetC3()
        {
            switch (Neuro.C3)
            {
                case 1:
                    C3_1.IsChecked = true;
                    break;
                case 2:
                    C3_2.IsChecked = true;
                    break;
                case 3:
                    C3_3.IsChecked = true;
                    break;
                case 4:
                    C3_4.IsChecked = true;
                    break;
                case 5:
                    C3_5.IsChecked = true;
                    break;

            }
        }
        private void SetC4()
        {
            switch (Neuro.C4)
            {
                case 1:
                    C4_1.IsChecked = true;
                    break;
                case 2:
                    C4_2.IsChecked = true;
                    break;
                case 3:
                    C4_3.IsChecked = true;
                    break;
                case 4:
                    C4_4.IsChecked = true;
                    break;
                case 5:
                    C4_5.IsChecked = true;
                    break;
            }
        }
        private void SetD1()
        {
            switch (Neuro.D1)
            {
                case 1:
                    D1_1.IsChecked = true;
                    break;
                case 2:
                    D1_2.IsChecked = true;
                    break;
                case 3:
                    D1_3.IsChecked = true;
                    break;
                case 4:
                    D1_4.IsChecked = true;
                    break;
                case 5:
                    D1_5.IsChecked = true;
                    break;
            }
        }
        private void SetD2()
        {
            switch (Neuro.D2)
            {
                case 1:
                    D2_1.IsChecked = true;
                    break;
                case 2:
                    D2_2.IsChecked = true;
                    break;
                case 3:
                    D2_3.IsChecked = true;
                    break;
                case 4:
                    D2_4.IsChecked = true;
                    break;
                case 5:
                    D2_5.IsChecked = true;
                    break;
            }
        }
        private void SetD3()
        {
            switch (Neuro.D3)
            {
                case 1:
                    D3_1.IsChecked = true;
                    break;
                case 2:
                    D3_2.IsChecked = true;
                    break;
                case 3:
                    D3_3.IsChecked = true;
                    break;
                case 4:
                    D3_4.IsChecked = true;
                    break;
                case 5:
                    D3_5.IsChecked = true;
                    break;
            }
        }
        private void SetD4()
        {
            switch (Neuro.D4)
            {
                case 1:
                    D4_1.IsChecked = true;
                    break;
                case 2:
                    D4_2.IsChecked = true;
                    break;
                case 3:
                    D4_3.IsChecked = true;
                    break;
                case 4:
                    D4_4.IsChecked = true;
                    break;
                case 5:
                    D4_5.IsChecked = true;
                    break;
            }
        }
        private void SetGenApp()
        {
            switch (Neuro.GenApp)
            {
                case 1:
                    rbWellGroomed.IsChecked = true;
                    break;
                case 2:
                    rbUnkept.IsChecked = true;
                    break;
                case 3:
                    rbVeryPoor.IsChecked = true;
                    break;
            }
        }
        private void SetAttitude()
        {
            switch (Neuro.Attitude)
            {
                case 1:
                    rbCooperative.IsChecked = true;
                    break;
                case 2:
                    rbUncooperative.IsChecked = true;
                    break;
                case 3:
                    rbVeryAngry.IsChecked = true;
                    break;
            }
        }
        private void SetMemory()
        {
            switch (Neuro.Memory)
            {
                case 1:
                    rbMemoryNormal.IsChecked = true;
                    break;
                case 2:
                    rbMemorySlowed.IsChecked = true;
                    break;
                case 3:
                    rbDifficult.IsChecked = true;
                    break;
            }
        }
        private void SetSpeech()
        {
            switch (Neuro.Speech)
            {
                case 1:
                    rbFluent.IsChecked = true;
                    break;
                case 2:
                    rbSpeechSlowed.IsChecked = true;
                    break;
                case 3:
                    rbBroken.IsChecked = true;
                    break;
            }
        }
        private void SetAffectAndMood()
        {
            switch (Neuro.AffectAndMood)
            {
                case 1:
                    rbAffectAndMoodNormal.IsChecked = true;
                    break;
                case 2:
                    rbSad.IsChecked = true;
                    break;
                case 3:
                    rbManic.IsChecked = true;
                    break;
            }
        }
        private void SetThoughtContent()
        {
            switch (Neuro.ThoughtContent)
            {
                case 1:
                    rbSpontaneous.IsChecked = true;
                    break;
                case 2:
                    rbIllogical.IsChecked = true;
                    break;
                case 3:
                    rbFlightOfIdeas.IsChecked = true;
                    break;
            }
        }
        private void SetSuicidality()
        {
            switch (Neuro.Suicidality)
            {
                case 1:
                    rbNoPattern.IsChecked = true;
                    break;
                case 2:
                    rbThreats.IsChecked = true;
                    break;
                case 3:
                    rbPlanAttempt.IsChecked = true;
                    break;
            }
        }
        private void SetPreoccupations()
        {
            switch (Neuro.PreOccupations)
            {
                case 1:
                    rbPreoccupationNone.IsChecked = true;
                    break;
                case 2:
                    rbAntiSocial.IsChecked = true;
                    break;
                case 3:
                    rbObsessions.IsChecked = true;
                    break;
            }
        }
        private void SetCognition()
        {
            switch (Neuro.CognitionThinking)
            {
                case 1:
                    rbOrientation.IsChecked = true;
                    break;
                case 2:
                    rbIncomplete.IsChecked = true;
                    break;
                case 3:
                    rbDifficult.IsChecked = true;
                    break;
            }
        }
        private void SetHalucination()
        {
            switch (Neuro.Halucination)
            {
                case 1:
                    rbHalucinationNone.IsChecked = true;
                    break;
                case 2:
                    rbVoice.IsChecked = true;
                    break;
                case 3:
                    rbPersecutions.IsChecked = true;
                    break;
            }
        }

        private void SetCheckItems()
        {
            SetA();
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
            SetGenApp();
            SetAttitude();
            SetMemory();
            SetSpeech();
            SetAffectAndMood();
            SetThoughtContent();
            SetSuicidality();
            SetPreoccupations();
            SetCognition();
            SetHalucination();
        }
        private void ValidateEntries()
        {
            //if (!String.IsNullOrWhiteSpace(TbReligion.Text))
            //{
            //    if (!String.IsNullOrWhiteSpace(TbOccupation.Text))
            //    {
            //        if (!String.IsNullOrWhiteSpace(TbPlaceOfWork.Text))
            //        {
            //            if (!String.IsNullOrWhiteSpace(TbEducAttainment.Text))
            //            {
            //                if (!String.IsNullOrWhiteSpace(info.A))
            //                {
            //                    if (!String.IsNullOrWhiteSpace(info.B1))
            //                    {
            //                        if (!String.IsNullOrWhiteSpace(info.B2))
            //                        {
            //                            if (!String.IsNullOrWhiteSpace(info.C1))
            //                            {
            //                                if (!String.IsNullOrWhiteSpace(info.C2))
            //                                {
            //                                    if (!String.IsNullOrWhiteSpace(info.C3))
            //                                    {
            //                                        if (!String.IsNullOrWhiteSpace(info.C4))
            //                                        {
            //                                            if (!String.IsNullOrWhiteSpace(info.D1))
            //                                            {
            //                                                if (!String.IsNullOrWhiteSpace(info.D2))
            //                                                {
            //                                                    if (!String.IsNullOrWhiteSpace(info.D3))
            //                                                    {
            //                                                        if (!String.IsNullOrWhiteSpace(info.D4))
            //                                                        {
            //                                                            if (!String.IsNullOrWhiteSpace(TbJobExp.Text))
            //                                                            {
            //                                                                if (!String.IsNullOrWhiteSpace(TbEligibility.Text))
            //                                                                {
            //                                                                    if (!String.IsNullOrWhiteSpace(TbRemarks.Text))
            //                                                                    {
            //                                                                        if (!String.IsNullOrWhiteSpace(CbRecommendation.Text))
            //                                                                        {
            //                                                                            if (!String.IsNullOrWhiteSpace(CbPsychometrician.Text))
            //                                                                            {
            //                                                                                if (!String.IsNullOrWhiteSpace(CbPsychiatrist.Text))
            //                                                                                {
            //                                                                                    if (!String.IsNullOrWhiteSpace(info.GenApp))
            //                                                                                    {
            //                                                                                        if (!String.IsNullOrWhiteSpace(info.Attitude))
            //                                                                                        {
            //                                                                                            if (!String.IsNullOrWhiteSpace(info.Memory))
            //                                                                                            {
            //                                                                                                if (!String.IsNullOrWhiteSpace(info.Speech))
            //                                                                                                {
            //                                                                                                    if (!String.IsNullOrWhiteSpace(info.AffectAndMood))
            //                                                                                                    {
            //                                                                                                        if (!String.IsNullOrWhiteSpace(info.ThoughtContent))
            //                                                                                                        {
            //                                                                                                            if (!String.IsNullOrWhiteSpace(info.Suicidality))
            //                                                                                                            {
            //                                                                                                                if (!String.IsNullOrWhiteSpace(info.Preoccupations))
            //                                                                                                                {
            //                                                                                                                    if (!String.IsNullOrWhiteSpace(info.CognitionThinking))
            //                                                                                                                    {
            //                                                                                                                        if (!String.IsNullOrWhiteSpace(info.Halucination))
            //                                                                                                                        {
            //                                                                                                                            PasswordPage ppage = new PasswordPage();
            //                                                                                                                            ppage.TableName = "office_user";
            //                                                                                                                            if (ppage.ShowDialog() == true)
            //                                                                                                                            {
            //                                                                                                                                BtSaveRecord.Content = "SAVING...";
            //                                                                                                                                BtSaveRecord.IsEnabled = false;
            //                                                                                                                                SaveRecord(ppage.User);
            //                                                                                                                            }
            //                                                                                                                        }
            //                                                                                                                        else
            //                                                                                                                        {
            //                                                                                                                            MessageBox.Show("Mental Status Examination:" + Environment.NewLine + "Halucination/Delusions not specified!");
            //                                                                                                                        }
            //                                                                                                                    }
            //                                                                                                                    else
            //                                                                                                                    {
            //                                                                                                                        MessageBox.Show("Mental Status Examination:" + Environment.NewLine + "Cognition/Thinking not specified!");
            //                                                                                                                    }
            //                                                                                                                }
            //                                                                                                                else
            //                                                                                                                {
            //                                                                                                                    MessageBox.Show("Mental Status Examination:" + Environment.NewLine + "Preoccupations not specified!");
            //                                                                                                                }
            //                                                                                                            }
            //                                                                                                            else
            //                                                                                                            {
            //                                                                                                                MessageBox.Show("Mental Status Examination:" + Environment.NewLine + "Suicidality not specified!");
            //                                                                                                            }
            //                                                                                                        }
            //                                                                                                        else
            //                                                                                                        {
            //                                                                                                            MessageBox.Show("Mental Status Examination:" + Environment.NewLine + "Thought Content not specified!");
            //                                                                                                        }
            //                                                                                                    }
            //                                                                                                    else
            //                                                                                                    {
            //                                                                                                        MessageBox.Show("Mental Status Examination:" + Environment.NewLine + "Affect and Mood not specified!");
            //                                                                                                    }
            //                                                                                                }
            //                                                                                                else
            //                                                                                                {
            //                                                                                                    MessageBox.Show("Mental Status Examination:" + Environment.NewLine + "Speech not specified!");
            //                                                                                                }
            //                                                                                            }
            //                                                                                            else
            //                                                                                            {
            //                                                                                                MessageBox.Show("Mental Status Examination:" + Environment.NewLine + "Memory not specified!");
            //                                                                                            }
            //                                                                                        }
            //                                                                                        else
            //                                                                                        {
            //                                                                                            MessageBox.Show("Mental Status Examination:" + Environment.NewLine + "Attitude not specified!");
            //                                                                                        }
            //                                                                                    }
            //                                                                                    else
            //                                                                                    {
            //                                                                                        MessageBox.Show("Mental Status Examination:" + Environment.NewLine + "General Appearance not specified!");
            //                                                                                    }
            //                                                                                }
            //                                                                                else
            //                                                                                {
            //                                                                                    MessageBox.Show("Psychiatrist not specified!");
            //                                                                                }
            //                                                                            }
            //                                                                            else
            //                                                                            {
            //                                                                                MessageBox.Show("Psychometrician not specified!");
            //                                                                            }
            //                                                                        }
            //                                                                        else
            //                                                                        {
            //                                                                            MessageBox.Show("Recommendation not specified!");
            //                                                                        }
            //                                                                    }
            //                                                                    else
            //                                                                    {
            //                                                                        MessageBox.Show("Remarks not specified!");
            //                                                                    }
            //                                                                }
            //                                                                else
            //                                                                {
            //                                                                    MessageBox.Show("Eligibility not specified!");
            //                                                                }
            //                                                            }
            //                                                            else
            //                                                            {
            //                                                                MessageBox.Show("Job Experience not specified!");
            //                                                            }
            //                                                        }
            //                                                        else
            //                                                        {
            //                                                            MessageBox.Show("D.Work Attitudes" + Environment.NewLine + "4.Flexibility not specified!");
            //                                                        }
            //                                                    }
            //                                                    else
            //                                                    {
            //                                                        MessageBox.Show("D.Work Attitudes" + Environment.NewLine + "3.Perseverance not specified!");
            //                                                    }
            //                                                }
            //                                                else
            //                                                {
            //                                                    MessageBox.Show("D.Work Attitudes" + Environment.NewLine + "2.Loyalty not specified!");
            //                                                }
            //                                            }
            //                                            else
            //                                            {
            //                                                MessageBox.Show("D.Work Attitudes" + Environment.NewLine + "1.Responsibility/Dependability not specified!");
            //                                            }
            //                                        }
            //                                        else
            //                                        {
            //                                            MessageBox.Show("C.Social Adaptability" + Environment.NewLine + "4.With subordinates not specified!");
            //                                        }
            //                                    }
            //                                    else
            //                                    {
            //                                        MessageBox.Show("C.Social Adaptability" + Environment.NewLine + "3.With superior not specified!");
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    MessageBox.Show("C.Social Adaptability" + Environment.NewLine + "2.With Peers not specified!");
            //                                }
            //                            }
            //                            else
            //                            {
            //                                MessageBox.Show("C.Social Adaptability" + Environment.NewLine + "1.With people in general not specified!");
            //                            }
            //                        }
            //                        else
            //                        {
            //                            MessageBox.Show("B.Emotional Stability" + Environment.NewLine + "2.Control of aggressive/hostile impulses not specified!");
            //                        }
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("B.Emotional Stability" + Environment.NewLine + "1.Coping with Stress not specified!");
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show("A.Intelligence not specified!");
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Educational Attainment not specified!");
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Place Of Work not specified!");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Occupation not specified!");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Religion not specified!");
            //}
        }
        #endregion
        #region PROPERTIES
        public NeuroV1 Neuro
        {
            get;
            set;
        }
        #endregion
    }
}
