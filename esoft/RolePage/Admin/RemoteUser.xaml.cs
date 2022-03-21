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

        List<ListUsers> ListUsersAll;

        public RemoteUser()
        {
            InitializeComponent();
            ListUsersAll = eSoftEntities.GetContext().ListUsers.Where(i => i.DeletedBy == null).ToList();
            dataGridUserList.ItemsSource = ListUsersAll;
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            Button selectButton = sender as Button;
            int UserId = int.Parse(selectButton.Uid);
            User seachUser = eSoftEntities.GetContext().User.Where(i => i.id == UserId).ToList()[0];
            EditUserWindow editWindowsUser = new EditUserWindow(seachUser);
            editWindowsUser.Show();


        }

        private void clickAddUser(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/RolePage/Admin/addUser.xaml", UriKind.Relative));
        }

        private void ChangedTextBoxSearchBox(object sender, TextChangedEventArgs e)
        {
            List<ListUsers> filterListUser = new List<ListUsers>();
            if (TextBoxSearchBox.Text.Length > 1)
            {
                foreach (ListUsers users in ListUsersAll)
                {
                    if (LevenshteinDistance(users.LastName.ToString(), TextBoxSearchBox.Text) <= 2 || LevenshteinDistance(users.FirstName.ToString(), TextBoxSearchBox.Text) <= 2 || LevenshteinDistance(users.MidlName.ToString(), TextBoxSearchBox.Text) <= 2 || users.LastName.ToString().Contains(TextBoxSearchBox.Text.ToString()) || users.FirstName.ToString().Contains(TextBoxSearchBox.Text.ToString()) || users.MidlName.ToString().Contains(TextBoxSearchBox.Text.ToString()))
                        filterListUser.Add(users);
                }
            }
            else
            {
                filterListUser = ListUsersAll;
            }

            dataGridUserList.ItemsSource = filterListUser;

        }

        private void DeletedAt(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources["idUser"].ToString() == "null" && Application.Current.Resources["Role"].ToString() != "C")
            {
                MessageBox.Show("Warning 403\nНеобходимо автроизоваться под ролью Администратора или Риелтора");
            }
            else
            {
                if (MessageBox.Show("Вы точно хотите удалить данную запись?",
                    "Save file",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int selectedDellIdUser = (dataGridUserList.SelectedItem as ListUsers).UserId;
                    (eSoftEntities.GetContext().User.Where(i => i.id == selectedDellIdUser).ToList()[0] as User).DeletedBy = int.Parse(Application.Current.Resources["idUser"].ToString());
                    eSoftEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись успешно удалена");
                    ListUsersAll = eSoftEntities.GetContext().ListUsers.Where(i => i.DeletedBy == null).ToList();
                    dataGridUserList.ItemsSource = ListUsersAll;
                }
            }
        }

        public static int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null) string1 = "";
            if (string2 == null) string2 = "";
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
                }
            }
            return m[string1.Length, string2.Length];
        }

    }
}
