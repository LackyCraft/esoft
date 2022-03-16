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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void clickButtonLogin(object sender, RoutedEventArgs e)
        {
            string readLogin = TextBoxLogin.Text;
            string readPassword = PasswordBoxPassword.Password.ToString();

         
            var seachUser = eSoftEntities.GetContext().User.Where(i => i.login == readLogin && i.password == readPassword).ToList();

            if (seachUser.Count > 0)
            {
                    Application.Current.Resources["idUser"] = seachUser[0].id;
                    Application.Current.Resources["Role"] = seachUser[0].RoleId;

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).ButtonAuth.Content = "Выход";
                            (window as MainWindow).ClientInfo.IsEnabled = true;
                        }
                    }


                if (seachUser[0].RoleId == "A")
                {
                    this.NavigationService.Navigate(new Uri("/RolePage/Admin/RemoteUser.xaml", UriKind.Relative));
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).ClientInfo.IsEnabled = false;
                            (window as MainWindow).ClientInfo.Background = (Brush)Application.Current.MainWindow.FindResource("Grey");
                            (window as MainWindow).ClientInfo.Foreground = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
                        }
                    }
                }
                else
                {
                    this.NavigationService.Navigate(new Uri("/RolePage/Client/UserInfo.xaml", UriKind.Relative));
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).ClientInfo.IsEnabled = true;
                            (window as MainWindow).ClientInfo.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
                            (window as MainWindow).ClientInfo.Foreground = (Brush)Application.Current.MainWindow.FindResource("DarkGrey3");
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Warning 422\n Неверный логин или пароль");
            }
            
        }

        private void clickButtonRegister(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Register.xaml",UriKind.Relative));
        }
    }
}
