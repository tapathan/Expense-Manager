using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using Microsoft.Office.Interop;

namespace ExMon
{
    public partial class FrmInitialSetup : Form
    {
        public FrmInitialSetup()
        {
            InitializeComponent();
        }

        SqlConnection SqlCon = DBConnectionMgr.GetCon(true, "InitialSetup");
        string strQ;
        SqlCommand cmd;
        string DBDetailsFilename = "";
        SqlDataReader Rdr;

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog DBDetailsFile = new OpenFileDialog();
            DBDetailsFile.InitialDirectory = @"C:\";
            DBDetailsFile.Title = "Browse DB Details File";
            DBDetailsFile.ShowReadOnly = true;
            DBDetailsFile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (DBDetailsFile.ShowDialog() == DialogResult.OK)
            {
                DBDetailsFilename = DBDetailsFile.FileName;
            }
            Load_File(TransflexViewXls, DBDetailsFilename, "Sheet1");
            BtnCreate.Enabled = true;
        }

        private void Load_File(DataGridView dg, String filename, String SSheet)
        {
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
            try
            {
                OleDbConnection cn = new OleDbConnection(cs);
                if (!System.IO.File.Exists(filename))
                {
                    MessageBox.Show("file not exists");
                }
                OleDbDataAdapter dAdapter = new OleDbDataAdapter("Select * From [" + SSheet + "$]", cs);
                DataSet dts = new DataSet();
                dAdapter.Fill(dts);
                dg.DataSource = dts.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnIns_Click(object sender, EventArgs e)
        {
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            int Row1 = TransflexViewXls.RowCount - 1;
            int Counter = 0;
            string FieldName, FieldType, FieldLength, Alias, KeyFieldInd, NullInd, PrimaryKeyInd;
            string AutoIncreamentInd, TableName, DatabaseName, ViewFieldName, TempField;
            string Display, ControlType, DefaultValues, ImportantFieldInd, ReadOnlyControlInd;
            while (Row1 > 0)
            {
                FieldName = TransflexViewXls["FieldName", Counter].Value.ToString();
                FieldType = TransflexViewXls["FieldType", Counter].Value.ToString();
                TempField = TransflexViewXls["FieldLength", Counter].Value.ToString();
                if (TempField == null)
                    TempField = "";
                FieldLength = TempField;
                Alias = TransflexViewXls["Alias", Counter].Value.ToString();
                KeyFieldInd = TransflexViewXls["KeyFieldInd", Counter].Value.ToString();
                NullInd = TransflexViewXls["NullInd", Counter].Value.ToString();
                PrimaryKeyInd = TransflexViewXls["PrimaryKeyInd", Counter].Value.ToString();
                AutoIncreamentInd = TransflexViewXls["AutoIncreamentInd", Counter].Value.ToString();
                TableName = TransflexViewXls["TableName", Counter].Value.ToString();
                DatabaseName = TransflexViewXls["DatabaseName", Counter].Value.ToString();
                ViewFieldName = TransflexViewXls["ViewFieldName", Counter].Value.ToString();
                Display = TransflexViewXls["Display", Counter].Value.ToString();
                ControlType = TransflexViewXls["ControlType", Counter].Value.ToString();
                DefaultValues = TransflexViewXls["DefaultValues", Counter].Value.ToString();
                ImportantFieldInd = TransflexViewXls["ImportantFieldInd", Counter].Value.ToString();
                ReadOnlyControlInd = TransflexViewXls["ReadOnlyControlInd", Counter].Value.ToString();
                Counter++;
                Row1--;
                strQ = "USE " + DatabaseName + "\nInsert into AllFieldsDimension values('" + FieldName + "','" + FieldType + "','"
                    + FieldLength + "','" + Alias + "','" + KeyFieldInd + "','" + NullInd + "','"
                    + PrimaryKeyInd + "','" + AutoIncreamentInd + "','" + TableName + "','"
                    + DatabaseName + "','" + ViewFieldName + "','" + Display + "','" + ControlType
                    + "','" + DefaultValues + "','" + ImportantFieldInd + "','" + ReadOnlyControlInd + "')";
                cmd = new SqlCommand(strQ, SqlCon);
                cmd.ExecuteNonQuery();
            }
            TransflexViewXls.DataSource = null;
            TransflexViewXls.Rows.Clear();
            TransflexViewXls.Refresh();
            MessageBox.Show("Data Loaded from Excel file to DB.");
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string PrevTableName = "", Query = "", PrimaryKeyFields = "", PrevDBName = "";
            int Row1 = TransflexViewXls.RowCount - 1;
            int Counter = 0;
            CreateDatabases();
            if (SqlCon.State == ConnectionState.Closed)
                SqlCon.Open();
            string FieldName, FieldType, Alias, KeyFieldInd, NullInd, PrimaryKeyInd, FieldLength;
            string AutoIncreamentInd, TableName = "", DatabaseName, ViewFieldName, TempField;
            while (Row1 > 0)
            {
                if (TransflexViewXls["IsAView", Counter].Value.ToString() == "Y")
                {
                    Counter++;
                    Row1--;
                    continue;
                }
                FieldName = TransflexViewXls["FieldName", Counter].Value.ToString();
                FieldType = TransflexViewXls["FieldType", Counter].Value.ToString();
                TempField = TransflexViewXls["FieldLength", Counter].Value.ToString();
                if (TempField == null || TempField == "")
                    TempField = "0";
                FieldLength = Convert.ToString(TempField.Replace('.', ','));
                Alias = TransflexViewXls["Alias", Counter].Value.ToString();
                KeyFieldInd = TransflexViewXls["KeyFieldInd", Counter].Value.ToString();
                NullInd = TransflexViewXls["NullInd", Counter].Value.ToString();
                PrimaryKeyInd = TransflexViewXls["PrimaryKeyInd", Counter].Value.ToString();
                AutoIncreamentInd = TransflexViewXls["AutoIncreamentInd", Counter].Value.ToString();
                TableName = TransflexViewXls["TableName", Counter].Value.ToString();
                DatabaseName = TransflexViewXls["DatabaseName", Counter].Value.ToString();
                ViewFieldName = TransflexViewXls["ViewFieldName", Counter].Value.ToString();
                if (PrevTableName != TableName)
                {
                    if (Counter != 0)
                    {
                        if (PrimaryKeyFields != "")
                        {
                            Query = Query + ", CONSTRAINT " + PrevTableName + "PK PRIMARY KEY(" + PrimaryKeyFields + ")";
                        }
                        Query = Query + ")";
                        strQ = "USE " + DatabaseName + "\n"
                            + "select table_name TN from INFORMATION_SCHEMA.tables where table_name = '" + PrevTableName + "'";
                        cmd = new SqlCommand(strQ, SqlCon);
                        Rdr = cmd.ExecuteReader();
                        if (Rdr.HasRows == true && Rdr.Read() && Rdr["TN"].ToString() == PrevTableName)
                        {
                            Rdr.Close();
                        }
                        else
                        {
                            Rdr.Close();
                            cmd = new SqlCommand(Query, SqlCon);
                            cmd.ExecuteNonQuery();
                        }
                        PrimaryKeyFields = "";
                    }
                    Query = "USE " + DatabaseName + "\n" + "CREATE TABLE " + TableName + "(";
                    PrevTableName = TableName;
                    PrevDBName = DatabaseName;
                }
                else
                {
                    Query = Query + ",";
                }
                FieldType = FieldType.ToUpper();
                Query = Query + FieldName + " " + FieldType;
                if (FieldType != "INT" && FieldType != "DATE" && FieldType != "DATETIME" && FieldType != "CHAR")
                    Query = Query + "(" + FieldLength + ")";
                if (PrimaryKeyInd == "Y")
                {
                    if (PrimaryKeyFields != "")
                        PrimaryKeyFields = PrimaryKeyFields + "," + FieldName;
                    else
                        PrimaryKeyFields = FieldName;
                }
                if (AutoIncreamentInd == "Y")
                    Query = Query + " IDENTITY(1,1) ";
                if (NullInd == "N")
                    Query = Query + " NOT NULL ";
                Counter++;
                Row1--;
            }
            if (PrimaryKeyFields != "")
            {
                Query = Query + ", CONSTRAINT " + PrevTableName + "PK PRIMARY KEY(" + PrimaryKeyFields + ")";
            }
            Query = Query + ")";
            strQ = "USE " + PrevDBName + "\n"
                            + "select table_name TN from INFORMATION_SCHEMA.tables where table_name = '" + PrevTableName + "'";
            cmd = new SqlCommand(strQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true && Rdr.Read() && Rdr["TN"].ToString() == PrevTableName)
            {
                Rdr.Close();
            }
            else
            {
                Rdr.Close();
                cmd = new SqlCommand(Query, SqlCon);
                cmd.ExecuteNonQuery();
            }
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
            BtnIns.Enabled = true;
        }

        private void CreateDatabases()
        {

            int Row1 = TransflexViewXls.RowCount - 1;
            int Counter = 0, UniqDbs_Counter = 0;
            string DatabaseName, Prev_DatabaseName = "", Query = "";
            string[] UniqDbs = new string[100];
            while (Row1 > 0)
            {
                DatabaseName = TransflexViewXls["DatabaseName", Counter].Value.ToString();
                if (DatabaseName != Prev_DatabaseName && DatabaseName != "")
                {
                    UniqDbs[UniqDbs_Counter] = DatabaseName;
                    Prev_DatabaseName = DatabaseName;
                    UniqDbs_Counter++;
                }
                Counter++;
                Row1--;
            }
            while (UniqDbs_Counter > 0)
            {
                Query = "select name from dbo.sysdatabases where name = '" + UniqDbs[UniqDbs_Counter - 1] + "'";
                cmd = new SqlCommand(Query, SqlCon);
                Rdr = cmd.ExecuteReader();
                if (Rdr.HasRows == true && Rdr.Read() && Rdr["name"].ToString() == UniqDbs[UniqDbs_Counter - 1])
                {
                    Rdr.Close();
                    MessageBox.Show("DB " + UniqDbs[UniqDbs_Counter - 1] + " Exists.", "message:", MessageBoxButtons.OK);
                }
                else
                {
                    Rdr.Close();
                    Query = "create database " + UniqDbs[UniqDbs_Counter - 1];
                    cmd = new SqlCommand(Query, SqlCon);
                    cmd.ExecuteNonQuery();
                    // Create AllFieldsDimension
                }
                Query = "USE " + UniqDbs[UniqDbs_Counter - 1] + "\n"
                    + "select table_name TN from INFORMATION_SCHEMA.tables where table_name = 'AllFieldsDimension'";
                cmd = new SqlCommand(Query, SqlCon);
                Rdr = cmd.ExecuteReader();
                if (Rdr.HasRows == true && Rdr.Read() && Rdr["TN"].ToString() == "AllFieldsDimension")
                {
                    Rdr.Close();
                    MessageBox.Show("Table AllFieldsDimension Exists.", "message:", MessageBoxButtons.OK);
                }
                else
                {
                    Rdr.Close();
                    Query = "USE " + UniqDbs[UniqDbs_Counter - 1] + "\n" +
                        "CREATE TABLE [dbo].[AllFieldsDimension](" +
                        "[FieldKey] [int] IDENTITY(1,1) NOT NULL," +
                        "[FieldName] [varchar](50) NULL," +
                        "[FieldType] [varchar](50) NULL," +
                        "[FieldLength] [varchar](50) NULL," +
                        "[Alias] [varchar](50) NULL," +
                        "[KeyFieldInd] [char](1) NULL," +
                        "[NullInd] [char](1) NULL," +
                        "[PrimaryKeyInd] [char](1) NULL," +
                        "[AutoIncreamentInd] [char](1) NULL," +
                        "[TableName] [varchar](50) NULL," +
                        "[DatabaseName] [varchar](50) NULL," +
                        "[ViewFieldName] [varchar](50) NULL," +
                        "[Display] [char](1) NULL," +
                        "[ControlType] [varchar](50) NULL," +
                        "[DefaultValues] [varchar](1000) NULL," +
                        "[ImportantFieldInd] [char](1) NULL," +
                        "[ReadOnlyControlInd] [char](1) NULL" +
                        ") ON [PRIMARY]";
                    cmd = new SqlCommand(Query, SqlCon);
                    cmd.ExecuteNonQuery();
                }
                UniqDbs_Counter--;
            }
            if (SqlCon.State == ConnectionState.Open)
                SqlCon.Close();
            MessageBox.Show("DBs in the Excel sheet created successfully.");
        }

        private void FrmInitialSetup_Load(object sender, EventArgs e)
        {
            BtnCreate.Enabled = false;
            BtnIns.Enabled = false;
        }

    }
}