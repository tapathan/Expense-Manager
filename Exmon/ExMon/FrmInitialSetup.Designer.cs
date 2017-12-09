namespace ExMon
{
    partial class FrmInitialSetup
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
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.BtnIns = new System.Windows.Forms.Button();
            this.TransflexViewXls = new System.Windows.Forms.DataGridView();
            this.GrpXls = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.TransflexViewXls)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(12, 12);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(176, 35);
            this.btnBrowseFile.TabIndex = 10;
            this.btnBrowseFile.Text = "BROWSE FILE";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // BtnCreate
            // 
            this.BtnCreate.Location = new System.Drawing.Point(12, 600);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(176, 35);
            this.BtnCreate.TabIndex = 9;
            this.BtnCreate.Text = "CREATE (DB and Tables)";
            this.BtnCreate.UseVisualStyleBackColor = true;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // BtnIns
            // 
            this.BtnIns.Location = new System.Drawing.Point(228, 600);
            this.BtnIns.Name = "BtnIns";
            this.BtnIns.Size = new System.Drawing.Size(176, 35);
            this.BtnIns.TabIndex = 8;
            this.BtnIns.Text = "INSERT (Info in Application)";
            this.BtnIns.UseVisualStyleBackColor = true;
            this.BtnIns.Click += new System.EventHandler(this.BtnIns_Click);
            // 
            // TransflexViewXls
            // 
            this.TransflexViewXls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransflexViewXls.Location = new System.Drawing.Point(18, 64);
            this.TransflexViewXls.Name = "TransflexViewXls";
            this.TransflexViewXls.Size = new System.Drawing.Size(1159, 521);
            this.TransflexViewXls.TabIndex = 7;
            // 
            // GrpXls
            // 
            this.GrpXls.Location = new System.Drawing.Point(12, 50);
            this.GrpXls.Name = "GrpXls";
            this.GrpXls.Size = new System.Drawing.Size(1171, 541);
            this.GrpXls.TabIndex = 11;
            this.GrpXls.TabStop = false;
            // 
            // FrmInitialSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 691);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.BtnIns);
            this.Controls.Add(this.TransflexViewXls);
            this.Controls.Add(this.GrpXls);
            this.Name = "FrmInitialSetup";
            this.Text = "Initial Setup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInitialSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransflexViewXls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Button BtnIns;
        private System.Windows.Forms.DataGridView TransflexViewXls;
        private System.Windows.Forms.GroupBox GrpXls;

    }
}