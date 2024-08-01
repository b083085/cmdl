using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data;

namespace CMDL
{
    class PE_PrintDoc
    {
        PrintDocument doc = new PrintDocument();
        PrintPreviewDialog prev = new PrintPreviewDialog();
        CyberPrintPreview cprev = new CyberPrintPreview();


        public List<LabClientInfo> info;

        //font
        private Font labelinfo = new Font("Arial", 9.75F);
        private Font labelinfo_Italic = new Font("Arial", 7.5F, FontStyle.Italic);
        private Font labelpe = new Font("Arial", 9F);
        private Font labelinfo_bold = new Font("Arial", 9.75F, FontStyle.Bold);
        private Font titlebarfont = new Font("Arial", 11.5F, FontStyle.Bold);
        private Font printedbyfont = new Font("Arial", 6F);
        private Brush black = Brushes.Black;

        private Font radfont = new Font("Arial", 9F);
        private Font radlabelfont = new Font("Arial", 8F);

        private int ctr = 0;

        public PE_PrintDoc()
        {
            //paper size
            doc.DefaultPageSettings.PaperSize = new PaperSize("Custom Size", 816, 1248);
            //smooth text preview
            prev.UseAntiAlias = true;
            //properties for preview form
            ((Form)prev).WindowState = FormWindowState.Normal;
            ((Form)prev).Size = new Size(600, 600);
            ((Form)prev).StartPosition = FormStartPosition.CenterScreen;
            ((Form)prev).Text = "PRINT PREVIEW";

            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

        }


        public void Preview(List<LabClientInfo> info)
        {
            this.info = info;
            ctr = 0;
            prev.Document = doc;
            prev.ShowDialog();
        }

        public void CyberPreview(List<LabClientInfo> info)
        {
            this.info = info;
            ctr = 0;
            cprev.Document = doc;
            cprev.ShowDialog();
        }

