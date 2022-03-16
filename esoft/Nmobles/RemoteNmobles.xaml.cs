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

namespace esoft.Nmobles
{
    /// <summary>
    /// Логика взаимодействия для RemoteNmobles.xaml
    /// </summary>
    public partial class RemoteNmobles : Page
    {
        public RemoteNmobles()
        {
            InitializeComponent();
        }

        private void ScrolPage(object sender, RoutedEventArgs e)
        {
            ButtonGoLand.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");
            ButtonGoHouse.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");
            ButtonGoApartaments.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");

            if (sender == ButtonGoLand)
            {
                FrameNmobles.NavigationService.Navigate(new Uri("/Nmobles/LandList.xaml",UriKind.Relative));
                ButtonGoLand.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            }
            if(sender == ButtonGoApartaments)
            {
                FrameNmobles.NavigationService.Navigate(new Uri("/Nmobles/ApartamentsList.xaml", UriKind.Relative));
                ButtonGoApartaments.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            }
            if (sender == ButtonGoHouse)
            {
                FrameNmobles.NavigationService.Navigate(new Uri("/Nmobles/Houses.xaml", UriKind.Relative));
                ButtonGoHouse.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            }
        }
    }
}
