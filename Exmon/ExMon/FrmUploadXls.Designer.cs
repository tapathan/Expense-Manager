namespace ExMon
{
    partial class FrmUploadXls
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
            this.DGVXls = new System.Windows.Forms.DataGridView();
            this.GrpTransactions = new System.Windows.Forms.GroupBox();
            this.BtnBrowseFile = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVXls)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVXls
            // 
            this.DGVXls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVXls.Location = new System.Drawing.Point(18, 81);
            this.DGVXls.Name = "DGVXls";
            this.DGVXls.Size = new System.Drawing.Size(828, 448);
            this.DGVXls.TabIndex = 0;
            // 
            // GrpTransactions
            // 
            this.GrpTransactions.Location = new System.Drawing.Point(12, 62);
            this.GrpTransactions.Name = "GrpTransactions";
            this.GrpTransactions.Size = new System.Drawing.Size(840, 473);
            this.GrpTransactions.TabIndex = 1;
            this.GrpTransactions.TabStop = false;
            this.GrpTransactions.Text = "Transactions";
            // 
            // BtnBrowseFile
            // 
            this.BtnBrowseFile.Location = new System.Drawing.Point(18, 21);
            this.BtnBrowseFile.Name = "BtnBrowseFile";
            this.BtnBrowseFile.Size = new System.Drawing.Size(173, 35);
            this.BtnBrowseFile.TabIndex = 2;
            this.BtnBrowseFile.Text = "Browse Xls File";
            this.BtnBrowseFile.UseVisualStyleBackColor = true;
            this.BtnBrowseFile.Click += new System.EventHandler(this.BtnBrowseFile_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(673, 547);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(173, 35);
            this.BtnClose.TabIndex = 3;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(18, 547);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(173, 35);
            this.BtnImport.TabIndex = 4;
            this.BtnImport.Text = "IMPORT";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // FrmUploadXls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 594);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnBrowseFile);
            this.Controls.Add(this.DGVXls);
            this.Controls.Add(this.GrpTransactions);
            this.Name = "FrmUploadXls";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmUploadXls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVXls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVXls;
        private System.Windows.Forms.GroupBox GrpTransactions;
        private System.Windows.Forms.Button BtnBrowseFile;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnImport;
    }
}