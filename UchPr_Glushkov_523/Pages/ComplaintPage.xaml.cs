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

        private Book curbook;
        private User curuser;
        private Review currev;
        public ComplaintPage(Book BookID= null, User usId = null, Review RevID = null)
        {
            InitializeComponent();
            curbook = BookID;
            curuser = usId;
            currev = RevID;
            CompLB.Content = ("Жалоба на ");
            if (BookID != null) {
                CompLB.Content += ("книгу:");
                BookLB.Content = (BookID.Title); 
            }
            if (usId != null)
            {
                CompLB.Content += ("автора:");
                AuthLB.Content = (usId.Name);
            }
            if (RevID != null)
            {
                CompLB.Content += ("комментарий:");
                ReviewLB.Content = (RevID.User.Name);
            }
            
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) NavigationService.GoBack();
        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            Complaint NewComp = new Complaint 
            {
                TargetUserId = curuser.ID,
                BookId = curbook.ID,
                ReviewId = currev.ID,
                Reason = ComplTB.Text,
                AdminID = MainWindow.user.ID
            };
            Core.Context.Complaint.Add(NewComp);
            Core.Update();
            MessageBox.Show("Жалоба отправлена!");
            if (NavigationService.CanGoBack) NavigationService.GoBack();
        }

        private void ComplTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ComplTB.Text) && !string.IsNullOrEmpty(ComplTB.Text))
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
