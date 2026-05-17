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
    /// Логика взаимодействия для UserControlPage.xaml
    /// </summary>
    public partial class UserControlPage : Page
    {
        User user;
        public UserControlPage(User _user)
        {
            InitializeComponent();
            user = _user;
            List<String> roles = new List<String> { "Читатель", "Автор", "Администратор"};
            RoleCB.ItemsSource = roles;

            RoleCB.SelectedIndex = user.RoleID - 1;
            userLB.Content += (user.Name);
            UserPassTB.Text = (user.Password);
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if(RoleCB.SelectedIndex != user.RoleID-1 || UserPassTB.Text != user.Password)
            {
                MessageBoxResult result = MessageBox.Show("Данные пользователя изменены. Вы уверены что хотите продолжить?", "Внимание!", 
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes) 
                {
                    user.RoleID = RoleCB.SelectedIndex+1;
                    user.Password = UserPassTB.Text;
                    Core.Context.SaveChanges();
                    MessageBox.Show("Данные сохранены!");
                    NavigationService.Navigate(new AdministrationPage());
                }
            }
        }

    }
}
