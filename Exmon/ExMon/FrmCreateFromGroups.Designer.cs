namespace ExMon
{
    partial class FrmCreateFromGroups
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GrpFormTitle = new System.Windows.Forms.GroupBox();
            this.CmbFormTitle = new System.Windows.Forms.ComboBox();
            this.LblFormTitle = new System.Windows.Forms.Label();
            this.GrpGroupFields = new System.Windows.Forms.GroupBox();
            this.DGVGroupFields = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrpCriteriaFields = new System.Windows.Forms.GroupBox();
            this.DGVCriteria = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAppendCriteria = new System.Windows.Forms.Button();
            this.BtnCreateGroup = new System.Windows.Forms.Button();
            this.GrpGroupName = new System.Windows.Forms.GroupBox();
            this.TxtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrpFormTitle.SuspendLayout();
            this.GrpGroupFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGroupFields)).BeginInit();
            this.GrpCriteriaFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCriteria)).BeginInit();
            this.GrpGroupName.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpFormTitle
            // 
            this.GrpFormTitle.Controls.Add(this.CmbFormTitle);
            this.GrpFormTitle.Controls.Add(this.LblFormTitle);
            this.GrpFormTitle.Location = new System.Drawing.Point(26, 24);
            this.GrpFormTitle.Name = "GrpFormTitle";
            this.GrpFormTitle.Size = new System.Drawing.Size(272, 45);
            this.GrpFormTitle.TabIndex = 8;
            this.GrpFormTitle.TabStop = false;
            // 
            // CmbFormTitle
            // 
            this.CmbFormTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFormTitle.FormattingEnabled = true;
            this.CmbFormTitle.Location = new System.Drawing.Point(81, 16);
            this.CmbFormTitle.Name = "CmbFormTitle";
            this.CmbFormTitle.Size = new System.Drawing.Size(185, 21);
            this.CmbFormTitle.TabIndex = 6;
            this.CmbFormTitle.SelectedIndexChanged += new System.EventHandler(this.CmbFormTitle_SelectedIndexChanged);
            // 
            // LblFormTitle
            // 
            this.LblFormTitle.AutoSize = true;
            this.LblFormTitle.Location = new System.Drawing.Point(12, 19);
            this.LblFormTitle.Name = "LblFormTitle";
            this.LblFormTitle.Size = new System.Drawing.Size(53, 13);
            this.LblFormTitle.TabIndex = 0;
            this.LblFormTitle.Text = "Form Title";
            // 
            // GrpGroupFields
            // 
            this.GrpGroupFields.Controls.Add(this.DGVGroupFields);
            this.GrpGroupFields.Location = new System.Drawing.Point(26, 85);
            this.GrpGroupFields.Name = "GrpGroupFields";
            this.GrpGroupFields.Size = new System.Drawing.Size(376, 290);
            this.GrpGroupFields.TabIndex = 10;
            this.GrpGroupFields.TabStop = false;
            this.GrpGroupFields.Text = "Group Fields";
            // 
            // DGVGroupFields
            // 
            this.DGVGroupFields.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVGroupFields.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVGroupFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGroupFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVGroupFields.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVGroupFields.Location = new System.Drawing.Point(9, 16);
            this.DGVGroupFields.Name = "DGVGroupFields";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVGroupFields.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVGroupFields.Size = new System.Drawing.Size(359, 267);
            this.DGVGroupFields.TabIndex = 2;
            this.DGVGroupFields.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVGroupFields_RowHeaderMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Table Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 157;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Field Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 160;
            // 
            // GrpCriteriaFields
            // 
            this.GrpCriteriaFields.Controls.Add(this.DGVCriteria);
            this.GrpCriteriaFields.Location = new System.Drawing.Point(524, 85);
            this.GrpCriteriaFields.Name = "GrpCriteriaFields";
            this.GrpCriteriaFields.Size = new System.Drawing.Size(376, 290);
            this.GrpCriteriaFields.TabIndex = 11;
            this.GrpCriteriaFields.TabStop = false;
            this.GrpCriteriaFields.Text = "Criteria Fields";
            // 
            // DGVCriteria
            // 
            this.DGVCriteria.AllowUserToAddRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCriteria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCriteria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCriteria.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGVCriteria.Location = new System.Drawing.Point(9, 16);
            this.DGVCriteria.Name = "DGVCriteria";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCriteria.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVCriteria.Size = new System.Drawing.Size(359, 267);
            this.DGVCriteria.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Table Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 157;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Field Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 160;
            // 
            // BtnAppendCriteria
            // 
            this.BtnAppendCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAppendCriteria.Location = new System.Drawing.Point(419, 215);
            this.BtnAppendCriteria.Name = "BtnAppendCriteria";
            this.BtnAppendCriteria.Size = new System.Drawing.Size(87, 35);
            this.BtnAppendCriteria.TabIndex = 16;
            this.BtnAppendCriteria.Text = "<<";
            this.BtnAppendCriteria.UseVisualStyleBackColor = true;
            this.BtnAppendCriteria.Click += new System.EventHandler(this.BtnAppendCriteria_Click);
            // 
            // BtnCreateGroup
            // 
            this.BtnCreateGroup.Location = new System.Drawing.Point(26, 390);
            this.BtnCreateGroup.Name = "BtnCreateGroup";
            this.BtnCreateGroup.Size = new System.Drawing.Size(129, 35);
            this.BtnCreateGroup.TabIndex = 17;
            this.BtnCreateGroup.Text = "CREATE GROUP";
            this.BtnCreateGroup.UseVisualStyleBackColor = true;
            this.BtnCreateGroup.Click += new System.EventHandler(this.BtnCreateGroup_Click);
            // 
            // GrpGroupName
            // 
            this.GrpGroupName.Controls.Add(this.TxtGroupName);
            this.GrpGroupName.Controls.Add(this.label1);
            this.GrpGroupName.Location = new System.Drawing.Point(323, 24);
            this.GrpGroupName.Name = "GrpGroupName";
            this.GrpGroupName.Size = new System.Drawing.Size(272, 45);
            this.GrpGroupName.TabIndex = 9;
            this.GrpGroupName.TabStop = false;
            // 
            // TxtGroupName
            // 
            this.TxtGroupName.Location = new System.Drawing.Point(96, 16);
            this.TxtGroupName.Name = "TxtGroupName";
            this.TxtGroupName.ReadOnly = true;
            this.TxtGroupName.Size = new System.Drawing.Size(170, 20);
            this.TxtGroupName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group Name";
            // 
            // FrmCreateFromGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 439);
            this.Controls.Add(this.GrpGroupName);
            this.Controls.Add(this.BtnCreateGroup);
            this.Controls.Add(this.BtnAppendCriteria);
            this.Controls.Add(this.GrpCriteriaFields);
            this.Controls.Add(this.GrpGroupFields);
            this.Controls.Add(this.GrpFormTitle);
            this.Name = "FrmCreateFromGroups";
            this.Text = "FrmCreateFromGroups";
            this.Load += new System.EventHandler(this.FrmCreateFromGroups_Load);
            this.GrpFormTitle.ResumeLayout(false);
            this.GrpFormTitle.PerformLayout();
            this.GrpGroupFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVGroupFields)).EndInit();
            this.GrpCriteriaFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCriteria)).EndInit();
            this.GrpGroupName.ResumeLayout(false);
            this.GrpGroupName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpFormTitle;
        private System.Windows.Forms.ComboBox CmbFormTitle;
        private System.Windows.Forms.Label LblFormTitle;
        private System.Windows.Forms.GroupBox GrpGroupFields;
        private System.Windows.Forms.DataGridView DGVGroupFields;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox GrpCriteriaFields;
        private System.Windows.Forms.DataGridView DGVCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button BtnAppendCriteria;
        private System.Windows.Forms.Button BtnCreateGroup;
        private System.Windows.Forms.GroupBox GrpGroupName;
        private System.Windows.Forms.TextBox TxtGroupName;
        private System.Windows.Forms.Label label1;
    }
}