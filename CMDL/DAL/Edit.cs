using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;


namespace CMDL
{
    public class Edit
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr handle);
        public static IntPtr ip;
        public static BitmapSource bs;
        public static JpegBitmapEncoder encoder;

        public static Image Crop(Image image, Rectangle croparea)
        {
            try
            {
                Bitmap bitmap = new Bitmap(image);
                Bitmap bmpCrop = bitmap.Clone(croparea, bitmap.PixelFormat);

                return (Image)(bmpCrop);
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show(ex.Message, "Crop Image Message");
                return null;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Crop Image Exception");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Crop Image Exception");
                return null;
            }

        }

        public static Image Resize(Image image, System.Drawing.Size size)
        {
            try
            {
                Bitmap bitmap = new Bitmap(size.Width, size.Height);

                using (Graphics g = Graphics.FromImage((System.Drawing.Image)bitmap))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.DrawImage(image, 0, 0, size.Width, size.Height);

                    return (Image)bitmap;
                }
            }
            catch (ArgumentNullException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Resize Image Message");
                return null;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Resize Image Message");
                return null;
            }

        }

        public static BitmapSource BmpSource(Image image)
        {

            Bitmap getImage = (Bitmap)image;
            Bitmap newImage = new Bitmap(140, 140);

            using (Graphics g = Graphics.FromImage((Image)newImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(getImage, 0, 0, 140, 140);

                ip = getImage.GetHbitmap();
                bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, IntPtr.Zero, System.Windows.Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
                DeleteObject(ip);

                return bs;
            }
        }

        public static Bitmap BitmapSourceToBitmap(BitmapSource source)
        {
            Bitmap bmp = new Bitmap(source.PixelWidth, source.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            source.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bmp.UnlockBits(data);
            return bmp;
        }

        public static string SetEscSeq(string data)
        {
            string text = "", get_c = "";
            try
            {
                foreach (char c in data)
                {

                    if (c.ToString() == "'")
                    {
                        get_c = "''";
                    }
                    else if (c.ToString() == "\"")
                    {
                        get_c = "\"";
                    }
                    else
                    {
                        get_c = c.ToString();
                    }
                    text += get_c;
                }
            }
            catch (Exception)
            {

            }
            return text;
        }

        public static string CheckTilde(string data)
        {
            string text = "", get_c = "";

            foreach (char c in data)
            {

                if (string.Format("{0:X}", (int)c) == "A5")
                {
                    get_c = "Ñ";
                }
                else if (string.Format("{0:X}", (int)c) == "A4")
                {
                    get_c = "ñ";
                }
                else
                {
                    get_c = c.ToString();
                }
                text += get_c;
            }
            return text;
        }

        public static List<string> ParseTest(string exam, List<string> list)
        {
            string get_c = "";
            List<string> test = new List<string>();

            foreach (string l in list)
            {
                if (l != "DRUG TEST")
                {
                    foreach (char c in exam)
                    {
                        if (c.ToString() != ",")
                        {
                            get_c += c.ToString();
                        }
                        else
                        {
                            if (get_c == l)
                            {
                                test.Add(l);
                            }
                            get_c = "";
                        }
                    }
                }
            }
            return test;
        }

        public static byte[] ImageToStream(Image photo)
        {
            try
            {
                Bitmap image = new Bitmap(photo);
                using (MemoryStream stream = new MemoryStream())
                {
                    photo.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    return stream.ToArray();
                }

            }
            catch (ArgumentNullException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Image Stream Message");
                return null;
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Image Stream Message");
                return null;
            }
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        public static void SavePhoto(byte[] image,string name)
        {
            try
            {
                encoder = new JpegBitmapEncoder();
                encoder.Frames.Add((BitmapFrame.Create(Edit.BmpSource(Edit.ByteArrayToImage(image)))));
                encoder.QualityLevel = 100;
                if (!Directory.Exists(@"C:\Cyber_Pictures"))
                    Directory.CreateDirectory(@"C:\Cyber_Pictures");

                using (FileStream fstream = new FileStream(@"C:\Cyber_Pictures\" + name + ".jpg", FileMode.Create))
                {
                    encoder.Save(fstream);
                    fstream.Close();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Save Picture Mesasage");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Save Picture Mesasage");
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message, "Save Picture Mesasage");
            }
        }

    }
}
