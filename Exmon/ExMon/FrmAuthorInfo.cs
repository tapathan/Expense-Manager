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
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            //LblLogo
            LblAbout.Text = "ExMon 1.0 (32-bit Edition)" 
                + "\nThis Software costs an optional 100 Indian Rupees charge." 
                + "\nPlease donate 100 Indian Rupees to someone you know is in need of." 
                + "\n\nAuthor Information: Tanveer Ahmad Pathan"
                + "\nEmail-Id: tanveertech@gmail.com"
                + "\n\nYou can write me your experience with ExMon on my Email-Id."
                + "\nAny suggestions are welcome."
                + "\n\nThank You.";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
