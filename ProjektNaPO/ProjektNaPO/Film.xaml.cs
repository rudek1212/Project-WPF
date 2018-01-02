using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace ProjektNaPO
{
    /// <summary>
    ///     Interaction logic for Film.xaml
    /// </summary>
    public partial class Film
    {
        private readonly List<Product> _cart =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\cart.dat");

        private readonly List<Product> _movies =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");

        public Film()
        {
            InitializeComponent();
            MoviesView.ItemsSource = _movies;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            CartView.ItemsSource = _cart;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var index = MoviesView.Items.IndexOf(MoviesView.SelectedItem);

            try
            {
                _cart.Add(_movies.ElementAt(index));
                _movies.RemoveAt(index);
                MoviesView.Items.Refresh();
                CartView.Items.Refresh();
                Serialization.Serialize(_movies, Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");
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
                if (_cart.ElementAt(index).Prod == Product.KindOf.Movie)
                {
                    _movies.Add(_cart.ElementAt(index));
                    _cart.RemoveAt(index);
                    MoviesView.Items.Refresh();
                    CartView.Items.Refresh();
                    Serialization.Serialize(_movies, Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");
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