namespace ExMon
{
    partial class FrmExchangeRate
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
            this.LblBaseCurrency = new System.Windows.Forms.Label();
            this.LblCurreny = new System.Windows.Forms.Label();
            this.GrpMajorEvent = new System.Windows.Forms.GroupBox();
            this.TxtExchangeRate = new System.Windows.Forms.TextBox();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.LblExchangeRate = new System.Windows.Forms.Label();
            this.TxtBaseCurrency = new System.Windows.Forms.TextBox();
            this.GrpMajorEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(182, 162);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(98, 32);
            this.BtnClose.TabIndex = 5;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblBaseCurrency
            // 
            this.LblBaseCurrency.AutoSize = true;
            this.LblBaseCurrency.Location = new System.Drawing.Point(28, 80);
            this.LblBaseCurrency.Name = "LblBaseCurrency";
            this.LblBaseCurrency.Size = new System.Drawing.Size(92, 13);
            this.LblBaseCurrency.TabIndex = 18;
            this.LblBaseCurrency.Text = "To Base Currency";
            // 
            // LblCurreny
            // 
            this.LblCurreny.AutoSize = true;
            this.LblCurreny.Location = new System.Drawing.Point(28, 53);
            this.LblCurreny.Name = "LblCurreny";
            this.LblCurreny.Size = new System.Drawing.Size(49, 13);
            this.LblCurreny.TabIndex = 16;
            this.LblCurreny.Text = "Currency";
            // 
            // GrpMajorEvent
            // 
            this.GrpMajorEvent.Controls.Add(this.TxtBaseCurrency);
            this.GrpMajorEvent.Controls.Add(this.LblExchangeRate);
            this.GrpMajorEvent.Controls.Add(this.CmbCurrency);
            this.GrpMajorEvent.Controls.Add(this.LblBaseCurrency);
            this.GrpMajorEvent.Controls.Add(this.LblCurreny);
            this.GrpMajorEvent.Controls.Add(this.TxtExchangeRate);
            this.GrpMajorEvent.Controls.Add(this.DtpDate);
            this.GrpMajorEvent.Controls.Add(this.LblDate);
            this.GrpMajorEvent.Location = new System.Drawing.Point(12, 12);
            this.GrpMajorEvent.Name = "GrpMajorEvent";
            this.GrpMajorEvent.Size = new System.Drawing.Size(268, 139);
            this.GrpMajorEvent.TabIndex = 21;
            this.GrpMajorEvent.TabStop = false;
            // 
            // TxtExchangeRate
            // 
            this.TxtExchangeRate.Location = new System.Drawing.Point(126, 104);
            this.TxtExchangeRate.Name = "TxtExchangeRate";
            this.TxtExchangeRate.Size = new System.Drawing.Size(108, 20);
            this.TxtExchangeRate.TabIndex = 3;
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "dd/MM/yyyy";
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDate.Location = new System.Drawing.Point(145, 19);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.ShowUpDown = true;
            this.DtpDate.Size = new System.Drawing.Size(89, 20);
            this.DtpDate.TabIndex = 1;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(97, 21);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(30, 13);
            this.LblDate.TabIndex = 6;
            this.LblDate.Text = "Date";
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(12, 162);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(98, 32);
            this.BtnEnter.TabIndex = 4;
            this.BtnEnter.Text = "ENTER";
            this.BtnEnter.UseVisualStyleBackColor = true;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // CmbCurrency
            // 
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.CmbCurrency.Location = new System.Drawing.Point(126, 50);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(108, 21);
            this.CmbCurrency.TabIndex = 2;
            // 
            // LblExchangeRate
            // 
            this.LblExchangeRate.AutoSize = true;
            this.LblExchangeRate.Location = new System.Drawing.Point(28, 107);
            this.LblExchangeRate.Name = "LblExchangeRate";
            this.LblExchangeRate.Size = new System.Drawing.Size(81, 13);
            this.LblExchangeRate.TabIndex = 20;
            this.LblExchangeRate.Text = "Exchange Rate";
            // 
            // TxtBaseCurrency
            // 
            this.TxtBaseCurrency.Enabled = false;
            this.TxtBaseCurrency.Location = new System.Drawing.Point(126, 78);
            this.TxtBaseCurrency.Name = "TxtBaseCurrency";
            this.TxtBaseCurrency.Size = new System.Drawing.Size(108, 20);
            this.TxtBaseCurrency.TabIndex = 21;
            // 
            // FrmExchangeRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 205);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.GrpMajorEvent);
            this.Controls.Add(this.BtnEnter);
            this.Name = "FrmExchangeRate";
            this.Text = "FrmExchangeRate";
            this.Load += new System.EventHandler(this.FrmExchangeRate_Load);
            this.GrpMajorEvent.ResumeLayout(false);
            this.GrpMajorEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label LblBaseCurrency;
        private System.Windows.Forms.Label LblCurreny;
        private System.Windows.Forms.GroupBox GrpMajorEvent;
        private System.Windows.Forms.TextBox TxtExchangeRate;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Button BtnEnter;
        private System.Windows.Forms.Label LblExchangeRate;
        private System.Windows.Forms.ComboBox CmbCurrency;
        private System.Windows.Forms.TextBox TxtBaseCurrency;
    }
}