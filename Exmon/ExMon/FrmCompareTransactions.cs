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
    public partial class FrmCompareTransactions : Form
    {
        public FrmCompareTransactions()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();
        string SelectedHierarchies = "";

        private void FrmCompareTransactions_Load(object sender, EventArgs e)
        {
            CommFunc.Fill_Combo(CmbTransactionHierarchy, "Hierarchy", "TransactionTypeDim", "");
            CmbTransactionHierarchy.SelectedIndex = 0;
            ChkCategory.Checked = true;
            ChkDescription.Checked = true;
            ChkComments.Checked = true;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            DgvComparison.Rows.Clear();
            DgvTransactions.Rows.Clear();
            SelectedHierarchies = "";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (SelectedHierarchies == "")
                SelectedHierarchies = CmbTransactionHierarchy.Text;
            else
                SelectedHierarchies = SelectedHierarchies + "','" + CmbTransactionHierarchy.Text;
            FillDGVTransactions();
            FillDGVComparision();
        }

        private void FillDGVTransactions()
        {
            DgvTransactions.Rows.Clear();
            CommFunc.QueryFactFillDGV("TransactionFact", "DateDim,UserDim,AccountDim,TransactionTypeDim", "Date1 <= '"
                + DtpDate.Value.ToString("yyyy/MM/dd") + "' AND TransactionTypeDimHierarchy IN ('" + SelectedHierarchies + "')"
                + " AND UserDimUsername = '" + CommonFunctions.UserNm + "'",
                "DateDimDate1,TransactionTypeDimDescription,TransactionTypeDimCategory,TransactionTypeDimHierarchy,TransactionFactComments," 
                + "TransactionFactAmount,TransactionTypeDimCreditDebitInd",
                DgvTransactions, Convert.ToDecimal("5.1"));
        }

        private void FillDGVComparision()
        {
            string ComparisionSelectFields = "";
            if (ChkDescription.Checked == true)
            {
                if (ComparisionSelectFields == "")
                    ComparisionSelectFields = "TransactionTypeDimDescription";
                else
                    ComparisionSelectFields = ComparisionSelectFields + "," + "TransactionTypeDimDescription";
            }
            if (ChkCategory.Checked == true)
            {
                if (ComparisionSelectFields == "")
                    ComparisionSelectFields = "TransactionTypeDimCategory";
                else
                    ComparisionSelectFields = ComparisionSelectFields + "," + "TransactionTypeDimCategory";
            }
            if (ChkComments.Checked == true)
            {
                if (ComparisionSelectFields == "")
                    ComparisionSelectFields = "TransactionFactComments";
                else
                    ComparisionSelectFields = ComparisionSelectFields + "," + "TransactionFactComments";
            }
            if (ComparisionSelectFields != "")
                ComparisionSelectFields = ComparisionSelectFields + ",";
            DgvComparison.Rows.Clear();
            CommFunc.QueryFactFillDGV("TransactionFact", "DateDim,UserDim,AccountDim,TransactionTypeDim", "Date1 <= '"
                + DtpDate.Value.ToString("yyyy/MM/dd") + "' AND TransactionTypeDimHierarchy IN ('" + SelectedHierarchies + "')"
                + " AND UserDimUsername = '" + CommonFunctions.UserNm + "' GROUP BY " + ComparisionSelectFields
                + "TransactionTypeDimCreditDebitInd ORDER BY " + ComparisionSelectFields
                + "TransactionTypeDimCreditDebitInd", ComparisionSelectFields
                + "TransactionTypeDimCreditDebitInd,SUM(TransactionFactAmount) AS Amount",
                DgvComparison, Convert.ToDecimal("5.4"));
            string JoinValue1 = "";
            string JoinValue2 = "";
            string JoinValue3 = "";
            string PrevJoinValue1 = "";
            string PrevJoinValue2 = "";
            string PrevJoinValue3 = "";
            decimal Amount = 0;
            decimal PrevAmount = 0;
            string CreditOrDebit = "";
            int Counter = 0;
            Boolean AllUnchecked = false;
            if (ChkCategory.Checked == false && ChkDescription.Checked == false && ChkComments.Checked == false)
                AllUnchecked = true;
            int ColumnCount = DgvComparison.Columns.Count;
            while (Counter < DgvComparison.Rows.Count)
            {
                JoinValue1 = DgvComparison[0, Counter].Value.ToString();
                if (ColumnCount > 3)
                    JoinValue2 = DgvComparison[1, Counter].Value.ToString();
                if (ColumnCount > 4)
                    JoinValue3 = DgvComparison[2, Counter].Value.ToString();
                CreditOrDebit = DgvComparison[ColumnCount - 2, Counter].Value.ToString();
                if (CreditOrDebit == "C")
                    Amount = Convert.ToDecimal(DgvComparison[ColumnCount - 1, Counter].Value.ToString()) * -1;
                else
                    Amount = Convert.ToDecimal(DgvComparison[ColumnCount - 1, Counter].Value.ToString());
                if ((JoinValue1 == PrevJoinValue1 && JoinValue2 == PrevJoinValue2 && JoinValue3 == PrevJoinValue3) 
                    || AllUnchecked == true && Counter != 0)
                {
                    Amount = Amount + PrevAmount;
                    DgvComparison[ColumnCount - 1, Counter - 1].Value = Amount;
                    DgvComparison.Rows.RemoveAt(Counter);
                    Counter = Counter - 1;
                }
                PrevJoinValue1 = JoinValue1;
                PrevJoinValue2 = JoinValue2;
                PrevJoinValue3 = JoinValue3;
                PrevAmount = Amount;
                Counter++;
            }
            DgvComparison.Columns.RemoveAt(DgvComparison.Columns.Count - 2);
            Counter = 0;
            while (Counter < DgvComparison.Columns.Count)
            {
                DgvComparison.Columns[Counter].Width = (DgvComparison.Width - 43) / DgvComparison.Columns.Count;
                Counter++;
            }
        }

        private void ChkCategory_CheckedChanged(object sender, EventArgs e)
        {
            FillDGVComparision();
        }

        private void ChkDescription_CheckedChanged(object sender, EventArgs e)
        {
            FillDGVComparision();
        }

        private void ChkComments_CheckedChanged(object sender, EventArgs e)
        {
            FillDGVComparision();
        }

        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            FillDGVTransactions();
            FillDGVComparision();
        }

    }
}
