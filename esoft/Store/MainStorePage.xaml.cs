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

namespace esoft.Store
{
    /// <summary>
    /// Логика взаимодействия для MainStorePage.xaml
    /// </summary>
    public partial class MainStorePage : Page
    {
        public MainStorePage()
        {
            InitializeComponent();
        }

        private void ScrolPage(object sender, RoutedEventArgs e)
        {
            FrameNmobles.Content = null;

            //Закрашиваем все кнопки в Normal
            ButtonSupplies.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            ButtonPay.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            GoodDeal.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");

            //Закрашиваем нажатую кнопку в Hover
            (sender as Button).Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");

            //Передаем в PayStoreMain кнопку, что бы определить какую вкладку мы открываем
            if (sender == ButtonSupplies || sender == ButtonPay)
                FrameNmobles.NavigationService.Navigate(new PayStoreMain(sender));
            if (sender == GoodDeal)
                FrameNmobles.NavigationService.Navigate(new esoft.Nmobles.Store.Dale.DaleList());

        }
    }
}
