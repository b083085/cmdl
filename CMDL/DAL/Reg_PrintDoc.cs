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
    public struct Pages
    {
        bool firstpage;
        bool secondpage;
        bool thirdpage;
        bool fourthpage;

        int count;

        public Pages(bool value)
        {
            firstpage = value;
            secondpage = value;
            thirdpage = value;
            fourthpage = value;
            count = 1;
        }

        public bool First
        {
            set
            {
                firstpage = value;
            }
            get
            {
                return firstpage;
            }
        }

        public bool Second
        {
            set
            {
                secondpage = value;
            }
            get
            {
                return secondpage;
            }
        }

        public bool Third
        {
            set
            {
                thirdpage = value;
            }
            get
            {
                return thirdpage;
            }
        }

        public bool Fourth
        {
            set
            {
                fourthpage = value;
            }
            get
            {
                return fourthpage;
            }
        }

        public void All(bool value)
        {
            firstpage = value;
            secondpage = value;
            thirdpage = value;
            fourthpage = value;
        }

        public void One_Page()
        {
            firstpage = true;
            secondpage = false;
            thirdpage = false;
            fourthpage = false;
            count = 1;
        }

        public void Two_Pages()
        {
            firstpage = true;
            secondpage = true;
            thirdpage = false;
            fourthpage = false;
            count = 2;
        }

        public void Three_Pages()
        {
            firstpage = true;
            secondpage = true;
            thirdpage = true;
            fourthpage = false;
            count = 3;
        }

        public void Four_Pages()
        {
            All(true);
            count = 4;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }
    }
    
    public class Reg_PrintDoc:Reg_PrintDoc_Items
    {
        private PrintDocument doc = new PrintDocument();
        
        private List<XRayMarker> xray_marker = new List<XRayMarker>();

        public Pages page;

        private Font markerfont = new Font("Arial Black", 9F, FontStyle.Bold);
        private Brush black = Brushes.Black;
        private Brush blue = Brushes.Blue;

        private byte booltobyte;

        public Reg_PrintDoc()
        {
            doc.DefaultPageSettings.PaperSize = new PaperSize("Custom Size", 408, 528);
            //prev.UseAntiAlias = true;
            //prev.PrintPreviewControl.Columns = 3;
            //((Form)prev).WindowState = FormWindowState.Maximized;
            //((Form)prev).Size = new Size(600, 600);
            //((Form)prev).Text = "PRINT PREVIEW";

            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            doc.EndPrint += new PrintEventHandler(doc_EndPrint);

            page = new Pages(false);
        }

        private void Header(PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.Logo, new RectangleF(new Point(5, 10), new SizeF(50, 25)));

            e.Graphics.DrawString(Properties.Settings.Default.Company, new Font("Arial", 9F, FontStyle.Bold), Brushes.Black, new RectangleF(new Point(10, 10), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(Properties.Settings.Default.Company_Profile, new Font("Arial", 6.5F, FontStyle.Bold), Brushes.Black, new RectangleF(new Point(10, 21), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(Properties.Settings.Default.Company_Addr, new Font("Arial", 6.3F), Brushes.Black, new RectangleF(new Point(10, 29), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(Properties.Settings.Default.Company_TelNo, new Font("Arial", 6.3F), Brushes.Black, new RectangleF(new Point(10, 37), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });
        }

        private void StubSection(PrintPageEventArgs e,string title)
        {

            e.Graphics.DrawString("-" + title + "-", new Font("Arial", 9F, FontStyle.Bold), title == "LABORATORY STUB" ? blue:black, new RectangleF(new Point(10, 50), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Center });

            //Patient Info
            e.Graphics.DrawString("Date: ", new Font("Arial", 7F, FontStyle.Italic), black, new RectangleF(new Point(10, 71), new SizeF(280, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(Date_Registered.ToString(), new Font("Arial", 8.5F, FontStyle.Bold), title == "LABORATORY STUB" ? blue : black, new RectangleF(new Point(38, 70), new SizeF(280, 20)), new StringFormat() { Alignment = StringAlignment.Near });

            e.Graphics.DrawString("Name: ", new Font("Arial", 7F, FontStyle.Italic), black, new RectangleF(new Point(10, 86), new SizeF(280, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(LastName + ", " + FirstName + " " + MI + " " + Suffix, new Font("Arial", 8.5F, FontStyle.Bold), title == "LABORATORY STUB" ? blue : black, new RectangleF(new Point(43, 85), new SizeF(280, 20)), new StringFormat() { Alignment = StringAlignment.Near });

            e.Graphics.DrawString("Age/Gender: ", new Font("Arial", 7F, FontStyle.Italic), black, new RectangleF(new Point(10, 101), new SizeF(280, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(Age + "/" + Sex, new Font("Arial", 8.5F, FontStyle.Bold), title == "LABORATORY STUB" ? blue : black, new RectangleF(new Point(72, 100), new SizeF(280, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            //e.Graphics.DrawString(Age + "/" + Sex, new Font("Arial", 8.5F, FontStyle.Bold), title == "LABORATORY STUB" ? blue : black, new RectangleF(new Point(52, 100), new SizeF(280, 20)), new StringFormat() { Alignment = StringAlignment.Near });

            e.Graphics.DrawString("Address: ", new Font("Arial", 7F, FontStyle.Italic), black, new RectangleF(new Point(10, 116), new SizeF(280, 40)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(Address, new Font("Arial", 8.5F, FontStyle.Bold), title == "LABORATORY STUB" ? blue : black, new RectangleF(new Point(52, 115), new SizeF(220, 40)), new StringFormat() { Alignment = StringAlignment.Near });

            e.Graphics.DrawString("Requesting Party: ", new Font("Arial", 7F, FontStyle.Italic), black, new RectangleF(new Point(10, 146), new SizeF(280, 40)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(ReqParty, new Font("Arial", 8.5F, FontStyle.Bold), title == "LABORATORY STUB" ? blue : black, new RectangleF(new Point(90, 145), new SizeF(180, 40)), new StringFormat() { Alignment = StringAlignment.Near });

            //Photo
            //e.Graphics.DrawImage(Edit.Resize(Photo, new Size(100, 100)), new RectangleF(new Point(290, 70), new SizeF(100, 100)));
            e.Graphics.DrawImage(Photo, new RectangleF(new Point(290, 70), new SizeF(100, 100)));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(290, 70, 100, 100));
            e.Graphics.DrawString("CMDL-" + ControlNo, new Font("Arial", 6.5F), Brushes.Red, new RectangleF(new Point(290, 170), new SizeF(100, 20)), new StringFormat() { Alignment = StringAlignment.Center });

            //Examination
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(10, 190, 388, 15));
            e.Graphics.DrawString("TEST", new Font("Arial", 7F, FontStyle.Bold), title == "LABORATORY STUB" ? blue : black, new RectangleF(new Point(20, 192), new SizeF(400, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            if(title == "CLAIM STUB")
            e.Graphics.DrawString("PRICE", new Font("Arial", 7F, FontStyle.Bold), black, new RectangleF(new Point(290, 192), new SizeF(118, 20)), new StringFormat() { Alignment = StringAlignment.Center });


            //background logo
            e.Graphics.DrawImage(Edit.Resize(Properties.Resources.LogoTransparent, new Size(388, 200)), new RectangleF(new Point(10, 205), new SizeF(388, 200)));

            
            if(title == "LABORATORY STUB")
                e.Graphics.DrawString(DrawStringLab(), new Font("Arial", 8.5F), blue, new RectangleF(new Point(20, 212), new SizeF(280, 200)), new StringFormat() { Alignment = StringAlignment.Near });
            else if (title == "CLAIM STUB")
            {
                e.Graphics.DrawString(DrawStringExam(Exam), new Font("Arial", 8.5F), black, new RectangleF(new Point(20, 212), new SizeF(280, 200)), new StringFormat() { Alignment = StringAlignment.Near });
                e.Graphics.DrawString(DrawStringPrice(Price), new Font("Arial", 8.5F, FontStyle.Bold), black, new RectangleF(new Point(290, 212), new SizeF(118, 200)), new StringFormat() { Alignment = StringAlignment.Center });

                //Total,AmtPaid,Balance and Change
                e.Graphics.DrawLine(Pens.Black, new Point(290, 372), new Point(398, 372));
                e.Graphics.DrawString("Total: " + string.Format("{0:0.00}", Total), new Font("Arial", 8.5F), black, new RectangleF(new Point(290, 382), new SizeF(118, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                e.Graphics.DrawString("Amt. Paid: " + string.Format("{0:0.00}", AmountPaid), new Font("Arial", 8.5F, FontStyle.Bold), black, new RectangleF(new Point(290, 397), new SizeF(118, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                e.Graphics.DrawString(Balance == 0 ? ("Change: " + string.Format("{0:0.00}", Change)) : ("Balance: " + string.Format("{0:0.00}", Balance)), new Font("Arial", 8.5F), black, new RectangleF(new Point(290, 412), new SizeF(118, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            }
            else if(title == "RECOPY STUB")
                e.Graphics.DrawString(DrawStringRecopy(), new Font("Arial", 7F), blue, new RectangleF(new Point(20, 212), new SizeF(280, 200)), new StringFormat() { Alignment = StringAlignment.Near });

        }

        private string DrawStringExam(string exam)
        {
            string[] testList = exam.Split(',');
            string test = string.Empty;

            foreach (var t in testList)
                test += t + Environment.NewLine;

            return test;
        }

        private string DrawStringPrice(string price)
        {
            string[] priceList = price.Split(',');
            string subPrice = string.Empty;

            foreach (var p in priceList)
                subPrice += p + Environment.NewLine;

            return subPrice;
        }

        private string DrawStringLab()
        {
            string lab = string.Empty;

            foreach (DataRow d in TbSingle.Rows)
            {
                if (Convert.ToString(d["type"]) == "LAB")
                {
                    if (Exam.Contains(Convert.ToString(d["test"])))
                    {
                        lab += Convert.ToString(d["test"]) + Environment.NewLine;
                    }
                }
            }

            return lab;
        }

        private string DrawStringRecopy()
        {
            string recopy = "";
            foreach (DataRow d in TbSingle.Rows)
            {
                if (Convert.ToString(d["type"]) == "RECOPY")
                {
                    if (Exam.Contains(Convert.ToString(d["test"])))
                    {
                        recopy += Convert.ToString(d["test"]) + Environment.NewLine;
                    }
                }
            }

            return recopy;
        }

        private void ParseXRayTest()
        {
            xray_marker.Clear();
            foreach (DataRow d in TbSingle.Rows)
            {
                if (Convert.ToString(d["type"]).Contains("XRAY"))
                {
                    if (Exam.Contains(Convert.ToString(d["test"])))
                    {
                        xray_marker.Add(new XRayMarker() { Test = Convert.ToString(d["test"]), Type = Convert.ToString(d["type"]), Marker = Convert.ToString(d["marker"])});
                    }
                }
            }
        }

        private string ParseNeuroTest()
        {
            foreach (DataRow d in TbSingle.Rows)
            {
                if (Convert.ToString(d["type"]) == "NEURO")
                {
                    if (Exam.Contains(Convert.ToString(d["test"])))
                    {
                        return Convert.ToString(d["marker"]);
                    }
                }
            }

            return "NEURO ";
        }

        private void NeuroMarker(PrintPageEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Brushes.Black, 1F), new Point(0, 432), new Point(408, 432));
            e.Graphics.DrawString("CYBER MEDICAL & DIAGNOSTIC LABORATORY", markerfont, blue, new RectangleF(new Point(5, 440), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Date: " + Date_Registered.ToString() + "\t" + " No: " + ControlNo, markerfont, blue, new RectangleF(new Point(5, 455), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Name: " + LastName + ", " + FirstName + " " + MI + " " + Suffix, markerfont, blue, new RectangleF(new Point(5, 470), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Age/Sex: " + Age + "/" + Sex, markerfont, blue, new RectangleF(new Point(5, 485), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Exam: " + ParseNeuroTest(), markerfont, blue, new RectangleF(new Point(5, 500), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawImage(Properties.Resources.Logo, new RectangleF(new Point(270, 485), new SizeF(60, 30)));
            //e.Graphics.DrawImage(Edit.Resize(Properties.Resources.Logo, new Size(60, 30)), new RectangleF(new Point(270, 485), new SizeF(60, 30)));
        }

        private void SingleXRayMarker(PrintPageEventArgs e)
        {
            foreach (XRayMarker x in xray_marker)
            {
                if(x.Type == "XRAY1")
                {
                    e.Graphics.DrawLine(new Pen(Brushes.Black, 1F), new Point(0, 432), new Point(408, 432));
                    e.Graphics.DrawLine(new Pen(Brushes.Black, 1F), new Point(0, 439), new Point(408, 439));
                    e.Graphics.DrawString("CYBER MEDICAL & DIAGNOSTIC LABORATORY", markerfont, black, new RectangleF(new Point(5, 440), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawString("Date: " + Date_Registered.ToString() + "\t" + " No: " + ControlNo, markerfont, black, new RectangleF(new Point(5, 455), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawString("Name: " + LastName + ", " + FirstName + " " + MI + " " + Suffix, markerfont, black, new RectangleF(new Point(5, 470), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawString("Age/Sex: " + Age + "/" + Sex, markerfont, black, new RectangleF(new Point(5, 485), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawString("Exam: " + x.Marker, markerfont, black, new RectangleF(new Point(5, 500), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawImage(Properties.Resources.Logo, new RectangleF(new Point(270, 485), new SizeF(60, 30)));
                    //e.Graphics.DrawImage(Edit.Resize(Properties.Resources.Logo, new Size(60, 30)), new RectangleF(new Point(270, 485), new SizeF(60, 30)));
                    break;
                }
            }

        }

        private void MultipleXRayMarker(PrintPageEventArgs e)
        {
            int line_ypos = 2, cmdl_ypos = 10, date_ypos = 25, name_ypos = 40, agesex_ypos = 55, exam_ypos = 70, logo_ypos = 55;

            //add 96

            foreach (XRayMarker x in xray_marker)
            {
                if (x.Type == "XRAY2")
                {
                    e.Graphics.DrawLine(new Pen(Brushes.Black, 1F), new Point(0, line_ypos), new Point(408, line_ypos));
                    e.Graphics.DrawLine(new Pen(Brushes.Black, 1F), new Point(0, line_ypos + 7), new Point(408, line_ypos + 7));
                    e.Graphics.DrawString("CYBER MEDICAL & DIAGNOSTIC LABORATORY", markerfont, black, new RectangleF(new Point(5, cmdl_ypos), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawString("Date: " + Date_Registered.ToString() + "\t" + " No: " + ControlNo, markerfont, black, new RectangleF(new Point(5, date_ypos), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawString("Name: " + LastName + ", " + FirstName + " " + MI + " " + Suffix, markerfont, black, new RectangleF(new Point(5, name_ypos), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawString("Age/Sex: " + Age + "/" + Sex, markerfont, black, new RectangleF(new Point(5, agesex_ypos), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawString("Exam: " + x.Marker, markerfont, black, new RectangleF(new Point(5, exam_ypos), new SizeF(408, 20)), new StringFormat() { Alignment = StringAlignment.Near });
                    e.Graphics.DrawImage(Properties.Resources.Logo, new RectangleF(new Point(270, logo_ypos), new SizeF(60, 30)));
                    //e.Graphics.DrawImage(Edit.Resize(Properties.Resources.Logo, new Size(60, 30)), new RectangleF(new Point(270, logo_ypos), new SizeF(60, 30)));

                    line_ypos += 96;
                    cmdl_ypos += 96;
                    date_ypos += 96;
                    name_ypos += 96;
                    agesex_ypos += 96;
                    exam_ypos += 96;
                    logo_ypos += 96;
                }
            }
        }

        private bool IsNeuro()
        {
            if (Exam_Type.Contains("NEURO"))
                return true;
            else
                return false;
        }

        private bool IsXRay1()
        {
            if (Exam_Type.Contains("XRAY1"))
                return true;
            else
                return false;
        }

        private bool IsXRay2()
        {
            if (Exam_Type.Contains("XRAY2"))
                return true;
            else
                return false;
        }

        private bool IsLab()
        {
            if (Exam_Type.Contains("LAB"))
                return true;
            else
                return false;
        }

        private bool IsRecopy()
        {
            if (Exam_Type.Contains("RECOPY"))
                return true;
            else
                return false;
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            switch(Convert.ToInt32(booltobyte))
            {
                case 1: if (page.First)//lab only
                        {
                            Header(e);
                            StubSection(e,"CLAIM STUB");
                            page.First = false;
                            e.HasMorePages = page.Second;
                        }
                            else if (page.Second)
                            {
                                Header(e);
                                StubSection(e, "LABORATORY STUB");
                                page.Second = false;
                                e.HasMorePages = false;
                            }
                            break;

                case 2: if (page.First)//neuro only
                        {
                            Header(e);
                            StubSection(e, "CLAIM STUB");
                            NeuroMarker(e);
                            page.First = false;
                            e.HasMorePages = false;
                        }
                        break;

                case 3: if (page.First)//neuro and lab
                        {
                            Header(e);
                            StubSection(e, "CLAIM STUB");
                            NeuroMarker(e);
                            page.First = false;
                            e.HasMorePages = page.Second;
                        }
                        else if (page.Second)
                        {
                            Header(e);
                            StubSection(e, "LABORATORY STUB");
                            page.Second = false;
                            e.HasMorePages = false;
                        }
                        break;
                case 4: if (page.First)//xray2 only
                        {
                            Header(e);
                            StubSection(e, "CLAIM STUB");
                            page.First = false;
                            e.HasMorePages = page.Second;
                        }
                        else if (page.Second)
                        {
                            MultipleXRayMarker(e);
                            page.Second = false;
                            e.HasMorePages = false;
                        }
                        break;
                case 5: if (page.First)//xray2 and lab
                        {
                            Header(e);
                            StubSection(e, "CLAIM STUB");
                            page.First = false;
                            e.HasMorePages = page.Second;
                        }
                        else if (page.Second)
                        {
                            Header(e);
                            StubSection(e, "LABORATORY STUB");
                            page.Second = false;
                            e.HasMorePages = page.Third;
                        }
                        else if (page.Third)
                        {
                            MultipleXRayMarker(e);
                            page.Third = false;
                            e.HasMorePages = false;
                        }
                        break;
                case 6: if (page.First)//xray2 and neuro
                        {
                            Header(e);
                            StubSection(e, "CLAIM STUB");
                            NeuroMarker(e);
                            page.First = false;
                            e.HasMorePages = page.Second;
                        }
                        else if (page.Second)
                        {
                            MultipleXRayMarker(e);
                            page.Second = false;
                            e.HasMorePages = false;
                        }
                        break;
                case 7: if (page.First)//xray2,neuro and lab
                        {
                            Header(e);
                            StubSection(e, "CLAIM STUB");
                            NeuroMarker(e);
                            page.First = false;
                            e.HasMorePages = page.Second;
                        }
                        else if (page.Second)
                        {
                            Header(e);
                            StubSection(e, "LABORATORY STUB");
                            page.Second = false;
                            e.HasMorePages = page.Third;
                        }
                        else if (page.Third)
                        {
                            MultipleXRayMarker(e);
                            page.Third = false;
                            e.HasMorePages = false;
                        }
                        break;
                case 8: if (page.First)//xray1
                        {
                            Header(e);
                            StubSection(e, "CLAIM STUB");
                            SingleXRayMarker(e);
                            page.First = false;
                            e.HasMorePages = false;
                        }
                    break;
                case 9: if (page.First)//xray1 and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        page.Second = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 10: if (page.First)//xray1 and neuro
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        NeuroMarker(e);
                        page.Second = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 11: if (page.First)//xray1,neuro and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        NeuroMarker(e);
                        page.Second = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 12: if (page.First)//xray1 and xray2
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        MultipleXRayMarker(e);
                        page.Second = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 13: if (page.First)//xray1,xray2 and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        MultipleXRayMarker(e);
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 14: if (page.First)//xray1,xray2 and neuro
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        NeuroMarker(e);
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        MultipleXRayMarker(e);
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 15: if (page.First)//xray1,xray2,neuro and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        NeuroMarker(e);
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        MultipleXRayMarker(e);
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 16: if (page.First)//recopy
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        page.Second = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 17: if (page.First)//recopy and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 18: if (page.First)//recopy and neuro
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        NeuroMarker(e);
                        page.Second = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 19: if (page.First)//recopy,neuro and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        NeuroMarker(e);
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 20: if (page.First)//recopy and xray2
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        MultipleXRayMarker(e);
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 21: if (page.First)//recopy,xray2 and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        page.Third = false;
                        e.HasMorePages = page.Fourth;
                    }
                    else if (page.Fourth)
                    {
                        MultipleXRayMarker(e);
                        page.Fourth = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 22: if (page.First)//recopy,xray2 and neuro
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        NeuroMarker(e);
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 23: if (page.First)//recopy,xray2,neuro and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        NeuroMarker(e);
                        page.Third = false;
                        e.HasMorePages = page.Fourth;
                    }
                    else if (page.Fourth)
                    {
                        MultipleXRayMarker(e);
                        page.Fourth = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 24: if (page.First)//recopy and xray1
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        page.Second = false;
                        e.HasMorePages = false;
                    } 
                    break;
                case 25: if (page.First)//recopy,xray1 and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 26: if (page.First)//recopy,xray1 and neuro
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        NeuroMarker(e);
                        page.Second = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 27: if (page.First)//recopy,xray1,neuro and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        NeuroMarker(e);
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 28: if (page.First)//recopy,xray1 and xray2
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        MultipleXRayMarker(e);
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 29: if (page.First)//recopy,xray1,xray2 and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        page.Third = false;
                        e.HasMorePages = page.Fourth;
                    }
                    else if (page.Fourth)
                    {
                        MultipleXRayMarker(e);
                        page.Fourth = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 30: if (page.First)//recopy,xray1,xray2 and neuro
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        NeuroMarker(e);
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        MultipleXRayMarker(e);
                        page.Third = false;
                        e.HasMorePages = false;
                    }
                    break;
                case 31: if (page.First)//recopy,xray1,xray2,neuro and lab
                    {
                        Header(e);
                        StubSection(e, "CLAIM STUB");
                        SingleXRayMarker(e);
                        page.First = false;
                        e.HasMorePages = page.Second;
                    }
                    else if (page.Second)
                    {
                        Header(e);
                        StubSection(e, "RECOPY STUB");
                        NeuroMarker(e);
                        page.Second = false;
                        e.HasMorePages = page.Third;
                    }
                    else if (page.Third)
                    {
                        Header(e);
                        StubSection(e, "LABORATORY STUB");
                        page.Third = false;
                        e.HasMorePages = page.Fourth;
                    }
                    else if (page.Fourth)
                    {
                        MultipleXRayMarker(e);
                        page.Fourth = false;
                        e.HasMorePages = false;
                    }
                    break;
            }
            
        }

        void doc_EndPrint(object sender, PrintEventArgs e)
        {
            page.All(false);
            ParseXRayTest();
        }

        public PrintDocument Document()
        {
            page.All(false);

            booltobyte = Convert.ToByte((Convert.ToByte(IsRecopy()) << 4) | (Convert.ToByte(IsXRay1()) << 3) | (Convert.ToByte(IsXRay2()) << 2) | (Convert.ToByte(IsNeuro()) << 1) | (Convert.ToByte(IsLab())));

            SetNoOfPages();

            ParseXRayTest();
            return doc;
        }

        public void FinalPrint(PrinterSettings settings)
        {
            page.All(false);

            booltobyte = Convert.ToByte((Convert.ToByte(IsRecopy()) << 4) | (Convert.ToByte(IsXRay1()) << 3) | (Convert.ToByte(IsXRay2()) << 2) | (Convert.ToByte(IsNeuro()) << 1) | (Convert.ToByte(IsLab())));

            if (settings.PrintRange == PrintRange.AllPages)
            {
                SetNoOfPages();
            }
            else if (settings.PrintRange == PrintRange.SomePages)
            {
                for (int i = settings.FromPage; i <= settings.ToPage; i++)
                    SelectedPages(i);
            }

            ParseXRayTest();
            doc.Print();
        }

        private void SelectedPages(int value)
        {
            switch (value)
            {
                case 1: page.First = true;
                    break;
                case 2: page.Second = true;
                    break;
                case 3: page.Third = true;
                    break;
                case 4: page.Fourth = true;
                    break;
            }
        }

        private void SetNoOfPages()
        {
            switch (Convert.ToInt32(booltobyte))
            {
                case 1: page.Two_Pages();
                    break;
                case 2: page.One_Page();
                    break;
                case 3: page.Two_Pages();
                    break;
                case 4: page.Two_Pages();
                    break;
                case 5: page.Three_Pages();
                    break;
                case 6: page.Two_Pages();
                    break;
                case 7: page.Three_Pages();
                    break;
                case 8: page.One_Page();
                    break;
                case 9: page.Two_Pages();
                    break;
                case 10: page.Two_Pages();
                    break;
                case 11: page.Two_Pages();
                    break;
                case 12: page.Two_Pages();
                    break;
                case 13: page.Three_Pages();
                    break;
                case 14: page.Three_Pages();
                    break;
                case 15: page.Three_Pages();
                    break;
                case 16: page.Two_Pages();
                    break;
                case 17: page.Three_Pages();
                    break;
                case 18: page.Two_Pages();
                    break;
                case 19: page.Three_Pages();
                    break;
                case 20: page.Three_Pages();
                    break;
                case 21: page.Four_Pages();
                    break;
                case 22: page.Three_Pages();
                    break;
                case 23: page.Four_Pages();
                    break;
                case 24: page.Two_Pages();
                    break;
                case 25: page.Three_Pages();
                    break;
                case 26: page.Two_Pages();
                    break;
                case 27: page.Three_Pages();
                    break;
                case 28: page.Three_Pages();
                    break;
                case 29: page.Four_Pages();
                    break;
                case 30: page.Three_Pages();
                    break;
                case 31: page.Four_Pages();
                    break;
            }

        }
    }

    public class XRayMarker
    {
        public string Test { set; get; }
        public string Type { set; get; }
        public string Marker { set; get; }
    }

    public class Reg_PrintDoc_Items
    {
        public string ControlNo
        {
            set;
            get;
        }

        public DateTime Date_Registered
        {
            set;
            get;
        }

        public string LastName
        {
            set;
            get;
        }

        public string FirstName
        {
            set;
            get;
        }

        public string MI
        {
            set;
            get;
        }

        public string Suffix
        {
            set;
            get;
        }

        public string Address
        {
            set;
            get;
        }

        public string Age
        {
            set;
            get;
        }

        public string Sex
        {
            set;
            get;
        }

        public string ReqParty
        {
            set;
            get;
        }

        public string Exam
        {
            set;
            get;
        }

        public string Price
        {
            set;
            get;
        }

        public double Total
        {
            set;
            get;
        }

        public double AmountPaid
        {
            set;
            get;
        }

        public double Balance
        {
            set;
            get;
        }

        public double Change
        {
            set;
            get;
        }

        public Image Photo
        {
            set;
            get;
        }

        public DataTable TbSingle
        {
            set;
            get;
        }

        public string Exam_Type
        {
            set;
            get;
        }
    }
}
