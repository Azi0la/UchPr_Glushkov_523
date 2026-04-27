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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            MainePage.NavigationService.Navigate(new Pages.CatalogPage());
        }

        private void ButtCatalog_Click(object sender, RoutedEventArgs e)
        {

            MainePage.NavigationService.Navigate(new Pages.CatalogPage());

        }

        private void ButtBookList_Click(object sender, RoutedEventArgs e)
        {
            MainePage.NavigationService.Navigate(new Pages.BookListPage());
        }

        private void ButtAdmin_Click(object sender, RoutedEventArgs e)
        {
            MainePage.NavigationService.Navigate(new Pages.AdministrationPage());
        }

        private void ButtAuthor_Click(object sender, RoutedEventArgs e)
        {
            MainePage.NavigationService.Navigate(new Pages.AuthorPage());
        }

        private void ButtUser_Click(object sender, RoutedEventArgs e)
        {
            MainePage.NavigationService.Navigate(new Pages.UserPage());
        }
    }
}
