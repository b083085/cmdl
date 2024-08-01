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
    class Stool_PrintDoc
    {
        PrintDocument doc = new PrintDocument();
        PrintPreviewDialog prev = new PrintPreviewDialog();
        CyberPrintPreview cprev = new CyberPrintPreview();


        public List<LabClientInfo> info;

        //font
        private Font labelinfo = new Font("Arial", 9.75F);
        private Font labelinfo_Italic = new Font("Arial", 8F, FontStyle.Italic);
        private Font labelstool = new Font("Arial", 9F);
        private Font labelinfo_bold = new Font("Arial", 9.75F, FontStyle.Bold);
        private Font titlebarfont = new Font("Arial", 11.5F, FontStyle.Bold);
        private Font printedbyfont = new Font("Arial", 6F);
        private Brush black = Brushes.Black;

        private Font radfont = new Font("Arial", 9F);
        private Font radlabelfont = new Font("Arial", 8F);

        private int ctr = 0;

        public Stool_PrintDoc()
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

        private void Body(PrintPageEventArgs e)
        {
            e.Graphics.DrawString("MACROSCOPIC", labelinfo_Italic, black, new Point(36, 230));
            e.Graphics.DrawString("MICROSCOPIC", labelinfo_Italic, black,  new Point(36, 290));
            e.Graphics.DrawString("CHEMICAL ANALYSIS", labelinfo_Italic, black, new Point(36, 430));
            //COLOR
            e.Graphics.DrawString("COLOR:", labelinfo, black, new Point(36, 250));
            e.Graphics.DrawString(info[ctr].Stool.Color, labelinfo_bold, black, new RectangleF(new Point(93, 250), new SizeF(200, 100)), new StringFormat() { Alignment = StringAlignment.Near });
            //CONSISTENCY
            e.Graphics.DrawString("CONSISTENCY:", labelinfo, black, new Point(500, 250));
            e.Graphics.DrawString(info[ctr].Stool.Consistency, labelinfo_bold, black, new RectangleF(new Point(610, 250), new SizeF(200, 100)), new StringFormat() { Alignment = StringAlignment.Near });
            //LEUKOCYTES
            e.Graphics.DrawString("LEUKOCYTES:", labelinfo, black, new Point(36, 310));
            e.Graphics.DrawString(info[ctr].Stool.Leukocytes, labelinfo_bold, black, new RectangleF(new Point(138, 310), new SizeF(200, 100)), new StringFormat() { Alignment = StringAlignment.Near });
            //ERYTHROCYTES
            e.Graphics.DrawString("ERYTHROCYTES:", labelinfo, black, new Point(36, 350));
            e.Graphics.DrawString(info[ctr].Stool.Erythrocytes, labelinfo_bold, black, new RectangleF(new Point(157, 350), new SizeF(200, 100)), new StringFormat() { Alignment = StringAlignment.Near });
            //FAT GLOBULES
            e.Graphics.DrawString("FAT GLOBULES:", labelinfo, black, new Point(36, 390));
            e.Graphics.DrawString(info[ctr].Stool.Fat_Globules, labelinfo_bold, black, new RectangleF(new Point(148, 390), new SizeF(200, 100)), new StringFormat() { Alignment = StringAlignment.Near });
            //YEAST CELLS
            e.Graphics.DrawString("YEAST CELLS:", labelinfo, black, new Point(500, 310));
            e.Graphics.DrawString(info[ctr].Stool.Yeast_Cells, labelinfo_bold, black, new RectangleF(new Point(603, 310), new SizeF(200, 100)), new StringFormat() { Alignment = StringAlignment.Near });
            //OVA OF PARASITE
            e.Graphics.DrawString("OVA/PARASITE:", labelinfo, black, new Point(500, 350));
            e.Graphics.DrawString(info[ctr].Stool.Ova_Of_Parasite, labelinfo_bold, black, new RectangleF(new Point(610, 350), new SizeF(200, 100)), new StringFormat() { Alignment = StringAlignment.Near });
            //PROTOZOAN
            e.Graphics.DrawString("PROTOZOAN:", labelinfo, black, new Point(500, 390));
            e.Graphics.DrawString(info[ctr].Stool.Protozoan, labelinfo_bold, black, new RectangleF(new Point(595, 390), new SizeF(200, 100)), new StringFormat() { Alignment = StringAlignment.Near });
            //OCCULT BLOOD
            e.Graphics.DrawString("OCCULT BLOOD:", labelinfo, black, new Point(36, 450));
            e.Graphics.DrawString(info[ctr].Stool.Occult_Blood, labelinfo_bold, black, new RectangleF(new Point(153, 450), new SizeF(200, 100)), new StringFormat() { Alignment = StringAlignment.Near});

            //REMARKS
            if (!String.IsNullOrWhiteSpace(info[ctr].Stool.Remarks))
            {
                e.Graphics.DrawString("REMARKS:", labelinfo_Italic, black, new Point(47, 490));
                e.Graphics.DrawString(info[ctr].Stool.Remarks, labelinfo_bold, black, new RectangleF(new PointF(112, 490), new SizeF(600, 100)));
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
                e.Graphics.FillRectangle(Brushes.Khaki, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawString("FECALYSIS", titlebarfont, Brushes.Black, new RectangleF(new Point(20, 190), new SizeF(776, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //draw background logo
                e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, new Size(776, 300)), new RectangleF(new Point(20, 210), new SizeF(776, 300)));

                Body(e);

                //signatories
                if (!String.IsNullOrWhiteSpace(info[ctr].Stool.MedTech))
                {
                    e.Graphics.DrawString(info[ctr].Stool.MedTech, radfont, black, new RectangleF(new Point(20, 580), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Medical Technologist", radlabelfont, black, new RectangleF(new Point(20, 595), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                }
                if (!String.IsNullOrWhiteSpace(info[ctr].Stool.Pathologist))
                {
                    e.Graphics.DrawString(info[ctr].Stool.Pathologist, radfont, black, new RectangleF(new Point(408, 580), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Pathologist", radlabelfont, black, new RectangleF(new Point(408, 595), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                }

                e.Graphics.DrawString("Printed By: " + info[ctr].Stool.PrintedBy, printedbyfont, black, new Point(20, 605));


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
