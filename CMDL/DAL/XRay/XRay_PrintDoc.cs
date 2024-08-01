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
    public class XRay_PrintDoc
    {
        PrintDocument doc = new PrintDocument();
        PrintPreviewDialog prev = new PrintPreviewDialog();
        CyberPrintPreview cprev = new CyberPrintPreview();

        public List<XRayClientInfo> info;

        //font
        private Font labelinfo = new Font("Arial", 9.75F);
        private Font labelinfo_bold = new Font("Arial", 9.75F, FontStyle.Bold);
        private Font titlebarfont = new Font("Arial", 11.5F, FontStyle.Bold);
        private Font printedbyfont = new Font("Arial", 6F);
        private Brush black = Brushes.Black;

        private Font radfont = new Font("Arial", 9F);
        private Font radlabelfont = new Font("Arial", 8F);

        private int ctr = 0;

        public XRay_PrintDoc()
        {
            //paper size
            doc.DefaultPageSettings.PaperSize = new PaperSize("Custom Size", 816, 624);
            //smooth text preview
            prev.UseAntiAlias = true;
            //no. of columns to display
            //prev.PrintPreviewControl.Columns = 3;
            //properties for preview form
            ((Form)prev).WindowState = FormWindowState.Normal;
            ((Form)prev).Size = new Size(600, 600);
            ((Form)prev).StartPosition = FormStartPosition.CenterScreen;
            ((Form)prev).Text = "PRINT PREVIEW";

            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

        }

        public void Preview(List<XRayClientInfo> info)
        {
            this.info = info;
            ctr = 0;
            prev.Document = doc;
            prev.ShowDialog();
        }

        public void CyberPreview(List<XRayClientInfo> info)
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

                //NAME
                e.Graphics.DrawString("Name:", labelinfo, black, new Point(47, 119));
                e.Graphics.DrawString(info[ctr].LastName + ", " + info[ctr].FirstName + " " + info[ctr].MI + " " + info[ctr].Suffix, labelinfo_bold, black, new Point(90, 119));
                //EXAMINATION
                e.Graphics.DrawString("Exam:", labelinfo, black, new Point(47, 141));
                e.Graphics.DrawString(info[ctr].Marker, labelinfo_bold, black, new Point(90, 141));
                //DATE
                e.Graphics.DrawString("Date:", labelinfo, black, new Point(489, 119));
                e.Graphics.DrawString(info[ctr].TimeIn, labelinfo_bold, black, new Point(526, 119));
                //AGE/SEX
                e.Graphics.DrawString("Age/Sex:", labelinfo, black, new Point(489, 141));
                e.Graphics.DrawString(info[ctr].Age + "/" + info[ctr].Sex, labelinfo_bold, black, new Point(548, 141));

                //Title bar
                e.Graphics.FillRectangle(Brushes.Yellow, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawString("RADIOLOGICAL REPORT", titlebarfont, Brushes.Black, new RectangleF(new Point(20, 190), new SizeF(776, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //draw background logo
                e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, new Size(776, 300)), new RectangleF(new Point(20, 210), new SizeF(776, 300)));

                //radio report
                int remarksYPos = 400;
                if (!String.IsNullOrWhiteSpace(info[ctr].RadioReport))
                {
                    var strList = info[ctr].RadioReport.Split(new char[]{'.'}, StringSplitOptions.None);
                    var radioReport = string.Empty;

                    foreach (var str in strList)
                    {
                        if (!String.IsNullOrWhiteSpace(str))
                        {
                            //radioReport += str.Trim() + ". ";
                            radioReport += str.Trim() + "." + Environment.NewLine;
                        }
                    }


                    //e.Graphics.DrawString(info[ctr].RadioReport, labelinfo_bold, black, new RectangleF(new Point(60, 220), new SizeF(696, 120)), new StringFormat() { Alignment = StringAlignment.Near });
                    //e.Graphics.DrawRectangle(Pens.Red, new Rectangle(60, 220, 696, (strList.Length * 20)));
                    e.Graphics.DrawString(radioReport, labelinfo_bold, black, new RectangleF(new Point(60, 220), new SizeF(696, (strList.Length * 20))), new StringFormat() { Alignment = StringAlignment.Near });
                    remarksYPos = (strList.Length * 20) + 220;
                }

                //conclusion
                //e.Graphics.DrawString("REMARKS:", labelinfo, black, new Point(60, 400));
                //e.Graphics.DrawString(info[ctr].Conclusion, labelinfo_bold, black, new RectangleF(new Point(136, 400), new SizeF(620, 130)), new StringFormat() { Alignment = StringAlignment.Near });
               

                if (!String.IsNullOrWhiteSpace(info[ctr].Conclusion))
                {
                    e.Graphics.DrawString(info[ctr].Conclusion.Contains("NEGATIVE") ? "CONCLUSION:" : "REMARKS:", labelinfo, black, new Point(60, remarksYPos));
                    var strList = info[ctr].Conclusion.Split(new char[] { '.' }, StringSplitOptions.None);
                    var remarks = string.Empty;

                    foreach (var str in strList)
                    {
                        if (!String.IsNullOrWhiteSpace(str))
                        {
                            remarks += str.Trim() + "." + Environment.NewLine;
                            //remarks += str.Trim() + ". ";
                        }
                    }

                    e.Graphics.DrawString(remarks, labelinfo_bold, black, new RectangleF(new Point(160, remarksYPos), new SizeF(620, (strList.Length * 20))), new StringFormat() { Alignment = StringAlignment.Near });
                    //e.Graphics.DrawString(info[ctr].Conclusion, labelinfo_bold, black, new RectangleF(new Point(136, remarksYPos), new SizeF(620, 130)), new StringFormat() { Alignment = StringAlignment.Near });
                }

                //radiologist
                e.Graphics.DrawString(info[ctr].Radiologist, radfont, black, new RectangleF(new Point(408, 580), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(info[ctr].Radiologist.Contains("PILAR M. LACEDA") ? "Medical Director" : info[ctr].RadiologistTitle, radlabelfont, black, new RectangleF(new Point(408, 595), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });



                e.Graphics.DrawString("Printed By: " + info[ctr].PrintedBy, printedbyfont, black, new Point(20, 605));

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
