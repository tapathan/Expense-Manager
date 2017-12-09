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
    public partial class FrmChoosePassword : Form
    {
        public FrmChoosePassword()
        {
            InitializeComponent();
        }

        public string ReturnValue { get; set; }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (TxtPassword.Text != "")
            {
                this.ReturnValue = TxtPassword.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Please provide a password.", "message:", MessageBoxButtons.OK);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmChoosePassword_Load(object sender, EventArgs e)
        {
            this.Text = "Choose Password";
            this.AcceptButton = BtnOk;
        } 
    }
}
