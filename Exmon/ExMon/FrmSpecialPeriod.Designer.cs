namespace ExMon
{
    partial class FrmSpecialPeriod
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.LblProgress = new System.Windows.Forms.Label();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.LblSpecialPeriod = new System.Windows.Forms.Label();
            this.LblEndDt = new System.Windows.Forms.Label();
            this.PbrProgress = new System.Windows.Forms.ProgressBar();
            this.DtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.LblStartDt = new System.Windows.Forms.Label();
            this.DtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.TxtSpecialPeriod = new System.Windows.Forms.TextBox();
            this.GrpSpecialPeriod = new System.Windows.Forms.GroupBox();
            this.GrpSpecialPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(179, 188);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(132, 32);
            this.BtnClose.TabIndex = 25;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblProgress
            // 
            this.LblProgress.AutoSize = true;
            this.LblProgress.Location = new System.Drawing.Point(28, 142);
            this.LblProgress.Name = "LblProgress";
            this.LblProgress.Size = new System.Drawing.Size(48, 13);
            this.LblProgress.TabIndex = 18;
            this.LblProgress.Text = "Progress";
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(12, 188);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(132, 32);
            this.BtnEnter.TabIndex = 24;
            this.BtnEnter.Text = "ENTER";
            this.BtnEnter.UseVisualStyleBackColor = true;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // LblSpecialPeriod
            // 
            this.LblSpecialPeriod.AutoSize = true;
            this.LblSpecialPeriod.Location = new System.Drawing.Point(40, 43);
            this.LblSpecialPeriod.Name = "LblSpecialPeriod";
            this.LblSpecialPeriod.Size = new System.Drawing.Size(75, 13);
            this.LblSpecialPeriod.TabIndex = 23;
            this.LblSpecialPeriod.Text = "Special Period";
            // 
            // LblEndDt
            // 
            this.LblEndDt.AutoSize = true;
            this.LblEndDt.Location = new System.Drawing.Point(40, 115);
            this.LblEndDt.Name = "LblEndDt";
            this.LblEndDt.Size = new System.Drawing.Size(52, 13);
            this.LblEndDt.TabIndex = 22;
            this.LblEndDt.Text = "End Date";
            // 
            // PbrProgress
            // 
            this.PbrProgress.Location = new System.Drawing.Point(93, 142);
            this.PbrProgress.Name = "PbrProgress";
            this.PbrProgress.Size = new System.Drawing.Size(152, 15);
            this.PbrProgress.TabIndex = 0;
            // 
            // DtpEndDate
            // 
            this.DtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.DtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpEndDate.Location = new System.Drawing.Point(142, 112);
            this.DtpEndDate.Name = "DtpEndDate";
            this.DtpEndDate.Size = new System.Drawing.Size(94, 20);
            this.DtpEndDate.TabIndex = 21;
            // 
            // LblStartDt
            // 
            this.LblStartDt.AutoSize = true;
            this.LblStartDt.Location = new System.Drawing.Point(40, 79);
            this.LblStartDt.Name = "LblStartDt";
            this.LblStartDt.Size = new System.Drawing.Size(55, 13);
            this.LblStartDt.TabIndex = 20;
            this.LblStartDt.Text = "Start Date";
            // 
            // DtpStartDate
            // 
            this.DtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.DtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpStartDate.Location = new System.Drawing.Point(142, 76);
            this.DtpStartDate.Name = "DtpStartDate";
            this.DtpStartDate.Size = new System.Drawing.Size(94, 20);
            this.DtpStartDate.TabIndex = 19;
            this.DtpStartDate.ValueChanged += new System.EventHandler(this.DtpStartDate_ValueChanged);
            // 
            // TxtSpecialPeriod
            // 
            this.TxtSpecialPeriod.Location = new System.Drawing.Point(142, 39);
            this.TxtSpecialPeriod.Name = "TxtSpecialPeriod";
            this.TxtSpecialPeriod.Size = new System.Drawing.Size(115, 20);
            this.TxtSpecialPeriod.TabIndex = 18;
            this.TxtSpecialPeriod.TextChanged += new System.EventHandler(this.TxtSpecialPeriod_TextChanged);
            this.TxtSpecialPeriod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSpecialPeriod_KeyPress);
            // 
            // GrpSpecialPeriod
            // 
            this.GrpSpecialPeriod.Controls.Add(this.LblProgress);
            this.GrpSpecialPeriod.Controls.Add(this.PbrProgress);
            this.GrpSpecialPeriod.Location = new System.Drawing.Point(12, 12);
            this.GrpSpecialPeriod.Name = "GrpSpecialPeriod";
            this.GrpSpecialPeriod.Size = new System.Drawing.Size(299, 170);
            this.GrpSpecialPeriod.TabIndex = 26;
            this.GrpSpecialPeriod.TabStop = false;
            this.GrpSpecialPeriod.Text = "Enter Special Period";
            // 
            // FrmSpecialPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 228);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnEnter);
            this.Controls.Add(this.LblSpecialPeriod);
            this.Controls.Add(this.LblEndDt);
            this.Controls.Add(this.DtpEndDate);
            this.Controls.Add(this.LblStartDt);
            this.Controls.Add(this.DtpStartDate);
            this.Controls.Add(this.TxtSpecialPeriod);
            this.Controls.Add(this.GrpSpecialPeriod);
            this.Name = "FrmSpecialPeriod";
            this.Text = "FrmSpecialPeriod";
            this.Load += new System.EventHandler(this.FrmSpecialPeriod_Load);
            this.GrpSpecialPeriod.ResumeLayout(false);
            this.GrpSpecialPeriod.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label LblProgress;
        private System.Windows.Forms.Button BtnEnter;
        private System.Windows.Forms.Label LblSpecialPeriod;
        private System.Windows.Forms.Label LblEndDt;
        private System.Windows.Forms.ProgressBar PbrProgress;
        private System.Windows.Forms.DateTimePicker DtpEndDate;
        private System.Windows.Forms.Label LblStartDt;
        private System.Windows.Forms.DateTimePicker DtpStartDate;
        private System.Windows.Forms.TextBox TxtSpecialPeriod;
        private System.Windows.Forms.GroupBox GrpSpecialPeriod;
    }
}