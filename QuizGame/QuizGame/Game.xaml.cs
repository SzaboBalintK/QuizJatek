using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
    class Kerdesek
    {

        public int id { get; set; }
        public string kerdes { get; set; }
        public string helyesvalasz { get; set; }
        public string valasz2 { get; set; }
        public string valasz3 { get; set; }
        public string ido { get; set; }
        public string tema { get; set; }

        public Kerdesek (string sor)
        {
            string[] adatok = sor.Split(';');
            id = Convert.ToInt32(adatok[0]);
            kerdes = adatok[1];
            helyesvalasz = adatok[2];
            valasz2 = adatok[3];
            valasz3 = adatok[4];
            ido = adatok[5];
            tema = adatok[6];
        }
    }
    public partial class Game : Page
    {
        public static bool win;
        public static bool megy = true;
        public Game()
        {
            InitializeComponent();

            List<Kerdesek> osszkerdes = new List<Kerdesek>();
            foreach (string sor in File.ReadAllLines("teszt.txt"))
            {
                osszkerdes.Add(new Kerdesek(sor));
            }
            Random rnd = new Random();
            int randomid = rnd.Next(0, 0);

            kerdes_txt.Text = osszkerdes[0].kerdes;
            valasz_elsoeleme.Content = osszkerdes[0].helyesvalasz;
            valasz_masodikeleme.Content = osszkerdes[0].valasz2;
            valasz_harmadikeleme.Content = osszkerdes[0].valasz3;

        }

        private void vissza_gomb(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void helyes_valasz(object sender, RoutedEventArgs e)
        {
            valasz_elsoeleme.Background = Brushes.Green;
            valasz_masodikeleme.Background = Brushes.Red;
            valasz_harmadikeleme.Background = Brushes.Red;
            win = true;
            megy = false;


            if (megy == false)
            {
                MessageBox.Show("Vége!");
                valasz_elsoeleme.IsEnabled = false;
                valasz_masodikeleme.IsEnabled = false;
                valasz_harmadikeleme.IsEnabled = false;
            }
        }

        private void rossz1_valasz(object sender, RoutedEventArgs e)
        {
            valasz_elsoeleme.Background = Brushes.Green;
            valasz_masodikeleme.Background = Brushes.IndianRed;
            valasz_harmadikeleme.Background = Brushes.Red;
            win = false;
            megy = false;


            if (megy == false)
            {
                MessageBox.Show("Vége!");
                valasz_elsoeleme.IsEnabled = false;
                valasz_masodikeleme.IsEnabled = false;
                valasz_harmadikeleme.IsEnabled = false;
            }
        }

        private void rossz2_valasz(object sender, RoutedEventArgs e)
        {
            valasz_elsoeleme.Background = Brushes.Green;
            valasz_masodikeleme.Background = Brushes.Red;
            valasz_harmadikeleme.Background = Brushes.IndianRed;
            win = false;
            megy = false;


            if (megy == false)
            {
                MessageBox.Show("Vége!");
                valasz_elsoeleme.IsEnabled = false;
                valasz_masodikeleme.IsEnabled = false;
                valasz_harmadikeleme.IsEnabled = false;
            }
        }
    }
}
