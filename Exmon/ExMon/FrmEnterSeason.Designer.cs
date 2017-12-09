namespace ExMon
{
    partial class FrmEnterSeason
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
            this.TxtSeason = new System.Windows.Forms.TextBox();
            this.LblDt = new System.Windows.Forms.Label();
            this.DtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.GrpSeason = new System.Windows.Forms.GroupBox();
            this.PbrProgress = new System.Windows.Forms.ProgressBar();
            this.LblProgress = new System.Windows.Forms.Label();
            this.GrpSeason.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtSeason
            // 
            this.TxtSeason.Location = new System.Drawing.Point(152, 44);
            this.TxtSeason.Name = "TxtSeason";
            this.TxtSeason.Size = new System.Drawing.Size(115, 20);
            this.TxtSeason.TabIndex = 0;
            this.TxtSeason.TextChanged += new System.EventHandler(this.TxtSeason_TextChanged);
            this.TxtSeason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSeason_KeyPress);
            // 
            // LblDt
            // 
            this.LblDt.AutoSize = true;
            this.LblDt.Location = new System.Drawing.Point(50, 84);
            this.LblDt.Name = "LblDt";
            this.LblDt.Size = new System.Drawing.Size(94, 13);
            this.LblDt.TabIndex = 11;
            this.LblDt.Text = "Season Start Date";
            // 
            // DtpStartDate
            // 
            this.DtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.DtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpStartDate.Location = new System.Drawing.Point(152, 81);
            this.DtpStartDate.Name = "DtpStartDate";
            this.DtpStartDate.Size = new System.Drawing.Size(94, 20);
            this.DtpStartDate.TabIndex = 10;
            this.DtpStartDate.ValueChanged += new System.EventHandler(this.DtpStartDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Season End Date";
            // 
            // DtpEndDate
            // 
            this.DtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.DtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpEndDate.Location = new System.Drawing.Point(152, 117);
            this.DtpEndDate.Name = "DtpEndDate";
            this.DtpEndDate.Size = new System.Drawing.Size(94, 20);
            this.DtpEndDate.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Season";
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(189, 193);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(132, 32);
            this.BtnClose.TabIndex = 16;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(22, 193);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(132, 32);
            this.BtnEnter.TabIndex = 15;
            this.BtnEnter.Text = "ENTER";
            this.BtnEnter.UseVisualStyleBackColor = true;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // GrpSeason
            // 
            this.GrpSeason.Controls.Add(this.LblProgress);
            this.GrpSeason.Controls.Add(this.PbrProgress);
            this.GrpSeason.Location = new System.Drawing.Point(22, 17);
            this.GrpSeason.Name = "GrpSeason";
            this.GrpSeason.Size = new System.Drawing.Size(299, 170);
            this.GrpSeason.TabIndex = 17;
            this.GrpSeason.TabStop = false;
            this.GrpSeason.Text = "Enter Season";
            // 
            // PbrProgress
            // 
            this.PbrProgress.Location = new System.Drawing.Point(93, 142);
            this.PbrProgress.Name = "PbrProgress";
            this.PbrProgress.Size = new System.Drawing.Size(152, 15);
            this.PbrProgress.TabIndex = 0;
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
            // FrmEnterSeason
            // 
            this.AcceptButton = this.BtnEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 230);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnEnter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpEndDate);
            this.Controls.Add(this.LblDt);
            this.Controls.Add(this.DtpStartDate);
            this.Controls.Add(this.TxtSeason);
            this.Controls.Add(this.GrpSeason);
            this.MinimizeBox = false;
            this.Name = "FrmEnterSeason";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmEnterSeason";
            this.Load += new System.EventHandler(this.FrmEnterSeason_Load);
            this.GrpSeason.ResumeLayout(false);
            this.GrpSeason.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtSeason;
        private System.Windows.Forms.Label LblDt;
        private System.Windows.Forms.DateTimePicker DtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnEnter;
        private System.Windows.Forms.GroupBox GrpSeason;
        private System.Windows.Forms.Label LblProgress;
        private System.Windows.Forms.ProgressBar PbrProgress;
    }
}