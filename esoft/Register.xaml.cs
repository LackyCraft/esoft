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

namespace esoft
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void clickButtonRegister(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            string messageWarning = "";
            string newLogin = TextBoxLogin.Text;
            var loginCheck = eSoftEntities.GetContext().User.Where(i => i.login == newLogin).ToList();
            TextBoxLogin.Background = Brushes.White;
            PasswordBoxPassword.Background = Brushes.White;
            PasswordBoxDoublePassword.Background = Brushes.White;
            WarningContactItem.Foreground = (Brush)bc.ConvertFrom("#546e7a");
            TextBoxNumberPhone.Background = Brushes.White;

            if (loginCheck.Count > 0)
            {
                MessageBox.Show("Error 422\nТакой логин уже зарегистрирован в системе выберите другой логин");
                TextBoxLogin.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (PasswordBoxPassword.Password.ToString().Length < 6)
            {
                MessageBox.Show("Error 422\n Пароль должен содержать не меньше 6 символов");
                PasswordBoxPassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if(PasswordBoxPassword.Password.ToString() != PasswordBoxDoublePassword.Password.ToString())
            {
                messageWarning = "Пароли не совпадают";
                PasswordBoxPassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
                PasswordBoxDoublePassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (TextBoxEmail.Text.Length < 3 && TextBoxNumberPhone.Text.Length != 12)
            {
                WarningContactItem.Foreground = (Brush)Application.Current.MainWindow.FindResource("Warning");
                if (TextBoxNumberPhone.Text.Length != 12)
                {
                    TextBoxNumberPhone.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
                    messageWarning += "\nТелефон должен содержать ровно 12 цифр";
                }
            }


            if (messageWarning.Length > 2)
            {
                TextBlockWarning.Text = messageWarning;
            }
            else
            {
                User newUser = new User();
                newUser.login = TextBoxLogin.Text;
                newUser.password = PasswordBoxPassword.Password.ToString();
                newUser.RoleId = "C";

                eSoftEntities.GetContext().User.Add(newUser);

                Client newClient = new Client();
                newClient.UserId = newUser.id;
                if (TextBoxLastName.Text.Length > 3)
                {
                    newClient.LastName = TextBoxLastName.Text;
                }
                else
                {
                    newClient.LastName = null;
                }
                if (TextBoxFirstName.Text.Length > 3)
                {
                    newClient.FirstName = TextBoxFirstName.Text;
                }
                else
                {
                    newClient.FirstName = null;
                }
                if (TextBoxMidlName.Text.Length > 1)
                {
                    newClient.MidlName = TextBoxMidlName.Text;
                }
                else
                {
                    newClient.MidlName = null;
                }
                if (TextBoxEmail.Text.Length > 3)
                {
                    newClient.Email = TextBoxEmail.Text;
                }
                else
                {
                    newClient.Email = null;
                }
                if (TextBoxNumberPhone.Text.Length == 12)
                {
                    newClient.Phone = TextBoxNumberPhone.Text;
                }
                else
                {
                    newClient.Phone = null;
                }

                eSoftEntities.GetContext().Client.Add(newClient);
                eSoftEntities.GetContext().SaveChanges();

                MessageBox.Show("Вы были успешно зарегестрированы");

                this.NavigationService.Navigate(new Uri("Auth.xaml", UriKind.Relative));

            }
        }
    }
}
