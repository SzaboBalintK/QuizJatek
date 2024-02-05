using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuizGame
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Fomenu fomenu = new Fomenu();
            frame_sajat.NavigationService.Navigate(fomenu);
        }
    }
}
