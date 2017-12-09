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
    public partial class FrmRemoveAssets : Form
    {
        public FrmRemoveAssets()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();

        private void FrmRemoveAssets_Load(object sender, EventArgs e)
        {
            CommFunc.Fill_Combo(CmbHierarchy, "Hierarchy", "TransactionTypeDim", "CreditDebitInd = 'D'");
            CmbHierarchy.SelectedIndex = 0;
            FillDGV();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbHierarchy_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDGV();
        }

        private void FillDGV()
        {
            CommFunc.QueryFactFillDGV("TransactionFact", "DateDim,UserDim,AccountDim,TransactionTypeDim",
                "TransactionTypeDimHierarchy = '" + CmbHierarchy.Text + "'" + " AND UserDimUsername = '"
                + CommonFunctions.UserNm + "' AND TransactionFactAssetInd = 'Y'",
                "TransactionFactTransactionId,AccountDimDescription,TransactionTypeDimDescription,"
                + "TransactionTypeDimCategory,TransactionTypeDimHierarchy,TransactionFactAmount",
                DGVAssets, Convert.ToDecimal("7.5"));
            DGVAssets.Columns[0].Visible = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int Counter = 0;
            int TransactionId = 0;
            while (Counter < DGVAssets.Rows.Count)
            {
                if (DGVAssets.Rows[Counter].Selected == true)
                {
                    TransactionId = Convert.ToInt16(DGVAssets[0, Counter].Value.ToString());
                    CommFunc.Update_DB("AssetInd = 'N'", "TransactionFact", "TransactionId = " + TransactionId);
                    Counter++;
                }
            }
            FillDGV();
        }

    }
}
