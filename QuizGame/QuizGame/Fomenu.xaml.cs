using System;
using System.Collections.Generic;
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
    public partial class Fomenu : Page
    {
        public static string nev;
        public static string temanev;
        public static int korokszama;
        public static int hozzaad = 0;
        public static bool kerdesek_helyzete;
        public static bool helyesvalaszok_helyzete;
        public static bool helyesvalaszoktobbvagysem_helyzete;//ha false akkor csak 1 valasz
        //korokszamat at kell írni, mert valahol egy van
        public Fomenu()
        {
            InitializeComponent();
            hibauzenet.Visibility = Visibility.Hidden;
            //jatekos_nev.Text = "a"; //itt csak a tesztek miatt van itt
            allatok.Visibility = Visibility.Hidden;
            zene.Visibility = Visibility.Hidden;
            mitosz.Visibility = Visibility.Hidden;
            egy_valasz_helyes.Visibility = Visibility.Hidden;
            tobb_valasz_helyes.Visibility = Visibility.Hidden;
            kerdesek_label.Content = "Játékos Neve:";
        }
        private void mitosz_click(object sender, RoutedEventArgs e)
        {
            if (kerdesek_helyzete == false)
            {
                temanev = "mitologia";
                kerdesekszama_kerdes();
            }
            else
            {
                korokszama = 5;
                eltunnek();
            }
        }

        private void zene_click(object sender, RoutedEventArgs e)
        {
            if (kerdesek_helyzete == false)
            {
                temanev = "zene";
                kerdesekszama_kerdes();
            }
            else
            {
                korokszama = 8;
                eltunnek();
            }
        }
        private void allatok_click(object sender, RoutedEventArgs e)
        {
            if (kerdesek_helyzete == false)
            {
                temanev = "allatok";
                kerdesekszama_kerdes();
            }
            else
            {
                korokszama = 10;
                eltunnek();
            }
        }
        private void kerdesekszama_kerdes()
        {
            kerdesek_label.Content = "Helyes Válaszok Száma:";
            kerdesek_label.Width = 127;
            egy_valasz_helyes.Margin = new Thickness(45, 0, -250, 0);
            mitosz.Visibility = Visibility.Hidden;
            zene.Visibility = Visibility.Hidden;
            allatok.Visibility = Visibility.Hidden;
            egy_valasz_helyes.Visibility = Visibility.Visible;
            tobb_valasz_helyes.Visibility = Visibility.Visible;
            tobb_valasz_helyes.Margin = new Thickness(-60, 0, 30, 0);
            kerdesek_helyzete = true;

        }
        private void korokszama_kerdes()
        {
            mitosz.Visibility = Visibility.Visible;
            zene.Visibility = Visibility.Visible;
            allatok.Visibility = Visibility.Visible;
            egy_valasz_helyes.Visibility = Visibility.Hidden;
            tobb_valasz_helyes.Visibility = Visibility.Hidden;
            kerdesek_label.Width = 95;
            kerdesek_label.Content = "Kérdések Száma:";
            mitosz.Content = "5";
            zene.Content = "8";
            allatok.Content = "10";
            kerdesek_helyzete = true;

        }
        private void eltunnek()
        {
            NavigationService.Navigate(new Game());
        }
        private void nev_tovabblepes(object sender, RoutedEventArgs e)
        {
            nev = jatekos_nev.Text;
            if (String.IsNullOrWhiteSpace(nev) != true && nev.Contains(";") != true/* && nev.Length <= 15*/)
            {
                allatok.Visibility = Visibility.Visible;
                zene.Visibility = Visibility.Visible;
                mitosz.Visibility = Visibility.Visible;
                nev_tovabb.Visibility = Visibility.Hidden;
                jatekos_nev.Visibility = Visibility.Hidden;
                hibauzenet.Visibility = Visibility.Hidden;
                kerdesek_label.Content = "Témakör Választás:";
            }
            else if (String.IsNullOrWhiteSpace(nev))
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Adj meg betűket f.névhez!";
            }
            //ez kesobb lehet kell
            /*else if (!String.IsNullOrWhiteSpace(nev) && nev.Length > 15)
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Rövidebb f.nevet adj meg!";
            }*/
            if (nev.Contains(";"))
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Nem lehet benne ilyen karakter! (';')";
            }
        }
        private void Egy_valasz_click(object sender, RoutedEventArgs e)
        {
            helyesvalaszoktobbvagysem_helyzete = false;
            korokszama_kerdes();
        }
        private void tobb_valasz_click(object sender, RoutedEventArgs e)
        {
            helyesvalaszoktobbvagysem_helyzete = true;
            korokszama_kerdes();
        }
    }
}