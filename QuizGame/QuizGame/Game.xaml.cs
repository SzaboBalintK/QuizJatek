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
using System.Threading;
using System.Timers;
using System.Windows.Threading;

namespace QuizGame
{
    class Kerdesek
    {
        public int id { get; set; }
        public string kerdes { get; set; }
        public string helyesvalasz { get; set; }
        public string valasz2 { get; set; }
        public string valasz3 { get; set; }
        public int ido { get; set; }
        public string tema { get; set; }
        public Kerdesek(string sor)
        {
            string[] adatok = sor.Split(';');
            id = Convert.ToInt32(adatok[0]);
            kerdes = adatok[1];
            helyesvalasz = adatok[2];
            valasz2 = adatok[3];
            valasz3 = adatok[4];
            ido = Convert.ToInt32(adatok[5]);
            tema = adatok[6];
        }
    }
    public partial class Game : Page
    {
        public static int ido = 0;
        public static int current_kerdesek = 0;
        public static int all_keredesek = Fomenu.korokszama;
        public static int jo_valaszok_szama = 0;
        public static bool ido_vege = true;
        public static bool gomb_ido = true;
        public static bool gyors = true;
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer kerdesek_valaszideje_timer = new DispatcherTimer();
        private int teszt = 0;
        private int visszaszamol = 5;
        
