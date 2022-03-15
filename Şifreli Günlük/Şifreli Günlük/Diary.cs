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
    public partial class Diary : Form
    {
        public Diary()
        {
            InitializeComponent();
        }

        private void Yukle()
        {
            StreamReader metin = new StreamReader(dosya_yolu);
            richTextBox1.Text = "";
            string satir = metin.ReadLine();
            while (satir != "" && satir != null)
            {
                CodingAndEncoding cd = new CodingAndEncoding();
                richTextBox1.Text += cd.Cozumle(satir) + "\n";
                satir = metin.ReadLine();
            }

            metin.Close();
        }

        string dosya_yolu;
        string dosya_adi;

        private void Diary_Load(object sender, EventArgs e)
        {
            StreamReader dosyaOku = new StreamReader(Application.StartupPath + "\\Sistem Dosyaları\\secili");
            dosya_adi = dosyaOku.ReadLine();
            dosyaOku.Close();

            StreamReader var = new StreamReader(Application.StartupPath + "\\Sistem Dosyaları\\var");
            bool kontrol = var.ReadLine().Equals("1");
            var.Close();

            foreach (string notlar in Directory.GetFiles(Application.StartupPath + "\\Notlar"))
            {
                DirectoryInfo dir = new DirectoryInfo(notlar);

                if (dir.Name.EndsWith(dosya_adi))
                {
                    dosya_yolu = notlar;
                }
            }

            if (kontrol)
            {
                Yukle();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodingAndEncoding cd = new CodingAndEncoding();
            string[] sifreli = new string[richTextBox1.Lines.Length];

            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                sifreli[i] = cd.Sifrele(richTextBox1.Lines[i]);
            }

            StreamWriter yaz = new StreamWriter(dosya_yolu);
            foreach (string satir in sifreli)
            {
                yaz.WriteLine(satir);
            }
            yaz.Close();
            MessageBox.Show("Kayıt Başarılı!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ana_Sayfa anasay = new Ana_Sayfa();
            anasay.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Yukle();
        }

        private void Diary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
