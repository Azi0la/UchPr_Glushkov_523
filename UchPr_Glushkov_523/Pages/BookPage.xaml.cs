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
        public List<BookGenre> bg = Core.Context.BookGenre.ToList();
        public List<Genre> g = Core.Context.Genre.ToList();
        public List<Review> r = Core.Context.Review.ToList();
        public List<ReadingList> rl = Core.Context.ReadingList.ToList();
        Book book;
        public BookPage(Book _book)
        {
            InitializeComponent();
            book = _book;
            DataContext = _book;

           
        }
        private void Loading()
        {
            ReviewList.ItemsSource = null;
            StatusCB.ItemsSource = null;
            ReviewList.ItemsSource = r.Where(c => c.BookID == book.ID).ToList();
            List<String> sorting = new List<String> { "Заброшено", "В планах", "Читаю", "Прочитано" };
            List<BookGenre> bookGenres = bg.Where(c => c.BookID == book.ID).ToList();
            StatusCB.ItemsSource = sorting;
            int count = book.Review.Count;
            CountTB.Text = "Кол-во отзывов: " + count;

            var z = rl.FirstOrDefault(c => c.UserID == MainWindow.user.ID && c.BookID == book.ID);
            if (z != null)
            {
                StatusCB.SelectedIndex = z.StatusID - 1;
            }

            //var lbl = bookGenres.Select();
            GenreTB.Text = "Жанры: ";
            foreach (BookGenre b in bookGenres)
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
                    var z = rl.FirstOrDefault(c => c.UserID == MainWindow.user.ID && c.BookID == book.ID);
                    if (z == null)
                    {
                        var n = new ReadingList
                        {
                            UserID = MainWindow.user.ID,
                            BookID = book.ID,
                            StatusID = 1
                        };
                        Core.Context.ReadingList.Add(n);
                    }
                    else if (z.StatusID != 1)
                    {
                        z.StatusID = 1;
                    }
                    Core.Context.SaveChanges();
                    break;
                case 1:
                    var v = rl.FirstOrDefault(c => c.UserID == MainWindow.user.ID && c.BookID == book.ID);
                    if (v == null)
                    {
                        var n = new ReadingList
                        {
                            UserID = MainWindow.user.ID,
                            BookID = book.ID,
                            StatusID = 2
                        };
                        Core.Context.ReadingList.Add(n);
                    }
                    else if (v.StatusID != 2)
                    {
                        v.StatusID = 2;

                    }
                    Core.Context.SaveChanges();
                    break;
                case 2:
                    var ch = rl.FirstOrDefault(c => c.UserID == MainWindow.user.ID && c.BookID == book.ID);
                    if (ch == null)
                    {
                        var n = new ReadingList
                        {
                            UserID = MainWindow.user.ID,
                            BookID = book.ID,
                            StatusID = 3
                        };
                        Core.Context.ReadingList.Add(n);
                    }
                    else if (ch.StatusID != 3)
                    {
                        ch.StatusID = 3;

                    }
                    Core.Context.SaveChanges();
                    break;
                case 3:
                    var p = rl.FirstOrDefault(c => c.UserID == MainWindow.user.ID && c.BookID == book.ID);
                    if (p == null)
                    {
                        var n = new ReadingList
                        {
                            UserID = MainWindow.user.ID,
                            BookID = book.ID,
                            StatusID = 4
                        };
                        Core.Context.ReadingList.Add(n);
                    }
                    else if (p.StatusID != 4)
                    {
                        p.StatusID = 4;

                    }
                    Core.Context.SaveChanges();
                    break;
                default:

                    break;
            }
            rl = Core.Context.ReadingList.ToList();
        }

        private void ReadBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReadPage(book));
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
=> Loading();

        private void ReviewBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReviewPage(book));
        }

        private void BookComplBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ComplaintPage(book));
        }

        private void AuthComplBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ComplaintPage(null, book.User));
        }

        private void RevComplBTN_Click(object sender, RoutedEventArgs e)
        {
            Button Btn = sender as Button;
            Review SelectRev = Btn.DataContext as Review;
            NavigationService.Navigate(new ComplaintPage(null, null, SelectRev));
        }
    }
}

