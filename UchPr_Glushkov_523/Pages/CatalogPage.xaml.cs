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
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        public static List<Book> books = Core.Context.Book.ToList();
        public static List<Genre> Genres = Core.Context.Genre.ToList();
        public CatalogPage()
        {
            InitializeComponent();
            BookList.ItemsSource = books;
            List<String> sorting = new List<String> { "По Названию", "По Оценке" };
            FilterBox.ItemsSource = sorting;
            GenreList.ItemsSource = Genres;
            
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (FilterBox.SelectedIndex)
            {
                case 0:
                    BookList.ItemsSource = books.OrderBy(p => p.Title);
                    break;
                case 1:
                    BookList.ItemsSource = books.OrderBy(p => p.Rating);
                    break;
                default:
                    BookList.ItemsSource = books.OrderBy(p => p.Title);
                    break;
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            BookList.ItemsSource = books.Where(p => p.Title.ToLower().Contains(SearchBar.Text.ToLower()) || p.User.Name.ToLower().Contains(SearchBar.Text.ToLower()));
        }

        private void BookList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BookPage(BookList.SelectedItem as Book));
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton rb = sender as RadioButton; 
                int f=0;
                if (int.TryParse(rb.Tag.ToString(), out int taga))
                    f = taga;
                
                List<BookGenre> g = Core.Context.BookGenre.Where(bg => bg.GenreID == (f)).ToList();
                BookList.ItemsSource = g.Select(genr=>genr.Book);
            }
        } 
    }
}
