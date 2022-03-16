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

namespace esoft.RolePage.Admin
{
    /// <summary>
    /// Логика взаимодействия для RemoteUser.xaml
    /// </summary>
    public partial class RemoteUser : Page
    {

        List<ListUsers> ListUsers = eSoftEntities.GetContext().ListUsers.ToList();

        public RemoteUser()
        {
            InitializeComponent();
            dataGridUserList.ItemsSource = ListUsers;
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            Button selectButton = sender as Button;
            int UserId = int.Parse(selectButton.Uid);
            User seachUser = eSoftEntities.GetContext().User.Where(i => i.id == UserId).ToList()[0];
            EditUserWindow editWindowsUser = new EditUserWindow(seachUser);
            editWindowsUser.Show();


        }

        private void ButtClickButtonSearcon_Click(object sender, RoutedEventArgs e)
        {
            List<ListUsers> filterUserList = ListUsers;
            if (TextBoxSearchBox.Text.ToString().Length > 1)
            {
                filterUserList = filterUserList.Where(i => (i.LastName.Contains(TextBoxSearchBox.Text.ToString()) || i.FirstName.Contains(TextBoxSearchBox.Text.ToString()) || i.MidlName.Contains(TextBoxSearchBox.Text.ToString()))).ToList();
                //filterUserList = filterUserList.Where(i => (i.Phone.Contains(TextBoxSearchBox.Text.ToString()) || i.Email.Contains(TextBoxSearchBox.Text.ToString()) || i.Role.Contains(TextBoxSearchBox.Text.ToString()) )).ToList();
            }
            dataGridUserList.ItemsSource = filterUserList;
        }

        private void clickAddUser(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/RolePage/Admin/addUser.xaml", UriKind.Relative));
        }
        
    }
}
