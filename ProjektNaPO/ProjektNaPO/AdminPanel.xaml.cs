using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace ProjektNaPO
{
    /// <summary>
    ///     Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel
    {
        //creating categorized lists
        private readonly List<Product> _albums = new List<Product>();

        private readonly List<Product> _books = new List<Product>();
        private readonly List<Product> _games = new List<Product>();
        private readonly List<Product> _movies = new List<Product>();

        //importing database
        private readonly List<Product> _products =
            Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\list.dat");

        public AdminPanel()
        {
            InitializeComponent();

            var products = _products;

            listOfContent.ItemsSource = products;
            comboxCategory.ItemsSource = Enum.GetValues(typeof(Product.KindOf));
            comboxMainCat.ItemsSource = Enum.GetValues(typeof(Product.KindOf));
            File.Delete(Directory.GetCurrentDirectory() + @"\DB\cart.dat");
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void buttonDeleteObject_Click(object sender, RoutedEventArgs e)
        {
            var index = listOfContent.Items.IndexOf(listOfContent.SelectedItem);
            try
            {
                _products.RemoveAt(index);
            }
            catch (Exception)
            {
                MessageBox.Show("Select an object to delete","Oops" );
            }
            listOfContent.Items.Refresh();
        }

        private void buttonAddObject_Click(object sender, RoutedEventArgs e)
        {
            if (boxName.Text == "" || boxPrice.Text == "" || boxAmount.Text == "" || comboxCategory.SelectedItem == null
            ) MessageBox.Show("Add all values");
            else
                try
                {
                    _products.Add(new Product(boxName.Text, Convert.ToInt32(boxAmount.Text),
                        Convert.ToDouble(boxPrice.Text), (Product.KindOf) comboxCategory.SelectedItem));
                    listOfContent.Items.Refresh();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(
                        "Something went wrong. Check input boxes." + Environment.NewLine + Environment.NewLine +
                        exception.Message, "Ooops...");
                }
        }

        private void buttonSaveAll_Click(object sender, RoutedEventArgs e)
        {
            //adding values to categorized lists
            foreach (var product in _products)
            {
                if (product.Prod == Product.KindOf.Movie) _movies.Add(product);
                if (product.Prod == Product.KindOf.Game) _games.Add(product);
                if (product.Prod == Product.KindOf.Book) _books.Add(product);
                if (product.Prod == Product.KindOf.Album) _albums.Add(product);
            }

            //serializing categorized lists
            Serialization.Serialize(_movies, Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");
            Serialization.Serialize(_games, Directory.GetCurrentDirectory() + @"\DB\Categories\games.dat");
            Serialization.Serialize(_books, Directory.GetCurrentDirectory() + @"\DB\Categories\books.dat");
            Serialization.Serialize(_albums, Directory.GetCurrentDirectory() + @"\DB\Categories\albums.dat");

            //serializing main DB
            Serialization.Serialize(_products, Directory.GetCurrentDirectory() + @"\DB\list.dat");

            MessageBox.Show("Done");
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            new AdminLogIn().Show();
        }
    }
}