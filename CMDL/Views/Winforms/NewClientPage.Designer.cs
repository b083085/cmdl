namespace CMDL
{
    partial class NewClientPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewClientPage));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btDisplayInformation = new System.Windows.Forms.ToolStripDropDownButton();
            this.label9 = new System.Windows.Forms.Label();
            this.BirthDate = new System.Windows.Forms.DateTimePicker();
            this.TbBirthPlace = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ListOfParties = new System.Windows.Forms.ListBox();
            this.BtNewReqParty = new System.Windows.Forms.Button();
            this.CbPurpose = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TbDistrictBranch = new System.Windows.Forms.TextBox();
            this.BtCapture = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtTest = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.LbTotal = new System.Windows.Forms.Label();
            this.LbAmountPaid = new System.Windows.Forms.Label();
            this.LbBalance = new System.Windows.Forms.Label();
            this.LbChange = new System.Windows.Forms.Label();
            this.BtSaveRecord = new System.Windows.Forms.Button();
            this.BtDelete = new System.Windows.Forms.Button();
            this.BtCopyAddr = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TbMobileNo = new System.Windows.Forms.TextBox();
            this.TbTelNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btList = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TbAge = new System.Windows.Forms.TextBox();
            this.TbMI = new System.Windows.Forms.TextBox();
            this.CbCivilStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TbAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CbSex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TbSuffix = new System.Windows.Forms.TextBox();
            this.TbFirstName = new System.Windows.Forms.TextBox();
            this.TbLastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bgSave = new System.ComponentModel.BackgroundWorker();
            //this.temp_regnoTbAdapter = new CMDL.DAL.cmdldbDataSetTableAdapters.temp_regnoTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btDisplayInformation});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btDisplayInformation
            // 
            this.btDisplayInformation.AutoSize = false;
            this.btDisplayInformation.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btDisplayInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btDisplayInformation.Image = ((System.Drawing.Image)(resources.GetObject("btDisplayInformation.Image")));
            this.btDisplayInformation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDisplayInformation.Name = "btDisplayInformation";
            this.btDisplayInformation.ShowDropDownArrow = false;
            this.btDisplayInformation.Size = new System.Drawing.Size(150, 20);
            this.btDisplayInformation.Text = "Display Information";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "Birth Date";
            this.label9.UseCompatibleTextRendering = true;
            // 
            // BirthDate
            // 
            this.BirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BirthDate.Location = new System.Drawing.Point(9, 42);
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.Size = new System.Drawing.Size(112, 22);
            this.BirthDate.TabIndex = 0;
            // 
            // TbBirthPlace
            // 
            this.TbBirthPlace.BackColor = System.Drawing.Color.LightYellow;
            this.TbBirthPlace.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbBirthPlace.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbBirthPlace.ForeColor = System.Drawing.Color.Black;
            this.TbBirthPlace.Location = new System.Drawing.Point(127, 42);
            this.TbBirthPlace.Name = "TbBirthPlace";
            this.TbBirthPlace.Size = new System.Drawing.Size(282, 22);
            this.TbBirthPlace.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(124, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Birth Place";
            this.label10.UseCompatibleTextRendering = true;
            // 
            // ListOfParties
            // 
            this.ListOfParties.BackColor = System.Drawing.Color.LightYellow;
            this.ListOfParties.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListOfParties.ForeColor = System.Drawing.Color.Black;
            this.ListOfParties.FormattingEnabled = true;
            this.ListOfParties.Location = new System.Drawing.Point(9, 19);
            this.ListOfParties.Name = "ListOfParties";
            this.ListOfParties.Size = new System.Drawing.Size(314, 69);
            this.ListOfParties.TabIndex = 0;
            // 
            // BtNewReqParty
            // 
            this.BtNewReqParty.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtNewReqParty.ForeColor = System.Drawing.Color.Black;
            this.BtNewReqParty.Location = new System.Drawing.Point(332, 47);
            this.BtNewReqParty.Name = "BtNewReqParty";
            this.BtNewReqParty.Size = new System.Drawing.Size(80, 23);
            this.BtNewReqParty.TabIndex = 2;
            this.BtNewReqParty.Text = "Add";
            this.BtNewReqParty.UseVisualStyleBackColor = true;
            // 
            // CbPurpose
            // 
            this.CbPurpose.BackColor = System.Drawing.Color.LightYellow;
            this.CbPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbPurpose.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbPurpose.ForeColor = System.Drawing.Color.Black;
            this.CbPurpose.FormattingEnabled = true;
            this.CbPurpose.Location = new System.Drawing.Point(105, 26);
            this.CbPurpose.Name = "CbPurpose";
            this.CbPurpose.Size = new System.Drawing.Size(304, 21);
            this.CbPurpose.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(6, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 20);
            this.label13.TabIndex = 34;
            this.label13.Text = "Telephone No.";
            this.label13.UseCompatibleTextRendering = true;
            // 
            // TbDistrictBranch
            // 
            this.TbDistrictBranch.BackColor = System.Drawing.Color.LightYellow;
            this.TbDistrictBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbDistrictBranch.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbDistrictBranch.ForeColor = System.Drawing.Color.Black;
            this.TbDistrictBranch.Location = new System.Drawing.Point(105, 103);
            this.TbDistrictBranch.Name = "TbDistrictBranch";
            this.TbDistrictBranch.Size = new System.Drawing.Size(304, 22);
            this.TbDistrictBranch.TabIndex = 3;
            // 
            // BtCapture
            // 
            this.BtCapture.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCapture.ForeColor = System.Drawing.Color.Black;
            this.BtCapture.Location = new System.Drawing.Point(619, 175);
            this.BtCapture.Name = "BtCapture";
            this.BtCapture.Size = new System.Drawing.Size(150, 23);
            this.BtCapture.TabIndex = 5;
            this.BtCapture.Text = "Capture";
            this.BtCapture.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.LightYellow;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(9, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(318, 192);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Test";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Price";
            // 
            // BtTest
            // 
            this.BtTest.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtTest.ForeColor = System.Drawing.Color.Black;
            this.BtTest.Location = new System.Drawing.Point(9, 218);
            this.BtTest.Name = "BtTest";
            this.BtTest.Size = new System.Drawing.Size(80, 23);
            this.BtTest.TabIndex = 1;
            this.BtTest.Text = "Test...";
            this.BtTest.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(240, 218);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 20);
            this.label16.TabIndex = 39;
            this.label16.Text = "Total:";
            this.label16.UseCompatibleTextRendering = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(201, 236);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 20);
            this.label17.TabIndex = 40;
            this.label17.Text = "Amount Paid:";
            this.label17.UseCompatibleTextRendering = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(227, 254);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 20);
            this.label18.TabIndex = 41;
            this.label18.Text = "Balance:";
            this.label18.UseCompatibleTextRendering = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(228, 272);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 20);
            this.label19.TabIndex = 43;
            this.label19.Text = "Change:";
            this.label19.UseCompatibleTextRendering = true;
            // 
            // LbTotal
            // 
            this.LbTotal.AutoSize = true;
            this.LbTotal.ForeColor = System.Drawing.Color.Black;
            this.LbTotal.Location = new System.Drawing.Point(280, 218);
            this.LbTotal.Name = "LbTotal";
            this.LbTotal.Size = new System.Drawing.Size(27, 20);
            this.LbTotal.TabIndex = 44;
            this.LbTotal.Text = "0.00";
            this.LbTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LbTotal.UseCompatibleTextRendering = true;
            // 
            // LbAmountPaid
            // 
            this.LbAmountPaid.AutoSize = true;
            this.LbAmountPaid.ForeColor = System.Drawing.Color.Black;
            this.LbAmountPaid.Location = new System.Drawing.Point(280, 236);
            this.LbAmountPaid.Name = "LbAmountPaid";
            this.LbAmountPaid.Size = new System.Drawing.Size(27, 20);
            this.LbAmountPaid.TabIndex = 45;
            this.LbAmountPaid.Text = "0.00";
            this.LbAmountPaid.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LbAmountPaid.UseCompatibleTextRendering = true;
            // 
            // LbBalance
            // 
            this.LbBalance.AutoSize = true;
            this.LbBalance.ForeColor = System.Drawing.Color.Black;
            this.LbBalance.Location = new System.Drawing.Point(280, 254);
            this.LbBalance.Name = "LbBalance";
            this.LbBalance.Size = new System.Drawing.Size(27, 20);
            this.LbBalance.TabIndex = 0;
            this.LbBalance.Text = "0.00";
            this.LbBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LbBalance.UseCompatibleTextRendering = true;
            // 
            // LbChange
            // 
            this.LbChange.AutoSize = true;
            this.LbChange.ForeColor = System.Drawing.Color.Black;
            this.LbChange.Location = new System.Drawing.Point(280, 272);
            this.LbChange.Name = "LbChange";
            this.LbChange.Size = new System.Drawing.Size(27, 20);
            this.LbChange.TabIndex = 1;
            this.LbChange.Text = "0.00";
            this.LbChange.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LbChange.UseCompatibleTextRendering = true;
            // 
            // BtSaveRecord
            // 
            this.BtSaveRecord.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtSaveRecord.ForeColor = System.Drawing.Color.Black;
            this.BtSaveRecord.Location = new System.Drawing.Point(619, 511);
            this.BtSaveRecord.Name = "BtSaveRecord";
            this.BtSaveRecord.Size = new System.Drawing.Size(150, 23);
            this.BtSaveRecord.TabIndex = 6;
            this.BtSaveRecord.Text = "Save Record";
            this.BtSaveRecord.UseVisualStyleBackColor = true;
            // 
            // BtDelete
            // 
            this.BtDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtDelete.ForeColor = System.Drawing.Color.Black;
            this.BtDelete.Location = new System.Drawing.Point(332, 76);
            this.BtDelete.Name = "BtDelete";
            this.BtDelete.Size = new System.Drawing.Size(80, 23);
            this.BtDelete.TabIndex = 3;
            this.BtDelete.Text = "Delete";
            this.BtDelete.UseVisualStyleBackColor = true;
            // 
            // BtCopyAddr
            // 
            this.BtCopyAddr.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtCopyAddr.ForeColor = System.Drawing.Color.Black;
            this.BtCopyAddr.Location = new System.Drawing.Point(319, 68);
            this.BtCopyAddr.Name = "BtCopyAddr";
            this.BtCopyAddr.Size = new System.Drawing.Size(90, 23);
            this.BtCopyAddr.TabIndex = 2;
            this.BtCopyAddr.Text = "Copy Address";
            this.BtCopyAddr.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TbMobileNo);
            this.groupBox1.Controls.Add(this.TbTelNo);
            this.groupBox1.Controls.Add(this.CbPurpose);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.TbDistrictBranch);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 391);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 143);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PURPOSE, CONTACT NO(S) AND DISTRICT/BRANCH";
            // 
            // TbMobileNo
            // 
            this.TbMobileNo.BackColor = System.Drawing.Color.LightYellow;
            this.TbMobileNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbMobileNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMobileNo.ForeColor = System.Drawing.Color.Black;
            this.TbMobileNo.Location = new System.Drawing.Point(105, 78);
            this.TbMobileNo.Name = "TbMobileNo";
            this.TbMobileNo.Size = new System.Drawing.Size(304, 22);
            this.TbMobileNo.TabIndex = 2;
            // 
            // TbTelNo
            // 
            this.TbTelNo.BackColor = System.Drawing.Color.LightYellow;
            this.TbTelNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbTelNo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbTelNo.ForeColor = System.Drawing.Color.Black;
            this.TbTelNo.Location = new System.Drawing.Point(105, 53);
            this.TbTelNo.Name = "TbTelNo";
            this.TbTelNo.Size = new System.Drawing.Size(304, 22);
            this.TbTelNo.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 20);
            this.label12.TabIndex = 38;
            this.label12.Text = "Purpose";
            this.label12.UseCompatibleTextRendering = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "District/Branch";
            this.label11.UseCompatibleTextRendering = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(6, 82);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 20);
            this.label20.TabIndex = 36;
            this.label20.Text = "Mobile No.";
            this.label20.UseCompatibleTextRendering = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Controls.Add(this.BtTest);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.LbTotal);
            this.groupBox2.Controls.Add(this.LbChange);
            this.groupBox2.Controls.Add(this.LbAmountPaid);
            this.groupBox2.Controls.Add(this.LbBalance);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(436, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 302);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EXAMINATION";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.BirthDate);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.BtCopyAddr);
            this.groupBox3.Controls.Add(this.TbBirthPlace);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(12, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(418, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BIRTH INFORMATION";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btList);
            this.groupBox4.Controls.Add(this.ListOfParties);
            this.groupBox4.Controls.Add(this.BtNewReqParty);
            this.groupBox4.Controls.Add(this.BtDelete);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox4.Location = new System.Drawing.Point(12, 277);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(418, 108);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "REQUESTING PARTY";
            // 
            // btList
            // 
            this.btList.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btList.ForeColor = System.Drawing.Color.Black;
            this.btList.Location = new System.Drawing.Point(332, 18);
            this.btList.Name = "btList";
            this.btList.Size = new System.Drawing.Size(80, 23);
            this.btList.TabIndex = 1;
            this.btList.Text = "List..";
            this.btList.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TbAge);
            this.groupBox5.Controls.Add(this.TbMI);
            this.groupBox5.Controls.Add(this.CbCivilStatus);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.TbAddress);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.CbSex);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.TbSuffix);
            this.groupBox5.Controls.Add(this.TbFirstName);
            this.groupBox5.Controls.Add(this.TbLastName);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(418, 153);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PERSONAL INFORMATION";
            // 
            // TbAge
            // 
            this.TbAge.BackColor = System.Drawing.Color.LightYellow;
            this.TbAge.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbAge.ForeColor = System.Drawing.Color.Black;
            this.TbAge.Location = new System.Drawing.Point(11, 113);
            this.TbAge.MaxLength = 3;
            this.TbAge.Name = "TbAge";
            this.TbAge.Size = new System.Drawing.Size(49, 22);
            this.TbAge.TabIndex = 5;
            // 
            // TbMI
            // 
            this.TbMI.BackColor = System.Drawing.Color.LightYellow;
            this.TbMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbMI.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbMI.ForeColor = System.Drawing.Color.Black;
            this.TbMI.Location = new System.Drawing.Point(333, 34);
            this.TbMI.MaxLength = 5;
            this.TbMI.Name = "TbMI";
            this.TbMI.Size = new System.Drawing.Size(35, 22);
            this.TbMI.TabIndex = 2;
            // 
            // CbCivilStatus
            // 
            this.CbCivilStatus.BackColor = System.Drawing.Color.LightYellow;
            this.CbCivilStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCivilStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbCivilStatus.ForeColor = System.Drawing.Color.Black;
            this.CbCivilStatus.FormattingEnabled = true;
            this.CbCivilStatus.Items.AddRange(new object[] {
            "SINGLE",
            "MARRIED",
            "WIDOW/ER",
            "SEPARATED",
            "DIVORCED",
            "ANNULED",
            "LIVE-IN"});
            this.CbCivilStatus.Location = new System.Drawing.Point(124, 112);
            this.CbCivilStatus.Name = "CbCivilStatus";
            this.CbCivilStatus.Size = new System.Drawing.Size(150, 21);
            this.CbCivilStatus.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(121, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "Civil Status";
            this.label8.UseCompatibleTextRendering = true;
            // 
            // TbAddress
            // 
            this.TbAddress.BackColor = System.Drawing.Color.LightYellow;
            this.TbAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbAddress.ForeColor = System.Drawing.Color.Black;
            this.TbAddress.Location = new System.Drawing.Point(11, 73);
            this.TbAddress.Name = "TbAddress";
            this.TbAddress.Size = new System.Drawing.Size(398, 22);
            this.TbAddress.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(11, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Address";
            this.label7.UseCompatibleTextRendering = true;
            // 
            // CbSex
            // 
            this.CbSex.BackColor = System.Drawing.Color.LightYellow;
            this.CbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbSex.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CbSex.ForeColor = System.Drawing.Color.Black;
            this.CbSex.FormattingEnabled = true;
            this.CbSex.Items.AddRange(new object[] {
            "M",
            "F"});
            this.CbSex.Location = new System.Drawing.Point(67, 112);
            this.CbSex.Name = "CbSex";
            this.CbSex.Size = new System.Drawing.Size(50, 21);
            this.CbSex.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(64, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 39;
            this.label5.Text = "Gender";
            this.label5.UseCompatibleTextRendering = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(11, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Age";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // TbSuffix
            // 
            this.TbSuffix.BackColor = System.Drawing.Color.LightYellow;
            this.TbSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbSuffix.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbSuffix.ForeColor = System.Drawing.Color.Black;
            this.TbSuffix.Location = new System.Drawing.Point(374, 34);
            this.TbSuffix.Name = "TbSuffix";
            this.TbSuffix.Size = new System.Drawing.Size(35, 22);
            this.TbSuffix.TabIndex = 3;
            // 
            // TbFirstName
            // 
            this.TbFirstName.BackColor = System.Drawing.Color.LightYellow;
            this.TbFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbFirstName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbFirstName.ForeColor = System.Drawing.Color.Black;
            this.TbFirstName.Location = new System.Drawing.Point(167, 34);
            this.TbFirstName.Name = "TbFirstName";
            this.TbFirstName.Size = new System.Drawing.Size(160, 22);
            this.TbFirstName.TabIndex = 1;
            // 
            // TbLastName
            // 
            this.TbLastName.BackColor = System.Drawing.Color.LightYellow;
            this.TbLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TbLastName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbLastName.ForeColor = System.Drawing.Color.Black;
            this.TbLastName.Location = new System.Drawing.Point(11, 34);
            this.TbLastName.Name = "TbLastName";
            this.TbLastName.Size = new System.Drawing.Size(150, 22);
            this.TbLastName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(374, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Suffix";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(167, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "First Name";
            this.label3.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(333, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "MI";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Last Name";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // bgSave
            // 
            this.bgSave.WorkerReportsProgress = true;
            this.bgSave.WorkerSupportsCancellation = true;
            // 
            // temp_regnoTbAdapter
            // 
            //this.temp_regnoTbAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(619, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // NewClientPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtSaveRecord);
            this.Controls.Add(this.BtCapture);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "NewClientPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NEW CLIENT";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker BirthDate;
        private System.Windows.Forms.TextBox TbBirthPlace;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox ListOfParties;
        private System.Windows.Forms.Button BtNewReqParty;
        private System.Windows.Forms.ComboBox CbPurpose;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TbDistrictBranch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtCapture;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button BtTest;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label LbTotal;
        private System.Windows.Forms.Label LbAmountPaid;
        private System.Windows.Forms.Label LbBalance;
        private System.Windows.Forms.Label LbChange;
        private System.Windows.Forms.Button BtSaveRecord;
        private System.Windows.Forms.Button BtDelete;
        private System.Windows.Forms.Button BtCopyAddr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TbMI;
        private System.Windows.Forms.ComboBox CbCivilStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TbAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbSex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbSuffix;
        private System.Windows.Forms.TextBox TbFirstName;
        private System.Windows.Forms.TextBox TbLastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbAge;
        private System.ComponentModel.BackgroundWorker bgSave;
        private System.Windows.Forms.TextBox TbMobileNo;
        private System.Windows.Forms.TextBox TbTelNo;
        //private CMDL.DAL.cmdldbDataSetTableAdapters.temp_regnoTableAdapter temp_regnoTbAdapter;
        private System.Windows.Forms.ToolStripDropDownButton btDisplayInformation;
        private System.Windows.Forms.Button btList;
    }
}