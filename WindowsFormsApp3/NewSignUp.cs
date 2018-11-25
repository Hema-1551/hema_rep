using System;
using System.Security.Cryptography;
using System.IO;

using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class NewSignUp : Form
    {
        private string[] returnedPass= { "1", "2" };
        string path = "", password = "", decrypted,IdEncrypt, IdDecrypt , PassEncrypt, PassDecrypt ,writingText= ""; byte[] encrypted;

        AesManaged aes = new AesManaged();

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

        private void NewSignUp_Load(object sender, EventArgs e)
        {

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

        //CONSTRINTS FOR PASSWORD


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == bunifuMaterialTextbox2.Text)
            {
                password = bunifuMaterialTextbox2.Text;

                returnedPass = EncryptAesManaged(password);
                PassEncrypt = returnedPass[0];
                PassDecrypt = returnedPass[1];
                PassDecrypt = Reverse(PassDecrypt);

                Random r = new Random();
                string RanPass = "";
                foreach (char c in PassDecrypt)///G/o/o/g/l/e/1/5/3/1
                {
                    RanPass += Convert.ToString(Convert.ToChar(r.Next(1, 122))) + c;
                }
                MessageBox.Show(RanPass);
                writingText = PassEncrypt + "\r\a" + RanPass;
                File.WriteAllText(path, writingText.ToString());
                MessageBox.Show("Password is successfully created for Admin Account");
                this.Close();
              
            }


        }

    }
}
