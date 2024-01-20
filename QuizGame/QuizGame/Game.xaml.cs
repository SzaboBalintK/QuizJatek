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
        //0;Ki számít a nyugati klasszikus zene atyjának?;Josquin des Prez;Liszt Ferenc; Frederick Chopin;20;zene
        //0;Ki számít a nyugati klasszikus zene atyjának?;Josquin des Prez;Alma;Pite;20;zene
        public Kerdesek(string sor)
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
        //public static bool megy = true;
        public static int ido = 0;
        public static int current_kerdesek = 0;
        public static int all_keredesek = Fomenu.korokszama;
        public Game()
        {
            InitializeComponent();
            //42-es és a 23-as sor nincs

            List<Kerdesek> osszkerdes = new List<Kerdesek>();
            foreach (string sor in File.ReadAllLines("asd.txt"))
            {
                osszkerdes.Add(new Kerdesek(sor));
            }
            //Random rnd = new Random();
            //int randomid = rnd.Next(0, 0);

            /*kerdes_txt.Text = osszkerdes[0].kerdes;
            valasz_elsoeleme.Content = osszkerdes[0].helyesvalasz;
            valasz_masodikeleme.Content = osszkerdes[0].valasz2;
            valasz_harmadikeleme.Content = osszkerdes[0].valasz3;*/
            kerdesekszama.Content = Convert.ToString(current_kerdesek + "/" + all_keredesek);
            kerdesek_betolt();

        }

        private void vissza_gomb(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void helyes_valasz(object sender, RoutedEventArgs e)
        {
            //valasz_elsoeleme.Background = Brushes.Green;
            //valasz_masodikeleme.Background = Brushes.Red;
            //valasz_harmadikeleme.Background = Brushes.Red;
            //win = true;
            //megy = false;
            //gyoztelvnem(1);
            //gomblathatosag(megy);
            /*if (megy == false)
            {
                MessageBox.Show("Vége!");
                valasz_elsoeleme.IsEnabled = false;
                valasz_masodikeleme.IsEnabled = false;
                valasz_harmadikeleme.IsEnabled = false;
            }*/
        }

        private void rossz1_valasz(object sender, RoutedEventArgs e)
        {
            //valasz_elsoeleme.Background = Brushes.Green;
            //valasz_masodikeleme.Background = Brushes.IndianRed;
            //valasz_harmadikeleme.Background = Brushes.Red;
            //win = false;
            //megy = false;
            //gyoztelvnem(0);
            //gomblathatosag(megy);
            /*if (megy == false)
            {
                MessageBox.Show("Vége!");
                valasz_elsoeleme.IsEnabled = false;
                valasz_masodikeleme.IsEnabled = false;
                valasz_harmadikeleme.IsEnabled = false;
            }*/
        }
        private void rossz2_valasz(object sender, RoutedEventArgs e)
        {
            //valasz_elsoeleme.Background = Brushes.Green;
            //valasz_masodikeleme.Background = Brushes.Red;
            //valasz_harmadikeleme.Background = Brushes.IndianRed;
            //win = false;
            //megy = false;
            //gyoztelvnem(0);
            //gomblathatosag(megy);
            /*if (megy == false)
            {
                MessageBox.Show("Vége!");
                valasz_elsoeleme.IsEnabled = false;
                valasz_masodikeleme.IsEnabled = false;
                valasz_harmadikeleme.IsEnabled = false;
            }*/
        }
        private void gomblathatosag(bool idk)
        {
            if (idk == false)
            {
                MessageBox.Show("Vége!");
                valasz_elsoeleme.IsEnabled = false;
                valasz_masodikeleme.IsEnabled = false;
                valasz_harmadikeleme.IsEnabled = false;
            }
        }
        private bool gyoztelvnem(int nyert)
        {
            //megy = false;
            if (nyert == 1)
            {
                return win = true;
            }
            else
            {
                return win = false;
            }
        }

        private void kerdesek_betolt()
        {
            List<Kerdesek> sorok = new List<Kerdesek>();
            foreach (string sor in File.ReadAllLines("asd.txt"))
                sorok.Add(new Kerdesek(sor));

            string tema = Fomenu.temanev;

            List<Kerdesek> temahoz_szavak = sorok.Where(szo => szo.tema == tema).ToList();
            Random random = new Random();
            int randomszam = random.Next(0, temahoz_szavak.Count());//ez lehet nem jo igy
            //Kerdesek selectedQuestion = temahoz_szavak[ra];
            kerdes_txt.Text = temahoz_szavak[randomszam].kerdes;
            valasz_elsoeleme.Content = temahoz_szavak[randomszam].helyesvalasz;
            valasz_masodikeleme.Content = temahoz_szavak[randomszam].valasz2;
            valasz_harmadikeleme.Content = temahoz_szavak[randomszam].valasz3;


        }
    }
}
