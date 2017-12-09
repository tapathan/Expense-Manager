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
    public partial class FrmCreateNewUser : Form
    {
        Boolean InitialSetup;
        Boolean ChangePassword;
        public FrmCreateNewUser()
        {
            InitializeComponent();
            this.InitialSetup = false;
        }

        public FrmCreateNewUser(string InitialSetup)
        {
            InitializeComponent();
            if (InitialSetup == "InitialSetup")
            {
                this.InitialSetup = true;
                this.ChangePassword = false;
            }
            else if (InitialSetup == "ChangePassword")
            {
                this.InitialSetup = false;
                this.ChangePassword = true;
            }
        }

        CommonFunctions CommFunc = new CommonFunctions();
        SqlConnection SqlCon = DBConnectionMgr.GetCon(true);
        SqlCommand InsCmd;
        string InsQuery = "";
        ClsDBScripts DBScript = new ClsDBScripts();

        private void FrmCreateNewUser_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
            if (InitialSetup == true)
            {
                 DBScript.CreateViews();
                DBScript.CreateProcs();
                DBScript.CreateTriggers();
                DBScript.InsertData();
                CmbAccess.SelectedIndex = 2;
                CmbAccess.Enabled = false;
            }
            else
            {
                CmbAccess.Items.Remove("SUPER USER");
                CmbAccess.SelectedIndex = 0;
            }
            if (ChangePassword == true)
            {
                txtUsername.Text = CommonFunctions.UserNm;
                txtUsername.Enabled = false;
                string UserAccessType = CommFunc.Fetch_DB_Value("Access", "UserDim", "Username = '" + CommonFunctions.UserNm + "'");
                CmbAccess.Text = UserAccessType;
                CmbAccess.Enabled = false;
                GrpCreateNewUser.Text = "Change Password";
            }
            this.Text = "Create User";
            this.AcceptButton = BtnOk;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
                MessageBox.Show("All Fields are necessary.", "Warning:", MessageBoxButtons.OK);
            else
            {
                if (txtPassword.Text != txtConfirmPassword.Text)
                    MessageBox.Show("Passwords doesn't match.", "ERROR:", MessageBoxButtons.OK);
                else
                {
                    string TodayDt = DateTime.Today.ToString("yyyy/MM/dd");
                    int UserKey = CommFunc.FetchMaxKey("UserKey", "UserDim");
                    EncryptDecrypt EncrPasswd = new EncryptDecrypt((txtUsername.Text + txtPassword.Text).ToCharArray(), 2);
                    if (ChangePassword == false)
                    {
                        InsQuery = "INSERT INTO USERDIM VALUES(" + UserKey + ", '" + txtUsername.Text + "', '"
                            + EncrPasswd.Encrypt() + "', '" + CmbAccess.Text + "','" + TodayDt + "', '2099/12/31')";
                        InsCmd = new SqlCommand(InsQuery, SqlCon);
                        InsCmd.ExecuteNonQuery();
                        MessageBox.Show("User " + txtUsername.Text + " created successfully.", "Message:",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtConfirmPassword.Text = "";
                        CmbAccess.Enabled = true;
                        CmbAccess.SelectedIndex = 0;
                        txtUsername.Focus();
                    }
                    else
                    {
                        UserKey = CommFunc.FetchKey("UserDim", txtUsername.Text);
                        CommFunc.Update_DB("Password = '" + EncrPasswd.Encrypt() + "'", "UserDim", "UserKey = " + UserKey);
                        MessageBox.Show("Your password has been changed.", "Message:", MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
