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
    public class NeuroV3_PrintDoc
    {
        private PrintDocument printDocument;
        private PrintPreviewDialog previewDocument;
        private CyberPrintPreview printPreviewDocument;
        private Font defaultLabel;
        private Font defaultBoldLabel;
        private Font defaultUnderlineLabel;
        private Font factorLabel;
        private Font titleBarLabel;
        private Font printedByLabel;
        private Font signatoryLabel;
        private Font signatoryTitleLabel;
        private Brush blackBrush;
        private Brush whiteBrush;
        private Pen blackPen;
        private Pen blackPen2;
        private Pen grayPen;
        private int ctr = 0;

        public NeuroV3_PrintDoc()
        {
            printDocument = new PrintDocument();
            previewDocument = new PrintPreviewDialog();
            printPreviewDocument = new CyberPrintPreview();

            defaultLabel = FontGenerator.Regular(9.75F);
            defaultBoldLabel = FontGenerator.Bold(9.75F);
            defaultUnderlineLabel = FontGenerator.Underline(9.75F);
            factorLabel = FontGenerator.Bold(10F);
            titleBarLabel = FontGenerator.Bold(11.5F);
            printedByLabel = FontGenerator.Regular(6F);
            signatoryLabel = FontGenerator.Regular(9F);
            signatoryTitleLabel = FontGenerator.Regular(8F);
            blackBrush = Brushes.Black;
            whiteBrush = Brushes.White;
            blackPen = Pens.Black;
            grayPen = Pens.Gray;
            blackPen2 = new Pen(Brushes.Black, 1.5F);
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

                StandardHeader.Print(e, model.Client.ControlNo, Edit.BitmapSourceToBitmap((System.Windows.Media.Imaging.BitmapSource)model.Client.Photo));

                //client info
                DrawPersonalInformation(e, model);

                //Title bar
                e.Graphics.FillRectangle(Brushes.DodgerBlue, GetRectangle(20, 315, 776, 20));
                e.Graphics.DrawRectangle(blackPen, GetRectangle(20, 315, 776, 20));
                e.Graphics.DrawString("PSYCHOLOGICAL TEST REPORT", titleBarLabel, whiteBrush, GetRectangleF(20, 315, 776, 20), CenterAligment());

                //draw background logo
                e.Graphics.DrawImage(Properties.Resources.LogoTransparent, GetRectangleF(20, 335, 776, 300));
                //e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, GetSize(776, 300)), GetRectangleF(20, 335, 776, 300));

                //FACTORS
                DrawFactorLabels(e);

                //draw box
                DrawFactorBox(e, 360);
                DrawFactorBox(e, 420);
                DrawFactorBox(e, 440);
                DrawFactorBox(e, 460);
                DrawFactorBox(e, 480);
                DrawFactorBox(e, 500);

                //fill rectangle with circles
                DrawFactor(e, model.Intelligence, 360);
                DrawFactor(e, model.Neuroticism, 420);
                DrawFactor(e, model.Extraversion, 440);
                DrawFactor(e, model.Openness, 460);
                DrawFactor(e, model.Agreeableness, 480);
                DrawFactor(e, model.Conscientiousness, 500);

                //LINE 1
                e.Graphics.DrawLine(blackPen, GetPoint(20, 530), GetPoint(796, 530));
                e.Graphics.DrawLine(blackPen, GetPoint(20, 533), GetPoint(796, 533));

                //MENTAL STATUS EXAMINATION
                DrawMentalStatusLabels(e);

                DrawMSEBox(e, "Well-groomed", "Disheveled", "Poor Hygiene", 570);
                DrawMSEBox(e, "Appropriate", "Heightened", "Non-reactive", 590);
                DrawMSEBox(e, "Logical", "Incoherent", "Suicidal/Homicidal", 610);
                DrawMSEBox(e, "Focused", "Confused", "Disoriented", 630);
                DrawMSEBox(e, "Good", "Fair", "Poor", 650);


                DrawMSEEllipse(e, model.GeneralAppearance, 570);
                DrawMSEEllipse(e, model.Emotions, 590);
                DrawMSEEllipse(e, model.Thoughts, 610);
                DrawMSEEllipse(e, model.Cognition, 630);
                DrawMSEEllipse(e, model.JudgmentAndInsight, 650);

                e.Graphics.DrawString("Significant Remarks:", defaultLabel, blackBrush, GetPoint(90, 670));
                e.Graphics.DrawString(model.SignificantRemarks, defaultBoldLabel, blackBrush, GetRectangleF(218, 670, 578, 45));


                //LINE 4
                e.Graphics.DrawLine(blackPen, GetPoint(20, 700), GetPoint(796, 700));
                e.Graphics.DrawLine(blackPen, GetPoint(20, 703), GetPoint(796, 703));

                //remarks
                e.Graphics.DrawString("SUMMARY", factorLabel, blackBrush, GetPoint(47, 720));
                e.Graphics.DrawString(string.IsNullOrEmpty(model.Remarks) ? string.Empty : model.Remarks.Trim(), defaultBoldLabel, blackBrush, GetRectangleF(47, 745, 749, 260), NearAlignment());
                //e.Graphics.DrawRectangle(blackPen, GetRectangle(47, 745, 749, 260));

                //psychological evaluation
                e.Graphics.DrawString("PSYCHOLOGICAL EVALUATION:", defaultLabel, blackBrush, GetPoint(47, 1005));
                e.Graphics.DrawString("No psychotic ideation manifested at the time of assessment.", defaultBoldLabel, blackBrush, GetPoint(265, 1005));

                e.Graphics.DrawLine(blackPen, GetPoint(20, 1035), GetPoint(796, 1035));
                e.Graphics.DrawLine(blackPen, GetPoint(20, 1038), GetPoint(796, 1038));

                //recommendation
                e.Graphics.DrawString("RECOMMENDATION", factorLabel, blackBrush, GetPoint(47, 1055));

                //draw box recommendation
                DrawRecommendation(e, model.Recommendation);

                //psychometrician
                e.Graphics.DrawString(model.Psychometrician, signatoryLabel, blackBrush, GetRectangleF(20, 1220, 258, 20), CenterAligment());
                e.Graphics.DrawString(Psychometrician != null ? Psychometrician.Title : string.Empty, signatoryTitleLabel, blackBrush, GetRectangleF(20, 1235, 258, 20), CenterAligment());

                if (!string.IsNullOrEmpty(model.Psychologist))
                    e.Graphics.DrawImage(Properties.Resources.watin, GetRectangleF(308, 1190, 198, 30));
                    
                //psychologist
                e.Graphics.DrawString(model.Psychologist, signatoryLabel, blackBrush, GetRectangleF(278, 1220, 258, 20), CenterAligment());
                e.Graphics.DrawString(Psychologist != null ? Psychologist.Title : string.Empty, signatoryTitleLabel, blackBrush, GetRectangleF(278, 1235, 258, 20), CenterAligment());

                //psychologist
                e.Graphics.DrawString("PILAR M. LACEDA, M.D. FPAFP", signatoryLabel, blackBrush, GetRectangleF(536, 1220, 258, 20), CenterAligment());
                e.Graphics.DrawString("Medical Director", signatoryTitleLabel, blackBrush, GetRectangleF(536, 1235, 258, 20), CenterAligment());

                //printed by
                e.Graphics.DrawString($"Printed By: {model.PrintedBy}", printedByLabel, blackBrush, GetPoint(20, 1255));


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
        private Point GetPoint(int x, int y)
        {
            return new Point(x, y);
        }
        private Size GetSize(int width, int height)
        {
            return new Size(width, height);
        }
        private RectangleF GetRectangleF(int x, int y, int width, int height)
        {
            return new RectangleF(new Point(x, y), new SizeF(width, height));
        }
        private Rectangle GetRectangle(int x, int y, int width, int height)
        {
            return new Rectangle(x, y, width, height);
        }
        private StringFormat CenterAligment()
        {
            return new StringFormat() { Alignment = StringAlignment.Center };
        }
        private StringFormat NearAlignment()
        {
            return new StringFormat() { Alignment = StringAlignment.Near };
        }
        private void DrawFactorBox(PrintPageEventArgs e, int ypos)
        {
            for (int i = 350; i <= 750; i += 100)
            {
                e.Graphics.DrawRectangle(grayPen, GetRectangle(i - 1, ypos + 1, 15, 15));
                e.Graphics.DrawRectangle(blackPen, GetRectangle(i, ypos, 15, 15));
            }
        }
        private void DrawFactor(PrintPageEventArgs e, byte factor, int ypos)
        {
            switch (factor)
            {
                case 1: e.Graphics.FillRectangle(blackBrush, GetRectangle(350, ypos, 15, 15)); break;
                case 2: e.Graphics.FillRectangle(blackBrush, GetRectangle(450, ypos, 15, 15)); break;
                case 3: e.Graphics.FillRectangle(blackBrush, GetRectangle(550, ypos, 15, 15)); break;
                case 4: e.Graphics.FillRectangle(blackBrush, GetRectangle(650, ypos, 15, 15)); break;
                case 5: e.Graphics.FillRectangle(blackBrush, GetRectangle(750, ypos, 15, 15)); break;
            }
        }
        private void DrawRecommendation(PrintPageEventArgs e, byte res)
        {
            e.Graphics.DrawRectangle(grayPen, GetRectangle(46, 1075, 15, 15));
            e.Graphics.DrawRectangle(blackPen, GetRectangle(47, 1074, 15, 15));

            e.Graphics.DrawRectangle(grayPen, GetRectangle(46, 1095, 15, 15));
            e.Graphics.DrawRectangle(blackPen, GetRectangle(47, 1094, 15, 15));

            e.Graphics.DrawRectangle(grayPen, GetRectangle(46, 1115, 15, 15));
            e.Graphics.DrawRectangle(blackPen, GetRectangle(47, 1114, 15, 15));

            e.Graphics.DrawString("Recommended/", defaultBoldLabel, blackBrush, GetPoint(65, 1075));
            e.Graphics.DrawString("No significant manifestation of personality and mental disturbances noted at the time of evaluation", defaultLabel, blackBrush, GetPoint(169, 1075));
            e.Graphics.DrawString("Recommended", defaultBoldLabel, blackBrush, GetPoint(65, 1095));
            e.Graphics.DrawString("with reservation; for further evaluation", defaultLabel, blackBrush, GetPoint(167, 1095));
            e.Graphics.DrawString("Not recommended", defaultBoldLabel, blackBrush, GetPoint(65, 1115));
            e.Graphics.DrawString("at the time of examination", defaultLabel, blackBrush, GetPoint(192, 1115));

            switch (res)
            {
                case 1:
                    e.Graphics.FillRectangle(blackBrush, GetRectangle(47, 1074, 15, 15));
                    break;
                case 2:
                    e.Graphics.FillRectangle(blackBrush, GetRectangle(47, 1094, 15, 15));
                    break;
                case 3:
                    e.Graphics.FillRectangle(blackBrush, GetRectangle(47, 1114, 15, 15));
                    break;
            }
        }
        private void DrawMSEBox(PrintPageEventArgs e, string a, string b, string c, int ypos)
        {
            e.Graphics.DrawEllipse(grayPen, GetRectangle(349, ypos + 1, 15, 15));
            e.Graphics.DrawEllipse(blackPen, GetRectangle(350, ypos, 15, 15));
            e.Graphics.DrawString(a, defaultLabel, blackBrush, GetPoint(370, ypos));

            e.Graphics.DrawEllipse(grayPen, GetRectangle(509, ypos + 1, 15, 15));
            e.Graphics.DrawEllipse(blackPen, GetRectangle(510, ypos, 15, 15));
            e.Graphics.DrawString(b, defaultLabel, blackBrush, GetPoint(530, ypos));

            e.Graphics.DrawEllipse(grayPen, GetRectangle(669, ypos + 1, 15, 15));
            e.Graphics.DrawEllipse(blackPen, GetRectangle(670, ypos, 15, 15));
            e.Graphics.DrawString(c, defaultLabel, blackBrush, GetPoint(690, ypos));
        }
        private void DrawMSEEllipse(PrintPageEventArgs e, byte res, int ypos)
        {
            switch (res)
            {
                case 1: e.Graphics.FillEllipse(blackBrush, GetRectangle(350, ypos, 15, 15)); break;
                case 2: e.Graphics.FillEllipse(blackBrush, GetRectangle(510, ypos, 15, 15)); break;
                case 3: e.Graphics.FillEllipse(blackBrush, GetRectangle(670, ypos, 15, 15)); break;
            }
        }
        private void DrawMentalStatusLabels(PrintPageEventArgs e)
        {
            e.Graphics.DrawString("MENTAL STATUS EXAMINATION (MSE)", factorLabel, blackBrush, GetPoint(47, 550));
            e.Graphics.DrawString("General Appearance", defaultLabel, blackBrush, GetPoint(90, 570));
            e.Graphics.DrawString("Emotions", defaultLabel, blackBrush, GetPoint(90, 590));
            e.Graphics.DrawString("Thoughts", defaultLabel, blackBrush, GetPoint(90, 610));
            e.Graphics.DrawString("Cognition", defaultLabel, blackBrush, GetPoint(90, 630));
            e.Graphics.DrawString("Judgment and Insight", defaultLabel, blackBrush, GetPoint(90, 650));
        }
        private void DrawRelatedFactors(PrintPageEventArgs e, NeuroV2 model)
        {
            e.Graphics.DrawString("E.RELATED FACTORS:", factorLabel, blackBrush, GetPoint(47, 655));
            e.Graphics.DrawString("a.Job Experience:", defaultLabel, blackBrush, GetPoint(90, 675));
            e.Graphics.DrawString(model.JobExperience, defaultBoldLabel, blackBrush, GetPoint(203, 675));
            e.Graphics.DrawString("b.Eligibility:", defaultLabel, blackBrush, GetPoint(90, 695));
            e.Graphics.DrawString(model.Eligibility, defaultBoldLabel, blackBrush, GetPoint(162, 695));
        }
        private void DrawFactorLabels(PrintPageEventArgs e)
        {
            e.Graphics.DrawString("INTELLIGENCE TEST", factorLabel, blackBrush, GetPoint(47, 340));
            e.Graphics.DrawString("Below Average", defaultBoldLabel, blackBrush, GetPoint(306, 340));
            e.Graphics.DrawString("Lower Average", defaultBoldLabel, blackBrush, GetPoint(410, 340));
            e.Graphics.DrawString("Average", defaultBoldLabel, blackBrush, GetPoint(530, 340));
            e.Graphics.DrawString("Above Average", defaultBoldLabel, blackBrush, GetPoint(610, 340));
            e.Graphics.DrawString("Superior", defaultBoldLabel, blackBrush, GetPoint(730, 340));
            e.Graphics.DrawLine(blackPen, GetPoint(20, 390), GetPoint(796, 390));
            e.Graphics.DrawLine(blackPen, GetPoint(20, 393), GetPoint(796, 393));
            e.Graphics.DrawString("PERSONALITY TEST", factorLabel, blackBrush, GetPoint(47, 400));
            e.Graphics.DrawString("Very Low", defaultBoldLabel, blackBrush, GetPoint(326, 400));
            e.Graphics.DrawString("Low", defaultBoldLabel, blackBrush, GetPoint(441, 400));
            e.Graphics.DrawString("Average", defaultBoldLabel, blackBrush, GetPoint(529, 400));
            e.Graphics.DrawString("High", defaultBoldLabel, blackBrush, GetPoint(640, 400));
            e.Graphics.DrawString("Very High", defaultBoldLabel, blackBrush, GetPoint(726, 400));
            e.Graphics.DrawString("Neuroticism", defaultLabel, blackBrush, GetPoint(90, 420));
            e.Graphics.DrawString("Extraversion", defaultLabel, blackBrush, GetPoint(90, 440));
            e.Graphics.DrawString("Openness", defaultLabel, blackBrush, GetPoint(90, 460));
            e.Graphics.DrawString("Agreeableness", defaultLabel, blackBrush, GetPoint(90, 480));
            e.Graphics.DrawString("Conscientiousness", defaultLabel, blackBrush, GetPoint(90, 500));
        }
        private void DrawPersonalInformation(PrintPageEventArgs e, NeuroV2 model)
        {
            e.Graphics.DrawString("Name:", defaultLabel, blackBrush, GetPoint(47, 119));
            e.Graphics.DrawString(model.Client.FullName, defaultBoldLabel, blackBrush, GetPoint(90, 119));
            e.Graphics.DrawString("Home Address:", defaultLabel, blackBrush, GetPoint(47, 139));
            e.Graphics.DrawString(model.Client.HomeAddress, defaultBoldLabel, blackBrush, GetRectangleF(145, 139, 340, 40), NearAlignment());
            e.Graphics.DrawString("Occupation:", defaultLabel, blackBrush, GetPoint(47, 183));
            e.Graphics.DrawString(model.Occupation, defaultBoldLabel, blackBrush, GetPoint(124, 183));
            e.Graphics.DrawString("Educational Attainment:", defaultLabel, blackBrush, GetPoint(47, 203));
            e.Graphics.DrawString(model.EducationalAttainment, defaultBoldLabel, blackBrush, GetPoint(196, 203));
            e.Graphics.DrawString("Job Experience:", defaultLabel, blackBrush, GetPoint(47, 223));
            e.Graphics.DrawString(model.JobExperience, defaultBoldLabel, blackBrush, GetPoint(149, 223));
            e.Graphics.DrawString("Purpose:", defaultLabel, blackBrush, GetPoint(47, 243));
            e.Graphics.DrawString(model.Client.Purpose, defaultBoldLabel, blackBrush, GetPoint(105, 243));
            e.Graphics.DrawString("Eligibility:", defaultLabel, blackBrush, GetPoint(47, 263));
            e.Graphics.DrawString(model.Eligibility, defaultBoldLabel, blackBrush, GetPoint(107, 263));
            e.Graphics.DrawString("Referring Agency:", defaultLabel, blackBrush, GetPoint(47, 283));
            e.Graphics.DrawString(model.Client.RequestingParty, defaultBoldLabel, blackBrush, GetPoint(160, 283));
            e.Graphics.DrawString("Date:", defaultLabel, blackBrush, GetPoint(480, 119));
            e.Graphics.DrawString(model.Client.TimeIn.HasValue ? model.Client.TimeIn.ToString() : string.Empty, defaultBoldLabel, blackBrush, GetPoint(517, 119));
            e.Graphics.DrawString("Age/Gender:", defaultLabel, blackBrush, GetPoint(480, 139));
            e.Graphics.DrawString($"{model.Client.Age}/{model.Client.Gender}", defaultBoldLabel, blackBrush, GetPoint(561, 139));
            e.Graphics.DrawRectangle(blackPen2, GetRectangle(480, 185, 316, 115));
            e.Graphics.DrawString("Tests Administered", defaultUnderlineLabel, blackBrush, GetRectangleF(485, 185, 311, 20), CenterAligment());

            var yPos = 185;
            if (!string.IsNullOrEmpty(model.IQTest) && model.IQTest != "-")
            {
                yPos += 20;
                e.Graphics.DrawString("IQ Test:", defaultLabel, blackBrush, GetPoint(485, yPos));
                e.Graphics.DrawString(model.IQTest, defaultBoldLabel, blackBrush, GetPoint(537, yPos));
            }
            if (!string.IsNullOrEmpty(model.PersonalityTest) && model.PersonalityTest != "-")
            {
                yPos += 20;
                e.Graphics.DrawString("Personality Test:", defaultLabel, blackBrush, GetPoint(485, yPos));
                e.Graphics.DrawString(model.PersonalityTest, defaultBoldLabel, blackBrush, GetPoint(590, yPos));
            }
            if (!string.IsNullOrEmpty(model.Others) && model.Others != "-")
            {
                yPos += 20;
                e.Graphics.DrawString("Others:", defaultLabel, blackBrush, GetPoint(485, yPos));
                if (!string.IsNullOrEmpty(model.Others))
                {
                    if (model.Others.Contains(","))
                    {
                        var others = model.Others.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var other in others)
                        {
                            e.Graphics.DrawString(other, defaultBoldLabel, blackBrush, GetPoint(534, yPos));
                            yPos += 20;
                        }
                    }
                    else
                    {

                        e.Graphics.DrawString(model.Others, defaultBoldLabel, blackBrush, GetPoint(534, yPos));
                    }
                }
            }
        }
        public void Preview(params NeuroV2[] info)
        {
            if (info.Length > 0)
            {
                this.NeuroList = info.ToList();
                ctr = 0;
                printPreviewDocument.Document = printDocument;
                printPreviewDocument.ShowDialog();
            }
        }
        public void Print(params NeuroV2[] info)
        {
            if (info.Length > 0)
            {
                this.NeuroList = info.ToList();
                ctr = 0;
                previewDocument.Document = printDocument;
                previewDocument.ShowDialog();
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
        public List<NeuroV2> NeuroList
        {
            get;
            set;
        }
        #endregion




    }
}
