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
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : Window
    {
        List<Product> books = Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\books.dat");
        List<Product> cart = Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\cart.dat");
        public Books()
        {
            InitializeComponent();
            BooksView.ItemsSource = books;
            CartView.ItemsSource = cart;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var index = BooksView.Items.IndexOf(BooksView.SelectedItem);

            cart.Add(books.ElementAt(index));
            books.RemoveAt(index);
            BooksView.Items.Refresh();
            CartView.Items.Refresh();
            Serialization.Serialize(books, Directory.GetCurrentDirectory() + @"\DB\Categories\books.dat");
            Serialization.Serialize(cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
        }

        private void ReomoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            var index = CartView.Items.IndexOf(CartView.SelectedItem);
            if (cart.ElementAt(index).Prod == Product.KindOf.Book)
            {
                books.Add(cart.ElementAt(index));
                cart.RemoveAt(index);
                BooksView.Items.Refresh();
                CartView.Items.Refresh();
                Serialization.Serialize(books, Directory.GetCurrentDirectory() + @"\DB\Categories\books.dat");
                Serialization.Serialize(cart, Directory.GetCurrentDirectory() + @"\DB\cart.dat");
            }

        }
    }
}
