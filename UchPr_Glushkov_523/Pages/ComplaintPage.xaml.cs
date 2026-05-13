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
    /// Логика взаимодействия для ComplaintPage.xaml
    /// </summary>
    public partial class ComplaintPage : Page
    {
        //public class Compl 
        //{
        //    public int? UserID { get; set; }
        //    public int? BookID { get; set; }
        //    public int? ReviewID { get; set; }
        //    public string Reason { get; set; }
        //    public int AuthorID { get; set; }
        //}
        public ComplaintPage(Book BookID= null, User usId = null, Review RevID = null)
        {
            InitializeComponent();
            
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) NavigationService.GoBack();
        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
