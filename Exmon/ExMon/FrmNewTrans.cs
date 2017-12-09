using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExMon
{
    public partial class FrmNewTrans : Form
    {
        public FrmNewTrans()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();
        Boolean SearchKeyHit = true;
        Boolean FromTextChange = false;
        Boolean TxtSearchKeyHit = true;
        Boolean TxtFromTextChange = false;
        Boolean TxtSearchKeyHitTransfer = true;
        Boolean TxtFromTextChangeTransfer = false;

        private void FrmNewTrans_Load(object sender, EventArgs e)
        {
            this.AcceptButton = BtnEnter;
            TabcTaransaction.Font = new Font("Verdana", 8, FontStyle.Regular);
            this.BackColor = Color.AliceBlue;
            TabTransaction.BackColor = Color.GhostWhite;
            TabTransfer.BackColor = Color.Honeydew;
            BtnSearchTransactionType.BackgroundImage = Properties.Resources.IcnSearch.ToBitmap();
            BtnSearchTransactionType.BackgroundImageLayout = ImageLayout.Stretch;
            CommFunc.Fill_Combo(CmbAccount, "Description", "AccountDim", "", DtpDate.Value);
            if (CmbAccount.Items.Count > 0)
                CmbAccount.SelectedIndex = 0;
            CommFunc.Fill_Combo(CmbAccountType, "Type", "AccountDim", "Description = '" + CmbAccount.Text + "'", DtpDate.Value);
            CmbAccountType.SelectedIndex = 0;
            CommFunc.Fill_Combo(CmbCurrency, "CurrencyCode", "CurrencyDim", "");
            CmbCurrency.Text = CommFunc.Fetch_DB_Value("CurrencyCode", "CurrencyDim", "CurrentlyUsedInd = 'Y'");

            CommFunc.Fill_Combo(CmbFromAccountTransfer, "Description", "AccountDim", "", DtpDateTransfer.Value);
            if (CmbFromAccountTransfer.Items.Count > 1)
                CmbFromAccountTransfer.SelectedIndex = 1;            

            ActiveControl = CmbType;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            CommFunc.Fill_Combo(CmbAccount, "Description", "AccountDim", "", DtpDate.Value);
            if (CmbAccount.Items.Count > 0)
                CmbAccount.SelectedIndex = 0;
            CommFunc.Fill_Combo(CmbAccountType, "Type", "AccountDim", "Description = '" + CmbAccount.Text + "'", DtpDate.Value);
            CmbAccountType.SelectedIndex = 0;
        }

        private void CmbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                SearchKeyHit = true;
            else
                SearchKeyHit = false;
            FromTextChange = false;
        }

        private void CmbType_TextChanged(object sender, EventArgs e)
        {
            int NumberOfChar = CmbType.Text.Length - CmbType.SelectedText.Length;
            if (SearchKeyHit == true && FromTextChange == false)
            {
                CmbType.Items.Clear();
                string Desc = "", Category = "", Hier = "";
                string EnteredText = CmbType.Text.Substring(0, CmbType.Text.Length - CmbType.SelectedText.Length).Replace("::", ":");
                string QueryRes = "";
                int LoopCounter = 0;
                if (EnteredText.Split(':').Count() == 3)
                {
                    Desc = EnteredText.Split(':')[0];
                    Category = EnteredText.Split(':')[1];
                    Hier = EnteredText.Split(':')[2];
                    QueryRes = CommFunc.Fetch_DB_MultiValue("Description,Category,Hierarchy", "TransactionTypeDim", "Description like '"
                        + Desc + "%' and Category like '" + Category + "%' and Hierarchy like '" + Hier + "%'");
                    while (LoopCounter < QueryRes.Split('|').Count())
                    {
                        CmbType.Items.Add(QueryRes.Split('|')[LoopCounter]);
                        LoopCounter++;
                    }
                    FromTextChange = true;
                    if (QueryRes != "")
                        CmbType.SelectedIndex = 0;
                    CmbType.Select(NumberOfChar, CmbType.Text.Length - NumberOfChar);
                }
                if (EnteredText.Split(':').Count() == 2)
                {
                    Desc = EnteredText.Split(':')[0];
                    Category = EnteredText.Split(':')[1];
                    QueryRes = CommFunc.Fetch_DB_MultiValue("Description,Category,Hierarchy", "TransactionTypeDim", "Description like '"
                        + Desc + "%' and Category like '" + Category + "%'");
                    while (LoopCounter < QueryRes.Split('|').Count())
                    {
                        CmbType.Items.Add(QueryRes.Split('|')[LoopCounter]);
                        LoopCounter++;
                    }
                    FromTextChange = true;
                    if (QueryRes != "")
                        CmbType.SelectedIndex = 0;
                    CmbType.Select(NumberOfChar, CmbType.Text.Length - NumberOfChar);
                }
                if (EnteredText.Split(':').Count() == 1)
                {
                    Desc = EnteredText;
                    QueryRes = CommFunc.Fetch_DB_MultiValue("Description,Category,Hierarchy", "TransactionTypeDim", "Description like '"
                        + Desc + "%'");
                    while (LoopCounter < QueryRes.Split('|').Count())
                    {
                        CmbType.Items.Add(QueryRes.Split('|')[LoopCounter]);
                        LoopCounter++;
                    }
                    FromTextChange = true;
                    if (QueryRes != "")
                        CmbType.SelectedIndex = 0;
                    CmbType.Select(NumberOfChar, CmbType.Text.Length - NumberOfChar);
                }
                else
                    FromTextChange = false;
            }
        }

        private void RtxComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                TxtSearchKeyHit = true;
            else
                TxtSearchKeyHit = false;
            TxtFromTextChange = false;
        }

        private void RtxComments_TextChanged(object sender, EventArgs e)
        {
            string QueryRes = "";
            int NumberOfChar = RtxComments.Text.Length - RtxComments.SelectedText.Length;
            if (TxtSearchKeyHit == true && TxtFromTextChange == false && ChkAutoComplete.Checked == true)
            {
                string EnteredText = RtxComments.Text;
                QueryRes = CommFunc.Fetch_DB_Value("distinct(Comments)", "TransactionFact", "Comments like '"
                        + EnteredText + "%'");
                QueryRes = QueryRes.Split('|')[0];
                if (QueryRes != "")
                {
                    RtxComments.Text = QueryRes;
                    RtxComments.Select(NumberOfChar, RtxComments.Text.Length - NumberOfChar);
                }
                TxtFromTextChange = false;
            }
            else
                TxtFromTextChange = false;
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            string EnteredText = CmbType.Text.Replace("::", ":");
            if (CmbAccount.Text == "" || EnteredText == "" || TxtAmount.Text == "")
                MessageBox.Show("Account, Transaction Type and Amount fields are mandatory.", "message:", MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            else
            {
                string Desc = "", Category = "", Hier = "";
                if (EnteredText.Split(':').Count() == 3)
                {
                    Desc = EnteredText.Split(':')[0];
                    Category = EnteredText.Split(':')[1];
                    Hier = EnteredText.Split(':')[2];
                }
                int TransactionTypeKey = CommFunc.FetchKey("TransactionTypeDim", Desc + "^" + Category + "^" + Hier);
                if (TransactionTypeKey == 0)
                    MessageBox.Show("Invalid Transaction Type provided.", "message:", MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                else
                {
                    int AccountKey = CommFunc.FetchKey("AccountDim", CmbAccount.Text + "^" + CmbAccountType.Text);
                    int CurrencyKey = CommFunc.FetchKey("CurrencyDim", CmbCurrency.Text);
                    decimal ExchgRate = 1;
                    string CurrencyType = CommFunc.Fetch_DB_Value("CurrentlyUsedInd", "CurrencyDim", "CurrencyCode = '" 
                        + CmbCurrency.Text + "'");
                    int DateKey = CommFunc.FetchKey("DateDim", DtpDate.Value.ToString("dd-MM-yyyy"));
                    int ExchgMaxDateKey = 0;
                    if (CurrencyType != "Y")
                    {
                        ExchgMaxDateKey = Convert.ToInt16(CommFunc.Fetch_DB_Value("Max(DateKey)", "ExchangeRatesFact", "DateKey <= "
                        + DateKey + " and CurrencyKey = " + CurrencyKey));
                        ExchgRate = Convert.ToDecimal(CommFunc.Fetch_DB_Value("ExchangeRate", "ExchangeRatesFact", "DateKey = "
                            + Convert.ToString(ExchgMaxDateKey) + " and CurrencyKey = " + Convert.ToString(CurrencyKey)));
                    }
                    int UserKey = CommFunc.FetchKey("UserDim", CommonFunctions.UserNm);
                    int TransactionId = CommFunc.FetchMaxTransactionNo() + 1;
                    string FollowUpInd = "";
                    string AssetInd = "";
                    if (ChkFollowup.Checked == true)
                        FollowUpInd = "Y";
                    if (ChkAsset.Checked == true)
                        AssetInd = "Y";
                    decimal Amount = Convert.ToDecimal(TxtAmount.Text) * ExchgRate;
                    CommFunc.Insert_into_DB(DateKey + "," + UserKey + "," + AccountKey + ","
                        + TransactionTypeKey + "," + TransactionId + "," + Amount + ",'" + RtxComments.Text
                        + "','" + FollowUpInd + "',NULL,NULL,NULL,'" + AssetInd + "'", "TransactionFact");
                    CmbType.Items.Clear();
                    CmbType.Text = "";
                    TxtAmount.Text = "";
                    TxtSearchKeyHit = false;
                    RtxComments.Text = "";
                    ChkFollowup.Checked = false;
                    ChkAsset.Checked = false;
                    ChkAutoComplete.Checked = true;
                    CommFunc.Fill_Combo(CmbAccount, "Description", "AccountDim", "", DtpDate.Value);
                    CmbAccount.SelectedIndex = 0;
                    CommFunc.Fill_Combo(CmbAccountType, "Type", "AccountDim", "Description = '" + CmbAccount.Text + "'", DtpDate.Value);
                    CmbAccountType.SelectedIndex = 0;
                    CommFunc.Fill_Combo(CmbCurrency, "CurrencyCode", "CurrencyDim", "");
                    CmbCurrency.Text = CommFunc.Fetch_DB_Value("CurrencyCode", "CurrencyDim", "CurrentlyUsedInd = 'Y'");
                    ActiveControl = CmbType;
                    CmbType.Text = "";
                    CmbType.Items.Clear();
                }
            }
        }

        private void CmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommFunc.Fill_Combo(CmbAccountType, "Type", "AccountDim", "Description = '" + CmbAccount.Text + "'", DtpDate.Value);
            CmbAccountType.SelectedIndex = 0;
        }

        private void BtnSearchTransactionType_Click(object sender, EventArgs e)
        {
            FrmTransactionType SearchTransactionType = new FrmTransactionType(true);
            var TransTypeRes = SearchTransactionType.ShowDialog();
            string TransTypeVal = "";
            if (TransTypeRes == DialogResult.OK)
                TransTypeVal = SearchTransactionType.ReturnValue1;
            CmbType.Text = TransTypeVal;
            CmbType.Select(CmbType.Text.Length, 0);
        }

        private void BtnCloseTransfer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnterTransfer_Click(object sender, EventArgs e)
        {
            if (CmbFromAccountTransfer.Text == "" || TxtAmountTransfer.Text == "")
                MessageBox.Show("From Account, To Account and Amount are mandatory.", "message:"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int TransactionId = CommFunc.FetchMaxTransactionNo() + 1;
                int FromAccountKey = CommFunc.FetchKey("AccountDim", CmbFromAccountTransfer.Text + "^"
                    + CmbFromAccountTypeTransfer.Text);
                int ToAccountKey = CommFunc.FetchKey("AccountDim", CmbToAccountTransfer.Text + "^"
                    + CmbToAccountTypeTransfer.Text);
                int DateKey = CommFunc.FetchKey("DateDim", DtpDateTransfer.Value.ToString("dd-MM-yyyy"));
                CommFunc.Insert_into_DB(DateKey + "," + FromAccountKey + "," + ToAccountKey + "," + TransactionId + ","
                    + TxtAmountTransfer.Text + ",'" + RtxCommentsTransfer.Text + "'", "AccountTransferFact");
                TxtAmountTransfer.Text = "";
                TxtSearchKeyHitTransfer = false;
                RtxCommentsTransfer.Text = "";
                ChkAutoCompTransfer.Checked = true;
                CommFunc.Fill_Combo(CmbFromAccountTransfer, "Description", "AccountDim", "", DtpDateTransfer.Value);
                CmbFromAccountTransfer.SelectedIndex = 0;  
            }
        }

        private void CmbFromAccountTransfer_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommFunc.Fill_Combo(CmbFromAccountTypeTransfer, "Type", "AccountDim", "Description = '"
                + CmbFromAccountTransfer.Text + "'", DtpDateTransfer.Value);
            CmbFromAccountTypeTransfer.SelectedIndex = 0;
        }

        private void DtpDateTransfer_ValueChanged(object sender, EventArgs e)
        {
            CmbFromAccountTypeTransfer.Text = "";
            CmbToAccountTypeTransfer.Items.Clear();
            CmbToAccountTypeTransfer.Text = "";
            CmbToAccountTypeTransfer.Items.Clear();
            CommFunc.Fill_Combo(CmbFromAccountTransfer, "Description", "AccountDim", "", DtpDateTransfer.Value);
            if (CmbFromAccountTransfer.Items.Count > 0)
                CmbFromAccountTransfer.SelectedIndex = 0;
        }

        private void CmbToAccountTransfer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int FromAccountKey = CommFunc.FetchKey("AccountDim", CmbFromAccountTransfer.Text + "^"
                    + CmbFromAccountTypeTransfer.Text);
            CommFunc.Fill_Combo(CmbToAccountTypeTransfer, "Type", "AccountDim", "Description = '"
                + CmbToAccountTransfer.Text + "' and AccountKey != " + FromAccountKey, DtpDateTransfer.Value);
            CmbToAccountTypeTransfer.SelectedIndex = 0;
        }

        private void CmbFromAccountTypeTransfer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int FromAccountKey = CommFunc.FetchKey("AccountDim", CmbFromAccountTransfer.Text + "^"
                + CmbFromAccountTypeTransfer.Text);

            CommFunc.Fill_Combo(CmbToAccountTransfer, "Description", "AccountDim", "AccountKey != "
                + FromAccountKey, DtpDateTransfer.Value);
            CmbToAccountTransfer.SelectedIndex = 0;
        }

        private void RtxCommentsTransfer_TextChanged(object sender, EventArgs e)
        {
            string QueryRes = "";
            int NumberOfChar = RtxCommentsTransfer.Text.Length - RtxCommentsTransfer.SelectedText.Length;
            if (TxtSearchKeyHitTransfer == true && TxtFromTextChangeTransfer == false && ChkAutoCompTransfer.Checked == true)
            {
                string EnteredText = RtxCommentsTransfer.Text;
                QueryRes = CommFunc.Fetch_DB_Value("distinct(Comments)", "AccountTransferFact", "Comments like '"
                        + EnteredText + "%'");
                QueryRes = QueryRes.Split('|')[0];
                if (QueryRes != "")
                {
                    RtxCommentsTransfer.Text = QueryRes;
                    RtxCommentsTransfer.Select(NumberOfChar, RtxCommentsTransfer.Text.Length - NumberOfChar);
                }
                TxtFromTextChangeTransfer = false;
            }
            else
                TxtFromTextChangeTransfer = false;
        }

        private void RtxCommentsTransfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                TxtSearchKeyHitTransfer = true;
            else
                TxtSearchKeyHitTransfer = false;
            TxtFromTextChangeTransfer = false;
        }

    }
}
