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
    public partial class FrmChangeTransactionTypeCorD : Form
    {
        public FrmChangeTransactionTypeCorD()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();

        private void FrmChangeTransactionTypeCorD_Load(object sender, EventArgs e)
        {
            CommFunc.Fill_Combo(CmbTransactionHierarchy, "Hierarchy", "TransactionTypeDim", "");
            CmbTransactionHierarchy.SelectedIndex = 0;
            CmbCD.SelectedIndex = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            string CorD = CmbCD.Text;
            if (CorD == "CREDIT")
                CorD = "C";
            else
                CorD = "D";
            string Hierarchy = CmbTransactionHierarchy.Text;
            string Res = CommFunc.Fetch_DB_Value("Distinct(Hierarchy)", "TransactionFact,TransactionTypeDim",
                "TransactionTypeDim.TransactionTypeKey = TransactionFact.TransactionTypeKey and Hierarchy = '"
                + Hierarchy + "'");
            if (Res == "")
            {
                CommFunc.Update_DB("CreditDebitInd = '" + CorD + "'", "TransactionTypeDim", "Hierarchy = '" + Hierarchy + "'");
                MessageBox.Show("Hierarchy: " + Hierarchy + " has been set to type " + CmbCD.Text + " now",
                "message:", MessageBoxButtons.OK);
                CmbTransactionHierarchy.SelectedIndex = 0;
                CmbCD.SelectedIndex = 0;
            }
            else
                MessageBox.Show("Transactions found for " + Hierarchy + ".\nPlease delete them before changing the Credit Type.",
                    "message:", MessageBoxButtons.OK);
        }
    }
}
