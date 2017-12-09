namespace ExMon
{
    partial class FrmDimType1Generic
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
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.GrpBox = new System.Windows.Forms.GroupBox();
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
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // TransFlex
            // 
            this.TransFlex.AllowUserToAddRows = false;
            this.TransFlex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransFlex.Location = new System.Drawing.Point(45, 29);
            this.TransFlex.Name = "TransFlex";
            this.TransFlex.Size = new System.Drawing.Size(978, 314);
            this.TransFlex.TabIndex = 13;
            this.TransFlex.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransFlex_CellClick);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(332, 536);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(130, 48);
            this.BtnUpdate.TabIndex = 3;
            this.BtnUpdate.Text = "UPDATE";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click_1);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(185, 536);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(130, 48);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "DELETE";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click_1);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(38, 536);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(130, 48);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "ADD";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click_1);
            // 
            // GrpBox
            // 
            this.GrpBox.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox.Controls.Add(this.BtnExit);
            this.GrpBox.Controls.Add(this.BtnUpdate);
            this.GrpBox.Controls.Add(this.BtnDelete);
            this.GrpBox.Controls.Add(this.BtnAdd);
            this.GrpBox.Location = new System.Drawing.Point(12, 10);
            this.GrpBox.Name = "GrpBox";
            this.GrpBox.Size = new System.Drawing.Size(1031, 591);
            this.GrpBox.TabIndex = 14;
            this.GrpBox.TabStop = false;
            // 
            // FrmDimType1Generic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 604);
            this.Controls.Add(this.TransFlex);
            this.Controls.Add(this.GrpBox);
            this.Name = "FrmDimType1Generic";
            this.Text = "FrmDimType1Generic";
            this.Load += new System.EventHandler(this.FrmDimType1Generic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransFlex)).EndInit();
            this.GrpBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.DataGridView TransFlex;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.GroupBox GrpBox;
    }
}