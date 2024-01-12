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
        public Fomenu()
        {
            InitializeComponent();
            hibauzenet.Visibility = Visibility.Hidden;
        }

        private void next_btn(object sender, RoutedEventArgs e)
        {
            //nev = jatekos_nev.Text;
            //if(String.IsNullOrWhiteSpace(nev) != true && nev.Contains(";") != true)
            //{
            NavigationService.Navigate(new Game());
            //}
            /*if(String.IsNullOrWhiteSpace(nev))
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Adj meg betűket f.névhez!";
            }
            if(nev.Contains(";"))
            {
                hibauzenet.Visibility = Visibility.Visible;
                hibauzenet.Content = "Nem lehet benne ilyen karakter! (';')";
            }*/

        }

    }
}
