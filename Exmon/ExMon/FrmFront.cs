using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace ExMon
{
    public partial class FrmFront : Form
    {
        public FrmFront()
        {
            InitializeComponent();
        }

        SqlConnection SqlCon = DBConnectionMgr.GetCon(true);
        CommonFunctions CommFunc = new CommonFunctions();
        SqlCommand cmd;
        SqlDataReader Rdr;
        string strQ = "";
        Boolean TrvFilterMouseDown = false;
        Boolean TrvFilterMouseHover = false;

        Boolean FromLoad = false;
        string SelectedAccount = "";
        string SelectedTransactionType = "";
        string TranTypeWhereClause = "", AccountWhereClause = "";
        string SelectedDesc, SelectedCategory, SelectedHier;

        public void FrmFront_Load(object sender, EventArgs e)
        {
            TrvAccounts.Nodes.Clear();
            TrvFilters.Nodes.Clear();
            this.BackColor = Color.LightBlue;
            TrvFilters.Font = new Font("Comic Sans MS", 10, FontStyle.Regular);
            TrvAccounts.Font = new Font("Comic Sans MS", 10, FontStyle.Regular);
            TransactionTypeTree_load();
            AccountsTree_load();
            TrvAccounts.SelectedNode = null;
            TrvFilters.SelectedNode = null;
            DtpDate.Select();
            Fill_DGVTransactions();
            Fill_DGVCategory();
            Fill_DGVHierarchy();
            Fill_DGVTransfers();
        }

        private void TransactionTypeTree_load()
        {
            string Hierarchy = "", Category = "", Description = "";
            string PrevHierarchy = "", PrevCategory = "", PrevDescription = "";
            strQ = "SELECT Hierarchy, Category, Description FROM TransactionTypeDim ORDER BY Hierarchy, Category, Description";
            cmd = new SqlCommand(strQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                TreeNode NodeGrandChild = new TreeNode();
                TreeNode NodeChild = new TreeNode();
                TreeNode NodeParent = new TreeNode();
                while (Rdr.Read())
                {
                    Hierarchy = Rdr["Hierarchy"].ToString();
                    Category = Rdr["Category"].ToString();
                    Description = Rdr["Description"].ToString();
                    if (PrevHierarchy != Hierarchy && PrevHierarchy != "")
                    {
                        NodeChild = new TreeNode(PrevCategory);
                        foreach (TreeNode child in NodeGrandChild.Nodes)
                        {
                            NodeChild.Nodes.Add(child.Text);
                        }
                        NodeGrandChild = new TreeNode();
                        if (NodeParent.Nodes.Count == 0)
                            NodeParent = new TreeNode(PrevHierarchy);
                        NodeParent.Nodes.Add(NodeChild);
                        TrvFilters.Nodes.Add(NodeParent);
                        NodeParent = new TreeNode();
                        NodeChild = new TreeNode();
                    }
                    else
                    {
                        if (PrevCategory != Category && PrevCategory != "")
                        {
                            NodeChild = new TreeNode(PrevCategory);
                            foreach (TreeNode child in NodeGrandChild.Nodes)
                            {
                                NodeChild.Nodes.Add(child.Text);
                            }
                            NodeGrandChild = new TreeNode();
                            if (NodeParent.Nodes.Count == 0)
                                NodeParent = new TreeNode(PrevHierarchy);
                            NodeParent.Nodes.Add(NodeChild);
                            NodeChild = new TreeNode();
                        }
                    }
                    NodeGrandChild.Nodes.Add(Description);
                    PrevHierarchy = Hierarchy;
                    PrevCategory = Category;
                    PrevDescription = Description;
                }
                if (NodeChild.Nodes.Count == 0)
                {
                    NodeChild = new TreeNode(PrevCategory);
                    foreach (TreeNode child in NodeGrandChild.Nodes)
                    {
                        NodeChild.Nodes.Add(child.Text);
                    }
                    if (NodeParent.Nodes.Count == 0)
                        NodeParent = new TreeNode(PrevHierarchy);
                    NodeParent.Nodes.Add(NodeChild);
                }
                else
                {
                    NodeChild = new TreeNode(PrevCategory);
                    foreach (TreeNode child in NodeGrandChild.Nodes)
                    {
                        NodeChild.Nodes.Add(child.Text);
                    }
                    NodeParent.Nodes.Add(NodeChild);
                }
                TrvFilters.Nodes.Add(NodeParent);
            }
            Rdr.Close();
            FromLoad = true;
        }

        private void AccountsTree_load()
        {
            string AccountDesc = "", AccountType = "";
            string PrevAccountDesc = "", PrevAccountType = "";
            strQ = "SELECT Description, Type FROM AccountDim where StartDate <= '" 
                + DtpDate.Value.ToString("yyyy/MM/dd") + "' and EndDate >= '"
                + DtpDate.Value.ToString("yyyy/MM/dd") + "' ORDER BY Description, Type";
            cmd = new SqlCommand(strQ, SqlCon);
            Rdr = cmd.ExecuteReader();
            if (Rdr.HasRows == true)
            {
                TreeNode NodeChild = new TreeNode();
                TreeNode NodeParent = new TreeNode();
                while (Rdr.Read())
                {
                    AccountDesc = Rdr["Description"].ToString();
                    AccountType = Rdr["Type"].ToString();
                    if (PrevAccountDesc != AccountDesc && PrevAccountDesc != "")
                    {
                        NodeParent = new TreeNode(PrevAccountDesc);
                        foreach (TreeNode child in NodeChild.Nodes)
                        {
                            NodeParent.Nodes.Add(child.Text);
                        }
                        TrvAccounts.Nodes.Add(NodeParent);
                        NodeChild = new TreeNode();
                        NodeParent = new TreeNode();
                    }
                    NodeChild.Nodes.Add(AccountType);
                    PrevAccountDesc = AccountDesc;
                    PrevAccountType = AccountType;
                }
                if (NodeParent.Nodes.Count == 0)
                    NodeParent = new TreeNode(PrevAccountDesc);
                foreach (TreeNode child in NodeChild.Nodes)
                {
                    NodeParent.Nodes.Add(child.Text);
                }
                TrvAccounts.Nodes.Add(NodeParent);
            }
            Rdr.Close();
            FromLoad = true;
        }

        private void TrvFilters_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int NodeCount = TrvFilters.SelectedNode.FullPath.Replace("\\", "|").Split('|').Count();
            SelectedTransactionType = TrvFilters.SelectedNode.FullPath.Replace("\\", "|");
            TrvFilters.SelectedNode.BackColor = SystemColors.Highlight;
            TrvFilters.SelectedNode.ForeColor = SystemColors.HighlightText;
            if (NodeCount == 3)
                SelectedDesc = SelectedTransactionType.Split('|')[2];
            else
                SelectedDesc = "";
            if (NodeCount >= 2)
                SelectedCategory = SelectedTransactionType.Split('|')[1];
            else
                SelectedCategory = "";
            if (NodeCount >= 1)
                SelectedHier = SelectedTransactionType.Split('|')[0];
            else
                SelectedHier = "";
            if (SelectedHier != "")
            {
                TranTypeWhereClause = TranTypeWhereClause + " AND TransactionTypeDimHierarchy = '" + SelectedHier + "'";
                if (SelectedCategory != "")
                    TranTypeWhereClause = TranTypeWhereClause + " AND TransactionTypeDimCategory = '" + SelectedCategory + "'";
                if (SelectedDesc != "")
                    TranTypeWhereClause = TranTypeWhereClause + " AND TransactionTypeDimDescription = '" + SelectedDesc + "'";
            }
            else
                TranTypeWhereClause = "";
            Fill_DGVTransactions();
            Fill_DGVCategory();
            Fill_DGVHierarchy();
        }

        private void TrvFilters_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TrvFilters.SelectedNode.BackColor = Color.White;
            TrvFilters.SelectedNode.ForeColor = Color.Black;
        }

        private void TrvAccounts_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TrvAccounts.SelectedNode.BackColor = Color.White;
            TrvAccounts.SelectedNode.ForeColor = Color.Black;
        }

        private void TrvFilters_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                e.Node.Expand();
            }
        }

        private void TrvFilters_Click(object sender, EventArgs e)
        {
            if (SelectedTransactionType != "" && TrvFilters.GetNodeAt(Cursor.Position) == null)
            {
                TrvFilters.SelectedNode.BackColor = Color.White;
                TrvFilters.SelectedNode.ForeColor = Color.Black;
                //TrvFilters.CollapseAll();
                TrvFilters.SelectedNode = null;
                SelectedTransactionType = "";
                TranTypeWhereClause = "";
                Fill_DGVTransactions();
                Fill_DGVCategory();
                Fill_DGVHierarchy();
            }
        }

        private void TrvFilters_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedTransactionType != "" && TrvFilters.GetNodeAt(e.Location) == null && TrvFilters.SelectedNode != null)
            {
                TrvFilters.SelectedNode.BackColor = Color.White;
                TrvFilters.SelectedNode.ForeColor = Color.Black;
                TrvFilters.CollapseAll();
                TrvFilters.SelectedNode = null;
                SelectedTransactionType = "";
                TranTypeWhereClause = "";
                Fill_DGVTransactions();
                Fill_DGVCategory();
                Fill_DGVHierarchy();
            }
            else if (TrvFilters.GetNodeAt(e.Location) == null && TrvFilters.SelectedNode == null)
                TrvFilters.CollapseAll();
        }

        private void TrvAccounts_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            e.Node.ExpandAll();
        }

        private void TrvAccounts_Click(object sender, EventArgs e)
        {
            if (SelectedAccount != "" && TrvAccounts.GetNodeAt(Cursor.Position) == null)
            {
                TrvAccounts.SelectedNode.BackColor = Color.White;
                TrvAccounts.SelectedNode.ForeColor = Color.Black;
                TrvAccounts.CollapseAll();
                TrvAccounts.SelectedNode = null;
                SelectedAccount = "";
                AccountWhereClause = "";
                Fill_DGVTransactions();
                Fill_DGVCategory();
                Fill_DGVHierarchy();
            }
        }

        private void TrvAccounts_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedAccount != "" && TrvAccounts.GetNodeAt(e.Location) == null)
            {
                TrvAccounts.SelectedNode.BackColor = Color.White;
                TrvAccounts.SelectedNode.ForeColor = Color.Black;
                TrvAccounts.CollapseAll();
                TrvAccounts.SelectedNode = null;
                SelectedAccount = "";
                AccountWhereClause = "";
                Fill_DGVTransactions();
                Fill_DGVCategory();
                Fill_DGVHierarchy();
            }
        }

        private void Fill_DGVTransactions()
        {
            CommFunc.QueryFactFillDGV("TransactionFact", "DateDim,UserDim,AccountDim,TransactionTypeDim", "Date1 = '"
                + DtpDate.Value.ToString("yyyy/MM/dd") + "'" + TranTypeWhereClause + AccountWhereClause 
                + " AND UserDimUsername = '" + CommonFunctions.UserNm + "'",
                "TransactionFactTransactionId,AccountDimDescription,TransactionTypeDimDescription," 
                + "TransactionTypeDimCategory,TransactionTypeDimHierarchy,TransactionFactAmount", 
                DgvTransactions, Convert.ToDecimal("4.9800001"));
            DgvTransactions.Columns[0].Visible = false;
            Calculate();
            EnableButtons();
        }

        private void Fill_DGVTransfers()
        {
            CommFunc.QueryFactFillDGV("AccountTransferFact", "DateDim,FromAccountDim,ToAccountDim", "Date1 = '"
                + DtpDate.Value.ToString("yyyy/MM/dd") + "'",
                "AccountTransferFactTransactionId,FromAccountDimDescription,FromAccountDimType,ToAccountDimDescription,ToAccountDimType,"
                + "AccountTransferFactAmount", DgvTransfers, Convert.ToDecimal("5.426"));
            DgvTransfers.Columns[0].Visible = false;
        }

        private void Fill_DGVCategory()
        {
            CommFunc.QueryFactFillDGV("TransactionFactView", "DateAllDim,UserDim,AccountDim,TransactionTypeDim", "MonthMM = '"
                + DtpDate.Value.ToString("MM") + "' and YearYYYY = '" + DtpDate.Value.ToString("yyyy") + "'" 
                + TranTypeWhereClause + AccountWhereClause + " AND UserDimUsername = '"
                + CommonFunctions.UserNm + "' group by TransactionTypeDimHierarchy,TransactionTypeDimCategory",
                "TransactionTypeDimHierarchy,TransactionTypeDimCategory," + "SUM(TransactionFactViewNetAmount) AS Amount", DgvCategory, Convert.ToDecimal("4.65"));
        }

        private void Fill_DGVHierarchy()
        {
            CommFunc.QueryFactFillDGV("TransactionFactView", "DateAllDim,UserDim,AccountDim,TransactionTypeDim", "MonthMM = '"
                + DtpDate.Value.ToString("MM") + "' and YearYYYY = '" + DtpDate.Value.ToString("yyyy") + "'" 
                + TranTypeWhereClause + AccountWhereClause + " AND UserDimUsername = '"
                + CommonFunctions.UserNm + "' group by TransactionTypeDimHierarchy",
                "TransactionTypeDimHierarchy," + "SUM(TransactionFactViewNetAmount) AS Amount", 
                DgvHierarchy, Convert.ToDecimal("7.35"));
        }

        private void DtpDate_ValueChanged(object sender, EventArgs e)
        {
            Fill_DGVTransactions();
            Fill_DGVCategory();
            Fill_DGVHierarchy();
            Fill_DGVTransfers();
        }

        private void TrvAccounts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int NodeCount = TrvAccounts.SelectedNode.FullPath.Replace("\\", "|").Split('|').Count();
            SelectedAccount = TrvAccounts.SelectedNode.FullPath.Replace("\\", "|");
            TrvAccounts.SelectedNode.BackColor = SystemColors.Highlight;
            TrvAccounts.SelectedNode.ForeColor = SystemColors.HighlightText;
            string AcctDesc = "", AcctType = "";
            if (NodeCount >= 1)
                AcctDesc = SelectedAccount.Split('|')[0];
            if (NodeCount == 2)
                AcctType = SelectedAccount.Split('|')[1];
            if (AcctDesc != "")
            {
                AccountWhereClause = AccountWhereClause + " AND AccountDimDescription = '" + AcctDesc + "'";
                if (AcctType != "")
                    AccountWhereClause = AccountWhereClause + " AND AccountDimType = '" + AcctType + "'";
            }
            Fill_DGVTransactions();
            Fill_DGVCategory();
            Fill_DGVHierarchy();
        }

        private void Calculate()
        {
            string Calculations = "TOTAL(Amount),MAX(Amount)";
            TxtTotal.Clear();
            if (Calculations != "")
            {
                int i = 0;
                while (i < Calculations.Split(',').Length)
                {
                    if (Calculations.Split(',')[i].ToUpper().Contains("MAX(") == true)
                    {
                        string FuncName = Calculations.Split(',')[i].Split('(')[0];
                        string ColumnHeader = "Amount";
                        int j = 0;
                        decimal MaxVal = 0;
                        while (j < DgvTransactions.Rows.Count)
                        {
                            decimal Val = Convert.ToDecimal(DgvTransactions[5, j].Value.ToString());
                            if (Val > MaxVal)
                                MaxVal = Val;
                            j++;
                        }
                        TxtTotal.Text = TxtTotal.Text + "  Max " + ColumnHeader + " = " + Convert.ToString(MaxVal);
                    }
                    if (Calculations.Split(',')[i].ToUpper().Contains("AVG(") == true)
                    {
                        string FuncName = Calculations.Split(',')[i].Split('(')[0];
                        string ColumnHeader = "Amount";
                        int j = 0;
                        decimal AvgVal = 0;
                        while (j < DgvTransactions.Rows.Count)
                        {
                            decimal Val = Convert.ToDecimal(DgvTransactions[5, j].Value.ToString());
                            AvgVal = AvgVal + Val;                           
                            j++;
                        }
                        AvgVal = AvgVal / j;
                        TxtTotal.Text = TxtTotal.Text + "  Average " + ColumnHeader + " = " + Convert.ToString(AvgVal);
                    }
                    if (Calculations.Split(',')[i].ToUpper().Contains("TOTAL(") == true)
                    {
                        string FuncName = Calculations.Split(',')[i].Split('(')[0];
                        string ColumnHeader = "Amount";
                        int j = 0;
                        decimal TotVal = 0;
                        while (j < DgvTransactions.Rows.Count)
                        {
                            decimal Val = Convert.ToDecimal(DgvTransactions[5, j].Value.ToString());
                            TotVal = TotVal + Val;
                            j++;
                        }
                        TxtTotal.Text = TxtTotal.Text + "  Total " + ColumnHeader + " = " + Convert.ToString(TotVal);
                    }
                    i++;
                }
            }
            TxtTotal.Font = new Font(this.Font, FontStyle.Bold);
            TxtTotal.TextAlign = HorizontalAlignment.Right;
        }

        public void DgvTransactions_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EnableButtons();
        }

        private void EnableButtons()
        {
            Form frm = (Form)this.MdiParent;
            ToolStrip Ts = (ToolStrip)frm.Controls["StrpMdi"];
            ToolStripItemCollection Tsi = (ToolStripItemCollection)Ts.Items;
            if (DgvTransactions.SelectedRows.Count > 0)
            {
                Tsi["toolStripDelete"].Enabled = true;
                Tsi["toolStripAddtoAssests"].Enabled = true;
            }
            else
            {
                Tsi["toolStripDelete"].Enabled = false;
                Tsi["toolStripAddtoAssests"].Enabled = false;
            }
            if (DgvTransfers.SelectedRows.Count > 0 || DgvTransactions.SelectedRows.Count > 0)
            {
                Tsi["toolStripDelete"].Enabled = true;
            }
            else
            {
                Tsi["toolStripDelete"].Enabled = false;
            }
        }

        public void DeleteRecords()
        {
            int i = 0;
            int TransactionNo = 0;
            while (i < DgvTransactions.SelectedRows.Count)
            {
                DgvTransactions.SelectedRows[i].Visible = false;
                TransactionNo = Convert.ToInt16(DgvTransactions.SelectedRows[i].Cells["TransactionFactTransactionId"].Value.ToString());
                CommFunc.delete_table("TransactionFact", "TransactionId=" + Convert.ToString(TransactionNo));
                i++;
            }
            i = 0;
            while (i < DgvTransfers.SelectedRows.Count)
            {
                DgvTransfers.SelectedRows[i].Visible = false;
                TransactionNo = Convert.ToInt16(DgvTransfers.SelectedRows[i].Cells["AccountTransferFactTransactionId"].Value.ToString());
                CommFunc.delete_table("AccountTransferFact", "TransactionId=" + Convert.ToString(TransactionNo));
                i++;
            }
        }

        public void AddToAssets()
        {
            int i = 0;
            int TransactionNo = 0;
            string Hierarchy = "";
            string Category = "";
            string Desc = "";
            while (i < DgvTransactions.SelectedRows.Count)
            {
                TransactionNo = Convert.ToInt16(DgvTransactions.SelectedRows[i].Cells["TransactionFactTransactionId"].Value.ToString());
                Hierarchy = DgvTransactions.SelectedRows[i].Cells["TransactionTypeDimHierarchy"].Value.ToString();
                Category = DgvTransactions.SelectedRows[i].Cells["TransactionTypeDimCategory"].Value.ToString();
                Desc = DgvTransactions.SelectedRows[i].Cells["TransactionTypeDimDescription"].Value.ToString();
                FrmSelectAssetType SelectAssetType = new FrmSelectAssetType(TransactionNo, Hierarchy + "->" + Category 
                    + "->" + Desc);
                SelectAssetType.Font = this.Font;
                SelectAssetType.BackColor = Color.Bisque;
                SelectAssetType.StartPosition = FormStartPosition.CenterScreen;
                SelectAssetType.ShowDialog();
                i++;
            }
        }

        private void DgvTransfers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            EnableButtons();
        }

    }
}
