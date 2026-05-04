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
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        public static List <BookGenre> bg = Core.Context.BookGenre.ToList();
        public static List <Genre> g = Core.Context.Genre.ToList();
        public static List <Review> r = Core.Context.Review.ToList();
        Book book;
        public BookPage(Book _book)
        {
            InitializeComponent();
            book = _book;
            DataContext = _book;
            ReviewList.ItemsSource = r.Where(c => c.BookID == _book.ID).ToList();
            List<String> sorting = new List<String> { "Заброшено", "В планах", "Читаю", "Прочитано" };
            List <BookGenre> bookGenres = bg.Where(c => c.BookID == _book.ID).ToList();
            StatusCB.ItemsSource = sorting;
            int count = _book.Review.Count;
            CountTB.Text = "Кол-во отзывов: " + count;
            

            foreach(BookGenre b in bookGenres)
            {
                GenreTB.Text += g.FirstOrDefault(c => c.ID == b.GenreID).Name.ToString();
                GenreTB.Text += " ";
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void StatusCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (StatusCB.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    
                    break;
            }
        }

        private void ReadBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReadPage(book));
        }
    }
}
