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
    /// Логика взаимодействия для ReviewPage.xaml
    /// </summary>
    public partial class ReviewPage : Page
    {
        private Book book;
        public ReviewPage(Book _book)
        {
            InitializeComponent();
            book = _book;
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) { NavigationService.GoBack(); }
        }

        private void RevNumTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(RevNumTB.Text) && !string.IsNullOrEmpty(RevNumTB.Text))
            {
                RevBTN.IsEnabled = true;
            }
            else
            {
                RevBTN.IsEnabled = false;
            }
        }

        private void RevBTN_Click(object sender, RoutedEventArgs e)
        {
            List<string> nums = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            if (nums.Contains(RevNumTB.Text))
            {
                int be = int.Parse(RevNumTB.Text);
                Review rev = new Review
                {
                    UserID = MainWindow.user.ID,
                    BookID = book.ID,
                    Rating = be,
                    CreateDate = DateTime.Now,
                    Text = RevTextTB.Text
                };
                Core.Context.Review.Add(rev);
                Core.Context.SaveChanges();
                MessageBox.Show("Комментарий опубликован!");
                NavigationService.Navigate(new CatalogPage());
            }
            else 
            {
                MessageBox.Show("Оценка введена неккоректно!");
            }
        }
    }
}
