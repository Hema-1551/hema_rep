using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void button1_Click(object sender, EventArgs e)
        {
        
            Clipboard.SetText(Password);
            this.Dispose();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += Password;
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
