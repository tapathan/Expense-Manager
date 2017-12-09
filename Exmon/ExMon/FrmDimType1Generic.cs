using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExMon
{
    public partial class FrmDimType1Generic : Form
    {
        string TableName;
        string KeyName;
        Font AllFont;
        Font LblFont;
        Font BtnFont;
        string FormTitle;
        decimal DivideGridCellSizeBy;
        public FrmDimType1Generic(string TableName)
        {
            this.TableName = TableName;
            this.KeyName = TableName.Replace("Dim", "Key");
            this.AllFont = new Font("Verdana", 8, FontStyle.Regular);
            this.LblFont = new Font("Verdana", 8, FontStyle.Bold);
            this.BtnFont = new Font("Verdana", 10, FontStyle.Regular);
            this.FormTitle = TableName;
            this.DivideGridCellSizeBy = 1;
            InitializeComponent();
        }
        public FrmDimType1Generic(string TableName, string FormTitle)
        {
            this.TableName = TableName;
            this.KeyName = TableName.Replace("Dim", "Key");
            this.AllFont = new Font("Verdana", 8, FontStyle.Regular);
            this.LblFont = new Font("Verdana", 8, FontStyle.Bold);
            this.BtnFont = new Font("Verdana", 10, FontStyle.Regular);
            this.FormTitle = FormTitle;
            this.DivideGridCellSizeBy = 1;
            InitializeComponent();
        }
        public FrmDimType1Generic(string TableName, string FormTitle, decimal DivideGridCellSizeBy)
        {
            this.TableName = TableName;
            this.KeyName = TableName.Replace("Dim", "Key");
            this.AllFont = new Font("Verdana", 8, FontStyle.Regular);
            this.LblFont = new Font("Verdana", 8, FontStyle.Bold);
            this.BtnFont = new Font("Verdana", 10, FontStyle.Regular);
            this.FormTitle = FormTitle;
            this.DivideGridCellSizeBy = DivideGridCellSizeBy;
            InitializeComponent();
        }
        public FrmDimType1Generic(string TableName, string Fnt, string FormTitle, decimal DivideGridCellSizeBy)
        {
            this.TableName = TableName;
            this.KeyName = TableName.Replace("Dim", "Key");
            this.AllFont = new Font(Fnt, 8, FontStyle.Regular);
            this.LblFont = new Font(Fnt, 8, FontStyle.Bold);
            this.BtnFont = new Font(Fnt, 10, FontStyle.Regular);
            this.FormTitle = FormTitle;
            this.DivideGridCellSizeBy = DivideGridCellSizeBy;
            InitializeComponent();
        }
        public FrmDimType1Generic()
        {
            InitializeComponent();
        }

        CommonFunctions mgr = new CommonFunctions();
        TextBox[] TxtBoxArr = new TextBox[50];
        DateTimePicker[] DatePkArr = new DateTimePicker[50];
        Label[] LblArr = new Label[50];
        DateTimePicker[] DtpArr1 = new DateTimePicker[50];
        ComboBox[] ComboArr1 = new ComboBox[50];
        Button[] BtnArr = new Button[4];
        string[] ControlType = new string[50];
        string[] DefaultValues = new string[50];
        string[] FieldNameArr = new string[50];
        string[] FieldsAlias = new string[100];
        char[] ImportantFieldInd = new char[50];
        char[] ReadOnlyControlInd = new char[50];
        string[] FieldsType = new string[50];
        string[] FieldsSize = new string[50];
        string SelectFields;
        int Width = 195, Height = 60, FormBuildOver = 0;
        int StartDtPos = -1, EndDatePos = -1;
        int NumberOfObject = 0;
        public int XInitialLocation = 110, YInitialLocation = 400;
        int HeightDecrement = 30;
        SqlConnection con = DBConnectionMgr.GetCon(true);
        SqlCommand cmd;
        SqlDataAdapter adptr;
        DataTable dt;
        SqlDataReader Rdr;
        string strQ;
        string FieldNamesGlobal = "", PrimaryFieldsWhereClauseGlobal = "";

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDimType1Generic_Load(object sender, EventArgs e)
        {
            int ObjNumber = 0, Counter = 0;
            string[] AliasArr = new string[50];
            if (con.State == ConnectionState.Closed)
                con.Open();
            TransFlex.Font = this.AllFont;
            this.Text = this.FormTitle;
            strQ = "select FieldName FN, Alias AL, ControlType CT, DefaultValues DV, ImportantFieldInd IFI, "
                + "ReadOnlyControlInd ROCI, FieldType FT, FieldLength FS from AllFieldsDimension where TableName = '"
                + TableName + "' and KeyFieldInd != 'Y' and Display = 'Y'";
            cmd = new SqlCommand(strQ, con);
            Rdr = cmd.ExecuteReader();
            while (Rdr.Read())
            {
                FieldNameArr[ObjNumber] = Convert.ToString(Rdr["FN"]);
                if (FieldNameArr[ObjNumber] == "StartDate")
                    StartDtPos = ObjNumber;
                if (FieldNameArr[ObjNumber] == "EndDate")
                    EndDatePos = ObjNumber;
                AliasArr[ObjNumber] = Convert.ToString(Rdr["AL"]);
                ControlType[ObjNumber] = Convert.ToString(Rdr["CT"]);
                DefaultValues[ObjNumber] = Convert.ToString(Rdr["DV"]);
                ImportantFieldInd[ObjNumber] = Convert.ToChar(Rdr["IFI"]);
                ReadOnlyControlInd[ObjNumber] = Convert.ToChar(Rdr["ROCI"]);
                FieldsType[ObjNumber] = Convert.ToString(Rdr["FT"]);
                FieldsSize[ObjNumber] = Convert.ToString(Rdr["FS"]);
                if (ObjNumber == 0)
                    FieldNamesGlobal = FieldNameArr[ObjNumber];
                else
                    FieldNamesGlobal = FieldNamesGlobal + "," + FieldNameArr[ObjNumber];
                ObjNumber++;
            }
            Rdr.Close();
            Fill_grid(1, "");
            Resize_grid(DivideGridCellSizeBy);
            Create_TextBoxAndDtp(ObjNumber);
            Create_Label(ObjNumber);
            CreateControls(ObjNumber);
            PutDefaultValues(ObjNumber);
            while (Counter < ObjNumber)
            {
                Name_Label(Counter, AliasArr[Counter]);
                Counter++;
            }
            NumberOfObject = ObjNumber;
            if (con.State == ConnectionState.Open)
                con.Close();
            AdjustExitBtn();
            FormBuildOver = 1;
        }

        private void Create_TextBoxAndDtp(int Number)
        {
            int Counter = 0, IncrementLocation, FieldColumns;
            while (Counter < Number)
            {
                FieldColumns = Counter / 10;
                if (Counter != StartDtPos && Counter != EndDatePos)
                {
                    TextBox TxtBox = new TextBox();
                    TxtBox.Height = Height;
                    TxtBox.Width = Width;
                    TxtBox.Font = this.AllFont;
                    if (Counter < 10)
                        IncrementLocation = YInitialLocation + Counter * (Height - HeightDecrement) + 5;
                    else
                        IncrementLocation = YInitialLocation + Counter % (FieldColumns * 10) * (Height - HeightDecrement) + 5;
                    TxtBox.Location = new Point((XInitialLocation + 100) + FieldColumns * 400, IncrementLocation);
                    TxtBox.TextChanged += new EventHandler(this.Control_TextChanged);
                    if (ReadOnlyControlInd[Counter] == 'Y')
                        TxtBox.ReadOnly = true;
                    TxtBoxArr[Counter] = TxtBox;
                    this.Controls.Add(TxtBoxArr[Counter]);
                }
                else
                {
                    DateTimePicker DatePk = new DateTimePicker();
                    DatePk.Height = Height;
                    DatePk.Width = Width - 109;
                    if (Counter < 10)
                        IncrementLocation = YInitialLocation + Counter * (Height - HeightDecrement);
                    else
                        IncrementLocation = YInitialLocation + Counter % (FieldColumns * 10) * (Height - HeightDecrement);
                    DatePk.Location = new Point((XInitialLocation + 100) + FieldColumns * 400, IncrementLocation);
                    DatePk.CustomFormat = "dd/MM/yyyy";
                    if (Counter == EndDatePos)
                    {
                        DateTime DefaultEndDate = new DateTime(2099, 12, 31);
                        DatePk.Value = DefaultEndDate;
                    }
                    DatePk.Format = DateTimePickerFormat.Custom;
                    DatePk.Font = this.AllFont;
                    DatePkArr[Counter] = DatePk;
                    this.Controls.Add(DatePkArr[Counter]);
                }
                Counter++;
            }
        }

        private void Create_Label(int Number)
        {
            int Counter = 0, IncrementLocation, FieldColumns;
            while (Counter < Number)
            {
                FieldColumns = Counter / 10;
                Label Lbl = new Label();
                Lbl.Height = Height - HeightDecrement;
                Lbl.Width = Width - 30;
                if (Counter < 10)
                    IncrementLocation = YInitialLocation + Counter * (Height - HeightDecrement);
                else
                    IncrementLocation = YInitialLocation + Counter % (FieldColumns * 10) * (Height - HeightDecrement);
                Lbl.Location = new Point((XInitialLocation - 60) + FieldColumns * 400, IncrementLocation);
                Lbl.AutoSize = false;
                Lbl.Font = this.LblFont;
                Lbl.TextAlign = ContentAlignment.MiddleLeft;
                Lbl.Text = "Hi";
                LblArr[Counter] = Lbl;
                this.Controls.Add(LblArr[Counter]);
                Counter++;
            }
        }

        private void Name_Label(int LblNo, string LblText)
        {
            LblArr[LblNo].Text = LblText;
        }

        private string Check_mandatoryField(int LblCheckNo)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string GivenValue = "";
            if (LblCheckNo != StartDtPos && LblCheckNo != EndDatePos)
            {
                string CaseValue = ControlType[LblCheckNo];
                switch (CaseValue)
                {
                    case "Combobox":
                        {
                            GivenValue = ComboArr1[LblCheckNo].Text;
                            break;
                        }
                    case "DatePicker":
                        {
                            GivenValue = "A";
                            break;
                        }
                    case "Textbox":
                        {
                            GivenValue = TxtBoxArr[LblCheckNo].Text;
                            break;
                        }
                }
            }
            string strQ1 = "select NullInd NI from AllFieldsDimension where Alias = '" +
                LblArr[LblCheckNo].Text + "' and TableName = '" + TableName + "'";
            cmd = new SqlCommand(strQ1, con);
            Rdr = cmd.ExecuteReader();
            Rdr.Read();
            string NullInd = Convert.ToString(Rdr["NI"]);
            if (LblCheckNo != StartDtPos && LblCheckNo != EndDatePos)
            {
                if (NullInd == "N" && (GivenValue == "" || GivenValue == null))
                {
                    Rdr.Close();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    return (LblArr[LblCheckNo].Text);
                }
                else
                {
                    Rdr.Close();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    return ("");
                }
            }
            else
            {
                if (NullInd == "N" && (DatePkArr[LblCheckNo].Text == "" || DatePkArr[LblCheckNo].Text == null))
                {
                    Rdr.Close();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    return (LblArr[LblCheckNo].Text);
                }
                else
                {
                    Rdr.Close();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    return ("");
                }
            }
        }

        private int GetMaxPlusOne()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            int KeyValue;
            string KeyFieldName = TableName.Replace("Dim", "Key");
            string strQ1 = "select isnull(max(" + KeyFieldName + "),0) KF from " + TableName;
            cmd = new SqlCommand(strQ1, con);
            Rdr = cmd.ExecuteReader();
            Rdr.Read();
            if (Rdr.HasRows == true)
                KeyValue = Convert.ToInt16(Rdr["KF"]);
            else
                KeyValue = 0;
            KeyValue = KeyValue + 1;
            Rdr.Close();
            return (KeyValue);
        }

        private string GetFieldValues(int LblNo)
        {
            if (LblNo == StartDtPos || LblNo == EndDatePos)
                return (DatePkArr[LblNo].Value.ToString("yyyy/MM/dd"));
            if (ControlType[LblNo] == "Combobox")
                return (ComboArr1[LblNo].Text);
            if (ControlType[LblNo] == "DatePicker")
                return (DtpArr1[LblNo].Value.ToString("yyyy/MM/dd"));
            return (TxtBoxArr[LblNo].Text);
        }

        private string Check_PrimaryKeyFields()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string WhereClause = "", strQ1, PrimaryKeyFields = "", GivenValue = "";
            int Counter = 0;
            while (Counter < NumberOfObject)
            {
                strQ1 = "select FieldName FN from AllFieldsDimension where Alias = '"
                    + LblArr[Counter].Text + "' and PrimaryKeyInd = 'Y' and TableName = '" + TableName + "'";
                string CaseValue = ControlType[Counter];
                switch (CaseValue)
                {
                    case "Combobox":
                        {
                            GivenValue = ComboArr1[Counter].Text;
                            break;
                        }
                    case "DatePicker":
                        {
                            if (Counter != StartDtPos && Counter != EndDatePos)
                                GivenValue = DtpArr1[Counter].Value.ToString("yyyy/MM/dd");
                            break;
                        }
                    case "Textbox":
                        {
                            GivenValue = TxtBoxArr[Counter].Text;
                            break;
                        }
                }
                cmd = new SqlCommand(strQ1, con);
                Rdr = cmd.ExecuteReader();
                Rdr.Read();
                if (Rdr.HasRows == true)
                {
                    if (WhereClause == "")
                    {
                        PrimaryKeyFields = LblArr[Counter].Text;
                        WhereClause = Convert.ToString(Rdr["FN"]) + " = '" + GivenValue + "'";
                    }
                    else
                    {
                        WhereClause = WhereClause + " and " + Convert.ToString(Rdr["FN"]) + " = '"
                            + GivenValue + "'";
                        PrimaryKeyFields = PrimaryKeyFields + ", " + LblArr[Counter].Text;
                    }
                }
                Rdr.Close();
                Counter++;
            }
            PrimaryFieldsWhereClauseGlobal = WhereClause;
            strQ1 = "select * from " + TableName + " where " + WhereClause;
            cmd = new SqlCommand(strQ1, con);
            Rdr = cmd.ExecuteReader();
            Rdr.Read();
            if (Rdr.HasRows == true)
            {
                Rdr.Close();
                return (PrimaryKeyFields);
            }
            else
            {
                Rdr.Close();
                return ("");
            }
        }

        private void Resize_grid(decimal DivideBy)
        {
            int Counter = 0;
            while (Counter < FieldsAlias.Length)
            {
                if (FieldsType[Counter].ToUpper() == "CHAR")
                    FieldsSize[Counter] = "3";
                if (FieldsType[Counter].ToUpper() == "INT")
                    FieldsSize[Counter] = "10";
                if (FieldsType[Counter].ToUpper() == "DECIMAL")
                    FieldsSize[Counter] = "12";
                if (FieldsType[Counter].ToUpper() == "DATETIME" || FieldsType[Counter].ToUpper() == "DATE")
                {
                    FieldsSize[Counter] = "10";
                    TransFlex.Columns[Counter].DefaultCellStyle.Format = "dd/MM/yyyy";
                    TransFlex.Columns[Counter].Width = 10 * Convert.ToInt16(FieldsSize[Counter]) - 6;
                }
                else
                {
                    FieldsSize[Counter] = FieldsSize[Counter].ToUpper().Replace("VARCHAR(", "");
                    FieldsSize[Counter] = FieldsSize[Counter].Replace(")", "");
                    if (Convert.ToInt16(FieldsSize[Counter]) >= 30)
                        FieldsSize[Counter] = "20";
                    TransFlex.Columns[Counter].Width = Convert.ToInt16(10 * Convert.ToDecimal(FieldsSize[Counter]) / DivideBy);
                }
                Counter++;
            }
        }

        private void Fill_grid(int Load, string QueryWhereClause)
        {
            if (QueryWhereClause != "")
                QueryWhereClause = " where 1 = 1 " + QueryWhereClause;
            if (Load == 1)
            {
                SelectFields = FieldNamesGlobal;
                FieldsAlias = SelectFields.Split(',');
                int Counter = 0;
                while (Counter < FieldsAlias.Length)
                {
                    strQ = "select Alias AL from AllFieldsDimension where FieldName = '" + FieldsAlias[Counter] + "'";
                    cmd = new SqlCommand(strQ, con);
                    Rdr = cmd.ExecuteReader();
                    Rdr.Read();
                    string Alias = Convert.ToString(Rdr["AL"]);
                    FieldsAlias[Counter] = FieldsAlias[Counter] + " '" + Alias + "', ";
                    Rdr.Close();
                    Counter++;
                }
                FieldsAlias[Counter - 1] = FieldsAlias[Counter - 1].Replace(",", "");
                Counter = 0;
                SelectFields = null;
                while (Counter < FieldsAlias.Length)
                {
                    SelectFields = SelectFields + FieldsAlias[Counter];
                    Counter++;
                }
            }
            strQ = "select " + SelectFields + " from " + TableName 
                + QueryWhereClause;
            adptr = new SqlDataAdapter(strQ, con);
            dt = new DataTable();
            adptr.Fill(dt);
            TransFlex.DataSource = dt; ;
        }

        private void Clear_TxtBox()
        {
            int Counter = 0;
            while (Counter < NumberOfObject)
            {
                if (Counter != StartDtPos && Counter != EndDatePos)
                {
                    if (ControlType[Counter] == "Combobox")
                    {
                        ComboArr1[Counter].Text = "";
                        if (ComboArr1[Counter].Items.Count > 0)
                            ComboArr1[Counter].SelectedIndex = 0;
                    }
                    if (ControlType[Counter] == "DatePicker")
                        DtpArr1[Counter].Value = DateTime.Now;
                    else
                        TxtBoxArr[Counter].Text = "";
                }
                Counter++;
            }
        }

        private void TransFlex_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int Counter = 0;
                string[] HeaderNames = new string[50];
                while (Counter < TransFlex.Columns.Count)
                {
                    HeaderNames[Counter] = TransFlex.Columns[Counter].HeaderText;
                    Counter++;
                }
                int Cnt = 0;
                string[] CellValuesSelected = new string[50];
                while (Cnt < Counter)
                {
                    CellValuesSelected[Cnt] = TransFlex[Cnt, e.RowIndex].Value.ToString();
                    Cnt++;
                }
                Counter--;
                while (Counter >= 0)
                {
                    if (Counter != StartDtPos && Counter != EndDatePos)
                    {
                        if (ControlType[Counter] == "Checkbox")
                            ComboArr1[Counter].Text = CellValuesSelected[Counter];
                        else if (ControlType[Counter] == "DatePicker")
                            DtpArr1[Counter].Value = Convert.ToDateTime(CellValuesSelected[Counter]);
                        else
                            TxtBoxArr[Counter].Text = CellValuesSelected[Counter];
                    }
                    if (Counter == StartDtPos)
                        DatePkArr[Counter].Value = Convert.ToDateTime(CellValuesSelected[Counter]);
                    if (Counter == EndDatePos)
                        DatePkArr[Counter].Value = Convert.ToDateTime(CellValuesSelected[Counter]);
                    Counter--;
                }
            }
        }

        public void TransflexReduceWidth(int WidthToDecrease)
        {
            float TransWidth, TransHeight;
            TransWidth = this.TransFlex.Width - WidthToDecrease;
            TransHeight = this.TransFlex.Height;
            SizeF SizeoFTrans = new SizeF(TransWidth, TransHeight);
            this.TransFlex.Size = SizeoFTrans.ToSize();
            //Point P1 = new Point(49, 34);
            //this.TransFlex.Location = P1;
        }

        public void TransflexIncreaseWidth(int WidthToIncrease)
        {
            float TransWidth, TransHeight;
            TransWidth = this.TransFlex.Width + WidthToIncrease;
            TransHeight = this.TransFlex.Height;
            SizeF SizeoFTrans = new SizeF(TransWidth, TransHeight);
            this.TransFlex.Size = SizeoFTrans.ToSize();
            //Point P1 = new Point(49, 34);
            //this.TransFlex.Location = P1;
        }

        private void CreateControls(int Number)
        {
            int Counter = 0;
            while (Counter < Number)
            {
                if (Counter != StartDtPos && Counter != EndDatePos)
                {
                    Point TxtLocation = TxtBoxArr[Counter].Location;
                    if (ControlType[Counter] == "Combobox")
                    {
                        ComboBox CmbBox = new ComboBox();
                        CmbBox.Height = Height;
                        CmbBox.Width = Width;
                        CmbBox.Font = this.AllFont;
                        CmbBox.Location = TxtLocation;
                        CmbBox.TabIndex = TxtBoxArr[Counter].TabIndex;
                        CmbBox.TextChanged += new EventHandler(this.Control_TextChanged);
                        if (ReadOnlyControlInd[Counter] == 'Y')
                            CmbBox.DropDownStyle = ComboBoxStyle.DropDownList;
                        ComboArr1[Counter] = CmbBox;
                        this.Controls.Remove(TxtBoxArr[Counter]);
                        this.Controls.Add(ComboArr1[Counter]);
                    }
                    if (ControlType[Counter] == "DatePicker")
                    {
                        DateTimePicker DatePick = new DateTimePicker();
                        DatePick.Height = Height;
                        DatePick.Width = Width - 109;
                        //DatePick.Font = this.AllFont;
                        DatePick.Location = TxtLocation;
                        DatePick.CustomFormat = "dd/MM/yyyy";
                        DatePick.Format = DateTimePickerFormat.Custom;
                        DatePick.TabIndex = TxtBoxArr[Counter].TabIndex;
                        DatePick.ValueChanged += new EventHandler(this.Control_TextChanged);
                        DtpArr1[Counter] = DatePick;
                        this.Controls.Remove(TxtBoxArr[Counter]);
                        this.Controls.Add(DtpArr1[Counter]);
                    }
                    LblArr[Counter].SendToBack();
                }
                Counter++;
            }
        }

        private void PutDefaultValues(int Number)
        {
            int Counter = 0;
            while (Counter < Number)
            {
                if (Counter != StartDtPos && Counter != EndDatePos)
                {
                    if (ControlType[Counter] == "Combobox")
                    {
                        string[] CmbDefaultValues = new string[1000];
                        CmbDefaultValues = DefaultValues[Counter].Split('^');
                        int Counter1 = 0;
                        while (Counter1 < CmbDefaultValues.Length)
                        {
                            if (CmbDefaultValues[Counter1] == "Query:")
                            {
                                string Query = CmbDefaultValues[Counter1 + 1];
                                cmd = new SqlCommand(Query, con);
                                Rdr = cmd.ExecuteReader();
                                if (Rdr.HasRows == true)
                                {
                                    while (Rdr.Read())
                                        ComboArr1[Counter].Items.Add(Convert.ToString(Rdr["RESULT"]));
                                }
                                Counter1 = CmbDefaultValues.Length;
                                Rdr.Close();
                            }
                            else
                            {
                                ComboArr1[Counter].Items.Add(CmbDefaultValues[Counter1]);
                                Counter1++;
                            }
                        }
                        if (ComboArr1[Counter].Items.Count != 0)
                            ComboArr1[Counter].SelectedIndex = 0;
                    }
                    if (ControlType[Counter] == "Textbox")
                    {
                        TxtBoxArr[Counter].Text = DefaultValues[Counter];
                    }
                }
                Counter++;
            }
        }

        private void AdjustExitBtn()
        {
            int TransFlexX = TransFlex.Location.X;
            int TransFlexWidth = TransFlex.Size.Width;
            int ExitBtnWidth = BtnExit.Width;
            int PrevExitX = BtnExit.Location.X;
            int ExitBtnX = TransFlexX + TransFlexWidth - ExitBtnWidth;
            int ExitBtnY = BtnExit.Location.Y;
            int ExitBtnXDiff = PrevExitX - ExitBtnX;
            int FrameWidth = GrpBox.Size.Width - ExitBtnXDiff;
            GrpBox.Width = FrameWidth;
            BtnAdd.Font = this.BtnFont;
            BtnDelete.Font = this.BtnFont;
            BtnUpdate.Font = this.BtnFont;
            BtnExit.Font = this.BtnFont;
            GrpBox.SendToBack();
            if (TransFlex.Width < 700)
            {
                int BtnWidth = 110, BtnHeigth = 40;
                BtnAdd.Width = BtnWidth;
                BtnAdd.Height = BtnHeigth;
                BtnDelete.Width = BtnWidth;
                BtnDelete.Height = BtnHeigth;
                BtnUpdate.Width = BtnWidth;
                BtnUpdate.Height = BtnHeigth;
                BtnExit.Width = BtnWidth;
                BtnExit.Height = BtnHeigth;
                ExitBtnX = TransFlexX + TransFlexWidth - BtnExit.Width - 10;
            }
            BtnAdd.Location = new Point(TransFlex.Location.X - 20, ExitBtnY);
            BtnDelete.Location = new Point(BtnAdd.Location.X + BtnAdd.Width + 20, BtnAdd.Location.Y);
            BtnUpdate.Location = new Point(BtnDelete.Location.X + BtnDelete.Width + 20, BtnDelete.Location.Y);
            BtnExit.Location = new Point(ExitBtnX - 10, ExitBtnY);
        }

        public void ColourForm(Color Clr)
        {
            this.BackColor = Clr;
            GrpBox.BackColor = Clr;
        }

        public void Control_TextChanged(object sender, EventArgs e)
        {
            string Query = "";
            int Counter = 0;
            while (Counter < ImportantFieldInd.Length && ImportantFieldInd[Counter] != '\0' && FormBuildOver == 1)
            {
                if (ImportantFieldInd[Counter] == 'Y')
                {
                    if (ControlType[Counter] == "Textbox" && TxtBoxArr[Counter].Text != null && TxtBoxArr[Counter].Text != "")
                    {
                        Query = Query + " and " + FieldNameArr[Counter] + " like '" + TxtBoxArr[Counter].Text + "%'";
                    }
                    if (ControlType[Counter] == "Combobox" && ComboArr1[Counter].Text != "" && ComboArr1[Counter].Text != "")
                    {
                        Query = Query + " and " + FieldNameArr[Counter] + " like '" + ComboArr1[Counter].Text + "%'";
                    }
                    if (ControlType[Counter] == "DatePicker")
                    {
                        Query = Query + " and " + FieldNameArr[Counter] + " = '" + DtpArr1[Counter].Value.ToString("yyyy/MM/dd") + "'";
                    }
                }
                Counter++;
            }
            Fill_grid(0, Query);
        }

        private void BtnAdd_Click_1(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            int Counter = 0, KeyValue;
            string ReturnValue = "", FinalReturnValue = "";
            while (Counter < NumberOfObject)
            {
                ReturnValue = Check_mandatoryField(Counter);
                if (ReturnValue != "" && Counter != 0)
                    FinalReturnValue = FinalReturnValue + ", " + Check_mandatoryField(Counter);
                else if (ReturnValue != "" && Counter == 0)
                    FinalReturnValue = Check_mandatoryField(Counter);
                Counter++;
            }
            if (FinalReturnValue != "")
                MessageBox.Show(FinalReturnValue + " FIELDS NEED TO BE PROVIDED SOME VALUE.");
            else
            {
                string PrimaryKeyFields = Check_PrimaryKeyFields();
                if (PrimaryKeyFields != "")
                    MessageBox.Show("THE RECORD IS ALREADY PRESENT WITH THE SAME VALUES FOR FIELDS : " + PrimaryKeyFields +
                        "\nPERFORM DELETE OR UPDATE ON THIS RECORD");
                else
                {
                    KeyValue = GetMaxPlusOne();
                    string InsertString = "'" + Convert.ToString(KeyValue);
                    Counter = 0;
                    while (Counter < NumberOfObject)
                    {
                        InsertString = InsertString + "','" + GetFieldValues(Counter);
                        Counter++;
                    }
                    InsertString = InsertString + "'";
                    strQ = "insert into " + TableName + " values (" + InsertString + ")";
                    cmd = new SqlCommand(strQ, con);
                    cmd.ExecuteNonQuery();
                }
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            Fill_grid(0, "");
            Clear_TxtBox();
        }

        private void BtnDelete_Click_1(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string WhereClause = "", Querry, FieldName = "", FieldValue = "";
            int Counter = 0, RowCount = 0;
            while (Counter < NumberOfObject)
            {
                Querry = "select FieldName FN from AllFieldsDimension where Alias = '"
                    + LblArr[Counter].Text + "' and TableName = '" + TableName + "'";
                cmd = new SqlCommand(Querry, con);
                Rdr = cmd.ExecuteReader();
                Rdr.Read();
                if (Rdr.HasRows == true)
                {
                    FieldName = Rdr["FN"].ToString();
                }
                Rdr.Close();
                FieldValue = GetFieldValues(Counter);
                if (WhereClause == "")
                    WhereClause = FieldName + " = '" + FieldValue + "'";
                else
                    WhereClause = WhereClause + " and " + FieldName + " = '" + FieldValue + "'";
                Counter++;
            }
            strQ = "select * from " + TableName + " where " + WhereClause;
            cmd = new SqlCommand(strQ, con);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                while (Rdr.Read())
                    RowCount++;
            }
            Rdr.Close();
            if (RowCount == 0)
                MessageBox.Show("ERROR : NO ROWS FOUND FOR THE GIVEN VALUES.");
            if (RowCount > 1)
                MessageBox.Show("ERROR : " + RowCount + " ROWS FOUND FOR THE GIVEN VALUES.");
            int KeyFieldValue = 0;
            strQ = "select " + KeyName + " KV from " + TableName + " where " + WhereClause;
            cmd = new SqlCommand(strQ, con);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                Rdr.Read();
                KeyFieldValue = Convert.ToInt16(Rdr["KV"]);
            }
            Rdr.Close();
            string CheckPrimaryKeyFields = Check_PrimaryKeyFields();
            strQ = "delete from " + TableName + " where " + WhereClause;
            cmd = new SqlCommand(strQ, con);
            cmd.ExecuteNonQuery();
            Fill_grid(0, "");
            Clear_TxtBox();
            if (con.State == ConnectionState.Open)
                con.Close();
        }

        private void BtnUpdate_Click_1(object sender, EventArgs e)
        {
            int Counter = 0;
            string ReturnValue = "", FinalReturnValue = "";
            while (Counter < NumberOfObject)
            {
                ReturnValue = Check_mandatoryField(Counter);
                if (ReturnValue != "" && Counter != 0)
                    FinalReturnValue = FinalReturnValue + ", " + Check_mandatoryField(Counter);
                else if (ReturnValue != "" && Counter == 0)
                    FinalReturnValue = Check_mandatoryField(Counter);
                Counter++;
            }
            if (FinalReturnValue != "")
                MessageBox.Show(FinalReturnValue + " FIELD(S) NEED TO BE PROVIDED SOME VALUE.");
            else
            {
                string PrimaryKeyFields = Check_PrimaryKeyFields();
                if (PrimaryKeyFields != "")
                {
                    int OldKeyValue = 0;
                    strQ = "select " + KeyName + " OK from " + TableName
                        + " where " + PrimaryFieldsWhereClauseGlobal;
                    cmd = new SqlCommand(strQ, con);
                    Rdr = cmd.ExecuteReader();
                    if (Rdr.HasRows == true)
                    {
                        Rdr.Read();
                        OldKeyValue = Convert.ToInt16(Rdr["OK"]);
                    }
                    Rdr.Close();

                    //Update Record
                    string UpdtString = "update " + TableName + " set"; // Convert.ToString(KeyValue);
                    Counter = 0;
                    while (Counter < NumberOfObject)
                    {
                        if (Counter == 0) 
                            UpdtString = UpdtString + " " + FieldNameArr[Counter] + " = '" + GetFieldValues(Counter) + "'";
                        else
                            UpdtString = UpdtString + ", " + FieldNameArr[Counter] + " = '" + GetFieldValues(Counter) + "'";
                        Counter++;
                    }
                    UpdtString = UpdtString + " where " + KeyName + " = " + Convert.ToString(OldKeyValue);
                    cmd = new SqlCommand(UpdtString, con);
                    cmd.ExecuteNonQuery();
                }
                Fill_grid(0, "");
                Clear_TxtBox();
            }
        }

    }
}
