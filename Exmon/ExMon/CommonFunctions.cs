using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using ExMon;

namespace ExMon
{

    public class CommonFunctions
    {
        SqlConnection SqlCon = DBConnectionMgr.GetCon(true);
        SqlCommand cmd;
        SqlDataReader Rdr;
        string strQ = "";
        SqlDataAdapter adptr;
        DataTable dt;

        public static string UserNm;
        Boolean TxtChangeEventFlg = false;

        public int FetchMaxKey(string Xcol, string XTblName)
        {
            int MxNo = 1;
            try
            {
                if (SqlCon.State == ConnectionState.Closed)
                    SqlCon.Open();
                strQ = " Select ISNULL(MAX(" + Xcol + "), 0) AS " + Xcol + " FROM " + XTblName + " ";
                cmd = new SqlCommand(strQ, SqlCon);
                Rdr = cmd.ExecuteReader();
                while (Rdr.Read())
                {
                      MxNo = Convert.ToInt32(Rdr[Xcol]) + 1;
                }
                Rdr.Close();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Source + Environment.NewLine + ex.Message, " ERROR ", MessageBoxButtons.OK); 
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return MxNo;
        }

        public int FetchKey(string DimName, string Values)
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            string[] Value = new string[100];
            string[] FieldName = new string[100];
            string WhereClause = "";
            string KeyName = DimName.Replace("Dim", "Key");
            int KeyValue = 0;
            Value = Values.Split('^');
            string DD = "", MM = "", YYYY = "";
            DateTime DT = new DateTime(10000);
            if (DimName == "DateDim")
            {
                DD = Value[0].Split('-')[0];
                MM = Value[0].Split('-')[1];
                YYYY = Value[0].Split('-')[2];
                DT = new DateTime(Convert.ToInt16(YYYY), Convert.ToInt16(MM), Convert.ToInt16(DD));
                Value[0] = YYYY + "-" + MM + "-" + DD;
            }
            string StrQ = "select FieldName FN from AllFieldsDimension where TableName = '" + DimName
                + "' and PrimaryKeyInd = 'Y' and KeyFieldInd != 'Y'";
            cmd = new SqlCommand(StrQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                int Counter = 0;
                while (Rdr.Read())
                {
                    FieldName[Counter] = Rdr["FN"].ToString();
                    if (Counter == 0)
                        WhereClause = FieldName[Counter] + " = '" + Value[Counter] + "'";
                    else
                        WhereClause = WhereClause + " and " + FieldName[Counter] + " = '" + Value[Counter] + "'";
                    Counter++;
                }
                Rdr.Close();
            }
            if (Rdr.IsClosed == false)
                Rdr.Close();
            StrQ = "Select " + KeyName + " KV from " + DimName + " where " + WhereClause;
            cmd = new SqlCommand(StrQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                Rdr.Read();
                KeyValue = Convert.ToInt16(Rdr["KV"]);
            }
            Rdr.Close();

            if (DimName == "DateDim")
            {
                if (KeyValue == 0)
                {
                    PopulateDateDim(DT);
                    if (SqlCon.State == ConnectionState.Closed)
                        SqlCon.Open();
                    StrQ = "select isnull(max(DateKey),0) as DK from DateDim where Date1='" + YYYY + "-" + MM + "-" + DD + "'";
                    cmd = new SqlCommand(StrQ, SqlCon);
                    Rdr = cmd.ExecuteReader();
                    Rdr.Read();
                    KeyValue = Convert.ToInt16(Rdr["DK"]);
                    Rdr.Close();
                }
            }


            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
            return (KeyValue);
        }

        public int FetchMaxTransactionNo()
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();