        public Game()
        {
            InitializeComponent();
            //42-es és a 23-as sor nincs
            List<Kerdesek> osszkerdes = new List<Kerdesek>();
            foreach (string sor in File.ReadAllLines("asd.txt"))
            {
                osszkerdes.Add(new Kerdesek(sor));
            }
            Ready_kiiaratas();
            timer.Interval = TimeSpan.FromSeconds(1);
            kerdesek_betolt();
        }
        public void Ready_kiiaratas()
        {
            kerdes_kozti_ido.Visibility = Visibility.Hidden;//ez majd lehet nem kell;
            progressbar_kiiras.BorderBrush = Brushes.Black;
            progressbar_kiiras.Foreground = Brushes.Green;
            kerdesekszama.Content = Convert.ToString(current_kerdesek + "/" + all_keredesek);
            ido_label.Content = "Idő: " + ido.ToString();
        }
        private void helyes_valasz(object sender, RoutedEventArgs e)
        {
            if(gomb_ido)
            {
                kerdesek_valaszideje_timer.Stop();
                gomb_ido = false;
                valasz_elsoeleme.Background = Brushes.Green;
                valasz_masodikeleme.Background = Brushes.Red;
                valasz_harmadikeleme.Background = Brushes.Red;
                jo_valaszok_szama++;
                timer.Tick += TimerTick;
                kerdes_kozti_ido.Visibility = Visibility.Visible;
                kerdes_kozti_ido.Content = "Idő a következő kérdésig: " + visszaszamol.ToString();
                timer.Start();
            }
        }
        private void rossz1_valasz(object sender, RoutedEventArgs e)
        {
            if(gomb_ido)
            {
                kerdesek_valaszideje_timer.Stop();
                gomb_ido = false;
                valasz_elsoeleme.Background = Brushes.Green;
                valasz_masodikeleme.Background = Brushes.IndianRed;
                valasz_harmadikeleme.Background = Brushes.Red;
                timer.Tick += TimerTick;
                kerdes_kozti_ido.Visibility = Visibility.Visible;
                kerdes_kozti_ido.Content = "Idő a következő kérdésig: " + visszaszamol.ToString();
                timer.Start();
            }
        }
        private void rossz2_valasz(object sender, RoutedEventArgs e)
        {
            if(gomb_ido)
            {
                kerdesek_valaszideje_timer.Stop();
                gomb_ido = false;
                valasz_elsoeleme.Background = Brushes.Green;
                valasz_masodikeleme.Background = Brushes.Red;
                valasz_harmadikeleme.Background = Brushes.IndianRed;
                timer.Tick += TimerTick;
                kerdes_kozti_ido.Visibility = Visibility.Visible;
                kerdes_kozti_ido.Content = "Idő a következő kérdésig: " + visszaszamol.ToString();
                timer.Start();
            }
        }
        private void kerdesek_betolt()
        {
                if (current_kerdesek >= all_keredesek)
                {
                    //MessageBox.Show("itt még jó");
                    timer.Tick += TimerTick;
                    timer.Interval = TimeSpan.FromSeconds(1);
                    kerdes_kozti_ido.Visibility = Visibility.Visible;
                    kerdes_kozti_ido.Content = "Kiértékelés: " + visszaszamol.ToString();
                    timer.Start();
                    //MessageBox.Show("uccso");
                    gyors = false;
                    NavigationService.Navigate(new Kiertekelo());
                }
                if (ido_vege == true && current_kerdesek != all_keredesek)
                {
                    gombszinek();
                    current_kerdesek++;
                    ido_vege = false;
                    kerdesek_valaszideje_timer.Tick -= Rendelkezesre_allo_ido;
                    timer.Tick -= TimerTick;
                    List<Kerdesek> sorok = new List<Kerdesek>();
                    foreach (string sor in File.ReadAllLines("asd.txt"))
                        sorok.Add(new Kerdesek(sor));

                    string tema = Fomenu.temanev;

                    List<Kerdesek> temahoz_szavak = sorok.Where(szo => szo.tema == tema).ToList();
                    Random random = new Random();
                    Random random_gombok_helye = new Random();
                    int randomszam = random.Next(0, temahoz_szavak.Count() + 1);
                    int gombokhelye_switch = random_gombok_helye.Next(1, 4);
                    //int gombokhelye_switch = 1; //teszthez kellett
                    List<int> volt_szamok = new List<int>();
                    while (volt_szamok.Contains(randomszam))
                    {
                        randomszam = random.Next(0, temahoz_szavak.Count() + 1);
                    }
                    bool szam_volt_v_sem = volt_szamok.Contains(randomszam);
                    if (szam_volt_v_sem == false)
                    {
                        volt_szamok.Add(randomszam);
                        switch (gombokhelye_switch)
                        {
                            case 1://jobb szelen van a jo,
                                valasz_elsoeleme.Margin = new Thickness(625, 0, -700, 0);
                                valasz_masodikeleme.Margin = new Thickness(0, 0, 0, 0);
                                valasz_harmadikeleme.Margin = new Thickness(-700, 0, 625, 0);
                                break;
                            case 2://alap ahogyan vannak
                                valasz_elsoeleme.Margin = new Thickness(20, 0, 0, 0);
                                valasz_masodikeleme.Margin = new Thickness(0, 0, 0, 0);
                                valasz_harmadikeleme.Margin = new Thickness(0, 0, 20, 0);
                                break;
                            case 3://kozépen van a jo, 
                                valasz_elsoeleme.Margin = new Thickness(320, 0, -500, 00);
                                valasz_masodikeleme.Margin = new Thickness(-500, 0, 120, 0);
                                valasz_harmadikeleme.Margin = new Thickness(0, 0, 20, 0);
                                break;
                            default:
                                break;
                        }
                        ido_label.Content = "Idő: " + temahoz_szavak[randomszam].ido;
                        ido = temahoz_szavak[randomszam].ido;
                        progressbar_kiiras.Value = ido;
                        progressbar_kiiras.Maximum = ido;
                        progressbar_kiiras.Foreground = Brushes.Green;
                        kerdesek_valaszideje_timer.Tick += Rendelkezesre_allo_ido;
                        kerdesek_valaszideje_timer.Interval = TimeSpan.FromSeconds(1);
                        kerdesek_valaszideje_timer.Start();
                        kerdesekszama.Content = Convert.ToString("Kérdések: " + current_kerdesek + "/" + all_keredesek);
                        kerdes_txt.Text = temahoz_szavak[randomszam].kerdes;
                        valasz_elsoeleme.Content = temahoz_szavak[randomszam].helyesvalasz;
                        valasz_masodikeleme.Content = temahoz_szavak[randomszam].valasz2;
                        valasz_harmadikeleme.Content = temahoz_szavak[randomszam].valasz3;
                    }


                
            }
            
        }
        private void gombszinek()
        {
            valasz_elsoeleme.Background = Brushes.White;
            valasz_masodikeleme.Background = Brushes.White;
            valasz_harmadikeleme.Background = Brushes.White;
        }
        private void TimerTick(object sender, EventArgs e)
        {
            teszt++;
            visszaszamol--;
            kerdes_kozti_ido.Content = "Idő a következő kérdésig: " + visszaszamol.ToString();
            if (teszt == 5) 
            { 
                timer.Stop();
                teszt = 0;
                visszaszamol = 5;
                ido_vege = true;
                gomb_ido = true;
                kerdes_kozti_ido.Visibility = Visibility.Hidden;
                if (gyors)
                {
                    kerdesek_betolt();
                }
                
            }
        }
        private void Rendelkezesre_allo_ido(object sender, EventArgs e)
        {
            ido--;
            progressbar_kiiras.Value--;
            ido_label.Content = "Idő: " + ido.ToString();
            if(progressbar_kiiras.Value <= 5)
            {
                progressbar_kiiras.Foreground = Brushes.Red;
            }
            if (ido == 0)
            {
                kerdesek_valaszideje_timer.Stop();
                teszt = 0;
                visszaszamol = 5;
                ido_vege = true;
                gomb_ido = true;
                kerdes_kozti_ido.Visibility = Visibility.Hidden;
                MessageBox.Show("halo");
                kerdesek_betolt();
            }
        }
    }
}