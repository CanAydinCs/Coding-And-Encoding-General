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

namespace Coding_and_Encoding
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        Dictionary<int, char> sayi_karakter;
        Dictionary<char, int> karakter_sayi;

        List<int> a;
        List<int> b;
        List<int> c;

        private void Form1_Load(object sender, EventArgs e)
        {
            a = new List<int>();
            b = new List<int>();
            c = new List<int>();

            sayi_karakter = new Dictionary<int, char>();
            karakter_sayi = new Dictionary<char, int>();
            StreamReader karsılıkları_oku = new StreamReader(Application.StartupPath + "\\passwords.txt");

            List<string> kelimeler = new List<string>();
            string satir = karsılıkları_oku.ReadLine();
            while(satir != null && satir != "")
            {
                kelimeler.Add(satir);
                satir = karsılıkları_oku.ReadLine();
            }

            karsılıkları_oku.Close();

            foreach (string item in kelimeler)
            {
                int sayi = Convert.ToInt32(item.Split('-')[1]);
                char karakter = Convert.ToChar(item.Split('-')[0]);

                sayi_karakter.Add(sayi, karakter);
                karakter_sayi.Add(karakter, sayi);
            }


            StreamReader ucgenleri_oku = new StreamReader(Application.StartupPath + "\\triangles.txt");
            List<string> kelimeler2 = new List<string>();
            satir = ucgenleri_oku.ReadLine();
            while(satir != null && satir != "")
            {
                kelimeler2.Add(satir);
                satir = ucgenleri_oku.ReadLine();
            }

            ucgenleri_oku.Close();

            foreach (string item in kelimeler2)
            {
                string kelime = item.Split(';')[0];

                a.Add(Convert.ToInt32(kelime.Split(',')[0]));
                b.Add(Convert.ToInt32(kelime.Split(',')[1]));
                c.Add(Convert.ToInt32(item.Split(';')[1]));
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text == null || richTextBox1.Text == "")
            {
                MessageBox.Show("Lütfen İlk Kutucuğu Doldurunuz!");
            }
            else
            {
                richTextBox2.Text = "";
                List<string> satirlar = new List<string>();

                foreach (string i in richTextBox1.Lines)
                    satirlar.Add(i);

                for (int i = 0; i < satirlar.Count; i++)
                {
                    foreach (char item in satirlar[i])
                    {
                        if(item == ' ')
                        {
                            richTextBox2.Text += " -";
                            continue;
                        }
                        int sayi_degeri = karakter_sayi[item];

                        List<int> a_degerleri = new List<int>();
                        List<int> b_degerleri = new List<int>();

                        for (int j = 0; j < c.Count; j++)
                        {
                            if(sayi_degeri == c[j])
                            {
                                a_degerleri.Add(a[j]);
                                b_degerleri.Add(b[j]);
                            }
                        }

                        Random rastgele = new Random();

                        bool karar = rastgele.Next(0, 2) == 0;
                        int ilk_deger = rastgele.Next(0, a_degerleri.Count);
                        int ikinci_deger = rastgele.Next(0, a_degerleri.Count);

                        while (ilk_deger == ikinci_deger)
                            ikinci_deger = rastgele.Next(0, a_degerleri.Count);

                        richTextBox2.Text += (karar) ?
                            (a_degerleri[ilk_deger] + "a" + a_degerleri[ikinci_deger] + "-") :
                            (b_degerleri[ilk_deger] + "b" + b_degerleri[ikinci_deger] + "-");
                    }
                    if(i < satirlar.Count - 1)
                        richTextBox2.Text += "\n";
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox4.Text == "" || richTextBox4.Text == null)
                {
                    MessageBox.Show("Lütfen Gerekli Alanı Doldurunuz!");
                }
                else
                {
                    richTextBox3.Text = "";
                    List<string> satirlar = new List<string>();

                    foreach (string item in richTextBox4.Lines)
                        satirlar.Add(item);

                    for (int i = 0; i < satirlar.Count; i++)
                    {
                        foreach (string item in satirlar[i].Split('-'))
                        {
                            int cdeger = 0;

                            if (item.Contains("a"))
                            {
                                int sayi1 = Convert.ToInt32(item.Split('a')[0]);
                                int sayi2 = Convert.ToInt32(item.Split('a')[1]);

                                int s1, s2;

                                List<int> allIndex1 = new List<int>();
                                List<int> allIndex2 = new List<int>();

                                for (int j = 0; j < a.Count; j++)
                                    if (a[j] == sayi1)
                                        allIndex1.Add(j);

                                for (int j = 0; j < a.Count; j++)
                                    if (a[j] == sayi2)
                                        allIndex2.Add(j);


                                foreach (int it1 in allIndex1)
                                {
                                    foreach (int it2 in allIndex2)
                                    {
                                        s1 = c[it1];
                                        s2 = c[it2];

                                        if (s1 == s2)
                                        {
                                            cdeger = c[it1];
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (item.Contains("b"))
                            {
                                int sayi1 = Convert.ToInt32(item.Split('b')[0]);
                                int sayi2 = Convert.ToInt32(item.Split('b')[1]);

                                int s1, s2;

                                List<int> allIndex1 = new List<int>();
                                List<int> allIndex2 = new List<int>();

                                for (int j = 0; j < b.Count; j++)
                                    if (b[j] == sayi1)
                                        allIndex1.Add(j);

                                for (int j = 0; j < b.Count; j++)
                                    if (b[j] == sayi2)
                                        allIndex2.Add(j);


                                foreach (int it1 in allIndex1)
                                {
                                    foreach (int it2 in allIndex2)
                                    {
                                        s1 = c[it1];
                                        s2 = c[it2];

                                        if (s1 == s2)
                                        {
                                            cdeger = c[it1];
                                            break;
                                        }
                                    }
                                }
                            }
                            else if (cdeger == 0)
                            {
                                richTextBox3.Text += " ";
                                continue;
                            }

                            richTextBox3.Text += sayi_karakter[cdeger];
                        }
                        if (i < satirlar.Count - 1)
                            richTextBox3.Text += "\n";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş Yapıldı! Tekrar Deneyiniz!");
                richTextBox3.Text = "";
                richTextBox4.Text = "";
            }
        }
    }
}
