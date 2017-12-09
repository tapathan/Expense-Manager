namespace ExMon
{
    partial class FrmDeleteUser
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
            this.GrpDeleteUser = new System.Windows.Forms.GroupBox();
            this.CmbUsername = new System.Windows.Forms.ComboBox();
            this.LblUsername = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.GrpDeleteUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpDeleteUser
            // 
            this.GrpDeleteUser.Controls.Add(this.LblUsername);
            this.GrpDeleteUser.Controls.Add(this.CmbUsername);
            this.GrpDeleteUser.Location = new System.Drawing.Point(23, 22);
            this.GrpDeleteUser.Name = "GrpDeleteUser";
            this.GrpDeleteUser.Size = new System.Drawing.Size(272, 72);
            this.GrpDeleteUser.TabIndex = 0;
            this.GrpDeleteUser.TabStop = false;
            this.GrpDeleteUser.Text = "Select User to Delete";
            // 
            // CmbUsername
            // 
            this.CmbUsername.FormattingEnabled = true;
            this.CmbUsername.Location = new System.Drawing.Point(105, 29);
            this.CmbUsername.Name = "CmbUsername";
            this.CmbUsername.Size = new System.Drawing.Size(151, 21);
            this.CmbUsername.TabIndex = 0;
            // 
            // LblUsername
            // 
            this.LblUsername.AutoSize = true;
            this.LblUsername.Location = new System.Drawing.Point(29, 32);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(55, 13);
            this.LblUsername.TabIndex = 1;
            this.LblUsername.Text = "Username";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(23, 100);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(102, 35);
            this.BtnDelete.TabIndex = 1;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(193, 101);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(102, 35);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // FrmDeleteUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 148);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.GrpDeleteUser);
            this.Name = "FrmDeleteUser";
            this.Text = "FrmDeleteUser";
            this.Load += new System.EventHandler(this.FrmDeleteUser_Load);
            this.GrpDeleteUser.ResumeLayout(false);
            this.GrpDeleteUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpDeleteUser;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.ComboBox CmbUsername;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnClose;
    }
}