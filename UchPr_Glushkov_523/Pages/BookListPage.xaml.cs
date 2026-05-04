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
        public BookListPage()
        {
            InitializeComponent();
            List<String> sorting = new List<String> { "По Названию", "По Оценке" };
            FilterBox.ItemsSource = sorting;
            List<String> status = new List<String> {"Заброшено", "В планах", "Читаю", "Прочитано" };
            StatusBox.ItemsSource = status;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
