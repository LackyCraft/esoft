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
    /// Логика взаимодействия для RegisterRieltor.xaml
    /// </summary>
    public partial class RegisterRieltor : Page
    {
        public RegisterRieltor()
        {
            InitializeComponent();
        }

        private void textBlockShareTextChanged(object sender, RoutedEventArgs e)
        {
            Byte res;
            if (!(Byte.TryParse(TextBlockShare.Text, out res) && res >= 0 && res <= 100))
            {
                MessageBox.Show("Warning 422\nПроцентная ставка может принимать значения от 0 до 100");
                TextBlockShare.Text = "0";
            }
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
            TextBoxLastName.Background = Brushes.White;
            TextBoxFirstName.Background = Brushes.White;
            TextBoxMidlName.Background = Brushes.White;

            if (loginCheck.Count > 0)
            {
                MessageBox.Show("Error 422\nТакой логин уже зарегистрирован в системе выберите другой логин");
                TextBoxLogin.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (!(TextBoxLogin.Text.Length > 0))
            {
                messageWarning = "Логин - обязателен для заполнения";
                TextBoxLogin.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (PasswordBoxPassword.Password.ToString().Length < 6)
            {
                MessageBox.Show("Error 422\n Пароль должен содержать не меньше 6 символов");
                PasswordBoxPassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (PasswordBoxPassword.Password.ToString() != PasswordBoxDoublePassword.Password.ToString())
            {
                messageWarning += "\nПароли не совпадают";
                PasswordBoxPassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
                PasswordBoxDoublePassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (!(TextBoxLastName.Text.Length > 0))
            {
                messageWarning += "\nИмя - обязательно для заполнения";
                TextBoxLastName.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (!(TextBoxFirstName.Text.Length > 0))
            {
                messageWarning += "\nФамиилия - обязательно для заполнения";
                TextBoxFirstName.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (!(TextBoxMidlName.Text.Length > 0))
            {
                messageWarning += "\nОтчество - обязательно для заполнения";
                TextBoxMidlName.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }



            if (messageWarning.Length > 2)
            {
                TextBlockWarning.Text = messageWarning;
            }
            else
            {
                try
                {
                    User newUser = new User();
                    newUser.login = TextBoxLogin.Text;
                    newUser.password = PasswordBoxPassword.Password.ToString();
                    newUser.RoleId = "R";

                    eSoftEntities.GetContext().User.Add(newUser);

                    Realtor newRealtor = new Realtor();
                    newRealtor.idUser = newUser.id;
                    newRealtor.LastName = TextBoxLastName.Text;
                    newRealtor.FirstName = TextBoxFirstName.Text;
                    newRealtor.MidlName = TextBoxMidlName.Text;
                    newRealtor.share = int.Parse(TextBlockShare.Text);

                    eSoftEntities.GetContext().Realtor.Add(newRealtor);
                    eSoftEntities.GetContext().SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно");
                    this.NavigationService.Navigate(new Uri("/RolePage/Admin/RemoteUser.xaml", UriKind.Relative));
                }
                catch
                {
                    MessageBox.Show("Error 505\nПроизошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
                    this.Content = null;
                    this.NavigationService.Navigate(new Uri("/RolePage/Admin/RemoteUser.xaml", UriKind.Relative));
                }
            }
        }
    }
}
