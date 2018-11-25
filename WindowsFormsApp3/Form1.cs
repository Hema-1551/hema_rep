using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //this.BackgroundImage = Properties.Resources.Transparent_Btn;

            Form2 ManageYourPasswords = new Form2();
            ManageYourPasswords.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 GenerateRandomPassword = new Form3();
            GenerateRandomPassword.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 GenerateRandomPassword = new Form5();
            GenerateRandomPassword.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Application Is Published By ::\n       ::Hemalatha::      \n::All Rights Reserved::");
            ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.button5, "Button Info");

            About nsns = new About();
            nsns.Show();
        }

 
    }
}
