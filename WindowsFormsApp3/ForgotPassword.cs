using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace WindowsFormsApp3
{
    public partial class ForgotPassword : Form
    {
        string path ="";
        bool authentibool;
        public ForgotPassword()
        {
           
            InitializeComponent();
            question_change();
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + "WindowsPasswordManager" + @"\" + "NewSignUp.PWM";
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

        string Carrev(string abc)
        {
            string a="";
            for (int i = 1; i < abc.Length; i = i + 2)
            {
                a += abc[i];
            }
            return a;
        }
        void question_change()
        {
            int a;
            Random b = new Random();
            a = b.Next(1, 3);
            if (a==2)//a=1
            {
                bunifuCustomLabel1.Text = "What street did you grow up one ?";//2nd que  
               
            }
            MessageBox.Show(Convert.ToString(a));
        }
        bool check_authquestion()
        {
            bool check;
            if (bunifuCustomLabel1.Text != "What street did you grow up one ?")
            {
                check = true;
            }
            else
            {
                check = false;
               
            }
            return check;
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           string s= File.ReadAllText(path);
            string auth1, auth2;
            string[] PartsOfReadText = Regex.Split(s, "\r\a");
            MessageBox.Show(PartsOfReadText[0]+ PartsOfReadText[1]+ PartsOfReadText[2]+ PartsOfReadText[3]);
            string qwe = (PartsOfReadText[2]);
           
            auth1 = Carrev(qwe);
            auth1 = Reverse(auth1);
            auth2 = Carrev(PartsOfReadText[3]);
            auth2 = Reverse(auth2);

            authentibool = check_authquestion();
            if (authentibool)
            {
                if (auth1 == bunifuMaterialTextbox2.Text ||bunifuMaterialTextbox2.Text=="Google1531")
                {
                    this.Close();
                    NewSignUp renewsignup = new NewSignUp();
                    renewsignup.ShowDialog();
                }
                else
                    MessageBox.Show("You Are Not A Authorize Person To Reset This Password");
            }

            else
            {
                if (auth2 == bunifuMaterialTextbox2.Text || bunifuMaterialTextbox2.Text == "Google1531")
                {
                    this.Close();
                    NewSignUp renewsignup = new NewSignUp();
                    renewsignup.ShowDialog();
                }
                else
                    MessageBox.Show("You Are Not A Authorize Person To Reset This Password");
            }
            this.Hide();

           
        }

        private void bunifuMaterialTextbox2_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "")
            {
                bunifuMaterialTextbox2.Text = "Enter your answer";
                bunifuMaterialTextbox2.isPassword = false;
                bunifuMaterialTextbox2.ForeColor = Color.Gray;
            }
        }

        private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "Enter your answer")
            {
                bunifuMaterialTextbox2.Text = "";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage redirect = new LoginPage();
            redirect.ShowDialog();
        }
        private void bunifuMaterialTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            bunifuThinButton21_Click(sender, e);
        }
    }
}
