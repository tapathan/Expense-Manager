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
    public partial class FrmGenCreateSearchFrm : Form
    {
        Font FrmFont;
        Boolean EditForm;

        public FrmGenCreateSearchFrm()
        {
            InitializeComponent();
            this.FrmFont = new Font("Verdana", 9, FontStyle.Regular);
            this.EditForm = false;
        }

        public FrmGenCreateSearchFrm(Font Fnt)
        {
            InitializeComponent();
            this.FrmFont = Fnt;
            this.EditForm = false;
        }

        public FrmGenCreateSearchFrm(Font Fnt, Boolean EditForm)
        {
            InitializeComponent();
            this.FrmFont = Fnt;
            this.EditForm = EditForm;
        }

        public FrmGenCreateSearchFrm(Boolean EditForm)
        {
            InitializeComponent();
            this.FrmFont = new Font("Verdana", 9, FontStyle.Regular);
            this.EditForm = EditForm;
        }

        CommonFunctions CommFunc = new CommonFunctions();
        string[] DragFieldNames = new string[150];
        Form SelectField = new Form();
        DataGridView DGVFields = new DataGridView();
        string CalcFieldNm = "";

        private void FrmGenCreateSearchFrm_Load(object sender, EventArgs e)
        {
            this.Font = FrmFont;
            DGVCriteria.Columns[0].Width = DGVCriteria.Width / 2 - 51;
            DGVCriteria.Columns[1].Width = DGVCriteria.Width / 2 - 51;
            DGVCriteria.Columns[2].Width = 60;
            DGVDisplay.Columns[0].Width = DGVDisplay.Width / 2 - 20;
            DGVDisplay.Columns[1].Width = DGVDisplay.Width / 2 - 20;

            if (EditForm == true)
            {
                CmbFormTitle.Visible = true;
                TxtFormTitle.Visible = false;
                CmbFormTitle.Location = new Point(TxtFormTitle.Location.X, TxtFormTitle.Location.Y);
                CmbFormTitle.Size = TxtFormTitle.Size;
                CmbFormTitle.DropDownStyle = ComboBoxStyle.DropDownList;
                CommFunc.Fill_Combo(CmbFormTitle, "FrmName", "FormDim", "");
                CmbFormTitle.SelectedIndex = 0;
            }

            CommFunc.Fill_Combo(CmbTableName, "TableName", "AllFieldsDimension",
                "TableName not in ('FormDim', 'MakeFormFact','FormGroupFact')");
            CmbTableName.SelectedIndex = 0;
            CmbAccess.SelectedIndex = 0;
            LstTableFields.SelectionMode = SelectionMode.MultiExtended;

            foreach (FontFamily fnt in System.Drawing.FontFamily.Families)
                CmbFont.Items.Add(fnt.Name);
            CmbFont.Text = "Verdana";
            TxtColor.BackColor = Color.Lavender;

            BtnSum.Font = this.Font;
            BtnAverage.Font = this.Font;
            BtnMaximum.Font = this.Font;
            BtnMinimum.Font = this.Font;
            BtnCount.Font = this.Font;
            BtnProduct.Font = this.Font;

            DGVFields.Columns.Add("FieldName", "Field Name");
            DGVFields.Columns.Add("TableName", "Table Name");
            EditModeFillDGV();
            SetColorSize();
            SetCalcFuncs();
        }

        private void SetCalcFuncs()
        {
            if (EditForm == true)
            {
                int FormKey = CommFunc.FetchKey("FormDim", CmbFormTitle.Text);
                string FrmCalculations = CommFunc.Fetch_DB_Value("Calculations", "FormDim", "FormKey = " + FormKey);
                int Counter = 0;
                while (Counter < FrmCalculations.Split(',').Count() && FrmCalculations != "")
                {
                    if (FrmCalculations.Split(',')[Counter].Split('(')[0].ToUpper() == "TOTAL")
                        BtnSum.Text = FrmCalculations.Split(',')[Counter];
                    else if (FrmCalculations.Split(',')[Counter].Split('(')[0].ToUpper() == "AVG")
                        BtnAverage.Text = FrmCalculations.Split(',')[Counter];
                    else if (FrmCalculations.Split(',')[Counter].Split('(')[0].ToUpper() == "MAX")
                        BtnMaximum.Text = FrmCalculations.Split(',')[Counter];
                    else if (FrmCalculations.Split(',')[Counter].Split('(')[0].ToUpper() == "MIN")
                        BtnMinimum.Text = FrmCalculations.Split(',')[Counter];
                    else if (FrmCalculations.Split(',')[Counter].Split('(')[0].ToUpper() == "COUNT")
                        BtnCount.Text = FrmCalculations.Split(',')[Counter];
                    else if (FrmCalculations.Split(',')[Counter].Split('(')[0].ToUpper() == "PRODUCT")
                        BtnProduct.Text = FrmCalculations.Split(',')[Counter];
                    Counter++;
                }
            }
            else
                SetBtnDefaultText();
        }

        private void SetBtnDefaultText()
        {
            BtnSum.Text = "TOTAL";
            BtnAverage.Text = "AVG";
            BtnMaximum.Text = "MAX";
            BtnMinimum.Text = "MIN";
            BtnCount.Text = "COUNT";
            BtnProduct.Text = "PRODUCT";
        }

        private void SetColorSize()
        {
            if (EditForm == true)
            {
                int FormKey = CommFunc.FetchKey("FormDim", CmbFormTitle.Text);
                Color FrmColor = ColorTranslator.FromHtml("#" + CommFunc.Fetch_DB_Value("FrmColor", "FormDim", "FormKey = " 
                    + FormKey));
                string FrmSize = CommFunc.Fetch_DB_Value("FrmSize", "FormDim", "FormKey = " + FormKey);
                TxtColor.BackColor = FrmColor;
                TxtSize.Text = FrmSize;
            }
        }

        private void EditModeFillDGV()
        {
            if (EditForm == true)
            {
                DGVCriteria.Rows.Clear();
                DGVDisplay.Rows.Clear();
                DataGridView DGVTemp1 = new DataGridView();
                CommFunc.QueryFactFillDGV("MakeFormFact", "FormDim", "FormDimFrmName = '" + CmbFormTitle.Text
                    + "' and MakeFormFactCriteriaOrDisplay = 'C'",
                    "MakeFormFactFieldName,MakeFormFactTableName,MakeFormFactIsFreezed AS IsFrz", DGVTemp1, 1);
                int Counter = 0;
                while (Counter < DGVTemp1.Rows.Count)
                {
                    string IsFrz = DGVTemp1[2, Counter].Value.ToString();
                    Boolean BlIsFrz = false;
                    if (IsFrz == "Y")
                        BlIsFrz = true;
                    DGVCriteria.Rows.Add(DGVTemp1[1, Counter].Value, DGVTemp1[0, Counter].Value, BlIsFrz);
                    Counter++;
                }
                DataGridView DGVTemp2 = new DataGridView();
                CommFunc.QueryFactFillDGV("MakeFormFact", "FormDim", "FormDimFrmName = '" + CmbFormTitle.Text
                    + "' and MakeFormFactCriteriaOrDisplay = 'D'",
                    "MakeFormFactFieldName,MakeFormFactTableName,MakeFormFactIsFreezed AS IsFrz", DGVTemp2, 1);
                Counter = 0;
                while (Counter < DGVTemp2.Rows.Count)
                {
                    DGVDisplay.Rows.Add(DGVTemp2[1, Counter].Value, DGVTemp2[0, Counter].Value);
                    Counter++;
                }
            }
        }

        private void CmbTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string QueryRes = CommFunc.Fetch_DB_Value("FieldName", "AllFieldsDimension", "TableName='" 
                + CmbTableName.Text + "' and KeyFieldInd != 'Y'");
            string[] QueryResVec = QueryRes.Split('|');
            int Counter = 0;
            LstTableFields.Items.Clear();
            while (Counter < QueryRes.Split('|').Count())
            {
                LstTableFields.Items.Add(QueryResVec[Counter]);
                Counter++;
            }
        }

        private void BtnAppendCriteria_Click(object sender, EventArgs e)
        {
            int Cntr = 0;
            while (Cntr < DragFieldNames.Count())
            {
                DragFieldNames[Cntr] = null;
                Cntr++;
            }
            if (LstTableFields.SelectedItems.Count > 0)
            {
                int Counter = 0;
                int ArrCounter = 0;
                while (Counter < LstTableFields.Items.Count)
                {
                    if (LstTableFields.GetSelected(Counter) == true)
                    {
                        DragFieldNames[ArrCounter] = LstTableFields.Items[Counter].ToString();
                        ArrCounter++;
                    }
                    Counter++;
                }
                int CounterOuter = 0;
                int CounterInner = 0;
                while (DragFieldNames[CounterOuter] != null)
                {
                    while (CounterInner < DGVCriteria.Rows.Count)
                    {
                        if (DragFieldNames[CounterOuter] == DGVCriteria["FieldName", CounterInner].Value.ToString()
                            && CmbTableName.Text == DGVCriteria["TableName", CounterInner].Value.ToString())
                            break;
                        CounterInner++;
                    }
                    if (CounterInner == DGVCriteria.Rows.Count)
                    {
                        DGVCriteria.Rows.Add(CmbTableName.Text, DragFieldNames[CounterOuter]);
                    }
                    CounterOuter++;
                }
            }
        }

        private void DGVCriteria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                if (Convert.ToBoolean(DGVCriteria[2, e.RowIndex].Value) == true)
                    DGVCriteria[2, e.RowIndex].Value = false;
                else
                    DGVCriteria[2, e.RowIndex].Value = true;
            }
        }

        private void BtnAppendDisplay_Click(object sender, EventArgs e)
        {
            int Cntr = 0;
            while (Cntr < DragFieldNames.Count())
            {
                DragFieldNames[Cntr] = null;
                Cntr++;
            }
            if (LstTableFields.SelectedItems.Count > 0)
            {
                int Counter = 0;
                int ArrCounter = 0;
                while (Counter < LstTableFields.Items.Count)
                {
                    if (LstTableFields.GetSelected(Counter) == true)
                    {
                        DragFieldNames[ArrCounter] = LstTableFields.Items[Counter].ToString();
                        ArrCounter++;
                    }
                    Counter++;
                }
                int CounterOuter = 0;
                int CounterInner = 0;
                while (DragFieldNames[CounterOuter] != null)
                {
                    while (CounterInner < DGVDisplay.Rows.Count)
                    {
                        if (DragFieldNames[CounterOuter] == DGVDisplay[1, CounterInner].Value.ToString()
                            && CmbTableName.Text == DGVDisplay[0, CounterInner].Value.ToString())
                            break;
                        CounterInner++;
                    }
                    if (CounterInner == DGVDisplay.Rows.Count)
                    {
                        DGVDisplay.Rows.Add(CmbTableName.Text, DragFieldNames[CounterOuter]);
                    }
                    CounterOuter++;
                }
            }
        }

        private void BtnCreateFrm_Click(object sender, EventArgs e)
        {
            if (TxtFormTitle.Text == "" && EditForm == false)
                MessageBox.Show("Please provide Form Title.", "message:", MessageBoxButtons.OK);
            else if (DGVCriteria.Rows.Count == 0)
                MessageBox.Show("Please provide Criteria Fields", "message:", MessageBoxButtons.OK);
            else if (DGVDisplay.Rows.Count == 0)
                MessageBox.Show("Please provide Display Fields", "message:", MessageBoxButtons.OK);
            else
            {
                int FormKey = 0;
                string FormName = "";
                if (EditForm == true)
                {
                    FormKey = CommFunc.FetchKey("FormDim", CmbFormTitle.Text);
                    FormName = CmbFormTitle.Text;
                }
                else
                {
                    FormKey = CommFunc.FetchMaxKey("FormKey", "FormDim");
                    FormName = TxtFormTitle.Text;
                }
                string FormColor = string.Format("{0:x6}", TxtColor.BackColor.ToArgb());
                string FormSize = TxtSize.Text;
                if (FormSize == "")
                    FormSize = "Maximised";
                string FormFont = CmbFont.Text;
                string FormAccess = CmbAccess.Text;
                int Counter = 0;
                string FormCalculations = "";
                if (BtnSum.Text.Contains("(") == true && BtnSum.Text.Contains("()") == false)
                    FormCalculations = FormCalculations + "," + BtnSum.Text;
                if (BtnAverage.Text.Contains("(") == true && BtnAverage.Text.Contains("()") == false)
                    FormCalculations = FormCalculations + "," + BtnAverage.Text;
                if (BtnMaximum.Text.Contains("(") == true && BtnMaximum.Text.Contains("()") == false)
                    FormCalculations = FormCalculations + "," + BtnMaximum.Text;
                if (BtnMinimum.Text.Contains("(") == true && BtnMinimum.Text.Contains("()") == false)
                    FormCalculations = FormCalculations + "," + BtnMinimum.Text;
                if (BtnCount.Text.Contains("(") == true && BtnCount.Text.Contains("()") == false)
                    FormCalculations = FormCalculations + "," + BtnCount.Text;
                if (BtnProduct.Text.Contains("(") == true && BtnProduct.Text.Contains("()") == false)
                    FormCalculations = FormCalculations + "," + BtnProduct.Text;
                if (FormCalculations.StartsWith(",") == true)
                    FormCalculations = FormCalculations.Substring(1, FormCalculations.Length - 1);
                if (EditForm == true)
                {
                    DialogResult Res = MessageBox.Show("Do you want to delete all earlier set Groups for this form?", 
                        "message:", MessageBoxButtons.YesNo);
                    if (Res == DialogResult.Yes)
                        CommFunc.delete_table("FormGroupFact", "FormKey = " + FormKey);
                    CommFunc.delete_table("MakeFormFact", "FormKey = " + FormKey);
                    CommFunc.delete_table("FormDim", "FormKey = " + FormKey);
                }
                CommFunc.Insert_into_DB(FormKey + ",'" + FormName + "','" + FormAccess + "','" + FormSize + "','" + FormColor
                    + "','" + FormFont + "','" + FormCalculations + "'", "FormDim");
                Counter = 0;
                while (Counter < DGVCriteria.Rows.Count)
                {
                    string TName = DGVCriteria[0, Counter].Value.ToString();
                    string FName = DGVCriteria[1, Counter].Value.ToString();
                    string IsFreezed = "";
                    if (DGVCriteria[2, Counter].Value != null)
                        IsFreezed = DGVCriteria[2, Counter].Value.ToString();
                    if (IsFreezed == "True")
                        IsFreezed = "Y";
                    else
                        IsFreezed = "N";
                    CommFunc.Insert_into_DB(FormKey + ",'" + FName + "','" + TName + "','" + IsFreezed 
                        + "','C'", "MakeFormFact");
                    Counter++;
                }
                Counter = 0;
                while (Counter < DGVDisplay.Rows.Count)
                {
                    string TName = DGVDisplay[0, Counter].Value.ToString();
                    string FName = DGVDisplay[1, Counter].Value.ToString();
                    CommFunc.Insert_into_DB(FormKey + ",'" + FName + "','" + TName + "','','D'", "MakeFormFact");
                    Counter++;
                }
                DGVCriteria.Rows.Clear();
                DGVDisplay.Rows.Clear();
                TxtSize.Text = "";
                CmbFont.Text = "Verdana";
                FrmCreateFromGroups FrmGrp = new FrmCreateFromGroups(TxtFormTitle.Text, new Font("Verdana", 9, FontStyle.Regular));
                FrmGrp.ShowDialog();
                TxtFormTitle.Text = "";
            }
        }

        private void TxtColor_Click(object sender, EventArgs e)
        {
            ColorDialog ClrDiag = new ColorDialog();
            var Ans = ClrDiag.ShowDialog();
            Color ClrVal;
            if (Ans == DialogResult.OK)
                ClrVal = ClrDiag.Color;
            else
                ClrVal = TxtColor.BackColor;
            TxtColor.BackColor = ClrVal;
        }

        private void DGVCriteria_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DGVCriteria.Rows.RemoveAt(e.RowIndex);
        }

        private void DGVDisplay_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DGVDisplay.Rows.RemoveAt(e.RowIndex);
        }

        private void BtnSum_Click(object sender, EventArgs e)
        {
            SelectFieldForCalc(BtnSum.Text);
            BtnSum.Text = "TOTAL(" + CalcFieldNm + ")";
        }

        private void SelectFieldForCalc(string Calc)
        {
            CalcFieldNm = "";
            SelectField.Text = "Select Field for " + Calc;
            SelectField.Width = 460;
            SelectField.Height = 560;
            int Counter = 0;
            DGVFields.Rows.Clear();
            while (Counter < DGVDisplay.Rows.Count)
            {
                DGVFields.Rows.Add(DGVDisplay[0, Counter].Value.ToString(), DGVDisplay[1, Counter].Value.ToString());
                Counter++;
            }
            DGVFields.Location = new Point(20, 20);
            DGVFields.Width = 400;
            DGVFields.Height = 440;
            DGVFields.AllowUserToAddRows = false;
            DGVFields.Columns[0].Width = DGVFields.Width / 2 - 22;
            DGVFields.Columns[1].Width = DGVFields.Width / 2 - 22;
            SelectField.Controls.Add(DGVFields);
            Button BtnEnter = new Button();
            BtnEnter.Text = "Enter";
            BtnEnter.Width = 130;
            BtnEnter.Height = 40;
            BtnEnter.Location = new Point(DGVFields.Location.X, DGVFields.Location.Y + DGVFields.Height + 10);
            BtnEnter.Click += new EventHandler(SetCalcField);
            SelectField.Font = this.Font;
            SelectField.Controls.Add(BtnEnter);
            SelectField.ShowDialog();
        }

        private void SetCalcField(object sender, EventArgs e)
        {
            int Counter = 0;
            while (Counter < DGVFields.Rows.Count)
            {
                if (DGVFields.Rows[Counter].Selected == true)
                {
                    CalcFieldNm = DGVFields[0, Counter].Value.ToString() + "." + DGVFields[1, Counter].Value.ToString();
                    MessageBox.Show("Calculation Field set to " + CalcFieldNm, "message:", MessageBoxButtons.OK);
                    break;
                }
                Counter++;
            }
            this.SelectField.Close();
        }

        private void BtnAverage_Click(object sender, EventArgs e)
        {
            SelectFieldForCalc(BtnAverage.Text);
            BtnAverage.Text = "AVG(" + CalcFieldNm + ")";
        }

        private void BtnMaximum_Click(object sender, EventArgs e)
        {
            SelectFieldForCalc(BtnMaximum.Text);
            BtnMaximum.Text = "MAX(" + CalcFieldNm + ")";
        }

        private void BtnMinimum_Click(object sender, EventArgs e)
        {
            SelectFieldForCalc(BtnMinimum.Text);
            BtnMinimum.Text = "MIN(" + CalcFieldNm + ")";
        }

        private void BtnCount_Click(object sender, EventArgs e)
        {
            SelectFieldForCalc(BtnCount.Text);
            BtnCount.Text = "COUNT(" + CalcFieldNm + ")";
        }

        private void BtnProduct_Click(object sender, EventArgs e)
        {
            SelectFieldForCalc(BtnProduct.Text);
            BtnProduct.Text = "PRODUCT(" + CalcFieldNm + ")";
        }

        private void CmbFormTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditModeFillDGV();
            SetColorSize();
            SetBtnDefaultText();
            SetCalcFuncs();
        }

    }
}
