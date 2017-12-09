namespace ExMon
{
    partial class FrmCompareTransactions
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
            this.DgvTransactions = new System.Windows.Forms.DataGridView();
            this.GrpTransfers = new System.Windows.Forms.GroupBox();
            this.GrpDate = new System.Windows.Forms.GroupBox();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.GrpTransCD = new System.Windows.Forms.GroupBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LblTransactionType = new System.Windows.Forms.Label();
            this.CmbTransactionHierarchy = new System.Windows.Forms.ComboBox();
            this.GrpComparison = new System.Windows.Forms.GroupBox();
            this.DgvComparison = new System.Windows.Forms.DataGridView();
            this.BtnClear = new System.Windows.Forms.Button();
            this.GrpJoinOn = new System.Windows.Forms.GroupBox();
            this.ChkComments = new System.Windows.Forms.CheckBox();
            this.ChkDescription = new System.Windows.Forms.CheckBox();
            this.ChkCategory = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransactions)).BeginInit();
            this.GrpTransfers.SuspendLayout();
            this.GrpDate.SuspendLayout();
            this.GrpTransCD.SuspendLayout();
            this.GrpComparison.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvComparison)).BeginInit();
            this.GrpJoinOn.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvTransactions
            // 
            this.DgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTransactions.Location = new System.Drawing.Point(6, 19);
            this.DgvTransactions.Name = "DgvTransactions";
            this.DgvTransactions.Size = new System.Drawing.Size(568, 426);
            this.DgvTransactions.TabIndex = 0;
            // 
            // GrpTransfers
            // 
            this.GrpTransfers.Controls.Add(this.DgvTransactions);
            this.GrpTransfers.Location = new System.Drawing.Point(28, 119);
            this.GrpTransfers.Name = "GrpTransfers";
            this.GrpTransfers.Size = new System.Drawing.Size(580, 451);
            this.GrpTransfers.TabIndex = 4;
            this.GrpTransfers.TabStop = false;
            this.GrpTransfers.Text = "Transactions";
            // 
            // GrpDate
            // 
            this.GrpDate.Controls.Add(this.DtpDate);
            this.GrpDate.Controls.Add(this.LblDate);
            this.GrpDate.Location = new System.Drawing.Point(28, 12);
            this.GrpDate.Name = "GrpDate";
            this.GrpDate.Size = new System.Drawing.Size(160, 40);
            this.GrpDate.TabIndex = 21;
            this.GrpDate.TabStop = false;
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "dd/MM/yyyy";
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDate.Location = new System.Drawing.Point(72, 13);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.ShowUpDown = true;
            this.DtpDate.Size = new System.Drawing.Size(82, 20);
            this.DtpDate.TabIndex = 18;
            this.DtpDate.ValueChanged += new System.EventHandler(this.DtpDate_ValueChanged);
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(17, 16);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(46, 13);
            this.LblDate.TabIndex = 17;
            this.LblDate.Text = "Till Date";
            // 
            // GrpTransCD
            // 
            this.GrpTransCD.Controls.Add(this.BtnAdd);
            this.GrpTransCD.Controls.Add(this.LblTransactionType);
            this.GrpTransCD.Controls.Add(this.CmbTransactionHierarchy);
            this.GrpTransCD.Location = new System.Drawing.Point(28, 55);
            this.GrpTransCD.Name = "GrpTransCD";
            this.GrpTransCD.Size = new System.Drawing.Size(485, 58);
            this.GrpTransCD.TabIndex = 27;
            this.GrpTransCD.TabStop = false;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(397, 16);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(82, 27);
            this.BtnAdd.TabIndex = 28;
            this.BtnAdd.Text = "ADD";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LblTransactionType
            // 
            this.LblTransactionType.AutoSize = true;
            this.LblTransactionType.Location = new System.Drawing.Point(6, 23);
            this.LblTransactionType.Name = "LblTransactionType";
            this.LblTransactionType.Size = new System.Drawing.Size(111, 13);
            this.LblTransactionType.TabIndex = 25;
            this.LblTransactionType.Text = "Transaction Hierarchy";
            // 
            // CmbTransactionHierarchy
            // 
            this.CmbTransactionHierarchy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTransactionHierarchy.FormattingEnabled = true;
            this.CmbTransactionHierarchy.Location = new System.Drawing.Point(132, 20);
            this.CmbTransactionHierarchy.Name = "CmbTransactionHierarchy";
            this.CmbTransactionHierarchy.Size = new System.Drawing.Size(230, 21);
            this.CmbTransactionHierarchy.TabIndex = 22;
            // 
            // GrpComparison
            // 
            this.GrpComparison.Controls.Add(this.DgvComparison);
            this.GrpComparison.Location = new System.Drawing.Point(614, 119);
            this.GrpComparison.Name = "GrpComparison";
            this.GrpComparison.Size = new System.Drawing.Size(399, 451);
            this.GrpComparison.TabIndex = 5;
            this.GrpComparison.TabStop = false;
            this.GrpComparison.Text = "Comparison Difference";
            // 
            // DgvComparison
            // 
            this.DgvComparison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvComparison.Location = new System.Drawing.Point(6, 19);
            this.DgvComparison.Name = "DgvComparison";
            this.DgvComparison.Size = new System.Drawing.Size(387, 426);
            this.DgvComparison.TabIndex = 0;
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(891, 64);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(122, 43);
            this.BtnClear.TabIndex = 29;
            this.BtnClear.Text = "CLEAR";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // GrpJoinOn
            // 
            this.GrpJoinOn.Controls.Add(this.ChkComments);
            this.GrpJoinOn.Controls.Add(this.ChkDescription);
            this.GrpJoinOn.Controls.Add(this.ChkCategory);
            this.GrpJoinOn.Location = new System.Drawing.Point(528, 55);
            this.GrpJoinOn.Name = "GrpJoinOn";
            this.GrpJoinOn.Size = new System.Drawing.Size(357, 57);
            this.GrpJoinOn.TabIndex = 30;
            this.GrpJoinOn.TabStop = false;
            this.GrpJoinOn.Text = "Join On";
            // 
            // ChkComments
            // 
            this.ChkComments.AutoSize = true;
            this.ChkComments.Location = new System.Drawing.Point(239, 21);
            this.ChkComments.Name = "ChkComments";
            this.ChkComments.Size = new System.Drawing.Size(75, 17);
            this.ChkComments.TabIndex = 2;
            this.ChkComments.Text = "Comments";
            this.ChkComments.UseVisualStyleBackColor = true;
            this.ChkComments.CheckedChanged += new System.EventHandler(this.ChkComments_CheckedChanged);
            // 
            // ChkDescription
            // 
            this.ChkDescription.AutoSize = true;
            this.ChkDescription.Location = new System.Drawing.Point(118, 21);
            this.ChkDescription.Name = "ChkDescription";
            this.ChkDescription.Size = new System.Drawing.Size(79, 17);
            this.ChkDescription.TabIndex = 1;
            this.ChkDescription.Text = "Description";
            this.ChkDescription.UseVisualStyleBackColor = true;
            this.ChkDescription.CheckedChanged += new System.EventHandler(this.ChkDescription_CheckedChanged);
            // 
            // ChkCategory
            // 
            this.ChkCategory.AutoSize = true;
            this.ChkCategory.Location = new System.Drawing.Point(6, 21);
            this.ChkCategory.Name = "ChkCategory";
            this.ChkCategory.Size = new System.Drawing.Size(68, 17);
            this.ChkCategory.TabIndex = 0;
            this.ChkCategory.Text = "Category";
            this.ChkCategory.UseVisualStyleBackColor = true;
            this.ChkCategory.CheckedChanged += new System.EventHandler(this.ChkCategory_CheckedChanged);
            // 
            // FrmCompareTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 593);
            this.Controls.Add(this.GrpJoinOn);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.GrpComparison);
            this.Controls.Add(this.GrpTransCD);
            this.Controls.Add(this.GrpDate);
            this.Controls.Add(this.GrpTransfers);
            this.Name = "FrmCompareTransactions";
            this.Text = "FrmCompareTransactions";
            this.Load += new System.EventHandler(this.FrmCompareTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransactions)).EndInit();
            this.GrpTransfers.ResumeLayout(false);
            this.GrpDate.ResumeLayout(false);
            this.GrpDate.PerformLayout();
            this.GrpTransCD.ResumeLayout(false);
            this.GrpTransCD.PerformLayout();
            this.GrpComparison.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvComparison)).EndInit();
            this.GrpJoinOn.ResumeLayout(false);
            this.GrpJoinOn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvTransactions;
        private System.Windows.Forms.GroupBox GrpTransfers;
        private System.Windows.Forms.GroupBox GrpDate;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.GroupBox GrpTransCD;
        private System.Windows.Forms.ComboBox CmbTransactionHierarchy;
        private System.Windows.Forms.Label LblTransactionType;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.GroupBox GrpComparison;
        private System.Windows.Forms.DataGridView DgvComparison;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.GroupBox GrpJoinOn;
        private System.Windows.Forms.CheckBox ChkComments;
        private System.Windows.Forms.CheckBox ChkDescription;
        private System.Windows.Forms.CheckBox ChkCategory;
    }
}