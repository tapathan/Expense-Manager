namespace ExMon
{
    partial class FrmFront
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
            this.TrvFilters = new System.Windows.Forms.TreeView();
            this.GrpFilters = new System.Windows.Forms.GroupBox();
            this.GrpAccounts = new System.Windows.Forms.GroupBox();
            this.TrvAccounts = new System.Windows.Forms.TreeView();
            this.GrpTransactionTypes = new System.Windows.Forms.GroupBox();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.LblDateTransfer = new System.Windows.Forms.Label();
            this.GrpData = new System.Windows.Forms.GroupBox();
            this.GrpTransfers = new System.Windows.Forms.GroupBox();
            this.DgvTransfers = new System.Windows.Forms.DataGridView();
            this.GrpTransactions = new System.Windows.Forms.GroupBox();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.DgvTransactions = new System.Windows.Forms.DataGridView();
            this.GrpHierarchy = new System.Windows.Forms.GroupBox();
            this.DgvHierarchy = new System.Windows.Forms.DataGridView();
            this.GrpCategory = new System.Windows.Forms.GroupBox();
            this.DgvCategory = new System.Windows.Forms.DataGridView();
            this.GrpDate = new System.Windows.Forms.GroupBox();
            this.GrpFilters.SuspendLayout();
            this.GrpAccounts.SuspendLayout();
            this.GrpData.SuspendLayout();
            this.GrpTransfers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransfers)).BeginInit();
            this.GrpTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransactions)).BeginInit();
            this.GrpHierarchy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvHierarchy)).BeginInit();
            this.GrpCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCategory)).BeginInit();
            this.GrpDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrvFilters
            // 
            this.TrvFilters.Location = new System.Drawing.Point(13, 153);
            this.TrvFilters.Name = "TrvFilters";
            this.TrvFilters.Size = new System.Drawing.Size(187, 409);
            this.TrvFilters.TabIndex = 0;
            this.TrvFilters.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.TrvFilters_NodeMouseHover);
            this.TrvFilters.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvFilters_AfterSelect);
            this.TrvFilters.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrvFilters_MouseDown);
            this.TrvFilters.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TrvFilters_BeforeSelect);
            this.TrvFilters.Click += new System.EventHandler(this.TrvFilters_Click);
            // 
            // GrpFilters
            // 
            this.GrpFilters.Controls.Add(this.GrpAccounts);
            this.GrpFilters.Controls.Add(this.TrvFilters);
            this.GrpFilters.Controls.Add(this.GrpTransactionTypes);
            this.GrpFilters.Location = new System.Drawing.Point(802, 41);
            this.GrpFilters.Name = "GrpFilters";
            this.GrpFilters.Size = new System.Drawing.Size(212, 579);
            this.GrpFilters.TabIndex = 1;
            this.GrpFilters.TabStop = false;
            this.GrpFilters.Text = "Filters";
            // 
            // GrpAccounts
            // 
            this.GrpAccounts.Controls.Add(this.TrvAccounts);
            this.GrpAccounts.Location = new System.Drawing.Point(7, 15);
            this.GrpAccounts.Name = "GrpAccounts";
            this.GrpAccounts.Size = new System.Drawing.Size(199, 119);
            this.GrpAccounts.TabIndex = 1;
            this.GrpAccounts.TabStop = false;
            this.GrpAccounts.Text = "Accounts";
            // 
            // TrvAccounts
            // 
            this.TrvAccounts.Location = new System.Drawing.Point(6, 19);
            this.TrvAccounts.Name = "TrvAccounts";
            this.TrvAccounts.Size = new System.Drawing.Size(187, 94);
            this.TrvAccounts.TabIndex = 0;
            this.TrvAccounts.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.TrvAccounts_NodeMouseHover);
            this.TrvAccounts.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrvAccounts_AfterSelect);
            this.TrvAccounts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrvAccounts_MouseDown);
            this.TrvAccounts.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TrvAccounts_BeforeSelect);
            this.TrvAccounts.Click += new System.EventHandler(this.TrvAccounts_Click);
            // 
            // GrpTransactionTypes
            // 
            this.GrpTransactionTypes.Location = new System.Drawing.Point(6, 134);
            this.GrpTransactionTypes.Name = "GrpTransactionTypes";
            this.GrpTransactionTypes.Size = new System.Drawing.Size(200, 434);
            this.GrpTransactionTypes.TabIndex = 2;
            this.GrpTransactionTypes.TabStop = false;
            this.GrpTransactionTypes.Text = "Transaction Types";
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "dd/MM/yyyy";
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDate.Location = new System.Drawing.Point(118, 14);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.ShowUpDown = true;
            this.DtpDate.Size = new System.Drawing.Size(82, 20);
            this.DtpDate.TabIndex = 18;
            this.DtpDate.ValueChanged += new System.EventHandler(this.DtpDate_ValueChanged);
            // 
            // LblDateTransfer
            // 
            this.LblDateTransfer.AutoSize = true;
            this.LblDateTransfer.Location = new System.Drawing.Point(72, 16);
            this.LblDateTransfer.Name = "LblDateTransfer";
            this.LblDateTransfer.Size = new System.Drawing.Size(30, 13);
            this.LblDateTransfer.TabIndex = 17;
            this.LblDateTransfer.Text = "Date";
            // 
            // GrpData
            // 
            this.GrpData.Controls.Add(this.GrpTransfers);
            this.GrpData.Controls.Add(this.GrpTransactions);
            this.GrpData.Controls.Add(this.GrpHierarchy);
            this.GrpData.Controls.Add(this.GrpCategory);
            this.GrpData.Location = new System.Drawing.Point(12, 1);
            this.GrpData.Name = "GrpData";
            this.GrpData.Size = new System.Drawing.Size(784, 619);
            this.GrpData.TabIndex = 19;
            this.GrpData.TabStop = false;
            // 
            // GrpTransfers
            // 
            this.GrpTransfers.Controls.Add(this.DgvTransfers);
            this.GrpTransfers.Location = new System.Drawing.Point(293, 457);
            this.GrpTransfers.Name = "GrpTransfers";
            this.GrpTransfers.Size = new System.Drawing.Size(485, 151);
            this.GrpTransfers.TabIndex = 3;
            this.GrpTransfers.TabStop = false;
            this.GrpTransfers.Text = "Transfers";
            // 
            // DgvTransfers
            // 
            this.DgvTransfers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTransfers.Location = new System.Drawing.Point(6, 19);
            this.DgvTransfers.Name = "DgvTransfers";
            this.DgvTransfers.Size = new System.Drawing.Size(473, 126);
            this.DgvTransfers.TabIndex = 0;
            this.DgvTransfers.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTransfers_RowHeaderMouseClick);
            // 
            // GrpTransactions
            // 
            this.GrpTransactions.Controls.Add(this.TxtTotal);
            this.GrpTransactions.Controls.Add(this.DgvTransactions);
            this.GrpTransactions.Location = new System.Drawing.Point(293, 14);
            this.GrpTransactions.Name = "GrpTransactions";
            this.GrpTransactions.Size = new System.Drawing.Size(485, 437);
            this.GrpTransactions.TabIndex = 2;
            this.GrpTransactions.TabStop = false;
            this.GrpTransactions.Text = "Transactions";
            // 
            // TxtTotal
            // 
            this.TxtTotal.Location = new System.Drawing.Point(6, 409);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(473, 20);
            this.TxtTotal.TabIndex = 2;
            // 
            // DgvTransactions
            // 
            this.DgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTransactions.Location = new System.Drawing.Point(6, 19);
            this.DgvTransactions.Name = "DgvTransactions";
            this.DgvTransactions.Size = new System.Drawing.Size(473, 384);
            this.DgvTransactions.TabIndex = 1;
            this.DgvTransactions.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTransactions_RowHeaderMouseClick);
            // 
            // GrpHierarchy
            // 
            this.GrpHierarchy.Controls.Add(this.DgvHierarchy);
            this.GrpHierarchy.Location = new System.Drawing.Point(6, 395);
            this.GrpHierarchy.Name = "GrpHierarchy";
            this.GrpHierarchy.Size = new System.Drawing.Size(281, 213);
            this.GrpHierarchy.TabIndex = 1;
            this.GrpHierarchy.TabStop = false;
            this.GrpHierarchy.Text = "Hierarchies";
            // 
            // DgvHierarchy
            // 
            this.DgvHierarchy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvHierarchy.Location = new System.Drawing.Point(6, 17);
            this.DgvHierarchy.Name = "DgvHierarchy";
            this.DgvHierarchy.Size = new System.Drawing.Size(269, 190);
            this.DgvHierarchy.TabIndex = 0;
            // 
            // GrpCategory
            // 
            this.GrpCategory.Controls.Add(this.DgvCategory);
            this.GrpCategory.Location = new System.Drawing.Point(6, 14);
            this.GrpCategory.Name = "GrpCategory";
            this.GrpCategory.Size = new System.Drawing.Size(281, 375);
            this.GrpCategory.TabIndex = 0;
            this.GrpCategory.TabStop = false;
            this.GrpCategory.Text = "Categories";
            // 
            // DgvCategory
            // 
            this.DgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCategory.Location = new System.Drawing.Point(6, 19);
            this.DgvCategory.Name = "DgvCategory";
            this.DgvCategory.Size = new System.Drawing.Size(269, 349);
            this.DgvCategory.TabIndex = 0;
            // 
            // GrpDate
            // 
            this.GrpDate.Controls.Add(this.DtpDate);
            this.GrpDate.Controls.Add(this.LblDateTransfer);
            this.GrpDate.Location = new System.Drawing.Point(802, 1);
            this.GrpDate.Name = "GrpDate";
            this.GrpDate.Size = new System.Drawing.Size(211, 40);
            this.GrpDate.TabIndex = 20;
            this.GrpDate.TabStop = false;
            // 
            // FrmFront
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 702);
            this.ControlBox = false;
            this.Controls.Add(this.GrpDate);
            this.Controls.Add(this.GrpData);
            this.Controls.Add(this.GrpFilters);
            this.Name = "FrmFront";
            this.Text = "Summary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmFront_Load);
            this.GrpFilters.ResumeLayout(false);
            this.GrpAccounts.ResumeLayout(false);
            this.GrpData.ResumeLayout(false);
            this.GrpTransfers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransfers)).EndInit();
            this.GrpTransactions.ResumeLayout(false);
            this.GrpTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTransactions)).EndInit();
            this.GrpHierarchy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvHierarchy)).EndInit();
            this.GrpCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCategory)).EndInit();
            this.GrpDate.ResumeLayout(false);
            this.GrpDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TrvFilters;
        private System.Windows.Forms.GroupBox GrpFilters;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label LblDateTransfer;
        private System.Windows.Forms.GroupBox GrpData;
        private System.Windows.Forms.GroupBox GrpDate;
        private System.Windows.Forms.GroupBox GrpCategory;
        private System.Windows.Forms.GroupBox GrpTransfers;
        private System.Windows.Forms.GroupBox GrpTransactions;
        private System.Windows.Forms.GroupBox GrpHierarchy;
        private System.Windows.Forms.DataGridView DgvHierarchy;
        private System.Windows.Forms.DataGridView DgvCategory;
        private System.Windows.Forms.DataGridView DgvTransfers;
        private System.Windows.Forms.DataGridView DgvTransactions;
        private System.Windows.Forms.TreeView TrvAccounts;
        private System.Windows.Forms.GroupBox GrpAccounts;
        private System.Windows.Forms.GroupBox GrpTransactionTypes;
        private System.Windows.Forms.TextBox TxtTotal;
    }
}