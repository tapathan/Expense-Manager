namespace ExMon
{
    partial class FrmDimGeneric
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
            this.BtnExit = new System.Windows.Forms.Button();
            this.TransFlex = new System.Windows.Forms.DataGridView();
            this.LblDt = new System.Windows.Forms.Label();
            this.DtpCurrDate = new System.Windows.Forms.DateTimePicker();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.GrpBox = new System.Windows.Forms.GroupBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TransFlex)).BeginInit();
            this.GrpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(881, 536);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(130, 48);
            this.BtnExit.TabIndex = 5;
            this.BtnExit.Text = "EXIT";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click_2);
            // 
            // TransFlex
            // 
            this.TransFlex.AllowUserToAddRows = false;
            this.TransFlex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransFlex.Location = new System.Drawing.Point(41, 47);
            this.TransFlex.Name = "TransFlex";
            this.TransFlex.Size = new System.Drawing.Size(978, 291);
            this.TransFlex.TabIndex = 11;
            this.TransFlex.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransFlex_CellClick_1);
            // 
            // LblDt
            // 
            this.LblDt.AutoSize = true;
            this.LblDt.Location = new System.Drawing.Point(34, 16);
            this.LblDt.Name = "LblDt";
            this.LblDt.Size = new System.Drawing.Size(30, 13);
            this.LblDt.TabIndex = 9;
            this.LblDt.Text = "Date";
            // 
            // DtpCurrDate
            // 
            this.DtpCurrDate.CustomFormat = "dd/MM/yyyy";
            this.DtpCurrDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpCurrDate.Location = new System.Drawing.Point(91, 16);
            this.DtpCurrDate.Name = "DtpCurrDate";
            this.DtpCurrDate.Size = new System.Drawing.Size(85, 20);
            this.DtpCurrDate.TabIndex = 8;
            this.DtpCurrDate.ValueChanged += new System.EventHandler(this.DtpCurrDate_ValueChanged_1);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(332, 536);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(130, 48);
            this.BtnUpdate.TabIndex = 3;
            this.BtnUpdate.Text = "UPDATE";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // GrpBox
            // 
            this.GrpBox.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox.Controls.Add(this.BtnExit);
            this.GrpBox.Controls.Add(this.LblDt);
            this.GrpBox.Controls.Add(this.DtpCurrDate);
            this.GrpBox.Controls.Add(this.BtnUpdate);
            this.GrpBox.Controls.Add(this.BtnDelete);
            this.GrpBox.Controls.Add(this.BtnAdd);
            this.GrpBox.Location = new System.Drawing.Point(8, 5);
            this.GrpBox.Name = "GrpBox";
            this.GrpBox.Size = new System.Drawing.Size(1031, 591);
            this.GrpBox.TabIndex = 12;
            this.GrpBox.TabStop = false;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(185, 536);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(130, 48);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "DELETE";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(38, 536);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(130, 48);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "ADD";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // FrmDimGeneric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 693);
            this.Controls.Add(this.TransFlex);
            this.Controls.Add(this.GrpBox);
            this.Name = "FrmDimGeneric";
            this.Text = "FrmDimGeneric";
            this.Load += new System.EventHandler(this.FrmDimGeneric_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransFlex)).EndInit();
            this.GrpBox.ResumeLayout(false);
            this.GrpBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.DataGridView TransFlex;
        private System.Windows.Forms.Label LblDt;
        private System.Windows.Forms.DateTimePicker DtpCurrDate;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.GroupBox GrpBox;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAdd;
    }
}