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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        SqlConnection SqlCon = DBConnectionMgr.GetCon(true);
        SqlCommand SelCmd;
        SqlDataReader Rdr;

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (SqlCon.ConnectionString.Contains("master"))
            {
                FrmInitialSetup InitialSetup = new FrmInitialSetup();
                InitialSetup.Font = this.Font;
                InitialSetup.BackColor = Color.LightBlue;
                InitialSetup.ShowDialog();
                FrmCreateNewUser NewUser = new FrmCreateNewUser("InitialSetup");
                NewUser.ShowDialog();
                MessageBox.Show("Please restart the applicaion to login.", "Message:", MessageBoxButtons.OK);
                this.Close();
            }
            if (SqlCon.ConnectionString == "")
                Close();
            this.BackColor = Color.CadetBlue;
            PanLogin.BackColor = Color.Ivory;
            LblUsername.Font = new Font("Verdana", 10, FontStyle.Regular);
            LblPassword.Font = new Font("Verdana", 10, FontStyle.Regular);
            BtnOk.Font = new Font("Verdana", 10, FontStyle.Regular);
            BtnCancel.Font = new Font("Verdana", 10, FontStyle.Regular);
            txtUsername.Font = new Font("Verdana", 10, FontStyle.Regular);
            txtPassword.Font = new Font("Verdana", 10, FontStyle.Regular);
            txtPassword.PasswordChar = '*';
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Username or Password can't be blank.", "Warning:", MessageBoxButtons.OK);
            else
            {
                EncryptDecrypt EncryptPasswd = new EncryptDecrypt((txtUsername.Text + txtPassword.Text).ToCharArray(), 2);
                string Query = "SELECT PASSWORD AS PASS FROM USERDIM WHERE USERNAME = '" + txtUsername.Text + "'";
                SelCmd = new SqlCommand(Query, SqlCon);
                Rdr = SelCmd.ExecuteReader();
                string DbPass = "";
                if (Rdr.HasRows == true)
                {
                    Rdr.Read();
                    DbPass = Rdr["PASS"].ToString();
                }
                if (DbPass == "")
                {
                    MessageBox.Show("User " + txtUsername.Text + " not found.", "Error:", MessageBoxButtons.OK);
                    txtPassword.Text = "";
                }
                else
                {
                    if (EncryptPasswd.Encrypt() != DbPass)
                    {
                        MessageBox.Show("Incorrect Password.", "Error:", MessageBoxButtons.OK);
                        txtPassword.Text = "";
                    }
                    else
                    {
                        CommonFunctions.UserNm = txtUsername.Text;
                        FrmMDIMain MDI = new FrmMDIMain();
                        MDI.ShowDialog();
                        this.Close();
                    }
                }
                Rdr.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
