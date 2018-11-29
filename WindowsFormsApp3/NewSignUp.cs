using System;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class NewSignUp : Form
    {
        private string[] returnedPass= { "1", "2" };
        string path = "", password = "",gmail="", decrypted, PassEncrypt, PassDecrypt ,writingText= ""; byte[] encrypted;

        AesManaged aes = new AesManaged();
        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage redirect = new LoginPage();
            redirect.ShowDialog();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.isPassword = true;
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
        }
        private void bunifuMaterialTextbox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            bunifuThinButton21_Click(sender, e);
        }
        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
            {
                bunifuMaterialTextbox1.Text = "Enter your password";
                bunifuMaterialTextbox1.ForeColor = Color.Gray;
                bunifuMaterialTextbox1.isPassword = false;

            }
        }

        private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "ReEnter your password")
            {
                bunifuMaterialTextbox2.Text = "";
            }
        }
        private void bunifuMaterialTextbox2_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "")
            {
                bunifuMaterialTextbox2.Text = "ReEnter your password";
                bunifuMaterialTextbox2.ForeColor =Color.Gray;
                bunifuMaterialTextbox2.isPassword = false;

            }
        }

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "Enter your password")
            {
                bunifuMaterialTextbox1.Text = "";
            }
        }

        public NewSignUp()
        {
            InitializeComponent();
            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            path = path + @"\" + "WindowsPasswordManager";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += @"\" + "NewSignUp.PWM";
        }
        string[] EncryptAesManaged(string raw1)
        {
            string variable = ""; string[] crypt = { "1", "2" };
            try
            {
                // Create Aes that generates a new key and initialization vector (IV).    
                // Same key must be used in encryption and decryption    
                using (AesManaged aes = new AesManaged())
                {
                    // Encrypt string    
                    encrypted = Encrypt(raw1, aes.Key, aes.IV);

                    decrypted = Decrypt(encrypted, aes.Key, aes.IV);

                    // MessageBox.Show("decryted value"+decrypted);
                    variable = System.Text.Encoding.UTF8.GetString(encrypted);
                    //  byte [] ver=System.Text.Decoder
                    crypt[0] = variable;
                    crypt[1] = decrypted;
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            return crypt;
        }

        string[] Questions = { "", "" };
        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            string[] EncryptDecrypt = EncryptAesManaged(bunifuMaterialTextbox3.Text);
            EncryptDecrypt[1] = Reverse(EncryptDecrypt[1]);
            string answer= "\r\a" + CharAdd(EncryptDecrypt[1]);
           File.AppendAllText(path, answer);
            if(bunifuCustomLabel4.Text!= "What street did you grow up one ?")
            {
                bunifuCustomLabel4.Text = "What street did you grow up one ?";//2nd que  
                bunifuMaterialTextbox3.Text = "";
            }
            else
            {
                bunifuCustomLabel4.Text = "";
                bunifuMaterialTextbox3.Text = "";
                bunifuCustomLabel4.Text = "Account is created successfully !";
                this.Close();
                LoginPage redirect = new LoginPage();
                redirect.ShowDialog();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuMaterialTextbox1_OnValueChanged_1(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
        }

        private void bunifuMaterialTextbox2_OnValueChanged_1(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.isPassword = true;
        }

        private void bunifuMaterialTextbox4_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox4.Text == "Enter Your Email")
            {
                bunifuMaterialTextbox4.Text = "";
            }
        }

        private void bunifuMaterialTextbox4_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox4.Text == "")
            {
                bunifuMaterialTextbox4.Text = "Enter Your Email";
                bunifuMaterialTextbox4.ForeColor = Color.Gray;
                bunifuMaterialTextbox4.isPassword = false;

            }
        }

        byte[] Encrypt(string plainText1, byte[] Key, byte[] IV)
            {
                byte[] encrypted;
                // Create a new AesManaged.    
                using (AesManaged aes = new AesManaged())
                {
                    // Create encryptor    
                    ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                    // Create MemoryStream    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                        // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                        // to encrypt    
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            // Create StreamWriter and write data to a stream    
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(plainText1);
                            }
                            encrypted = ms.ToArray();
                        }
                    }
                }
                // Return encrypted data    
                return encrypted;
            }
            string Decrypt(byte[] cipherText, byte[] Key, byte[] IV)
            {
                string plaintext = null;
                // Create AesManaged    
                using (AesManaged aes = new AesManaged())
                {
                    // Create a decryptor    
                    ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                    // Create the streams used for decryption.    
                    using (MemoryStream ms = new MemoryStream(cipherText))
                    {
                        // Create crypto stream    
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            // Read crypto stream    
                            using (StreamReader reader = new StreamReader(cs))
                                plaintext = reader.ReadToEnd();
                        }
                    }
                }
                return plaintext;
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
        string  CharAdd(string str)
        {
                Random r = new Random();
            string RanPass = "";
            foreach (char c in str)
            {
                RanPass += Convert.ToString(Convert.ToChar(r.Next(1, 122))) + c;
            }
            return RanPass;
        }

        //CONSTRINTS FOR PASSWORD

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == bunifuMaterialTextbox2.Text&&bunifuMaterialTextbox4.Text!=null)
            {
                password = bunifuMaterialTextbox2.Text;
                gmail = bunifuMaterialTextbox4.Text;
                gmail = CharAdd(Reverse(bunifuMaterialTextbox4.Text));
                MessageBox.Show(gmail);
                returnedPass = EncryptAesManaged(password);
                PassEncrypt = returnedPass[0];
                PassDecrypt = returnedPass[1];
                PassDecrypt = Reverse(PassDecrypt);
                writingText = PassEncrypt + "\r\a" + CharAdd(PassDecrypt)+"\r\a"+gmail;
                File.WriteAllText(path, writingText.ToString());
                bunifuThinButton21.Location = new Point(160, 365);//pont to be changes
                bunifuMaterialTextbox1.Location = new Point(69,194);
                bunifuMaterialTextbox2.Location = new Point(69, 274);
                //bunifuCustomLabel2.Font.Size();
                bunifuCustomLabel1.Location = new Point(120, 162);
                bunifuMaterialTextbox3.BackColor = Color.AliceBlue;
                bunifuCustomLabel2.Location = new Point(171, 432);
                bunifuCustomLabel2.ForeColor = Color.White;
                bunifuCustomLabel2.BackColor = Color.DeepSkyBlue;
                bunifuCustomLabel3.Location = new Point(286, 563);
                bunifuCustomLabel3.ForeColor = Color.White;
                bunifuCustomLabel3.BackColor = Color.DeepSkyBlue;
                bunifuCustomLabel4.Location = new Point(107, 481);
                bunifuCustomLabel4.ForeColor = Color.White;
                bunifuCustomLabel4.BackColor = Color.DeepSkyBlue;
                //OTP Implementation..

                MessageBox.Show("Password is successfully created for Admin Account");
              //  this.Close();
              
            }


        }

    }
}
