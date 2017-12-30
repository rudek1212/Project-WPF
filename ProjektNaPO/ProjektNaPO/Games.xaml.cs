using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace ProjektNaPO
{
    /// <summary>
    ///     Interaction logic for Games.xaml
    /// </summary>
    public partial class Games
    {
        private readonly List<Product> _cart =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\cart.dat");

        private readonly List<Product> _games =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\games.dat");

        public Games()
        {
            InitializeComponent();
            CartView.ItemsSource = _games;
            CartView.ItemsSource = _cart;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var index = CartView.Items.IndexOf(CartView.SelectedItem);

            _cart.Add(_games.ElementAt(index));
            _games.RemoveAt(index);
            CartView.Items.Refresh();
            CartView.Items.Refresh();
            Serialization.Serialize(_games, Directory.GetCurrentDirectory() + @"\DB\Categories\games.dat");
            Serialization.Serialize(_cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
        }

        private void ReomoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            var index = CartView.Items.IndexOf(CartView.SelectedItem);
            if (_cart.ElementAt(index).Prod == Product.KindOf.Game)
            {
                _games.Add(_cart.ElementAt(index));
                _cart.RemoveAt(index);
                CartView.Items.Refresh();
                CartView.Items.Refresh();
                Serialization.Serialize(_games, Directory.GetCurrentDirectory() + @"\DB\Categories\games.dat");
                Serialization.Serialize(_cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}