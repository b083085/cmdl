using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data;
using CMDL.Models;

namespace CMDL
{
    public class Neuro_PrintDoc
    {
        PrintDocument doc = new PrintDocument();
        PrintPreviewDialog prev = new PrintPreviewDialog();
        CyberPrintPreview cprev = new CyberPrintPreview();

        public List<NeuroClientInfo> info;

        //font
        private Font labelinfo = new Font("Arial", 9.75F);
        private Font labelinfo_bold = new Font("Arial", 9.75F, FontStyle.Bold);
        private Font factorfont = new Font("Arial", 10F, FontStyle.Bold);
        private Font titlebarfont = new Font("Arial", 11.5F, FontStyle.Bold);
        private Font printedbyfont = new Font("Arial", 6F);
        private Brush black = Brushes.Black;

        private Font signatoryfont = new Font("Arial", 9F);
        private Font siglabelfont = new Font("Arial", 8F);

        private int ctr = 0;

        public Neuro_PrintDoc()
        {
            //paper size
            doc.DefaultPageSettings.PaperSize = new PaperSize("Custom Size", 830, 1270);
            //smooth text preview
            prev.UseAntiAlias = true;
            ((Form)prev).WindowState = FormWindowState.Normal;
            ((Form)prev).Size = new Size(600, 600);
            ((Form)prev).StartPosition = FormStartPosition.CenterScreen;
            ((Form)prev).Text = "PRINT PREVIEW";

            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
        }

