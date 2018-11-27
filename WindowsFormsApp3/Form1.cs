using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage redirect = new LoginPage();
            redirect.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 GenerateRandomPassword = new Form3();
            GenerateRandomPassword.Show();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            this.Close();
            Form2 ManageYourPasswords = new Form2();
            ManageYourPasswords.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();
            Form5 GenerateRandomPassword = new Form5();
            GenerateRandomPassword.Show();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Application Is Published By ::\n       ::Hemalatha::      \n::All Rights Reserved::");
            ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.bunifuThinButton23, "Button Info");

            About nsns = new About();
            nsns.Show();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
