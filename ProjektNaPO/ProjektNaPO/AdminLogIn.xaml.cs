using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ProjektNaPO
{
    /// <summary>
    ///     Interaction logic for AdminLogIn.xaml
    /// </summary>
    public partial class AdminLogIn
    {
        private readonly string login = "a";
        private readonly string password = "a";

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
                var panel = new AdminPanel();
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

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            new MainWindow().Show();
        }
    }
}