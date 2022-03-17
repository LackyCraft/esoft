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
    /// Логика взаимодействия для PayStoreMain.xaml
    /// </summary>
    public partial class PayStoreMain : Page
    {
        private Button selectNmobles;

        public PayStoreMain(object sender)
        {
            InitializeComponent();
            selectNmobles = (sender as Button);
        }
        private void ScrolPage(object sender, RoutedEventArgs e)
        {
            FrameNmobles.Content = null;

            //Меняем цвет в normal
            ButtonGoLand.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            ButtonGoHouse.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");
            ButtonGoApartaments.Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey");

            //Меняем цвет нажатую кнопку в Hover
            (sender as Button).Background = (Brush)Application.Current.MainWindow.FindResource("DarkGrey1");

            //В Uid кнопки храниться ТИП недвижимости "H" "L" или "A" - передаем тип в SuppliesStore, что бы отобразить в фрайм необхадимую таблицу
            if (selectNmobles.Name == "ButtonSupplies")
            {
                FrameNmobles.NavigationService.Navigate(new Nmobles.Store.SuppliesStore((sender as Button).Uid));
            }
        }
    }
}
