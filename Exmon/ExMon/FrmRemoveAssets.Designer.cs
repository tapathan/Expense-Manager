namespace ExMon
{
    partial class FrmRemoveAssets
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRemove = new System.Windows.Forms.Button();
            this.LblHierarchy = new System.Windows.Forms.Label();
            this.GrpHierarchy = new System.Windows.Forms.GroupBox();
            this.GrpAssets = new System.Windows.Forms.GroupBox();
            this.DGVAssets = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.CmbHierarchy = new System.Windows.Forms.ComboBox();
            this.GrpHierarchy.SuspendLayout();
            this.GrpAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAssets)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(18, 445);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(134, 42);
            this.btnRemove.TabIndex = 27;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // LblHierarchy
            // 
            this.LblHierarchy.AutoSize = true;
            this.LblHierarchy.Location = new System.Drawing.Point(4, 16);
            this.LblHierarchy.Name = "LblHierarchy";
            this.LblHierarchy.Size = new System.Drawing.Size(52, 13);
            this.LblHierarchy.TabIndex = 14;
            this.LblHierarchy.Text = "Hierarchy";
            // 
            // GrpHierarchy
            // 
            this.GrpHierarchy.Controls.Add(this.CmbHierarchy);
            this.GrpHierarchy.Controls.Add(this.LblHierarchy);
            this.GrpHierarchy.Location = new System.Drawing.Point(18, 16);
            this.GrpHierarchy.Name = "GrpHierarchy";
            this.GrpHierarchy.Size = new System.Drawing.Size(313, 38);
            this.GrpHierarchy.TabIndex = 26;
            this.GrpHierarchy.TabStop = false;
            // 
            // GrpAssets
            // 
            this.GrpAssets.Controls.Add(this.DGVAssets);
            this.GrpAssets.Location = new System.Drawing.Point(19, 54);
            this.GrpAssets.Name = "GrpAssets";
            this.GrpAssets.Size = new System.Drawing.Size(707, 385);
            this.GrpAssets.TabIndex = 24;
            this.GrpAssets.TabStop = false;
            // 
            // DGVAssets
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAssets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.DGVAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVAssets.DefaultCellStyle = dataGridViewCellStyle14;
            this.DGVAssets.Location = new System.Drawing.Point(7, 18);
            this.DGVAssets.Name = "DGVAssets";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAssets.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DGVAssets.Size = new System.Drawing.Size(692, 359);
            this.DGVAssets.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(592, 445);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 42);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CmbHierarchy
            // 
            this.CmbHierarchy.FormattingEnabled = true;
            this.CmbHierarchy.Location = new System.Drawing.Point(72, 11);
            this.CmbHierarchy.Name = "CmbHierarchy";
            this.CmbHierarchy.Size = new System.Drawing.Size(232, 21);
            this.CmbHierarchy.TabIndex = 15;
            this.CmbHierarchy.SelectedIndexChanged += new System.EventHandler(this.CmbHierarchy_SelectedIndexChanged);
            // 
            // FrmRemoveAssets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 501);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.GrpHierarchy);
            this.Controls.Add(this.GrpAssets);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmRemoveAssets";
            this.Text = "Remove from Assets";
            this.Load += new System.EventHandler(this.FrmRemoveAssets_Load);
            this.GrpHierarchy.ResumeLayout(false);
            this.GrpHierarchy.PerformLayout();
            this.GrpAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAssets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label LblHierarchy;
        private System.Windows.Forms.GroupBox GrpHierarchy;
        private System.Windows.Forms.GroupBox GrpAssets;
        private System.Windows.Forms.DataGridView DGVAssets;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox CmbHierarchy;
    }
}