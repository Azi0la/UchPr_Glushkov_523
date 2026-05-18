using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using UchPr_Glushkov_523.Pages;

namespace UchPr_Glushkov_523
{
    /// <summary>
    /// Логика взаимодействия для AdminBlockPage.xaml
    /// </summary>
    public partial class AdminBlockPage : Page
    {
        private User curuser;
        private Review currev;
        public static List<Motive> m = Core.Context.Motive.ToList();
        public static List<User> u = Core.Context.User.ToList();
        public List<Book> b = Core.Context.Book.ToList();
        public List<Review> r = Core.Context.Review.ToList();
        public AdminBlockPage(User usId = null, Review RevID = null)
        {
            InitializeComponent();
            curuser = usId;
            currev = RevID;
            List<String> motives = new List<String> { "Спам или реклама", "Оскорбление и ненависть", "Взрослый и шокирующий контент", "Мошенничество и обман",
            "Пиратство и плагиат", "Другое"};
            MotiveCB.ItemsSource = motives;
            CompLB.Content = ("Заморозка ");
            if (usId != null)
            {
                CompLB.Content += ("автора:");
                AuthLB.Content = (usId.Name);
            }
            if (RevID != null)
            {
                CompLB.Content += ("комментарий:");
                ReviewLB.Content = (RevID.User.Name);
            }
        }

        private void MotiveCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MotiveCB.SelectedItem != null)
            {
                SendBTN.IsEnabled = true;
            }
            else
            {
                SendBTN.IsEnabled = false;
            }
        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            if (curuser != null)
            {
                curuser.IsFrozen = true;
                curuser.MotiveID = MotiveCB.SelectedIndex + 1;
                Core.Context.SaveChanges();
            }
            else
            {
                currev.IsFrozen = true;
                currev.MotiveID = MotiveCB.SelectedIndex + 1;
                Core.Context.SaveChanges();
            }
            NavigationService.Navigate(new CatalogPage());
        }

        private void SendBTN_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
