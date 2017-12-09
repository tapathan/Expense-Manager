namespace ExMon
{
    partial class FrmCreateNewUser
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
            this.GrpCreateNewUser = new System.Windows.Forms.GroupBox();
            this.CmbAccess = new System.Windows.Forms.ComboBox();
            this.LblAccess = new System.Windows.Forms.Label();
            this.LblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.LblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.GrpCreateNewUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpCreateNewUser
            // 
            this.GrpCreateNewUser.Controls.Add(this.CmbAccess);
            this.GrpCreateNewUser.Controls.Add(this.LblAccess);
            this.GrpCreateNewUser.Controls.Add(this.LblConfirmPassword);
            this.GrpCreateNewUser.Controls.Add(this.txtConfirmPassword);
            this.GrpCreateNewUser.Controls.Add(this.LblPassword);
            this.GrpCreateNewUser.Controls.Add(this.txtPassword);
            this.GrpCreateNewUser.Controls.Add(this.LblUsername);
            this.GrpCreateNewUser.Controls.Add(this.txtUsername);
            this.GrpCreateNewUser.Location = new System.Drawing.Point(27, 23);
            this.GrpCreateNewUser.Name = "GrpCreateNewUser";
            this.GrpCreateNewUser.Size = new System.Drawing.Size(324, 142);
            this.GrpCreateNewUser.TabIndex = 0;
            this.GrpCreateNewUser.TabStop = false;
            this.GrpCreateNewUser.Text = "Create New User";
            // 
            // CmbAccess
            // 
            this.CmbAccess.FormattingEnabled = true;
            this.CmbAccess.Items.AddRange(new object[] {
            "FULL",
            "LIMITED",
            "SUPER USER"});
            this.CmbAccess.Location = new System.Drawing.Point(135, 110);
            this.CmbAccess.Name = "CmbAccess";
            this.CmbAccess.Size = new System.Drawing.Size(175, 21);
            this.CmbAccess.TabIndex = 4;
            // 
            // LblAccess
            // 
            this.LblAccess.AutoSize = true;
            this.LblAccess.Location = new System.Drawing.Point(20, 113);
            this.LblAccess.Name = "LblAccess";
            this.LblAccess.Size = new System.Drawing.Size(69, 13);
            this.LblAccess.TabIndex = 24;
            this.LblAccess.Text = "Access Type";
            // 
            // LblConfirmPassword
            // 
            this.LblConfirmPassword.AutoSize = true;
            this.LblConfirmPassword.Location = new System.Drawing.Point(20, 84);
            this.LblConfirmPassword.Name = "LblConfirmPassword";
            this.LblConfirmPassword.Size = new System.Drawing.Size(91, 13);
            this.LblConfirmPassword.TabIndex = 22;
            this.LblConfirmPassword.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(135, 81);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(175, 20);
            this.txtConfirmPassword.TabIndex = 3;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(20, 55);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(53, 13);
            this.LblPassword.TabIndex = 20;
            this.LblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(135, 52);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(175, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // LblUsername
            // 
            this.LblUsername.AutoSize = true;
            this.LblUsername.Location = new System.Drawing.Point(20, 26);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(55, 13);
            this.LblUsername.TabIndex = 19;
            this.LblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(135, 23);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(175, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(222, 172);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(129, 35);
            this.BtnCancel.TabIndex = 26;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(26, 172);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(129, 35);
            this.BtnOk.TabIndex = 25;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // FrmCreateNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 221);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.GrpCreateNewUser);
            this.Controls.Add(this.BtnOk);
            this.Name = "FrmCreateNewUser";
            this.Text = "FrmCreateNewUser";
            this.Load += new System.EventHandler(this.FrmCreateNewUser_Load);
            this.GrpCreateNewUser.ResumeLayout(false);
            this.GrpCreateNewUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpCreateNewUser;
        private System.Windows.Forms.Label LblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label LblAccess;
        private System.Windows.Forms.ComboBox CmbAccess;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
    }
}