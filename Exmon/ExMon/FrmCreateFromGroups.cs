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
    public partial class FrmCreateFromGroups : Form
    {
        Font Fnt;
        string FormName;

        public FrmCreateFromGroups()
        {
            InitializeComponent();
            Fnt = new Font("Verdana", 9, FontStyle.Regular);
            this.FormName = "";
        }

        public FrmCreateFromGroups(string FormName)
        {
            InitializeComponent();
            Fnt = new Font("Verdana", 9, FontStyle.Regular);
            this.FormName = FormName;
        }

        public FrmCreateFromGroups(string FormName, Font Ft)
        {
            InitializeComponent();
            Fnt = Ft;
            this.FormName = FormName;
        }

        public FrmCreateFromGroups(Font Ft)
        {
            InitializeComponent();
            Fnt = Ft;
            this.FormName = "";
        }

        CommonFunctions CommFunc = new CommonFunctions();

        private void FrmCreateFromGroups_Load(object sender, EventArgs e)
        {
            this.Font = Fnt;
            this.Text = "Create Form Groups";
            this.BackColor = Color.BlanchedAlmond;
            CommFunc.Fill_Combo(CmbFormTitle, "FrmName", "FormDim", "");
            if (FormName != "" && FormName != null)
                CmbFormTitle.Text = FormName;
            else
                CmbFormTitle.SelectedIndex = 0;
            DGVCriteria.Columns[0].Width = DGVCriteria.Width / 2 - 20;
            DGVCriteria.Columns[1].Width = DGVCriteria.Width / 2 - 20;
            DGVGroupFields.Columns[0].Width = DGVGroupFields.Width / 2 - 20;
            DGVGroupFields.Columns[1].Width = DGVGroupFields.Width / 2 - 20;
            CalculateGroupName();
        }

        private void CalculateGroupName()
        {
            int FormKey = CommFunc.FetchKey("FormDim", CmbFormTitle.Text);
            string GrpNm = CommFunc.Fetch_DB_Value("MAX(CAST(SUBSTRING(GroupName, 6, LEN(GroupName) - 5) AS DECIMAL))", 
                "FormGroupFact", "FormKey = " + FormKey);
            if (GrpNm == null || GrpNm == "")
                GrpNm = "Group1";
            else
                GrpNm = "Group" + Convert.ToString(Convert.ToInt16(GrpNm.Replace("Group", "")) + 1);
            TxtGroupName.Text = GrpNm;
        }

        private void CmbFormTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int FormKey = CommFunc.FetchKey("FormDim", CmbFormTitle.Text);
            string QueryRes = CommFunc.Fetch_DB_MultiValue("TableName,FieldName",
                "MakeFormFact", "CriteriaOrDisplay = 'C' and FormKey=" + FormKey);
            string[] QueryResVec = QueryRes.Split('|');
            int Counter = 0;
            DGVCriteria.Rows.Clear();
            while (Counter < QueryRes.Split('|').Count())
            {
                string TableNm = QueryResVec[Counter].Replace("::", "|").Split('|')[0];
                string FieldNm = QueryResVec[Counter].Replace("::", "|").Split('|')[1];
                DGVCriteria.Rows.Add(TableNm, FieldNm);
                Counter++;
            }
            CalculateGroupName();
        }

        private void BtnCreateGroup_Click(object sender, EventArgs e)
        {
            if (DGVGroupFields.Rows.Count > 1)
            {
                int FormKey = CommFunc.FetchKey("FormDim", CmbFormTitle.Text);
                int Counter = 0;
                while (Counter < DGVGroupFields.Rows.Count)
                {
                    string TableNm = DGVGroupFields[0, Counter].Value.ToString();
                    string FieldNm = DGVGroupFields[1, Counter].Value.ToString();
                    string GrpNm = TxtGroupName.Text;
                    CommFunc.Insert_into_DB(FormKey + ",'" + GrpNm + "','" + FieldNm + "','" + TableNm + "'", "FormGroupFact");
                    Counter++;
                }
                DGVGroupFields.Rows.Clear();
                CalculateGroupName();
            }
            else
                MessageBox.Show("Group must contain more than one fields.", "message:", MessageBoxButtons.OK);
        }

        private void BtnAppendCriteria_Click(object sender, EventArgs e)
        {
            int Counter = 0;
            while (Counter < DGVCriteria.Rows.Count)
            {
                if (DGVCriteria.Rows[Counter].Selected == true)
                {
                    string TableNm = DGVCriteria[0, Counter].Value.ToString();
                    string FieldNm = DGVCriteria[1, Counter].Value.ToString();
                    int InnerCounter = 0;
                    while (InnerCounter < DGVGroupFields.Rows.Count)
                    {
                        if (TableNm == DGVGroupFields[0, InnerCounter].Value.ToString() &&
                            FieldNm == DGVGroupFields[1, InnerCounter].Value.ToString())
                            break;
                        InnerCounter++;
                    }
                    if (InnerCounter == DGVGroupFields.Rows.Count)
                        DGVGroupFields.Rows.Add(TableNm, FieldNm);
                }
                Counter++;
            }
        }

        private void DGVGroupFields_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DGVGroupFields.Rows.RemoveAt(e.RowIndex);
        }
    }
}
