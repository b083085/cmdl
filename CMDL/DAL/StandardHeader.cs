using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace CMDL
{
    class StandardHeader
    {
        public static void Print(PrintPageEventArgs e,string controlno,Image photo)
        {
            e.Graphics.DrawString(Properties.Settings.Default.Company, new Font("Bauhaus 93", 15F, FontStyle.Bold), Brushes.Black, new RectangleF(new Point(9, 21), new SizeF(816, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(Properties.Settings.Default.Company, new Font("Bauhaus 93", 15F, FontStyle.Bold), Brushes.Gold, new RectangleF(new Point(10, 20), new SizeF(816, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(Properties.Settings.Default.Company_Profile, new Font("Arial", 11.5F, FontStyle.Bold), Brushes.Black, new RectangleF(new Point(10, 40), new SizeF(816, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(Properties.Settings.Default.Company_Addr, new Font("Arial", 9F), Brushes.Black, new RectangleF(new Point(10, 55), new SizeF(816, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(Properties.Settings.Default.Company_TelNo, new Font("Arial", 9F), Brushes.Black, new RectangleF(new Point(10, 68), new SizeF(816, 20)), new StringFormat() { Alignment = StringAlignment.Center });
            
            //draw logo
            //e.Graphics.DrawImage(Edit.Resize(Properties.Resources.Logo, new Size(120, 60)), new RectangleF(new Point(20, 20), new SizeF(120, 60)));
            e.Graphics.DrawImage(Properties.Resources.Logo, new RectangleF(new Point(20, 20), new SizeF(120, 60)));

            //draw photo
            //e.Graphics.DrawImage(Edit.Resize(photo, new Size(130, 130)), new RectangleF(new Point(666, 20), new SizeF(130, 130)));
            e.Graphics.DrawImage(photo, new RectangleF(new Point(666, 20), new SizeF(130, 130)));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(666, 20, 130, 130));
            BarCode.Draw(controlno, e);
            //e.Graphics.DrawString("CMDL-" + controlno, new Font("Arial", 8F), Brushes.Red, new RectangleF(new Point(666, 170), new SizeF(130, 20)), new StringFormat() { Alignment = StringAlignment.Center });

        }
    }
}
