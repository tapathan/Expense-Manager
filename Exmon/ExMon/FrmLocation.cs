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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();
        Boolean FromTextChange = false;
        Boolean SearchKeyHit = true;

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            this.Font = new Font("Verdana", 8, FontStyle.Regular);
            this.AcceptButton = BtnEnter;
        }

        private void TxtLocation_TextChanged(object sender, EventArgs e)
        {
            string QueryRes = "";
            int NumberOfChar = TxtLocation.Text.Length - TxtLocation.SelectedText.Length;
            if (SearchKeyHit == true && FromTextChange == false)
            {
                string EnteredText = TxtLocation.Text;
                QueryRes = CommFunc.Fetch_DB_Value("distinct(Location)", "LocationFact", "Location like '"
                        + EnteredText + "%'");
                if (QueryRes != "")
                {
                    TxtLocation.Text = QueryRes;
                    TxtLocation.Select(NumberOfChar, TxtLocation.Text.Length - NumberOfChar);
                }
                FromTextChange = true;
            }
            else
                FromTextChange = false;
        }

        private void TxtLocation_KeyPress(object sender, KeyPressEventArgs e)
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
            if (TxtLocation.Text == "")
                MessageBox.Show("Location needs to be provided.", "message:", MessageBoxButtons.OK);
            else
            {
                string LocationNm = TxtLocation.Text;
                int UserKey = CommFunc.FetchKey("UserDim", CommonFunctions.UserNm);
                DateKey = CommFunc.FetchKey("DateDim", EventDate.ToString("dd-MM-yyyy"));
                CommFunc.Insert_into_DB(DateKey.ToString() + "," + UserKey + ",'" + LocationNm + "'", "LocationFact");
                TxtLocation.Text = "";
                DtpDate.Value = DateTime.Now;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
