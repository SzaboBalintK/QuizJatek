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
        public int elertpontszam { get; set; }
        public int legjobbpontszam { get; set; }
        public Jatekos_sajat(string sor)
        {
            string[] adatok = sor.Split(';');
            nev = adatok[0];
            elertpontszam = Convert.ToInt32(adatok[1]);
            legjobbpontszam = Convert.ToInt32(adatok[2]);
        }
    }

    public partial class Kiertekelo : Page
    {
        public Kiertekelo()
        {
            InitializeComponent();
            elert_pontszam.Content = "Elért pontszám: " + Game.jo_valaszok_szama.ToString();
            //jatekosok_mentese_sajat(Fomenu.nev, Game.jo_valaszok_szama, Game.jo_valaszok_szama);
        }
        public void jatekosok_mentese_sajat(string jatekosneve, int a, int b)
        {
            List<Jatekos_sajat> eredmenyek = new List<Jatekos_sajat>();
            List<string> eredmenyeksima = new List<string>();
            var logika = (eredmenyek.Where(n => n.nev == jatekosneve).First());
            foreach (string sor in File.ReadAllLines("mentes.txt"))
            {
                eredmenyek.Add(new Jatekos_sajat(sor));
                eredmenyeksima.Add(sor);

            }
            /*var felhasznalo = eredmenyek.Find(x => x.nev == jatekosneve);
            var felhasznalo1 = eredmenyek.FindIndex(x => x.nev == jatekosneve);
            if (felhasznalo != null)
            {
                eredmenyeksima[felhasznalo1] = ($"{jatekosneve};{a};{b}");
            }
            else
            {
                eredmenyeksima.Add($"{jatekosneve};{a};{b}");
            }*/
            if (logika != null)
            {
                if (logika.legjobbpontszam >= b)
                { eredmenyeksima.Add($"{jatekosneve};{a};{logika.legjobbpontszam}"); }
                else
                {
                    eredmenyeksima.Add($"{jatekosneve};{a};{b}");
                }
            }
            else
            {
                eredmenyeksima.Add($"{jatekosneve};{a};{b}");
            }
            File.WriteAllLines("mentes.txt", eredmenyeksima);
        }
    }
}
