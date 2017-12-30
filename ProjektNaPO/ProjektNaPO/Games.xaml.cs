using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace ProjektNaPO
{
    /// <summary>
    /// Interaction logic for Games.xaml
    /// </summary>
    public partial class Games : Window
    {
        List<Product> games = Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\games.dat");
        List<Product> cart = Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\cart.dat");
        public Games()
        {
            InitializeComponent();
            CartView.ItemsSource = games;
            CartView.ItemsSource = cart;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var index = CartView.Items.IndexOf(CartView.SelectedItem);

            cart.Add(games.ElementAt(index));
            games.RemoveAt(index);
            CartView.Items.Refresh();
            CartView.Items.Refresh();
            Serialization.Serialize(games, Directory.GetCurrentDirectory() + @"\DB\Categories\games.dat");
            Serialization.Serialize(cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
        }

        private void ReomoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            var index = CartView.Items.IndexOf(CartView.SelectedItem);
            if (cart.ElementAt(index).Prod == Product.KindOf.Game)
            {
                games.Add(cart.ElementAt(index));
                cart.RemoveAt(index);
                CartView.Items.Refresh();
                CartView.Items.Refresh();
                Serialization.Serialize(games, Directory.GetCurrentDirectory() + @"\DB\Categories\games.dat");
                Serialization.Serialize(cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
            }

        }
    }
}
