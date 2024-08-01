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
    public class NeuroV2_PrintDoc
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

        public NeuroV2_PrintDoc()
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

                StandardHeader.Print(e, model.Client.ControlNo, (Image)Edit.BitmapSourceToBitmap((System.Windows.Media.Imaging.BitmapSource)model.Client.Photo));

                //client info
                DrawPersonalInformation(e, model);

                //Title bar
                e.Graphics.FillRectangle(Brushes.DodgerBlue, GetRectangle(20, 315, 776, 20));
                e.Graphics.DrawRectangle(blackPen, GetRectangle(20, 315, 776, 20));
                e.Graphics.DrawString("NEURO PSYCHOLOGICAL TEST REPORT", titleBarLabel, whiteBrush, GetRectangleF(20, 315, 776, 20), CenterAligment());

                //draw background logo
                e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, GetSize(776, 300)), GetRectangleF(20, 335, 776, 300));

                //FACTORS
                DrawFactorLabels(e);

                //draw box
                DrawFactorBox(e, 360);
                DrawFactorBox(e, 420);
                DrawFactorBox(e, 440);
                DrawFactorBox(e, 480);
                DrawFactorBox(e, 500);
                DrawFactorBox(e, 520);
                DrawFactorBox(e, 540);
                DrawFactorBox(e, 580);
                DrawFactorBox(e, 600);
                DrawFactorBox(e, 620);
                DrawFactorBox(e, 640);

                //fill rectangle with circles
                DrawFactor(e, model.Intelligence, 360);
                DrawFactor(e, model.B1, 420);
                DrawFactor(e, model.B2, 440);
                DrawFactor(e, model.C1, 480);
                DrawFactor(e, model.C2, 500);
                DrawFactor(e, model.C3, 520);
                DrawFactor(e, model.C4, 540);
                DrawFactor(e, model.D1, 580);
                DrawFactor(e, model.D2, 600);
                DrawFactor(e, model.D3, 620);
                DrawFactor(e, model.D4, 640);

                //LINE 1
                e.Graphics.DrawLine(blackPen, GetPoint(20, 670), GetPoint(796, 670));
                e.Graphics.DrawLine(blackPen, GetPoint(20, 673), GetPoint(796, 673));

                //MENTAL STATUS EXAMINATION
                DrawMentalStatusLabels(e);

                DrawMSEBox(e, "Well-groomed", "Disheveled", "Poor Hygiene", 705);
                DrawMSEBox(e, "Appropriate", "Heightened", "Non-reactive", 725);
                DrawMSEBox(e, "Logical", "Incoherent", "Suicidal/Homicidal", 745);
                DrawMSEBox(e, "Focused", "Confused", "Disoriented", 765);
                DrawMSEBox(e, "Good", "Fair", "Poor", 785);


                DrawMSEEllipse(e, model.GeneralAppearance, 705);
                DrawMSEEllipse(e, model.Emotions, 725);
                DrawMSEEllipse(e, model.Thoughts, 745);
                DrawMSEEllipse(e, model.Cognition, 765);
                DrawMSEEllipse(e, model.JudgmentAndInsight, 785);

                e.Graphics.DrawString("Significant Remarks:", defaultLabel, blackBrush, GetPoint(90, 815));
                e.Graphics.DrawString(model.SignificantRemarks, defaultBoldLabel, blackBrush, GetRectangleF(218, 815, 578, 45));


                //LINE 4
                e.Graphics.DrawLine(blackPen, GetPoint(20, 835), GetPoint(796, 835));
                e.Graphics.DrawLine(blackPen, GetPoint(20, 838), GetPoint(796, 838));

                //remarks
                e.Graphics.DrawString("F.REMARKS", factorLabel, blackBrush, GetPoint(47, 845));
                e.Graphics.DrawString(string.IsNullOrEmpty(model.Remarks) ? string.Empty : model.Remarks.Trim(), defaultBoldLabel, blackBrush, GetRectangleF(47, 865, 749, 220), NearAlignment());
                //e.Graphics.DrawRectangle(blackPen, GetRectangle(47, 865, 749, 220));

                //psychological evaluation
                e.Graphics.DrawString("PSYCHOLOGICAL EVALUATION:", defaultLabel, blackBrush, GetPoint(47, 1085));
                e.Graphics.DrawString("No psychotic ideation manifested at the time of assessment.", defaultBoldLabel, blackBrush, GetPoint(265, 1085));

                e.Graphics.DrawLine(blackPen, GetPoint(20, 1115), GetPoint(796, 1115));
                e.Graphics.DrawLine(blackPen, GetPoint(20, 1118), GetPoint(796, 1118));

                //recommendation
                e.Graphics.DrawString("RECOMMENDATION", factorLabel, blackBrush, GetPoint(47, 1125));

                //draw box recommendation
                DrawRecommendation(e, model.Recommendation);

                //psychometrician
                e.Graphics.DrawString(model.Psychometrician, signatoryLabel, blackBrush, GetRectangleF(20, 1230, 408, 20), CenterAligment());
                e.Graphics.DrawString(Psychometrician != null ? Psychometrician.Title : string.Empty, signatoryTitleLabel, blackBrush, GetRectangleF(20, 1245, 408, 20), CenterAligment());

                //psychologist
                e.Graphics.DrawString(model.Psychologist, signatoryLabel, blackBrush, GetRectangleF(408, 1230, 408, 20), CenterAligment());
                e.Graphics.DrawString(Psychologist != null ? Psychologist.Title : string.Empty, signatoryTitleLabel, blackBrush, GetRectangleF(408, 1245, 408, 20), CenterAligment());

                //printed by
                e.Graphics.DrawString($"Printed By: {model.PrintedBy}", printedByLabel, blackBrush, GetPoint(20, 1258));


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
            e.Graphics.DrawRectangle(grayPen, GetRectangle(46, 1146, 15, 15));
            e.Graphics.DrawRectangle(blackPen, GetRectangle(47, 1145, 15, 15));

            e.Graphics.DrawRectangle(grayPen, GetRectangle(46, 1166, 15, 15));
            e.Graphics.DrawRectangle(blackPen, GetRectangle(47, 1165, 15, 15));

            e.Graphics.DrawRectangle(grayPen, GetRectangle(46, 1186, 15, 15));
            e.Graphics.DrawRectangle(blackPen, GetRectangle(47, 1185, 15, 15));

            e.Graphics.DrawString("Recommended/", defaultBoldLabel, blackBrush, GetPoint(65, 1145));
            e.Graphics.DrawString("No significant manifestation of personality and mental disturbances noted at the time of evaluation", defaultLabel, blackBrush, GetPoint(169, 1145));
            e.Graphics.DrawString("Recommended", defaultBoldLabel, blackBrush, GetPoint(65, 1165));
            e.Graphics.DrawString("with reservation; for further evaluation", defaultLabel, blackBrush, GetPoint(167, 1165));
            e.Graphics.DrawString("Not recommended", defaultBoldLabel, blackBrush, GetPoint(65, 1185));
            e.Graphics.DrawString("at the time of examination", defaultLabel, blackBrush, GetPoint(192, 1185));

            switch (res)
            {
                case 1:
                    e.Graphics.FillRectangle(blackBrush, GetRectangle(47, 1145, 15, 15));
                    break;
                case 2:
                    e.Graphics.FillRectangle(blackBrush, GetRectangle(47, 1165, 15, 15));
                    break;
                case 3:
                    e.Graphics.FillRectangle(blackBrush, GetRectangle(47, 1185, 15, 15));
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
            e.Graphics.DrawString("E.MENTAL STATUS EXAMINATION(MSE)", factorLabel, blackBrush, GetPoint(47, 685));
            e.Graphics.DrawString("General Appearance", defaultLabel, blackBrush, GetPoint(90, 705));
            e.Graphics.DrawString("Emotions", defaultLabel, blackBrush, GetPoint(90, 725));
            e.Graphics.DrawString("Thoughts", defaultLabel, blackBrush, GetPoint(90, 745));
            e.Graphics.DrawString("Cognition", defaultLabel, blackBrush, GetPoint(90, 765));
            e.Graphics.DrawString("Judgment and Insight", defaultLabel, blackBrush, GetPoint(90, 785));
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
            e.Graphics.DrawString("A.INTELLIGENCE TEST", factorLabel, blackBrush, GetPoint(47, 340));
            e.Graphics.DrawString("Below Average", defaultBoldLabel, blackBrush, GetPoint(306, 340));
            e.Graphics.DrawString("Lower Average", defaultBoldLabel, blackBrush, GetPoint(410, 340));
            e.Graphics.DrawString("Average", defaultBoldLabel, blackBrush, GetPoint(530, 340));
            e.Graphics.DrawString("Above Average", defaultBoldLabel, blackBrush, GetPoint(610, 340));
            e.Graphics.DrawString("Superior", defaultBoldLabel, blackBrush, GetPoint(730, 340));
            e.Graphics.DrawLine(blackPen, GetPoint(20, 390), GetPoint(796, 390));
            e.Graphics.DrawLine(blackPen, GetPoint(20, 393), GetPoint(796, 393));
            e.Graphics.DrawString("B.EMOTIONAL STABILITY", factorLabel, blackBrush, GetPoint(47, 400));
            e.Graphics.DrawString("Very Low", defaultBoldLabel, blackBrush, GetPoint(326, 400));
            e.Graphics.DrawString("Low", defaultBoldLabel, blackBrush, GetPoint(441, 400));
            e.Graphics.DrawString("Average", defaultBoldLabel, blackBrush, GetPoint(529, 400));
            e.Graphics.DrawString("High", defaultBoldLabel, blackBrush, GetPoint(640, 400));
            e.Graphics.DrawString("Very High", defaultBoldLabel, blackBrush, GetPoint(726, 400));
            e.Graphics.DrawString("1.Coping with stress", defaultLabel, blackBrush, GetPoint(90, 420));
            e.Graphics.DrawString("2.Control of aggressive/hostile impulses", defaultLabel, blackBrush, GetPoint(90, 440));
            e.Graphics.DrawString("C.SOCIAL ADAPTABILITY", factorLabel, blackBrush, GetPoint(47, 460));
            e.Graphics.DrawString("1.With people in general", defaultLabel, blackBrush, GetPoint(90, 480));
            e.Graphics.DrawString("2.With peers", defaultLabel, blackBrush, GetPoint(90, 500));
            e.Graphics.DrawString("3.With superior", defaultLabel, blackBrush, GetPoint(90, 520));
            e.Graphics.DrawString("4.With subordinates", defaultLabel, blackBrush, GetPoint(90, 540));
            e.Graphics.DrawString("D.WORK ATTITUDES", factorLabel, blackBrush, GetPoint(47, 560));
            e.Graphics.DrawString("1.Responsibility/Dependability", defaultLabel, blackBrush, GetPoint(90, 580));
            e.Graphics.DrawString("2.Loyalty", defaultLabel, blackBrush, GetPoint(90, 600));
            e.Graphics.DrawString("3.Perseverance", defaultLabel, blackBrush, GetPoint(90, 620));
            e.Graphics.DrawString("4.Flexibility", defaultLabel, blackBrush, GetPoint(90, 640));
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
            e.Graphics.DrawRectangle(blackPen2, GetRectangle(480, 185, 316, 97));
            e.Graphics.DrawString("Tests Administered", defaultUnderlineLabel, blackBrush, GetRectangleF(485, 185, 311, 20), CenterAligment());

            var yPos = 185;
            if (!string.IsNullOrEmpty(model.IQTest) && model.IQTest != "-")
            {
                yPos += 20;
                e.Graphics.DrawString("IQ Test:", defaultLabel, blackBrush, GetPoint(485, yPos));
                e.Graphics.DrawString(model.IQTest, defaultBoldLabel, blackBrush, GetPoint(537, yPos));
            }
            if (!string.IsNullOrEmpty(model.Retake) && model.Retake != "-")
            {
                yPos += 20;
                e.Graphics.DrawString("Retake:", defaultLabel, blackBrush, GetPoint(485, yPos));
                e.Graphics.DrawString(model.Retake, defaultBoldLabel, blackBrush, GetPoint(535, yPos));
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
                e.Graphics.DrawString(model.Others, defaultBoldLabel, blackBrush, GetPoint(534, yPos));
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