        private void DrawBox(PrintPageEventArgs e,int ypos)
        {
            for (int i = 450; i <= 730; i += 70)
            {
                e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(i-1,ypos+1,15,15));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(i, ypos, 15, 15));
            }
        }

        private void DrawBoxRec(PrintPageEventArgs e, string res)
        {
            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(219, 1201, 15, 15));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(220, 1200, 15, 15));

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(369, 1201, 15, 15));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(370, 1200, 15, 15));

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(579, 1201, 15, 15));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(580, 1200, 15, 15));

            e.Graphics.DrawString("Recommended", labelinfo, black, new Point(240, 1200));
            e.Graphics.DrawString("Minimally Recommended", labelinfo, black, new Point(390, 1200));
            e.Graphics.DrawString("Not Recommended", labelinfo, black, new Point(600, 1200));

            switch (res)
            {
                case "RECOMMENDED": e.Graphics.FillEllipse(black, new Rectangle(220, 1200, 15, 15)); 
                    break;
                case "MINIMALLY RECOMMENDED": e.Graphics.FillEllipse(black, new Rectangle(370, 1200, 15, 15)); 
                    break;
                case "NOT RECOMMENDED": e.Graphics.FillEllipse(black, new Rectangle(580, 1200, 15, 15)); 
                    break;
            }
        }

        private void DrawEllipse(PrintPageEventArgs e, string factor, int ypos)
        {
            switch (factor)
            {
                case "1": e.Graphics.FillEllipse(black, new Rectangle(450, ypos, 15, 15)); break;
                case "2": e.Graphics.FillEllipse(black, new Rectangle(520, ypos, 15, 15)); break;
                case "3": e.Graphics.FillEllipse(black, new Rectangle(590, ypos, 15, 15)); break;
                case "4": e.Graphics.FillEllipse(black, new Rectangle(660, ypos, 15, 15)); break;
                case "5": e.Graphics.FillEllipse(black, new Rectangle(730, ypos, 15, 15)); break;
            }
        }

        private void DrawMSEBox(PrintPageEventArgs e, string a, string b, string c, int ypos)
        {
            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(349, ypos + 1, 15, 15));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(350, ypos, 15, 15));
            e.Graphics.DrawString(a, labelinfo, black, new Point(370, ypos));

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(509, ypos + 1, 15, 15));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(510, ypos, 15, 15));
            e.Graphics.DrawString(b, labelinfo, black, new Point(530, ypos));

            e.Graphics.DrawRectangle(Pens.Gray, new Rectangle(669, ypos + 1, 15, 15));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(670, ypos, 15, 15));
            e.Graphics.DrawString(c, labelinfo, black, new Point(690, ypos));
        }

        private void DrawMSEEllipse(PrintPageEventArgs e, string res, int ypos)
        {
            switch (res)
            {
                case "1": e.Graphics.FillEllipse(black, new Rectangle(350, ypos, 15, 15)); break;
                case "2": e.Graphics.FillEllipse(black, new Rectangle(510, ypos, 15, 15)); break;
                case "3": e.Graphics.FillEllipse(black, new Rectangle(670, ypos, 15, 15)); break;
            }
        }

        public void Preview(List<NeuroClientInfo> info)
        {
            this.info = info;
            ctr = 0;
            prev.Document = doc;
            prev.ShowDialog();
        }

        public void CyberPreview(List<NeuroClientInfo> info)
        {
            this.info = info;
            ctr = 0;
            cprev.Document = doc;
            cprev.ShowDialog();
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                StandardHeader.Print(e, info[ctr].ControlNo, (Image)Edit.BitmapSourceToBitmap((System.Windows.Media.Imaging.BitmapSource)info[ctr].Photo));

                //personal information
                e.Graphics.DrawString("Name:", labelinfo, black, new Point(47, 119));
                e.Graphics.DrawString(info[ctr].LastName + ", " + info[ctr].FirstName + " " + info[ctr].MI + " " + info[ctr].Suffix, labelinfo_bold, black, new Point(90, 119));
                e.Graphics.DrawString("Home Address:", labelinfo, black, new Point(47, 141));
                e.Graphics.DrawString(info[ctr].HomeAddress, labelinfo_bold, black, new RectangleF(new Point(145, 141), new SizeF(340, 40)), new StringFormat() { Alignment = StringAlignment.Near });
                e.Graphics.DrawString("Religion:", labelinfo, black, new Point(47, 185));
                e.Graphics.DrawString(info[ctr].Religion, labelinfo_bold, black, new Point(104, 185));
                e.Graphics.DrawString("Occupation:", labelinfo, black, new Point(47, 207));
                e.Graphics.DrawString(info[ctr].Occupation, labelinfo_bold, black, new Point(124, 207));
                e.Graphics.DrawString("Place Of Work:", labelinfo, black, new Point(47, 229));
                e.Graphics.DrawString(info[ctr].PlaceOfWork, labelinfo_bold, black, new Point(145, 229));
                e.Graphics.DrawString("Educational Attainment:", labelinfo, black, new Point(47, 251));
                e.Graphics.DrawString(info[ctr].Education, labelinfo_bold, black, new Point(197, 251));
                e.Graphics.DrawString("Purpose:", labelinfo, black, new Point(47, 273));
                e.Graphics.DrawString(info[ctr].Purpose, labelinfo_bold, black, new Point(105, 273));
                e.Graphics.DrawString("Referring Agency:", labelinfo, black, new Point(47, 295));
                e.Graphics.DrawString(info[ctr].RefAgency, labelinfo_bold, black, new Point(160, 295));
                e.Graphics.DrawString("Date:", labelinfo, black, new Point(489, 119));
                e.Graphics.DrawString(info[ctr].TimeIn, labelinfo_bold, black, new Point(526, 119));
                e.Graphics.DrawString("Age/Sex:", labelinfo, black, new Point(489, 141));
                e.Graphics.DrawString(info[ctr].Age + "/" + info[ctr].Sex, labelinfo_bold, black, new Point(548, 141));

                //Title bar
                e.Graphics.FillRectangle(Brushes.DodgerBlue, new Rectangle(20, 315, 776, 20));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 315, 776, 20));
                e.Graphics.DrawString(info[ctr].Subject + " TEST REPORT", titlebarfont, Brushes.White, new RectangleF(new Point(20, 315), new SizeF(776, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //draw background logo
                e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, new Size(776, 300)), new RectangleF(new Point(20, 335), new SizeF(776, 300)));

                //FACTORS
                e.Graphics.DrawString("FACTORS", factorfont, black, new Point(47, 340));
                e.Graphics.DrawString("1", labelinfo_bold, black, new Point(450, 340));
                e.Graphics.DrawString("2", labelinfo_bold, black, new Point(520, 340));
                e.Graphics.DrawString("3", labelinfo_bold, black, new Point(590, 340));
                e.Graphics.DrawString("4", labelinfo_bold, black, new Point(660, 340));
                e.Graphics.DrawString("5", labelinfo_bold, black, new Point(730, 340));
                e.Graphics.DrawString("A.INTELLIGENCE", factorfont, black, new Point(47, 360));
                e.Graphics.DrawString("B.EMOTIONAL STABILITY", factorfont, black, new Point(47, 380));
                e.Graphics.DrawString("1.Coping with stress", labelinfo, black, new Point(90, 400));
                e.Graphics.DrawString("2.Control of aggressive/hostile impulses", labelinfo, black, new Point(90, 420));
                e.Graphics.DrawString("C.SOCIAL ADAPTABILITY", factorfont, black, new Point(47, 440));
                e.Graphics.DrawString("1.With people in general", labelinfo, black, new Point(90, 460));
                e.Graphics.DrawString("2.With peers", labelinfo, black, new Point(90, 480));
                e.Graphics.DrawString("3.With superior", labelinfo, black, new Point(90, 500));
                e.Graphics.DrawString("4.With subordinates", labelinfo, black, new Point(90, 520));
                e.Graphics.DrawString("D.WORK ATTITUDES", factorfont, black, new Point(47, 540));
                e.Graphics.DrawString("1.Responsibility/Dependability", labelinfo, black, new Point(90, 560));
                e.Graphics.DrawString("2.Loyalty", labelinfo, black, new Point(90, 580));
                e.Graphics.DrawString("3.Perseverance", labelinfo, black, new Point(90, 600));
                e.Graphics.DrawString("4.Flexibility", labelinfo, black, new Point(90, 620));

                //draw box
                DrawBox(e, 360);
                DrawBox(e, 400);
                DrawBox(e, 420);
                DrawBox(e, 460);
                DrawBox(e, 480);
                DrawBox(e, 500);
                DrawBox(e, 520);
                DrawBox(e, 560);
                DrawBox(e, 580);
                DrawBox(e, 600);
                DrawBox(e, 620);

                //fill rectangle with circles
                DrawEllipse(e, info[ctr].A, 360);
                DrawEllipse(e, info[ctr].B1, 400);
                DrawEllipse(e, info[ctr].B2, 420);
                DrawEllipse(e, info[ctr].C1, 460);
                DrawEllipse(e, info[ctr].C2, 480);
                DrawEllipse(e, info[ctr].C3, 500);
                DrawEllipse(e, info[ctr].C4, 520);
                DrawEllipse(e, info[ctr].D1, 560);
                DrawEllipse(e, info[ctr].D2, 580);
                DrawEllipse(e, info[ctr].D3, 600);
                DrawEllipse(e, info[ctr].D4, 620);

                //LINE 1
                e.Graphics.DrawLine(Pens.Black, new Point(20, 640), new Point(796, 640));
                e.Graphics.DrawLine(Pens.Black, new Point(20, 643), new Point(796, 643));

                //D.RELATED FACTORS
                e.Graphics.DrawString("E.RELATED FACTORS:", factorfont, black, new Point(47, 655));
                e.Graphics.DrawString("a.Job Experience:", labelinfo, black, new Point(90, 675));
                e.Graphics.DrawString(info[ctr].JobExperience, labelinfo_bold, black, new Point(203, 675));
                e.Graphics.DrawString("b.Eligibility:", labelinfo, black, new Point(90, 695));
                e.Graphics.DrawString(info[ctr].Eligibility, labelinfo_bold, black, new Point(162, 695));

                //LINE 2
                e.Graphics.DrawLine(Pens.Black, new Point(20, 715), new Point(796, 715));
                e.Graphics.DrawLine(Pens.Black, new Point(20, 718), new Point(796, 718));

                //legend
                e.Graphics.DrawString("LEGEND:", factorfont, black, new Point(47, 720));
                e.Graphics.DrawString("1. Poor\t 2. Fair\t 3. Adequate(Average)\t 4. Satisfactory\t 5. Very Satisfactory", labelinfo, black, new Point(90, 740));

                //LINE 3
                e.Graphics.DrawLine(Pens.Black, new Point(20, 760), new Point(796, 760));
                e.Graphics.DrawLine(Pens.Black, new Point(20, 763), new Point(796, 763));

                //MENTAL STATUS EXAMINATION
                e.Graphics.DrawString("MENTAL STATUS EXAMINATION(MSE)", factorfont, black, new Point(47, 780));
                e.Graphics.DrawString("A(Normal)", labelinfo_bold, black, new Point(350, 780));
                e.Graphics.DrawString("B(Problem)", labelinfo_bold, black, new Point(510, 780));
                e.Graphics.DrawString("C(Problem)", labelinfo_bold, black, new Point(670, 780));
                e.Graphics.DrawString("General Appearance", labelinfo, black, new Point(90, 800));
                e.Graphics.DrawString("Attitude", labelinfo, black, new Point(90, 820));
                e.Graphics.DrawString("Memory", labelinfo, black, new Point(90, 840));
                e.Graphics.DrawString("Speech", labelinfo, black, new Point(90, 860));
                e.Graphics.DrawString("Affect and Mood", labelinfo, black, new Point(90, 880));
                e.Graphics.DrawString("Thought Content", labelinfo, black, new Point(90, 900));
                e.Graphics.DrawString("Suicidality", labelinfo, black, new Point(90, 920));
                e.Graphics.DrawString("Preoccupations", labelinfo, black, new Point(90, 940));
                e.Graphics.DrawString("Cognition/Thinking", labelinfo, black, new Point(90, 960));
                e.Graphics.DrawString("Halucinations/Delusions", labelinfo, black, new Point(90, 980));

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

                DrawMSEEllipse(e, info[ctr].GenApp, 800);
                DrawMSEEllipse(e, info[ctr].Attitude, 820);
                DrawMSEEllipse(e, info[ctr].Memory, 840);
                DrawMSEEllipse(e, info[ctr].Speech, 860);
                DrawMSEEllipse(e, info[ctr].AffectAndMood, 880);
                DrawMSEEllipse(e, info[ctr].ThoughtContent, 900);
                DrawMSEEllipse(e, info[ctr].Suicidality, 920);
                DrawMSEEllipse(e, info[ctr].Preoccupations, 940);
                DrawMSEEllipse(e, info[ctr].CognitionThinking, 960);
                DrawMSEEllipse(e, info[ctr].Halucination, 980);

                //LINE 4
                e.Graphics.DrawLine(Pens.Black, new Point(20, 1000), new Point(796, 1000));
                e.Graphics.DrawLine(Pens.Black, new Point(20, 1003), new Point(796, 1003));

                //remarks
                e.Graphics.DrawString("REMARKS", factorfont, black, new Point(47, 1020));
                e.Graphics.DrawString(String.IsNullOrWhiteSpace(info[ctr].Remarks) ? "" : info[ctr].Remarks.Trim(), labelinfo_bold, black, new RectangleF(new Point(90, 1040), new SizeF(750, 260)), new StringFormat() { Alignment = StringAlignment.Near });

                //psychiatric
                e.Graphics.DrawString("PSYCHIATRIC:", labelinfo, black, new Point(47, 1180));
                e.Graphics.DrawString("No psychotic ideation manifested at present", labelinfo_bold, black, new Point(145, 1180));

                //recommendation
                e.Graphics.DrawString("RECOMMENDATION:", factorfont, black, new Point(47, 1200));

                //draw box recommendation
                DrawBoxRec(e, info[ctr].Recommendation);

                //psychometrician
                e.Graphics.DrawString(info[ctr].Psychometrician, signatoryfont, black, new RectangleF(new Point(20, 1240), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                foreach (DataRow d in Psychometrician.Rows)
                {
                    if (Convert.ToString(d["name"]) == info[ctr].Psychometrician)
                    {
                        e.Graphics.DrawString(Convert.ToString(d["title"]), siglabelfont, black, new RectangleF(new Point(20, 1255), new Size(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                        break;
                    }
                }

                //psychiatrist
                e.Graphics.DrawString(info[ctr].Psychiatrist, signatoryfont, black, new RectangleF(new Point(408, 1240), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                foreach (DataRow d in Psychiatrist.Rows)
                {
                    if (Convert.ToString(d["name"]) == info[ctr].Psychiatrist)
                    {
                        e.Graphics.DrawString(Convert.ToString(d["title"]), siglabelfont, black, new RectangleF(new Point(408, 1255), new Size(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                        break;
                    }
                }
                //printed by
                e.Graphics.DrawString("Printed By: " + info[ctr].PrintedBy, printedbyfont, black, new Point(20, 1265));
                

                //has more pages
                ctr++;
                e.HasMorePages = ctr < info.Count;

                //for reprinting
                if (ctr == info.Count)
                    ctr = 0;
            }
            catch (Exception)
            {
                //do nothing
            }

        }

        public DataTable Psychometrician
        {
            set;
            get;
        }

        public DataTable Psychiatrist
        {
            set;
            get;
        }
    }
}
