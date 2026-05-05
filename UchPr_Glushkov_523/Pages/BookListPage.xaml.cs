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
    /// Логика взаимодействия для BookListPage.xaml
    /// </summary>
    public partial class BookListPage : Page
    {

        public static List<BookGenre> bg = Core.Context.BookGenre.ToList();
        public static List<Genre> g = Core.Context.Genre.ToList();
        public static List<Review> r = Core.Context.Review.ToList();
        public static List<ReadingList> rl = Core.Context.ReadingList.ToList();
        public static List<Book> books = Core.Context.Book.ToList();
        public static List<Genre> Genres = Core.Context.Genre.ToList();

        public BookListPage()
        {
            InitializeComponent();
            List<String> sorting = new List<String> { "По Названию", "По Оценке" };
            FilterBox.ItemsSource = sorting;
            List<String> status = new List<String> {"Заброшено", "В планах", "Читаю", "Прочитано" };
            StatusBox.ItemsSource = status;
            BookList.ItemsSource = books;
            GenreList.ItemsSource = Genres;

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton rb = sender as RadioButton;
                int f = 0;
                if (int.TryParse(rb.Tag.ToString(), out int taga))
                    f = taga;

                List<BookGenre> g = Core.Context.BookGenre.Where(bg => bg.GenreID == (f)).ToList();
                BookList.ItemsSource = g.Select(genr => genr.Book);
            }
        }

        private void BookList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BookPage(BookList.SelectedItem as Book));
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

        private void StatusBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int z;
            z = StatusBox.SelectedIndex + 1;
            BookList.ItemsSource = books.Where(c => c.ReadingList.Any(m => m.ReadingStatus.ID == z && m.UserID == MainWindow.user.ID));
        }
    }
}
