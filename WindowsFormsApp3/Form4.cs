using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form4 : Form
    {
        string Password ="as";
        public Form4(String Pwd)
        {
            Password = Pwd;
            InitializeComponent();
        }
        
        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 redirect = new Form3();
            redirect.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Password);
            this.Dispose();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            textBox1.Text += Password;

        }
    }
}
