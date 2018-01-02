using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace ProjektNaPO
{
    /// <summary>
    ///     Interaction logic for Music.xaml
    /// </summary>
    public partial class Music
    {
        private readonly List<Product> _albums =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\albums.dat");

        private readonly List<Product> _cart =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\cart.dat");

        public Music()
        {
            InitializeComponent();
            AlbumsView.ItemsSource = _albums;
            CartView.ItemsSource = _cart;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var index = AlbumsView.Items.IndexOf(AlbumsView.SelectedItem);

            try
            {
                _cart.Add(_albums.ElementAt(index));
                _albums.RemoveAt(index);
                AlbumsView.Items.Refresh();
                CartView.Items.Refresh();
                Serialization.Serialize(_albums, Directory.GetCurrentDirectory() + @"\DB\Categories\albums.dat");
                Serialization.Serialize(_cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
            }
            catch (System.Exception)
            {
                MessageBox.Show("Select an item to add!");
            }
        }

        private void ReomoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            var index = CartView.Items.IndexOf(CartView.SelectedItem);
            try
            {
                if (_cart.ElementAt(index).Prod == Product.KindOf.Album)
                {
                    _albums.Add(_cart.ElementAt(index));
                    _cart.RemoveAt(index);
                    AlbumsView.Items.Refresh();
                    CartView.Items.Refresh();
                    Serialization.Serialize(_albums, Directory.GetCurrentDirectory() + @"\DB\Categories\albums.dat");
                    Serialization.Serialize(_cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
                }
            }
            catch (System.Exception)
            {
                //do nothing
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}