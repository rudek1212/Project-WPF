using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace ProjektNaPO
{
    /// <summary>
    ///     Interaction logic for Books.xaml
    /// </summary>
    public partial class Books
    {
        private readonly List<Product> _books =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\books.dat");

        private readonly List<Product> _cart =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\cart.dat");

        public Books()
        {
            InitializeComponent();
            BooksView.ItemsSource = _books;
            CartView.ItemsSource = _cart;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var index = BooksView.Items.IndexOf(BooksView.SelectedItem);

            try
            {
                _cart.Add(_books.ElementAt(index));
                _books.RemoveAt(index);
                BooksView.Items.Refresh();
                CartView.Items.Refresh();
                Serialization.Serialize(_books, Directory.GetCurrentDirectory() + @"\DB\Categories\books.dat");
                Serialization.Serialize(_cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
            }
            catch (Exception)
            {
                MessageBox.Show("Select an item to add!");
            }
        }

        private void ReomoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            var index = CartView.Items.IndexOf(CartView.SelectedItem);
            try
            {
                if (_cart.ElementAt(index).Prod == Product.KindOf.Book)
                {
                    _books.Add(_cart.ElementAt(index));
                    _cart.RemoveAt(index);
                    BooksView.Items.Refresh();
                    CartView.Items.Refresh();
                    Serialization.Serialize(_books, Directory.GetCurrentDirectory() + @"\DB\Categories\books.dat");
                    Serialization.Serialize(_cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
                }
            }
            catch (Exception)
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