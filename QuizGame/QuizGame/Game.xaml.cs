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
        public string valasz { get; set; }
        public string ido { get; set; }
        public string tema { get; set; }

        public Kerdesek (string sor)
        {
            string[] adatok = sor.Split(';');
            id = Convert.ToInt32(adatok[0]);
            kerdes = adatok[1];
            valasz = adatok[2];
            ido = adatok[3];
            tema = adatok[4];
        }
    }
    public partial class Game : Page
    {
        public Game()
        {
            InitializeComponent();

            List<Kerdesek> osszkerdes = new List<Kerdesek>();
            foreach (string sor in File.ReadAllLines("asd.txt"))
            {
                osszkerdes.Add(new Kerdesek(sor));
            }
            Random rnd = new Random();
            int randomid = rnd.Next(1, 105);

            kerdes_txt.Text = osszkerdes[12].kerdes;
            
        }
    }
}
