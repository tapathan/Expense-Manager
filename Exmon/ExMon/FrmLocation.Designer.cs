namespace ExMon
{
    partial class FrmLocation
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
            this.BtnEnter = new System.Windows.Forms.Button();
            this.GrpLocation = new System.Windows.Forms.GroupBox();
            this.LblLocation = new System.Windows.Forms.Label();
            this.TxtLocation = new System.Windows.Forms.TextBox();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.GrpLocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(12, 111);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(132, 32);
            this.BtnEnter.TabIndex = 22;
            this.BtnEnter.Text = "ENTER";
            this.BtnEnter.UseVisualStyleBackColor = true;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // GrpLocation
            // 
            this.GrpLocation.Controls.Add(this.LblLocation);
            this.GrpLocation.Controls.Add(this.TxtLocation);
            this.GrpLocation.Controls.Add(this.DtpDate);
            this.GrpLocation.Controls.Add(this.LblDate);
            this.GrpLocation.Location = new System.Drawing.Point(12, 12);
            this.GrpLocation.Name = "GrpLocation";
            this.GrpLocation.Size = new System.Drawing.Size(284, 90);
            this.GrpLocation.TabIndex = 21;
            this.GrpLocation.TabStop = false;
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Location = new System.Drawing.Point(28, 57);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(48, 13);
            this.LblLocation.TabIndex = 16;
            this.LblLocation.Text = "Location";
            // 
            // TxtLocation
            // 
            this.TxtLocation.Location = new System.Drawing.Point(99, 54);
            this.TxtLocation.Name = "TxtLocation";
            this.TxtLocation.Size = new System.Drawing.Size(161, 20);
            this.TxtLocation.TabIndex = 15;
            this.TxtLocation.TextChanged += new System.EventHandler(this.TxtLocation_TextChanged);
            this.TxtLocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLocation_KeyPress);
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "dd/MM/yyyy";
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDate.Location = new System.Drawing.Point(165, 19);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.ShowUpDown = true;
            this.DtpDate.Size = new System.Drawing.Size(95, 20);
            this.DtpDate.TabIndex = 3;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(118, 21);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(30, 13);
            this.LblDate.TabIndex = 2;
            this.LblDate.Text = "Date";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(164, 111);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(132, 32);
            this.BtnClose.TabIndex = 23;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // FrmLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 156);
            this.Controls.Add(this.BtnEnter);
            this.Controls.Add(this.GrpLocation);
            this.Controls.Add(this.BtnClose);
            this.Name = "FrmLocation";
            this.Text = "FrmLocation";
            this.Load += new System.EventHandler(this.FrmLocation_Load);
            this.GrpLocation.ResumeLayout(false);
            this.GrpLocation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnEnter;
        private System.Windows.Forms.GroupBox GrpLocation;
        private System.Windows.Forms.Label LblLocation;
        private System.Windows.Forms.TextBox TxtLocation;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Button BtnClose;
    }
}