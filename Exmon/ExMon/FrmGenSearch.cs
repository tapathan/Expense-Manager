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
    public partial class FrmGenSearch : Form
    {
        string TableNames;
        string CriteriaFields;
        string DisplayFields;
        string Groups;
        string FreezedFields;
        string Calculations;
        Color FrmClr;

        public FrmGenSearch(Color FrmClr, string TblNamesSepbyPipe, string CriteriaFieldsSepbyPipe, string GroupsSepbyPipe, string FreezeFieldsSepbyPipe, string Calculations)
        {
            InitializeComponent();
            this.FrmClr = FrmClr;
            this.TableNames = TblNamesSepbyPipe;
            this.CriteriaFields = CriteriaFieldsSepbyPipe.Split('#')[0];
            this.DisplayFields = CriteriaFieldsSepbyPipe.Split('#')[1];
            this.Groups = GroupsSepbyPipe;
            this.FreezedFields = FreezeFieldsSepbyPipe;
            this.Calculations = Calculations;
        }

        public FrmGenSearch(Color FrmClr, string TblNamesSepbyPipe, string CriteriaFieldsSepbyPipe, string GroupsSepbyPipe, string FreezeFieldsSepbyPipe)
        {
            InitializeComponent();
            this.FrmClr = FrmClr;
            this.TableNames = TblNamesSepbyPipe;
            this.CriteriaFields = CriteriaFieldsSepbyPipe.Split('#')[0];
            this.DisplayFields = CriteriaFieldsSepbyPipe.Split('#')[1];
            this.Groups = GroupsSepbyPipe;
            this.FreezedFields = FreezeFieldsSepbyPipe;
            this.Calculations = "";
        }

        public FrmGenSearch(Color FrmClr, string TblNamesSepbyPipe, string CriteriaFieldsSepbyPipe, string GroupsSepbyPipe)
        {
            InitializeComponent();
            this.FrmClr = FrmClr;
            this.TableNames = TblNamesSepbyPipe;
            this.CriteriaFields = CriteriaFieldsSepbyPipe.Split('#')[0];
            this.DisplayFields = CriteriaFieldsSepbyPipe.Split('#')[1];
            this.Groups = GroupsSepbyPipe;
            this.FreezedFields = "";
            this.Calculations = "";
        }

        public FrmGenSearch(Color FrmClr, string TblNamesSepbyPipe, string CriteriaFieldsSepbyPipe)
        {
            InitializeComponent();
            this.FrmClr = FrmClr;
            this.TableNames = TblNamesSepbyPipe;
            this.CriteriaFields = CriteriaFieldsSepbyPipe.Split('#')[0];
            this.DisplayFields = CriteriaFieldsSepbyPipe.Split('#')[1];
            this.Groups = "";
            this.FreezedFields = "";
            this.Calculations = "";
        }

        public FrmGenSearch(Color FrmClr, string TblNamesSepbyPipe)
        {
            InitializeComponent();
            this.FrmClr = FrmClr;
            this.TableNames = TblNamesSepbyPipe;
            this.CriteriaFields = "";
            this.DisplayFields = "";
            this.Groups = "";
            this.FreezedFields = "";
            this.Calculations = "";
        }

        Label[] LblArr = new Label[50];
        TextBox[] TxtBoxArr = new TextBox[50];
        ComboBox[] DataCmbArr = new ComboBox[50];
        ComboBox[] OptionCmbArr = new ComboBox[50];
        DateTimePicker[] DtpArr = new DateTimePicker[50];
        CheckBox[] ChkBoxArr = new CheckBox[50];
        Button[] BtnArr = new Button[50];
        GroupBox[] GrpBoxArr = new GroupBox[15];
        DataGridView DGVResult = new DataGridView();
        GroupBox GrpDGV = new GroupBox();
        TextBox FinalTxtbox = new TextBox();
        Button BtnEnter = new Button();
        Button BtnCancel = new Button();
        Button BtnExportToXls = new Button();
        KeyEventArgs KeyPressedEvent;

        CommonFunctions CommFunc = new CommonFunctions();

        string[] FieldNamesArr;
        string[] FieldTypeArr;
        string[] FieldLengthArr;
        string[] FieldAliasArr;
        string[] ViewFieldNameArr;
        string[] FieldTableNameArr;

        string[] DisplayFieldNamesArr;
        string[] DisplayFieldTypeArr;
        string[] DisplayFieldLengthArr;
        string[] DisplayFieldAliasArr;
        string[] DisplayViewFieldNameArr;
        string[] DisplayFieldTableNameArr;

        string[] EnableGrpControlArr = new string[100];

        private void FrmGenSearch_Load(object sender, EventArgs e)
        {
            string Result = "";
            string[] TableNameArr = TableNames.Split('|');
            int loopcounter = 0;
            while (loopcounter < TableNameArr.Length)
            {
                if (loopcounter == 0)
                    Result = CommFunc.select_table("AllFieldsDimension", "FieldName|FieldType|FieldLength|Alias|ViewFieldName|TableName", "TableName="
                        + TableNameArr[loopcounter] + "|" + "KeyFieldInd!=Y");
                else
                    Result = Result + "#" + CommFunc.select_table("AllFieldsDimension", "FieldName|FieldType|FieldLength|Alias|ViewFieldName|TableName",
                    "TableName=" + TableNameArr[loopcounter] + "|" + "KeyFieldInd!=Y");
                loopcounter++;
            }
            string[] ResultArr = Result.Split('#');
            string FieldNames = "";
            string FieldType = "";
            string FieldLength = "";
            string FieldAlias = "";
            string ViewFieldName = "";
            string FieldTableName = "";
            string DisplayFieldNames = "";
            string DisplayFieldType = "";
            string DisplayFieldLength = "";
            string DisplayFieldAlias = "";
            string DisplayViewFieldName = "";
            string DisplayFieldTableName = "";
            loopcounter = 0;
            Boolean CriteriaFieldFlg;
            Boolean DisplayFieldFlg;
            while (loopcounter < ResultArr.Length)
            {
                CriteriaFieldFlg = CriteriaFields.Contains(ResultArr[loopcounter].Split('|')[4] + "|");
                if (CriteriaFieldFlg == true)
                {
                    if (FieldNames == "")
                    {
                        FieldNames = ResultArr[loopcounter].Split('|')[0];
                        FieldType = ResultArr[loopcounter].Split('|')[1];
                        FieldLength = ResultArr[loopcounter].Split('|')[2];
                        FieldAlias = ResultArr[loopcounter].Split('|')[3];
                        ViewFieldName = ResultArr[loopcounter].Split('|')[4];
                        FieldTableName = ResultArr[loopcounter].Split('|')[5];
                    }
                    else
                    {
                        FieldNames = FieldNames + "|" + ResultArr[loopcounter].Split('|')[0];
                        FieldType = FieldType + "|" + ResultArr[loopcounter].Split('|')[1];
                        FieldLength = FieldLength + "|" + ResultArr[loopcounter].Split('|')[2];
                        FieldAlias = FieldAlias + "|" + ResultArr[loopcounter].Split('|')[3];
                        ViewFieldName = ViewFieldName + "|" + ResultArr[loopcounter].Split('|')[4];
                        FieldTableName = FieldTableName + "|" + ResultArr[loopcounter].Split('|')[5];
                    }
                }
                DisplayFieldFlg = DisplayFields.Contains(ResultArr[loopcounter].Split('|')[4] + "|");
                if (DisplayFieldFlg == true)
                {
                    if (DisplayFieldNames == "")
                    {
                        DisplayFieldNames = ResultArr[loopcounter].Split('|')[0];
                        DisplayFieldType = ResultArr[loopcounter].Split('|')[1];
                        DisplayFieldLength = ResultArr[loopcounter].Split('|')[2];
                        DisplayFieldAlias = ResultArr[loopcounter].Split('|')[3];
                        DisplayViewFieldName = ResultArr[loopcounter].Split('|')[4];
                        DisplayFieldTableName = ResultArr[loopcounter].Split('|')[5];
                    }
                    else
                    {
                        DisplayFieldNames = DisplayFieldNames + "|" + ResultArr[loopcounter].Split('|')[0];
                        DisplayFieldType = DisplayFieldType + "|" + ResultArr[loopcounter].Split('|')[1];
                        DisplayFieldLength = DisplayFieldLength + "|" + ResultArr[loopcounter].Split('|')[2];
                        DisplayFieldAlias = DisplayFieldAlias + "|" + ResultArr[loopcounter].Split('|')[3];
                        DisplayViewFieldName = DisplayViewFieldName + "|" + ResultArr[loopcounter].Split('|')[4];
                        DisplayFieldTableName = DisplayFieldTableName + "|" + ResultArr[loopcounter].Split('|')[5];
                    }
                }
                loopcounter++;
            }
            FieldNamesArr = FieldNames.Split('|');
            FieldTypeArr = FieldType.Split('|');
            FieldLengthArr = FieldLength.Split('|');
            FieldAliasArr = FieldAlias.Split('|');
            ViewFieldNameArr = ViewFieldName.Split('|');
            FieldTableNameArr = FieldTableName.Split('|');
            DisplayFieldNamesArr = DisplayFieldNames.Split('|');
            DisplayFieldTypeArr = DisplayFieldType.Split('|');
            DisplayFieldLengthArr = DisplayFieldLength.Split('|');
            DisplayFieldAliasArr = DisplayFieldAlias.Split('|');
            DisplayViewFieldNameArr = DisplayViewFieldName.Split('|');
            DisplayFieldTableNameArr = DisplayFieldTableName.Split('|');
            loopcounter = 0;
            while (loopcounter < FieldNamesArr.Length)
            {
                EnableGrpControlArr[loopcounter] = "";
                loopcounter++;
            }
            loopcounter = 0;
            int FrmWidth = this.Width;
            int FrmHeight = this.Height;
            int Width = 330;
            int Height = 26;
            int ControlsPerLine = 0;
            int XInitialLocation = 20, YInitialLocation = 40, OuterGrpLocation = YInitialLocation;
            int IncrementLocation;
            int Counter = 0;
            if (this.Width > 1325)
                ControlsPerLine = 4;
            else if (this.Width >= 1000)
                ControlsPerLine = 3;
            else if (this.Width >= 700)
                ControlsPerLine = 2;
            else
                ControlsPerLine = 1;
            while (loopcounter < FieldNamesArr.Length)
            {
                if (Counter > ControlsPerLine - 1)
                {
                    YInitialLocation = YInitialLocation + Height + 10;
                    Counter = 0;
                    GroupBox GrpBox = new GroupBox();
                    GrpBox.Location = new Point(XInitialLocation, YInitialLocation - 10);
                    GrpBox.Width = FrmWidth - 50;
                    GrpBox.Height = 1;
                    GrpBox.Text = "";
                    GrpBox.SendToBack();
                    GrpBoxArr[loopcounter / ControlsPerLine] = GrpBox;
                    this.Controls.Add(GrpBoxArr[loopcounter / ControlsPerLine]);
                }
                IncrementLocation = XInitialLocation + Counter * Width;
                // Create Label
                Label Lbl = new Label();
                Lbl.Location = new Point(IncrementLocation, YInitialLocation);
                Lbl.AutoSize = true;
                Lbl.TextAlign = ContentAlignment.MiddleLeft;
                Lbl.Text = FieldAliasArr[loopcounter];
                Lbl.BackColor = Color.LightGray;
                LblArr[loopcounter] = Lbl;
                this.Controls.Add(LblArr[loopcounter]);
                // Create Combo Options
                ComboBox Cmb = new ComboBox();
                Cmb.Location = new Point(IncrementLocation + 125, YInitialLocation - 3);
                Cmb.Width = 50;
                Cmb.TabIndex = FieldAliasArr.Length + loopcounter;
                Cmb.Items.Add("=");
                Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                if (FieldTypeArr[loopcounter].ToUpper() == "INT" || FieldTypeArr[loopcounter].ToUpper() == "DECIMAL" || FieldTypeArr[loopcounter].ToUpper() == "DATETIME" || FieldTypeArr[loopcounter].ToUpper() == "DATE")
                {
                    Cmb.Items.Add("<=");
                    Cmb.Items.Add(">=");
                }
                else
                {
                    Cmb.Items.Add("Like");
                    Cmb.Items.Add("Startwith");
                    Cmb.Items.Add("Endwith");
                }
                Cmb.SelectedIndex = 0;
                //Cmb.SelectedIndexChanged += new EventHandler(this.RefreshTxtFilePath);
                OptionCmbArr[loopcounter] = Cmb;
                this.Controls.Add(OptionCmbArr[loopcounter]);
                if (FreezedFields.Contains(ViewFieldNameArr[loopcounter] + "=") == true)
                {
                    // Create Combo Data Freezed
                    ComboBox Cmb1 = new ComboBox();
                    Cmb1.Location = new Point(IncrementLocation + 125 + 55, YInitialLocation - 3);
                    if (FieldTypeArr[loopcounter].ToUpper() == "CHAR" || (FieldTypeArr[loopcounter].ToUpper() == "VARCHAR") && Convert.ToInt16(FieldLengthArr[loopcounter]) < 5)
                        Cmb1.Width = 50;
                    else
                        Cmb1.Width = 140;
                    Cmb1.TabIndex = loopcounter;
                    Cmb1.DropDownStyle = ComboBoxStyle.DropDownList;
                    int i = 0;
                    while (i < FreezedFields.Split('|').Length)
                    {
                        if (FreezedFields.Split('|')[i].Split('=')[0] == ViewFieldNameArr[loopcounter])
                            Cmb1.Items.Add(FreezedFields.Split('|')[i].Split('=')[1]);
                        i++;
                    }
                    Cmb1.SelectedIndex = 0;
                    Cmb1.TextChanged += new EventHandler(this.CmbTextChanged);
                    Cmb1.KeyDown += new KeyEventHandler(this.KeyDown);
                    DataCmbArr[loopcounter] = Cmb1;
                    this.Controls.Add(DataCmbArr[loopcounter]);
                    OptionCmbArr[loopcounter].Items.Clear();
                    OptionCmbArr[loopcounter].Items.Add("=");
                    OptionCmbArr[loopcounter].SelectedIndex = 0;
                }
                else
                {
                    if (FieldTypeArr[loopcounter].ToUpper() == "DATETIME" || FieldTypeArr[loopcounter].ToUpper() == "DATE")
                    {
                        // Create DatePicker
                        DateTimePicker Dtp = new DateTimePicker();
                        Dtp.Location = new Point(IncrementLocation + 125 + 55, YInitialLocation - 3);
                        Dtp.Width = 85;
                        Dtp.Format = DateTimePickerFormat.Custom;
                        Dtp.CustomFormat = "dd-MM-yyyy";
                        Dtp.TabIndex = loopcounter;
                        DtpArr[loopcounter] = Dtp;
                        this.Controls.Add(DtpArr[loopcounter]);
                    }
                    else if (FieldTypeArr[loopcounter].ToUpper() == "INT" || FieldTypeArr[loopcounter].ToUpper() == "DECIMAL")
                    {
                        // Create TextBox Data
                        TextBox Txt1 = new TextBox();
                        Txt1.Location = new Point(IncrementLocation + 125 + 55, YInitialLocation - 3);
                        Txt1.Width = 140;
                        Txt1.TabIndex = loopcounter;
                        Txt1.TextChanged += new EventHandler(this.TxtTextChanged);
                        Txt1.KeyDown += new KeyEventHandler(this.KeyDown);
                        TxtBoxArr[loopcounter] = Txt1;
                        this.Controls.Add(TxtBoxArr[loopcounter]);
                    }
                    else
                    {
                        // Create Combo Data
                        ComboBox Cmb1 = new ComboBox();
                        Cmb1.Location = new Point(IncrementLocation + 125 + 55, YInitialLocation - 3);
                        if (FieldTypeArr[loopcounter].ToUpper() == "CHAR" || (FieldTypeArr[loopcounter].ToUpper() == "VARCHAR") && Convert.ToInt16(FieldLengthArr[loopcounter]) < 5)
                            Cmb1.Width = 50;
                        else
                            Cmb1.Width = 140;
                        Cmb1.TabIndex = loopcounter;
                        Cmb1.TextChanged += new EventHandler(this.CmbTextChanged);
                        Cmb1.KeyDown += new KeyEventHandler(this.KeyDown);
                        DataCmbArr[loopcounter] = Cmb1;
                        this.Controls.Add(DataCmbArr[loopcounter]);
                    }
                }
                Counter++;
                loopcounter++;
            }
            YInitialLocation = YInitialLocation + Height + 10;
            GroupBox GrpBoxTemp = new GroupBox();
            GrpBoxTemp.Location = new Point(XInitialLocation, YInitialLocation - 10);
            GrpBoxTemp.Width = FrmWidth - 50;
            GrpBoxTemp.Height = 1;
            GrpBoxTemp.Text = "";
            GrpBoxArr[loopcounter / ControlsPerLine] = GrpBoxTemp;
            this.Controls.Add(GrpBoxArr[loopcounter / ControlsPerLine]);
            GroupBox GrpBox1 = new GroupBox();
            GrpBox1.Location = new Point(XInitialLocation - 5, 25);
            GrpBox1.Width = FrmWidth - 50 + 5;
            GrpBox1.Height = YInitialLocation - 30;
            GrpBox1.Text = "";
            GrpBox1.SendToBack();
            GrpBox1.BackColor = Color.LightGray;
            GrpBoxArr[loopcounter / ControlsPerLine] = GrpBox1;
            this.Controls.Add(GrpBoxArr[loopcounter / ControlsPerLine]);
            BtnEnter.Location = new Point(XInitialLocation - 5, YInitialLocation);
            if (this.Width < 500)
                BtnEnter.Width = 120;
            else if (ControlsPerLine == 1)
                BtnEnter.Width = 150;
            else if (ControlsPerLine == 2)
                BtnEnter.Width = 220;
            else 
                BtnEnter.Width = 250;
            BtnEnter.Height = 40;
            BtnEnter.Text = "Enter";
            BtnEnter.FlatStyle = FlatStyle.System;
            BtnEnter.Click += new EventHandler(this.BuildQueryAndFillDGV);
            this.Controls.Add(BtnEnter);
            this.AcceptButton = BtnEnter;
            BtnExportToXls.Location = new Point(XInitialLocation + BtnEnter.Width, YInitialLocation);
            if (this.Width < 500)
                BtnExportToXls.Visible = false;
            else if (ControlsPerLine == 1)
                BtnExportToXls.Width = 150;
            else if (ControlsPerLine == 2)
                BtnExportToXls.Width = 220;
            else
                BtnExportToXls.Width = 250;
            BtnExportToXls.Height = 40;
            BtnExportToXls.Text = "Export To Xls";
            BtnExportToXls.FlatStyle = FlatStyle.System;
            BtnExportToXls.Click += new EventHandler(this.BtnExportToXls_Click);
            this.Controls.Add(BtnExportToXls);
            if (this.Width < 500)
                BtnCancel.Width = 120;
            else if (ControlsPerLine == 1)
                BtnCancel.Width = 150;
            else if (ControlsPerLine == 2)
                BtnCancel.Width = 220;
            else
                BtnCancel.Width = 250;
            BtnCancel.Height = 40;
            BtnCancel.Location = new Point(GrpBox1.Location.X + GrpBox1.Width - BtnCancel.Width, YInitialLocation);
            BtnCancel.Text = "Cancel";
            BtnCancel.FlatStyle = FlatStyle.System;
            BtnCancel.Click += new EventHandler(this.FrmClose);
            this.Controls.Add(BtnCancel);
            GrpDGV.Location = new Point(XInitialLocation - 5, YInitialLocation + 48);
            DGVResult.Location = new Point(XInitialLocation + 5, YInitialLocation + 48 + 15);
            GrpDGV.Width = FrmWidth - 50 + 5;
            DGVResult.Width = FrmWidth - 50 - 20;
            GrpDGV.Height = FrmHeight - 70 - YInitialLocation - 50;
            GrpDGV.SendToBack();
            DGVResult.BringToFront();
            this.Controls.Add(DGVResult);
            this.Controls.Add(GrpDGV);
            loopcounter = 0;
            int DGVCellsWidth = 0;
            while (loopcounter < DisplayFieldAliasArr.Length)
            {
                if (FreezedFields.Contains(DisplayViewFieldNameArr[loopcounter] + "=") == false
                    && DisplayFields.Contains(DisplayViewFieldNameArr[loopcounter] + "|") == true)
                {
                    DGVResult.Columns.Add(DisplayViewFieldNameArr[loopcounter], DisplayFieldAliasArr[loopcounter]);
                    DGVCellsWidth = DGVCellsWidth + DGVResult.Columns[loopcounter].Width;
                }
                loopcounter++;
            }
            loopcounter = 0;
            if (DGVCellsWidth < DGVResult.Width)
            {
                int LessWidth = DGVResult.Width - DGVCellsWidth;
                while (loopcounter < DisplayFieldAliasArr.Length)
                {
                    DGVResult.Columns[loopcounter].Width = DGVResult.Columns[loopcounter].Width
                        + LessWidth / DGVResult.Columns.Count - 42 / DGVResult.Columns.Count;
                    if (DGVResult.Columns[loopcounter].Width >= DGVResult.Width - 42 / DGVResult.Columns.Count)
                        DGVResult.Columns[loopcounter].Width = DGVResult.Width - 43;
                    loopcounter++;
                }
            }
            DGVResult.AllowUserToAddRows = false;
            DGVResult.Height = GrpDGV.Height - 20;
            FinalTxtbox.Width = DGVResult.Width;
            FinalTxtbox.Height = 40;
            FinalTxtbox.TextAlign = HorizontalAlignment.Right;
            FinalTxtbox.ReadOnly = true;
            FinalTxtbox.Font = new Font(this.Font.Name, this.Font.Size + 1, FontStyle.Bold);
            if (Calculations == "")
                FinalTxtbox.Visible = false;
            else
                DGVResult.Height = DGVResult.Height - 30;
            FinalTxtbox.Location = new Point(XInitialLocation + 5, DGVResult.Location.Y + DGVResult.Height + 5);
            this.Controls.Add(FinalTxtbox);
            FinalTxtbox.BringToFront();            

            //Set Form Color
            SetFormColor(FrmClr);
            GroupBox GrpOuter = new GroupBox();
            GrpOuter.Location = new Point(XInitialLocation - 15, OuterGrpLocation - 30);
            GrpOuter.Width = GrpDGV.Width + 20;
            GrpOuter.Height = FrmHeight - 70;
            GrpOuter.BackColor = LighterColor(FrmClr, 50f);
            this.Controls.Add(GrpOuter);
            GrpOuter.SendToBack();
        }

        public void SetFormColor(Color Clr)
        {
            int ControlsPerLine = 0;
            if (this.Width > 1325)
                ControlsPerLine = 4;
            else if (this.Width >= 1000)
                ControlsPerLine = 3;
            else if (this.Width >= 700)
                ControlsPerLine = 2;
            else
                ControlsPerLine = 1;
            int loopcounter = 0;
            if (FieldNamesArr.Length > ControlsPerLine + 2)
            {
                while (loopcounter < FieldNamesArr.Length)
                {
                    LblArr[loopcounter].BackColor = Clr;
                    if (loopcounter >= ControlsPerLine && GrpBoxArr[loopcounter / ControlsPerLine + 1] != null)
                        GrpBoxArr[loopcounter / ControlsPerLine + 1].BackColor = Clr;
                    loopcounter++;
                }
            }
            else
            {
                while (loopcounter < FieldNamesArr.Length)
                {
                    LblArr[loopcounter].BackColor = Clr;
                    if (loopcounter >= ControlsPerLine)
                        GrpBoxArr[loopcounter / ControlsPerLine].BackColor = Clr;
                    loopcounter++;
                }
            }
            if (FieldNamesArr.Length <= ControlsPerLine)
                GrpBoxArr[1].BackColor = Clr;
            GrpDGV.BackColor = Clr;
            this.BackColor = LighterColor(Clr, 75f);
            BtnEnter.BackColor = SystemColors.Control;
            BtnCancel.BackColor = SystemColors.Control;
        }

        private Color LighterColor(Color Clr, float Percent)
        {
            float correctionfactory = Percent;
            correctionfactory = correctionfactory / 100f;
            const float rgb255 = 255f;
            return Color.FromArgb((int)((float)Clr.R + ((rgb255 - (float)Clr.R) * correctionfactory)), 
                (int)((float)Clr.G + ((rgb255 - (float)Clr.G) * correctionfactory)), 
            (int)((float)Clr.B + ((rgb255 - (float)Clr.B) * correctionfactory)));
        }

        private void BtnExportToXls_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Sheet1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            for (int i = 1; i < DGVResult.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = DGVResult.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i <= DGVResult.Rows.Count - 1; i++)
            {
                for (int j = 0; j < DGVResult.Columns.Count; j++)
                {
                    if (DGVResult.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = DGVResult.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }

        private void TxtTextChanged(object sender, EventArgs e)
        {
            TextBox TxtBoxTemp = (TextBox)sender;
            int ArrSeq = TxtBoxTemp.TabIndex;
            CommFunc.AutoFill(TxtBoxTemp, FieldTableNameArr[ArrSeq], FieldNamesArr[ArrSeq], KeyPressedEvent);
            if (TxtBoxTemp.Text != "")
            {
                if (Groups.Contains(ViewFieldNameArr[ArrSeq] + "|") == true 
                    || Groups.Contains(ViewFieldNameArr[ArrSeq] + ",") == true)
                {
                    string[] GroupsArr = Groups.Split('|');
                    int loopcounter = 0;
                    while (loopcounter < GroupsArr.Length)
                    {
                        GroupsArr[loopcounter] = GroupsArr[loopcounter] + ",";
                        if (GroupsArr[loopcounter].Contains(ViewFieldNameArr[ArrSeq] + ",") == true)
                        {
                            string[] GroupsArrArr = GroupsArr[loopcounter].Split(',');
                            int internalloopcounter = 0;
                            while (internalloopcounter < FieldNamesArr.Length)
                            {
                                if (internalloopcounter != ArrSeq)
                                {
                                    int i = 0;
                                    while (i < GroupsArrArr.Length)
                                    {
                                        if (ViewFieldNameArr[internalloopcounter] == GroupsArrArr[i])
                                        {
                                            if (FieldTypeArr[internalloopcounter].ToUpper() == "DATETIME" || FieldTypeArr[internalloopcounter].ToUpper() == "DATE")
                                                DtpArr[internalloopcounter].Enabled = false;
                                            if (FieldTypeArr[internalloopcounter].ToUpper() == "INT" || FieldTypeArr[internalloopcounter].ToUpper() == "DECIMAL")
                                                TxtBoxArr[internalloopcounter].Enabled = false;
                                            if (FieldTypeArr[internalloopcounter].ToUpper() == "CHAR" || (FieldTypeArr[internalloopcounter].ToUpper() == "VARCHAR") && Convert.ToInt16(FieldLengthArr[internalloopcounter]) < 5)
                                                DataCmbArr[internalloopcounter].Enabled = false;
                                            if (EnableGrpControlArr[internalloopcounter] == "")
                                                EnableGrpControlArr[internalloopcounter] = "," + Convert.ToString(ArrSeq) + ",";
                                            else
                                                EnableGrpControlArr[internalloopcounter] = EnableGrpControlArr[internalloopcounter] + "," + Convert.ToString(ArrSeq) + ",";
                                        }
                                        i++;
                                    }
                                }
                                internalloopcounter++;
                            }
                        }
                        loopcounter++;
                    }
                }
            }
            else
            {
                if (Groups.Contains(ViewFieldNameArr[ArrSeq] + "|") == true
                    || Groups.Contains(ViewFieldNameArr[ArrSeq] + ",") == true)
                {
                    string[] GroupsArr = Groups.Split('|');
                    int loopcounter = 0;
                    while (loopcounter < GroupsArr.Length)
                    {
                        GroupsArr[loopcounter] = GroupsArr[loopcounter] + ",";
                        if (GroupsArr[loopcounter].Contains(ViewFieldNameArr[ArrSeq] + ",") == true)
                        {
                            string[] GroupsArrArr = GroupsArr[loopcounter].Split(',');
                            int internalloopcounter = 0;
                            while (internalloopcounter < FieldNamesArr.Length)
                            {
                                if (internalloopcounter != ArrSeq)
                                {
                                    int i = 0;
                                    while (i < GroupsArrArr.Length)
                                    {
                                        if (ViewFieldNameArr[internalloopcounter] == GroupsArrArr[i])
                                        {
                                            EnableGrpControlArr[internalloopcounter] = EnableGrpControlArr[internalloopcounter].Replace("," + Convert.ToString(ArrSeq), "");
                                            if (EnableGrpControlArr[internalloopcounter].Replace(",", "") == "")
                                            {
                                                if (FieldTypeArr[internalloopcounter].ToUpper() == "DATETIME" || FieldTypeArr[internalloopcounter].ToUpper() == "DATE")
                                                    DtpArr[internalloopcounter].Enabled = true;
                                                if (FieldTypeArr[internalloopcounter].ToUpper() == "INT" || FieldTypeArr[internalloopcounter].ToUpper() == "DECIMAL")
                                                    TxtBoxArr[internalloopcounter].Enabled = true;
                                                if (FieldTypeArr[internalloopcounter].ToUpper() == "CHAR" || (FieldTypeArr[internalloopcounter].ToUpper() == "VARCHAR") && Convert.ToInt16(FieldLengthArr[internalloopcounter]) < 5)
                                                    DataCmbArr[internalloopcounter].Enabled = true;
                                            }
                                        }
                                        i++;
                                    }
                                }
                                internalloopcounter++;
                            }
                        }
                        loopcounter++;
                    }
                }
            }
        }

        private void CmbTextChanged(object sender, EventArgs e)
        {
            ComboBox CmbBoxTemp = (ComboBox)sender;
            int ArrSeq = CmbBoxTemp.TabIndex;
            CommFunc.AutoFill(CmbBoxTemp, FieldTableNameArr[ArrSeq], FieldNamesArr[ArrSeq], KeyPressedEvent);
            if (CmbBoxTemp.Text != "")
            {
                if (Groups.Contains(ViewFieldNameArr[ArrSeq] + "|") == true
                    || Groups.Contains(ViewFieldNameArr[ArrSeq] + ",") == true)
                {
                    string[] GroupsArr = Groups.Split('|');
                    int loopcounter = 0;
                    while (loopcounter < GroupsArr.Length)
                    {
                        GroupsArr[loopcounter] = GroupsArr[loopcounter] + ",";
                        if (GroupsArr[loopcounter].Contains(ViewFieldNameArr[ArrSeq] + ",") == true)
                        {
                            string[] GroupsArrArr = GroupsArr[loopcounter].Split(',');
                            int internalloopcounter = 0;
                            while (internalloopcounter < FieldNamesArr.Length)
                            {
                                if (internalloopcounter != ArrSeq)
                                {
                                    int i = 0;
                                    while (i < GroupsArrArr.Length)
                                    {
                                        if (ViewFieldNameArr[internalloopcounter] == GroupsArrArr[i])
                                        {
                                            if (FieldTypeArr[internalloopcounter].ToUpper() == "DATETIME" || FieldTypeArr[internalloopcounter].ToUpper() == "DATE")
                                                DtpArr[internalloopcounter].Enabled = false;
                                            if (FieldTypeArr[internalloopcounter].ToUpper() == "INT" || FieldTypeArr[internalloopcounter].ToUpper() == "DECIMAL")
                                                TxtBoxArr[internalloopcounter].Enabled = false;
                                            if (FieldTypeArr[internalloopcounter].ToUpper() == "CHAR" || (FieldTypeArr[internalloopcounter].ToUpper() == "VARCHAR") && Convert.ToInt16(FieldLengthArr[internalloopcounter]) < 5)
                                                DataCmbArr[internalloopcounter].Enabled = false;
                                            if (EnableGrpControlArr[internalloopcounter] == "")
                                                EnableGrpControlArr[internalloopcounter] = "," + Convert.ToString(ArrSeq) + ",";
                                            else
                                                EnableGrpControlArr[internalloopcounter] = EnableGrpControlArr[internalloopcounter] + "," + Convert.ToString(ArrSeq) + ",";
                                        }
                                        i++;
                                    }
                                }
                                internalloopcounter++;
                            }
                        }
                        loopcounter++;
                    }
                }
            }
            else
            {
                if (Groups.Contains(ViewFieldNameArr[ArrSeq] + "|") == true
                    || Groups.Contains(ViewFieldNameArr[ArrSeq] + ",") == true)
                {
                    string[] GroupsArr = Groups.Split('|');
                    int loopcounter = 0;
                    while (loopcounter < GroupsArr.Length)
                    {
                        GroupsArr[loopcounter] = GroupsArr[loopcounter] + ",";
                        if (GroupsArr[loopcounter].Contains(ViewFieldNameArr[ArrSeq] + ",") == true)
                        {
                            string[] GroupsArrArr = GroupsArr[loopcounter].Split(',');
                            int internalloopcounter = 0;
                            while (internalloopcounter < FieldNamesArr.Length)
                            {
                                if (internalloopcounter != ArrSeq)
                                {
                                    int i = 0;
                                    while (i < GroupsArrArr.Length)
                                    {
                                        if (ViewFieldNameArr[internalloopcounter] == GroupsArrArr[i])
                                        {
                                            EnableGrpControlArr[internalloopcounter] = EnableGrpControlArr[internalloopcounter].Replace("," + Convert.ToString(ArrSeq), "");
                                            if (EnableGrpControlArr[internalloopcounter].Replace(",", "") == "")
                                            {
                                                if (FieldTypeArr[internalloopcounter].ToUpper() == "DATETIME" || FieldTypeArr[internalloopcounter].ToUpper() == "DATE")
                                                    DtpArr[internalloopcounter].Enabled = true;
                                                if (FieldTypeArr[internalloopcounter].ToUpper() == "INT" || FieldTypeArr[internalloopcounter].ToUpper() == "DECIMAL")
                                                    TxtBoxArr[internalloopcounter].Enabled = true;
                                                if (FieldTypeArr[internalloopcounter].ToUpper() == "CHAR" || (FieldTypeArr[internalloopcounter].ToUpper() == "VARCHAR") && Convert.ToInt16(FieldLengthArr[internalloopcounter]) < 5)
                                                    DataCmbArr[internalloopcounter].Enabled = true;
                                            }
                                        }
                                        i++;
                                    }
                                }
                                internalloopcounter++;
                            }
                        }
                        loopcounter++;
                    }
                }
            }
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            KeyPressedEvent = e;
        }

        public void SetFrmColor(Color Clr)
        {
            this.BackColor = Clr;
        }

        private string JoinOnKeyFields()
        {
            string QJoinKey = "";
            string ResultDim = "";
            string ResultFact = "";
            string[] TableNameArr = TableNames.Split('|');
            int loopcounter = 0;
            while (loopcounter < TableNameArr.Length)
            {
                if (TableNameArr[loopcounter].ToUpper().Contains("DIM"))
                {
                    if (ResultDim == "")
                        ResultDim = CommFunc.select_table("AllFieldsDimension", "TableName|FieldName", "TableName="
                            + TableNameArr[loopcounter] + "|" + "KeyFieldInd=Y");
                    else
                        ResultDim = ResultDim + "#" + CommFunc.select_table("AllFieldsDimension", "TableName|FieldName",
                        "TableName=" + TableNameArr[loopcounter] + "|" + "KeyFieldInd=Y");
                }
                else
                {
                    if (ResultFact == "")
                        ResultFact = CommFunc.select_table("AllFieldsDimension", "TableName|FieldName", "TableName="
                            + TableNameArr[loopcounter] + "|" + "KeyFieldInd=Y");
                    else
                        ResultFact = ResultFact + "#" + CommFunc.select_table("AllFieldsDimension", "TableName|FieldName",
                        "TableName=" + TableNameArr[loopcounter] + "|" + "KeyFieldInd=Y");
                }
                loopcounter++;
            }
            string[] FactFields = ResultFact.Replace('|', '.').Split('#');
            string[] DimFields = ResultDim.Replace('|', '.').Split('#');
            loopcounter = 0;
            while (loopcounter < FactFields.Length && FactFields[loopcounter] != "")
            {
                int i = 0;
                while (i < DimFields.Length)
                {
                    if (FactFields[loopcounter].Split('.')[1] == DimFields[i].Split('.')[1])
                        if (QJoinKey == "")
                            QJoinKey = FactFields[loopcounter] + "==" + DimFields[i];
                        else
                            QJoinKey = QJoinKey + "|" + FactFields[loopcounter] + "==" + DimFields[i];
                    i++;
                }
                loopcounter++;
            }
            if (QJoinKey != "")
                QJoinKey = "|" + QJoinKey;
            return QJoinKey;
        }

        private string SelectedCriterias()
        {
            int loopcounter = 0;
            string SelectedCriteria = "";
            while (loopcounter < FieldNamesArr.Length)
            {
                if (FieldTypeArr[loopcounter].ToUpper() == "DATETIME" || FieldTypeArr[loopcounter].ToUpper() == "DATE")
                {
                    if (DtpArr[loopcounter].Enabled == true && DtpArr[loopcounter].Text != "")
                    {
                        if (SelectedCriteria == "")
                            SelectedCriteria = FieldTableNameArr[loopcounter] + "." + FieldNamesArr[loopcounter]
                                + OptionCmbArr[loopcounter].Text + DtpArr[loopcounter].Value.ToString("yyyy-MM-dd");
                        else
                            SelectedCriteria = SelectedCriteria + "|" + FieldTableNameArr[loopcounter] + "."
                                + FieldNamesArr[loopcounter] + OptionCmbArr[loopcounter].Text
                                + DtpArr[loopcounter].Value.ToString("yyyy-MM-dd");
                    }
                }
                else if (FieldTypeArr[loopcounter].ToUpper() == "INT" || FieldTypeArr[loopcounter].ToUpper() == "DECIMAL")
                {
                    if (TxtBoxArr[loopcounter].Enabled == true && TxtBoxArr[loopcounter].Text != "")
                    {
                        if (SelectedCriteria == "")
                            SelectedCriteria = FieldTableNameArr[loopcounter] + "." + FieldNamesArr[loopcounter]
                                + OptionCmbArr[loopcounter].Text + TxtBoxArr[loopcounter].Text;
                        else
                            SelectedCriteria = SelectedCriteria + "|" + FieldTableNameArr[loopcounter] + "."
                                + FieldNamesArr[loopcounter] + OptionCmbArr[loopcounter].Text + TxtBoxArr[loopcounter].Text;
                    }
                }
                else
                {
                    if (DataCmbArr[loopcounter].Enabled == true && DataCmbArr[loopcounter].Text != "")
                    {
                        string Option = "";
                        if (OptionCmbArr[loopcounter].Text == "Like")
                            Option = " like '%" + DataCmbArr[loopcounter].Text + "%'";
                        else if (OptionCmbArr[loopcounter].Text == "Startwith")
                            Option = " like '" + DataCmbArr[loopcounter].Text + "%'";
                        else if (OptionCmbArr[loopcounter].Text == "Endwith")
                            Option = " like '%" + DataCmbArr[loopcounter].Text + "'";
                        else
                            Option = "=" + DataCmbArr[loopcounter].Text;
                        if (SelectedCriteria == "")
                            SelectedCriteria = FieldTableNameArr[loopcounter] + "." + FieldNamesArr[loopcounter]
                                + Option;
                        else
                            SelectedCriteria = SelectedCriteria + "|" + FieldTableNameArr[loopcounter] + "."
                                + FieldNamesArr[loopcounter] + Option;
                    }
                }
                loopcounter++;
            }
            return SelectedCriteria;
        }

        private string SelectFields()
        {
            string SelectFields = "";
            int loopcounter = 0;
            while (loopcounter < DisplayFieldNamesArr.Length)
            {
                if (FreezedFields.Contains(DisplayViewFieldNameArr[loopcounter] + "=") == false)
                {
                    if (SelectFields == "")
                        SelectFields = DisplayFieldTableNameArr[loopcounter] + "." + DisplayFieldNamesArr[loopcounter];
                    else
                        SelectFields = SelectFields + "|" + DisplayFieldTableNameArr[loopcounter] + "."
                            + DisplayFieldNamesArr[loopcounter];
                }
                loopcounter++;
            }
            return SelectFields;
        }

        private void BuildQueryAndFillDGV(object sender, EventArgs e)
        {
            DGVResult.Rows.Clear();
            string VarSelectedCriterias = SelectedCriterias();
            string JoinonKeys = JoinOnKeyFields();
            string VarSelectFields = SelectFields();
            VarSelectFields = VarSelectFields.Replace("DateAllDim.Date1", "DD-MM-YYYY~DateAllDim.Date1");
            string SelectTables = TableNames.Replace('|', ',');
            string Result = CommFunc.select_table(SelectTables, VarSelectFields, VarSelectedCriterias + JoinonKeys);
            Boolean NoRecords = false;
            if (Result == "")
            {
                NoRecords = true;
                FinalTxtbox.Text = "";
                MessageBox.Show("There are no records matching this criteria.", "", MessageBoxButtons.OK);
            }
            else
            {
                int loopcounter = 0;
                while (loopcounter < Result.Split('#').Length)
                {
                    DGVResult.Rows.Add(Result.Split('#')[loopcounter].Split('|'));
                    loopcounter++;
                }
            }
            DGVResult.AllowUserToAddRows = false;
            FinalTxtbox.Text = "";
            if (Calculations != "" && NoRecords == false)
            {
                int i = 0;
                while (i < Calculations.Split(',').Length)
                {
                    if (Calculations.Split(',')[i].ToUpper().Contains("MIN(") == true)
                    {
                        string FuncName = Calculations.Split(',')[i].Split('(')[0];
                        string MinFieldName = Calculations.Split(',')[i].Replace(FuncName + "(", "").Replace(")", "");
                        string ColumnHeader = DGVResult.Columns[MinFieldName].HeaderText;
                        int j = 0;
                        decimal MinVal = 0;
                        while (j < DGVResult.Rows.Count)
                        {
                            decimal Val = Convert.ToDecimal(DGVResult[MinFieldName, j].Value.ToString());
                            if (j == 0)
                                MinVal = Val;
                            if (Val < MinVal)
                                MinVal = Val;
                            j++;
                        }
                        FinalTxtbox.Text = FinalTxtbox.Text + "  Min " + ColumnHeader + " = " + Convert.ToString(MinVal);
                    }
                    if (Calculations.Split(',')[i].ToUpper().Contains("MAX(") == true)
                    {
                        string FuncName = Calculations.Split(',')[i].Split('(')[0];
                        string MaxFieldName = Calculations.Split(',')[i].Replace(FuncName + "(", "").Replace(")", "");
                        string ColumnHeader = DGVResult.Columns[MaxFieldName].HeaderText;
                        int j = 0;
                        decimal MaxVal = 0;
                        while (j < DGVResult.Rows.Count)
                        {
                            decimal Val = Convert.ToDecimal(DGVResult[MaxFieldName, j].Value.ToString());
                            if (Val > MaxVal)
                                MaxVal = Val;
                            j++;
                        }
                        FinalTxtbox.Text = FinalTxtbox.Text + "  Max " + ColumnHeader + " = " + Convert.ToString(MaxVal);
                    }
                    if (Calculations.Split(',')[i].ToUpper().Contains("AVG(") == true)
                    {
                        string FuncName = Calculations.Split(',')[i].Split('(')[0];
                        string AvgFieldName = Calculations.Split(',')[i].Replace(FuncName + "(", "").Replace(")", "");
                        string ColumnHeader = DGVResult.Columns[AvgFieldName].HeaderText;
                        int j = 0;
                        decimal AvgVal = 0;
                        while (j < DGVResult.Rows.Count)
                        {
                            decimal Val = Convert.ToDecimal(DGVResult[AvgFieldName, j].Value.ToString());
                            AvgVal = AvgVal + Val;
                            j++;
                        }
                        AvgVal = Decimal.Round(AvgVal / j, 2);
                        FinalTxtbox.Text = FinalTxtbox.Text + "  Average " + ColumnHeader + " = " + Convert.ToString(AvgVal);
                    }
                    if (Calculations.Split(',')[i].ToUpper().Contains("PRODUCT(") == true)
                    {
                        string FuncName = Calculations.Split(',')[i].Split('(')[0];
                        string AvgFieldName = Calculations.Split(',')[i].Replace(FuncName + "(", "").Replace(")", "");
                        string ColumnHeader = DGVResult.Columns[AvgFieldName].HeaderText;
                        int j = 0;
                        decimal ProductVal = 0;
                        while (j < DGVResult.Rows.Count)
                        {
                            decimal Val = Convert.ToDecimal(DGVResult[AvgFieldName, j].Value.ToString());
                            if (j == 0)
                                ProductVal = 1;
                            ProductVal = ProductVal * Val;
                            j++;
                        }
                        ProductVal = Decimal.Round(ProductVal, 2);
                        FinalTxtbox.Text = FinalTxtbox.Text + "  Product of " + ColumnHeader + " = " + Convert.ToString(ProductVal);
                    }
                    if (Calculations.Split(',')[i].ToUpper().Contains("COUNT(") == true)
                    {
                        string FuncName = Calculations.Split(',')[i].Split('(')[0];
                        string AvgFieldName = Calculations.Split(',')[i].Replace(FuncName + "(", "").Replace(")", "");
                        string ColumnHeader = DGVResult.Columns[AvgFieldName].HeaderText;
                        int j = 0;
                        while (j < DGVResult.Rows.Count)
                        {
                            j++;
                        }
                        FinalTxtbox.Text = FinalTxtbox.Text + "  Count of rows = " + Convert.ToString(j);
                    }
                    if (Calculations.Split(',')[i].ToUpper().Contains("TOTAL(") == true)
                    {
                        string FuncName = Calculations.Split(',')[i].Split('(')[0];
                        string TotFieldName = Calculations.Split(',')[i].Replace(FuncName + "(", "").Replace(")", "");
                        string ColumnHeader = DGVResult.Columns[TotFieldName].HeaderText;
                        int j = 0;
                        decimal TotVal = 0;
                        while (j < DGVResult.Rows.Count)
                        {
                            decimal Val = Convert.ToDecimal(DGVResult[TotFieldName, j].Value.ToString());
                            TotVal = TotVal + Val;
                            j++;
                        }
                        FinalTxtbox.Text = FinalTxtbox.Text + "  Total " + ColumnHeader + " = " + Convert.ToString(TotVal);
                    }
                    i++;
                }
            }
            TextBox TxtTemp = new TextBox();
            FinalTxtbox.Font = new Font(TxtTemp.Font, FontStyle.Bold);
        }

        private void FrmClose(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
