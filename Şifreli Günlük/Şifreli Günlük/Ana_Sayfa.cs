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
    public partial class Ana_Sayfa : Form
    {
        public Ana_Sayfa()
        {
            InitializeComponent();
        }

        private void Gonder(string dosya_adi,bool var)
        {
            StreamWriter yaz = new StreamWriter(Application.StartupPath + "\\Sistem Dosyaları\\secili");
            yaz.WriteLine(dosya_adi);
            yaz.Close();

            StreamWriter kontrol = new StreamWriter(Application.StartupPath + "\\Sistem Dosyaları\\var");
            if (var)
            {
                kontrol.WriteLine(1);
            }
            else
            {
                kontrol.WriteLine(0);
            }
            kontrol.Close();

            Diary dt = new Diary();
            dt.Show();
            this.Hide();

            dt.Text = dosya_adi;
        }

        private void Ana_Sayfa_Load(object sender, EventArgs e)
        {
            string[] dosyalar = Directory.GetFiles(Application.StartupPath + "\\Notlar");

            foreach (string notlar in dosyalar)
            {
                DirectoryInfo dir = new DirectoryInfo(notlar);
                if (dir.Name.EndsWith(".txt"))
                {
                    listBox1.Items.Add(dir.Name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex > -1)
            {
                Gonder(listBox1.SelectedItem.ToString(),true);
            }
            else
            {
                MessageBox.Show("Alttaki listeden bir kayıt seçiniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] dosyalar = Directory.GetFiles(Application.StartupPath + "\\Notlar");
            bool kontrol = true;

            foreach (string notlar in dosyalar)
            {
                DirectoryInfo dir = new DirectoryInfo(notlar);
                if (dir.Name.EndsWith(".txt") && dir.Name == textBox1.Text + ".txt")
                {
                    kontrol = false; break;
                } 
            }

            if (kontrol)
            {
                File.CreateText(Application.StartupPath + "\\Notlar\\" + textBox1.Text + ".txt");
                Gonder(textBox1.Text,false);
            }
            else
            {
                MessageBox.Show("Zaten böyle bir kayıt bulunuyor. Başka bir isim giriniz!");
            }
        }

        private void Ana_Sayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
