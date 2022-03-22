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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Resources["idUser"] = "null";
            Application.Current.Resources["Role"] = "null";
            MainFrame.NavigationService.Navigate(new Uri("Auth.xaml", UriKind.Relative));
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void AuthClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            //MainFrame.NavigationService.Navigate(new Uri("AuthWindow.xaml", UriKind.Relative));
            if (clickedButton.Content == "Выход")
            {
                clickedButton.Content = "Войти";
                MainFrame.Content = null;
                Application.Current.Resources["idUser"] = "null";
                Application.Current.Resources["Role"] = "null";
                ClientInfo.Background = (Brush)Application.Current.MainWindow.FindResource("Grey");
                ClientInfo.IsEnabled = false;
            }
            else
            {
                MainFrame.NavigationService.Navigate(new Uri("Auth.xaml", UriKind.Relative));
            }
            //Button Register new Client
            if (sender == ButtonRegister)
                MainFrame.NavigationService.Navigate(new Uri("/Register.xaml", UriKind.Relative));
        }

        private void scrolPage(object sender, RoutedEventArgs e)
        {
            //Так, как навигации внутри фрейма отключена. То при каждом открытии новой вкладке она будет писаться поверх прошлой
            // Что ведет к утечке памяти. Поэтому при открытии новой вкладки чистим содержимое фрейма
            MainFrame.Content = null;


            //Перекраска кнопок меню. Нажатая в Hover не нажатые в Normal
            RemoteNmobles.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            Store.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            DealShare.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");

            //Если пользователь не админ и авторизован, то кнопку Личной карточки так же красим в Normal
            if (Application.Current.Resources["Role"].ToString() != "null" && Application.Current.Resources["Role"].ToString() != "A")
            {
                ClientInfo.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            }

            //Красим в Hover нажатую кнопку
            (sender as Button).Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");

            //Buttons menu
            if (sender == ClientInfo)
                MainFrame.NavigationService.Navigate(new Uri("/RolePage/Client/UserInfo.xaml", UriKind.Relative));
            if (sender == RemoteNmobles)
                MainFrame.NavigationService.Navigate(new Uri("/Nmobles/RemoteNmobles.xaml", UriKind.Relative));
            if (sender == Store)
                MainFrame.NavigationService.Navigate(new Uri("/Store/MainStorePage.xaml", UriKind.Relative));
            if (sender == DealShare)
                MainFrame.NavigationService.Navigate(new Uri("/ShareDale.xaml", UriKind.Relative));

        }
    }
}
