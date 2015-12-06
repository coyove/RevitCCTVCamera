namespace CameraPlugin
{
    partial class frmEdit
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
            this.lblPan = new System.Windows.Forms.Label();
            this.tbPan = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOldPan = new System.Windows.Forms.Label();
            this.lblOldTilt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTilt = new System.Windows.Forms.Label();
            this.tbTilt = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFocal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbPan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTilt)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPan
            // 
            this.lblPan.AutoSize = true;
            this.lblPan.Location = new System.Drawing.Point(152, 55);
            this.lblPan.Name = "lblPan";
            this.lblPan.Size = new System.Drawing.Size(30, 15);
            this.lblPan.TabIndex = 9;
            this.lblPan.Text = "0°";
            // 
            // tbPan
            // 
            this.tbPan.Location = new System.Drawing.Point(188, 51);
            this.tbPan.Maximum = 360;
            this.tbPan.Name = "tbPan";
            this.tbPan.Size = new System.Drawing.Size(185, 56);
            this.tbPan.TabIndex = 8;
            this.tbPan.TickFrequency = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Pan Angle:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Original Angle:";
            // 
            // lblOldPan
            // 
            this.lblOldPan.AutoSize = true;
            this.lblOldPan.Location = new System.Drawing.Point(152, 92);
            this.lblOldPan.Name = "lblOldPan";
            this.lblOldPan.Size = new System.Drawing.Size(30, 15);
            this.lblOldPan.TabIndex = 13;
            this.lblOldPan.Text = "0°";
            // 
            // lblOldTilt
            // 
            this.lblOldTilt.AutoSize = true;
            this.lblOldTilt.Location = new System.Drawing.Point(152, 170);
            this.lblOldTilt.Name = "lblOldTilt";
            this.lblOldTilt.Size = new System.Drawing.Size(30, 15);
            this.lblOldTilt.TabIndex = 18;
            this.lblOldTilt.Text = "0°";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Original Angle:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tilt Angle:";
            // 
            // lblTilt
            // 
            this.lblTilt.AutoSize = true;
            this.lblTilt.Location = new System.Drawing.Point(152, 133);
            this.lblTilt.Name = "lblTilt";
            this.lblTilt.Size = new System.Drawing.Size(30, 15);
            this.lblTilt.TabIndex = 15;
            this.lblTilt.Text = "0°";
            // 
            // tbTilt
            // 
            this.tbTilt.Location = new System.Drawing.Point(188, 129);
            this.tbTilt.Maximum = 75;
            this.tbTilt.Name = "tbTilt";
            this.tbTilt.Size = new System.Drawing.Size(185, 56);
            this.tbTilt.TabIndex = 14;
            this.tbTilt.TickFrequency = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Sensor Size:";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(155, 206);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(60, 25);
            this.txtWidth.TabIndex = 20;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(274, 206);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(60, 25);
            this.txtHeight.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "mm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(340, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "mm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Focal Length:";
            // 
            // txtFocal
            // 
            this.txtFocal.Location = new System.Drawing.Point(155, 242);
            this.txtFocal.Name = "txtFocal";
            this.txtFocal.Size = new System.Drawing.Size(60, 25);
            this.txtFocal.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 245);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 15);
            this.label9.TabIndex = 26;
            this.label9.Text = "mm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(155, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 25);
            this.txtName.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 38);
            this.button1.TabIndex = 29;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 339);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtFocal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOldTilt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTilt);
            this.Controls.Add(this.tbTilt);
            this.Controls.Add(this.lblOldPan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPan);
            this.Controls.Add(this.tbPan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmEdit";
            this.Text = "Edit Camera";
            this.Load += new System.EventHandler(this.frmEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbPan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTilt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPan;
        private System.Windows.Forms.TrackBar tbPan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOldPan;
        private System.Windows.Forms.Label lblOldTilt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTilt;
        private System.Windows.Forms.TrackBar tbTilt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFocal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button button1;
    }
}