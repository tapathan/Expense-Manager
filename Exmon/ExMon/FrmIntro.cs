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
    public partial class FrmIntro : Form
    {
        public FrmIntro()
        {
            InitializeComponent();
        }

        private void FrmIntro_Load(object sender, EventArgs e)
        {
            string Intro = "Hello,\n\n" 
                + "    Have you ever thought of if you had a personal assistant who would take care of " 
                + "monitoring all your expenses and tell you on the trends how you spend your money? "
                + "ExMon could do that for you. Monitoring your expenses can make your life easier.\n"
                + "\n    ExMon not only records your day-to-day transactions' information but also is a powerful tool that would"
                + " let you analyse the information and drill down to find some valuable trends from this information.\n"
                + "\n    You might have noticed people complaining about how they wonder where their money got spend"
                + " so soon even though they think they don't spend much. Tracking the details of your expenses would never" 
                + " let you clueless about your money. Infact, doing so would make you more disciplined on managing your money.\n"
                + "\nThank You.";
            /*LblIntro.Text = Inro;
            LblIntro.AutoSize = false;
            LblIntro.Font = new Font(this.Font.Name, 10, FontStyle.Regular);
            LblIntro.Size = new Size(500, 320);*/
            richTextBox1.Text = Intro;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
