using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace ProjektNaPO
{
    /// <summary>
    ///     Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart
    {
        private readonly List<Product> _albums =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\albums.dat");

        private readonly List<Product> _books =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\books.dat");

        private readonly List<Product> _cart =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\cart.dat");

        private readonly List<Product> _games =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\games.dat");

        private readonly List<Product> _movies =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");

        private readonly List<Product> _products =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\list.dat");

        public Cart()
        {
            InitializeComponent();
            boxCart.ItemsSource = _cart;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            new MainWindow().Show();
        }

        private void removeFromCart_Click(object sender, RoutedEventArgs e)
        {
            var index = boxCart.Items.IndexOf(boxCart.SelectedItem);
            try
            {
                if (_cart.ElementAt(index).Prod == Product.KindOf.Game)
                {
                    _games.Add(_cart.ElementAt(index));
                    _cart.RemoveAt(index);
                    boxCart.Items.Refresh();
                    Serialization.Serialize(_games, Directory.GetCurrentDirectory() + @"\DB\Categories\games.dat");
                    Serialization.Serialize(_cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
                }
                else if (_cart.ElementAt(index).Prod == Product.KindOf.Album)
                {
                    _albums.Add(_cart.ElementAt(index));
                    _cart.RemoveAt(index);
                    boxCart.Items.Refresh();
                    Serialization.Serialize(_albums, Directory.GetCurrentDirectory() + @"\DB\Categories\albums.dat");
                    Serialization.Serialize(_cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
                }
                else if (_cart.ElementAt(index).Prod == Product.KindOf.Book)
                {
                    _books.Add(_cart.ElementAt(index));
                    _cart.RemoveAt(index);
                    boxCart.Items.Refresh();
                    Serialization.Serialize(_books, Directory.GetCurrentDirectory() + @"\DB\Categories\books.dat");
                    Serialization.Serialize(_cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
                }
                else if (_cart.ElementAt(index).Prod == Product.KindOf.Movie)
                {
                    _movies.Add(_cart.ElementAt(index));
                    _cart.RemoveAt(index);
                    boxCart.Items.Refresh();
                    Serialization.Serialize(_movies, Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");
                    Serialization.Serialize(_cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
                }
                try
                {
                    boxCart.SelectedItem = boxCart.Items.IndexOf(0);
                }
                catch (Exception)
                {
                    //do nothing
                }
            }
            catch (Exception)
            {
                //do nothing
            }
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            List<string> CartList = new List<string>();
            foreach (var product in _cart)
                CartList.Add(product.ToString());
            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\CartList.txt", CartList);
            foreach (var product in _cart)
            {
                foreach (var element in _products)
                {
                    if (product.Equals(element))
                    {
                        _products.Remove(element);
                        _cart.Remove(product);
                    }

                }
            }
            boxCart.Items.Refresh();
            MessageBox.Show("Saved list to desktop.");
        }
    }
}