using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using Microsoft.Office.Interop;

namespace ExMon
{
    public partial class FrmMDIMain : Form
    {
        public FrmMDIMain()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();
        FrmFront FrontForm = new FrmFront();
        string SelectedDeleteDimForm = "";
        Boolean Refresh = false;

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDimGeneric AccountDim = new FrmDimGeneric("AccountDim", "Accounts");
            AccountDim.MdiParent = this;
            AccountDim.WindowState = FormWindowState.Maximized;
            AccountDim.ColourForm(Color.FloralWhite);
            AccountDim.TransflexReduceWidth(327);
            AccountDim.Show();
        }

        private void transactionTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTransactionType TransactionType = new FrmTransactionType(false);
            TransactionType.BackColor = Color.SlateBlue;
            var TransTypeRes = TransactionType.ShowDialog();
            string TransTypeVal;
            if (TransTypeRes == DialogResult.OK)
                TransTypeVal = TransactionType.ReturnValue1;
        }

        private void FrmMDIMain_Load(object sender, EventArgs e)
        {
            this.Text = "ExMon";
            this.Font = new Font("Verdana", 9, FontStyle.Regular);
            string UserType = CommFunc.Fetch_DB_Value("Access", "UserDim", "Username = '" + CommonFunctions.UserNm + "'");
            MenuExMon.Font = new Font("Verdana", 9, FontStyle.Regular);
            FrontForm.MdiParent = this;
            FrontForm.Show();
            FrontForm.WindowState = FormWindowState.Maximized;
            FrontForm.MinimizeBox = false;
            FrontForm.MinimizeBox = false;
            if (UserType != "SUPER USER")
            {
                toolStripMenuItemTools.DropDownItems.RemoveByKey("toolStripCreateNewUser");
                toolStripMenuItemTools.DropDownItems.RemoveByKey("toolStripCreateDimensionForm");
                toolStripMenuItemTools.DropDownItems.RemoveByKey("toolStripCreateGrpDimensionForm");
                toolStripMenuItemTools.DropDownItems.RemoveByKey("toolStripEditDimensionForm");
                toolStripMenuItemTools.DropDownItems.RemoveByKey("toolStripDeleteDimensionForm");
                toolStripMenuItemTools.DropDownItems.RemoveByKey("toolStripDeleteUser");
            }
            if (UserType == "LIMITED")
            {
                toolStripMenuItemView.DropDownItems.RemoveByKey("toolStripAccounts");
                toolStripMenuItemEdit.DropDownItems.RemoveByKey("toolStripEnterSeason");
                toolStripMenuItemEdit.DropDownItems.RemoveByKey("toolStripEnterSpecialPeriodMenuItem8");
                toolStripMenuItemEdit.DropDownItems.RemoveByKey("toolStripEnterMajorEvent");
            }
            CreateSearchMenuItems();
            CommFunc.Execute_DB_Command("DELETE FROM AssetCalculations");
        }

        private void CreateSearchMenuItems()
        {
            if (Refresh == true)
            {
                MenuExMon.Items.RemoveAt(MenuExMon.Items.Count - 1);
            }
            string[] Forms;
            string FormsList = "";
            string UserType = CommFunc.Fetch_DB_Value("Access", "UserDim", "Username = '" + CommonFunctions.UserNm + "'");
            if (UserType == "SUPER USER")
                FormsList = CommFunc.Fetch_DB_Value("FrmName", "FormDim", "");
            else if (UserType == "LIMITED")
                FormsList = CommFunc.Fetch_DB_Value("FrmName", "FormDim", "Access in ('LIMITED', 'ALL')");
            else
                FormsList = CommFunc.Fetch_DB_Value("FrmName", "FormDim", "Access = 'ALL'");
            Forms = FormsList.Split('|');
            int Counter = 0;
            ToolStripMenuItem DimensionalView = new ToolStripMenuItem();
            DimensionalView.Text = "Dimensional View";
            while (Counter < Forms.Count())
            {
                ToolStripMenuItem DView = new ToolStripMenuItem(Forms[Counter]);
                DView.Click += DimensionalViewClick;
                DimensionalView.DropDownItems.Add(DView);
                Counter++;
            }
            MenuExMon.Items.Add(DimensionalView);
        }

        private void DimensionalViewClick(object sender, EventArgs e)
        {
            string[] FrmAllowedFreezeCols = "username|".Split('|');
            string FrmName = ((ToolStripMenuItem)sender).Text;
            int FormKey = CommFunc.FetchKey("FormDim", FrmName);
            string FrmTables = CommFunc.Fetch_DB_Value("distinct(TableName)", "MakeFormFact", "FormKey = " + FormKey);
            Color FrmColor = ColorTranslator.FromHtml("#" + CommFunc.Fetch_DB_Value("FrmColor", "FormDim", "FormKey = " + FormKey));
            string FrmSize = CommFunc.Fetch_DB_Value("FrmSize", "FormDim", "FormKey = " + FormKey);
            string FrmFont = CommFunc.Fetch_DB_Value("FrmFont", "FormDim", "FormKey = " + FormKey);
            string FrmFreezeFields = CommFunc.Fetch_DB_MultiValue("FieldName,TableName", "MakeFormFact", "FormKey = " 
                + FormKey + " and IsFreezed = 'Y'");
            string FrmCalculations = CommFunc.Fetch_DB_Value("Calculations", "FormDim", "FormKey = " + FormKey);
            string CalcFuncs = "";
            int CalcFuncCounter = 0;
            while (CalcFuncCounter < FrmCalculations.Split(',').Count() && FrmCalculations != "")
            {
                string FuncNm = FrmCalculations.Split(',')[CalcFuncCounter].Split('(')[0];
                string TblNm = FrmCalculations.Split(',')[CalcFuncCounter].Split('(')[1].Split('.')[0];
                string FieldNm = FrmCalculations.Split(',')[CalcFuncCounter].Split('(')[1].Split('.')[1].Replace(")", "");
                if (CalcFuncs == "")
                    CalcFuncs = FuncNm + "(" + CommFunc.Fetch_DB_Value("ViewFieldName", "AllFieldsDimension",
                            "FieldName = '" + FieldNm + "' and TableName = '" + TblNm + "'") + ")";
                else
                    CalcFuncs = CalcFuncs + "," + FuncNm + "(" + CommFunc.Fetch_DB_Value("ViewFieldName", "AllFieldsDimension",
                            "FieldName = '" + FieldNm + "' and TableName = '" + TblNm + "'") + ")";
                CalcFuncCounter++;
            }

            string AllFrmGroups = "";
            string FrmGroup = "";
            int GroupCounter = 0;
            int FreezeCounter = 0;
            string FreezeField = "";
            while (FreezeCounter < FrmFreezeFields.Split('|').Count() && FrmFreezeFields != "")
            {
                string FieldNm = FrmFreezeFields.Split('|')[FreezeCounter].Replace("::", ",").Split(',')[0];
                string TblNm = FrmFreezeFields.Split('|')[FreezeCounter].Replace("::", ",").Split(',')[1];
                if (FreezeField == "")
                    FreezeField = CommFunc.Fetch_DB_Value("ViewFieldName", "AllFieldsDimension",
                            "FieldName = '" + FieldNm + "' and TableName = '" + TblNm + "'");
                else
                    FreezeField = FreezeField + "|" + CommFunc.Fetch_DB_Value("ViewFieldName", "AllFieldsDimension",
                            "FieldName = '" + FieldNm + "' and TableName = '" + TblNm + "'");
                if (FieldNm.ToLower() == "username")
                    FreezeField = FreezeField + "=" + CommonFunctions.UserNm;
                FreezeCounter++;
            }
            while (GroupCounter == 0 || FrmGroup != "")
            {
                FrmGroup = CommFunc.Fetch_DB_MultiValue("FieldName,TableName", "FormGroupFact", "FormKey = " + FormKey
                    + " and GroupName = 'Group" + Convert.ToString(GroupCounter + 1) + "'");
                if (FrmGroup != "")
                {
                    if (AllFrmGroups == "")
                        AllFrmGroups = FrmGroup.Replace("::", ",");
                    else 
                        AllFrmGroups = AllFrmGroups + "#" + FrmGroup.Replace("::", ",");
                }
                GroupCounter++;
            }
            GroupCounter = 0;
            string AllFrmGroupsViewName = "";
            while (GroupCounter < AllFrmGroups.Split('#').Count() && AllFrmGroups != "")
            {
                int InnerCounter = 0;
                string SingleGroup = AllFrmGroups.Split('#')[GroupCounter];
                while (InnerCounter < SingleGroup.Split('|').Count())
                {
                    string FieldNm = SingleGroup.Split('|')[InnerCounter].Split(',')[0];
                    string TblNm = SingleGroup.Split('|')[InnerCounter].Split(',')[1];
                    if (AllFrmGroupsViewName == "")
                        AllFrmGroupsViewName = CommFunc.Fetch_DB_Value("ViewFieldName", "AllFieldsDimension",
                            "FieldName = '" + FieldNm + "' and TableName = '" + TblNm + "'");
                    else
                        AllFrmGroupsViewName = CommFunc.Fetch_DB_Value("ViewFieldName", "AllFieldsDimension",
                            "FieldName = '" + FieldNm + "' and TableName = '" + TblNm + "'")
                            + "," + AllFrmGroupsViewName;
                    InnerCounter++;
                }
                GroupCounter++;
                AllFrmGroupsViewName = "|" + AllFrmGroupsViewName;
            }
            if (AllFrmGroupsViewName != "")
                AllFrmGroupsViewName = AllFrmGroupsViewName.Replace(",|", "|") + "|";
            if (AllFrmGroupsViewName.StartsWith("|") == true)
                AllFrmGroupsViewName = AllFrmGroupsViewName.Substring(1, AllFrmGroupsViewName.Length - 1);
            string[] CriteriaFields = CommFunc.Fetch_DB_MultiValue("FieldName,TableName", "MakeFormFact", 
                "FormKey = " + FormKey + " and CriteriaOrDisplay = 'C'").Split('|');
            string[] DisplayFields = CommFunc.Fetch_DB_MultiValue("FieldName,TableName", "MakeFormFact",
                "FormKey = " + FormKey + " and CriteriaOrDisplay = 'D'").Split('|');
            int Counter = 0;
            string CriteriaFieldsViewName = "";
            while (Counter < CriteriaFields.Count())
            {
                CriteriaFieldsViewName = CommFunc.Fetch_DB_Value("ViewFieldName", "AllFieldsDimension",
                    "FieldName = '" + CriteriaFields[Counter].Replace("::", "|").Split('|')[0]
                    + "' and TableName = '" + CriteriaFields[Counter].Replace("::", "|").Split('|')[1] + "'")
                    + "|" + CriteriaFieldsViewName;
                Counter++;
            }
            Counter = 0;
            string DisplayFieldsViewName = "";
            while (Counter < DisplayFields.Count())
            {
                DisplayFieldsViewName = CommFunc.Fetch_DB_Value("ViewFieldName", "AllFieldsDimension",
                    "FieldName = '" + DisplayFields[Counter].Replace("::", "|").Split('|')[0]
                    + "' and TableName = '" + DisplayFields[Counter].Replace("::", "|").Split('|')[1] + "'")
                    + "|" + DisplayFieldsViewName;
                Counter++;
            }
            FrmGenSearch DimensionalSearch = new FrmGenSearch(FrmColor, FrmTables, CriteriaFieldsViewName
                + "#" + DisplayFieldsViewName, AllFrmGroupsViewName, FreezeField, CalcFuncs);
            if (FrmSize == "" || FrmSize.ToLower() == "maximized" || FrmSize.ToLower() == "maximised")
                DimensionalSearch.WindowState = FormWindowState.Maximized;
            else
            {
                int FrmHeight = Convert.ToInt16(FrmSize.Split('*')[0]);
                int FrmWidth = Convert.ToInt16(FrmSize.Split('*')[1]);
                DimensionalSearch.Height = FrmHeight;
                DimensionalSearch.Width = FrmWidth;
            }
            DimensionalSearch.Font = new Font(FrmFont, 8, FontStyle.Regular);
            DimensionalSearch.Text = FrmName;
            DimensionalSearch.StartPosition = FormStartPosition.CenterScreen;
            DimensionalSearch.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newTransactioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Accounts = CommFunc.Fetch_DB_Value("Description", "AccountDim", "");
            if (Accounts.Replace("::", "|").Split('|').Count() > 1)
            {
                FrmNewTrans NewTransaction = new FrmNewTrans();
                NewTransaction.Text = "New Transactions";
                NewTransaction.ShowDialog();
            }
            else
                MessageBox.Show("Atleast two accounts should be there to enter Transactions and Transfers.", "message:", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDimType1Generic CurrencyDim = new FrmDimType1Generic("CurrencyDim", "Currencies", Convert.ToDecimal("0.41"));
            CurrencyDim.MdiParent = this;
            CurrencyDim.WindowState = FormWindowState.Maximized;
            CurrencyDim.TransflexReduceWidth(627);
            CurrencyDim.ColourForm(Color.SeaShell);
            CurrencyDim.Show();
        }

        private void enterSeasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEnterSeason EnterSeason = new FrmEnterSeason();
            EnterSeason.BackColor = Color.Goldenrod;
            EnterSeason.StartPosition = FormStartPosition.CenterScreen;
            EnterSeason.Text = "Enter Season";
            EnterSeason.ShowDialog();
        }

        private void enterMajorEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMajorEvents MajorEvent = new FrmMajorEvents();
            MajorEvent.BackColor = Color.Honeydew;
            MajorEvent.StartPosition = FormStartPosition.CenterScreen;
            MajorEvent.Text = "Enter Major Event";
            MajorEvent.ShowDialog();
        }
       
        private void enterLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLocation Location = new FrmLocation();
            Location.BackColor = Color.LightGray;
            Location.StartPosition = FormStartPosition.CenterScreen;
            Location.Text = "Enter Location";
            Location.ShowDialog();
        }

        private void enterSpecialPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSpecialPeriod SpecialPeriod = new FrmSpecialPeriod();
            SpecialPeriod.BackColor = Color.LightSeaGreen;
            SpecialPeriod.StartPosition = FormStartPosition.CenterScreen;
            SpecialPeriod.Text = "Enter Special Period";
            SpecialPeriod.ShowDialog();
        }

        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCreateNewUser NewUser = new FrmCreateNewUser();
            NewUser.Font = this.Font;
            NewUser.ShowDialog();
        }

        private void createDimensionFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGenCreateSearchFrm CreateFrm = new FrmGenCreateSearchFrm();
            CreateFrm.WindowState = FormWindowState.Maximized;
            CreateFrm.BackColor = Color.Lavender;
            CreateFrm.ShowDialog();
        }

        private void createGroupsDimensionFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCreateFromGroups FrmGrp = new FrmCreateFromGroups(new Font("Verdana", 9, FontStyle.Regular));
            FrmGrp.ShowDialog();
        }

        private void editDimensionFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGenCreateSearchFrm CreateFrm = new FrmGenCreateSearchFrm(true);
            CreateFrm.WindowState = FormWindowState.Maximized;
            CreateFrm.BackColor = Color.Lavender;
            CreateFrm.ShowDialog();
        }

        private void deleteDimensionFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form DeleteDimForm = new Form();
            DeleteDimForm.Text = "Delete Dimension Search Form";
            DeleteDimForm.Size = new Size(300, 160);
            DeleteDimForm.StartPosition = FormStartPosition.CenterScreen;
            DeleteDimForm.Font = this.Font;
            ComboBox CmbDimForms = new ComboBox();
            CmbDimForms.Location = new Point(25, 30);
            CmbDimForms.Width = 220;
            CommFunc.Fill_Combo(CmbDimForms, "FrmName", "FormDim", "");
            if (CmbDimForms.Items.Count > 0)
                CmbDimForms.SelectedIndex = 0;
            SelectedDeleteDimForm = CmbDimForms.Text;
            CmbDimForms.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbDimForms.SelectedIndexChanged += new EventHandler(FillComboSelectedIndexChanged);
            DeleteDimForm.Controls.Add(CmbDimForms);
            Button BtnDeleteForm = new Button();
            BtnDeleteForm.Text = "Delete Form";
            BtnDeleteForm.Location = new Point(CmbDimForms.Location.X, CmbDimForms.Location.Y + CmbDimForms.Height + 10);
            BtnDeleteForm.Size = new Size(100, 40);
            BtnDeleteForm.FlatStyle = FlatStyle.System;
            BtnDeleteForm.Click += new EventHandler(DeleteDimFormClick);
            DeleteDimForm.Controls.Add(BtnDeleteForm);
            DeleteDimForm.BackColor = Color.DimGray;
            GroupBox GrpDeleteForm = new GroupBox();
            GrpDeleteForm.Location = new Point(CmbDimForms.Location.X - 5, CmbDimForms.Location.Y - 15);
            GrpDeleteForm.Width = CmbDimForms.Width + 10;
            GrpDeleteForm.Height = CmbDimForms.Height + BtnDeleteForm.Height + 30;
            DeleteDimForm.Controls.Add(GrpDeleteForm);
            DeleteDimForm.ShowDialog();
        }

        private void DeleteDimFormClick(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Really want to delete the Form: " + SelectedDeleteDimForm + "?", "message:", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                int FormKey = CommFunc.FetchKey("FormDim", SelectedDeleteDimForm);
                CommFunc.delete_table("FormGroupFact", "FormKey = " + FormKey);
                CommFunc.delete_table("MakeFormFact", "FormKey = " + FormKey);
                CommFunc.delete_table("FormDim", "FormKey = " + FormKey);
                MessageBox.Show(SelectedDeleteDimForm + " Form was deleted.", "message:", MessageBoxButtons.OK);
                ((Button)sender).Enabled = false;
            }
        }

        private void FillComboSelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedDeleteDimForm = ((ComboBox)sender).Text;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FrmRepeatingTrans RepeatTrans = new FrmRepeatingTrans();
            Color Clr = Color.FromArgb(225, 255, 240);
            RepeatTrans.SetFrmColor(Clr);
            RepeatTrans.Font = this.Font;
            RepeatTrans.StartPosition = FormStartPosition.CenterScreen;
            RepeatTrans.ShowDialog();
        }

        private void toolStripBtnDelete_Click(object sender, EventArgs e)
        {
            FrontForm.DeleteRecords();
        }

        private void NewTransaction_Click(object sender, EventArgs e)
        {
            newTransactioToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrontForm.AddToAssets();
        }

        private void undoLastTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boolean TransFound = false;
            int LastTranNo = CommFunc.FetchMaxTransactionNo();
            int UserKey = CommFunc.FetchKey("UserDim", CommonFunctions.UserNm);
            while (TransFound == false && LastTranNo != 0)
            {
                string LastTransaction = CommFunc.select_table("TransactionFact", "DateKey|TransactionTypeKey|Amount", 
                    "TransactionId=" + LastTranNo + "|UserKey=" + UserKey);
                if (LastTransaction != "")
                {
                    TransFound = true;
                    string Date = CommFunc.select_table("DateDim", "Date1", "DateKey=" + LastTransaction.Split('|')[0]).Split(' ')[0];
                    Date = Convert.ToDateTime(Date).ToString("dd-MM-yyyy");
                    string Purpose = CommFunc.select_table("TransactionTypeDim", "Hierarchy|Category|Description", 
                        "TransactionTypeKey=" + LastTransaction.Split('|')[1]);
                    DialogResult DResult = MessageBox.Show("Do you want transaction with : '" + Purpose.Replace("|", "->") 
                        + "' and Amount: '" + LastTransaction.Split('|')[2] + "' for Date: " + Date 
                        + " to be deleted.", "", MessageBoxButtons.YesNo);
                    if (DResult == DialogResult.Yes)
                    {
                        CommFunc.delete_table("TransactionFact", "TransactionId=" + LastTranNo);
                        MessageBox.Show("The transaction with : '" + Purpose.Replace("|", "->") + "' and Amount: '"
                            + LastTransaction.Split('|')[2] + "' for Date: " + Date + " was deleted.", "", MessageBoxButtons.OK);
                    }
                }
                if (TransFound == false)
                    LastTransaction = CommFunc.select_table("AccountTransferFact", "DateKey|FromAccountKey|ToAccountKey|Amount",
                    "TransactionId=" + LastTranNo);
                else
                    LastTransaction = "";
                if (LastTransaction != "")
                {
                    TransFound = true;
                    string Date = CommFunc.select_table("DateDim", "Date1", "DateKey=" + LastTransaction.Split('|')[0]).Split(' ')[0];
                    Date = Convert.ToDateTime(Date).ToString("dd-MM-yyyy");
                    string FromAccount = CommFunc.select_table("AccountDim", "Description", "AccountKey=" + LastTransaction.Split('|')[1]);
                    string ToAccount = CommFunc.select_table("AccountDim", "Description", "AccountKey=" + LastTransaction.Split('|')[2]);
                    DialogResult DResult = MessageBox.Show("Do you want the transfer of Amount: " + LastTransaction.Split('|')[3] + " from Account: '" + FromAccount
                        + "' to Account: '" + ToAccount + "' for Date: " + Date + " to be deleted.", "", MessageBoxButtons.YesNo);
                    if (DResult == DialogResult.Yes)
                    {
                        CommFunc.delete_table("AccountTransferFact", "TransactionId=" + LastTranNo);
                        MessageBox.Show("The transfer of Amount: " + LastTransaction.Split('|')[3] + " from Account: '" + FromAccount
                            + "' to Account: '" + ToAccount + "' for Date: " + Date + " was deleted.", "", MessageBoxButtons.OK);
                    }
                }
                LastTranNo--;
            }
            if (LastTranNo == 0)
                MessageBox.Show("There is no transaction to Undo.", "", MessageBoxButtons.OK);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            undoLastTransactionToolStripMenuItem_Click(sender, e);
        }

        private void assetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDimType1Generic AssetTypeDim = new FrmDimType1Generic("AssetTypeDim", "Asset Types", Convert.ToDecimal("0.978"));
            AssetTypeDim.MdiParent = this;
            AssetTypeDim.WindowState = FormWindowState.Maximized;
            AssetTypeDim.TransflexReduceWidth(627);
            AssetTypeDim.ColourForm(Color.SeaShell);
            AssetTypeDim.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDimGeneric FrmUsers = new FrmDimGeneric("UserDim", "Verdana", "Users", 1, true);
            FrmUsers.WindowState = FormWindowState.Maximized;
            FrmUsers.BackColor = Color.PaleTurquoise;
            FrmUsers.ColourForm(Color.PaleTurquoise);
            FrmUsers.TransflexReduceWidth(359);
            FrmUsers.ShowDialog();
        }

        private void importXlsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUploadXls UploadXls = new FrmUploadXls();
            UploadXls.Font = this.Font;
            UploadXls.BackColor = Color.Moccasin;
            UploadXls.Text = "Import From Xls";
            UploadXls.StartPosition = FormStartPosition.CenterScreen;
            UploadXls.ShowDialog();
        }

        private void compareTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompareTransactions CompareTransactions = new FrmCompareTransactions();
            CompareTransactions.BackColor = Color.Goldenrod;
            CompareTransactions.Font = this.Font;
            CompareTransactions.WindowState = FormWindowState.Maximized;
            CompareTransactions.Text = "Compare Transactions";
            CompareTransactions.ShowDialog();
        }

        private void changeTransactionTypeCDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmChangeTransactionTypeCorD ChangeCD = new FrmChangeTransactionTypeCorD();
            ChangeCD.Font = this.Font;
            ChangeCD.BackColor = Color.Cornsilk;
            ChangeCD.StartPosition = FormStartPosition.CenterScreen;
            ChangeCD.ShowDialog();
        }

        private void toolStripExcelUpload_Click(object sender, EventArgs e)
        {
            importXlsFileToolStripMenuItem_Click(sender, e);
        }

        private void toolStripBackupData_Click(object sender, EventArgs e)
        {
            string BackupCommand = "";
            string BackupFileName = "";
            string Password = "";
            SaveFileDialog DBBackupFile = new SaveFileDialog();
            DBBackupFile.InitialDirectory = @"C:\";
            DBBackupFile.Title = "Choose Backup File";
            if (DBBackupFile.ShowDialog() == DialogResult.OK)
            {
                BackupFileName = DBBackupFile.FileName;
            }
            if (BackupFileName != "")
            {
                FrmChoosePassword ChoosePassword = new FrmChoosePassword();
                ChoosePassword.Font = this.Font;
                ChoosePassword.BackColor = Color.SteelBlue;
                ChoosePassword.StartPosition = FormStartPosition.CenterScreen;
                var Res = ChoosePassword.ShowDialog();
                if (Res == DialogResult.OK)
                    Password = ChoosePassword.ReturnValue;
                BackupCommand = "backup database ExMon to disk = '" + BackupFileName + "' with password = '" + Password + "'";
                CommFunc.Execute_DB_Command(BackupCommand);
            }
        }

        private void toolStripRestoreBackup_Click(object sender, EventArgs e)
        {
            string RestoreCommand = "";
            string BackupFileName = "";
            string Password = "";
            OpenFileDialog DBBackupFile = new OpenFileDialog();
            DBBackupFile.InitialDirectory = @"C:\";
            DBBackupFile.Title = "Choose Backup File";
            DBBackupFile.ShowReadOnly = true;
            if (DBBackupFile.ShowDialog() == DialogResult.OK)
            {
                BackupFileName = DBBackupFile.FileName;
            }
            FrmChoosePassword ChoosePassword = new FrmChoosePassword();
            ChoosePassword.Font = this.Font;
            ChoosePassword.BackColor = Color.Teal;
            ChoosePassword.StartPosition = FormStartPosition.CenterScreen;
            var Res = ChoosePassword.ShowDialog();
            if (Res == DialogResult.OK)
                Password = ChoosePassword.ReturnValue;
            RestoreCommand = "restore database ExMon from disk = '" + BackupFileName + "' with password = '" + Password + "'";
            try {
                CommFunc.Execute_DB_Command(RestoreCommand);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("ERROR: " + Ex, "error:", MessageBoxButtons.OK);
            }
        }

        private void backupDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripBackupData_Click(sender, e);
        }

        private void toolStripAddtoAssests_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void toolStripCalculateAssets_Click(object sender, EventArgs e)
        {
            int DateKey = CommFunc.FetchKey("DateDim", DateTime.Now.ToString("dd-MM-yyyy"));
            CommFunc.Execute_DB_Command("EXEC Calculate_Assets " + Convert.ToString(DateKey));
            MessageBox.Show("Assets Calculated as of today.", "message:", MessageBoxButtons.OK);
        }

        private void removeAssestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRemoveAssets RemoveAssets = new FrmRemoveAssets();
            RemoveAssets.Font = this.Font;
            RemoveAssets.BackColor = Color.Khaki;
            RemoveAssets.ShowDialog();
        }

        private void toolStripAbout_Click(object sender, EventArgs e)
        {
            FrmAbout About = new FrmAbout();
            About.Font = this.Font;
            About.ShowDialog();
        }

        private void enterExchangeRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExchangeRate ExchgRate = new FrmExchangeRate();
            ExchgRate.Font = this.Font;
            ExchgRate.BackColor = Color.LightBlue;
            ExchgRate.StartPosition = FormStartPosition.CenterScreen;
            ExchgRate.Text = "Enter Exchange Rate";
            ExchgRate.ShowDialog();
        }

        private void introductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIntro Intro = new FrmIntro();
            Intro.Font = this.Font;
            Intro.ShowDialog();
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            Refresh = true;
            FrontForm.FrmFront_Load(sender, e);
            CreateSearchMenuItems();
            CommFunc.Execute_DB_Command("DELETE FROM AssetCalculations");
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCreateNewUser NewUser = new FrmCreateNewUser("ChangePassword");
            NewUser.Font = this.Font;
            NewUser.ShowDialog();
        }

        private void toolStripDeleteUser_Click(object sender, EventArgs e)
        {
            FrmDeleteUser DeleteUser = new FrmDeleteUser();
            DeleteUser.Font = this.Font;
            DeleteUser.BackColor = Color.Thistle;
            DeleteUser.StartPosition = FormStartPosition.CenterParent;
            DeleteUser.ShowDialog();
        }

        private void userManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://C:\\Projects\\User Manual Files\\User Manual.chm");
        }
        
    }
}
