using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Şifreli_Günlük
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodingAndEncoding cd = new CodingAndEncoding();
            StreamReader oku = new StreamReader(Application.StartupPath + "\\Sistem Dosyaları\\password");

            string sifre = cd.Cozumle(oku.ReadLine());
            oku.Close();

            if(sifre == textBox1.Text)
            {
                MessageBox.Show("Şifre doğru girildi!");
                Ana_Sayfa anasay = new Ana_Sayfa();
                anasay.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Şifre yanlış girildi!");
                textBox1.Text = "";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CodingAndEncoding cd = new CodingAndEncoding();
            cd.Yukleme(Application.StartupPath);
        }
    }
}
