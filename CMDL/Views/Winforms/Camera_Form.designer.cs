namespace CMDL
{
    partial class Camera_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CbCamSource = new System.Windows.Forms.ComboBox();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.Photo = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.BtCapture = new System.Windows.Forms.Button();
            this.BtSettings = new System.Windows.Forms.Button();
            this.BtLoadPhoto = new System.Windows.Forms.Button();
            this.BtOK = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Photo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // CbCamSource
            // 
            this.CbCamSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCamSource.FormattingEnabled = true;
            this.CbCamSource.Location = new System.Drawing.Point(12, 12);
            this.CbCamSource.Name = "CbCamSource";
            this.CbCamSource.Size = new System.Drawing.Size(300, 21);
            this.CbCamSource.TabIndex = 0;
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(12, 39);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(300, 300);
            this.videoSourcePlayer1.TabIndex = 1;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // Photo
            // 
            this.Photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Photo.Location = new System.Drawing.Point(318, 39);
            this.Photo.Name = "Photo";
            this.Photo.Size = new System.Drawing.Size(300, 300);
            this.Photo.TabIndex = 2;
            this.Photo.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(12, 345);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(300, 20);
            this.trackBar1.TabIndex = 3;
            // 
            // BtCapture
            // 
            this.BtCapture.ForeColor = System.Drawing.Color.Black;
            this.BtCapture.Location = new System.Drawing.Point(12, 374);
            this.BtCapture.Name = "BtCapture";
            this.BtCapture.Size = new System.Drawing.Size(300, 23);
            this.BtCapture.TabIndex = 4;
            this.BtCapture.Text = "Capture";
            this.BtCapture.UseVisualStyleBackColor = true;
            // 
            // BtSettings
            // 
            this.BtSettings.ForeColor = System.Drawing.Color.Black;
            this.BtSettings.Location = new System.Drawing.Point(12, 403);
            this.BtSettings.Name = "BtSettings";
            this.BtSettings.Size = new System.Drawing.Size(300, 23);
            this.BtSettings.TabIndex = 5;
            this.BtSettings.Text = "Properties";
            this.BtSettings.UseVisualStyleBackColor = true;
            // 
            // BtLoadPhoto
            // 
            this.BtLoadPhoto.ForeColor = System.Drawing.Color.Black;
            this.BtLoadPhoto.Location = new System.Drawing.Point(543, 345);
            this.BtLoadPhoto.Name = "BtLoadPhoto";
            this.BtLoadPhoto.Size = new System.Drawing.Size(75, 23);
            this.BtLoadPhoto.TabIndex = 6;
            this.BtLoadPhoto.Text = "Load Photo";
            this.BtLoadPhoto.UseVisualStyleBackColor = true;
            // 
            // BtOK
            // 
            this.BtOK.ForeColor = System.Drawing.Color.Black;
            this.BtOK.Location = new System.Drawing.Point(543, 374);
            this.BtOK.Name = "BtOK";
            this.BtOK.Size = new System.Drawing.Size(75, 23);
            this.BtOK.TabIndex = 7;
            this.BtOK.Text = "OK";
            this.BtOK.UseVisualStyleBackColor = true;
            // 
            // BtCancel
            // 
            this.BtCancel.ForeColor = System.Drawing.Color.Black;
            this.BtCancel.Location = new System.Drawing.Point(543, 403);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 8;
            this.BtCancel.Text = "Cancel";
            this.BtCancel.UseVisualStyleBackColor = true;
            // 
            // Camera_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(634, 462);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtOK);
            this.Controls.Add(this.BtLoadPhoto);
            this.Controls.Add(this.BtSettings);
            this.Controls.Add(this.BtCapture);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.Photo);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Controls.Add(this.CbCamSource);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 500);
            this.Name = "Camera_Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAMERA";
            ((System.ComponentModel.ISupportInitialize)(this.Photo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbCamSource;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.PictureBox Photo;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button BtCapture;
        private System.Windows.Forms.Button BtSettings;
        private System.Windows.Forms.Button BtLoadPhoto;
        private System.Windows.Forms.Button BtOK;
        private System.Windows.Forms.Button BtCancel;

    }
}