        private void Body(PrintPageEventArgs e)
        {
            //PHYSICAL EXAMINATION
            e.Graphics.DrawString("I.PHYSICAL EXAMINATION", labelinfo, black, new Point(36, 259));
            //GROWTH DEVELOPMENT
            e.Graphics.DrawString("GROWTH DEVELOPMENT", labelinfo_Italic, black, new Point(36, 279));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Growth_Development, labelinfo_bold, black, new Point(36, 289));
            //VITAL SIGNS
            e.Graphics.DrawString("VITAL SIGNS", labelinfo_Italic, black, new Point(36, 309));
            //BP
            e.Graphics.DrawString("BP", labelinfo_Italic,black, new Point(70, 319));
            if (!String.IsNullOrWhiteSpace(info[ctr].Physical_Examination.BP))
                e.Graphics.DrawString(info[ctr].Physical_Examination.BP, labelinfo_bold, black, new Point(70, 329));
            //HR
            e.Graphics.DrawString("HR", labelinfo_Italic, black, new Point(170, 319));
            if (!String.IsNullOrWhiteSpace(info[ctr].Physical_Examination.HR))
                e.Graphics.DrawString(info[ctr].Physical_Examination.HR + "/min", labelinfo_bold, black, new Point(170, 329));
            //PR
            e.Graphics.DrawString("PR", labelinfo_Italic, black, new Point(270, 319));
            if (!String.IsNullOrWhiteSpace(info[ctr].Physical_Examination.PR))
                e.Graphics.DrawString(info[ctr].Physical_Examination.PR + "/min", labelinfo_bold, black, new Point(270, 329));
            //VITAL SIGNS
            e.Graphics.DrawString("BODY MEASUREMENTS", labelinfo_Italic, black, new Point(36, 349));
            //HEIGHT
            e.Graphics.DrawString("Height", labelinfo_Italic,black, new Point(70, 359));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Height, labelinfo_bold, black, new Point(70, 369));
            //WEIGHT
            e.Graphics.DrawString("Weight", labelinfo_Italic, black, new Point(170, 359));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Weight, labelinfo_bold, black, new Point(170, 369));
            //EYES
            e.Graphics.DrawString("EYES", labelinfo_Italic,black, new Point(36, 389));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Eyes, labelinfo_bold, black, new Point(70, 389));
            e.Graphics.DrawString("Visual Acuity", labelinfo_Italic, black, new Point(36, 399));

            e.Graphics.DrawString("OD", labelinfo_Italic, black, new Point(70, 409));
            if (!String.IsNullOrWhiteSpace(info[ctr].Physical_Examination.OD))
            e.Graphics.DrawString("20/" + info[ctr].Physical_Examination.OD, labelinfo_bold,black, new Point(70, 419));

            e.Graphics.DrawString("OS", labelinfo_Italic, black, new System.Drawing.Point(170, 409));
            if (!String.IsNullOrWhiteSpace(info[ctr].Physical_Examination.OS))
            e.Graphics.DrawString("20/" + info[ctr].Physical_Examination.OS, labelinfo_bold,black, new Point(170, 419));
            
            e.Graphics.DrawString("Ishihara Test", labelinfo_Italic, black, new Point(36, 439));
            
            e.Graphics.DrawString("OD", labelinfo_Italic, black, new Point(70, 449));
            if (!String.IsNullOrWhiteSpace(info[ctr].Physical_Examination.Ishi_OD))
            e.Graphics.DrawString("20:/" + info[ctr].Physical_Examination.Ishi_OD, labelinfo_bold, black, new Point(70, 459));
            
            e.Graphics.DrawString("OS:", labelinfo_Italic,black, new Point(170, 449));
            if (!String.IsNullOrWhiteSpace(info[ctr].Physical_Examination.Ishi_OS))
            e.Graphics.DrawString("20:/" + info[ctr].Physical_Examination.Ishi_OS,labelinfo_bold,black, new Point(170, 459));
            //EARS
            e.Graphics.DrawString("EARS", labelinfo_Italic, black, new Point(350, 279));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Ears, labelinfo_bold, black, new Point(447, 279));
            //NOSE/THROAT
            e.Graphics.DrawString("NOSE/THROAT", labelinfo_Italic, black, new Point(350, 299));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Nose_Throat, labelinfo_bold, black, new Point(447, 299));
            //DENTALS
            e.Graphics.DrawString("DENTAL", labelinfo_Italic, black, new Point(350, 319));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Dentals, labelinfo_bold, black, new Point(447, 319));
            //BREATS
            e.Graphics.DrawString("BREAST", labelinfo_Italic, black, new Point(350, 339));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Breast, labelinfo_bold, black, new Point(447, 339));
            //EXTREMITIES
            e.Graphics.DrawString("EXTREMITIES", labelinfo_Italic, black, new Point(350, 359));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Extremities, labelinfo_bold, black, new Point(447, 359));
            //NEUROLOGIC
            e.Graphics.DrawString("NEUROLOGIC", labelinfo_Italic, black, new Point(350, 379));
            e.Graphics.DrawString(info[ctr].Physical_Examination.NeuroLog, labelinfo_bold, black, new Point(447, 379));
            //HEART
            e.Graphics.DrawString("HEART", labelinfo_Italic, black, new Point(350, 399));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Heart, labelinfo_bold, black, new Point(447, 399));
            //LUNGS
            e.Graphics.DrawString("LUNGS", labelinfo_Italic, black, new Point(350, 419));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Lungs, labelinfo_bold, black, new Point(447, 419));
            //ABDOMEN
            e.Graphics.DrawString("ABDOMEN", labelinfo_Italic, black, new Point(350, 439));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Abdomen, labelinfo_bold, black, new Point(447, 439));
            //GENITALIA
            e.Graphics.DrawString("GENITALIA", labelinfo_Italic, black, new Point(350, 459));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Genitalia, labelinfo_bold, black, new Point(447, 459));
            //ANO RECTAL
            e.Graphics.DrawString("ANO RECTAL", labelinfo_Italic, black, new Point(350, 479));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Ano_Rectal, labelinfo_bold, black, new Point(447, 479));
            //SKIN
            e.Graphics.DrawString("SKIN", labelinfo_Italic, black, new Point(350, 499));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Skin, labelinfo_bold, black, new Point(447, 499));
            //OTHERS
            e.Graphics.DrawString("OTHERS", labelinfo_Italic, black, new Point(350, 519));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Other_Body_Parts, labelinfo_bold, black, new Point(447, 519));
            //PAST MEDICAL HISTORY
            e.Graphics.DrawString("PAST MEDICAL HISTORY", labelinfo_Italic, black, new Point(36, 479));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Past_Med_History, labelinfo_bold, black, new RectangleF(new Point(36, 489),new SizeF(300,40)));

            //RADIOLOGICAL REPORT
            //
            //

            e.Graphics.DrawString("II.RADIOLOGICAL REPORT", labelinfo,black, new Point(36, 549));
            //CHEST X-RAY
            e.Graphics.DrawString("CHEST X-RAY", labelinfo_Italic,black, new Point(36, 569));
            //Date
            e.Graphics.DrawString("Date", labelinfo_Italic,black, new Point(70, 579));
            e.Graphics.DrawString(info[ctr].Physical_Examination.CXR_Date, labelinfo_bold,black, new Point(70, 589));
            //Film No
            e.Graphics.DrawString("Film No", labelinfo_Italic,black, new Point(170, 579));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Film_No, labelinfo_bold, black, new Point(170, 589));

            if (info[ctr].Physical_Examination.CXR_Date.ToUpper() != "NOT DONE")
            {
                //ESSENTIALLY NEGATIVE
                e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(270, 581, 10, 10));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(270, 579, 10, 10));
                e.Graphics.DrawString("ESSENTIALLY NEGATIVE", labelinfo_Italic, black, new Point(290, 579));
                if (info[ctr].Physical_Examination.CXR_Negative == "1")
                    e.Graphics.FillEllipse(Brushes.Black, new Rectangle(270, 579, 10, 10));

                e.Graphics.DrawString("Findings", labelinfo_Italic, black, new Point(490, 579));
                e.Graphics.DrawString(info[ctr].Physical_Examination.CXR_Findings, labelinfo_bold, black, new RectangleF(new PointF(490, 589), new SizeF(300, 100)));
                //e.Graphics.DrawRectangle(Pens.Black, new Rectangle(new Point(490, 589), new Size(300, 100)));
            }


            //LABORATORY
            //
            //
            //
            e.Graphics.DrawString("III.LABORATORY EXAMINATION", labelinfo, black, new Point(36, 609));
            //EARS
            e.Graphics.DrawString("CBC", labelinfo_Italic, black, new Point(36, 629));
            e.Graphics.DrawString(info[ctr].Physical_Examination.CBC, labelinfo_bold, black, new Point(140, 629));
            //NOSE/THROAT
            e.Graphics.DrawString("URINALYSIS", labelinfo_Italic, black, new Point(36, 649));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Urine, labelinfo_bold, black, new Point(140, 649));
            //DENTALS
            e.Graphics.DrawString("STOOL EXAM", labelinfo_Italic, black, new Point(36, 669));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Stool, labelinfo_bold, black, new Point(140, 669));
            //BREATS
            e.Graphics.DrawString("BLOOD CHEMISTRY", labelinfo_Italic, black, new Point(36, 689));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Blood_Chemistry, labelinfo_bold, black, new Point(140, 689));
            //EXTREMITIES
            e.Graphics.DrawString("PREGNANCY TEST", labelinfo_Italic, black, new Point(36, 709));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Pregnancy_Test, labelinfo_bold, black, new Point(140, 709));
            //NEUROLOGIC
            e.Graphics.DrawString("VDRL", labelinfo_Italic, black, new Point(36, 729));
            e.Graphics.DrawString(info[ctr].Physical_Examination.VDRL, labelinfo_bold, black, new Point(140, 729));
            //HEART
            e.Graphics.DrawString("HEP A", labelinfo_Italic, black, new Point(36, 749));
            e.Graphics.DrawString(info[ctr].Physical_Examination.HepA, labelinfo_bold, black, new Point(140, 749));
            //LUNGS
            e.Graphics.DrawString("HEP B", labelinfo_Italic, black, new Point(36, 769));
            e.Graphics.DrawString(info[ctr].Physical_Examination.HepB, labelinfo_bold, black, new Point(140, 769));
            //ABDOMEN
            e.Graphics.DrawString("HIV", labelinfo_Italic, black, new Point(36, 789));
            e.Graphics.DrawString(info[ctr].Physical_Examination.HIV, labelinfo_bold, black, new Point(140, 789));
            //GENITALIA
            e.Graphics.DrawString("DRUG TEST", labelinfo_Italic, black, new Point(36, 809));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Drug_Test, labelinfo_bold, black, new Point(140, 809));
            //ANO RECTAL
            e.Graphics.DrawString("BLOOD TYPING", labelinfo_Italic, black, new Point(36, 829));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Blood_Typing, labelinfo_bold, black, new Point(140, 829));
            //SKIN
            e.Graphics.DrawString("OTHERS", labelinfo_Italic, black, new Point(36, 849));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Other_Test, labelinfo_bold, black, new Point(140, 849));

            //LABORATORY
            //
            //
            //
            e.Graphics.DrawString("IV.NEURO PSYCHOLOGICAL/PSYCHIATRIC TEST REPORT", labelinfo, black, new Point(36, 869));
            //SKIN
            e.Graphics.DrawString("PSYCHOLOGICAL TEST", labelinfo_Italic, black, new Point(36, 889));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Neuro_Psychological, labelinfo_bold, black, new Point(160, 889));
            //SKIN
            e.Graphics.DrawString("PSYCHIATRIC TEST", labelinfo_Italic, black, new Point(36, 909));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Neuro_Psychiatric, labelinfo_bold, black, new Point(160, 909));

            e.Graphics.DrawString("REMARKS", labelinfo, black, new Point(36, 929));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Remarks, labelinfo_bold, black, new RectangleF(new Point(36, 949),new SizeF(400,240)));
            //e.Graphics.DrawRectangle(Pens.Black, new Rectangle(new Point(36, 949), new Size(400, 240)));

            e.Graphics.DrawString("RECOMMENDATION", labelinfo, black, new Point(436, 929));

            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(439, 951, 10, 10));
            e.Graphics.FillRectangle(Brushes.White, new Rectangle(436, 949, 10, 10));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(436, 949, 10, 10));
            e.Graphics.DrawString("CLASS A  Physically fit for all types of work",labelinfo_Italic,black, new Point(450, 949));
            if (info[ctr].Physical_Examination.Recommendation == "CLASS A")
                e.Graphics.FillEllipse(Brushes.Black, new Rectangle(436, 949, 10, 10));
            //CLASS B
            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(439, 971, 10, 10));
            e.Graphics.FillRectangle(Brushes.White, new Rectangle(436, 969, 10, 10));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(436, 969, 10, 10));
            e.Graphics.DrawString("CLASS B  Physically fit for all types of work with minor ailment(s) or defects(s)",labelinfo_Italic,black, new RectangleF(new Point(450, 969),new SizeF(350,40)));
            if (info[ctr].Physical_Examination.Recommendation == "CLASS B")
                e.Graphics.FillEllipse(Brushes.Black, new Rectangle(436, 969, 10, 10));
            //CLASS C
            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(439, 1011, 10, 10));
            e.Graphics.FillRectangle(Brushes.White, new Rectangle(436, 1009, 10, 10));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(436, 1009, 10, 10));
            e.Graphics.DrawString("CLASS C  Physically fit for certain jobs. Employment at the risk and discretion of the management", labelinfo_Italic, black, new RectangleF(new Point(450, 1009), new SizeF(350, 40)));
            if (info[ctr].Physical_Examination.Recommendation == "CLASS C")
                e.Graphics.FillEllipse(Brushes.Black, new RectangleF(436, 1009, 10, 10));

            //UNFIT
            e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(439, 1051, 10, 10));
            e.Graphics.FillRectangle(Brushes.White, new Rectangle(436, 1049, 10, 10));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(436, 1049, 10, 10));
            e.Graphics.DrawString("UNFIT", labelinfo_Italic, black, new RectangleF(new Point(450, 1049), new SizeF(200, 20)));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Rec_Note, labelinfo_bold, black, new RectangleF(new Point(490, 1049), new SizeF(340, 100)));
            //e.Graphics.DrawRectangle(Pens.Black, new Rectangle(new Point(490, 1049), new Size(340, 100)));
            if (info[ctr].Physical_Examination.Recommendation == "UNFIT")
                e.Graphics.FillEllipse(Brushes.Black, new RectangleF(436, 1049, 10, 10));

            //EXAMINEE'S SIGNATURE
            e.Graphics.DrawString("__________________________________", labelinfo_Italic, black, new RectangleF(new Point(36, 1179), new SizeF(200, 20)), new StringFormat() {  Alignment = StringAlignment.Center});
            e.Graphics.DrawString("Examinee's Signature", radlabelfont, black, new RectangleF(new Point(36, 1189), new SizeF(200, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            //Referred by
            e.Graphics.DrawString("Referred By", labelinfo_Italic, black, new Point(36, 1209));
            e.Graphics.DrawString(info[ctr].Physical_Examination.Ref_By, labelinfo_bold, black, new Point(100, 1209));

            
            //PHYSICIAN'S SIGNATURE
            foreach (DataRow p in Physician.Rows)
            {
                if (Convert.ToString(p["name"]) == info[ctr].Physical_Examination.Physician)
                {
                    e.Graphics.DrawString(info[ctr].Physical_Examination.Physician, radfont, black, new RectangleF(new Point(436, 1179), new SizeF(300, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Physician's Signature", radlabelfont, black, new RectangleF(new Point(436, 1189), new SizeF(300, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("License No. " + Convert.ToString(p["license_no"]), radlabelfont, black, new RectangleF(new Point(436, 1199), new SizeF(300, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    break;
                }
            }
            //NOTE
            e.Graphics.DrawString("NOTE: Physical Examination and X-Ray result will not be valid after (3) months.", labelinfo_Italic, black, new RectangleF(new PointF(400, 1229), new SizeF(400, 40)), new StringFormat() { Alignment = StringAlignment.Center});

        }

        public DataTable Physician
        {
            set;
            get;
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                StandardHeader.Print(e, info[ctr].ControlNo, (Image)Edit.BitmapSourceToBitmap((System.Windows.Media.Imaging.BitmapSource)info[ctr].Photo));

                //NAME
                e.Graphics.DrawString("Name:", labelinfo, black, new Point(47, 119));
                e.Graphics.DrawString(info[ctr].LastName + ", " + info[ctr].FirstName + " " + info[ctr].MI + " " + info[ctr].Suffix, labelinfo_bold, black, new Point(90, 119));
                //EXAMINATION
                e.Graphics.DrawString("Civil Status:", labelinfo, black, new Point(47, 141));
                e.Graphics.DrawString(info[ctr].CivilStatus, labelinfo_bold, black, new RectangleF(new PointF(125, 141), new SizeF(320, 40)));
                //NATURE OF WORK
                e.Graphics.DrawString("Nature Of Work:", labelinfo, black, new Point(47, 163));
                e.Graphics.DrawString(info[ctr].Physical_Examination.Nature_Of_Work, labelinfo_bold, black, new RectangleF(new PointF(152, 163), new SizeF(420, 20)));
                //EXAMINATION
                e.Graphics.DrawString("Address:", labelinfo, black, new Point(47, 185));
                e.Graphics.DrawString(info[ctr].Address, labelinfo_bold, black, new RectangleF(new PointF(105, 185), new SizeF(520, 40)));

                //DATE
                e.Graphics.DrawString("Date:", labelinfo, black, new Point(489, 119));
                e.Graphics.DrawString(info[ctr].TimeIn, labelinfo_bold, black, new Point(526, 119));
                //AGE/SEX
                e.Graphics.DrawString("Age/Sex:", labelinfo, black, new Point(489, 141));
                e.Graphics.DrawString(info[ctr].Age + "/" + info[ctr].Sex, labelinfo_bold, black, new Point(548, 141));

                //Title bar
                e.Graphics.FillRectangle(Brushes.Orange, new Rectangle(20, 229, 776, 20));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 229, 776, 20));
                e.Graphics.DrawString("MEDICAL EXAMINATION RECORD", titlebarfont, Brushes.Black, new RectangleF(new Point(20, 229), new SizeF(776, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //draw background logo
                e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, new Size(776, 300)), new RectangleF(new Point(20, 249), new SizeF(776, 300)));

                Body(e);

                e.Graphics.DrawString("Printed By: " + info[ctr].Physical_Examination.PrintedBy, printedbyfont, black, new Point(20, 1229));


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
    }
}
