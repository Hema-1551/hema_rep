using System;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        String alphabetUpper, specialChars, Pwd, genNum, alphabetLower = String.Empty;
        int LengthPass;
        public Form3()
        {
            InitializeComponent();
        }
        Random random = new Random();



        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 redirect = new Form1();
            redirect.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            genNum = string.Empty; alphabetLower = string.Empty; alphabetUpper = string.Empty; specialChars = string.Empty; Pwd = string.Empty;
            LengthPass = 0;
            // Generate Numbers Function
            String GenNumbers(int min, int max)
            {
                genNum = Convert.ToString(random.Next(min, max));


                return genNum;
            }
            //Generate Capitals Function
            String GenAlphabetsUpper(int min, int max)
            {
                alphabetUpper = Convert.ToString(Convert.ToChar(random.Next(min, max)));
                return alphabetUpper;
            }
            //Generate Smalls Functions
            String GenAlphabetsLower(int min, int max)
            {
                alphabetLower = Convert.ToString(Convert.ToChar(random.Next(min, max)));
                return alphabetLower;

            }
            //Generate Special Function
            String GenSpecialChars(int min, int max)
            {
                int selctSpecialChar = (random.Next(min, max));
                if (selctSpecialChar == 0)
                {
                    specialChars = Convert.ToString(Convert.ToChar(random.Next(33, 47)));
                }
                else if (selctSpecialChar == 1)
                {
                    specialChars = Convert.ToString(Convert.ToChar(random.Next(58, 64)));

                }
                else if (selctSpecialChar == 2)
                {
                    specialChars = Convert.ToString(Convert.ToChar(random.Next(91, 96)));

                }
                else
                {
                    specialChars = Convert.ToString(Convert.ToChar(random.Next(123, 126)));
                }

                return specialChars;
            }
            //input of user no. of charcters in password

            try
            {
                LengthPass = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Length Cannot Be Empty");

            }

            //FIRST CHARACTER CHARACTER CODE
            string latterPass = "", firstchara = "";
            if (LengthPass > 0)
            {
                if (radioButton1.Checked == true)
                {
                    firstchara = GenAlphabetsUpper(65, 90);
                }
                else if (radioButton2.Checked == true)
                {
                    firstchara = GenAlphabetsLower(97, 122);
                }
                else if (radioButton3.Checked == true)
                {
                    firstchara = GenNumbers(0, 9);
                }
            }
            //LATER CHARACTERS CODE
            string a, b, c, d;
            a = Convert.ToString(Convert.ToInt32(checkBox1.Checked));
            b = Convert.ToString(Convert.ToInt32(checkBox2.Checked));
            c = Convert.ToString(Convert.ToInt32(checkBox3.Checked));
            d = Convert.ToString(Convert.ToInt32(checkBox4.Checked));

            int choice = Convert.ToInt32(a + b + c + d);

            switch (choice)
            {
                case 0000:
                    MessageBox.Show("Please Select Check Boxes You Require");
                    break;
                case 0001:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        latterPass += GenSpecialChars(0, 3);
                    }
                    break;
                case 0010:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        latterPass += GenNumbers(0, 9);
                    }
                    break;
                case 0011:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 3);

                        if (multiple == 1)
                        {
                            latterPass += GenNumbers(0, 9);
                        }
                        else
                        {
                            latterPass += GenSpecialChars(0, 3);
                        }
                    }
                    break;
                case 0100:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        latterPass += GenAlphabetsLower(97, 122);
                    }
                    break;
                case 0101:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 3);
                        if (multiple == 1)
                        {
                            latterPass += GenAlphabetsLower(97, 122);
                        }
                        else
                        {
                            latterPass += GenSpecialChars(0, 3);
                        }
                    }

                    break;
                case 0110:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 3);

                        if (multiple == 1)
                        {
                            latterPass += GenAlphabetsLower(97, 122);
                        }
                        else
                        {
                            latterPass += GenNumbers(0, 9);
                        }
                    }
                    break;
                case 0111:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 4);
                        switch (multiple)
                        {
                            case 1:
                                latterPass += GenAlphabetsLower(97, 122);

                                break;
                            case 2:
                                latterPass += GenNumbers(0, 9);

                                break;
                            case 3:
                                latterPass += GenSpecialChars(0, 3);

                                break;
                        }
                    }
                    break;
                case 1000:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        latterPass += GenAlphabetsUpper(65, 90);
                    }
                    break;
                case 1001:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 3);

                        if (multiple == 1)
                        {
                            latterPass += GenAlphabetsUpper(65, 90);
                        }
                        else
                        {
                            latterPass += GenSpecialChars(0, 3);
                        }
                    }
                    break;
                case 1010:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 3);

                        if (multiple == 1)
                        {
                            latterPass += GenAlphabetsUpper(65, 90);
                        }
                        else
                        {
                            latterPass += GenNumbers(0, 9);
                        }
                    }
                    break;
                case 1011:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 4);
                        switch (multiple)
                        {
                            case 1:
                                latterPass += GenAlphabetsUpper(65, 90);

                                break;
                            case 2:
                                latterPass += GenNumbers(0, 9);

                                break;
                            case 3:
                                latterPass += GenSpecialChars(0, 3);

                                break;
                        }
                    }
                    break;
                case 1100:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 3);

                        if (multiple == 1)
                        {
                            latterPass += GenAlphabetsUpper(65, 90);
                        }
                        else
                        {
                            latterPass += GenAlphabetsLower(97, 122);
                        }
                    }
                    break;
                case 1101:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 4);
                        switch (multiple)
                        {
                            case 1:
                                latterPass += GenAlphabetsUpper(65, 90);

                                break;
                            case 2:
                                latterPass += GenAlphabetsLower(97, 122);

                                break;
                            case 3:
                                latterPass += GenSpecialChars(0, 3);

                                break;
                        }
                    }
                    break;
                case 1110:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 4);
                        switch (multiple)
                        {
                            case 1:
                                latterPass += GenAlphabetsUpper(65, 90);

                                break;
                            case 2:
                                latterPass += GenAlphabetsLower(97, 122);

                                break;
                            case 3:
                                latterPass += GenNumbers(0, 9);

                                break;
                        }
                    }
                    break;
                default:
                    for (int i = 0; i < (LengthPass - 1); i++)
                    {
                        int multiple = random.Next(1, 5);
                        switch (multiple)
                        {
                            case 1:
                                latterPass += GenAlphabetsUpper(65, 90);

                                break;
                            case 2:
                                latterPass += GenAlphabetsLower(97, 122);

                                break;
                            case 3:
                                latterPass += GenNumbers(0, 9);

                                break;
                            case 4:
                                latterPass += GenSpecialChars(0, 3);
                                break;
                        }
                    }
                    break;
            }

            Pwd = firstchara + latterPass;

            if (Convert.ToBoolean(LengthPass))
            {
                Form4 GeneratedPassword = new Form4(Pwd);
                GeneratedPassword.Show();
                Pwd = string.Empty;
            }
            else
            {
                Form3 gn = new Form3();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            checkBox3.Checked = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string t = textBox2.Text;
            foreach( char ch in t)
            {
                if (Char.IsDigit(ch))
                {
                }
                else
                {
                    textBox2.Text = null;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
