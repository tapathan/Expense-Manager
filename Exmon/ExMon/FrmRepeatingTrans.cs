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
    public partial class FrmRepeatingTrans : Form
    {
        public FrmRepeatingTrans()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();

        private void FrmRepeatingTrans_Load(object sender, EventArgs e)
        {
            this.Text = "Repeating Transactions";
            string DisplayCols = "Select,6|Account,20|Account Type,16|AccountKey,8|"
                + "Hierarchy,20|Category,22|Description,22|TransactionTypeKey,8|Amount,14|Comments,40";
            string[] DisplayColsArr = DisplayCols.Split('|');
            int loopcounter = 0;
            while (loopcounter < DisplayColsArr.Length)
            {
                if (loopcounter == 0)
                {
                    loopcounter++;
                    continue;
                }
                DGVResult.Columns.Add(DisplayColsArr[loopcounter].Split(',')[0], DisplayColsArr[loopcounter].Split(',')[0]);
                DGVResult.Columns[loopcounter].Width = 7 * Convert.ToInt16(DisplayColsArr[loopcounter].Split(',')[1]);
                DGVResult.Columns[loopcounter].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (DisplayColsArr[loopcounter].Contains("Key") == true)
                    DGVResult.Columns[loopcounter].Visible = false;
                if (loopcounter < 8)
                    DGVResult.Columns[loopcounter].ReadOnly = true;
                loopcounter++;
            }
            LoadDGV();
        }

        private void LoadDGV()
        {
            DGVResult.Rows.Clear();
            string SelectedDate = dtp.Value.ToString("yyyy-MM-dd");
            string Prev8Date = dtp.Value.AddDays(-7).ToString("yyyy-MM-dd");
            string Result = CommFunc.select_table("TransactionFact,AccountDim,TransactionTypeDim,DateDim",
                "'True' Selectit|AccountDim.Description|AccountDim.Type|TransactionFact.AccountKey|TransactionTypeDim.Hierarchy|"
                + "TransactionTypeDim.Category|TransactionTypeDim.Description|TransactionFact.TransactionTypeKey|"
                + "max(TransactionFact.Amount)|max(TransactionFact.Comments)",
                "DateDim.Date1 >= " + Prev8Date + "|DateDim.Date1 < '"
                + SelectedDate + "'|TransactionFact.DateKey==DateDim.DateKey|TransactionFact.AccountKey==AccountDim.AccountKey|"
                + "TransactionFact.TransactionTypeKey==TransactionTypeDim.TransactionTypeKey"
                + " group by AccountDim.Description,AccountDim.Type,TransactionFact.AccountKey,"
                + "TransactionTypeDim.Hierarchy,TransactionTypeDim.Category,TransactionTypeDim.Description,"
                + "TransactionFact.TransactionTypeKey having count(*) > 2");
            int loopcounter = 0;
            while (loopcounter < Result.Split('#').Length && Result != "")
            {
                DGVResult.Rows.Add(Result.Split('#')[loopcounter].Split('|'));
                loopcounter++;
            }
            DGVResult.AllowUserToAddRows = false;
            DGVResult.Columns[0].Width = 48;
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            int loopcounter = 0;
            int TransactionNo;
            int DateKey = CommFunc.FetchKey("DateDim", dtp.Value.ToString("dd-MM-yyyy"));
            int AccountKey = 0;
            int TransactionTypeKey = 0;
            decimal Amount;
            string Comments = "";
            while (loopcounter < DGVResult.RowCount)
            {
                if (Convert.ToBoolean(DGVResult[0, loopcounter].Value) == true)
                {
                    TransactionNo = CommFunc.FetchMaxTransactionNo() + 1;
                    AccountKey = Convert.ToInt16(DGVResult["AccountKey", loopcounter].Value);
                    TransactionTypeKey = Convert.ToInt16(DGVResult["TransactionTypeKey", loopcounter].Value);
                    Amount = Convert.ToDecimal(DGVResult["Amount", loopcounter].Value);
                    Comments = Convert.ToString(DGVResult["Comments", loopcounter].Value);
                    int UserKey = CommFunc.FetchKey("UserDim", CommonFunctions.UserNm);
                    if (Amount != 0)
                    {
                        CommFunc.insert_table("TransactionFact", DateKey + "|" + UserKey + "|"
                            + AccountKey + "|" + TransactionTypeKey + "|" + TransactionNo + "|" + Amount + "|" + Comments + "|"
                            + "" + "|" + "null" + "|" + "null" + "|" + "null" + "|" + "");
                        DGVResult.Rows.RemoveAt(loopcounter);
                        loopcounter--;
                    }
                }
                loopcounter++;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetFrmColor(Color Clr)
        {
            this.BackColor = Clr;
        }

    }
}
