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
    public partial class FrmUploadXls : Form
    {
        public FrmUploadXls()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();

        string DBDetailsFilename = "";

        private void FrmUploadXls_Load(object sender, EventArgs e)
        {
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
                int Counter = 0;
                while (Counter < DGVXls.Columns.Count)
                {
                    DGVXls.Columns[Counter].Width = (DGVXls.Width - 40) / DGVXls.Columns.Count;
                    Counter++;
                }
                DGVXls.Columns[Counter - 1].Width = DGVXls.Columns[Counter - 1].Width - 1;
                DGVXls.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBrowseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog DBDetailsFile = new OpenFileDialog();
            DBDetailsFile.InitialDirectory = @"C:\";
            DBDetailsFile.Title = "Browse Transactions Xls File";
            DBDetailsFile.ShowReadOnly = true;
            DBDetailsFile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (DBDetailsFile.ShowDialog() == DialogResult.OK)
            {
                DBDetailsFilename = DBDetailsFile.FileName;
            }
            Load_File(DGVXls, DBDetailsFilename, "Sheet1");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            string Date = "";
            string AccountDesc = "";
            string AccountType = "";
            string Hierarchy = "";
            string Category = "";
            string Purpose = "";
            decimal Amount = 0;
            string Comments = "";
            int TransactionId = 0;
            int DateKey = 0;
            int UserKey = CommFunc.FetchKey("UserDim", CommonFunctions.UserNm);
            int TransactionTypeKey = 0;
            int AccountKey = 0;
            int Counter = 0;
            while (Counter < DGVXls.Rows.Count)
            {
                Date = DGVXls[0, Counter].Value.ToString();
                AccountDesc = DGVXls[1, Counter].Value.ToString();
                AccountType = DGVXls[2, Counter].Value.ToString();
                Hierarchy = DGVXls[3, Counter].Value.ToString();
                Category = DGVXls[4, Counter].Value.ToString();
                Purpose = DGVXls[5, Counter].Value.ToString();
                Amount = Convert.ToDecimal(DGVXls[6, Counter].Value.ToString());
                Comments = DGVXls[7, Counter].Value.ToString();
                TransactionId = CommFunc.FetchMaxTransactionNo() + 1;
                try
                {
                    DateKey = CommFunc.FetchKey("DateDim", Date.Replace("/", "-"));
                    AccountKey = CommFunc.FetchKey("AccountDim", AccountDesc + "^" + AccountType);
                    TransactionTypeKey = CommFunc.FetchKey("TransactionTypeDim", Purpose + "^" + Category + "^" + Hierarchy);
                    if (DateKey == 0)
                        MessageBox.Show("ERROR: Invalid Date.\nProblem with row: " + Counter 
                            + "\nPlease correct and submit later.\nSkipping this row....", "Error:", MessageBoxButtons.OK);
                    else if (AccountKey == 0)
                        MessageBox.Show("ERROR: Invalid Account.\nProblem with row: " + Counter
                            + "\nPlease correct and submit later.\nSkipping this row....", "Error:", MessageBoxButtons.OK);
                    else if (TransactionTypeKey == 0)
                        MessageBox.Show("ERROR: Invalid Transaction Purpose.\nProblem with row: " + Counter
                            + "\nPlease correct and submit later.\nSkipping this row....", "Error:", MessageBoxButtons.OK);
                    else 
                        CommFunc.Insert_into_DB(DateKey + "," + UserKey + "," + AccountKey + ","
                            + TransactionTypeKey + "," + TransactionId + "," + Convert.ToDecimal(Amount) + ",'" + Comments
                            + "',NULL,NULL,NULL,NULL,NULL", "TransactionFact");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("ERROR: " + Ex + "\nProblem with row: " + Counter + "\nPlease correct and submit later."
                        + "\nSkipping this row....", "Error:", MessageBoxButtons.OK);
                }
                Counter++;
            }
            DGVXls.DataSource = null;
            DGVXls.Rows.Clear();
            DGVXls.Refresh();
        }

    }
}