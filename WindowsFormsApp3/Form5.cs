using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace WindowsFormsApp3
{
    public partial class Form5 : Form
    {
            int bonus = 0;
        string password = "";

        public Form5()
        {
            InitializeComponent();
            checkBox1.Checked = true;
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            password = textBox1.Text;
            int bonus_Characters = password.Length * 4;
            int bonus_Uppercase = -((LenOfUpper(password) - password.Length) * 2);
            if (LenOfUpper(password) <= 0)
            {
                bonus_Uppercase = 0;
            }
            int bonus_Lowercase = -(LenOfLower(password) - password.Length) * 2;
            if (LenOfLower(password) <= 0)
            {
                bonus_Lowercase = 0;
            }
            int bonus_Numbers = (LenOfNumbers(password) * 4);
            int bonus_Symbol = (LenOfSymbol(password) * 6);
            int bonus_MiddleNumbers=0;
            int bonus_MiddleSymbols=0;
            if (password.Length>0)
            {
                bonus_MiddleNumbers = LenOfMidNumbers(password) * 2;
                bonus_MiddleSymbols = LenOfMidSymbols(password) * 2;

            }
            //Reductions
            int bonus_DigitOnly = IsDigitsOnly(password);
            int bonus_LettersOnly = IsLetterOnly(password);
            int bonus_Repeated = -IsRepeated(password);
            int bonus_UpperConse = -IsUpperConsequtive(password) * 2;
            int bonus_LowerConse = -IsLowerConsequtive(password) * 2;
            bonus = bonus_Characters + bonus_Uppercase + bonus_Lowercase + bonus_Numbers + bonus_Symbol + bonus_MiddleNumbers + bonus_MiddleSymbols + bonus_LettersOnly + bonus_DigitOnly + bonus_Repeated + bonus_UpperConse;

           // MessageBox.Show("NOC :" + bonus_Characters + "\n UL :" + bonus_Uppercase + "\n LL :" + bonus_Lowercase + "\n  N :" + bonus_Numbers + "\n  Sy:" + bonus_Symbol + "\n  MiNu:" + bonus_MiddleNumbers + "\n MSy" + bonus_MiddleSymbols);

            if (bonus > 100)
            {
                bonus = 100;
            progressBar1.Value = bonus;

            }
            else if(bonus<1)
            {
                bonus = 1;
                progressBar1.Value = bonus;
            }
            else
            {
                progressBar1.Value = bonus;
            }
            label2.Text = Convert.ToString(bonus)+"%";
            // COMPLEXITY
            if (bonus <= 20)
            {
                label4.Text = "Very Weak";
            }
            else if (bonus <= 40)
            {
                label4.Text = " Weak";
            }
            else if (bonus <= 65)
            {
                label4.Text = "Good";

            }
            else if(bonus<=80)
            {
                label4.Text = "Strong";
            }
            else
            {
                label4.Text = "Very Strong";
            }
        }
        int LenOfUpper(string password)
        {
            int num = 0;
            foreach (char ch in password)
            {
                if (char.IsUpper(ch))
                {
                    num++;
                }
            }
            return num;
            
        }
        int LenOfLower(string password)
        {
            int num = 0;
            foreach (char ch in password)
            {
                if (char.IsLower(ch))
                {
                    num++;
                }
            }
            return num;
        }
        int LenOfNumbers(string password)
        {
            int num = 0;
            foreach (char ch in password)
            {
                if (char.IsDigit(ch))
                {
                    num++;
                }
            }
            return num;
        }
        int LenOfSymbol(string password)
        {
            int num = 0;
            foreach (char ch in password)
            {
                if ( !Char.IsLetterOrDigit(ch))
                {
                    num++;
                }
            }
            return num;
        }
        int LenOfMidNumbers(string password)
        {
            int num = 0;
            
                password = password.Substring(1,password.Length-1);
                foreach (char ch in password)
                {
                    if (char.IsDigit(ch))
                    {
                        num++;
                    }
                }
            return num;
        }
        int LenOfMidSymbols(string password)
        {
            int num = 0;
            password = password.Substring(1,password.Length-1);
            foreach (char ch in password)
                {
                    if (!Char.IsLetterOrDigit(ch))
                    {
                        num++;
                    }
                }
            return num;
        }
        int IsLetterOnly(string str)
        {
            if (Regex.IsMatch(str, @"^[a-zA-Z]+$"))
            {
                return -password.Length;
            }

            return 0;
        }
        int IsDigitsOnly(string str)
        {
            if (Regex.IsMatch(str, @"^[0-9]+$"))
            {
                return -password.Length;
            }
            return 0;
        }

        int IsUpperConsequtive(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                for (int j = i + 1; j < password.Length; j++)
                {
                    if (char.IsUpper(password[i]) && char.IsUpper(password[j]))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        int IsRepeated(string password)
        {
            int count = 0;

            for (int i = 0; i < password.Length; i++)
            {
                for (int j = i + 1; j < password.Length; j++)
                {
                    if (password[i] == password[j])
                    {
                        count++;
                    }
                }
            }
            return count * 2;
        }

        int IsLowerConsequtive(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                for (int j = i + 1; j < password.Length; j++)
                {
                    if (char.IsLower(password[i]) && char.IsLower(password[j]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = bonus;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <=100; i++)
            {
                // Wait 50 milliseconds.  
                Thread.Sleep(50);
                // Report progress.  
                backgroundWorker1.ReportProgress(i);
            }

        }
        private void backgroundWorker1_ProgresssChange(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar
        progressBar1.Value = e.ProgressPercentage;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = true;
            }
            else
            {
                textBox1.UseSystemPasswordChar = false;
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Form1 redirect = new Form1();
            redirect.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

