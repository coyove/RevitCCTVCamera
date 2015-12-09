namespace CameraPlugin
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSearchRoom = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lvRooms = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.roomArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.roomCoverage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtSearchCamera = new System.Windows.Forms.TextBox();
            this.lblCamera = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPan = new System.Windows.Forms.Label();
            this.tbTilt = new System.Windows.Forms.TrackBar();
            this.tbPan = new System.Windows.Forms.TrackBar();
            this.lvCameras = new System.Windows.Forms.ListView();
            this.cameraID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cameraName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cameraRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cameraFOV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cameraEv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cameraCoverage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cameraSensor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cameraLens = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkHuman = new System.Windows.Forms.CheckBox();
            this.chkWindows = new System.Windows.Forms.CheckBox();
            this.chkDoors = new System.Windows.Forms.CheckBox();
            this.chkFancy = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.txtFactor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtHumanHeight = new System.Windows.Forms.TextBox();
            this.menuCamera = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chooseSensor = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseLensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.picRooms = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPan)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(12, 539);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(898, 81);
            this.txtDebug.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(518, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(452, 500);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.txtSearchRoom);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.lvRooms);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(444, 471);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Room";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtSearchRoom
            // 
            this.txtSearchRoom.Location = new System.Drawing.Point(36, 6);
            this.txtSearchRoom.Name = "txtSearchRoom";
            this.txtSearchRoom.Size = new System.Drawing.Size(402, 25);
            this.txtSearchRoom.TabIndex = 13;
            this.txtSearchRoom.TextChanged += new System.EventHandler(this.txtSearchRoom_TextChanged);
            this.txtSearchRoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchRoom_KeyPress);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(165, 19);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Display all rooms";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lvRooms
            // 
            this.lvRooms.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colName,
            this.colLevel,
            this.roomArea,
            this.roomCoverage});
            this.lvRooms.FullRowSelect = true;
            this.lvRooms.GridLines = true;
            this.lvRooms.Location = new System.Drawing.Point(6, 62);
            this.lvRooms.Name = "lvRooms";
            this.lvRooms.Size = new System.Drawing.Size(432, 403);
            this.lvRooms.TabIndex = 4;
            this.lvRooms.UseCompatibleStateImageBehavior = false;
            this.lvRooms.View = System.Windows.Forms.View.Details;
            this.lvRooms.SelectedIndexChanged += new System.EventHandler(this.lvRooms_SelectedIndexChanged_1);
            this.lvRooms.DoubleClick += new System.EventHandler(this.lvRooms_DoubleClick);
            // 
            // colID
            // 
            this.colID.Text = "Room ID";
            this.colID.Width = 100;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // colLevel
            // 
            this.colLevel.Text = "Ev.";
            // 
            // roomArea
            // 
            this.roomArea.Text = "Area";
            // 
            // roomCoverage
            // 
            this.roomCoverage.Text = "Coverage";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.txtSearchCamera);
            this.tabPage2.Controls.Add(this.lblCamera);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lblPan);
            this.tabPage2.Controls.Add(this.tbTilt);
            this.tabPage2.Controls.Add(this.tbPan);
            this.tabPage2.Controls.Add(this.lvCameras);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(444, 471);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Camera";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtSearchCamera
            // 
            this.txtSearchCamera.Location = new System.Drawing.Point(36, 6);
            this.txtSearchCamera.Name = "txtSearchCamera";
            this.txtSearchCamera.Size = new System.Drawing.Size(402, 25);
            this.txtSearchCamera.TabIndex = 27;
            this.txtSearchCamera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchCamera_KeyPress);
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.Location = new System.Drawing.Point(12, 441);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(255, 15);
            this.lblCamera.TabIndex = 26;
            this.lblCamera.Text = "Double click to select a camera";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(320, 432);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 33);
            this.button1.TabIndex = 25;
            this.button1.Text = "Edit Profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tilt:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Pan:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "90°";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 395);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "0°";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "360°";
            // 
            // lblPan
            // 
            this.lblPan.AutoSize = true;
            this.lblPan.Location = new System.Drawing.Point(133, 354);
            this.lblPan.Name = "lblPan";
            this.lblPan.Size = new System.Drawing.Size(30, 15);
            this.lblPan.TabIndex = 16;
            this.lblPan.Text = "0°";
            // 
            // tbTilt
            // 
            this.tbTilt.BackColor = System.Drawing.Color.White;
            this.tbTilt.Location = new System.Drawing.Point(169, 386);
            this.tbTilt.Maximum = 90;
            this.tbTilt.Name = "tbTilt";
            this.tbTilt.Size = new System.Drawing.Size(199, 56);
            this.tbTilt.TabIndex = 15;
            this.tbTilt.TickFrequency = 10;
            this.tbTilt.Scroll += new System.EventHandler(this.tbTilt_Scroll);
            this.tbTilt.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbTilt_MouseUp);
            // 
            // tbPan
            // 
            this.tbPan.BackColor = System.Drawing.Color.White;
            this.tbPan.Location = new System.Drawing.Point(169, 344);
            this.tbPan.Maximum = 360;
            this.tbPan.Name = "tbPan";
            this.tbPan.Size = new System.Drawing.Size(199, 56);
            this.tbPan.TabIndex = 14;
            this.tbPan.TickFrequency = 10;
            this.tbPan.Scroll += new System.EventHandler(this.tbPan_Scroll);
            this.tbPan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbPan_MouseDown);
            this.tbPan.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbPan_MouseUp);
            // 
            // lvCameras
            // 
            this.lvCameras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cameraID,
            this.cameraName,
            this.cameraRoom,
            this.cameraFOV,
            this.cameraEv,
            this.cameraCoverage,
            this.cameraSensor,
            this.cameraLens});
            this.lvCameras.FullRowSelect = true;
            this.lvCameras.GridLines = true;
            this.lvCameras.Location = new System.Drawing.Point(6, 37);
            this.lvCameras.Name = "lvCameras";
            this.lvCameras.Size = new System.Drawing.Size(432, 301);
            this.lvCameras.TabIndex = 5;
            this.lvCameras.UseCompatibleStateImageBehavior = false;
            this.lvCameras.View = System.Windows.Forms.View.Details;
            this.lvCameras.SelectedIndexChanged += new System.EventHandler(this.lvCameras_SelectedIndexChanged);
            this.lvCameras.DoubleClick += new System.EventHandler(this.lvCameras_DoubleClick);
            // 
            // cameraID
            // 
            this.cameraID.Text = "Camera ID";
            this.cameraID.Width = 100;
            // 
            // cameraName
            // 
            this.cameraName.Text = "Name";
            // 
            // cameraRoom
            // 
            this.cameraRoom.Text = "Inside";
            // 
            // cameraFOV
            // 
            this.cameraFOV.Text = "FOV";
            // 
            // cameraEv
            // 
            this.cameraEv.Text = "Ev.";
            // 
            // cameraCoverage
            // 
            this.cameraCoverage.Text = "Coverage";
            // 
            // cameraSensor
            // 
            this.cameraSensor.Text = "Sensor";
            // 
            // cameraLens
            // 
            this.cameraLens.Text = "Lens";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtInfo);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(444, 471);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Info";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(6, 6);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(432, 459);
            this.txtInfo.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.pictureBox3);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.chkHuman);
            this.tabPage3.Controls.Add(this.chkWindows);
            this.tabPage3.Controls.Add(this.chkDoors);
            this.tabPage3.Controls.Add(this.chkFancy);
            this.tabPage3.Controls.Add(this.checkBox2);
            this.tabPage3.Controls.Add(this.txtFactor);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.btnSave);
            this.tabPage3.Controls.Add(this.txtHumanHeight);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(444, 471);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkHuman
            // 
            this.chkHuman.AutoSize = true;
            this.chkHuman.Checked = true;
            this.chkHuman.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHuman.Location = new System.Drawing.Point(9, 39);
            this.chkHuman.Name = "chkHuman";
            this.chkHuman.Size = new System.Drawing.Size(237, 19);
            this.chkHuman.TabIndex = 33;
            this.chkHuman.Text = "Consider human height (m):";
            this.chkHuman.UseVisualStyleBackColor = true;
            // 
            // chkWindows
            // 
            this.chkWindows.AutoSize = true;
            this.chkWindows.Checked = true;
            this.chkWindows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWindows.Location = new System.Drawing.Point(9, 139);
            this.chkWindows.Name = "chkWindows";
            this.chkWindows.Size = new System.Drawing.Size(149, 19);
            this.chkWindows.TabIndex = 32;
            this.chkWindows.Text = "Display windows";
            this.chkWindows.UseVisualStyleBackColor = true;
            this.chkWindows.CheckedChanged += new System.EventHandler(this.chkWindows_CheckedChanged);
            // 
            // chkDoors
            // 
            this.chkDoors.AutoSize = true;
            this.chkDoors.Checked = true;
            this.chkDoors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDoors.Location = new System.Drawing.Point(9, 114);
            this.chkDoors.Name = "chkDoors";
            this.chkDoors.Size = new System.Drawing.Size(133, 19);
            this.chkDoors.TabIndex = 31;
            this.chkDoors.Text = "Display doors";
            this.chkDoors.UseVisualStyleBackColor = true;
            this.chkDoors.CheckedChanged += new System.EventHandler(this.chkDoors_CheckedChanged);
            // 
            // chkFancy
            // 
            this.chkFancy.AutoSize = true;
            this.chkFancy.Checked = true;
            this.chkFancy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFancy.Location = new System.Drawing.Point(9, 89);
            this.chkFancy.Name = "chkFancy";
            this.chkFancy.Size = new System.Drawing.Size(173, 19);
            this.chkFancy.TabIndex = 30;
            this.chkFancy.Text = "Fancy camera icons";
            this.chkFancy.UseVisualStyleBackColor = true;
            this.chkFancy.CheckedChanged += new System.EventHandler(this.chkFancy_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(9, 64);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(381, 19);
            this.checkBox2.TabIndex = 29;
            this.checkBox2.Text = "Reset coordinates when selecting new cameras";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // txtFactor
            // 
            this.txtFactor.Location = new System.Drawing.Point(239, 313);
            this.txtFactor.Name = "txtFactor";
            this.txtFactor.Size = new System.Drawing.Size(121, 25);
            this.txtFactor.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Clipper Library";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(333, 434);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 31);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHumanHeight
            // 
            this.txtHumanHeight.Location = new System.Drawing.Point(252, 37);
            this.txtHumanHeight.Name = "txtHumanHeight";
            this.txtHumanHeight.Size = new System.Drawing.Size(80, 25);
            this.txtHumanHeight.TabIndex = 25;
            // 
            // menuCamera
            // 
            this.menuCamera.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuCamera.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseSensor,
            this.chooseLensToolStripMenuItem,
            this.toolStripSeparator1,
            this.editNameToolStripMenuItem});
            this.menuCamera.Name = "contextMenuStrip1";
            this.menuCamera.Size = new System.Drawing.Size(194, 88);
            this.menuCamera.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuCamera_ItemClicked);
            // 
            // chooseSensor
            // 
            this.chooseSensor.Name = "chooseSensor";
            this.chooseSensor.Size = new System.Drawing.Size(193, 26);
            this.chooseSensor.Text = "Choose Sensor";
            // 
            // chooseLensToolStripMenuItem
            // 
            this.chooseLensToolStripMenuItem.Name = "chooseLensToolStripMenuItem";
            this.chooseLensToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.chooseLensToolStripMenuItem.Text = "Choose Lens";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // editNameToolStripMenuItem
            // 
            this.editNameToolStripMenuItem.Name = "editNameToolStripMenuItem";
            this.editNameToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.editNameToolStripMenuItem.Text = "Edit Name";
            this.editNameToolStripMenuItem.Click += new System.EventHandler(this.editNameToolStripMenuItem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 15);
            this.label7.TabIndex = 34;
            this.label7.Text = "Camera Settings";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::CameraPlugin.Properties.Resources.search;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CameraPlugin.Properties.Resources.search;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::CameraPlugin.Properties.Resources.clipper_sample;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(3, 216);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(96, 90);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // picRooms
            // 
            this.picRooms.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picRooms.Location = new System.Drawing.Point(12, 12);
            this.picRooms.Name = "picRooms";
            this.picRooms.Size = new System.Drawing.Size(500, 500);
            this.picRooms.TabIndex = 1;
            this.picRooms.TabStop = false;
            this.picRooms.Click += new System.EventHandler(this.picRooms_Click);
            this.picRooms.Paint += new System.Windows.Forms.PaintEventHandler(this.picRooms_Paint);
            this.picRooms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picRooms_MouseDown);
            this.picRooms.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picRooms_MouseMove);
            this.picRooms.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picRooms_MouseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 230);
            this.label8.MaximumSize = new System.Drawing.Size(350, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(319, 60);
            this.label8.TabIndex = 36;
            this.label8.Text = "This program uses Clipper Library to calculate the coverage. Increasing the Facto" +
    "r could produce more accurate results.\r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(170, 316);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 37;
            this.label9.Text = "Factor:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 523);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.picRooms);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "CCTV Camera Inspector";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPan)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picRooms;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListView lvRooms;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colLevel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TrackBar tbTilt;
        private System.Windows.Forms.TrackBar tbPan;
        private System.Windows.Forms.ListView lvCameras;
        private System.Windows.Forms.ColumnHeader cameraID;
        private System.Windows.Forms.ColumnHeader cameraName;
        private System.Windows.Forms.ColumnHeader cameraRoom;
        private System.Windows.Forms.ColumnHeader cameraFOV;
        private System.Windows.Forms.ColumnHeader cameraEv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader roomArea;
        private System.Windows.Forms.ColumnHeader cameraCoverage;
        private System.Windows.Forms.ColumnHeader roomCoverage;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtHumanHeight;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip menuCamera;
        private System.Windows.Forms.ToolStripMenuItem chooseSensor;
        private System.Windows.Forms.ColumnHeader cameraSensor;
        private System.Windows.Forms.ToolStripMenuItem chooseLensToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader cameraLens;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFactor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editNameToolStripMenuItem;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox chkFancy;
        private System.Windows.Forms.TextBox txtSearchRoom;
        private System.Windows.Forms.TextBox txtSearchCamera;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.CheckBox chkDoors;
        private System.Windows.Forms.CheckBox chkWindows;
        private System.Windows.Forms.CheckBox chkHuman;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}