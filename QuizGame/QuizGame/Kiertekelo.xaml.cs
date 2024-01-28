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
    { private bool tobbkerdes_vagy_sem = Fomenu.helyesvalaszoktobbvagysem_helyzete;
        public Kiertekelo()
        {
            InitializeComponent();
            
            elert_pontszam.Content = "Elért pontszám: " + Game.jo_valaszok_szama.ToString();
            jatekosok_mentese_sajat(Fomenu.nev, Game.jo_valaszok_szama, Game.jo_valaszok_szama);
        }
        public void jatekosok_mentese_sajat(string jatekosneve, int a, int b)
        {  //hibakezeles kell, ha nincs semmi sem a fajlban
            List<Jatekos_sajat> eredmenyek = new List<Jatekos_sajat>();
            List<string> eredmenyeksima = new List<string>();
            //int a = File.ReadAllLines("mentes.txt").Length;
            foreach (string sor in File.ReadAllLines("mentes.txt"))
            {
                eredmenyek.Add(new Jatekos_sajat(sor));
                eredmenyeksima.Add(sor);

            }
            var logika_bool = (eredmenyek.Any(n => n.nev == jatekosneve));//van-e ilyen nevu felhasznalo
            

            if (logika_bool)//ha van (true)
            {   var logika = (eredmenyek.Where(n => n.nev == jatekosneve).First());
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
            File.WriteAllLines("mentes.txt", eredmenyeksima);
        }
    }
}
