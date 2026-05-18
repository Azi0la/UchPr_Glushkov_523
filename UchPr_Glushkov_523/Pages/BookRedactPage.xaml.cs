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
    /// Логика взаимодействия для BookRedactPage.xaml
    /// </summary>
    public partial class BookRedactPage : Page
    {
        private Book book;
        public List<Genre> g = Core.Context.Genre.ToList();
        public List<int> selGenres = new List<int>();
        public static int status;
        public BookRedactPage(int i, Book _book)
        {
            InitializeComponent();
            GenreList.ItemsSource = g;
            book = _book;
            status = i;
            
            if(i == 1)
            {
                BookRedLB.Content = ("Создание книги");
            }
            else if(i == 2)
            {
                BookRedLB.Content = ("Редактирование книги");
                TitleTB.Text = book.Title;
                DescriptionTB.Text = book.Description;
                PathTB.Text = book.ImagePath;
                FillingTB.Text = book.Filling;
                selGenres = book.BookGenre.Select(x => x.GenreID).ToList();
                
                
            }
        }


        

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTB.Text) && string.IsNullOrWhiteSpace(FillingTB.Text))
            {
                MessageBox.Show("Название книги и наполнение обязательно!");
                return;
            }

            book.Title = TitleTB.Text;
            book.Description = DescriptionTB.Text;
            book.ImagePath = PathTB.Text;
            book.Filling = FillingTB.Text;

            try
            {
                if (book.ID == 0) 
                {
                    Core.Context.Book.Add(book);
                }

                Core.Context.SaveChanges(); 

               
                var oldGenres = Core.Context.BookGenre.Where(bg => bg.BookID == book.ID).ToList();
                Core.Context.BookGenre.RemoveRange(oldGenres);

       
                foreach (var item in GenreList.Items)
                {
                    var container = GenreList.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                    if (container != null)
                    {
                        var cb = FindVisualChild<CheckBox>(container);
                        if (cb?.IsChecked == true && cb.Tag is int genreId)
                        {
                            Core.Context.BookGenre.Add(new BookGenre
                            {
                                BookID = book.ID,
                                GenreID = genreId
                            });
                        }
                    }
                }

                Core.Context.SaveChanges();

                MessageBox.Show("Сохранено успешно!");
                NavigationService?.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        
        private static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                if (child is T t) return t;
                var found = FindVisualChild<T>(child);
                if (found != null) return found;
            }
            return null;
        }

        private void GenreBox_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GenreBox_Checked(object sender, RoutedEventArgs e)
        {
     
        }

        private void GenreBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void GenreBox_Loaded(object sender, RoutedEventArgs e)
        {

        }


    }
}
