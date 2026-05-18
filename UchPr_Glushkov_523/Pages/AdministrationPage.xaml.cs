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
    /// Логика взаимодействия для AdministrationPage.xaml
    /// </summary>
    public partial class AdministrationPage : Page
    {
        public static List<User> u = Core.Context.User.ToList();
        public List<Book> b = Core.Context.Book.ToList();
        public List<Review> r = Core.Context.Review.ToList();
        public List<RoleApplication> ra = Core.Context.RoleApplication.ToList();
        public List<UnfreezeRequest> ur = Core.Context.UnfreezeRequest.ToList();
        public List<Complaint> cp = Core.Context.Complaint.ToList();

        public List<FrozenStuff> FS = new List<FrozenStuff>();

        public AdministrationPage()
        {
            InitializeComponent();
            AdmUserList.ItemsSource = u;
            foreach(var item in u.Where(i=> i.IsFrozen == true)) 
            {
                FS.Add(new FrozenStuff(item));
            }
            foreach (var item in b.Where(i => i.IsFrozen == true))
            {
                FS.Add(new FrozenStuff(item));
            }
            foreach (var item in r.Where(i => i.IsFrozen == true))
            {
                FS.Add(new FrozenStuff(item));
            }
            FrozenList.ItemsSource = FS;
            ApplicList.ItemsSource = ra.Where(f => f.IsProcessed == false);
            UnfrzList.ItemsSource = ur.Where(f => f.IsProcessed == false);
            ComplList.ItemsSource = cp.Where(f => f.IsProcessed == false);

        }

        private void AdmUserList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new UserControlPage(AdmUserList.SelectedItem as User));
        }

        private void ApplicList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var SelItem = ApplicList.SelectedItem as RoleApplication;
            MessageBoxResult result = MessageBox.Show(SelItem.Reason + "\n Принимается ли заявка?",
                "Заявка от " + SelItem.User.Name, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                SelItem.IsProcessed = true;
                SelItem.User.RoleID = 2;
                Core.Context.SaveChanges();
                NavigationService.Navigate(new AdministrationPage());
            }
            else if (result == MessageBoxResult.No)
            {
                Core.Context.RoleApplication.Remove(SelItem);
                Core.Context.SaveChanges();
                NavigationService.Navigate(new AdministrationPage());
            }
        }

        private void UnfrzList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var SelItem = UnfrzList.SelectedItem as UnfreezeRequest;
            MessageBoxResult result = MessageBox.Show(SelItem.Reason + "\n Принимается ли оспаривание?",
                "Заявка от " + SelItem.User.Name, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                SelItem.IsProcessed = true;
                var book = b.FirstOrDefault(x => x.ID == SelItem.BookID);
                if (book == null)
                {
                    var user = u.FirstOrDefault(x=> x.ID == SelItem.UserID);
                    user.IsFrozen = false;
                    user.MotiveID = null;
                    Core.Context.SaveChanges();
                }
                else
                {
                    book.IsFrozen = false;
                    book.MotiveID = null;
                    Core.Context.SaveChanges();
                }

                NavigationService.Navigate(new AdministrationPage());
            }
            else if (result == MessageBoxResult.No)
            {
                Core.Context.UnfreezeRequest.Remove(SelItem);
                Core.Context.SaveChanges();
                NavigationService.Navigate(new AdministrationPage());
            }
        }

        private void ComplList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
