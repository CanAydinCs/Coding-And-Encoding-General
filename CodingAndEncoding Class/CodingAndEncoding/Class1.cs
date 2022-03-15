using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAndEncoding
{
    public class CodingEncoding
    {
        private static Dictionary<char, int> kelime_sayi = new Dictionary<char, int>();
        private static Dictionary<int, char> sayi_kelime = new Dictionary<int, char>();

        private static List<int> a = new List<int>(), b = new List<int>(), c = new List<int>();

        public void Yukleme(string yolum)
        {
            string sifre = yolum + "\\Sistem Dosyaları\\passwords.txt";
            string triangles = yolum + "\\Sistem Dosyaları\\triangles.txt";

            List<string> kelime1 = new List<string>();
            StreamReader oku1 = new StreamReader(triangles);

            string satir = oku1.ReadLine();
            while (satir != null && satir != "")
            {
                kelime1.Add(satir);
                satir = oku1.ReadLine();
            }
            oku1.Close();

            foreach (string item in kelime1)
            {
                c.Add(Convert.ToInt32(item.Split(';')[1]));
                a.Add(Convert.ToInt32(item.Split(';')[0].Split(',')[0]));
                b.Add(Convert.ToInt32(item.Split(';')[0].Split(',')[1]));
            }

            StreamReader oku2 = new StreamReader(sifre);
            List<string> kelime2 = new List<string>();
            satir = oku2.ReadLine();
            while (satir != null && satir != "")
            {
                kelime2.Add(satir);
                satir = oku2.ReadLine();
            }
            oku2.Close();

            foreach (string item in kelime2)
            {
                char kelime = Convert.ToChar(item.Split('-')[0]);
                int sayi = Convert.ToInt32(item.Split('-')[1]);

                kelime_sayi.Add(kelime, sayi);
                sayi_kelime.Add(sayi, kelime);
            }
        }

        public override int GetHashCode()
        {
            return 519;
        }

        public string Sifrele(string kelime)
        {
            string sifre = "";

            foreach (char item in kelime)
            {
                if (item.ToString() == "\n")
                {
                    sifre += "\n";
                }
                else if (item == ' ')
                {
                    sifre += " ";
                }
                else
                {
                    int deger = kelime_sayi[item];

                    Random rastgele = new Random();

                    List<int> na = new List<int>(), nb = new List<int>();

                    for (int i = 0; i < c.Count; i++)
                    {
                        if (deger == c[i])
                        {
                            na.Add(a[i]);
                            nb.Add(b[i]);
                        }
                    }

                    int sayi1, sayi2;
                    char orta = '1';

                    if (rastgele.Next(0, 2) == 0)
                    {
                        sayi1 = na[rastgele.Next(0, na.Count)];
                        sayi2 = na[rastgele.Next(0, na.Count)];
                        orta = 'a';
                    }
                    else
                    {
                        sayi1 = nb[rastgele.Next(0, nb.Count)];
                        sayi2 = nb[rastgele.Next(0, nb.Count)];
                        orta = 'b';
                    }

                    sifre += sayi1.ToString() + orta.ToString() + sayi2.ToString();
                }
                sifre += "-";
            }
            return sifre;
        }

        public string Cozumle(string sifre)
        {
            string kelime = "";
            int say = sifre.Split('-').Length;

            foreach (string item in sifre.Split('-'))
            {
                if (item == " " || item == "\n" || item == "")
                {
                    kelime += item;
                }
                else
                {
                    say--;
                    if (say == 0) break;

                    char deger = item.Contains("a") ? 'a' : 'b';

                    int ilkDeger, ikinciDeger;
                    ilkDeger = Convert.ToInt32(item.Split(deger)[0]);
                    ikinciDeger = Convert.ToInt32(item.Split(deger)[1]);

                    List<int> allIndex1 = new List<int>(), allIndex2 = new List<int>();

                    if (deger == 'a')
                    {
                        for (int j = 0; j < a.Count; j++)
                            if (a[j] == ilkDeger)
                                allIndex1.Add(j);
                        for (int j = 0; j < a.Count; j++)
                            if (a[j] == ikinciDeger)
                                allIndex2.Add(j);
                    }
                    else
                    {
                        for (int j = 0; j < b.Count; j++)
                            if (b[j] == ilkDeger)
                                allIndex1.Add(j);
                        for (int j = 0; j < b.Count; j++)
                            if (b[j] == ikinciDeger)
                                allIndex2.Add(j);
                    }

                    int csayisi = 0;
                    foreach (int ilk in allIndex1)
                    {
                        foreach (int ikinci in allIndex2)
                        {
                            if (c[ilk] == c[ikinci])
                            {
                                csayisi = c[ilk]; break;
                            }
                        }
                    }

                    kelime += sayi_kelime[csayisi];

                }
            }

            return kelime;
        }
    }
}
