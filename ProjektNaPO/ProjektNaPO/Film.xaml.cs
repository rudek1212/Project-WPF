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
    /// Interaction logic for Film.xaml
    /// </summary>
    public partial class Film : Window
    {
        List<Product> movies = Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");
        List<Product> cart = Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\cart.dat");
        public Film()
        {
            InitializeComponent();
            MoviesView.ItemsSource = movies;
            CartView.ItemsSource = cart;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var index = MoviesView.Items.IndexOf(MoviesView.SelectedItem);

            cart.Add(movies.ElementAt(index));
            movies.RemoveAt(index);
            MoviesView.Items.Refresh();
            CartView.Items.Refresh();
            Serialization.Serialize(movies, Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");
            Serialization.Serialize(cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
        }

        private void ReomoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            var index = CartView.Items.IndexOf(CartView.SelectedItem);
            if (cart.ElementAt(index).Prod == Product.KindOf.Movie)
            {
                movies.Add(cart.ElementAt(index));
                cart.RemoveAt(index);
                MoviesView.Items.Refresh();
                CartView.Items.Refresh();
                Serialization.Serialize(movies, Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");
                Serialization.Serialize(cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
            }

        }
    }
}
