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
    /// Логика взаимодействия для AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page
    {
        public static List<Book> books = Core.Context.Book.ToList();
        public AuthorPage()
        {
            InitializeComponent();
            BookAuthList.ItemsSource = books.Where(c => c.AuthorID == MainWindow.user.ID && c.IsFrozen == false).ToList();
            BookFrozenList.ItemsSource = books.Where(c => c.AuthorID == MainWindow.user.ID && c.IsFrozen == true).ToList();
        }

        private void BookAuthList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void BookFrozenList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
