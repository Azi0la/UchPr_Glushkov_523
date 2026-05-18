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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        public static List<Review> r = Core.Context.Review.ToList();
        public List<RoleApplication> ra = Core.Context.RoleApplication.ToList();
        public List<UnfreezeRequest> ur = Core.Context.UnfreezeRequest.ToList();

        public UserPage()
        {
            InitializeComponent();
            DataContext = MainWindow.user;
            RevUsList.ItemsSource = r.Where(c => c.UserID == MainWindow.user.ID).ToList();
            if(ra.Find(c =>  c.UserID == MainWindow.user.ID) != null ) ApplicBTN.IsEnabled = false;
            if(MainWindow.user.RoleID == 3) ApplicBTN.IsEnabled = false;
            if(MainWindow.user.IsFrozen == true)
            {
                WarnTB.Text = ("Внимание!\nВаш аккаунт\nзаморожен");
                WarnBTN.Visibility = Visibility.Visible;
            }
            if (ur.Find(c => c.UserID == MainWindow.user.ID) != null) WarnBTN.IsEnabled = false;

        }

        private void ApplicBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoleApplicationPage());
        }

        private void WarnBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UnfreezePage(null, MainWindow.user));
        }
    }
}
