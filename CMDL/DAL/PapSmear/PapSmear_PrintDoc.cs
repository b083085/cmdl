using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data;

namespace CMDL.CLASS
{
    public class PapSmear_PrintDoc
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

        public PapSmear_PrintDoc()
        {
            //paper size
            doc.DefaultPageSettings.PaperSize = new PaperSize("Custom Size", 816, 1056);
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
            //COLLECTION
            e.Graphics.DrawString("COLLECTION:", labelinfo, black, new Point(36, 230));
            e.Graphics.DrawString(info[ctr].Urinalysis.Collection, labelinfo_bold, black, new Point(170, 230));
            //COLOR
            e.Graphics.DrawString("COLOR:", labelinfo, black, new Point(36, 250));
            e.Graphics.DrawString(info[ctr].Urinalysis.Color, labelinfo_bold, black, new Point(170, 250));
            //TRANSPARENCY
            e.Graphics.DrawString("TRANSPARENCY:", labelinfo, black, new Point(36, 270));
            e.Graphics.DrawString(info[ctr].Urinalysis.Transparency, labelinfo_bold, black, new Point(170, 270));
            //SPECIFIC GRAVITY
            e.Graphics.DrawString("SPECIFIC GRAVITY:", labelinfo, black, new Point(36, 290));
            e.Graphics.DrawString(info[ctr].Urinalysis.Specific_Gravity, labelinfo_bold, black, new Point(170, 290));
            //PH
            e.Graphics.DrawString("PH:", labelinfo, black, new Point(36, 310));
            e.Graphics.DrawString(info[ctr].Urinalysis.PH, labelinfo_bold, black, new Point(170, 310));
            //GLUCOSE
            e.Graphics.DrawString("GLUCOSE:", labelinfo, black, new Point(36, 330));
            e.Graphics.DrawString(info[ctr].Urinalysis.Glucose, labelinfo_bold, black, new Point(170, 330));
            //PROTEIN
            e.Graphics.DrawString("PROTEIN:", labelinfo, black, new Point(36, 350));
            e.Graphics.DrawString(info[ctr].Urinalysis.Protein, labelinfo_bold, black, new Point(170, 350));
            //BLOOD
            e.Graphics.DrawString("BLOOD:", labelinfo, black, new Point(36, 370));
            e.Graphics.DrawString(info[ctr].Urinalysis.Blood, labelinfo_bold, black, new Point(170, 370));
            //LEUCOCYTES
            e.Graphics.DrawString("LEUKOCYTES:", labelinfo, black, new Point(36, 390));
            e.Graphics.DrawString(info[ctr].Urinalysis.Leukocytes, labelinfo_bold, black, new Point(170, 390));
            //NITRITE
            e.Graphics.DrawString("NITRITE:", labelinfo, black, new Point(36, 410));
            e.Graphics.DrawString(info[ctr].Urinalysis.Nitrite, labelinfo_bold, black, new Point(170, 410));
            //KETONE
            e.Graphics.DrawString("KETONE:", labelinfo, black, new Point(36, 430));
            e.Graphics.DrawString(info[ctr].Urinalysis.Ketone, labelinfo_bold, black, new Point(170, 430));
            //UROBILINOGEN
            e.Graphics.DrawString("UROBILINOGEN:", labelinfo, black, new Point(36, 450));
            e.Graphics.DrawString(info[ctr].Urinalysis.Urobilinogen, labelinfo_bold, black, new Point(170, 450));
            //ASCORBIC ACID
            e.Graphics.DrawString("ASCORBIC ACID:", labelinfo, black, new Point(36, 470));
            e.Graphics.DrawString(info[ctr].Urinalysis.Ascorbic_Acid, labelinfo_bold, black, new Point(170, 470));




            //NOTE
            e.Graphics.DrawString("NOTE:", labelinfo, black, new Point(400, 230));
            e.Graphics.DrawString(info[ctr].Urinalysis.Note, labelinfo_bold, black, new Point(445, 230));
            //RBC
            e.Graphics.DrawString("RBC:", labelinfo, black, new Point(400, 250));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.RBC))
                e.Graphics.DrawString(info[ctr].Urinalysis.RBC + " /hpf", labelinfo_bold, black, new Point(580, 250));
            //WBC
            e.Graphics.DrawString("WBC:", labelinfo, black, new Point(400, 270));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.WBC))
                e.Graphics.DrawString(info[ctr].Urinalysis.WBC + " /hpf", labelinfo_bold, black, new Point(580, 270));
            //EPITHELIAL CELLS
            e.Graphics.DrawString("EPITHELIAL CELLS:", labelinfo, black, new Point(400, 290));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.Epithelial_Cells))
                e.Graphics.DrawString(info[ctr].Urinalysis.Epithelial_Cells + " /hpf", labelinfo_bold, black, new Point(580, 290));
            //BACTERIA
            e.Graphics.DrawString("BACTERIA:", labelinfo, black, new Point(400, 310));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.Bacteria))
                e.Graphics.DrawString(info[ctr].Urinalysis.Bacteria + " /hpf", labelinfo_bold, black, new Point(580, 310));
            //MUCUS THREAD
            e.Graphics.DrawString("MUCUS THREAD:", labelinfo, black, new Point(400, 330));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.Mucus_Thread))
                e.Graphics.DrawString(info[ctr].Urinalysis.Mucus_Thread + " /hpf", labelinfo_bold, black, new Point(580, 330));
            //A URATES/P04
            e.Graphics.DrawString("A.URATES/PO4:", labelinfo, black, new Point(400, 350));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.A_Urates))
                e.Graphics.DrawString(info[ctr].Urinalysis.A_Urates + " /lpf", labelinfo_bold, black, new Point(580, 350));
            //URIC ACID
            e.Graphics.DrawString("URIC ACID:", labelinfo, black, new Point(400, 370));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.Uric_Acid))
                e.Graphics.DrawString(info[ctr].Urinalysis.Uric_Acid + " /hpf", labelinfo_bold, black, new Point(580, 370));
            //CALCIUM OXALATE
            e.Graphics.DrawString("CALCIUM OXALATE:", labelinfo, black, new Point(400, 390));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.Calcium_Oxalate))
                e.Graphics.DrawString(info[ctr].Urinalysis.Calcium_Oxalate + " /hpf", labelinfo_bold, black, new Point(580, 390));
            //FINE GRANULAR CAST
            e.Graphics.DrawString("FINE GRANULAR CAST:", labelinfo, black, new Point(400, 410));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.Fine_Granular_Cast))
                e.Graphics.DrawString(info[ctr].Urinalysis.Fine_Granular_Cast + " /lpf", labelinfo_bold, black, new Point(580, 410));
            //COARSE GRANULAR CAST
            e.Graphics.DrawString("COARSE GRANULAR CAST:", labelinfo, black, new Point(400, 430));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.Coarse_Granular_Cast))
                e.Graphics.DrawString(info[ctr].Urinalysis.Coarse_Granular_Cast + " /lpf", labelinfo_bold, black, new Point(585, 430));
            //WBC CAST
            e.Graphics.DrawString("WBC CAST:", labelinfo, black, new Point(400, 450));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.WBC_Cast))
                e.Graphics.DrawString(info[ctr].Urinalysis.WBC_Cast + " /lpf", labelinfo_bold, black, new Point(580, 450));
            //RBC CAST
            e.Graphics.DrawString("RBC CAST:", labelinfo, black, new Point(400, 470));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.RBC_Cast))
                e.Graphics.DrawString(info[ctr].Urinalysis.RBC_Cast + " /lpf", labelinfo_bold, black, new Point(580, 470));
            //OTHERS
            e.Graphics.DrawString("OTHERS:", labelinfo, black, new Point(400, 490));
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.Others))
            {
                e.Graphics.DrawString(info[ctr].Urinalysis.Others, labelinfo_bold, black, new RectangleF(580,490,300,60), new StringFormat() { Alignment = StringAlignment.Near});
            }
                //e.Graphics.DrawString(info[ctr].Urinalysis.Others, labelinfo_bold, black, new Point(580, 490));
            

            //REMARKS
            if (!String.IsNullOrWhiteSpace(info[ctr].Urinalysis.Remarks))
            {
                e.Graphics.DrawString("REMARKS:", labelinfo_Italic, black, new Point(47, 510));
                e.Graphics.DrawString(info[ctr].Urinalysis.Remarks, labelinfo_bold, black, new RectangleF(new PointF(112, 510), new SizeF(600, 100)));
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
                e.Graphics.FillRectangle(Brushes.SkyBlue, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawString("PAP SMEAR", titlebarfont, Brushes.White, new RectangleF(new Point(20, 190), new SizeF(776, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //draw background logo
                e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, new Size(776, 300)), new RectangleF(new Point(20, 210), new SizeF(776, 300)));

                //Body(e);


                string body = info[ctr].PapSmear.System + Environment.NewLine + Environment.NewLine +
                              "Specimen Type:" + Environment.NewLine +
                              info[ctr].PapSmear.SpecimenType + Environment.NewLine + Environment.NewLine +
                              "ADEQUACY OF SPECIMEN:" + Environment.NewLine +
                              info[ctr].PapSmear.AdequacyOfSpecimen + Environment.NewLine + Environment.NewLine +
                              "GENERAL CATEGORIZATION:" + Environment.NewLine +
                              info[ctr].PapSmear.GeneralCategorization + Environment.NewLine + Environment.NewLine +
                              "INTERPRETATION / RESULT" + Environment.NewLine +
                              info[ctr].PapSmear.Interpretation + Environment.NewLine + Environment.NewLine +
                              "Interpreted by: " + info[ctr].PapSmear.InterpretedBy + Environment.NewLine + "\t\t" +
                              info[ctr].PapSmear.InterpretedByTitle;

                e.Graphics.DrawString(body, labelinfo, black, new Point(36, 230));

                //signatories
                if (!String.IsNullOrWhiteSpace(info[ctr].PapSmear.Medtech))
                {
                    e.Graphics.DrawString(info[ctr].PapSmear.Medtech, radfont, black, new RectangleF(new Point(20, 996), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Medical Technologist", radlabelfont, black, new RectangleF(new Point(20, 1011), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                }
                if (!String.IsNullOrWhiteSpace(info[ctr].PapSmear.Pathologist))
                {
                    e.Graphics.DrawString(info[ctr].PapSmear.Pathologist, radfont, black, new RectangleF(new Point(408, 996), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Pathologist", radlabelfont, black, new RectangleF(new Point(408, 1011), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                }

                e.Graphics.DrawString("Printed By: " + info[ctr].PapSmear.PrintedBy, printedbyfont, black, new Point(20, 1040));


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

