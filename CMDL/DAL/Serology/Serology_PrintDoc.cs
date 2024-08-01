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
    class Serology_PrintDoc
    {
        PrintDocument doc = new PrintDocument();
        PrintPreviewDialog prev = new PrintPreviewDialog();
        CyberPrintPreview cprev = new CyberPrintPreview();


        public List<LabClientInfo> info;

        //font
        private Font labelinfo = new Font("Arial", 9.75F);
        private Font labelinfo_Italic = new Font("Arial", 8F,FontStyle.Italic);
        private Font labelinfo_bold = new Font("Arial", 9.75F, FontStyle.Bold);
        private Font titlebarfont = new Font("Arial", 11.5F, FontStyle.Bold);
        private Font printedbyfont = new Font("Arial", 6F);
        private Brush black = Brushes.Black;

        private Font radfont = new Font("Arial", 9F);
        private Font radlabelfont = new Font("Arial", 8F);

        private int ctr = 0;
        private string key = "";
        

        public Serology_PrintDoc()
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

        private bool CheckIfEmpty(string res)
        {
            if (String.IsNullOrWhiteSpace(res))
                return false;
            else if (res == "NOT DONE")
                return false;
            else if (res == "NONE")
                return false;
            else
                return true;
        }

        public void Preview(List<LabClientInfo> info,string key)
        {
            this.info = info;
            this.key = key;
            ctr = 0;
            prev.Document = doc;
            prev.ShowDialog();
        }

        public void CyberPreview(List<LabClientInfo> info, string key)
        {
            this.info = info;
            this.key = key;
            ctr = 0;
            cprev.Document = doc;
            cprev.ShowDialog();
        }

        private void BloodTest(PrintPageEventArgs e)
        {
            //Label
            e.Graphics.DrawString("EXAMINATION", labelinfo_Italic, black, new RectangleF(new PointF(20, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center});
            e.Graphics.DrawString("SPECIMEN", labelinfo_Italic, black, new RectangleF(new PointF(131, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("RESULT", labelinfo_Italic, black, new RectangleF(new PointF(242, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("TEST KIT / LOT NO / EXPIRY", labelinfo_Italic, black, new RectangleF(new PointF(353, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("REMARKS", labelinfo_Italic, black, new RectangleF(new PointF(575, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });

            int yPos = 250;

            //ANTIHIV 1/2
            if (CheckIfEmpty(info[ctr].Serology[key].AntiHIV_results))
            {
                e.Graphics.DrawString("ANTI-HIV 1/2", labelinfo_bold, black, new RectangleF(new PointF(20, yPos), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString("SERUM", labelinfo_bold, black, new RectangleF(new PointF(131, yPos), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(info[ctr].Serology[key].AntiHIV_results, labelinfo_bold, black, new RectangleF(new PointF(242, yPos), new SizeF(111, 60)), new StringFormat() { Alignment = StringAlignment.Center });

                if (CheckIfEmpty(info[ctr].Serology[key].AntiHIV_Kit))
                {
                    e.Graphics.DrawString(info[ctr].Serology[key].AntiHIV_Kit + " / " +
                                          info[ctr].Serology[key].AntiHIV_LotNo + " / " +
                                          info[ctr].Serology[key].AntiHIV_Exp, labelinfo_bold, black, new RectangleF(new PointF(353, yPos), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
                }

                e.Graphics.DrawString(info[ctr].Serology[key].AntiHIV_Remarks, labelinfo_bold, black, new RectangleF(new PointF(575, yPos), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });

                if (!CheckIfEmpty(info[ctr].Serology[key].AntiHIV_Remarks))
                    yPos += 40;
                else
                    yPos += 100;
            }


            //HBsAg
            if (CheckIfEmpty(info[ctr].Serology[key].HBsAg_results))
            {
                e.Graphics.DrawString("HBsAg", labelinfo_bold, black, new RectangleF(new PointF(20, yPos), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString("SERUM", labelinfo_bold, black, new RectangleF(new PointF(131, yPos), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(info[ctr].Serology[key].HBsAg_results, labelinfo_bold, black, new RectangleF(new PointF(242, yPos), new SizeF(111, 60)), new StringFormat() { Alignment = StringAlignment.Center });

                if (CheckIfEmpty(info[ctr].Serology[key].HBsAg_Kit))
                {
                    e.Graphics.DrawString(info[ctr].Serology[key].HBsAg_Kit + " / " +
                                          info[ctr].Serology[key].HBsAg_LotNo + " / " +
                                          info[ctr].Serology[key].HBsAg_Exp, labelinfo_bold, black, new RectangleF(new PointF(353, yPos), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
                }

                e.Graphics.DrawString(info[ctr].Serology[key].HBsAg_Remarks, labelinfo_bold, black, new RectangleF(new PointF(575, yPos), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });

                if (!CheckIfEmpty(info[ctr].Serology[key].HBsAg_Remarks))
                    yPos += 40;
                else
                    yPos += 100;
            }

            //SYPHILIS
            if (CheckIfEmpty(info[ctr].Serology[key].AntiTP_results))
            {
                e.Graphics.DrawString("Syphilis", labelinfo_bold, black, new RectangleF(new PointF(20, yPos), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString("SERUM", labelinfo_bold, black, new RectangleF(new PointF(131, yPos), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(info[ctr].Serology[key].AntiTP_results, labelinfo_bold, black, new RectangleF(new PointF(242, yPos), new SizeF(111, 60)), new StringFormat() { Alignment = StringAlignment.Center });

                if (CheckIfEmpty(info[ctr].Serology[key].AntiTP_Kit))
                {
                    e.Graphics.DrawString(info[ctr].Serology[key].AntiTP_Kit + " / " +
                                          info[ctr].Serology[key].AntiTP_LotNo + " / " +
                                          info[ctr].Serology[key].AntiTP_Exp, labelinfo_bold, black, new RectangleF(new PointF(353, yPos), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
                }

                e.Graphics.DrawString(info[ctr].Serology[key].AntiTP_Remarks, labelinfo_bold, black, new RectangleF(new PointF(575, yPos), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });

                if (!CheckIfEmpty(info[ctr].Serology[key].AntiTP_Remarks))
                    yPos += 40;
                else
                    yPos += 100;
            }

            //HPE C
            if (CheckIfEmpty(info[ctr].Serology[key].AntiHCV_results))
            {
                e.Graphics.DrawString("Anti HCV", labelinfo_bold, black, new RectangleF(new PointF(20, yPos), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString("SERUM", labelinfo_bold, black, new RectangleF(new PointF(131, yPos), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                e.Graphics.DrawString(info[ctr].Serology[key].AntiHCV_results, labelinfo_bold, black, new RectangleF(new PointF(242, yPos), new SizeF(111, 60)), new StringFormat() { Alignment = StringAlignment.Center });

                if (CheckIfEmpty(info[ctr].Serology[key].AntiHCV_Kit))
                {
                    e.Graphics.DrawString(info[ctr].Serology[key].AntiHCV_Kit + " / " +
                                          info[ctr].Serology[key].AntiHCV_LotNo + " / " +
                                          info[ctr].Serology[key].AntiHCV_Exp, labelinfo_bold, black, new RectangleF(new PointF(353, yPos), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
                }
                
                e.Graphics.DrawString(info[ctr].Serology[key].AntiHCV_Remarks, labelinfo_bold, black, new RectangleF(new PointF(575, yPos), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });
            }
        }

        private void HepA(PrintPageEventArgs e)
        {
            //Label
            e.Graphics.DrawString("EXAMINATION", labelinfo_Italic, black, new RectangleF(new PointF(20, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SPECIMEN", labelinfo_Italic, black, new RectangleF(new PointF(131, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("RESULT", labelinfo_Italic, black, new RectangleF(new PointF(242, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("TEST KIT / LOT NO / EXPIRY", labelinfo_Italic, black, new RectangleF(new PointF(353, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("REMARKS", labelinfo_Italic, black, new RectangleF(new PointF(575, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });


            //ANTIHIV 1/2
            e.Graphics.DrawString("ANTI-HAV IgM RAPID TEST", labelinfo_bold, black, new RectangleF(new PointF(20, 250), new SizeF(111, 40)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SERUM", labelinfo_bold, black, new RectangleF(new PointF(131, 250), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(info[ctr].Serology[key].AntiHIV_results, labelinfo_bold, black, new RectangleF(new PointF(242, 250), new SizeF(111, 60)), new StringFormat() { Alignment = StringAlignment.Center });

            if (CheckIfEmpty(info[ctr].Serology[key].AntiHIV_Kit))
            {
                e.Graphics.DrawString(info[ctr].Serology[key].AntiHIV_Kit + " / " +
                                      info[ctr].Serology[key].AntiHIV_LotNo + " / " +
                                      info[ctr].Serology[key].AntiHIV_Exp, labelinfo_bold, black, new RectangleF(new PointF(353, 250), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            }

            e.Graphics.DrawString(info[ctr].Serology[key].AntiHIV_Remarks, labelinfo_bold, black, new RectangleF(new PointF(575, 250), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });

        }

        private void HIV(PrintPageEventArgs e)
        {
            //Label
            e.Graphics.DrawString("EXAMINATION", labelinfo_Italic, black, new RectangleF(new PointF(20, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SPECIMEN", labelinfo_Italic, black, new RectangleF(new PointF(131, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("RESULT", labelinfo_Italic, black, new RectangleF(new PointF(242, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("TEST KIT / LOT NO / EXPIRY", labelinfo_Italic, black, new RectangleF(new PointF(353, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("REMARKS", labelinfo_Italic, black, new RectangleF(new PointF(575, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });


            //ANTIHIV 1/2
            e.Graphics.DrawString("ANTI-HIV 1/2", labelinfo_bold, black, new RectangleF(new PointF(20, 250), new SizeF(111, 40)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SERUM", labelinfo_bold, black, new RectangleF(new PointF(131, 250), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(info[ctr].Serology[key].AntiHIV_results, labelinfo_bold, black, new RectangleF(new PointF(242, 250), new SizeF(111, 60)), new StringFormat() { Alignment = StringAlignment.Center });

            if (CheckIfEmpty(info[ctr].Serology[key].AntiHIV_Kit))
            {
                e.Graphics.DrawString(info[ctr].Serology[key].AntiHIV_Kit + " / " +
                                      info[ctr].Serology[key].AntiHIV_LotNo + " / " +
                                      info[ctr].Serology[key].AntiHIV_Exp, labelinfo_bold, black, new RectangleF(new PointF(353, 250), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            }
            e.Graphics.DrawString(info[ctr].Serology[key].AntiHIV_Remarks, labelinfo_bold, black, new RectangleF(new PointF(575, 250), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });

        }

        private void HepB(PrintPageEventArgs e)
        {
            //Label
            e.Graphics.DrawString("EXAMINATION", labelinfo_Italic, black, new RectangleF(new PointF(20, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SPECIMEN", labelinfo_Italic, black, new RectangleF(new PointF(131, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("RESULT", labelinfo_Italic, black, new RectangleF(new PointF(242, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("TEST KIT / LOT NO / EXPIRY", labelinfo_Italic, black, new RectangleF(new PointF(353, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("REMARKS", labelinfo_Italic, black, new RectangleF(new PointF(575, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });


            //ANTIHIV 1/2
            e.Graphics.DrawString("HBsAg", labelinfo_bold, black, new RectangleF(new PointF(20, 250), new SizeF(111, 40)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SERUM", labelinfo_bold, black, new RectangleF(new PointF(131, 250), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(info[ctr].Serology[key].HBsAg_results, labelinfo_bold, black, new RectangleF(new PointF(242, 250), new SizeF(111, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            if (CheckIfEmpty(info[ctr].Serology[key].HBsAg_Kit))
            {
                e.Graphics.DrawString(info[ctr].Serology[key].HBsAg_Kit + " / " +
                                      info[ctr].Serology[key].HBsAg_LotNo + " / " +
                                      info[ctr].Serology[key].HBsAg_Exp, labelinfo_bold, black, new RectangleF(new PointF(353, 250), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            }
            e.Graphics.DrawString(info[ctr].Serology[key].HBsAg_Remarks, labelinfo_bold, black, new RectangleF(new PointF(575, 250), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });

        }

        private void AntiHBS(PrintPageEventArgs e)
        {
            //Label
            e.Graphics.DrawString("EXAMINATION", labelinfo_Italic, black, new RectangleF(new PointF(20, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("RESULT", labelinfo_Italic, black, new RectangleF(new PointF(131, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("UNIT", labelinfo_Italic, black, new RectangleF(new PointF(242, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("REFERENCE", labelinfo_Italic, black, new RectangleF(new PointF(353, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("COMMENTS", labelinfo_Italic, black, new RectangleF(new PointF(575, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });


            //ANTIHIV 1/2
            e.Graphics.DrawString("Anti HBs", labelinfo_bold, black, new RectangleF(new PointF(20, 250), new SizeF(111, 40)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("> 1000.0", labelinfo_bold, black, new RectangleF(new PointF(131, 250), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("mlU/ml", labelinfo_bold, black, new RectangleF(new PointF(242, 250), new SizeF(111, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            if (CheckIfEmpty(info[ctr].Serology[key].HBsAg_Kit))
            {
                e.Graphics.DrawString("C.O.V. 10.00", labelinfo_bold, black, new RectangleF(new PointF(353, 250), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            }
            e.Graphics.DrawString(info[ctr].Serology[key].HBsAg_results, labelinfo_bold, black, new RectangleF(new PointF(575, 250), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });

        }

        private void AntiTP(PrintPageEventArgs e)
        {

            //Label
            e.Graphics.DrawString("EXAMINATION", labelinfo_Italic, black, new RectangleF(new PointF(20, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SPECIMEN", labelinfo_Italic, black, new RectangleF(new PointF(131, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("RESULT", labelinfo_Italic, black, new RectangleF(new PointF(242, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("TEST KIT / LOT NO / EXPIRY", labelinfo_Italic, black, new RectangleF(new PointF(353, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("REMARKS", labelinfo_Italic, black, new RectangleF(new PointF(575, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });


            //ANTIHIV 1/2
            e.Graphics.DrawString("Syphilis", labelinfo_bold, black, new RectangleF(new PointF(20, 250), new SizeF(111, 40)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SERUM", labelinfo_bold, black, new RectangleF(new PointF(131, 250), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(info[ctr].Serology[key].AntiTP_results, labelinfo_bold, black, new RectangleF(new PointF(242, 250), new SizeF(111, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            if (CheckIfEmpty(info[ctr].Serology[key].AntiTP_Kit))
            {
                e.Graphics.DrawString(info[ctr].Serology[key].AntiTP_Kit + " / " +
                                      info[ctr].Serology[key].AntiTP_LotNo + " / " +
                                      info[ctr].Serology[key].AntiTP_Exp, labelinfo_bold, black, new RectangleF(new PointF(353, 250), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            }
            e.Graphics.DrawString(info[ctr].Serology[key].AntiTP_Remarks, labelinfo_bold, black, new RectangleF(new PointF(575, 250), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });

        }

        private void RPR(PrintPageEventArgs e)
        {

            //Label
            e.Graphics.DrawString("EXAMINATION", labelinfo_Italic, black, new RectangleF(new PointF(20, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("RESULT", labelinfo_Italic, black, new RectangleF(new PointF(131, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("COMMENTS", labelinfo_Italic, black, new RectangleF(new PointF(242, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            //e.Graphics.DrawString("TEST KIT / LOT NO / EXPIRY", labelinfo_Italic, black, new RectangleF(new PointF(353, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            //e.Graphics.DrawString("REMARKS", labelinfo_Italic, black, new RectangleF(new PointF(575, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });


            //ANTIHIV 1/2
            //e.Graphics.DrawString("RPR w/ Dilution", labelinfo_bold, black, new RectangleF(new PointF(20, 250), new SizeF(111, 40)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("VDRL", labelinfo_bold, black, new RectangleF(new PointF(20, 250), new SizeF(111, 40)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(info[ctr].Serology[key].AntiTP_results, labelinfo_bold, black, new RectangleF(new PointF(131, 250), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(info[ctr].Serology[key].AntiTP_Remarks, labelinfo_bold, black, new RectangleF(new PointF(242, 250), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            //if (CheckIfEmpty(info[ctr].Serology[key].AntiTP_Kit))
            //{
            //    e.Graphics.DrawString(info[ctr].Serology[key].AntiTP_Kit + " / " +
            //                          info[ctr].Serology[key].AntiTP_LotNo + " / " +
            //                          info[ctr].Serology[key].AntiTP_Exp, labelinfo_bold, black, new RectangleF(new PointF(353, 250), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            //}
            //e.Graphics.DrawString(info[ctr].Serology[key].AntiTP_Remarks, labelinfo_bold, black, new RectangleF(new PointF(575, 250), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });

        }

        private void HepC(PrintPageEventArgs e)
        {

            //Label
            e.Graphics.DrawString("EXAMINATION", labelinfo_Italic, black, new RectangleF(new PointF(20, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SPECIMEN", labelinfo_Italic, black, new RectangleF(new PointF(131, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("RESULT", labelinfo_Italic, black, new RectangleF(new PointF(242, 230), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("TEST KIT / LOT NO / EXPIRY", labelinfo_Italic, black, new RectangleF(new PointF(353, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("REMARKS", labelinfo_Italic, black, new RectangleF(new PointF(575, 230), new SizeF(222, 20)), new StringFormat() { Alignment = StringAlignment.Center });


            //ANTIHIV 1/2
            e.Graphics.DrawString("Anti HCV", labelinfo_bold, black, new RectangleF(new PointF(20, 250), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString("SERUM", labelinfo_bold, black, new RectangleF(new PointF(131, 250), new SizeF(111, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(info[ctr].Serology[key].AntiHCV_results, labelinfo_bold, black, new RectangleF(new PointF(242, 250), new SizeF(111, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            
            if (CheckIfEmpty(info[ctr].Serology[key].AntiHCV_Kit))
            {
                e.Graphics.DrawString(info[ctr].Serology[key].AntiHCV_Kit + " / " +
                                      info[ctr].Serology[key].AntiHCV_LotNo + " / " +
                                      info[ctr].Serology[key].AntiHCV_Exp, labelinfo_bold, black, new RectangleF(new PointF(353, 250), new SizeF(222, 60)), new StringFormat() { Alignment = StringAlignment.Center });
            }
            e.Graphics.DrawString(info[ctr].Serology[key].AntiHCV_Remarks, labelinfo_bold, black, new RectangleF(new PointF(575, 250), new SizeF(222, 100)), new StringFormat() { Alignment = StringAlignment.Center });

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
                e.Graphics.DrawString(info[ctr].RequestingParty, labelinfo_bold, black,new RectangleF(new PointF(160,141),new SizeF(320,40)));
                //DATE
                e.Graphics.DrawString("Date:", labelinfo, black, new Point(489, 119));
                e.Graphics.DrawString(info[ctr].TimeIn, labelinfo_bold, black, new Point(526, 119));
                //AGE/SEX
                e.Graphics.DrawString("Age/Sex:", labelinfo, black, new Point(489, 141));
                e.Graphics.DrawString(info[ctr].Age + "/" + info[ctr].Sex, labelinfo_bold, black, new Point(548, 141));

                //Title bar
                e.Graphics.FillRectangle(Brushes.Red, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(20, 190, 776, 20));
                e.Graphics.DrawString("SEROLOGY", titlebarfont, Brushes.White, new RectangleF(new Point(20, 190), new SizeF(776, 20)), new StringFormat() { Alignment = StringAlignment.Center });

                //draw background logo
                e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, new Size(776, 300)), new RectangleF(new Point(20, 210), new SizeF(776, 300)));

                switch (key)
                {
                    case "BLOOD TEST": 
                        BloodTest(e);
                        break;
                    case "HEP A":
                        HepA(e);
                        break;
                    case "HIV":
                        HIV(e);
                        break;
                    case "HEP B":
                        HepB(e);
                        break;
                    case "RPR":
                    case "VDRL":
                        //AntiTP(e);
                        RPR(e);
                        break;
                    case "HEP C": 
                        HepC(e);
                        break;
                    case "ANTI-HBS":
                        AntiHBS(e);
                        break;
                    
                }

                ////signatories
                //if (!String.IsNullOrWhiteSpace(info[ctr].Serology[key].MedTech_1))
                //{
                //    e.Graphics.DrawString(info[ctr].Serology[key].MedTech_1, radfont, black, new RectangleF(new Point(20, 580), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                //    e.Graphics.DrawString("Medical Technologist", radlabelfont, black, new RectangleF(new Point(20, 595), new Size(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                //}
                //if (!String.IsNullOrWhiteSpace(info[ctr].Serology[key].Pathologist))
                //{
                //    e.Graphics.DrawString(info[ctr].Serology[key].Pathologist, radfont, black, new RectangleF(new Point(279, 580), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                //    e.Graphics.DrawString("Pathologist", radlabelfont, black, new RectangleF(new Point(279, 595), new Size(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                //}
                //if (!String.IsNullOrWhiteSpace(info[ctr].Serology[key].MedTech_2))
                //{
                //    e.Graphics.DrawString(info[ctr].Serology[key].MedTech_2, radfont, black, new RectangleF(new Point(538, 580), new SizeF(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                //    e.Graphics.DrawString("Medical Technologist", radlabelfont, black, new RectangleF(new Point(538, 595), new Size(259, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                //}



                //signatories
                if (!String.IsNullOrWhiteSpace(info[ctr].Serology[key].MedTech_1))
                {
                    e.Graphics.DrawString(info[ctr].Serology[key].MedTech_1, radfont, black, new RectangleF(new Point(20, 580), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Medical Technologist", radlabelfont, black, new RectangleF(new Point(20, 595), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                }
                if (!String.IsNullOrWhiteSpace(info[ctr].Serology[key].Pathologist))
                {
                    e.Graphics.DrawString(info[ctr].Serology[key].Pathologist, radfont, black, new RectangleF(new Point(408, 580), new SizeF(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                    e.Graphics.DrawString("Pathologist", radlabelfont, black, new RectangleF(new Point(408, 595), new Size(388, 20)), new StringFormat() { Alignment = StringAlignment.Center });
                }


                e.Graphics.DrawString("Printed By: " + info[ctr].Serology[key].PrintedBy, printedbyfont, black, new Point(20, 605));

                
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
