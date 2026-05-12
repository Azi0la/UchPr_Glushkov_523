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
            List<String> status = new List<String> {"All","Заброшено", "В планах", "Читаю", "Прочитано" };
            StatusBox.ItemsSource = status;
            BookList.ItemsSource = books;
            GenreList.ItemsSource = Genres;

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void BookList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BookPage(BookList.SelectedItem as Book));
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void StatusBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void Search()
        {
            var FilterBooks = Core.Context.Book.ToList();
            if (SearchBar == null && FilterBox ==null && StatusBox == null&& GenreList==null) return;
            
            if (!string.IsNullOrWhiteSpace(SearchBar.Text))
            {
                FilterBooks = FilterBooks.Where(p => p.Title.ToLower().Contains(SearchBar.Text.ToLower()) 
                || p.User.Name.ToLower().Contains(SearchBar.Text.ToLower())).ToList();
            }

            if(FilterBox.SelectedIndex == 0)
            {
                FilterBooks = FilterBooks.OrderBy(p => p.Title).ToList();
            }
            else if(FilterBox.SelectedIndex == 1)
            {
                FilterBooks = FilterBooks.OrderBy(p => p.Rating).ToList();
            }
            int z;
            switch (StatusBox.SelectedIndex)
            {

                case 1:
                    FilterBooks = FilterBooks.Where(c => c.ReadingList.Any(m => m.ReadingStatus.ID == StatusBox.SelectedIndex && m.UserID == MainWindow.user.ID)).ToList();
                    break;
                case 2:
                    z = StatusBox.SelectedIndex + 1;
                    FilterBooks = FilterBooks.Where(c => c.ReadingList.Any(m => m.ReadingStatus.ID == z && m.UserID == MainWindow.user.ID)).ToList();
                    break;
                 case 3:
                    z = StatusBox.SelectedIndex + 1;
                    FilterBooks = FilterBooks.Where(c => c.ReadingList.Any(m => m.ReadingStatus.ID == z && m.UserID == MainWindow.user.ID)).ToList();
                    break;
                case 4:
                    z = StatusBox.SelectedIndex + 1;
                    FilterBooks = FilterBooks.Where(c => c.ReadingList.Any(m => m.ReadingStatus.ID == z && m.UserID == MainWindow.user.ID)).ToList();
                    break;
                default:
                    break;
            }

            var b = new List<Genre>();
            foreach (var i in GenreList.Items){
                if (i)
                {
                }
            }
            Genre SelGen = GenreList.SelectedItem as Genre;
            if(SelGen != null)
            {
                List<BookGenre> g = Core.Context.BookGenre.Where(bg => bg.GenreID == (SelGen.ID)).ToList();
                FilterBooks = g.Select(genr => genr.Book).ToList();
            }
            


            BookList.ItemsSource = FilterBooks;
        }

    }
}
