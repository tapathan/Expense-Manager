namespace ExMon
{
    partial class FrmChangeTransactionTypeCorD
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
            this.LblCorD = new System.Windows.Forms.Label();
            this.CmbCD = new System.Windows.Forms.ComboBox();
            this.LblTransactionType = new System.Windows.Forms.Label();
            this.CmbTransactionHierarchy = new System.Windows.Forms.ComboBox();
            this.GrpTransCD = new System.Windows.Forms.GroupBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.GrpTransCD.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblCorD
            // 
            this.LblCorD.AutoSize = true;
            this.LblCorD.Location = new System.Drawing.Point(34, 80);
            this.LblCorD.Name = "LblCorD";
            this.LblCorD.Size = new System.Drawing.Size(76, 13);
            this.LblCorD.TabIndex = 25;
            this.LblCorD.Text = "Credit Or Debit";
            // 
            // CmbCD
            // 
            this.CmbCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCD.FormattingEnabled = true;
            this.CmbCD.Items.AddRange(new object[] {
            "CREDIT",
            "DEBIT"});
            this.CmbCD.Location = new System.Drawing.Point(132, 47);
            this.CmbCD.Name = "CmbCD";
            this.CmbCD.Size = new System.Drawing.Size(111, 21);
            this.CmbCD.TabIndex = 23;
            // 
            // LblTransactionType
            // 
            this.LblTransactionType.AutoSize = true;
            this.LblTransactionType.Location = new System.Drawing.Point(34, 53);
            this.LblTransactionType.Name = "LblTransactionType";
            this.LblTransactionType.Size = new System.Drawing.Size(111, 13);
            this.LblTransactionType.TabIndex = 24;
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
            // GrpTransCD
            // 
            this.GrpTransCD.Controls.Add(this.CmbCD);
            this.GrpTransCD.Controls.Add(this.CmbTransactionHierarchy);
            this.GrpTransCD.Location = new System.Drawing.Point(27, 30);
            this.GrpTransCD.Name = "GrpTransCD";
            this.GrpTransCD.Size = new System.Drawing.Size(369, 78);
            this.GrpTransCD.TabIndex = 26;
            this.GrpTransCD.TabStop = false;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(264, 114);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(132, 32);
            this.BtnClose.TabIndex = 28;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(27, 114);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(132, 32);
            this.BtnEnter.TabIndex = 27;
            this.BtnEnter.Text = "ENTER";
            this.BtnEnter.UseVisualStyleBackColor = true;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // FrmChangeTransactionTypeCorD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 167);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnEnter);
            this.Controls.Add(this.LblCorD);
            this.Controls.Add(this.LblTransactionType);
            this.Controls.Add(this.GrpTransCD);
            this.Name = "FrmChangeTransactionTypeCorD";
            this.Text = "Change Transaction Type to Credit or Debit";
            this.Load += new System.EventHandler(this.FrmChangeTransactionTypeCorD_Load);
            this.GrpTransCD.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblCorD;
        private System.Windows.Forms.ComboBox CmbCD;
        private System.Windows.Forms.Label LblTransactionType;
        private System.Windows.Forms.ComboBox CmbTransactionHierarchy;
        private System.Windows.Forms.GroupBox GrpTransCD;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnEnter;
    }
}