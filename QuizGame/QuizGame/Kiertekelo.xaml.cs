using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizGame
{
    class Jatekos_sajat
    {
        public string nev { get; set; }
        public int elertpontszam_sima { get; set; }
        public int elertpontszam { get; set; }
        public int legjobbpontszam_sima { get; set; }
        public int legjobbpontszam { get; set; }
        public Jatekos_sajat(string sor)
        {
            string[] adatok = sor.Split(';');
            nev = adatok[0];
            elertpontszam_sima = Convert.ToInt32(adatok[1]);
            legjobbpontszam_sima = Convert.ToInt32(adatok[2]);
            elertpontszam = Convert.ToInt32(adatok[3]);
            legjobbpontszam = Convert.ToInt32(adatok[4]);
        }
    }

    public partial class Kiertekelo : Page
    {
        private bool tobbkerdes_vagy_sem = Fomenu.helyesvalaszoktobbvagysem_helyzete;
        public Kiertekelo()
        {
            InitializeComponent();
            kiiratas();
            jatekosok_mentese_sajat(Fomenu.nev, Game.jo_valaszok_szama, Game.jo_valaszok_szama);
        }
        public void jatekosok_mentese_sajat(string jatekosneve, int a, int b)
        {  //hibakezeles kell, ha nincs semmi sem a fajlban
            List<Jatekos_sajat> eredmenyek = new List<Jatekos_sajat>();
            List<string> eredmenyeksima = new List<string>();
            string[] ures_v_sem = File.ReadAllLines("mentes.txt");
            if (ures_v_sem.Length == 0 || (ures_v_sem.Length == 1 && string.IsNullOrWhiteSpace(ures_v_sem[0])))
            {
                if (tobbkerdes_vagy_sem)
                {
                    eredmenyeksima.Add($"{jatekosneve};0;0;{a};{b}");//teljes sort ad hozzá a lista tipusanak megfeleloen
                }
                else
                {
                    eredmenyeksima.Add($"{jatekosneve};{a};{b};0;0");
                }
            }
            else
            {
                foreach (string sor in File.ReadAllLines("mentes.txt"))
                {
                    eredmenyek.Add(new Jatekos_sajat(sor));
                    eredmenyeksima.Add(sor);

                }
                var logika_bool = (eredmenyek.Any(n => n.nev == jatekosneve));//van-e ilyen nevu felhasznalo

                if (logika_bool)//ha van (true)
                {
                    var logika = (eredmenyek.Where(n => n.nev == jatekosneve).First());
                    var felhasznalo1 = eredmenyek.FindIndex(x => x.nev == jatekosneve);
                    if (tobbkerdes_vagy_sem)
                    {
                        if (logika.legjobbpontszam >= b)//ha a fajlba nagyobb az eredmeny akkor marad
                        {
                            eredmenyeksima[felhasznalo1] = ($"{jatekosneve};{logika.elertpontszam_sima};{logika.legjobbpontszam_sima};{a};{logika.legjobbpontszam}");
                        }
                        else
                        {
                            eredmenyeksima[felhasznalo1] = ($"{jatekosneve};{logika.elertpontszam_sima};{logika.legjobbpontszam_sima};{a};{b}");
                        }
                    }
                    else
                    {
                        if (logika.legjobbpontszam_sima >= b)//ha a fajlba nagyobb az eredmeny akkor marad
                        {
                            eredmenyeksima[felhasznalo1] = ($"{jatekosneve};{a};{logika.legjobbpontszam_sima};{logika.elertpontszam};{logika.legjobbpontszam}");
                        }
                        else
                        {
                            eredmenyeksima[felhasznalo1] = ($"{jatekosneve};{a};{b};{logika.elertpontszam};{logika.legjobbpontszam}");
                        }
                    }
                }//ha nincs
                else
                {
                    if (tobbkerdes_vagy_sem)
                    {
                        eredmenyeksima.Add($"{jatekosneve};0;0;{a};{b}");//teljes sort ad hozzá a lista tipusanak megfeleloen
                    }
                    else
                    {
                        eredmenyeksima.Add($"{jatekosneve};{a};{b};0;0");
                    }
                }
            }
            File.WriteAllLines("mentes.txt", eredmenyeksima);
        }
        public void kiiratas()
        {
            List<Jatekos_sajat> eredmenyek = new List<Jatekos_sajat>();
            foreach (var sor in File.ReadAllLines("mentes.txt"))
            {
                eredmenyek.Add(new Jatekos_sajat(sor));
            }
            var logika_bool = (eredmenyek.Any(n => n.nev == Fomenu.nev));
            if (logika_bool)
            {
                var logika = (eredmenyek.Where(n => n.nev == Fomenu.nev).First());
                elert_pontszam.Content = "Elért pontszám: " + logika.elertpontszam_sima.ToString();
                elert_ponszamok.Content = "Elért ponszám (több válasz): " + logika.elertpontszam.ToString();
                legjobb_pontszam.Content = "Legjobb eredmény: " + logika.legjobbpontszam_sima.ToString();
                legjobb_ponszamok.Content = "Legjobb eredmény  (több válasz): " + logika.legjobbpontszam.ToString();
                felh_nev.Content = logika.nev;
            }
            else
            {
                aaa.Content = "Nincs még ilyen felhasználó.";
            }
        }

        private void Vissza(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Fomenu());
        }
    }
}
