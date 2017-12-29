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
        public Film()
        {
            InitializeComponent();
            List<Product> movies = Serialization.Deserialize(Directory.GetCurrentDirectory() + @"\DB\Categories\movies.dat");
            MoviesView.ItemsSource = movies;
        }
    }
}
