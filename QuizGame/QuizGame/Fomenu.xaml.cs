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
            jatekos_nev.Text = "a"; //itt csak a tesztek miatt van itt
            allatok.Visibility = Visibility.Hidden;
            zene.Visibility = Visibility.Hidden;
            mitosz.Visibility = Visibility.Hidden;
            kerdesek_label.Content = "Játékos Neve:";
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
                eltunnek();
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
                eltunnek();
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
                eltunnek();
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
        private void eltunnek()
        {
            NavigationService.Navigate(new Game());
        }

        private void nev_tovabblepes(object sender, RoutedEventArgs e)
        {
            nev = jatekos_nev.Text;
            if (String.IsNullOrWhiteSpace(nev) != true && nev.Contains(";") != true)
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
            if (nev.Contains(";"))
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Nem lehet benne ilyen karakter! (';')";
            }
        }
    }
}