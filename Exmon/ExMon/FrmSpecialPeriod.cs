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
    public partial class FrmSpecialPeriod : Form
    {
        public FrmSpecialPeriod()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();
        Boolean FromTextChange = false;
        Boolean SearchKeyHit = true;

        private void FrmSpecialPeriod_Load(object sender, EventArgs e)
        {
            this.Font = new Font("Verdana", 8, FontStyle.Regular);
            this.Text = "Enter Special Period";
            DateTime WeekLaterDt = DateTime.Today;
            WeekLaterDt = WeekLaterDt.AddDays(7);
            DtpEndDate.Value = WeekLaterDt;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtSpecialPeriod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                SearchKeyHit = true;
            else
                SearchKeyHit = false;
            FromTextChange = false;
        }

        private void TxtSpecialPeriod_TextChanged(object sender, EventArgs e)
        {
            string QueryRes = "";
            int NumberOfChar = TxtSpecialPeriod.Text.Length - TxtSpecialPeriod.SelectedText.Length;
            if (SearchKeyHit == true && FromTextChange == false)
            {
                string EnteredText = TxtSpecialPeriod.Text;
                QueryRes = CommFunc.Fetch_DB_Value("distinct(SpecialPeriod)", "SpecialPeriodFact", "SpecialPeriod like '"
                        + EnteredText + "%'");
                if (QueryRes != "")
                {
                    TxtSpecialPeriod.Text = QueryRes;
                    TxtSpecialPeriod.Select(NumberOfChar, TxtSpecialPeriod.Text.Length - NumberOfChar);
                }
                FromTextChange = true;
            }
            else
                FromTextChange = false;
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            DateTime StartDate = DtpStartDate.Value;
            DateTime EndDate = DtpEndDate.Value;
            int DayDiff = Convert.ToInt16((EndDate - StartDate).TotalDays.ToString()) + 1;
            int Counter = 0;
            int ProgressValue = 0;
            int DateKey = 0;
            if (TxtSpecialPeriod.Text == "")
                MessageBox.Show("Special Period Name needs to be provided.", "message:", MessageBoxButtons.OK);
            else
            {
                string SpecialPeriodNm = TxtSpecialPeriod.Text;
                while (StartDate <= EndDate && Counter < 2000)
                {
                    DateKey = CommFunc.FetchKey("DateDim", StartDate.ToString("dd-MM-yyyy"));
                    CommFunc.Insert_into_DB(DateKey.ToString() + ",'" + SpecialPeriodNm + "'", "SpecialPeriodFact");
                    StartDate = StartDate.AddDays(1);
                    Counter++;
                    ProgressValue = Counter * 100 / DayDiff;
                    PbrProgress.Value = ProgressValue;
                }
                TxtSpecialPeriod.Text = "";
                DtpStartDate.Value = DateTime.Now;
            }
            PbrProgress.Value = 0;
        }

        private void DtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime WeekLaterDt = DtpStartDate.Value;
            WeekLaterDt = WeekLaterDt.AddDays(7);
            DtpEndDate.Value = WeekLaterDt;
        }
    }
}
