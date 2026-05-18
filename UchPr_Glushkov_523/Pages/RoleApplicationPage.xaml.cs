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
    /// Логика взаимодействия для RoleApplicationPage.xaml
    /// </summary>
    public partial class RoleApplicationPage : Page
    {
        public RoleApplicationPage()
        {
            InitializeComponent();
        }

        private void SendBTN_Click(object sender, RoutedEventArgs e)
        {
            RoleApplication RA = new RoleApplication
            {
                UserID = MainWindow.user.ID,
                IsProcessed = false,
                Reason = ReasonTB.Text
            };
            Core.Context.RoleApplication.Add(RA);
            Core.Context.SaveChanges();
            MessageBox.Show("Заявка отправлена!");
            NavigationService.Navigate(new UserPage());
        }

        private void ReasonTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ReasonTB.Text))
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
