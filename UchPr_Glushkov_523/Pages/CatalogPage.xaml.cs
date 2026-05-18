using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public List<Book> books = Core.Context.Book.ToList();
        public static List<BookGenre> bg = Core.Context.BookGenre.ToList();
        public static List<Genre> g = Core.Context.Genre.ToList();
        public List<Genre> Genres = Core.Context.Genre.ToList();
        public List<Genre> selectedGenres = new List<Genre>();

        public CatalogPage()
        {
            InitializeComponent();
            Core.Update();
            books = Core.Context.Book.ToList();
            BookList.ItemsSource = books.Where(c => c.IsFrozen == false);
            Genres = Core.Context.Genre.ToList();
            List<String> sorting = new List<String> { "По Названию", "По Оценке" };
            FilterBox.ItemsSource = sorting;
            GenreList.ItemsSource = Genres;
            
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void BookList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new BookPage(BookList.SelectedItem as Book));
        }



        private void Search()
        {
            var FilterBooks = Core.Context.Book.ToList();
            FilterBooks = FilterBooks.Where(c => c.IsFrozen == false).ToList();
            if (SearchBar == null && FilterBox == null && GenreList == null) return;

            if (!string.IsNullOrWhiteSpace(SearchBar.Text))
            {
                FilterBooks = FilterBooks.Where(p => p.Title.ToLower().Contains(SearchBar.Text.ToLower())
                || p.User.Name.ToLower().Contains(SearchBar.Text.ToLower())).ToList();
            }

            if (FilterBox.SelectedIndex == 0)
            {
                FilterBooks = FilterBooks.OrderBy(p => p.Title).ToList();
            }
            else if (FilterBox.SelectedIndex == 1)
            {
                FilterBooks = FilterBooks.OrderByDescending(p => p.Rating).ToList();
            }


            FilterBooks = FilterBooks.Where(fb => selectedGenres.All(sg => fb.BookGenre.Any(bg => bg.GenreID == sg.ID))).ToList();


            BookList.ItemsSource = FilterBooks;
        }

        private void GenreBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            selectedGenres.Add(g.FirstOrDefault(genr => genr.Name == checkBox.Content.ToString()));
        }

        private void GenreBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            selectedGenres.Remove(g.FirstOrDefault(genr => genr.Name == checkBox.Content.ToString()));
        }

    }
}
