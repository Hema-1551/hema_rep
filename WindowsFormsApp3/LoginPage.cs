using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
namespace WindowsFormsApp3
{
    public partial class LoginPage : Form
    {
        string path = "";
        public LoginPage()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+ @"\" + "WindowsPasswordManager"+@"\" + "NewSignUp.PWM";
        }
        string Reverse(string str)
        {
            string reverseString = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverseString += str[i];
            }
            return reverseString;
        }
        private void label4_Click(object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                this.Hide();
                NewSignUp signup = new NewSignUp();
                signup.Show();
            }
            else
                MessageBox.Show("You Have Created Password Already try Forget Your Password !!.");
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string pa = "", Authentication="", readalltext = "";
            readalltext = File.ReadAllText(path);
            string[] PartsOfReadText = Regex.Split(readalltext, "\r\a");
           string qwe = (PartsOfReadText[1]);
            for (int i = 1; i < PartsOfReadText[1].Length; i = i + 2)
            {
                pa += qwe[i];
            }
            pa = Reverse(pa);
            Authentication = bunifuMaterialTextbox1.Text;
            if (Authentication == pa)
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                if(bunifuMaterialTextbox1.Text == "")
                {
                    bunifuMaterialTextbox1.Text = "";
                }
                else
                label6.Text = "*Incorect Password";
            }
        }
        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
                    bunifuMaterialTextbox1.isPassword = true;
        }

        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
            {
                bunifuMaterialTextbox1.Text = "Enter your password";
                bunifuMaterialTextbox1.isPassword = false;
                bunifuMaterialTextbox1.ForeColor = Color.Gray;
            }
        }

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "Enter your password")
            {
                bunifuMaterialTextbox1.Text = "";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
            ForgotPassword gn = new ForgotPassword();
            gn.Show();
        }

        private void bunifuMaterialTextbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bunifuThinButton21_Click(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }
    }
}
