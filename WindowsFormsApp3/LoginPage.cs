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

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
            NewSignUp signup = new NewSignUp();
             signup.Show();
         
           
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //Futuree Implementation
            string pa = "", Authentication="", readalltext = "";
            readalltext = File.ReadAllText(path);

            string[] PartsOfReadText = Regex.Split(readalltext, "\r\a");

            //   writingText =Length + PassEncrypt  + RanPass;

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
                if ((bunifuMaterialTextbox1.Text == ""))
                {
                    bunifuMaterialTextbox1.Text = "";
                    
                }
                else
                label6.Text = "*Incorect Password";
            }
        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
          
        }

        private void bunifuMaterialTextbox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_MouseClick(object sender, MouseEventArgs e)
        {
        

        }

        private void bunifuMaterialTextbox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
            {
                bunifuMaterialTextbox1.Text = "Enter some text here";
                bunifuMaterialTextbox1.ForeColor = Color.Gray ;
            }
        }

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "Enter some text here")
            {
                bunifuMaterialTextbox1.Text = "";
            }
            bunifuThinButton21_Click(sender,e);
        }
    }
}
