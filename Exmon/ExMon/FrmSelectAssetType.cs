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
    public partial class FrmSelectAssetType : Form
    {
        int TransactionId;
        string TransactionType;

        public FrmSelectAssetType(int TransId, string TransactionType)
        {
            InitializeComponent();
            this.TransactionId = TransId;
            this.TransactionType = TransactionType;
        }

        CommonFunctions CommFunc = new CommonFunctions();

        private void FrmSelectAssetType_Load(object sender, EventArgs e)
        {
            CommFunc.Fill_Combo(CmbAssetType, "AssetType", "AssetTypeDim", "");
            CmbAssetType.SelectedIndex = 0;
            string Depreciation = CommFunc.Fetch_DB_MultiValue("DepreciationRate,DepreciationIntervalCount,DepreciationInterval"
                , "AssetTypeDim", "AssetType = '" + CmbAssetType.Text + "'");
            Depreciation = Depreciation.Replace("::", ",");
            if (Convert.ToInt16(Depreciation.Split(',')[1]) > 1)
                TxtDepreciationRate.Text = Depreciation.Split(',')[0] + "% PER " + Depreciation.Split(',')[1] + " "
                    + Depreciation.Split(',')[2] + "s"; 
            else
                TxtDepreciationRate.Text = Depreciation.Split(',')[0] + "% PER " + Depreciation.Split(',')[2];
            MessageBox.Show("Select Asset Type for " + TransactionType, "message:", MessageBoxButtons.OK);
        }

        private void CmbAssetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Depreciation = CommFunc.Fetch_DB_MultiValue("DepreciationRate,DepreciationIntervalCount,DepreciationInterval"
                , "AssetTypeDim", "AssetType = '" + CmbAssetType.Text + "'");
            Depreciation = Depreciation.Replace("::", ",");
            if (Convert.ToInt16(Depreciation.Split(',')[1]) > 1)
                TxtDepreciationRate.Text = Depreciation.Split(',')[0] + "% PER " + Depreciation.Split(',')[1] + " "
                    + Depreciation.Split(',')[2] + "s";
            else
                TxtDepreciationRate.Text = Depreciation.Split(',')[0] + "% PER " + Depreciation.Split(',')[2];
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            int AssetTypeKey = CommFunc.FetchKey("AssetTypeDim", CmbAssetType.Text);
            CommFunc.Update_DB("AssetTypeKey=" + AssetTypeKey + ",AssetInd='Y'", 
                "TransactionFact", "TransactionId = " + TransactionId);
            this.Close();
        }
    }
}
