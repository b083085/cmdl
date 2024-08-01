using CMDL.Common;
using CMDL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMDL.DAL.Neuro
{
    public class NeuroV1_PrintDoc
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog previewDocument;
        private CyberPrintPreview printPreviewDocument;
        private Font defaultLabel;
        private Font defaultBoldLabel;
        private Font factorLabel;
        private Font titleBarLabel;
        private Font printedByLabel;
        private Font signatoryLabel;
        private Font signatoryTitleLabel;
        private Brush blackBrush;
        private Brush whiteBrush;
        private Pen blackPen;
        private Pen grayPen;
        private int ctr = 0;

        public NeuroV1_PrintDoc()
        {
            printDocument = new PrintDocument();
            previewDocument = new PrintPreviewDialog();
            printPreviewDocument = new CyberPrintPreview();

            defaultLabel = FontGenerator.Regular(9.75F);
            defaultBoldLabel = FontGenerator.Bold(9.75F);
            factorLabel = FontGenerator.Bold(10F);
            titleBarLabel = FontGenerator.Bold(11.5F);
            printedByLabel = FontGenerator.Regular(6F);
            signatoryLabel = FontGenerator.Regular(9F);
            signatoryTitleLabel = FontGenerator.Regular(8F);
            blackBrush = Brushes.Black;
            whiteBrush = Brushes.White;
            blackPen = Pens.Black;
            grayPen = Pens.Gray;

            //paper size
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("Custom Size", 830, 1270);
            //smooth text preview
            previewDocument.UseAntiAlias = true;
            ((Form)previewDocument).WindowState = FormWindowState.Normal;
            ((Form)previewDocument).Size = new Size(600, 600);
            ((Form)previewDocument).StartPosition = FormStartPosition.CenterScreen;
            ((Form)previewDocument).Text = "PRINT PREVIEW";

            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        #region EVENTS
        void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                var model = NeuroList[ctr];

                StandardHeader.Print(e, model.Client.ControlNo, (Image)Edit.BitmapSourceToBitmap((System.Windows.Media.Imaging.BitmapSource)model.Client.Photo));

                //client info
                DrawPersonalInformation(e, model);

                //Title bar
                e.Graphics.FillRectangle(Brushes.DodgerBlue, new Rectangle(20, 315, 776, 20));
                e.Graphics.DrawRectangle(blackPen, new Rectangle(20, 315, 776, 20));
                e.Graphics.DrawString("NEURO PSYCHOLOGICAL TEST REPORT", titleBarLabel, whiteBrush, new RectangleF(new Point(20, 315), new SizeF(776, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //draw background logo
                e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, new Size(776, 300)), new RectangleF(new Point(20, 335), new SizeF(776, 300)));

                //FACTORS
                DrawFactorLabels(e);

                //draw box
                DrawFactorBox(e, 360);
                DrawFactorBox(e, 400);
                DrawFactorBox(e, 420);
                DrawFactorBox(e, 460);
                DrawFactorBox(e, 480);
                DrawFactorBox(e, 500);
                DrawFactorBox(e, 520);
                DrawFactorBox(e, 560);
                DrawFactorBox(e, 580);
                DrawFactorBox(e, 600);
                DrawFactorBox(e, 620);

                //fill rectangle with circles
                DrawFactor(e, model.A, 360);
                DrawFactor(e, model.B1, 400);
                DrawFactor(e, model.B2, 420);
                DrawFactor(e, model.C1, 460);
                DrawFactor(e, model.C2, 480);
                DrawFactor(e, model.C3, 500);
                DrawFactor(e, model.C4, 520);
                DrawFactor(e, model.D1, 560);
                DrawFactor(e, model.D2, 580);
                DrawFactor(e, model.D3, 600);
                DrawFactor(e, model.D4, 620);

                //LINE 1
                e.Graphics.DrawLine(blackPen, new Point(20, 640), new Point(796, 640));
                e.Graphics.DrawLine(blackPen, new Point(20, 643), new Point(796, 643));

                //D.RELATED FACTORS
                DrawRelatedFactors(e, model);

                //LINE 2
                e.Graphics.DrawLine(blackPen, new Point(20, 715), new Point(796, 715));
                e.Graphics.DrawLine(blackPen, new Point(20, 718), new Point(796, 718));

                //legend
                e.Graphics.DrawString("LEGEND:", factorLabel, blackBrush, new Point(47, 720));
                e.Graphics.DrawString("1. Poor\t 2. Fair\t 3. Adequate(Average)\t 4. Satisfactory\t 5. Very Satisfactory", defaultLabel, blackBrush, new Point(90, 740));

                //LINE 3
                e.Graphics.DrawLine(blackPen, new Point(20, 760), new Point(796, 760));
                e.Graphics.DrawLine(blackPen, new Point(20, 763), new Point(796, 763));

                //MENTAL STATUS EXAMINATION
                DrawMentalStatusLabels(e);

                DrawMSEBox(e, "well groomed", "unkept", "very poor", 800);
                DrawMSEBox(e, "cooperative", "uncooperative", "very angry", 820);
                DrawMSEBox(e, "normal", "slowed", "difficult", 840);
                DrawMSEBox(e, "fluent", "slowed", "broken", 860);
                DrawMSEBox(e, "normal", "sad", "manic", 880);
                DrawMSEBox(e, "spontaneous", "illogical", "flight of ideas", 900);
                DrawMSEBox(e, "no pattern", "threats", "plan/attempt", 920);
                DrawMSEBox(e, "none", "antisocial", "obsessions", 940);
                DrawMSEBox(e, "orientation", "incomplete", "disorganized", 960);
                DrawMSEBox(e, "none", "voice/visions", "persecutions", 980);

                DrawMSEEllipse(e, model.GenApp, 800);
                DrawMSEEllipse(e, model.Attitude, 820);
                DrawMSEEllipse(e, model.Memory, 840);
                DrawMSEEllipse(e, model.Speech, 860);
                DrawMSEEllipse(e, model.AffectAndMood, 880);
                DrawMSEEllipse(e, model.ThoughtContent, 900);
                DrawMSEEllipse(e, model.Suicidality, 920);
                DrawMSEEllipse(e, model.PreOccupations, 940);
                DrawMSEEllipse(e, model.CognitionThinking, 960);
                DrawMSEEllipse(e, model.Halucination, 980);

                //LINE 4
                e.Graphics.DrawLine(blackPen, new Point(20, 1000), new Point(796, 1000));
                e.Graphics.DrawLine(blackPen, new Point(20, 1003), new Point(796, 1003));

                //remarks
                e.Graphics.DrawString("REMARKS", factorLabel, blackBrush, new Point(47, 1020));
                e.Graphics.DrawString(string.IsNullOrEmpty(model.Remarks) ? string.Empty : model.Remarks.Trim(), defaultBoldLabel, blackBrush, new RectangleF(new Point(90, 1040), new SizeF(750, 260)), new StringFormat() { Alignment = StringAlignment.Near });

                //psychiatric
                e.Graphics.DrawString("PSYCHIATRIC:", defaultLabel, blackBrush, new Point(47, 1180));
                e.Graphics.DrawString("No psychotic ideation manifested at present", defaultBoldLabel, blackBrush, new Point(145, 1180));

                //recommendation
                e.Graphics.DrawString("RECOMMENDATION:", factorLabel, blackBrush, new Point(47, 1200));

                //draw box recommendation
                DrawRecommendation(e, model.Recommendation);

                //psychometrician
                e.Graphics.DrawString(model.Psychometrician, signatoryLabel, blackBrush, new RectangleF(new Point(20, 1240), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(Psychometrician != null ? Psychometrician.Title : string.Empty, signatoryTitleLabel, blackBrush, new RectangleF(new Point(20, 1255), new Size(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //psychiatrist
                e.Graphics.DrawString(model.Psychologist, signatoryLabel, blackBrush, new RectangleF(new Point(408, 1240), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(Psychologist != null ? Psychologist.Title : string.Empty, signatoryTitleLabel, blackBrush, new RectangleF(new Point(408, 1255), new Size(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //printed by
                e.Graphics.DrawString($"Printed By: {model.PrintedBy}", printedByLabel, blackBrush, new Point(20, 1265));


                //has more pages
                ctr++;
                e.HasMorePages = ctr < NeuroList.Count;

                //for reprinting
                if (ctr == NeuroList.Count)
                    ctr = 0;
            }
            catch (Exception)
            {
                //do nothing
            }

        }      
        #endregion
        #region FUNCTIONS
        private void DrawFactorBox(PrintPageEventArgs e, int ypos)
        {
            for (int i = 450; i <= 730; i += 70)
            {
                e.Graphics.DrawRectangle(grayPen, new Rectangle(i - 1, ypos + 1, 15, 15));
                e.Graphics.DrawRectangle(blackPen, new Rectangle(i, ypos, 15, 15));
            }
        }
        private void DrawFactor(PrintPageEventArgs e, sbyte factor, int ypos)
        {
            switch (factor)
            {
                case 1: e.Graphics.FillEllipse(blackBrush, new Rectangle(450, ypos, 15, 15)); break;
                case 2: e.Graphics.FillEllipse(blackBrush, new Rectangle(520, ypos, 15, 15)); break;
                case 3: e.Graphics.FillEllipse(blackBrush, new Rectangle(590, ypos, 15, 15)); break;
                case 4: e.Graphics.FillEllipse(blackBrush, new Rectangle(660, ypos, 15, 15)); break;
                case 5: e.Graphics.FillEllipse(blackBrush, new Rectangle(730, ypos, 15, 15)); break;
            }
        }
        private void DrawRecommendation(PrintPageEventArgs e, string res)
        {
            e.Graphics.DrawRectangle(grayPen, new Rectangle(219, 1201, 15, 15));
            e.Graphics.DrawRectangle(blackPen, new Rectangle(220, 1200, 15, 15));

            e.Graphics.DrawRectangle(grayPen, new Rectangle(369, 1201, 15, 15));
            e.Graphics.DrawRectangle(blackPen, new Rectangle(370, 1200, 15, 15));

            e.Graphics.DrawRectangle(grayPen, new Rectangle(579, 1201, 15, 15));
            e.Graphics.DrawRectangle(blackPen, new Rectangle(580, 1200, 15, 15));

            e.Graphics.DrawString("Recommended", defaultLabel, blackBrush, new Point(240, 1200));
            e.Graphics.DrawString("Minimally Recommended", defaultLabel, blackBrush, new Point(390, 1200));
            e.Graphics.DrawString("Not Recommended", defaultLabel, blackBrush, new Point(600, 1200));

            switch (res)
            {
                case "RECOMMENDED":
                    e.Graphics.FillEllipse(blackBrush, new Rectangle(220, 1200, 15, 15));
                    break;
                case "MINIMALLY RECOMMENDED":
                    e.Graphics.FillEllipse(blackBrush, new Rectangle(370, 1200, 15, 15));
                    break;
                case "NOT RECOMMENDED":
                    e.Graphics.FillEllipse(blackBrush, new Rectangle(580, 1200, 15, 15));
                    break;
            }
        }
        private void DrawMSEBox(PrintPageEventArgs e, string a, string b, string c, int ypos)
        {
            e.Graphics.DrawRectangle(grayPen, new Rectangle(349, ypos + 1, 15, 15));
            e.Graphics.DrawRectangle(blackPen, new Rectangle(350, ypos, 15, 15));
            e.Graphics.DrawString(a, defaultLabel, blackBrush, new Point(370, ypos));

            e.Graphics.DrawRectangle(grayPen, new Rectangle(509, ypos + 1, 15, 15));
            e.Graphics.DrawRectangle(blackPen, new Rectangle(510, ypos, 15, 15));
            e.Graphics.DrawString(b, defaultLabel, blackBrush, new Point(530, ypos));

            e.Graphics.DrawRectangle(grayPen, new Rectangle(669, ypos + 1, 15, 15));
            e.Graphics.DrawRectangle(blackPen, new Rectangle(670, ypos, 15, 15));
            e.Graphics.DrawString(c, defaultLabel, blackBrush, new Point(690, ypos));
        }
        private void DrawMSEEllipse(PrintPageEventArgs e, sbyte res, int ypos)
        {
            switch (res)
            {
                case 1: e.Graphics.FillEllipse(blackBrush, new Rectangle(350, ypos, 15, 15)); break;
                case 2: e.Graphics.FillEllipse(blackBrush, new Rectangle(510, ypos, 15, 15)); break;
                case 3: e.Graphics.FillEllipse(blackBrush, new Rectangle(670, ypos, 15, 15)); break;
            }
        }
        private void DrawMentalStatusLabels(PrintPageEventArgs e)
        {
            e.Graphics.DrawString("MENTAL STATUS EXAMINATION(MSE)", factorLabel, blackBrush, new Point(47, 780));
            e.Graphics.DrawString("A(Normal)", defaultBoldLabel, blackBrush, new Point(350, 780));
            e.Graphics.DrawString("B(Problem)", defaultBoldLabel, blackBrush, new Point(510, 780));
            e.Graphics.DrawString("C(Problem)", defaultBoldLabel, blackBrush, new Point(670, 780));
            e.Graphics.DrawString("General Appearance", defaultLabel, blackBrush, new Point(90, 800));
            e.Graphics.DrawString("Attitude", defaultLabel, blackBrush, new Point(90, 820));
            e.Graphics.DrawString("Memory", defaultLabel, blackBrush, new Point(90, 840));
            e.Graphics.DrawString("Speech", defaultLabel, blackBrush, new Point(90, 860));
            e.Graphics.DrawString("Affect and Mood", defaultLabel, blackBrush, new Point(90, 880));
            e.Graphics.DrawString("Thought Content", defaultLabel, blackBrush, new Point(90, 900));
            e.Graphics.DrawString("Suicidality", defaultLabel, blackBrush, new Point(90, 920));
            e.Graphics.DrawString("Preoccupations", defaultLabel, blackBrush, new Point(90, 940));
            e.Graphics.DrawString("Cognition/Thinking", defaultLabel, blackBrush, new Point(90, 960));
            e.Graphics.DrawString("Halucinations/Delusions", defaultLabel, blackBrush, new Point(90, 980));
        }
        private void DrawRelatedFactors(PrintPageEventArgs e, NeuroV1 model)
        {
            e.Graphics.DrawString("E.RELATED FACTORS:", factorLabel, blackBrush, new Point(47, 655));
            e.Graphics.DrawString("a.Job Experience:", defaultLabel, blackBrush, new Point(90, 675));
            e.Graphics.DrawString(model.JobExperience, defaultBoldLabel, blackBrush, new Point(203, 675));
            e.Graphics.DrawString("b.Eligibility:", defaultLabel, blackBrush, new Point(90, 695));
            e.Graphics.DrawString(model.Eligibility, defaultBoldLabel, blackBrush, new Point(162, 695));
        }
        private void DrawFactorLabels(PrintPageEventArgs e)
        {
            e.Graphics.DrawString("FACTORS", factorLabel, blackBrush, new Point(47, 340));
            e.Graphics.DrawString("1", defaultBoldLabel, blackBrush, new Point(450, 340));
            e.Graphics.DrawString("2", defaultBoldLabel, blackBrush, new Point(520, 340));
            e.Graphics.DrawString("3", defaultBoldLabel, blackBrush, new Point(590, 340));
            e.Graphics.DrawString("4", defaultBoldLabel, blackBrush, new Point(660, 340));
            e.Graphics.DrawString("5", defaultBoldLabel, blackBrush, new Point(730, 340));
            e.Graphics.DrawString("A.INTELLIGENCE", factorLabel, blackBrush, new Point(47, 360));
            e.Graphics.DrawString("B.EMOTIONAL STABILITY", factorLabel, blackBrush, new Point(47, 380));
            e.Graphics.DrawString("1.Coping with stress", defaultLabel, blackBrush, new Point(90, 400));
            e.Graphics.DrawString("2.Control of aggressive/hostile impulses", defaultLabel, blackBrush, new Point(90, 420));
            e.Graphics.DrawString("C.SOCIAL ADAPTABILITY", factorLabel, blackBrush, new Point(47, 440));
            e.Graphics.DrawString("1.With people in general", defaultLabel, blackBrush, new Point(90, 460));
            e.Graphics.DrawString("2.With peers", defaultLabel, blackBrush, new Point(90, 480));
            e.Graphics.DrawString("3.With superior", defaultLabel, blackBrush, new Point(90, 500));
            e.Graphics.DrawString("4.With subordinates", defaultLabel, blackBrush, new Point(90, 520));
            e.Graphics.DrawString("D.WORK ATTITUDES", factorLabel, blackBrush, new Point(47, 540));
            e.Graphics.DrawString("1.Responsibility/Dependability", defaultLabel, blackBrush, new Point(90, 560));
            e.Graphics.DrawString("2.Loyalty", defaultLabel, blackBrush, new Point(90, 580));
            e.Graphics.DrawString("3.Perseverance", defaultLabel, blackBrush, new Point(90, 600));
            e.Graphics.DrawString("4.Flexibility", defaultLabel, blackBrush, new Point(90, 620));
        }
        private void DrawPersonalInformation(PrintPageEventArgs e, NeuroV1 model)
        {
            e.Graphics.DrawString("Name:", defaultLabel, blackBrush, new Point(47, 119));
            e.Graphics.DrawString(model.Client.FullName, defaultBoldLabel, blackBrush, new Point(90, 119));
            e.Graphics.DrawString("Home Address:", defaultLabel, blackBrush, new Point(47, 141));
            e.Graphics.DrawString(model.Client.HomeAddress, defaultBoldLabel, blackBrush, new RectangleF(new Point(145, 141), new SizeF(340, 40)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Religion:", defaultLabel, blackBrush, new Point(47, 185));
            e.Graphics.DrawString(model.Religion, defaultBoldLabel, blackBrush, new Point(104, 185));
            e.Graphics.DrawString("Occupation:", defaultLabel, blackBrush, new Point(47, 207));
            e.Graphics.DrawString(model.Occupation, defaultBoldLabel, blackBrush, new Point(124, 207));
            e.Graphics.DrawString("Place Of Work:", defaultLabel, blackBrush, new Point(47, 229));
            e.Graphics.DrawString(model.PlaceOfWork, defaultBoldLabel, blackBrush, new Point(145, 229));
            e.Graphics.DrawString("Educational Attainment:", defaultLabel, blackBrush, new Point(47, 251));
            e.Graphics.DrawString(model.Education, defaultBoldLabel, blackBrush, new Point(197, 251));
            e.Graphics.DrawString("Purpose:", defaultLabel, blackBrush, new Point(47, 273));
            e.Graphics.DrawString(model.Client.Purpose, defaultBoldLabel, blackBrush, new Point(105, 273));
            e.Graphics.DrawString("Referring Agency:", defaultLabel, blackBrush, new Point(47, 295));
            e.Graphics.DrawString(model.Client.RequestingParty, defaultBoldLabel, blackBrush, new Point(160, 295));
            e.Graphics.DrawString("Date:", defaultLabel, blackBrush, new Point(489, 119));
            e.Graphics.DrawString(model.Client.TimeIn.ToString(), defaultBoldLabel, blackBrush, new Point(526, 119));
            e.Graphics.DrawString("Age/Sex:", defaultLabel, blackBrush, new Point(489, 141));
            e.Graphics.DrawString($"{model.Client.Age}/{model.Client.Gender}", defaultBoldLabel, blackBrush, new Point(548, 141));
        }
        public void Preview(params NeuroV1[] info)
        {
            if (info.Length > 0)
            {
                this.NeuroList = info.ToList();
                ctr = 0;
                previewDocument.Document = printDocument;
                previewDocument.ShowDialog();
            }
        }
        public void Print(params NeuroV1[] info)
        {
            if (info.Length > 0)
            {
                this.NeuroList = info.ToList();
                ctr = 0;
                printPreviewDocument.Document = printDocument;
                printPreviewDocument.ShowDialog();
            }
        }
        #endregion
        #region PROPERTIES
        public Signatory Psychometrician
        {
            get;
            set;
        }
        public Signatory Psychologist
        {
            get;
            set;
        }
        public List<NeuroV1> NeuroList
        {
            get;
            set;
        }
        #endregion




    }
}
