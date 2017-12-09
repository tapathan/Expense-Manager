namespace ExMon
{
    partial class FrmMajorEvents
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
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.GrpMajorEvent = new System.Windows.Forms.GroupBox();
            this.LblIsHoliday = new System.Windows.Forms.Label();
            this.CmbIsHoliday = new System.Windows.Forms.ComboBox();
            this.LblMajorEvent = new System.Windows.Forms.Label();
            this.TxtMajorEvent = new System.Windows.Forms.TextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.GrpMajorEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "dd/MM/yyyy";
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDate.Location = new System.Drawing.Point(192, 19);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.ShowUpDown = true;
            this.DtpDate.Size = new System.Drawing.Size(95, 20);
            this.DtpDate.TabIndex = 3;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(145, 21);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(30, 13);
            this.LblDate.TabIndex = 2;
            this.LblDate.Text = "Date";
            // 
            // GrpMajorEvent
            // 
            this.GrpMajorEvent.Controls.Add(this.LblIsHoliday);
            this.GrpMajorEvent.Controls.Add(this.CmbIsHoliday);
            this.GrpMajorEvent.Controls.Add(this.LblMajorEvent);
            this.GrpMajorEvent.Controls.Add(this.TxtMajorEvent);
            this.GrpMajorEvent.Controls.Add(this.DtpDate);
            this.GrpMajorEvent.Controls.Add(this.LblDate);
            this.GrpMajorEvent.Location = new System.Drawing.Point(18, 7);
            this.GrpMajorEvent.Name = "GrpMajorEvent";
            this.GrpMajorEvent.Size = new System.Drawing.Size(302, 122);
            this.GrpMajorEvent.TabIndex = 4;
            this.GrpMajorEvent.TabStop = false;
            // 
            // LblIsHoliday
            // 
            this.LblIsHoliday.AutoSize = true;
            this.LblIsHoliday.Location = new System.Drawing.Point(28, 92);
            this.LblIsHoliday.Name = "LblIsHoliday";
            this.LblIsHoliday.Size = new System.Drawing.Size(88, 13);
            this.LblIsHoliday.TabIndex = 18;
            this.LblIsHoliday.Text = "Is Holiday (Y/N)?";
            // 
            // CmbIsHoliday
            // 
            this.CmbIsHoliday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIsHoliday.FormattingEnabled = true;
            this.CmbIsHoliday.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.CmbIsHoliday.Location = new System.Drawing.Point(126, 89);
            this.CmbIsHoliday.Name = "CmbIsHoliday";
            this.CmbIsHoliday.Size = new System.Drawing.Size(108, 21);
            this.CmbIsHoliday.TabIndex = 17;
            // 
            // LblMajorEvent
            // 
            this.LblMajorEvent.AutoSize = true;
            this.LblMajorEvent.Location = new System.Drawing.Point(28, 57);
            this.LblMajorEvent.Name = "LblMajorEvent";
            this.LblMajorEvent.Size = new System.Drawing.Size(64, 13);
            this.LblMajorEvent.TabIndex = 16;
            this.LblMajorEvent.Text = "Major Event";
            // 
            // TxtMajorEvent
            // 
            this.TxtMajorEvent.Location = new System.Drawing.Point(126, 54);
            this.TxtMajorEvent.Name = "TxtMajorEvent";
            this.TxtMajorEvent.Size = new System.Drawing.Size(161, 20);
            this.TxtMajorEvent.TabIndex = 15;
            this.TxtMajorEvent.TextChanged += new System.EventHandler(this.TxtMajorEvent_TextChanged);
            this.TxtMajorEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtMajorEvent_KeyPress);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(188, 140);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(132, 32);
            this.BtnClose.TabIndex = 20;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(18, 140);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(132, 32);
            this.BtnEnter.TabIndex = 19;
            this.BtnEnter.Text = "ENTER";
            this.BtnEnter.UseVisualStyleBackColor = true;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // FrmMajorEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 186);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.GrpMajorEvent);
            this.Controls.Add(this.BtnEnter);
            this.Name = "FrmMajorEvents";
            this.Text = "FrmMajorEvents";
            this.Load += new System.EventHandler(this.FrmMajorEvents_Load);
            this.GrpMajorEvent.ResumeLayout(false);
            this.GrpMajorEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.GroupBox GrpMajorEvent;
        private System.Windows.Forms.Label LblIsHoliday;
        private System.Windows.Forms.ComboBox CmbIsHoliday;
        private System.Windows.Forms.Label LblMajorEvent;
        private System.Windows.Forms.TextBox TxtMajorEvent;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnEnter;
    }
}