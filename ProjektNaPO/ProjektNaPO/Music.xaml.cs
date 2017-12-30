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
    /// Interaction logic for Music.xaml
    /// </summary>
    public partial class Music : Window
    {
        List<Product> albums = Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\albums.dat");
        List<Product> cart = Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\cart.dat");
        public Music()
        {
            InitializeComponent();
            AlbumsView.ItemsSource = albums;
            CartView.ItemsSource = cart;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var index = AlbumsView.Items.IndexOf(AlbumsView.SelectedItem);

            cart.Add(albums.ElementAt(index));
            albums.RemoveAt(index);
            AlbumsView.Items.Refresh();
            CartView.Items.Refresh();
            Serialization.Serialize(albums, Directory.GetCurrentDirectory() + @"\DB\Categories\albums.dat");
            Serialization.Serialize(cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
        }

        private void ReomoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            var index = CartView.Items.IndexOf(CartView.SelectedItem);
            if (cart.ElementAt(index).Prod == Product.KindOf.Album)
            {
                albums.Add(cart.ElementAt(index));
                cart.RemoveAt(index);
                AlbumsView.Items.Refresh();
                CartView.Items.Refresh();
                Serialization.Serialize(albums, Directory.GetCurrentDirectory() + @"\DB\Categories\albums.dat");
                Serialization.Serialize(cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
            }

        }
    }
}
