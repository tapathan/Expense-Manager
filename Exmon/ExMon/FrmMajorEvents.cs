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
    public partial class FrmMajorEvents : Form
    {
        public FrmMajorEvents()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();
        Boolean FromTextChange = false;
        Boolean SearchKeyHit = true;

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMajorEvents_Load(object sender, EventArgs e)
        {
            this.Font = new Font("Verdana", 8, FontStyle.Regular);
            CmbIsHoliday.SelectedIndex = 0;
            this.AcceptButton = BtnEnter;
        }

        private void TxtMajorEvent_TextChanged(object sender, EventArgs e)
        {
            string QueryRes = "";
            int NumberOfChar = TxtMajorEvent.Text.Length - TxtMajorEvent.SelectedText.Length;
            if (SearchKeyHit == true && FromTextChange == false)
            {
                string EnteredText = TxtMajorEvent.Text;
                QueryRes = CommFunc.Fetch_DB_Value("distinct(MajorEvent)", "MajorEventFact", "MajorEvent like '"
                        + EnteredText + "%'");
                if (QueryRes != "")
                {
                    TxtMajorEvent.Text = QueryRes;
                    TxtMajorEvent.Select(NumberOfChar, TxtMajorEvent.Text.Length - NumberOfChar);
                }
                FromTextChange = true;
            }
            else
                FromTextChange = false;
        }

        private void TxtMajorEvent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                SearchKeyHit = true;
            else
                SearchKeyHit = false;
            FromTextChange = false;
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            DateTime EventDate = DtpDate.Value;
            int DateKey = 0;
            if (TxtMajorEvent.Text == "")
                MessageBox.Show("Major Event needs to be provided.", "message:", MessageBoxButtons.OK);
            else
            {
                string EventNm = TxtMajorEvent.Text;
                string IsHoliday = CmbIsHoliday.Text;
                DateKey = CommFunc.FetchKey("DateDim", EventDate.ToString("dd-MM-yyyy"));
                CommFunc.Insert_into_DB(DateKey.ToString() + ",'" + EventNm + "','" + IsHoliday + "'", "MajorEventFact");
                TxtMajorEvent.Text = "";
                DtpDate.Value = DateTime.Now;
            }
        }
    }
}
