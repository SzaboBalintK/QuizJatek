using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuizGame
{
    public partial class MainWindow : Window
    {
        /*private bool isDragging = false;
        private Point startPoint;*/

        public MainWindow()
        {
            InitializeComponent();
            Fomenu fomenu = new Fomenu();
            frame_sajat.NavigationService.Navigate(fomenu);
        }

        /*private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                isDragging = true;
                startPoint = e.GetPosition(this);
            }
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point endPoint = e.GetPosition(this);

                double deltaX = endPoint.X - startPoint.X;
                double deltaY = endPoint.Y - startPoint.Y;

                double newWidth = Width + deltaX;
                double newHeight = Height + deltaY;

                Width = newWidth > 0 ? newWidth : Width;
                Height = newHeight > 0 ? newHeight : Height;

                startPoint = endPoint;
            }
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }*/
    }
}
