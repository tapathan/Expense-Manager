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
    public partial class FrmTransactionType : Form
    {
        Boolean EnableSelect = false;
        public FrmTransactionType()
        {
            InitializeComponent();
        }

        public FrmTransactionType(Boolean EnableSelect)
        {
            InitializeComponent();
            this.EnableSelect = EnableSelect;
        }

        SqlConnection SqlCon = DBConnectionMgr.GetCon(true);
        CommonFunctions CommFunc = new CommonFunctions();
        SqlCommand cmd;
        SqlDataReader Rdr;
        string strQ = "";

        string WhereClause = "", UpdateClause = "";
        string SelectedDesc, SelectedCategory, SelectedHier;
        Boolean LabelEdit = false;
        Boolean FromLoad = false;
        int ExcCounter = 0;

        TreeView TrvTransactionType = new TreeView();

        public string ReturnValue1 { get; set; } 

        private void FrmTransactionType_Load(object sender, EventArgs e)
        {
            TrvTransactionType.Width = this.Width - 31;
            TrvTransactionType.Height = this.Height - 165;
            TrvTransactionType.Location = new Point(9, 12);
            TrvTransactionType.LabelEdit = true;
            TrvTransactionType.Font = new Font("Comic Sans MS", 10, FontStyle.Regular);
            TrvTransactionType.AfterSelect += new TreeViewEventHandler(this.TreeView_AfterSelect);
            TrvTransactionType.AfterLabelEdit += new NodeLabelEditEventHandler(this.TreeView_AfterLabelEdit);
            TrvTransactionType.Click += new EventHandler(this.TreeView_Click);
            TrvTransactionType.MouseClick += new MouseEventHandler(this.TreeView_MouseClick);
            //TrvTransactionType.MouseDown += new MouseEventHandler(this.TreeView_MouseClick);
            TrvTransactionType.MouseDoubleClick += new MouseEventHandler(this.BtnSelect_Click);
            this.Controls.Add(TrvTransactionType);
            this.Text = "Transaction Types";
            Button BtnSearch = new Button();
            BtnSearch.Size = new Size(25, TxtSearchTrans.ClientSize.Height + 7);
            BtnSearch.Location = new Point(TxtSearchTrans.ClientSize.Width - BtnSearch.Width, -1);
            BtnSearch.Cursor = Cursors.Default;
            BtnSearch.BackgroundImage = Properties.Resources.IcnSearch.ToBitmap();
            BtnSearch.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSearch.Click += new EventHandler(BtnSearch_Click);
            TxtSearchTrans.Controls.Add(BtnSearch);
            this.AcceptButton = BtnSearch;
            BtnAdd.Font = new Font("Comic San MS", 10, FontStyle.Regular);
            BtnSelect.Font = new Font("Comic San MS", 10, FontStyle.Regular);
            BtnDelete.Font = new Font("Comic San MS", 10, FontStyle.Regular);
            BtnClose.Font = new Font("Comic San MS", 10, FontStyle.Regular);
            TxtSearchTrans.Font = new Font("Comic Sans MS", 10, FontStyle.Regular);
            Tree_load();
        }

        private void Tree_load()
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
                        TrvTransactionType.Nodes.Add(NodeParent);
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
                TrvTransactionType.Nodes.Add(NodeParent);
            }
            Rdr.Close();
            FromLoad = true;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchTreeView();
        }

        private void SearchTreeView()
        {
            if (TxtSearchTrans.Text != "")
            {
                string HierarchyFound = CommFunc.Fetch_DB_Value("Hierarchy", "TransactionTypeDim",
                    "Description LIKE '%"
                    + TxtSearchTrans.Text + "%' OR Category LIKE '%" + TxtSearchTrans.Text + "%' GROUP BY Hierarchy");
                string CategoryFound = CommFunc.Fetch_DB_Value("Category", "TransactionTypeDim",
                    "Description LIKE '%"
                    + TxtSearchTrans.Text + "%' GROUP BY Category");
                int counter = 0;
                while (counter < HierarchyFound.Split('|').Count())
                {
                    string NodeNm = HierarchyFound.Split('|')[counter];
                    int innercounter = 0;
                    while (innercounter < TrvTransactionType.Nodes.Count)
                    {
                        TrvTransactionType.SelectedNode = TrvTransactionType.Nodes[innercounter];
                        if (TrvTransactionType.SelectedNode.Text == NodeNm)
                        {
                            TrvTransactionType.SelectedNode.BackColor = SystemColors.Highlight;
                            TrvTransactionType.SelectedNode.ForeColor = SystemColors.HighlightText;
                            TrvTransactionType.SelectedNode.Expand();
                            int CatCounter = 0;
                            while (CatCounter < CategoryFound.Split('|').Count())
                            {
                                string NodeNmCat = CategoryFound.Split('|')[CatCounter];
                                int innerCatCounter = 0;
                                while (innerCatCounter < TrvTransactionType.Nodes[innercounter].Nodes.Count)
                                {
                                    TrvTransactionType.SelectedNode = TrvTransactionType.Nodes[innercounter].Nodes[innerCatCounter];
                                    if (TrvTransactionType.SelectedNode.Text == NodeNmCat)
                                    {
                                        TrvTransactionType.SelectedNode.BackColor = SystemColors.Highlight;
                                        TrvTransactionType.SelectedNode.ForeColor = SystemColors.HighlightText;
                                        TrvTransactionType.SelectedNode.Expand();
                                    }
                                    innerCatCounter++;
                                }
                                CatCounter++;
                            }
                        }
                        innercounter++;
                    }
                    counter++;
                }
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (LabelEdit == false && FromLoad == false)
            {
                string SelectedVal = TrvTransactionType.SelectedNode.FullPath.Replace("\\", "|");
                int SelectedValCount = SelectedVal.Split('|').Count();
                if (SelectedValCount == 3)
                {
                    SelectedDesc = SelectedVal.Split('|')[2];
                    SelectedCategory = SelectedVal.Split('|')[1];
                    SelectedHier = SelectedVal.Split('|')[0];
                }
                else if (SelectedValCount == 2)
                {
                    SelectedCategory = SelectedVal.Split('|')[1];
                    SelectedHier = SelectedVal.Split('|')[0];
                }
                else
                    SelectedHier = SelectedVal;
                if (SelectedDesc != null)
                {
                    WhereClause = "Description = '" + SelectedDesc + "'";
                    if (EnableSelect == true)
                        BtnSelect.Enabled = true;
                }
                if (SelectedCategory != null)
                    WhereClause = WhereClause + " AND Category = '" + SelectedCategory + "'";
                if (SelectedHier != null)
                {
                    WhereClause = WhereClause + " AND Hierarchy = '" + SelectedHier + "'";
                }
                else
                    WhereClause = "";
            }
            else
            {
                LabelEdit = false;
                FromLoad = false;
            }
        }

        private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (FromLoad == false && ExcCounter == 0)
            {
                LabelEdit = true;
                string EditedVal = e.Label;
                if (EditedVal == null)
                    EditedVal = TrvTransactionType.SelectedNode.Text;
                if (SelectedDesc != null)
                    UpdateClause = "Description = '" + EditedVal + "'";
                else
                {
                    if (SelectedCategory != null)
                        UpdateClause = "Category = '" + EditedVal + "'";
                    else
                        if (SelectedHier != null)
                        {
                            UpdateClause = "Hierarchy = '" + EditedVal + "'";
                        }
                }
                string UpdtSql = "";
                if (WhereClause != "")
                {
                    if (WhereClause.StartsWith(" AND ") == true)
                        WhereClause = WhereClause.Substring(5, WhereClause.Length - 5);
                    UpdtSql = "UPDATE TransactionTypeDim SET " + UpdateClause + " WHERE " + WhereClause;
                    cmd = new SqlCommand(UpdtSql, SqlCon);
                    cmd.ExecuteNonQuery();
                }
                TrvTransactionType.Nodes.Clear();
                Tree_load();
                ExcCounter++;
            }
            else
                FromLoad = false;
        }

        private void TreeView_Click(object sender, EventArgs e)
        {
            FromLoad = false;
            ExcCounter = 0;
        }

        private void TreeView_MouseClick(object sender, EventArgs e)
        {
            TrvTransactionType.SelectedNode = null;
            BtnSelect.Enabled = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ExcCounter = 0;
            if (TrvTransactionType.SelectedNode == null)
            {
                TreeNode UntitledNode = new TreeNode("Untitled");
                TrvTransactionType.Nodes.Add(UntitledNode);
                TrvTransactionType.SelectedNode = UntitledNode;
                TrvTransactionType.SelectedNode.BeginEdit();
                ExcCounter = 1;
            }
            else
            {
                int SelectedValLevel = TrvTransactionType.SelectedNode.FullPath.Replace("\\", "|").Split('|').Count();
                if (SelectedValLevel == 3)
                    MessageBox.Show("You can't add a node further to this.", "Message:", MessageBoxButtons.OK);
                else
                {
                    TrvTransactionType.SelectedNode.Nodes.Add("Untitled");
                    TrvTransactionType.SelectedNode.Expand();
                    TrvTransactionType.SelectedNode.LastNode.BeginEdit();
                    SelectedValLevel = TrvTransactionType.SelectedNode.LastNode.FullPath.Replace("\\", "|").Split('|').Count();
                    if (SelectedValLevel == 3)
                    {
                        int MaxKey = CommFunc.FetchMaxKey("TransactionTypeKey", "TransactionTypeDim");
                        string GotDesc, GotCategory, GotHier;
                        string SelectedVal = TrvTransactionType.SelectedNode.LastNode.FullPath.Replace("\\", "|");
                        GotDesc = SelectedVal.Split('|')[2];
                        GotCategory = SelectedVal.Split('|')[1];
                        GotHier = SelectedVal.Split('|')[0];
                        string CreditDebitInd = CommFunc.Fetch_DB_Value("distinct(CreditDebitInd)", "TransactionTypeDim",
                            "Hierarchy = '" + GotHier + "'");
                        if (CreditDebitInd == "")
                            CreditDebitInd = "D";
                        strQ = "INSERT INTO TransactionTypeDim VALUES(" + MaxKey + ",'" + GotDesc + "','" + GotCategory + "','"
                            + GotHier + "','" + CreditDebitInd + "')";
                        cmd = new SqlCommand(strQ, SqlCon);
                        cmd.ExecuteNonQuery();
                        SelectedDesc = SelectedVal.Split('|')[2];
                        SelectedCategory = SelectedVal.Split('|')[1];
                        SelectedHier = SelectedVal.Split('|')[0];
                        if (SelectedDesc != null)
                            WhereClause = "Description = '" + SelectedDesc + "'";
                        if (SelectedCategory != null)
                            WhereClause = WhereClause + " AND Category = '" + SelectedCategory + "'";
                        if (SelectedHier != null)
                        {
                            WhereClause = WhereClause + " AND Hierarchy = '" + SelectedHier + "'";
                        }
                        else
                            WhereClause = "";
                    }
                    else
                        ExcCounter = 1;
                }
            }
            TrvTransactionType.SelectedNode = null;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int SelectedValLevel = TrvTransactionType.SelectedNode.FullPath.Replace("\\", "|").Split('|').Count();
            string GotDesc, GotCategory, GotHier;
            string SelectedVal = TrvTransactionType.SelectedNode.FullPath.Replace("\\", "|");
            if (SelectedValLevel == 3)
            {
                GotDesc = SelectedVal.Split('|')[2];
                GotCategory = SelectedVal.Split('|')[1];
                GotHier = SelectedVal.Split('|')[0];
                DialogResult Res = MessageBox.Show("Please confirm if you want to delete the node: " + GotDesc, "Message:", MessageBoxButtons.YesNo);
                if (Res == DialogResult.Yes)
                {
                    strQ = "DELETE FROM TransactionTypeDim WHERE Hierarchy = '"
                        + GotHier + "' AND Category = '" + GotCategory + "' AND Description = '" + GotDesc + "'";
                    cmd = new SqlCommand(strQ, SqlCon);
                    cmd.ExecuteNonQuery();
                    TrvTransactionType.Nodes.Clear();
                    Tree_load();
                }
            }
            if (SelectedValLevel == 2)
            {
                GotCategory = SelectedVal.Split('|')[1];
                GotHier = SelectedVal.Split('|')[0];
                DialogResult Res = MessageBox.Show("Please confirm if you want to delete the node: " + GotCategory, "Message:", MessageBoxButtons.YesNo);
                if (Res == DialogResult.Yes)
                {
                    strQ = "DELETE FROM TransactionTypeDim WHERE Hierarchy = '"
                        + GotHier + "' AND Category = '" + GotCategory + "'";
                    cmd = new SqlCommand(strQ, SqlCon);
                    cmd.ExecuteNonQuery();
                    TrvTransactionType.Nodes.Clear();
                    Tree_load();
                }
            }
            if (SelectedValLevel == 1)
            {
                GotHier = SelectedVal.Split('|')[0];
                DialogResult Res = MessageBox.Show("Please confirm if you want to delete the node: " + GotHier, "Message:", MessageBoxButtons.YesNo);
                if (Res == DialogResult.Yes)
                {
                    strQ = "DELETE FROM TransactionTypeDim WHERE Hierarchy = '"
                        + GotHier + "'";
                    cmd = new SqlCommand(strQ, SqlCon);
                    cmd.ExecuteNonQuery();
                    TrvTransactionType.Nodes.Clear();
                    Tree_load();
                }
            }
        }

        private void TxtSearchTrans_TextChanged(object sender, EventArgs e)
        {
            if (TxtSearchTrans.Text == "")
            {
                int innercounter = 0;
                while (innercounter < TrvTransactionType.Nodes.Count)
                {
                    TrvTransactionType.SelectedNode = TrvTransactionType.Nodes[innercounter];
                    TrvTransactionType.SelectedNode.BackColor = Color.White;
                    TrvTransactionType.SelectedNode.ForeColor = Color.Black;
                    int innerCatCounter = 0;
                    while (innerCatCounter < TrvTransactionType.Nodes[innercounter].Nodes.Count)
                    {
                        TrvTransactionType.SelectedNode = TrvTransactionType.Nodes[innercounter].Nodes[innerCatCounter];
                        TrvTransactionType.SelectedNode.BackColor = Color.White;
                        TrvTransactionType.SelectedNode.ForeColor = Color.Black;
                        innerCatCounter++;
                    }
                    innercounter++;
                }
                TrvTransactionType.CollapseAll();
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            string SelectedVal = TrvTransactionType.SelectedNode.FullPath.Replace("\\", "|");
            if (SelectedVal.Split('|').Count() == 3)
            {
                string GotDesc, GotCategory, GotHier;
                GotDesc = SelectedVal.Split('|')[2];
                GotCategory = SelectedVal.Split('|')[1];
                GotHier = SelectedVal.Split('|')[0];
                this.ReturnValue1 = GotDesc + ":" + GotCategory + ":" + GotHier;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
