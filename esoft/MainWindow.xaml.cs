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
            }
            else
            {
                MainFrame.NavigationService.Navigate(new Uri("Auth.xaml", UriKind.Relative));
            }
        }

        private void scrolPage(object sender, RoutedEventArgs e)
        {
            //Так, как навигации внутри фрейма отключена. То при каждом открытии новой вкладке она будет писаться поверх прошлой
            // Что ведет к утечке памяти. Поэтому при открытии новой вкладки чистим содержимое фрейма
            MainFrame.Content = null;
            if(Application.Current.Resources["Role"].ToString() != "A" && Application.Current.Resources["Role"].ToString() != "null")
                ClientInfo.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            RemoteNmobles.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            if (sender == ClientInfo)
            {
                MainFrame.NavigationService.Navigate(new Uri("/RolePage/Client/UserInfo.xaml", UriKind.Relative));
                (sender as Button).Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");
            }
            if (sender == RemoteNmobles)
            {
                MainFrame.NavigationService.Navigate(new Uri("/Nmobles/RemoteNmobles.xaml", UriKind.Relative));
                (sender as Button).Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");
            }
            if(sender == ButtonRegister)
                MainFrame.NavigationService.Navigate(new Uri("Register.xaml", UriKind.Relative));
        }
    }
}
