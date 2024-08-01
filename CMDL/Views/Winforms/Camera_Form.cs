using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;

namespace CMDL
{
    public partial class Camera_Form : Form
    {
        private VideoCaptureDevice videocaptureSource;
        private FilterInfoCollection videoDevices;
        private Crop crop;
        private int mouseX = 0, mouseY = 0, boxWidth = 0, boxHeight = 0;
        private bool mouseDown = false;
        private Graphics g;
        public event EventHandler PhotoEvent;


        public Camera_Form()
        {
            InitializeComponent();

            trackBar1.Scroll += new EventHandler(trackBar1_Scroll);

            videoSourcePlayer1.SizeChanged += new EventHandler(videoSourcePlayer1_SizeChanged);
            videoSourcePlayer1.MouseDown += new System.Windows.Forms.MouseEventHandler(videoSourcePlayer1_MouseDown);
            videoSourcePlayer1.Paint += new System.Windows.Forms.PaintEventHandler(videoSourcePlayer1_Paint);
            videoSourcePlayer1.MouseMove += new System.Windows.Forms.MouseEventHandler(videoSourcePlayer1_MouseMove);
            videoSourcePlayer1.MouseUp += new System.Windows.Forms.MouseEventHandler(videoSourcePlayer1_MouseUp);

            this.Load += new EventHandler(Camera_Form_Load);
            this.FormClosing += new FormClosingEventHandler(Camera_Form_FormClosing);

            CbCamSource.SelectedIndexChanged += new EventHandler(CbCamSource_SelectedIndexChanged);

            BtCapture.Click += new EventHandler(BtCapture_Click);
            BtLoadPhoto.Click += new EventHandler(BtLoadPhoto_Click);
            BtOK.Click += new EventHandler(BtOK_Click);
            BtCancel.Click += new EventHandler(BtCancel_Click);
            BtSettings.Click += new EventHandler(BtSettings_Click);

        }



        #region BUTTON
        void BtCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void BtOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        void BtLoadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.FileName = "Pictures";
                openFileDialog1.Title = "Pictures";
                openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                openFileDialog1.Filter = "JPEG File (.jpg,.jpeg)|*.jpg|GIF Files (.gif)|*.gif|BMP Files (.bmp)|*.bmp|PNG Files (.png)|*.png";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SetPicBoxImage(System.Drawing.Image.FromFile(openFileDialog1.FileName));
                }
                else
                {
                    Photo.Image = null;
                }
            }
        }

        void BtCapture_Click(object sender, EventArgs e)
        {
            try
            {
                if (videoSourcePlayer1.GetCurrentVideoFrame() != null)
                {
                    if (videoSourcePlayer1.IsRunning == true)
                    {

                        using (Bitmap videoImage = videoSourcePlayer1.GetCurrentVideoFrame())
                        {
                            using (Bitmap newImage = new Bitmap(Photo.Width, Photo.Height))
                            {
                                using (Graphics g = Graphics.FromImage((System.Drawing.Image)newImage))
                                {
                                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    g.DrawImage(videoImage, 0, 0, Photo.Width, Photo.Height);
                                    //CROP
                                    crop = new Crop(new Rectangle(mouseX, mouseY, boxWidth, boxHeight));
                                    this.SetPicBoxImage((System.Drawing.Image)crop.Apply(newImage));
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Try taking snapshot again when the video image is available", "Crop Message");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Capture Message");
            }
        }

        void BtSettings_Click(object sender, EventArgs e)
        {
            if (videocaptureSource != null)
            {
                videocaptureSource.DisplayPropertyPage(this.Handle); // modal dialog
                //videocaptureSource.DisplayPropertyPage(IntPtr.Zero); //non-modal
            }
        }
        #endregion

        #region VIDEOSOURCEPLAYER
        private void videoSourcePlayer1_SizeChanged(object sender, EventArgs e)
        {
            boxWidth = videoSourcePlayer1.Width - (2 * 20);
            boxHeight = videoSourcePlayer1.Height - (2 * 20);
        }

        private void videoSourcePlayer1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void videoSourcePlayer1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            g = e.Graphics;
            if (true)
                g.DrawRectangle(new Pen(Brushes.Blue, 5F), new Rectangle(mouseX, mouseY, boxWidth, boxHeight));
        }

        private void videoSourcePlayer1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = e.X - (boxWidth / 2);
                mouseY = e.Y - (boxHeight / 2);
                videoSourcePlayer1.Refresh();
            }
        }

        private void videoSourcePlayer1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mouseDown = false;

            if (mouseX < 0 || mouseY < 0)
            {
                mouseX = 20;
                mouseY = 20;
            }
            else if ((mouseX + boxWidth) > videoSourcePlayer1.Width || (mouseY + boxHeight) > videoSourcePlayer1.Height)
            {
                mouseX = videoSourcePlayer1.Width - boxWidth - 20;
                mouseY = videoSourcePlayer1.Height - boxHeight - 20;
            }
            videoSourcePlayer1.Refresh();
        }
        #endregion

        #region METHODS
        private void SearchVideoSource()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    CbCamSource.Items.Clear();
                    CbCamSource.Items.Add("NO VIDEO DEVICES");
                }
                else
                {
                    CbCamSource.Items.Clear();
                    foreach (FilterInfo mySingleDevice in videoDevices)
                    {
                        CbCamSource.Items.Add(mySingleDevice.Name);
                    }
                    CbCamSource.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Video Source Message");
            }
        }

        private void SetPicBoxImage(System.Drawing.Image image)
        {

            if (PhotoEvent != null)
                PhotoEvent(image, EventArgs.Empty);
            
            this.Photo.Image = image;
            if (image.Height < Photo.Height && image.Width < Photo.Width)
                this.Photo.SizeMode = PictureBoxSizeMode.CenterImage;
            else
                this.Photo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public System.Drawing.Image GetPhoto
        {
            get
            {
                return Photo.Image;
            }

        }
        #endregion

        #region FORM
        void Camera_Form_Load(object sender, EventArgs e)
        {
            SearchVideoSource();
            mouseX = 20;
            mouseY = 20;
            boxWidth = videoSourcePlayer1.Width - (2 * 20);
            boxHeight = videoSourcePlayer1.Height - (2 * 20);
            trackBar1.Maximum = videoSourcePlayer1.Width - (2 * 20);
            trackBar1.Minimum = 1;
        }

        void Camera_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            videoDevices = null;
            videocaptureSource = null;
            g = null;
        }
        #endregion

        #region COMBOBOX
        void CbCamSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbCamSource.SelectedItem.ToString() == "NO VIDEO DEVICES")
            {
                if (videoSourcePlayer1.IsRunning == true)
                {
                    videoSourcePlayer1.SignalToStop();
                    videoSourcePlayer1.WaitForStop();
                }
            }
            else
            {
                videocaptureSource = new VideoCaptureDevice(videoDevices[CbCamSource.SelectedIndex].MonikerString);
                videoSourcePlayer1.VideoSource = videocaptureSource;
                videoSourcePlayer1.Start();
            }
        }
        #endregion

        #region TRACKBAR
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            boxWidth = (videoSourcePlayer1.Width - (2 * 20)) - trackBar1.Value;
            boxHeight = (videoSourcePlayer1.Height - (2 * 20)) - trackBar1.Value;
            mouseX = (videoSourcePlayer1.Width - boxWidth) / 2;
            mouseY = (videoSourcePlayer1.Height - boxHeight) / 2;
            videoSourcePlayer1.Refresh();
        }
        #endregion




    }
}
