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
    class BloodTyping_PrintDoc
    {
        PrintDocument doc = new PrintDocument();
        PrintPreviewDialog prev = new PrintPreviewDialog();
        CyberPrintPreview cprev = new CyberPrintPreview();


        public List<LabClientInfo> info;

        //font
        private Font labelinfo = new Font("Arial", 9.75F);
        private Font labelinfo_Italic = new Font("Arial", 8F, FontStyle.Italic);
        private Font labelinfo_bold = new Font("Arial", 9.75F, FontStyle.Bold);
        private Font titlebarfont = new Font("Arial", 11.5F, FontStyle.Bold);
        private Font printedbyfont = new Font("Arial", 6F);
        private Brush black = Brushes.Black;

        private Font radfont = new Font("Arial", 9F);
        private Font radlabelfont = new Font("Arial", 8F);

        private int ctr = 0;

        public BloodTyping_PrintDoc()
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
                e.Graphics.FillRectangle(Brushes.SkyBlue, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 190, 776, 20));
                //e.Graphics.DrawString("SEROLOGY", titlebarfont, Brushes.Black, new RectangleF(new Point(20, 190), new SizeF(776, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //draw background logo
                e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, new Size(776, 300)), new RectangleF(new Point(20, 210), new SizeF(776, 300)));

                //Label
                e.Graphics.DrawString("TEST REQUESTED", labelinfo_Italic, black, new RectangleF(new PointF(20, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString("RESULTS", labelinfo_Italic, black, new RectangleF(new PointF(131, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString("REMARKS", labelinfo_Italic, black, new RectangleF(new PointF(353, 230), new SizeF(444, 20)), new StringFormat() { Alignment = StringAlignment.Near });

                //Results and remarks
                e.Graphics.DrawString("BLOOD TYPING", labelinfo_bold, black, new RectangleF(new PointF(20, 250), new SizeF(111, 100)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(info[ctr].Blood_Typing.Results, labelinfo_bold, black, new RectangleF(new PointF(131, 250), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(info[ctr].Blood_Typing.Remarks, labelinfo_bold, black, new RectangleF(new PointF(353, 250), new SizeF(444, 60)), new StringFormat() { Alignment = StringAlignment.Near });

                //signatories
                if (info[ctr].Blood_Typing.MedTech != null)
                {
                    e.Graphics.DrawString(info[ctr].Blood_Typing.MedTech, radfont, black, new RectangleF(new Point(20, 580), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Medical Technologist", radlabelfont, black, new RectangleF(new Point(20, 595), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                }
                if (info[ctr].Blood_Typing.Pathologist != null)
                {
                    e.Graphics.DrawString(info[ctr].Blood_Typing.Pathologist, radfont, black, new RectangleF(new Point(408, 580), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Pathologist", radlabelfont, black, new RectangleF(new Point(408, 595), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                }

                e.Graphics.DrawString("Printed By: " + info[ctr].Blood_Typing.PrintedBy, printedbyfont, black, new Point(20, 605));


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
