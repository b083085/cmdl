using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;


namespace CMDL
{
    class BarCode
    {
        private static float xpos = 0F;
        
        private static void DrawBarCode(string code,PrintPageEventArgs e,ref float x)
        {

            foreach (char c in code)
            {
                switch (c)
                {
                    case '1': e.Graphics.DrawLine(new Pen(Brushes.Gray,1), new PointF(xpos,152), new PointF(xpos,172));
                        xpos += 1F;
                              break;
                    case '2': e.Graphics.DrawLine(new Pen(Brushes.White, 2), new PointF(xpos, 152), new PointF(xpos, 172));
                              xpos += 2F;
                              break;
                    case '3': e.Graphics.DrawLine(new Pen(Brushes.Black, 3), new PointF(xpos, 152), new PointF(xpos, 172));
                              xpos += 2.6F;
                              break;

                }
            }

        }

        public static void Draw(string controlno,PrintPageEventArgs e)
        {
            xpos = 666F;
            foreach (char c in controlno)
            {

                switch (c)
                {
                    case '0': DrawBarCode("112331", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F), Brushes.Black, new PointF(xpos, 173));
                        break;
                    case '1': DrawBarCode("312113", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F,FontStyle.Bold), Brushes.Black, new PointF(xpos, 173));
                        break;
                    case '2': DrawBarCode("132113", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F), Brushes.Black, new PointF(xpos, 173));
                        break;
                    case '3': DrawBarCode("332111", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F,FontStyle.Bold), Brushes.Black, new PointF(xpos, 173));
                        break;
                    case '4': DrawBarCode("112313", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F), Brushes.Black, new PointF(xpos, 173));
                        break;
                    case '5': DrawBarCode("312311", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F, FontStyle.Bold), Brushes.Black, new PointF(xpos, 173));
                        break;
                    case '6': DrawBarCode("132311", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F, FontStyle.Bold), Brushes.Black, new PointF(xpos, 173));
                        break;
                    case '7': DrawBarCode("112133", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F, FontStyle.Bold), Brushes.Black, new PointF(xpos, 173));
                        break;
                    case '8': DrawBarCode("312131", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F), Brushes.Black, new PointF(xpos, 173));
                        break;
                    case '9': DrawBarCode("132131", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F, FontStyle.Bold), Brushes.Black, new PointF(xpos, 173));
                        break;
                    case '*': DrawBarCode("121331", e, ref xpos);
                        e.Graphics.DrawString(c.ToString(), new Font("Arial", 7F), Brushes.Black, new PointF(xpos, 173));
                        break;


                }
            }
        }

    }
}
