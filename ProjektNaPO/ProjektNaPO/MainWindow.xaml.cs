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

namespace ProjektNaPO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminLogIn logInWindow = new AdminLogIn();
            logInWindow.Show();
            Hide();
        }

        private void buttonMusic_Click(object sender, RoutedEventArgs e)
        {
            Music music = new Music();
            music.Show();
            Hide();
        }

        private void buttonFilm_Click(object sender, RoutedEventArgs e)
        {
            Film film = new Film();
            film.Show();
            Hide();
        }

        private void buttonGames_Click(object sender, RoutedEventArgs e)
        {
            Games games = new Games();
            games.Show();
            Hide();
        }

        private void buttonBooks_Click(object sender, RoutedEventArgs e)
        {
            Books books = new Books();
            books.Show();
            Hide();
        }

        private void buttonBasket_Click(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();
            Hide();

        }
    }
}
