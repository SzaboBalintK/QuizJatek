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
        public static bool kerdesek_helyzete;
        public Fomenu()
        {
            InitializeComponent();
            hibauzenet.Visibility = Visibility.Hidden;
            jatekos_nev.Text = "a";
        }

        private void next_btn(object sender, RoutedEventArgs e)
        {
            nev = jatekos_nev.Text;
            if(String.IsNullOrWhiteSpace(nev) != true && nev.Contains(";") != true && String.IsNullOrWhiteSpace(temanev) == false && korokszama >= 10)
            {
            NavigationService.Navigate(new Game());
            }
            if (String.IsNullOrWhiteSpace(temanev) && String.IsNullOrWhiteSpace(nev))
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Nincs téma kiválasztva!\nNincs f.név megadva!";
            }
            else if (String.IsNullOrWhiteSpace(nev))
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Adj meg betűket f.névhez!";
            }
            else if (String.IsNullOrWhiteSpace(temanev))
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Nincs téma kiválasztva!";
            }
            if (nev.Contains(";"))
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Nem lehet benne ilyen karakter! (';')";
            }
            if(korokszama <= 10)
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Válassz egy számot!";
            }



        }
        private void mitosz_click(object sender, RoutedEventArgs e)
        {
            if (kerdesek_helyzete == false)
            {
                temanev = "mitologia";
                korokszama_kerdes();
            }
            else
            {
                korokszama = 10;
            }

        }

        private void zene_click(object sender, RoutedEventArgs e)
        {
            if (kerdesek_helyzete == false)
            {
                temanev = "zene";
                korokszama_kerdes();
            }
            else
            {
                korokszama = 15;
            }
        }

        private void allatok_click(object sender, RoutedEventArgs e)
        {
            if (kerdesek_helyzete == false)
            {
                temanev = "allatok";
                korokszama_kerdes();
            }
            else
            {
                korokszama = 20;
            }
        }

        private void korokszama_kerdes()
        {
            kerdesek_label.Content = "Kérdések Száma:";
            mitosz.Content = "10";
            zene.Content = "15";
            allatok.Content = "20";
            kerdesek_helyzete = true;
        }
    }
}
