using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media.TextFormatting;

namespace ProjektNaPO
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        List<Product> movies = new List<Product>();
        List<Product> games = new List<Product>();
        List<Product> books = new List<Product>();
        List<Product> albums = new List<Product>();

        //importing database
        List<Product> products = Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\list.dat");
        public AdminPanel()
        {
            InitializeComponent();
            var movies = this.movies;
            var games = this.games;
            var books = this.books;
            var albums = this.albums;
            var products = this.products;


            //creating new categorized lists
            foreach (var product in products)
            {
                if (product.Prod==Product.KindOf.Movie) movies.Add(product);
                if (product.Prod == Product.KindOf.Game) games.Add(product);
                if (product.Prod == Product.KindOf.Book) books.Add(product);
                if (product.Prod == Product.KindOf.Album) albums.Add(product);
            }
            //serializing categorized lists
            Serialization.Serialize(movies, Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");
            Serialization.Serialize(games, Directory.GetCurrentDirectory() + @"\DB\Categories\games.dat");
            Serialization.Serialize(books, Directory.GetCurrentDirectory() + @"\DB\Categories\books.dat");
            Serialization.Serialize(albums, Directory.GetCurrentDirectory() + @"\DB\Categories\albums.dat");
            listOfContent.ItemsSource = products;
            boxCategory.ItemsSource = Enum.GetValues(typeof(Product.KindOf));
        }

        private void buttonDeleteObject_Click(object sender, RoutedEventArgs e)
        {
            var index = listOfContent.Items.IndexOf(listOfContent.SelectedItem);
            products.RemoveAt(index);
            listOfContent.UpdateLayout();
        }
    }
}
