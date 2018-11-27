using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        string Retrievedata, finalLength, finalD_encrypted = "", finalD_decrypted = "", finalBencrypted = "", finalBdecrypted = ""; byte[] encrypted;
        private string[] crypt = { "1", "2" };
        string finalAencrypt = "", finalAdecrypt = ""; string decrypted = "", BDecrypt = "", path = "", Lengthpath = "";
        string[] rowentery = new string[9];
        string[] RetrievedText,LengthsArray ,OneLengthArray= new string[9];
        AesManaged aes = new AesManaged();

        public Form2()
        {
            InitializeComponent();


            path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            path = path + @"\" + "WindowsPasswordManager";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

            }
            path += @"\" + "PMLog.PWM";
            Lengthpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            Lengthpath = Lengthpath + @"\" + "WindowsPasswordManager";
            if (!Directory.Exists(Lengthpath))
            {
                Directory.CreateDirectory(path);

            }
            Lengthpath += @"\" + "Length.txt";
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }
        string[] EncryptAesManaged(string raw1)
        {
            string variable = "";
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
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        string[] abc = new string[9];

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 redirect = new Form1();
            redirect.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            slno = 0;
            bunifuCustomDataGrid1.Rows.Clear();
            Retrievedata = File.ReadAllText(path);
            string LengthsData = File.ReadAllText(Lengthpath);

            RetrievedText = Regex.Split(Retrievedata, "\r\n");

            LengthsArray = Regex.Split(LengthsData, "\a\b");

            int i = CountStringOccurrences(LengthsData, "\a\b");
            string[][] row = new string[10][];

            for (int j = 0; j < RetrievedText.Length - 1; j++)
            {
                for (int k = 0; k < 6; k++)
                {
                    row[k] = Regex.Split(LengthsArray[j], "\t");
                    // MessageBox.Show(Convert.ToString(row[j][k]));
                    //MessageBox.Show("Reterived tedt:: "+RetrievedText[j]);
                    //MessageBox.Show("Lengths Array:: ["+j+" ]"+ LengthsArray[j]);
                    //MessageBox.Show("One Length:: [" + j + " ]" + OneLengthArray[j]);
                }
                SavRetrieve(RetrievedText[j], row[j]);
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {

            string a = textBox1.Text, b = textBox2.Text;
            string[] finalA, finalB, finalDate1;
            string finalText = "";
            DateTime date = DateTime.Now;
            string date1 = Convert.ToString(date);
            ///CALLING FUNCTION
            if (a.Length > 0 && b.Length > 0)
            {
                finalA = EncryptAesManaged(a);
                finalAencrypt = finalA[0];
                finalAdecrypt = finalA[1];
                finalAdecrypt = Reverse(finalAdecrypt);
                finalB = EncryptAesManaged(b);
                finalBencrypted = finalB[0];
                finalBdecrypted = finalB[1];
                finalBdecrypted = Reverse(finalBdecrypted);

                finalDate1 = EncryptAesManaged(date1);
                finalD_encrypted = finalDate1[0];
                finalD_decrypted = finalDate1[1];
                finalD_decrypted = Reverse(finalD_decrypted);

                // finalText += finalD_encrypted + finalD_encrypted.Length + finalD_decrypted + finalD_decrypted.Length + finalBencrypted + finalBencrypted.Length + finalBdecrypted + finalBdecrypted.Length + finalAencrypt + finalAencrypt.Length + finalAdecrypt + finalAdecrypt.Length;

                finalText = finalD_encrypted + finalD_decrypted + finalBencrypted + finalBdecrypted + finalAencrypt + finalAdecrypt + "\r\n";
                finalLength = Convert.ToString(finalD_encrypted.Length) + "\t" + finalD_decrypted.Length + "\t" + finalBencrypted.Length + "\t" + finalBdecrypted.Length + "\t" + finalAencrypt.Length + "\t" + finalAdecrypt.Length + "\a\b";
                // MessageBox.Show(finalText);
            }
            else
            {
                MessageBox.Show("Make sure Domain and Password are given");
            }

            try
            {
                File.AppendAllText(path, finalText);
                File.AppendAllText(Lengthpath, finalLength);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
          if (checkBox2.Checked)
            {
                for (int i = 0; i < bunifuCustomDataGrid1.RowCount; i++)
                {
                    bunifuCustomDataGrid1.Rows[i].Cells[2].Value = "";
                }
            }
            else
            {
                for (int i = 0; i < bunifuCustomDataGrid1.RowCount - 1; i++)
                {
                    bunifuCustomDataGrid1.Rows[i].Cells[2].Value = abc[i];
                }
            }
           

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

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path, String.Empty);
            File.WriteAllText(Lengthpath, String.Empty);

        }
        private int CountStringOccurrences(string text, string pattern)//CCCCCCCCCCCCCCCCCCCCCCC
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                OneLengthArray = Regex.Split(LengthsArray[count], "\t");
               // MessageBox.Show(OneLengthArray[count]);
                count++;
            }
            return count;
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
        void DataEntries(string domain, string password, string dateAndTime)
        {
            try
            {
                string[] rowentery = { Convert.ToString(slno), domain, password, dateAndTime };
                bunifuCustomDataGrid1.Rows.Add(rowentery);
               
                textBox1.Text = null; textBox2.Text = null;
                slno++;
              for (int i = 0; i < bunifuCustomDataGrid1.RowCount-1; i++)
                {
                    abc[i] = Convert.ToString(bunifuCustomDataGrid1.Rows[i].Cells[2].Value);
                }
            }
            catch(Exception Ex) 
            {   
                MessageBox.Show(Ex.Message);
            }
        }
       void VieRetrieve(string str)
        {
            //finaltext
            string da = str.Substring(finalD_encrypted.Length, finalD_decrypted.Length);
            da = Reverse(da);
            BDecrypt = str.Substring(finalBencrypted.Length + finalD_encrypted.Length + finalD_decrypted.Length, finalBdecrypted.Length);
            BDecrypt = Reverse(BDecrypt);
            string ADecrypt = str.Substring(finalBencrypted.Length + finalBdecrypted.Length + finalD_encrypted.Length + finalD_decrypted.Length + finalAencrypt.Length, finalAdecrypt.Length);
            ADecrypt = Reverse(ADecrypt);
            if (textBox1.Text != "" && textBox2.Text != "")
            { 
                DataEntries(ADecrypt, BDecrypt, da);
            }
        }
        void SavRetrieve(string str,string[] row)
        {
            string da = str.Substring(Convert.ToInt16(row[0]), Convert.ToInt16(row[1]));
            da = Reverse(da);
            BDecrypt = str.Substring(Convert.ToInt16(row[0])+ Convert.ToInt16(row[1])+ Convert.ToInt16(row[2]), Convert.ToInt16(row[3]));
            BDecrypt = Reverse(BDecrypt);
            
            string ADecrypt = str.Substring(Convert.ToInt16(row[0]) + Convert.ToInt16(row[1]) + Convert.ToInt16(row[2])+Convert.ToInt16(row[4])+Convert.ToInt16(row[3]), Convert.ToInt16(row[5]));
            ADecrypt = Reverse(ADecrypt);
            //if (textBox1.Text != "" && textBox2.Text != "")
            {
                DataEntries(ADecrypt, BDecrypt, da);
            }
        }
        int slno = 0;

        
    }
}