            int TransactionNo = 0;
            int TempTransactionNo = 0;
            string TableNames = "";
            string StrQ = "select TableName TN from AllFieldsDimension where FieldName = 'TransactionId'";
            cmd = new SqlCommand(StrQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                while (Rdr.Read())
                {
                    if (TableNames == "")
                        TableNames = Convert.ToString(Rdr["TN"]);
                    else
                        TableNames = TableNames + "|" + Convert.ToString(Rdr["TN"]);
                }
            }
            Rdr.Close();
            string[] TableNamesArr = TableNames.Split('|');
            int loopcounter = 0;
            while (loopcounter < TableNamesArr.Length)
            {
                StrQ = "select isnull(max(TransactionId), 0) TN from " + TableNamesArr[loopcounter];
                cmd = new SqlCommand(StrQ, SqlCon);
                Rdr = cmd.ExecuteReader();
                if (Rdr.HasRows == true)
                {
                    Rdr.Read();
                    TempTransactionNo = Convert.ToInt16(Rdr["TN"]);
                    if (TempTransactionNo > TransactionNo)
                        TransactionNo = TempTransactionNo;
                }
                Rdr.Close();
                loopcounter++;
            }
            return TransactionNo;
        }

        public void PopulateDateDim(DateTime dt)
        {
            SqlCommand cmdIns;
            SqlCommand cmdInc;
            TimeSpan TimeSpan1;
            int DtKey, DateKey;
            string StrQInc;
            //DateTime DateFormat;
            int DateDD;
            int MonthMM;
            string MonthMMM;
            int YearYYYY;
            int DayOfWeekNum;
            string DayOfWeekWords, QuarterWords = "";
            char WeekEndInd;
            int QuarterNum;

            char HolidayInd = 'N';
            string Convertddt = dt.ToString("yyyy/MM/dd");
            DateDD = dt.Day;
            DateTime IdealDate = Convert.ToDateTime("01/01/2010");
            if (dt < IdealDate)
            {
                TimeSpan1 = IdealDate - dt;
                DateKey = TimeSpan1.Days;
                DateKey = -(DateKey);
                DateKey--;
            }
            else
            {
                TimeSpan1 = dt - IdealDate;
                DateKey = TimeSpan1.Days;
                DateKey++;
            }

            MonthMM = dt.Month;
            do
            {
                string ConvdtToIns = dt.ToString("yyyy/MM/dd");
                dt.ToString("dd/MM/yyyy");//First variable
                DateDD = dt.Day;
                MonthMM = dt.Month;
                MonthMMM = dt.ToString("MMM");
                YearYYYY = dt.Year;
                //DAY OF WEEK
                DayOfWeekNum = dt.DayOfYear + 5;
                DayOfWeekNum = DayOfWeekNum % 7;
                DayOfWeekWords = dt.DayOfWeek.ToString();
                //WEEK END INDICATOR
                if (DayOfWeekNum == 0 || DayOfWeekNum == 1)
                    WeekEndInd = 'Y';
                else
                    WeekEndInd = 'N';
                //QUARTER
                QuarterNum = MonthMM - 1;
                QuarterNum = QuarterNum / 3;
                QuarterNum = QuarterNum + 1;
                switch (QuarterNum)
                {
                    case 1:
                        QuarterWords = "First";
                        break;
                    case 2:
                        QuarterWords = "Second";
                        break;
                    case 3:
                        QuarterWords = "Third";
                        break;
                    case 4:
                        QuarterWords = "Fourth";
                        break;
                }
                if (SqlCon.State == ConnectionState.Closed)
                    SqlCon.Open();
                string strQIns;
                strQIns = "INSERT INTO DateDim VALUES('" + DateKey + "','" + ConvdtToIns + "','" + DateDD + "','" + MonthMM 
                    + "','" + MonthMMM + "','" + YearYYYY + "','" + DayOfWeekNum + "'," + "'" + DayOfWeekWords + "','" 
                    + QuarterNum + "','" + QuarterWords + "','" + WeekEndInd + "')";
                cmdIns = new SqlCommand(strQIns, SqlCon);
                cmdIns.ExecuteNonQuery();
                DateKey++;
                dt = dt.AddDays(1);
                Convertddt = dt.ToString("yyyy/MM/dd");
                StrQInc = "select isnull(max(DateKey),0) as DTKey from DateDim where Date1='" + Convertddt + "'";
                cmdInc = new SqlCommand(StrQInc, SqlCon);
                Rdr = cmdInc.ExecuteReader();
                Rdr.Read();
                DtKey = Convert.ToInt16(Rdr["DTKey"]);
                Rdr.Close();
                if (DtKey != 0)
                    break;
            } while (DateDD != 31 || MonthMM != 12);
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public void Fill_Combo(ComboBox ComboObj, string Field, string TableName, string FilterClause)
        {
            if (FilterClause != "")
                FilterClause = " where " + FilterClause;
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            ComboObj.Items.Clear();
            strQ = "select distinct(" + Field + ") D from " + TableName + FilterClause;
            cmd = new SqlCommand(strQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                while (Rdr.Read())
                {
                    ComboObj.Items.Add(Convert.ToString(Rdr["D"]));
                }
                Rdr.Close();
            }
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public void Fill_Combo(ComboBox ComboObj, string Field, string TableName, string FilterClause, DateTime Type2Date)
        {
            string Type2DateStr = Type2Date.ToString("yyyy/MM/dd");
            if (FilterClause != "")
                FilterClause = " and " + FilterClause;
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            ComboObj.Items.Clear();
            strQ = "select distinct(" + Field + ") D from " + TableName
                + " where StartDate <= '" + Type2DateStr + "' and EndDate >= '" + Type2DateStr + "'" + FilterClause;
            cmd = new SqlCommand(strQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                while (Rdr.Read())
                {
                    ComboObj.Items.Add(Convert.ToString(Rdr["D"]));
                }
                Rdr.Close();
            }
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public string Fetch_DB_Value(string Field, string TableName, string FilterClause)
        {
            if (FilterClause != "")
                FilterClause = " where " + FilterClause;
            string OutResult = "";
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            strQ = "select " + Field + " D from " + TableName + FilterClause;
            cmd = new SqlCommand(strQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                while (Rdr.Read())
                {
                    if (OutResult == "")
                        OutResult = Convert.ToString(Rdr["D"]);
                    else
                        OutResult = OutResult + "|" + Convert.ToString(Rdr["D"]);
                }
                Rdr.Close();
            }
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
            return OutResult;
        }

        public string Fetch_DB_MultiValue(string FieldsCommaSeperated, string TableName, string FilterClause)
        {
            if (FilterClause != "")
                FilterClause = " where " + FilterClause;
            string OutResult = "";
            string SelectFields = "CAST(" + FieldsCommaSeperated.Replace(",", " AS VARCHAR) + '::' + CAST(") + " AS VARCHAR) ";
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            strQ = "select " + SelectFields + " D from " + TableName + FilterClause;
            cmd = new SqlCommand(strQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                while (Rdr.Read())
                {
                    if (OutResult == "")
                        OutResult = Convert.ToString(Rdr["D"]);
                    else
                        OutResult = OutResult + "|" + Convert.ToString(Rdr["D"]);
                }
                Rdr.Close();
            }
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
            return OutResult;
        }

        public void Insert_into_DB(string ValuesCommaSeperated, string TableName)
        {
            string InsertQuery = "insert into " + TableName + " values (" + ValuesCommaSeperated + ")";
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            cmd = new SqlCommand(InsertQuery, SqlCon);
            cmd.ExecuteNonQuery();
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public void Update_DB(string FieldsWithValueAssigned, string TableName, string UpdtWhereClause)
        {
            if (UpdtWhereClause != "")
                UpdtWhereClause = " where " + UpdtWhereClause;
            string UpdtQuery = "update " + TableName + " set " + FieldsWithValueAssigned + UpdtWhereClause;
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            cmd = new SqlCommand(UpdtQuery, SqlCon);
            cmd.ExecuteNonQuery();
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public void Execute_DB_Command(string Command)
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            try
            {
                cmd = new SqlCommand(Command, SqlCon);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "");
            }
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public void QueryFactFillDGV(string FactTable, string Dimensions, string Filters, string SelectFields, DataGridView OutputDGV, decimal FieldResizeFactor)
        {
            string[] FieldName = new string[200];
            string[] FieldAlias = new string[200];
            string[] FieldType = new string[200];
            string[] FieldLength = new string[200];
            string[] KeyFieldInd = new string[200];
            string[] TableName = new string[200];
            string[] ViewFieldName = new string[200];
            int Counter = 0;
            int NoOfElements = 0;
            string[] SelectFieldsArr = SelectFields.Split(',');
            string SelectFieldNames = "";
            SqlCommand Command;
            SqlDataReader Reader;

            OutputDGV.Rows.Clear();
            OutputDGV.Columns.Clear();
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            string ClauseDimensions = "('" + Dimensions.Replace(",", "','").Trim() + "')";
            string StrQ = "select FieldName FN, Alias FA, FieldType FT, FieldLength FL, KeyFieldInd KFI, TableName TN, ViewFieldName VFN "
                + "from AllFieldsDimension where TableName in " + ClauseDimensions + " or TableName = '" + FactTable + "'";
            Command = new SqlCommand(StrQ, SqlCon);
            try
            {
                Reader = Command.ExecuteReader();
                if (Reader.HasRows == true)
                {
                    while (Reader.Read())
                    {
                        FieldName[Counter] = Reader["FN"].ToString();
                        FieldAlias[Counter] = Reader["FA"].ToString();
                        FieldType[Counter] = Reader["FT"].ToString();
                        FieldLength[Counter] = Reader["FL"].ToString();
                        KeyFieldInd[Counter] = Reader["KFI"].ToString();
                        TableName[Counter] = Reader["TN"].ToString();
                        ViewFieldName[Counter] = Reader["VFN"].ToString();
                        Filters = Filters.Replace(ViewFieldName[Counter], TableName[Counter] + "." + FieldName[Counter]);
                        Counter++;
                    }
                    NoOfElements = Counter;
                }
                if (Filters != "")
                    Filters = " AND " + Filters;
                Reader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            string JoinClause = "";
            while (Counter > 0)
            {
                if (KeyFieldInd[Counter - 1] == "Y" && TableName[Counter - 1] != FactTable)
                {
                    if (JoinClause == "")
                        JoinClause = FactTable + "." + FieldName[Counter - 1] + " = " + TableName[Counter - 1]
                            + "." + FieldName[Counter - 1];
                    else
                        JoinClause = JoinClause + " AND " + FactTable + "." + FieldName[Counter - 1] + " = " + TableName[Counter - 1]
                            + "." + FieldName[Counter - 1];
                }
                Counter--;
            }

            while (Counter < SelectFieldsArr.Count())
            {
                DataGridViewTextBoxCell DGVCell = new DataGridViewTextBoxCell();
                DataGridViewColumn DGVNewCol = new DataGridViewColumn(DGVCell);
                int InterLoopCounter = 0;
                while (InterLoopCounter < NoOfElements)
                {
                    if (ViewFieldName[InterLoopCounter] == SelectFieldsArr[Counter])
                    {
                        DGVNewCol.Name = ViewFieldName[InterLoopCounter];
                        DGVNewCol.HeaderText = FieldAlias[InterLoopCounter];
                        string FieldWidth = FieldLength[InterLoopCounter];
                        if (FieldType[InterLoopCounter].ToUpper() == "DECIMAL")
                            FieldWidth = "18";
                        if (FieldType[InterLoopCounter].ToUpper() == "DATE" 
                            || FieldType[InterLoopCounter].ToUpper() == "DATETIME")
                            FieldWidth = "16";
                        if (FieldType[InterLoopCounter].ToUpper() == "CHAR" || FieldType[InterLoopCounter].ToUpper() == "INT")
                            FieldWidth = "5";
                        if (Convert.ToInt16(FieldWidth) > 25)
                            FieldWidth = "25";
                        DGVNewCol.Width = Convert.ToInt16(Convert.ToDecimal(FieldWidth) * FieldResizeFactor);
                        if (SelectFieldNames == "")
                            SelectFieldNames = TableName[InterLoopCounter] + "." + FieldName[InterLoopCounter];
                        else
                            SelectFieldNames = SelectFieldNames + "," + TableName[InterLoopCounter] + "." + FieldName[InterLoopCounter];
                        break;
                    }
                    InterLoopCounter++;
                }
                if (InterLoopCounter == NoOfElements)
                {
                    InterLoopCounter = 0;
                    string TempFieldAlias = SelectFieldsArr[Counter].Replace(" AS ", "|").Split('|')[1];
                    DGVNewCol.Name = TempFieldAlias;
                    DGVNewCol.HeaderText = TempFieldAlias;
                    DGVNewCol.Width = Convert.ToInt16(18 * FieldResizeFactor);
                    while (InterLoopCounter < NoOfElements)
                    {
                        SelectFieldsArr[Counter] = SelectFieldsArr[Counter].Replace(ViewFieldName[InterLoopCounter], TableName[InterLoopCounter] + "." + FieldName[InterLoopCounter]);
                        InterLoopCounter++;
                    }
                    if (SelectFieldNames == "")
                        SelectFieldNames = SelectFieldsArr[Counter];
                    else
                        SelectFieldNames = SelectFieldNames + "," + SelectFieldsArr[Counter];
                }
                OutputDGV.Columns.Insert(Counter, DGVNewCol);
                Counter++;
            }
            string[] SelectFieldNamesArr = SelectFieldNames.Split(',');
            SelectFieldNames = SelectFieldNames.Replace("DateDim.Date1", 
                "CONVERT(VARCHAR(10),DateDim.Date1 ,105) DateDimDate1");
            SelectFieldNames = SelectFieldNames.Replace("DateAllDim.Date1",
                "CONVERT(VARCHAR(10),DateAllDim.Date1 ,105) DateAllDimDate1");
            StrQ = "select " + SelectFieldNames + " from " + FactTable + ", " + Dimensions + " where " + JoinClause
                + Filters;
            Command = new SqlCommand(StrQ, SqlCon);
            Reader = Command.ExecuteReader();
            int NoOfRows = 0;
            if (Reader.HasRows == true)
            {
                while (Reader.Read())
                {
                    Counter = 0;
                    OutputDGV.Rows.Add();
                    while (Counter < SelectFieldNamesArr.Count())
                    {
                        string Value = Reader[Counter].ToString();
                        OutputDGV[Counter, NoOfRows].Value = Value;
                        Counter++;
                    }
                    NoOfRows++;
                }
            }
            Reader.Close();
            OutputDGV.AllowUserToAddRows = false;
        }

        public void AutoFill(TextBox TxtBox, string TableName, string FieldName, KeyEventArgs KeyDownPress)
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            if (TxtChangeEventFlg == false)
            {
                TxtChangeEventFlg = true;
                string txtValue = TxtBox.Text;
                string SelectedText = TxtBox.SelectedText;
                string Result = "";
                if (SelectedText != "")
                    txtValue = txtValue.Replace(SelectedText, "");
                if (TxtBox.Text != "" && KeyDownPress.KeyCode != Keys.Back)
                {
                    string StrQ = "select " + FieldName + " FN from " + TableName + " where " + FieldName + " like '" + txtValue + "%'"
                        + " order by " + FieldName;
                    cmd = new SqlCommand(StrQ, SqlCon);
                    Rdr = cmd.ExecuteReader();
                    if (Rdr.HasRows == true)
                    {
                        Rdr.Read();
                        Result = Convert.ToString(Rdr["FN"]);
                        TxtBox.Text = Result;
                        int LenOfValue = txtValue.Length;
                        TxtBox.SelectionStart = LenOfValue;
                        TxtBox.SelectionLength = TxtBox.Text.Length - LenOfValue;
                    }
                    Rdr.Close();
                }
                TxtChangeEventFlg = false;
            }
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public void AutoFill(RichTextBox TxtBox, string TableName, string FieldName, KeyEventArgs KeyDownPress)
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            if (TxtChangeEventFlg == false)
            {
                TxtChangeEventFlg = true;
                string txtValue = TxtBox.Text;
                string SelectedText = TxtBox.SelectedText;
                string Result = "";
                if (SelectedText != "")
                    txtValue = txtValue.Replace(SelectedText, "");
                if (TxtBox.Text != "" && KeyDownPress.KeyCode != Keys.Back)
                {
                    string StrQ = "select " + FieldName + " FN from " + TableName + " where " + FieldName + " like '" + txtValue + "%'"
                        + " order by " + FieldName;
                    cmd = new SqlCommand(StrQ, SqlCon);
                    Rdr = cmd.ExecuteReader();
                    if (Rdr.HasRows == true)
                    {
                        Rdr.Read();
                        Result = Convert.ToString(Rdr["FN"]);
                        TxtBox.Text = Result;
                        int LenOfValue = txtValue.Length;
                        TxtBox.SelectionStart = LenOfValue;
                        TxtBox.SelectionLength = TxtBox.Text.Length - LenOfValue;
                    }
                    Rdr.Close();
                }
                TxtChangeEventFlg = false;
            }
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public void AutoFill(ComboBox CmbBox, string TableName, string FieldName, KeyEventArgs KeyDownPress)
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            if (TxtChangeEventFlg == false)
            {
                TxtChangeEventFlg = true;
                string txtValue = CmbBox.Text;
                string SelectedText = CmbBox.SelectedText;
                string Result = "";
                if (SelectedText != "")
                    txtValue = txtValue.Replace(SelectedText, "");
                if (KeyDownPress.KeyCode != Keys.Back && CmbBox.Text != "")
                {
                    string StrQ = "select distinct(" + FieldName + ") FN from " + TableName + " where " + FieldName + " like '" + txtValue + "%'"
                        + " order by " + FieldName;
                    cmd = new SqlCommand(StrQ, SqlCon);
                    Rdr = cmd.ExecuteReader();
                    CmbBox.Items.Clear();
                    if (Rdr.HasRows == true)
                    {
                        int loopcounter = 0;
                        while (Rdr.Read() && loopcounter < 50)
                        {
                            Result = Convert.ToString(Rdr["FN"]);
                            CmbBox.Items.Add(Result);
                            loopcounter++;
                        }
                        CmbBox.SelectedIndex = 0;
                    }
                    int LenOfValue = txtValue.Length;
                    CmbBox.SelectionStart = LenOfValue;
                    CmbBox.SelectionLength = CmbBox.Text.Length - LenOfValue;
                    Rdr.Close();
                }
                TxtChangeEventFlg = false;
            }
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public void update_table(string TableName, string SetValue, string WhereClause)
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();

            string[] SetValuesArr = SetValue.Split('|');
            string[] WhereClauseArr = WhereClause.Split('|');
            string QSetValue = "";
            string QWhereClause = "";
            int loopcounter = 0;
            string FieldName = "";
            while (loopcounter < SetValuesArr.Length)
            {
                FieldName = SetValuesArr[loopcounter].Split('=')[0];
                if (loopcounter == 0)
                    QSetValue = FieldName + " = '" + SetValuesArr[loopcounter].Split('=')[1] + "'";
                else
                    QSetValue = QSetValue + "," + FieldName + " = '" + SetValuesArr[loopcounter].Split('=')[1] + "'";
                loopcounter++;
            }
            loopcounter = 0;
            while (loopcounter < WhereClauseArr.Length)
            {
                FieldName = WhereClauseArr[loopcounter].Split('=')[0];
                if (loopcounter == 0)
                    QWhereClause = FieldName + " = '" + WhereClauseArr[loopcounter].Split('=')[1] + "'";
                else
                    QWhereClause = QWhereClause + " and " + FieldName + " = '" + WhereClauseArr[loopcounter].Split('=')[1] + "'";
                loopcounter++;
            }
            string Query = "update " + TableName + " set " + QSetValue + " where " + QWhereClause;
            SqlCommand cmdUpdt;
            cmdUpdt = new SqlCommand(Query, SqlCon);
            cmdUpdt.ExecuteNonQuery();

            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public void delete_table(string TableName, string WhereClause)
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();

            string[] WhereClauseArr = WhereClause.Split('|');
            string QWhereClause = "";
            int loopcounter = 0;
            string FieldName = "";
            while (loopcounter < WhereClauseArr.Length)
            {
                FieldName = WhereClauseArr[loopcounter].Split('=')[0];
                if (loopcounter == 0)
                    QWhereClause = FieldName + " = '" + WhereClauseArr[loopcounter].Split('=')[1] + "'";
                else
                    QWhereClause = QWhereClause + " and " + FieldName + " = '" + WhereClauseArr[loopcounter].Split('=')[1] + "'";
                loopcounter++;
            }
            string Query = "delete from " + TableName + " where " + QWhereClause;
            SqlCommand cmdUpdt;
            cmdUpdt = new SqlCommand(Query, SqlCon);
            cmdUpdt.ExecuteNonQuery();

            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public string select_table(string TableName, string SelectFields, string WhereClause)
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();

            string[] SelectFieldsArr = SelectFields.Split('|');
            string[] WhereClauseArr = WhereClause.Split('|');
            string QSelectFields = "";
            string QWhereClause = "";
            int loopcounter = 0;
            string FieldName = "";
            while (loopcounter < SelectFieldsArr.Length)
            {
                string Format = "";
                FieldName = SelectFieldsArr[loopcounter].Split('=')[0];
                if (FieldName.Contains('~') == true)
                {
                    Format = FieldName.Split('~')[0];
                    FieldName = FieldName.Split('~')[1];
                }
                if (Format != "" && FieldName.Contains('.') == true)
                {
                    int FormatLen = Format.Length;
                    int FormatCode = 0;
                    if (Format == "DD-MM-YYYY")
                        FormatCode = 105;
                    else if (Format == "DD-MM-YY")
                        FormatCode = 10;
                    else if (Format == "DD MMM YY")
                        FormatCode = 6;
                    else if (Format == "DD MMM YYYY")
                        FormatCode = 106;
                    string ConvertStr = "CONVERT(VARCHAR(" + FormatLen + "),";
                    string ConvertCode = FormatCode + ") ";
                    FieldName = ConvertStr + FieldName + " ," + ConvertCode + FieldName.Replace(".", "").Replace("(", "").Replace(")", "");
                }
                else if (FieldName.Contains('.') == true)
                    FieldName = FieldName + " " + FieldName.Replace(".", "").Replace("(", "").Replace(")", "");
                if (FieldName == "1")
                    FieldName = "1 Constant1";
                if (loopcounter == 0)
                    QSelectFields = FieldName;
                else
                    QSelectFields = QSelectFields + "," + FieldName;
                loopcounter++;
            }
            loopcounter = 0;
            while (loopcounter < WhereClauseArr.Length)
            {
                if (WhereClauseArr[loopcounter].Split('=').Length == 1)
                {
                    if (loopcounter == 0)
                        QWhereClause = WhereClauseArr[loopcounter];
                    else
                        QWhereClause = QWhereClause + " and " + WhereClauseArr[loopcounter];
                }
                else if (WhereClauseArr[loopcounter].Contains("!="))
                {
                    WhereClauseArr[loopcounter] = WhereClauseArr[loopcounter].Replace("!=", "=");
                    FieldName = WhereClauseArr[loopcounter].Split('=')[0];
                    if (loopcounter == 0)
                        QWhereClause = FieldName + " != '" + WhereClauseArr[loopcounter].Split('=')[1] + "'";
                    else
                        QWhereClause = QWhereClause + " and " + FieldName + " != '" + WhereClauseArr[loopcounter].Split('=')[1] + "'";
                }
                else if (WhereClauseArr[loopcounter].Split('=').Length == 3)
                {
                    FieldName = WhereClauseArr[loopcounter].Split('=')[0];
                    if (loopcounter == 0)
                        QWhereClause = FieldName + " = " + WhereClauseArr[loopcounter].Split('=')[2];
                    else
                        QWhereClause = QWhereClause + " and " + FieldName + " = " + WhereClauseArr[loopcounter].Split('=')[2];
                }
                else
                {
                    FieldName = WhereClauseArr[loopcounter].Split('=')[0];
                    if (loopcounter == 0)
                        QWhereClause = FieldName + " = '" + WhereClauseArr[loopcounter].Split('=')[1] + "'";
                    else
                        QWhereClause = QWhereClause + " and " + FieldName + " = '" + WhereClauseArr[loopcounter].Split('=')[1] + "'";
                }
                loopcounter++;
            }
            string Query = "select " + QSelectFields + " from " + TableName + " where " + QWhereClause;
            cmd = new SqlCommand(Query, SqlCon);
            Rdr = cmd.ExecuteReader();
            string Field1 = "";
            string Result = "";
            if (Rdr.HasRows == true)
            {
                while (Rdr.Read())
                {
                    if (Result != "")
                        Result = Result + "#";
                    loopcounter = 0;
                    while (loopcounter < SelectFieldsArr.Length)
                    {
                        Field1 = SelectFieldsArr[loopcounter].Replace(".", "").Replace("(", "").Replace(")", "");
                        if (Field1.Contains('~') == true)
                            Field1 = Field1.Split('~')[1];
                        if (SelectFieldsArr[loopcounter] == "1")
                            Field1 = "Constant1";
                        if (SelectFieldsArr[loopcounter].Split(' ').Length > 1)
                            Field1 = SelectFieldsArr[loopcounter].Split(' ')[1];
                        if (loopcounter == 0)
                            Result = Result + Convert.ToString(Rdr[Field1]);
                        else
                            Result = Result + "|" + Convert.ToString(Rdr[Field1]);
                        loopcounter++;
                    }
                }
                Rdr.Close();
            }

            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();

            return Result;
        }

        public void insert_table(string TableName, string Values)
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();

            SqlCommand cmdIns;
            string StrQ = "select FieldName FN, FieldType FT from AllFieldsDimension where TableName = '" + TableName + "' and AutoIncreamentInd != 'Y'";
            string FieldName = "";
            string FieldType = "";
            string Query = "insert into " + TableName + " values (";
            string Query1 = "";
            string Query2 = "";
            string[] ArrValues = Values.Split('|');
            int count = 0;
            cmd = new SqlCommand(StrQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                while (Rdr.Read())
                {
                    FieldName = Convert.ToString(Rdr["FN"]);
                    FieldType = Convert.ToString(Rdr["FT"]);
                    if (Query1 == "")
                        Query1 = FieldName;
                    else
                        Query1 = Query1 + "," + FieldName;
                    if (Query2 == "")
                        if (FieldType.ToLower() == "varchar" || FieldType.ToLower() == "datetime" || FieldType.ToLower() == "char")
                            Query2 = "'" + ArrValues[count] + "'";
                        else
                            Query2 = ArrValues[count];
                    else
                        if (FieldType.ToLower() == "varchar" || FieldType.ToLower() == "datetime" || FieldType.ToLower() == "char")
                            Query2 = Query2 + ",'" + ArrValues[count] + "'";
                        else
                            Query2 = Query2 + "," + ArrValues[count];
                    count = count + 1;
                }
                Query = Query + Query2 + ")";
            }
            Rdr.Close();
            cmdIns = new SqlCommand(Query, SqlCon);
            cmdIns.ExecuteNonQuery();

            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        public void FillCmbTextChanged(ComboBox XCombo, string XSelectFieldName, string XCriteriaField, string XTableName, string XText)
        {
            try
            {
                if (SqlCon.State == ConnectionState.Closed)
                    SqlCon.Open();
                cmd = new SqlCommand();
                cmd.CommandText = " select distinct(" + XSelectFieldName + ")  XSF From "
                    + XTableName + " where " + XCriteriaField + " like '" + XText + "%'" + " ORDER BY " + XSelectFieldName;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = SqlCon;
                SqlDataReader Rdr = cmd.ExecuteReader();
                XCombo.Items.Clear();
                if (Rdr.HasRows)
                {
                    while (Rdr.Read())
                        XCombo.Items.Add(Convert.ToString(Rdr["XSF"]));
                }
                Rdr.Close();
            }
            catch (Exception ex)
            {
                XCombo.Items.Clear();
                MessageBox.Show(ex.Source + Environment.NewLine
                    + ex.Message, " ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
        }

    }
}
