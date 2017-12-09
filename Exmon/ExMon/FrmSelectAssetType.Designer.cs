namespace ExMon
{
    partial class FrmSelectAssetType
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
            this.LblDepreciationRate = new System.Windows.Forms.Label();
            this.LblAssetType = new System.Windows.Forms.Label();
            this.CmbAssetType = new System.Windows.Forms.ComboBox();
            this.GrpAsset = new System.Windows.Forms.GroupBox();
            this.TxtDepreciationRate = new System.Windows.Forms.TextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.GrpAsset.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblDepreciationRate
            // 
            this.LblDepreciationRate.AutoSize = true;
            this.LblDepreciationRate.Location = new System.Drawing.Point(30, 67);
            this.LblDepreciationRate.Name = "LblDepreciationRate";
            this.LblDepreciationRate.Size = new System.Drawing.Size(93, 13);
            this.LblDepreciationRate.TabIndex = 25;
            this.LblDepreciationRate.Text = "Depreciation Rate";
            // 
            // LblAssetType
            // 
            this.LblAssetType.AutoSize = true;
            this.LblAssetType.Location = new System.Drawing.Point(30, 40);
            this.LblAssetType.Name = "LblAssetType";
            this.LblAssetType.Size = new System.Drawing.Size(60, 13);
            this.LblAssetType.TabIndex = 24;
            this.LblAssetType.Text = "Asset Type";
            // 
            // CmbAssetType
            // 
            this.CmbAssetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAssetType.FormattingEnabled = true;
            this.CmbAssetType.Location = new System.Drawing.Point(118, 15);
            this.CmbAssetType.Name = "CmbAssetType";
            this.CmbAssetType.Size = new System.Drawing.Size(230, 21);
            this.CmbAssetType.TabIndex = 22;
            this.CmbAssetType.SelectedIndexChanged += new System.EventHandler(this.CmbAssetType_SelectedIndexChanged);
            // 
            // GrpAsset
            // 
            this.GrpAsset.Controls.Add(this.TxtDepreciationRate);
            this.GrpAsset.Controls.Add(this.CmbAssetType);
            this.GrpAsset.Location = new System.Drawing.Point(23, 22);
            this.GrpAsset.Name = "GrpAsset";
            this.GrpAsset.Size = new System.Drawing.Size(358, 73);
            this.GrpAsset.TabIndex = 26;
            this.GrpAsset.TabStop = false;
            // 
            // TxtDepreciationRate
            // 
            this.TxtDepreciationRate.Location = new System.Drawing.Point(118, 42);
            this.TxtDepreciationRate.Name = "TxtDepreciationRate";
            this.TxtDepreciationRate.Size = new System.Drawing.Size(126, 20);
            this.TxtDepreciationRate.TabIndex = 23;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(249, 101);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(132, 32);
            this.BtnClose.TabIndex = 25;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(23, 101);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(132, 32);
            this.BtnOk.TabIndex = 24;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // FrmSelectAssetType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 148);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.LblDepreciationRate);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LblAssetType);
            this.Controls.Add(this.GrpAsset);
            this.Name = "FrmSelectAssetType";
            this.Text = "Select Asset Type";
            this.Load += new System.EventHandler(this.FrmSelectAssetType_Load);
            this.GrpAsset.ResumeLayout(false);
            this.GrpAsset.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblDepreciationRate;
        private System.Windows.Forms.Label LblAssetType;
        private System.Windows.Forms.ComboBox CmbAssetType;
        private System.Windows.Forms.GroupBox GrpAsset;
        private System.Windows.Forms.TextBox TxtDepreciationRate;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnOk;
    }
}