using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace ProjektNaPO
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            CreateDir();
        }

        private void buttonAdmin_Click(object sender, RoutedEventArgs e)
        {
            new AdminLogIn().Show();
            Hide();
        }

        private void buttonMusic_Click(object sender, RoutedEventArgs e)
        {
            new Music().Show();
            Hide();
        }

        private void buttonFilm_Click(object sender, RoutedEventArgs e)
        {
            new Film().Show();
            Hide();
        }

        private void buttonGames_Click(object sender, RoutedEventArgs e)
        {
            new Games().Show();
            Hide();
        }

        private void buttonBooks_Click(object sender, RoutedEventArgs e)
        {
            new Books().Show();
            Hide();
        }

        private void buttonBasket_Click(object sender, RoutedEventArgs e)
        {
            new Cart().Show();
            Hide();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public static void CreateDir()
        {
            var path = Directory.GetCurrentDirectory() + @"\DB\Categories";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}