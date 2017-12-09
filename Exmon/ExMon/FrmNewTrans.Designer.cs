namespace ExMon
{
    partial class FrmNewTrans
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
            this.TabcTaransaction = new System.Windows.Forms.TabControl();
            this.TabTransaction = new System.Windows.Forms.TabPage();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.GrpNewTrans = new System.Windows.Forms.GroupBox();
            this.LblAccountType = new System.Windows.Forms.Label();
            this.CmbAccountType = new System.Windows.Forms.ComboBox();
            this.LblAccount = new System.Windows.Forms.Label();
            this.CmbAccount = new System.Windows.Forms.ComboBox();
            this.BtnSearchTransactionType = new System.Windows.Forms.Button();
            this.ChkAutoComplete = new System.Windows.Forms.CheckBox();
            this.CmbCurrency = new System.Windows.Forms.ComboBox();
            this.ChkAsset = new System.Windows.Forms.CheckBox();
            this.ChkFollowup = new System.Windows.Forms.CheckBox();
            this.LblCurrency = new System.Windows.Forms.Label();
            this.LblComments = new System.Windows.Forms.Label();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblType = new System.Windows.Forms.Label();
            this.RtxComments = new System.Windows.Forms.RichTextBox();
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.CmbType = new System.Windows.Forms.ComboBox();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
            this.GrpAccount = new System.Windows.Forms.GroupBox();
            this.TabTransfer = new System.Windows.Forms.TabPage();
            this.BtnCloseTransfer = new System.Windows.Forms.Button();
            this.BtnEnterTransfer = new System.Windows.Forms.Button();
            this.ChkAutoCompTransfer = new System.Windows.Forms.CheckBox();
            this.LblCommentsTransfer = new System.Windows.Forms.Label();
            this.LblAmountTransfer = new System.Windows.Forms.Label();
            this.RtxCommentsTransfer = new System.Windows.Forms.RichTextBox();
            this.TxtAmountTransfer = new System.Windows.Forms.TextBox();
            this.DtpDateTransfer = new System.Windows.Forms.DateTimePicker();
            this.LblDateTransfer = new System.Windows.Forms.Label();
            this.GrpTransfer = new System.Windows.Forms.GroupBox();
            this.GrpTo = new System.Windows.Forms.GroupBox();
            this.LblToAccountTypeTransfer = new System.Windows.Forms.Label();
            this.CmbToAccountTypeTransfer = new System.Windows.Forms.ComboBox();
            this.LblToAccountTransfer = new System.Windows.Forms.Label();
            this.CmbToAccountTransfer = new System.Windows.Forms.ComboBox();
            this.GrpFrom = new System.Windows.Forms.GroupBox();
            this.LblFromAccountTypeTransfer = new System.Windows.Forms.Label();
            this.CmbFromAccountTypeTransfer = new System.Windows.Forms.ComboBox();
            this.LblFromAccountTransfer = new System.Windows.Forms.Label();
            this.CmbFromAccountTransfer = new System.Windows.Forms.ComboBox();
            this.TabcTaransaction.SuspendLayout();
            this.TabTransaction.SuspendLayout();
            this.GrpNewTrans.SuspendLayout();
            this.TabTransfer.SuspendLayout();
            this.GrpTransfer.SuspendLayout();
            this.GrpTo.SuspendLayout();
            this.GrpFrom.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabcTaransaction
            // 
            this.TabcTaransaction.Controls.Add(this.TabTransaction);
            this.TabcTaransaction.Controls.Add(this.TabTransfer);
            this.TabcTaransaction.Location = new System.Drawing.Point(6, 6);
            this.TabcTaransaction.Name = "TabcTaransaction";
            this.TabcTaransaction.SelectedIndex = 0;
            this.TabcTaransaction.Size = new System.Drawing.Size(398, 496);
            this.TabcTaransaction.TabIndex = 0;
            // 
            // TabTransaction
            // 
            this.TabTransaction.Controls.Add(this.BtnClose);
            this.TabTransaction.Controls.Add(this.BtnEnter);
            this.TabTransaction.Controls.Add(this.GrpNewTrans);
            this.TabTransaction.Location = new System.Drawing.Point(4, 22);
            this.TabTransaction.Name = "TabTransaction";
            this.TabTransaction.Padding = new System.Windows.Forms.Padding(3);
            this.TabTransaction.Size = new System.Drawing.Size(390, 470);
            this.TabTransaction.TabIndex = 0;
            this.TabTransaction.Text = "Transaction";
            this.TabTransaction.UseVisualStyleBackColor = true;
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(245, 427);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(132, 32);
            this.BtnClose.TabIndex = 11;
            this.BtnClose.Text = "CLOSE";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(14, 427);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(132, 32);
            this.BtnEnter.TabIndex = 10;
            this.BtnEnter.Text = "ENTER";
            this.BtnEnter.UseVisualStyleBackColor = true;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // GrpNewTrans
            // 
            this.GrpNewTrans.Controls.Add(this.LblAccountType);
            this.GrpNewTrans.Controls.Add(this.CmbAccountType);
            this.GrpNewTrans.Controls.Add(this.LblAccount);
            this.GrpNewTrans.Controls.Add(this.CmbAccount);
            this.GrpNewTrans.Controls.Add(this.BtnSearchTransactionType);
            this.GrpNewTrans.Controls.Add(this.ChkAutoComplete);
            this.GrpNewTrans.Controls.Add(this.CmbCurrency);
            this.GrpNewTrans.Controls.Add(this.ChkAsset);
            this.GrpNewTrans.Controls.Add(this.ChkFollowup);
            this.GrpNewTrans.Controls.Add(this.LblCurrency);
            this.GrpNewTrans.Controls.Add(this.LblComments);
            this.GrpNewTrans.Controls.Add(this.LblAmount);
            this.GrpNewTrans.Controls.Add(this.LblType);
            this.GrpNewTrans.Controls.Add(this.RtxComments);
            this.GrpNewTrans.Controls.Add(this.TxtAmount);
            this.GrpNewTrans.Controls.Add(this.CmbType);
            this.GrpNewTrans.Controls.Add(this.DtpDate);
            this.GrpNewTrans.Controls.Add(this.LblDate);
            this.GrpNewTrans.Controls.Add(this.GrpAccount);
            this.GrpNewTrans.Location = new System.Drawing.Point(13, 10);
            this.GrpNewTrans.Name = "GrpNewTrans";
            this.GrpNewTrans.Size = new System.Drawing.Size(364, 411);
            this.GrpNewTrans.TabIndex = 9;
            this.GrpNewTrans.TabStop = false;
            this.GrpNewTrans.Text = "New Transaction";
            // 
            // LblAccountType
            // 
            this.LblAccountType.AutoSize = true;
            this.LblAccountType.Location = new System.Drawing.Point(25, 90);
            this.LblAccountType.Name = "LblAccountType";
            this.LblAccountType.Size = new System.Drawing.Size(74, 13);
            this.LblAccountType.TabIndex = 20;
            this.LblAccountType.Text = "Account Type";
            // 
            // CmbAccountType
            // 
            this.CmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAccountType.FormattingEnabled = true;
            this.CmbAccountType.Location = new System.Drawing.Point(110, 89);
            this.CmbAccountType.Name = "CmbAccountType";
            this.CmbAccountType.Size = new System.Drawing.Size(230, 21);
            this.CmbAccountType.TabIndex = 18;
            // 
            // LblAccount
            // 
            this.LblAccount.AutoSize = true;
            this.LblAccount.Location = new System.Drawing.Point(25, 63);
            this.LblAccount.Name = "LblAccount";
            this.LblAccount.Size = new System.Drawing.Size(47, 13);
            this.LblAccount.TabIndex = 19;
            this.LblAccount.Text = "Account";
            // 
            // CmbAccount
            // 
            this.CmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAccount.FormattingEnabled = true;
            this.CmbAccount.Location = new System.Drawing.Point(110, 62);
            this.CmbAccount.Name = "CmbAccount";
            this.CmbAccount.Size = new System.Drawing.Size(230, 21);
            this.CmbAccount.TabIndex = 17;
            this.CmbAccount.SelectedIndexChanged += new System.EventHandler(this.CmbAccount_SelectedIndexChanged);
            // 
            // BtnSearchTransactionType
            // 
            this.BtnSearchTransactionType.Location = new System.Drawing.Point(321, 129);
            this.BtnSearchTransactionType.Name = "BtnSearchTransactionType";
            this.BtnSearchTransactionType.Size = new System.Drawing.Size(28, 24);
            this.BtnSearchTransactionType.TabIndex = 16;
            this.BtnSearchTransactionType.UseVisualStyleBackColor = true;
            this.BtnSearchTransactionType.Click += new System.EventHandler(this.BtnSearchTransactionType_Click);
            // 
            // ChkAutoComplete
            // 
            this.ChkAutoComplete.Checked = true;
            this.ChkAutoComplete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAutoComplete.Location = new System.Drawing.Point(28, 291);
            this.ChkAutoComplete.Name = "ChkAutoComplete";
            this.ChkAutoComplete.Size = new System.Drawing.Size(73, 33);
            this.ChkAutoComplete.TabIndex = 15;
            this.ChkAutoComplete.Text = "Auto Complete";
            this.ChkAutoComplete.UseVisualStyleBackColor = true;
            // 
            // CmbCurrency
            // 
            this.CmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurrency.FormattingEnabled = true;
            this.CmbCurrency.Location = new System.Drawing.Point(110, 167);
            this.CmbCurrency.Name = "CmbCurrency";
            this.CmbCurrency.Size = new System.Drawing.Size(91, 21);
            this.CmbCurrency.TabIndex = 5;
            // 
            // ChkAsset
            // 
            this.ChkAsset.AutoSize = true;
            this.ChkAsset.Location = new System.Drawing.Point(110, 384);
            this.ChkAsset.Name = "ChkAsset";
            this.ChkAsset.Size = new System.Drawing.Size(52, 17);
            this.ChkAsset.TabIndex = 9;
            this.ChkAsset.Text = "Asset";
            this.ChkAsset.UseVisualStyleBackColor = true;
            // 
            // ChkFollowup
            // 
            this.ChkFollowup.AutoSize = true;
            this.ChkFollowup.Location = new System.Drawing.Point(110, 240);
            this.ChkFollowup.Name = "ChkFollowup";
            this.ChkFollowup.Size = new System.Drawing.Size(67, 17);
            this.ChkFollowup.TabIndex = 7;
            this.ChkFollowup.Text = "Follw Up";
            this.ChkFollowup.UseVisualStyleBackColor = true;
            // 
            // LblCurrency
            // 
            this.LblCurrency.AutoSize = true;
            this.LblCurrency.Location = new System.Drawing.Point(25, 169);
            this.LblCurrency.Name = "LblCurrency";
            this.LblCurrency.Size = new System.Drawing.Size(49, 13);
            this.LblCurrency.TabIndex = 11;
            this.LblCurrency.Text = "Currency";
            // 
            // LblComments
            // 
            this.LblComments.AutoSize = true;
            this.LblComments.Location = new System.Drawing.Point(25, 275);
            this.LblComments.Name = "LblComments";
            this.LblComments.Size = new System.Drawing.Size(56, 13);
            this.LblComments.TabIndex = 9;
            this.LblComments.Text = "Comments";
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Location = new System.Drawing.Point(25, 207);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(43, 13);
            this.LblAmount.TabIndex = 8;
            this.LblAmount.Text = "Amount";
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Location = new System.Drawing.Point(25, 131);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(31, 13);
            this.LblType.TabIndex = 6;
            this.LblType.Text = "Type";
            // 
            // RtxComments
            // 
            this.RtxComments.Location = new System.Drawing.Point(110, 273);
            this.RtxComments.Name = "RtxComments";
            this.RtxComments.Size = new System.Drawing.Size(230, 95);
            this.RtxComments.TabIndex = 8;
            this.RtxComments.Text = "";
            this.RtxComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtxComments_KeyPress);
            this.RtxComments.TextChanged += new System.EventHandler(this.RtxComments_TextChanged);
            // 
            // TxtAmount
            // 
            this.TxtAmount.Location = new System.Drawing.Point(110, 204);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(91, 20);
            this.TxtAmount.TabIndex = 6;
            // 
            // CmbType
            // 
            this.CmbType.FormattingEnabled = true;
            this.CmbType.Location = new System.Drawing.Point(110, 130);
            this.CmbType.Name = "CmbType";
            this.CmbType.Size = new System.Drawing.Size(211, 21);
            this.CmbType.TabIndex = 4;
            this.CmbType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbType_KeyPress);
            this.CmbType.TextChanged += new System.EventHandler(this.CmbType_TextChanged);
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "dd/MM/yyyy";
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDate.Location = new System.Drawing.Point(245, 19);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.ShowUpDown = true;
            this.DtpDate.Size = new System.Drawing.Size(95, 20);
            this.DtpDate.TabIndex = 1;
            this.DtpDate.ValueChanged += new System.EventHandler(this.DtpDate_ValueChanged);
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(188, 21);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(30, 13);
            this.LblDate.TabIndex = 0;
            this.LblDate.Text = "Date";
            // 
            // GrpAccount
            // 
            this.GrpAccount.Location = new System.Drawing.Point(18, 45);
            this.GrpAccount.Name = "GrpAccount";
            this.GrpAccount.Size = new System.Drawing.Size(331, 78);
            this.GrpAccount.TabIndex = 21;
            this.GrpAccount.TabStop = false;
            // 
            // TabTransfer
            // 
            this.TabTransfer.Controls.Add(this.BtnCloseTransfer);
            this.TabTransfer.Controls.Add(this.BtnEnterTransfer);
            this.TabTransfer.Controls.Add(this.ChkAutoCompTransfer);
            this.TabTransfer.Controls.Add(this.LblCommentsTransfer);
            this.TabTransfer.Controls.Add(this.LblAmountTransfer);
            this.TabTransfer.Controls.Add(this.RtxCommentsTransfer);
            this.TabTransfer.Controls.Add(this.TxtAmountTransfer);
            this.TabTransfer.Controls.Add(this.DtpDateTransfer);
            this.TabTransfer.Controls.Add(this.LblDateTransfer);
            this.TabTransfer.Controls.Add(this.GrpTransfer);
            this.TabTransfer.Location = new System.Drawing.Point(4, 22);
            this.TabTransfer.Name = "TabTransfer";
            this.TabTransfer.Padding = new System.Windows.Forms.Padding(3);
            this.TabTransfer.Size = new System.Drawing.Size(390, 470);
            this.TabTransfer.TabIndex = 1;
            this.TabTransfer.Text = "Transfer";
            this.TabTransfer.UseVisualStyleBackColor = true;
            // 
            // BtnCloseTransfer
            // 
            this.BtnCloseTransfer.Location = new System.Drawing.Point(245, 427);
            this.BtnCloseTransfer.Name = "BtnCloseTransfer";
            this.BtnCloseTransfer.Size = new System.Drawing.Size(132, 32);
            this.BtnCloseTransfer.TabIndex = 25;
            this.BtnCloseTransfer.Text = "CLOSE";
            this.BtnCloseTransfer.UseVisualStyleBackColor = true;
            this.BtnCloseTransfer.Click += new System.EventHandler(this.BtnCloseTransfer_Click);
            // 
            // BtnEnterTransfer
            // 
            this.BtnEnterTransfer.Location = new System.Drawing.Point(14, 427);
            this.BtnEnterTransfer.Name = "BtnEnterTransfer";
            this.BtnEnterTransfer.Size = new System.Drawing.Size(132, 32);
            this.BtnEnterTransfer.TabIndex = 24;
            this.BtnEnterTransfer.Text = "ENTER";
            this.BtnEnterTransfer.UseVisualStyleBackColor = true;
            this.BtnEnterTransfer.Click += new System.EventHandler(this.BtnEnterTransfer_Click);
            // 
            // ChkAutoCompTransfer
            // 
            this.ChkAutoCompTransfer.Checked = true;
            this.ChkAutoCompTransfer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAutoCompTransfer.Location = new System.Drawing.Point(44, 300);
            this.ChkAutoCompTransfer.Name = "ChkAutoCompTransfer";
            this.ChkAutoCompTransfer.Size = new System.Drawing.Size(73, 33);
            this.ChkAutoCompTransfer.TabIndex = 23;
            this.ChkAutoCompTransfer.Text = "Auto Complete";
            this.ChkAutoCompTransfer.UseVisualStyleBackColor = true;
            // 
            // LblCommentsTransfer
            // 
            this.LblCommentsTransfer.AutoSize = true;
            this.LblCommentsTransfer.Location = new System.Drawing.Point(41, 284);
            this.LblCommentsTransfer.Name = "LblCommentsTransfer";
            this.LblCommentsTransfer.Size = new System.Drawing.Size(56, 13);
            this.LblCommentsTransfer.TabIndex = 22;
            this.LblCommentsTransfer.Text = "Comments";
            // 
            // LblAmountTransfer
            // 
            this.LblAmountTransfer.AutoSize = true;
            this.LblAmountTransfer.Location = new System.Drawing.Point(41, 242);
            this.LblAmountTransfer.Name = "LblAmountTransfer";
            this.LblAmountTransfer.Size = new System.Drawing.Size(43, 13);
            this.LblAmountTransfer.TabIndex = 21;
            this.LblAmountTransfer.Text = "Amount";
            // 
            // RtxCommentsTransfer
            // 
            this.RtxCommentsTransfer.Location = new System.Drawing.Point(126, 279);
            this.RtxCommentsTransfer.Name = "RtxCommentsTransfer";
            this.RtxCommentsTransfer.Size = new System.Drawing.Size(230, 95);
            this.RtxCommentsTransfer.TabIndex = 20;
            this.RtxCommentsTransfer.Text = "";
            this.RtxCommentsTransfer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RtxCommentsTransfer_KeyPress);
            this.RtxCommentsTransfer.TextChanged += new System.EventHandler(this.RtxCommentsTransfer_TextChanged);
            // 
            // TxtAmountTransfer
            // 
            this.TxtAmountTransfer.Location = new System.Drawing.Point(126, 240);
            this.TxtAmountTransfer.Name = "TxtAmountTransfer";
            this.TxtAmountTransfer.Size = new System.Drawing.Size(91, 20);
            this.TxtAmountTransfer.TabIndex = 19;
            // 
            // DtpDateTransfer
            // 
            this.DtpDateTransfer.CustomFormat = "dd/MM/yyyy";
            this.DtpDateTransfer.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpDateTransfer.Location = new System.Drawing.Point(259, 31);
            this.DtpDateTransfer.Name = "DtpDateTransfer";
            this.DtpDateTransfer.ShowUpDown = true;
            this.DtpDateTransfer.Size = new System.Drawing.Size(95, 20);
            this.DtpDateTransfer.TabIndex = 16;
            this.DtpDateTransfer.ValueChanged += new System.EventHandler(this.DtpDateTransfer_ValueChanged);
            // 
            // LblDateTransfer
            // 
            this.LblDateTransfer.AutoSize = true;
            this.LblDateTransfer.Location = new System.Drawing.Point(202, 33);
            this.LblDateTransfer.Name = "LblDateTransfer";
            this.LblDateTransfer.Size = new System.Drawing.Size(30, 13);
            this.LblDateTransfer.TabIndex = 15;
            this.LblDateTransfer.Text = "Date";
            // 
            // GrpTransfer
            // 
            this.GrpTransfer.Controls.Add(this.GrpTo);
            this.GrpTransfer.Controls.Add(this.GrpFrom);
            this.GrpTransfer.Location = new System.Drawing.Point(14, 12);
            this.GrpTransfer.Name = "GrpTransfer";
            this.GrpTransfer.Size = new System.Drawing.Size(363, 391);
            this.GrpTransfer.TabIndex = 26;
            this.GrpTransfer.TabStop = false;
            this.GrpTransfer.Text = "Transfer";
            // 
            // GrpTo
            // 
            this.GrpTo.Controls.Add(this.LblToAccountTypeTransfer);
            this.GrpTo.Controls.Add(this.CmbToAccountTypeTransfer);
            this.GrpTo.Controls.Add(this.LblToAccountTransfer);
            this.GrpTo.Controls.Add(this.CmbToAccountTransfer);
            this.GrpTo.Location = new System.Drawing.Point(18, 135);
            this.GrpTo.Name = "GrpTo";
            this.GrpTo.Size = new System.Drawing.Size(330, 80);
            this.GrpTo.TabIndex = 23;
            this.GrpTo.TabStop = false;
            this.GrpTo.Text = "TO";
            // 
            // LblToAccountTypeTransfer
            // 
            this.LblToAccountTypeTransfer.AutoSize = true;
            this.LblToAccountTypeTransfer.Location = new System.Drawing.Point(7, 47);
            this.LblToAccountTypeTransfer.Name = "LblToAccountTypeTransfer";
            this.LblToAccountTypeTransfer.Size = new System.Drawing.Size(74, 13);
            this.LblToAccountTypeTransfer.TabIndex = 21;
            this.LblToAccountTypeTransfer.Text = "Account Type";
            // 
            // CmbToAccountTypeTransfer
            // 
            this.CmbToAccountTypeTransfer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbToAccountTypeTransfer.FormattingEnabled = true;
            this.CmbToAccountTypeTransfer.Location = new System.Drawing.Point(92, 46);
            this.CmbToAccountTypeTransfer.Name = "CmbToAccountTypeTransfer";
            this.CmbToAccountTypeTransfer.Size = new System.Drawing.Size(230, 21);
            this.CmbToAccountTypeTransfer.TabIndex = 19;
            // 
            // LblToAccountTransfer
            // 
            this.LblToAccountTransfer.AutoSize = true;
            this.LblToAccountTransfer.Location = new System.Drawing.Point(7, 20);
            this.LblToAccountTransfer.Name = "LblToAccountTransfer";
            this.LblToAccountTransfer.Size = new System.Drawing.Size(47, 13);
            this.LblToAccountTransfer.TabIndex = 20;
            this.LblToAccountTransfer.Text = "Account";
            // 
            // CmbToAccountTransfer
            // 
            this.CmbToAccountTransfer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbToAccountTransfer.FormattingEnabled = true;
            this.CmbToAccountTransfer.Location = new System.Drawing.Point(92, 19);
            this.CmbToAccountTransfer.Name = "CmbToAccountTransfer";
            this.CmbToAccountTransfer.Size = new System.Drawing.Size(230, 21);
            this.CmbToAccountTransfer.TabIndex = 18;
            this.CmbToAccountTransfer.SelectedIndexChanged += new System.EventHandler(this.CmbToAccountTransfer_SelectedIndexChanged);
            // 
            // GrpFrom
            // 
            this.GrpFrom.Controls.Add(this.LblFromAccountTypeTransfer);
            this.GrpFrom.Controls.Add(this.CmbFromAccountTypeTransfer);
            this.GrpFrom.Controls.Add(this.LblFromAccountTransfer);
            this.GrpFrom.Controls.Add(this.CmbFromAccountTransfer);
            this.GrpFrom.Location = new System.Drawing.Point(18, 49);
            this.GrpFrom.Name = "GrpFrom";
            this.GrpFrom.Size = new System.Drawing.Size(330, 80);
            this.GrpFrom.TabIndex = 22;
            this.GrpFrom.TabStop = false;
            this.GrpFrom.Text = "FROM";
            // 
            // LblFromAccountTypeTransfer
            // 
            this.LblFromAccountTypeTransfer.AutoSize = true;
            this.LblFromAccountTypeTransfer.Location = new System.Drawing.Point(7, 47);
            this.LblFromAccountTypeTransfer.Name = "LblFromAccountTypeTransfer";
            this.LblFromAccountTypeTransfer.Size = new System.Drawing.Size(74, 13);
            this.LblFromAccountTypeTransfer.TabIndex = 21;
            this.LblFromAccountTypeTransfer.Text = "Account Type";
            // 
            // CmbFromAccountTypeTransfer
            // 
            this.CmbFromAccountTypeTransfer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFromAccountTypeTransfer.FormattingEnabled = true;
            this.CmbFromAccountTypeTransfer.Location = new System.Drawing.Point(92, 46);
            this.CmbFromAccountTypeTransfer.Name = "CmbFromAccountTypeTransfer";
            this.CmbFromAccountTypeTransfer.Size = new System.Drawing.Size(230, 21);
            this.CmbFromAccountTypeTransfer.TabIndex = 19;
            this.CmbFromAccountTypeTransfer.SelectedIndexChanged += new System.EventHandler(this.CmbFromAccountTypeTransfer_SelectedIndexChanged);
            // 
            // LblFromAccountTransfer
            // 
            this.LblFromAccountTransfer.AutoSize = true;
            this.LblFromAccountTransfer.Location = new System.Drawing.Point(7, 20);
            this.LblFromAccountTransfer.Name = "LblFromAccountTransfer";
            this.LblFromAccountTransfer.Size = new System.Drawing.Size(47, 13);
            this.LblFromAccountTransfer.TabIndex = 20;
            this.LblFromAccountTransfer.Text = "Account";
            // 
            // CmbFromAccountTransfer
            // 
            this.CmbFromAccountTransfer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFromAccountTransfer.FormattingEnabled = true;
            this.CmbFromAccountTransfer.Location = new System.Drawing.Point(92, 19);
            this.CmbFromAccountTransfer.Name = "CmbFromAccountTransfer";
            this.CmbFromAccountTransfer.Size = new System.Drawing.Size(230, 21);
            this.CmbFromAccountTransfer.TabIndex = 18;
            this.CmbFromAccountTransfer.SelectedIndexChanged += new System.EventHandler(this.CmbFromAccountTransfer_SelectedIndexChanged);
            // 
            // FrmNewTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 504);
            this.Controls.Add(this.TabcTaransaction);
            this.Name = "FrmNewTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmNewTrans";
            this.Load += new System.EventHandler(this.FrmNewTrans_Load);
            this.TabcTaransaction.ResumeLayout(false);
            this.TabTransaction.ResumeLayout(false);
            this.GrpNewTrans.ResumeLayout(false);
            this.GrpNewTrans.PerformLayout();
            this.TabTransfer.ResumeLayout(false);
            this.TabTransfer.PerformLayout();
            this.GrpTransfer.ResumeLayout(false);
            this.GrpTo.ResumeLayout(false);
            this.GrpTo.PerformLayout();
            this.GrpFrom.ResumeLayout(false);
            this.GrpFrom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabcTaransaction;
        private System.Windows.Forms.TabPage TabTransaction;
        private System.Windows.Forms.TabPage TabTransfer;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnEnter;
        private System.Windows.Forms.GroupBox GrpNewTrans;
        private System.Windows.Forms.CheckBox ChkAsset;
        private System.Windows.Forms.CheckBox ChkFollowup;
        private System.Windows.Forms.Label LblCurrency;
        private System.Windows.Forms.Label LblComments;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.RichTextBox RtxComments;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.ComboBox CmbType;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.ComboBox CmbCurrency;
        private System.Windows.Forms.CheckBox ChkAutoComplete;
        private System.Windows.Forms.Button BtnSearchTransactionType;
        private System.Windows.Forms.Button BtnCloseTransfer;
        private System.Windows.Forms.Button BtnEnterTransfer;
        private System.Windows.Forms.CheckBox ChkAutoCompTransfer;
        private System.Windows.Forms.Label LblCommentsTransfer;
        private System.Windows.Forms.Label LblAmountTransfer;
        private System.Windows.Forms.RichTextBox RtxCommentsTransfer;
        private System.Windows.Forms.TextBox TxtAmountTransfer;
        private System.Windows.Forms.DateTimePicker DtpDateTransfer;
        private System.Windows.Forms.Label LblDateTransfer;
        private System.Windows.Forms.GroupBox GrpTransfer;
        private System.Windows.Forms.GroupBox GrpTo;
        private System.Windows.Forms.Label LblToAccountTypeTransfer;
        private System.Windows.Forms.ComboBox CmbToAccountTypeTransfer;
        private System.Windows.Forms.Label LblToAccountTransfer;
        private System.Windows.Forms.ComboBox CmbToAccountTransfer;
        private System.Windows.Forms.GroupBox GrpFrom;
        private System.Windows.Forms.Label LblFromAccountTypeTransfer;
        private System.Windows.Forms.ComboBox CmbFromAccountTypeTransfer;
        private System.Windows.Forms.Label LblFromAccountTransfer;
        private System.Windows.Forms.ComboBox CmbFromAccountTransfer;
        private System.Windows.Forms.Label LblAccountType;
        private System.Windows.Forms.ComboBox CmbAccountType;
        private System.Windows.Forms.Label LblAccount;
        private System.Windows.Forms.ComboBox CmbAccount;
        private System.Windows.Forms.GroupBox GrpAccount;

    }
}