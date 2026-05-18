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
        public BookRedactPage(int i, Book _book)
        {
            InitializeComponent();
            GenreList.ItemsSource = g;
            book = _book;
            
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
                //GenreList.Loaded += GenreBox_Loaded;
                
            }
        }


        

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {

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
