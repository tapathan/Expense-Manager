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
    public partial class FrmEnterSeason : Form
    {
        public FrmEnterSeason()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();
        Boolean FromTextChange = false;
        Boolean SearchKeyHit = true;

        private void FrmEnterSeason_Load(object sender, EventArgs e)
        {
            this.Font = new Font("Verdana", 8, FontStyle.Regular);
            this.Text = "Enter Season";
            DateTime FourMonthLaterDt = DateTime.Today;
            FourMonthLaterDt = FourMonthLaterDt.AddMonths(4);
            DtpEndDate.Value = FourMonthLaterDt;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtSeason_TextChanged(object sender, EventArgs e)
        {
            string QueryRes = "";
            int NumberOfChar = TxtSeason.Text.Length - TxtSeason.SelectedText.Length;
            if (SearchKeyHit == true && FromTextChange == false)
            {
                string EnteredText = TxtSeason.Text;
                QueryRes = CommFunc.Fetch_DB_Value("distinct(Season)", "SeasonFact", "Season like '"
                        + EnteredText + "%'");
                if (QueryRes != "")
                {
                    TxtSeason.Text = QueryRes;
                    TxtSeason.Select(NumberOfChar, TxtSeason.Text.Length - NumberOfChar);
                }
                FromTextChange = true;
            }
            else
                FromTextChange = false;
        }

        private void TxtSeason_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                SearchKeyHit = true;
            else
                SearchKeyHit = false;
            FromTextChange = false;
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            DateTime StartDate = DtpStartDate.Value;
            DateTime EndDate = DtpEndDate.Value;
            int Counter = 0;
            int ProgressValue = 0;
            int DateKey = 0;
            if (TxtSeason.Text == "")
                MessageBox.Show("Season Name needs to be provided.", "message:", MessageBoxButtons.OK);
            else
            {
                string SeasonNm = TxtSeason.Text;
                while (StartDate <= EndDate && Counter < 1000)
                {
                    DateKey = CommFunc.FetchKey("DateDim", StartDate.ToString("dd-MM-yyyy"));
                    try
                    {
                        CommFunc.Insert_into_DB(DateKey.ToString() + ",'" + SeasonNm + "'", "SeasonFact");
                    }
                    catch (Exception Ex)
                    {
                        CommFunc.Update_DB("Season = '" + SeasonNm + "'", "SeasonFact", "DateKey = " + DateKey.ToString());
                    }
                    StartDate = StartDate.AddDays(1);
                    Counter++;
                    ProgressValue = Counter * 100 / 122;
                    PbrProgress.Value = ProgressValue;
                }
                TxtSeason.Text = "";
                DtpStartDate.Value = DateTime.Now;
            }
            PbrProgress.Value = 0;
        }

        private void DtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime FourMonthLaterDt = DtpStartDate.Value;
            FourMonthLaterDt = FourMonthLaterDt.AddMonths(4);
            DtpEndDate.Value = FourMonthLaterDt;
        }
    }
}
