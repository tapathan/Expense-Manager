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
    public partial class FrmExchangeRate : Form
    {
        public FrmExchangeRate()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();

        private void FrmExchangeRate_Load(object sender, EventArgs e)
        {
            CommFunc.Fill_Combo(CmbCurrency, "CurrencyCode", "CurrencyDim", "");
            CmbCurrency.SelectedIndex = 0;
            TxtBaseCurrency.Text = CommFunc.Fetch_DB_Value("CurrencyCode", "CurrencyDim", "CurrentlyUsedInd = 'Y'");
            this.AcceptButton = BtnEnter;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            if (TxtExchangeRate.Text == "")
                MessageBox.Show("Please provide the Exchange Rate.", "message:", MessageBoxButtons.OK);
            else
            {
                int DateKey = CommFunc.FetchKey("DateDim", DtpDate.Value.ToString("dd-MM-yyyy"));
                int FromCurrencyKey = CommFunc.FetchKey("CurrencyDim", CmbCurrency.Text);
                int BaseCurrencyKey = CommFunc.FetchKey("CurrencyDim", TxtBaseCurrency.Text);
                decimal ExchangeRate = Convert.ToDecimal(TxtExchangeRate.Text);
                CommFunc.Insert_into_DB(DateKey + "," + FromCurrencyKey + "," + ExchangeRate, "ExchangeRatesFact");
                TxtExchangeRate.Text = "";
                CmbCurrency.SelectedIndex = 0;
            }
        }
    }
}
