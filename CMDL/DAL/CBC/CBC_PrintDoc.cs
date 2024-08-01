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
    class CBC_PrintDoc
    {
        PrintDocument doc = new PrintDocument();
        PrintPreviewDialog prev = new PrintPreviewDialog();
        CyberPrintPreview cprev = new CyberPrintPreview();
        List<NormalRange> rangeList = null;

        public List<LabClientInfo> info;

        //font
        private Font labelinfo = new Font("Arial", 9.75F);
        private Font labelinfo_Italic = new Font("Arial", 8F, FontStyle.Italic);
        private Font labelcbc = new Font("Arial", 9F);
        private Font labelinfo_bold = new Font("Arial", 9.75F, FontStyle.Bold);
        private Font titlebarfont = new Font("Arial", 11.5F, FontStyle.Bold);
        private Font printedbyfont = new Font("Arial", 6F);
        private Brush black = Brushes.Black;

        private Font radfont = new Font("Arial", 9F);
        private Font radlabelfont = new Font("Arial", 8F);

        private int ctr = 0;

        private const string ERYTHROCYTE_COUNT = "ERYTHROCYTE COUNT";
        private const string HEMOGLOBIN = "HEMOGLOBIN";
        private const string HEMATOCRIT = "HEMATOCRIT";
        private const string LEUKOCYTE_COUNT = "LEUKOCYTE COUNT";
        private const string SEGMENTERS = "SEGMENTERS";
        private const string STABS = "STABS";
        private const string LYMPHOCYTES = "LYMPHOCYTES";
        private const string MONOCYTES = "MONOCYTES";
        private const string EOSINOPHILS = "EOSINOPHILS";
        private const string BASOPHILS = "BASOPHILS";
        private const string PLATELET = "PLATELET";

        public CBC_PrintDoc()
        {
            //paper size
            doc.DefaultPageSettings.PaperSize = new PaperSize("Custom Size", 816, 624);
            //smooth text preview
            prev.UseAntiAlias = true;
            //properties for preview form
            ((Form)prev).WindowState = FormWindowState.Normal;
            ((Form)prev).Size = new Size(600, 600);
            ((Form)prev).StartPosition = FormStartPosition.CenterScreen;
            ((Form)prev).Text = "PRINT PREVIEW";

            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            rangeList = new List<NormalRange>();
            rangeList.Add(new NormalRange() { Examination = ERYTHROCYTE_COUNT, Gender = "M", Minimum = 4.5, Maximum = 6.3 });
            rangeList.Add(new NormalRange() { Examination = HEMOGLOBIN, Gender = "M", Minimum = 140, Maximum = 180 });
            rangeList.Add(new NormalRange() { Examination = HEMATOCRIT, Gender = "M", Minimum = 0.42, Maximum = 0.52 });
            rangeList.Add(new NormalRange() { Examination = LEUKOCYTE_COUNT, Gender = "M", Minimum = 5, Maximum = 10 });
            rangeList.Add(new NormalRange() { Examination = SEGMENTERS, Gender = "M", Minimum = 0.45, Maximum = 0.65 });
            rangeList.Add(new NormalRange() { Examination = STABS, Gender = "M", Minimum = 0.00, Maximum = 0.05 });
            rangeList.Add(new NormalRange() { Examination = LYMPHOCYTES, Gender = "M", Minimum = 0.20, Maximum = 0.40 });
            rangeList.Add(new NormalRange() { Examination = MONOCYTES, Gender = "M", Minimum = 0.03, Maximum = 0.10 });
            rangeList.Add(new NormalRange() { Examination = EOSINOPHILS, Gender = "M", Minimum = 0, Maximum = 0.05 });
            rangeList.Add(new NormalRange() { Examination = BASOPHILS, Gender = "M", Minimum = 0, Maximum = 0.02 });
            rangeList.Add(new NormalRange() { Examination = PLATELET, Gender = "M", Minimum = 150, Maximum = 450 });

            rangeList.Add(new NormalRange() { Examination = ERYTHROCYTE_COUNT, Gender = "F", Minimum = 4.2, Maximum = 5.4 });
            rangeList.Add(new NormalRange() { Examination = HEMOGLOBIN, Gender = "F", Minimum = 120, Maximum = 160 });
            rangeList.Add(new NormalRange() { Examination = HEMATOCRIT, Gender = "F", Minimum = 0.37, Maximum = 0.47 });
            rangeList.Add(new NormalRange() { Examination = LEUKOCYTE_COUNT, Gender = "F", Minimum = 5, Maximum = 10 });
            rangeList.Add(new NormalRange() { Examination = SEGMENTERS, Gender = "F", Minimum = 0.45, Maximum = 0.65 });
            rangeList.Add(new NormalRange() { Examination = STABS, Gender = "F", Minimum = 0.00, Maximum = 0.05 });
            rangeList.Add(new NormalRange() { Examination = LYMPHOCYTES, Gender = "F", Minimum = 0.20, Maximum = 0.40 });
            rangeList.Add(new NormalRange() { Examination = MONOCYTES, Gender = "F", Minimum = 0.03, Maximum = 0.10 });
            rangeList.Add(new NormalRange() { Examination = EOSINOPHILS, Gender = "F", Minimum = 0, Maximum = 0.05 });
            rangeList.Add(new NormalRange() { Examination = BASOPHILS, Gender = "F", Minimum = 0, Maximum = 0.02 });
            rangeList.Add(new NormalRange() { Examination = PLATELET, Gender = "F", Minimum = 150, Maximum = 450 });


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

        private string PrintHighOrLow(string gender, string examination, string result)
        {
            var text = result;

            if (!string.IsNullOrEmpty(gender))
            {
                var genderLowerCase = gender.ToLower();

                var normalValue = rangeList.FirstOrDefault(x => x.Gender.ToLower() == genderLowerCase && x.Examination == examination);
                if (normalValue != null)
                {
                    if (double.TryParse(result, out double _result))
                    {
                        if (_result < normalValue.Minimum)
                        {
                            text = $"{result} L";
                        }
                        else if (_result > normalValue.Maximum)
                        {
                            text = $"{result} H";
                        }
                    }
                }
            }

            return text;
        }

        private void Body(PrintPageEventArgs e)
        {
            //EXAMINATION
            e.Graphics.DrawString("EXAMINATION", labelinfo_Italic, black, new RectangleF(new PointF(20, 230), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(ERYTHROCYTE_COUNT, labelcbc, black, new RectangleF(new PointF(20, 250), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(HEMOGLOBIN, labelcbc, black, new RectangleF(new PointF(20, 270), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(HEMATOCRIT, labelcbc, black, new RectangleF(new PointF(20, 290), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(LEUKOCYTE_COUNT, labelcbc, black, new RectangleF(new PointF(20, 310), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(SEGMENTERS, labelcbc, black, new RectangleF(new PointF(20, 330), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(STABS, labelcbc, black, new RectangleF(new PointF(20, 350), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(LYMPHOCYTES, labelcbc, black, new RectangleF(new PointF(20, 370), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(MONOCYTES, labelcbc, black, new RectangleF(new PointF(20, 390), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(EOSINOPHILS, labelcbc, black, new RectangleF(new PointF(20, 410), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(BASOPHILS, labelcbc, black, new RectangleF(new PointF(20, 430), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PLATELET, labelcbc, black, new RectangleF(new PointF(20, 450), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });

            //NORMAL VALUES
            e.Graphics.DrawString("NORMAL VALUES", labelinfo_Italic, black, new RectangleF(new PointF(538, 230), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("M 4.5 - 6.3 x 10 /L \t F 4.2 - 5.4 x 10 /L", labelcbc, black, new RectangleF(new PointF(538, 250), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("M 140 - 180 x 10 g/L \t F 120 - 160 x 10 g/L", labelcbc, black, new RectangleF(new PointF(538, 270), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("M 0.42 - 0.52 g/L \t F 0.37 - 0.47 g/L", labelcbc, black, new RectangleF(new PointF(538, 290), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("5 - 10.0 x 10 9/L", labelcbc, black, new RectangleF(new PointF(538, 310), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("0.45 - 0.65", labelcbc, black, new RectangleF(new PointF(538, 330), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("0.00 - 0.05", labelcbc, black, new RectangleF(new PointF(538, 350), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("0.20 - 0.40", labelcbc, black, new RectangleF(new PointF(538, 370), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("0.03 - 0.10", labelcbc, black, new RectangleF(new PointF(538, 390), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("0 - 0.05", labelcbc, black, new RectangleF(new PointF(538, 410), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("0 - 0.02", labelcbc, black, new RectangleF(new PointF(538, 430), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("150 - 450 x 10 9/L", labelcbc, black, new RectangleF(new PointF(538, 450), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });

            var gender = info[ctr].Sex;

            //RESULT
            e.Graphics.DrawString("RESULT", labelinfo_Italic, black, new RectangleF(new PointF(279, 230), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, ERYTHROCYTE_COUNT, info[ctr].CBC.Erythrocyte_Count), labelinfo_bold, black, new RectangleF(new PointF(279, 250), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, HEMOGLOBIN, info[ctr].CBC.Hemoglobin), labelinfo_bold, black, new RectangleF(new PointF(279, 270), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, HEMATOCRIT, info[ctr].CBC.Hematocrit), labelinfo_bold, black, new RectangleF(new PointF(279, 290), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, LEUKOCYTE_COUNT, info[ctr].CBC.Leukocyte_Count), labelinfo_bold, black, new RectangleF(new PointF(279, 310), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, SEGMENTERS, info[ctr].CBC.Segmenters), labelinfo_bold, black, new RectangleF(new PointF(279, 330), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, STABS, info[ctr].CBC.Stabs), labelinfo_bold, black, new RectangleF(new PointF(279, 350), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, LYMPHOCYTES, info[ctr].CBC.Lymphocytes), labelinfo_bold, black, new RectangleF(new PointF(279, 370), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, MONOCYTES, info[ctr].CBC.Monocytes), labelinfo_bold, black, new RectangleF(new PointF(279, 390), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, EOSINOPHILS, info[ctr].CBC.Eosinophils), labelinfo_bold, black, new RectangleF(new PointF(279, 410), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, BASOPHILS, info[ctr].CBC.Basophils), labelinfo_bold, black, new RectangleF(new PointF(279, 430), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(PrintHighOrLow(gender, PLATELET, info[ctr].CBC.Platelet), labelinfo_bold, black, new RectangleF(new PointF(279, 450), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });

            //REMARKS
            if (!String.IsNullOrWhiteSpace(info[ctr].CBC.Remarks))
            {
                e.Graphics.DrawString("REMARKS:", labelinfo_Italic, black, new Point(47, 490));
                e.Graphics.DrawString(info[ctr].CBC.Remarks, labelinfo_bold, black, new RectangleF(new PointF(112, 490), new SizeF(600, 100)));
            }
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
                e.Graphics.DrawString("Requesting Party:", labelinfo, black, new Point(47, 141));
                e.Graphics.DrawString(info[ctr].RequestingParty, labelinfo_bold, black, new RectangleF(new PointF(160, 141), new SizeF(320, 40)));
                //DATE
                e.Graphics.DrawString("Date:", labelinfo, black, new Point(489, 119));
                e.Graphics.DrawString(info[ctr].TimeIn, labelinfo_bold, black, new Point(526, 119));
                //AGE/SEX
                e.Graphics.DrawString("Age/Sex:", labelinfo, black, new Point(489, 141));
                e.Graphics.DrawString(info[ctr].Age + "/" + info[ctr].Sex, labelinfo_bold, black, new Point(548, 141));

                //Title bar
                e.Graphics.FillRectangle(Brushes.LightPink, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawString("HEMATOLOGY", titlebarfont, Brushes.Black, new RectangleF(new Point(20, 190), new SizeF(776, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //draw background logo
                e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, new Size(776, 300)), new RectangleF(new Point(20, 210), new SizeF(776, 300)));

                Body(e);

                //signatories
                if (!String.IsNullOrWhiteSpace(info[ctr].CBC.MedTech))
                {
                    e.Graphics.DrawString(info[ctr].CBC.MedTech, radfont, black, new RectangleF(new Point(20, 580), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Medical Technologist", radlabelfont, black, new RectangleF(new Point(20, 595), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });


                }
                if (!String.IsNullOrWhiteSpace(info[ctr].CBC.Pathologist))
                {
                    e.Graphics.DrawString(info[ctr].CBC.Pathologist, radfont, black, new RectangleF(new Point(408, 580), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Pathologist", radlabelfont, black, new RectangleF(new Point(408, 595), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                }

                e.Graphics.DrawString("Printed By: " + info[ctr].CBC.PrintedBy, printedbyfont, black, new Point(20, 605));


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

        public class NormalRange
        {
            public string Gender { get; set; }
            public string Examination { get; set; }
            public double Minimum { get; set; }
            public double Maximum { get; set; }
        }
    }
}
