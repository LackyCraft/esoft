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
                StackPanelMenu.IsEnabled = false;
            }
            else
            {
                MainFrame.NavigationService.Navigate(new Uri("Auth.xaml", UriKind.Relative));
            }
        }

        private void scrolPage(object sender, RoutedEventArgs e)
        {
            if(sender == ClientInfo)
            {
                MainFrame.NavigationService.Navigate(new Uri("/RolePage/Client/UserInfo.xaml", UriKind.Relative));
            }
        }
    }
}
