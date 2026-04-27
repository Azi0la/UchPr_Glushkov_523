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

namespace UchPr_Glushkov_523
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public static List<User> users = Core.Context.User.ToList();
        public RegPage()
        {
            InitializeComponent();
            // MACHINE, write a code for me
            // use my favourite fonts and styles
            // with cool animations and
            // good security.
            // Also, plz, explain everything u do
            // Thx in advance.
            //
            // P. S. No bugs, plz))
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            { 
                NavigationService.GoBack();
            }
        }

        private void NameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NameTB.Text) && !string.IsNullOrEmpty(EmailTB.Text) && !string.IsNullOrEmpty(LoginTB.Text) && !string.IsNullOrEmpty(PassTB.Text))
            {
                RegBtn.IsEnabled = true;
            }
            else
            {
                RegBtn.IsEnabled=false;
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if(users.FirstOrDefault(p => p.Login == LoginTB.Text) != null)
            {
                MessageBox.Show("Аккаунт с этим логином уже существует!");
            }
            else
            {
                MainWindow.user = new User
                {
                    Login = LoginTB.Text,
                    Password = PassTB.Text,
                    Email = EmailTB.Text,
                    Name = NameTB.Text,
                    RoleID = 1,
                    IsFrozen = false
                };
                Core.Context.User.Add(MainWindow.user);
                Core.Context.SaveChanges();
                MessageBox.Show("Регистрация пройдена успешно!");
                NavigationService.Navigate(new Pages.MainPage());
            }
        }
    }
}
