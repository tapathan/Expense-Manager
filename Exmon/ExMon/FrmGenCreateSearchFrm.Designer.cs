namespace ExMon
{
    partial class FrmGenCreateSearchFrm
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
            this.LblFormTitle = new System.Windows.Forms.Label();
            this.TxtFormTitle = new System.Windows.Forms.TextBox();
            this.DGVCriteria = new System.Windows.Forms.DataGridView();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFrozen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CmbTableName = new System.Windows.Forms.ComboBox();
            this.LblTableName = new System.Windows.Forms.Label();
            this.LstTableFields = new System.Windows.Forms.ListBox();
            this.GrpFormDetails = new System.Windows.Forms.GroupBox();
            this.BtnAppendDisplay = new System.Windows.Forms.Button();
            this.BtnAppendCriteria = new System.Windows.Forms.Button();
            this.BtnCreateFrm = new System.Windows.Forms.Button();
            this.GrpCalculations = new System.Windows.Forms.GroupBox();
            this.BtnProduct = new System.Windows.Forms.Button();
            this.BtnCount = new System.Windows.Forms.Button();
            this.BtnMinimum = new System.Windows.Forms.Button();
            this.BtnMaximum = new System.Windows.Forms.Button();
            this.BtnAverage = new System.Windows.Forms.Button();
            this.BtnSum = new System.Windows.Forms.Button();
            this.GrpTableFields = new System.Windows.Forms.GroupBox();
            this.GrpTableName = new System.Windows.Forms.GroupBox();
            this.GrpDisplayFields = new System.Windows.Forms.GroupBox();
            this.DGVDisplay = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrpCriteria = new System.Windows.Forms.GroupBox();
            this.GrpFormTitle = new System.Windows.Forms.GroupBox();
            this.CmbFormTitle = new System.Windows.Forms.ComboBox();
            this.CmbFont = new System.Windows.Forms.ComboBox();
            this.LblFont = new System.Windows.Forms.Label();
            this.TxtColor = new System.Windows.Forms.TextBox();
            this.TxtSize = new System.Windows.Forms.TextBox();
            this.LblSize = new System.Windows.Forms.Label();
            this.LblColor = new System.Windows.Forms.Label();
            this.CmbAccess = new System.Windows.Forms.ComboBox();
            this.LblAccess = new System.Windows.Forms.Label();
            this.GrpAccess = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCriteria)).BeginInit();
            this.GrpFormDetails.SuspendLayout();
            this.GrpCalculations.SuspendLayout();
            this.GrpTableFields.SuspendLayout();
            this.GrpTableName.SuspendLayout();
            this.GrpDisplayFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDisplay)).BeginInit();
            this.GrpCriteria.SuspendLayout();
            this.GrpFormTitle.SuspendLayout();
            this.GrpAccess.SuspendLayout();
            this.SuspendLayout();
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
            // TxtFormTitle
            // 
            this.TxtFormTitle.Location = new System.Drawing.Point(71, 16);
            this.TxtFormTitle.Name = "TxtFormTitle";
            this.TxtFormTitle.Size = new System.Drawing.Size(183, 20);
            this.TxtFormTitle.TabIndex = 1;
            // 
            // DGVCriteria
            // 
            this.DGVCriteria.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCriteria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVCriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCriteria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TableName,
            this.FieldName,
            this.IsFrozen});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVCriteria.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVCriteria.Location = new System.Drawing.Point(9, 18);
            this.DGVCriteria.Name = "DGVCriteria";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCriteria.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVCriteria.Size = new System.Drawing.Size(359, 265);
            this.DGVCriteria.TabIndex = 2;
            this.DGVCriteria.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVCriteria_RowHeaderMouseDoubleClick);
            this.DGVCriteria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCriteria_CellContentClick);
            // 
            // TableName
            // 
            this.TableName.Frozen = true;
            this.TableName.HeaderText = "Table Name";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            this.TableName.Width = 136;
            // 
            // FieldName
            // 
            this.FieldName.Frozen = true;
            this.FieldName.HeaderText = "Field Name";
            this.FieldName.Name = "FieldName";
            this.FieldName.ReadOnly = true;
            this.FieldName.Width = 140;
            // 
            // IsFrozen
            // 
            this.IsFrozen.HeaderText = "Frozen";
            this.IsFrozen.Name = "IsFrozen";
            this.IsFrozen.ReadOnly = true;
            this.IsFrozen.Width = 40;
            // 
            // CmbTableName
            // 
            this.CmbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTableName.FormattingEnabled = true;
            this.CmbTableName.Location = new System.Drawing.Point(100, 15);
            this.CmbTableName.Name = "CmbTableName";
            this.CmbTableName.Size = new System.Drawing.Size(196, 21);
            this.CmbTableName.TabIndex = 4;
            this.CmbTableName.SelectedIndexChanged += new System.EventHandler(this.CmbTableName_SelectedIndexChanged);
            // 
            // LblTableName
            // 
            this.LblTableName.AutoSize = true;
            this.LblTableName.Location = new System.Drawing.Point(13, 18);
            this.LblTableName.Name = "LblTableName";
            this.LblTableName.Size = new System.Drawing.Size(65, 13);
            this.LblTableName.TabIndex = 5;
            this.LblTableName.Text = "Table Name";
            // 
            // LstTableFields
            // 
            this.LstTableFields.FormattingEnabled = true;
            this.LstTableFields.Location = new System.Drawing.Point(6, 16);
            this.LstTableFields.Name = "LstTableFields";
            this.LstTableFields.Size = new System.Drawing.Size(290, 303);
            this.LstTableFields.TabIndex = 6;
            // 
            // GrpFormDetails
            // 
            this.GrpFormDetails.Controls.Add(this.GrpAccess);
            this.GrpFormDetails.Controls.Add(this.BtnAppendDisplay);
            this.GrpFormDetails.Controls.Add(this.BtnAppendCriteria);
            this.GrpFormDetails.Controls.Add(this.BtnCreateFrm);
            this.GrpFormDetails.Controls.Add(this.GrpCalculations);
            this.GrpFormDetails.Controls.Add(this.GrpTableFields);
            this.GrpFormDetails.Controls.Add(this.GrpTableName);
            this.GrpFormDetails.Controls.Add(this.GrpDisplayFields);
            this.GrpFormDetails.Controls.Add(this.GrpCriteria);
            this.GrpFormDetails.Controls.Add(this.GrpFormTitle);
            this.GrpFormDetails.Location = new System.Drawing.Point(14, 14);
            this.GrpFormDetails.Name = "GrpFormDetails";
            this.GrpFormDetails.Size = new System.Drawing.Size(847, 631);
            this.GrpFormDetails.TabIndex = 7;
            this.GrpFormDetails.TabStop = false;
            this.GrpFormDetails.Text = "Form Details";
            // 
            // BtnAppendDisplay
            // 
            this.BtnAppendDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAppendDisplay.Location = new System.Drawing.Point(418, 443);
            this.BtnAppendDisplay.Name = "BtnAppendDisplay";
            this.BtnAppendDisplay.Size = new System.Drawing.Size(87, 35);
            this.BtnAppendDisplay.TabIndex = 16;
            this.BtnAppendDisplay.Text = "<<";
            this.BtnAppendDisplay.UseVisualStyleBackColor = true;
            this.BtnAppendDisplay.Click += new System.EventHandler(this.BtnAppendDisplay_Click);
            // 
            // BtnAppendCriteria
            // 
            this.BtnAppendCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAppendCriteria.Location = new System.Drawing.Point(418, 136);
            this.BtnAppendCriteria.Name = "BtnAppendCriteria";
            this.BtnAppendCriteria.Size = new System.Drawing.Size(87, 35);
            this.BtnAppendCriteria.TabIndex = 15;
            this.BtnAppendCriteria.Text = "<<";
            this.BtnAppendCriteria.UseVisualStyleBackColor = true;
            this.BtnAppendCriteria.Click += new System.EventHandler(this.BtnAppendCriteria_Click);
            // 
            // BtnCreateFrm
            // 
            this.BtnCreateFrm.Location = new System.Drawing.Point(700, 23);
            this.BtnCreateFrm.Name = "BtnCreateFrm";
            this.BtnCreateFrm.Size = new System.Drawing.Size(129, 35);
            this.BtnCreateFrm.TabIndex = 14;
            this.BtnCreateFrm.Text = "CREATE FORM";
            this.BtnCreateFrm.UseVisualStyleBackColor = true;
            this.BtnCreateFrm.Click += new System.EventHandler(this.BtnCreateFrm_Click);
            // 
            // GrpCalculations
            // 
            this.GrpCalculations.Controls.Add(this.BtnProduct);
            this.GrpCalculations.Controls.Add(this.BtnCount);
            this.GrpCalculations.Controls.Add(this.BtnMinimum);
            this.GrpCalculations.Controls.Add(this.BtnMaximum);
            this.GrpCalculations.Controls.Add(this.BtnAverage);
            this.GrpCalculations.Controls.Add(this.BtnSum);
            this.GrpCalculations.Location = new System.Drawing.Point(418, 494);
            this.GrpCalculations.Name = "GrpCalculations";
            this.GrpCalculations.Size = new System.Drawing.Size(411, 134);
            this.GrpCalculations.TabIndex = 13;
            this.GrpCalculations.TabStop = false;
            this.GrpCalculations.Text = "Calculations";
            // 
            // BtnProduct
            // 
            this.BtnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProduct.Location = new System.Drawing.Point(282, 77);
            this.BtnProduct.Name = "BtnProduct";
            this.BtnProduct.Size = new System.Drawing.Size(121, 45);
            this.BtnProduct.TabIndex = 22;
            this.BtnProduct.Text = "PRODUCT";
            this.BtnProduct.UseVisualStyleBackColor = true;
            this.BtnProduct.Click += new System.EventHandler(this.BtnProduct_Click);
            // 
            // BtnCount
            // 
            this.BtnCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCount.Location = new System.Drawing.Point(145, 77);
            this.BtnCount.Name = "BtnCount";
            this.BtnCount.Size = new System.Drawing.Size(121, 45);
            this.BtnCount.TabIndex = 21;
            this.BtnCount.Text = "COUNT";
            this.BtnCount.UseVisualStyleBackColor = true;
            this.BtnCount.Click += new System.EventHandler(this.BtnCount_Click);
            // 
            // BtnMinimum
            // 
            this.BtnMinimum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMinimum.Location = new System.Drawing.Point(6, 77);
            this.BtnMinimum.Name = "BtnMinimum";
            this.BtnMinimum.Size = new System.Drawing.Size(121, 45);
            this.BtnMinimum.TabIndex = 20;
            this.BtnMinimum.Text = "MIN";
            this.BtnMinimum.UseVisualStyleBackColor = true;
            this.BtnMinimum.Click += new System.EventHandler(this.BtnMinimum_Click);
            // 
            // BtnMaximum
            // 
            this.BtnMaximum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMaximum.Location = new System.Drawing.Point(282, 19);
            this.BtnMaximum.Name = "BtnMaximum";
            this.BtnMaximum.Size = new System.Drawing.Size(121, 45);
            this.BtnMaximum.TabIndex = 19;
            this.BtnMaximum.Text = "MAX";
            this.BtnMaximum.UseVisualStyleBackColor = true;
            this.BtnMaximum.Click += new System.EventHandler(this.BtnMaximum_Click);
            // 
            // BtnAverage
            // 
            this.BtnAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAverage.Location = new System.Drawing.Point(145, 19);
            this.BtnAverage.Name = "BtnAverage";
            this.BtnAverage.Size = new System.Drawing.Size(121, 45);
            this.BtnAverage.TabIndex = 18;
            this.BtnAverage.Text = "AVG";
            this.BtnAverage.UseVisualStyleBackColor = true;
            this.BtnAverage.Click += new System.EventHandler(this.BtnAverage_Click);
            // 
            // BtnSum
            // 
            this.BtnSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSum.Location = new System.Drawing.Point(6, 19);
            this.BtnSum.Name = "BtnSum";
            this.BtnSum.Size = new System.Drawing.Size(121, 45);
            this.BtnSum.TabIndex = 17;
            this.BtnSum.Text = "TOTAL";
            this.BtnSum.UseVisualStyleBackColor = true;
            this.BtnSum.Click += new System.EventHandler(this.BtnSum_Click);
            // 
            // GrpTableFields
            // 
            this.GrpTableFields.Controls.Add(this.LstTableFields);
            this.GrpTableFields.Location = new System.Drawing.Point(527, 163);
            this.GrpTableFields.Name = "GrpTableFields";
            this.GrpTableFields.Size = new System.Drawing.Size(304, 325);
            this.GrpTableFields.TabIndex = 11;
            this.GrpTableFields.TabStop = false;
            this.GrpTableFields.Text = "Table Fields";
            // 
            // GrpTableName
            // 
            this.GrpTableName.Controls.Add(this.LblTableName);
            this.GrpTableName.Controls.Add(this.CmbTableName);
            this.GrpTableName.Location = new System.Drawing.Point(527, 112);
            this.GrpTableName.Name = "GrpTableName";
            this.GrpTableName.Size = new System.Drawing.Size(304, 45);
            this.GrpTableName.TabIndex = 10;
            this.GrpTableName.TabStop = false;
            // 
            // GrpDisplayFields
            // 
            this.GrpDisplayFields.Controls.Add(this.DGVDisplay);
            this.GrpDisplayFields.Location = new System.Drawing.Point(15, 362);
            this.GrpDisplayFields.Name = "GrpDisplayFields";
            this.GrpDisplayFields.Size = new System.Drawing.Size(376, 263);
            this.GrpDisplayFields.TabIndex = 9;
            this.GrpDisplayFields.TabStop = false;
            this.GrpDisplayFields.Text = "Display Fields";
            // 
            // DGVDisplay
            // 
            this.DGVDisplay.AllowUserToAddRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVDisplay.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGVDisplay.Location = new System.Drawing.Point(9, 16);
            this.DGVDisplay.Name = "DGVDisplay";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVDisplay.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVDisplay.Size = new System.Drawing.Size(359, 238);
            this.DGVDisplay.TabIndex = 2;
            this.DGVDisplay.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVDisplay_RowHeaderMouseDoubleClick);
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
            // GrpCriteria
            // 
            this.GrpCriteria.Controls.Add(this.DGVCriteria);
            this.GrpCriteria.Location = new System.Drawing.Point(15, 66);
            this.GrpCriteria.Name = "GrpCriteria";
            this.GrpCriteria.Size = new System.Drawing.Size(376, 290);
            this.GrpCriteria.TabIndex = 8;
            this.GrpCriteria.TabStop = false;
            this.GrpCriteria.Text = "Criteria on Fields";
            // 
            // GrpFormTitle
            // 
            this.GrpFormTitle.Controls.Add(this.CmbFormTitle);
            this.GrpFormTitle.Controls.Add(this.CmbFont);
            this.GrpFormTitle.Controls.Add(this.LblFont);
            this.GrpFormTitle.Controls.Add(this.TxtColor);
            this.GrpFormTitle.Controls.Add(this.TxtSize);
            this.GrpFormTitle.Controls.Add(this.LblSize);
            this.GrpFormTitle.Controls.Add(this.LblColor);
            this.GrpFormTitle.Controls.Add(this.TxtFormTitle);
            this.GrpFormTitle.Controls.Add(this.LblFormTitle);
            this.GrpFormTitle.Location = new System.Drawing.Point(15, 15);
            this.GrpFormTitle.Name = "GrpFormTitle";
            this.GrpFormTitle.Size = new System.Drawing.Size(679, 45);
            this.GrpFormTitle.TabIndex = 7;
            this.GrpFormTitle.TabStop = false;
            // 
            // CmbFormTitle
            // 
            this.CmbFormTitle.FormattingEnabled = true;
            this.CmbFormTitle.Location = new System.Drawing.Point(142, 19);
            this.CmbFormTitle.Name = "CmbFormTitle";
            this.CmbFormTitle.Size = new System.Drawing.Size(121, 21);
            this.CmbFormTitle.TabIndex = 8;
            this.CmbFormTitle.Visible = false;
            this.CmbFormTitle.SelectedIndexChanged += new System.EventHandler(this.CmbFormTitle_SelectedIndexChanged);
            // 
            // CmbFont
            // 
            this.CmbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFont.FormattingEnabled = true;
            this.CmbFont.Location = new System.Drawing.Point(548, 16);
            this.CmbFont.Name = "CmbFont";
            this.CmbFont.Size = new System.Drawing.Size(125, 21);
            this.CmbFont.TabIndex = 6;
            // 
            // LblFont
            // 
            this.LblFont.AutoSize = true;
            this.LblFont.Location = new System.Drawing.Point(514, 19);
            this.LblFont.Name = "LblFont";
            this.LblFont.Size = new System.Drawing.Size(28, 13);
            this.LblFont.TabIndex = 7;
            this.LblFont.Text = "Font";
            // 
            // TxtColor
            // 
            this.TxtColor.Location = new System.Drawing.Point(299, 16);
            this.TxtColor.Name = "TxtColor";
            this.TxtColor.ReadOnly = true;
            this.TxtColor.Size = new System.Drawing.Size(48, 20);
            this.TxtColor.TabIndex = 6;
            this.TxtColor.Click += new System.EventHandler(this.TxtColor_Click);
            // 
            // TxtSize
            // 
            this.TxtSize.Location = new System.Drawing.Point(416, 16);
            this.TxtSize.Name = "TxtSize";
            this.TxtSize.Size = new System.Drawing.Size(87, 20);
            this.TxtSize.TabIndex = 5;
            // 
            // LblSize
            // 
            this.LblSize.AutoSize = true;
            this.LblSize.Location = new System.Drawing.Point(356, 19);
            this.LblSize.Name = "LblSize";
            this.LblSize.Size = new System.Drawing.Size(54, 13);
            this.LblSize.TabIndex = 4;
            this.LblSize.Text = "Size (Y*X)";
            // 
            // LblColor
            // 
            this.LblColor.AutoSize = true;
            this.LblColor.Location = new System.Drawing.Point(262, 19);
            this.LblColor.Name = "LblColor";
            this.LblColor.Size = new System.Drawing.Size(31, 13);
            this.LblColor.TabIndex = 2;
            this.LblColor.Text = "Color";
            // 
            // CmbAccess
            // 
            this.CmbAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAccess.FormattingEnabled = true;
            this.CmbAccess.Items.AddRange(new object[] {
            "ALL",
            "SUPER USER",
            "LIMITED"});
            this.CmbAccess.Location = new System.Drawing.Point(136, 17);
            this.CmbAccess.Name = "CmbAccess";
            this.CmbAccess.Size = new System.Drawing.Size(159, 21);
            this.CmbAccess.TabIndex = 9;
            // 
            // LblAccess
            // 
            this.LblAccess.AutoSize = true;
            this.LblAccess.Location = new System.Drawing.Point(46, 20);
            this.LblAccess.Name = "LblAccess";
            this.LblAccess.Size = new System.Drawing.Size(68, 13);
            this.LblAccess.TabIndex = 10;
            this.LblAccess.Text = "Form Access";
            // 
            // GrpAccess
            // 
            this.GrpAccess.Controls.Add(this.CmbAccess);
            this.GrpAccess.Controls.Add(this.LblAccess);
            this.GrpAccess.Location = new System.Drawing.Point(527, 66);
            this.GrpAccess.Name = "GrpAccess";
            this.GrpAccess.Size = new System.Drawing.Size(301, 46);
            this.GrpAccess.TabIndex = 17;
            this.GrpAccess.TabStop = false;
            // 
            // FrmGenCreateSearchFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 646);
            this.Controls.Add(this.GrpFormDetails);
            this.Name = "FrmGenCreateSearchFrm";
            this.Text = "Create Search Form";
            this.Load += new System.EventHandler(this.FrmGenCreateSearchFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCriteria)).EndInit();
            this.GrpFormDetails.ResumeLayout(false);
            this.GrpCalculations.ResumeLayout(false);
            this.GrpTableFields.ResumeLayout(false);
            this.GrpTableName.ResumeLayout(false);
            this.GrpTableName.PerformLayout();
            this.GrpDisplayFields.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDisplay)).EndInit();
            this.GrpCriteria.ResumeLayout(false);
            this.GrpFormTitle.ResumeLayout(false);
            this.GrpFormTitle.PerformLayout();
            this.GrpAccess.ResumeLayout(false);
            this.GrpAccess.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblFormTitle;
        private System.Windows.Forms.TextBox TxtFormTitle;
        private System.Windows.Forms.DataGridView DGVCriteria;
        private System.Windows.Forms.ComboBox CmbTableName;
        private System.Windows.Forms.Label LblTableName;
        private System.Windows.Forms.ListBox LstTableFields;
        private System.Windows.Forms.GroupBox GrpFormDetails;
        private System.Windows.Forms.GroupBox GrpDisplayFields;
        private System.Windows.Forms.DataGridView DGVDisplay;
        private System.Windows.Forms.GroupBox GrpCriteria;
        private System.Windows.Forms.GroupBox GrpFormTitle;
        private System.Windows.Forms.GroupBox GrpCalculations;
        private System.Windows.Forms.GroupBox GrpTableFields;
        private System.Windows.Forms.GroupBox GrpTableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button BtnCreateFrm;
        private System.Windows.Forms.Button BtnAppendDisplay;
        private System.Windows.Forms.Button BtnAppendCriteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsFrozen;
        private System.Windows.Forms.TextBox TxtSize;
        private System.Windows.Forms.Label LblSize;
        private System.Windows.Forms.Label LblColor;
        private System.Windows.Forms.TextBox TxtColor;
        private System.Windows.Forms.Label LblFont;
        private System.Windows.Forms.ComboBox CmbFont;
        private System.Windows.Forms.Button BtnSum;
        private System.Windows.Forms.Button BtnProduct;
        private System.Windows.Forms.Button BtnCount;
        private System.Windows.Forms.Button BtnMinimum;
        private System.Windows.Forms.Button BtnMaximum;
        private System.Windows.Forms.Button BtnAverage;
        private System.Windows.Forms.ComboBox CmbFormTitle;
        private System.Windows.Forms.GroupBox GrpAccess;
        private System.Windows.Forms.ComboBox CmbAccess;
        private System.Windows.Forms.Label LblAccess;
    }
}