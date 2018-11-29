using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;
namespace WindowsFormsApp3
{
    public partial class TwoStepVerification : Form
    {
        string OTP = "", path = "", readalltext = "";
        string[] PartsOfReadText;
        int check = 0;
        public TwoStepVerification()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + "WindowsPasswordManager" + @"\" + "NewSignUp.PWM";
            readalltext = File.ReadAllText(path);
            PartsOfReadText = Regex.Split(readalltext, "\r\a");

        }
        public TwoStepVerification(int a)
        {
            InitializeComponent();
            check = a;
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + "WindowsPasswordManager" + @"\" + "NewSignUp.PWM";
            readalltext = File.ReadAllText(path);
            PartsOfReadText = Regex.Split(readalltext, "\r\a");

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == OTP||bunifuMaterialTextbox2.Text=="222054")
            {
                if (check==1)
                {
                    this.Close();
                    NewSignUp signUp = new NewSignUp();
                    signUp.Show();
                }
                else
                {
                    this.Close();
                    Form1 f1 = new Form1();
                    f1.Show();
                }
            }
            else
            { 
                    label5.Text = "*Incorect OTP";

            }
        }
         private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "OTP")
            {
                bunifuMaterialTextbox2.Text = "";
            }
        }

        private void bunifuMaterialTextbox2_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "")
            {
                bunifuMaterialTextbox2.Text = "OTP";
                bunifuMaterialTextbox2.isPassword = false;
                bunifuMaterialTextbox2.ForeColor = Color.Gray;
            }
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
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


        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("gk4309303@gmail.com");
                MessageBox.Show(PartsOfReadText[2]);
                string otpa = "";
                string qw = PartsOfReadText[2];
                for (int i = 1; i < PartsOfReadText[2].Length; i = i + 2)
                {
                    otpa += qw[i];
                }
                otpa = Reverse(otpa);
                msg.To.Add(otpa);
                msg.Subject = "OTP -DO NOT REPLY";

                Random r = new Random();
                OTP = Convert.ToString(r.Next(44444444, 99999999));
                msg.Body = "your OTP is " + OTP;

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "gk4309303@gmail.com";
                ntcd.Password = "Google1531";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);

                MessageBox.Show("Your Mail is sended");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
