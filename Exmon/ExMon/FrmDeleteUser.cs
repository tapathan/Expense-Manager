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
    public partial class FrmDeleteUser : Form
    {
        public FrmDeleteUser()
        {
            InitializeComponent();
        }

        CommonFunctions CommFunc = new CommonFunctions();

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDeleteUser_Load(object sender, EventArgs e)
        {
            this.Text = "Delete User";
            CommFunc.Fill_Combo(CmbUsername, "Username", "UserDim", "Access != 'SUPER USER'");
            if (CmbUsername.Items.Count > 0)
                CmbUsername.SelectedIndex = 0;
            CmbUsername.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int UserKey = CommFunc.FetchKey("UserDim", CmbUsername.Text);
            CommFunc.delete_table("UserDim", "UserKey = " + UserKey);
            MessageBox.Show("User " + CmbUsername.Text + " has been deleted.", "message:", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
        }
    }
}
