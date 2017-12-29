using System;
using System.Collections.Generic;
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
    /// Interaction logic for AdminLogIn.xaml
    /// </summary>
    public partial class AdminLogIn : Window
    {
        private string login = "a";
        private string password = "a";
        public AdminLogIn()
        {
            InitializeComponent();
            LoginBox.Focus();
        }

        public void IsLoginOk(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == login && PasswordBox.Password == password)
            {
                MessageBox.Show("OK");
                AdminPanel panel = new AdminPanel();
                panel.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Login or password are incorrect");
                LoginBox.Clear();
                PasswordBox.Clear();
                LoginBox.Focus();
            }
        }

        public void EnterCheck(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                IsLoginOk(sender, e);
        }
    }
}
