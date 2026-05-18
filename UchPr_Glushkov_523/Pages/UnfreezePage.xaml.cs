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
    /// Логика взаимодействия для UnfreezePage.xaml
    /// </summary>
    public partial class UnfreezePage : Page
    {
        private Book curbook;
        private User curuser;
        public UnfreezePage(Book BookID = null, User usId = null)
        {
            InitializeComponent();
            curbook = BookID;
            curuser = usId;
            UnfrzLB.Content = ("Оспаривание заморозки ");
            if (BookID != null)
            {
                UnfrzLB.Content += ("книги:");
                BookLB.Content = (BookID.Title);
            }
            if (usId != null)
            {
                UnfrzLB.Content += ("автора:");
                AuthLB.Content = (usId.Name);
            }
        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            UnfreezeRequest Unfrq = new UnfreezeRequest
            {
                AdminID = MainWindow.user.ID,
                BookID = curbook?.ID,
                Reason = UnfrzTB.Text,
                IsProcessed = false,
                UserID = curuser?.ID
            };
            Core.Context.UnfreezeRequest.Add(Unfrq);
            Core.Context.SaveChanges();
            MessageBox.Show("Оспаривание отправлено!");
            if (NavigationService.CanGoBack) NavigationService.GoBack();
        }

        private void UnfrzTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(UnfrzTB.Text))
            {
                SendBTN.IsEnabled = true;
            }
            else
            {
                SendBTN.IsEnabled = false;
            }
        }
    }
}
