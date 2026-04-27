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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UchPr_Glushkov_523.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public static List<User> users = Core.Context.User.ToList();
        public AuthPage()
        {
            InitializeComponent();
        }

        private void RegLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        private void PassTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PassTB.Text) && !string.IsNullOrEmpty(LoginTB.Text))
            {
                AuthBtn.IsEnabled = true;
            }
            else
            {
                AuthBtn.IsEnabled = false;
            }
        }

        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            if (users.FirstOrDefault(p => p.Login == LoginTB.Text && p.Password == PassTB.Text) != null)
            {
                MainWindow.user = users.FirstOrDefault(p => p.Login == LoginTB.Text && p.Password == PassTB.Text);
                MessageBox.Show("Вход прошёл успешно!");
                NavigationService.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }
    }
}
