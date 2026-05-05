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
        public static List<ReadingList> rl = Core.Context.ReadingList.ToList();
        Book book;
        public BookPage(Book _book)
        {
            InitializeComponent();
            book = _book;
            DataContext = _book;
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
                case 1:
                    var z = rl.FirstOrDefault(c => c.UserID == MainWindow.user.ID && c.BookID == book.ID);
                    if (z == null)
                    {
                        var n = new ReadingList
                        {
                            UserID = MainWindow.user.ID,
                            BookID = book.ID,
                            Status = "Заброшено"
                        };
                        Core.Context.ReadingList.Add(n);
                    }
                    else if (z.Status != "Заброшено")
                    {
                        z.Status = "Заброшено";
                    }
                    Core.Context.SaveChanges();
                    break;
                case 2:
                    var v = rl.FirstOrDefault(c => c.UserID == MainWindow.user.ID && c.BookID == book.ID);
                    if (v == null)
                    {
                        var n = new ReadingList
                        {
                            UserID = MainWindow.user.ID,
                            BookID = book.ID,
                            Status = "В планах"
                        };
                        Core.Context.ReadingList.Add(n);
                    }
                    else if (v.Status != "В планах")
                    {
                        v.Status = "В планах";
                        
                    }
                    Core.Context.SaveChanges();
                    break;
                case 3:
                    var ch = rl.FirstOrDefault(c => c.UserID == MainWindow.user.ID && c.BookID == book.ID);
                    if (ch == null)
                    {
                        var n = new ReadingList
                        {
                            UserID = MainWindow.user.ID,
                            BookID = book.ID,
                            Status = "Читаю"
                        };
                        Core.Context.ReadingList.Add(n);
                    }
                    else if (ch.Status != "Читаю")
                    {
                        ch.Status = "Читаю";

                    }
                    Core.Context.SaveChanges();
                    break;
                case 4:
                    var p = rl.FirstOrDefault(c => c.UserID == MainWindow.user.ID && c.BookID == book.ID);
                    if (p == null)
                    {
                        var n = new ReadingList
                        {
                            UserID = MainWindow.user.ID,
                            BookID = book.ID,
                            Status = "Прочитано"
                        };
                        Core.Context.ReadingList.Add(n);
                    }
                    else if (p.Status != "Прочитано")
                    {
                        p.Status = "Прочитано";

                    }
                    Core.Context.SaveChanges();
                    break;
                default:
                    
                    break;
            }
        }

        private void ReadBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReadPage(book));
        }

        private void Loading()
        {
            
            ReviewList.ItemsSource = r.Where(c => c.BookID == book.ID).ToList();
            List<String> sorting = new List<String> { "Заброшено", "В планах", "Читаю", "Прочитано" };
            List<BookGenre> bookGenres = bg.Where(c => c.BookID == book.ID).ToList();
            StatusCB.ItemsSource = sorting;
            int count = book.Review.Count;
            CountTB.Text = "Кол-во отзывов: " + count;

            var z = rl.FirstOrDefault(c => c.UserID == MainWindow.user.ID && c.BookID == book.ID);
            if (z != null)
            {
                StatusCB.SelectedItem = z.Status;
            }

            //var lbl = bookGenres.Select();

            foreach (BookGenre b in bookGenres)
            {
                GenreTB.Text += g.FirstOrDefault(c => c.ID == b.GenreID).Name.ToString();
                GenreTB.Text += " ";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
=> Loading();
    }
}
