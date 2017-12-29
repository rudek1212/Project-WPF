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
            CartTest.ItemsSource = cart;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var index = AlbumsView.Items.IndexOf(AlbumsView.SelectedItem);
            cart.Add(albums.ElementAt(index));
            AlbumsView.Items.Refresh();
            CartTest.Items.Refresh();
        }
    }
}
