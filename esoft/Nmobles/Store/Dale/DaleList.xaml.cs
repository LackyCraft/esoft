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

namespace esoft.Nmobles.Store.Dale
{
    /// <summary>
    /// Логика взаимодействия для DaleList.xaml
    /// </summary>
    public partial class DaleList : Page
    {
        public DaleList()
        {
            InitializeComponent();
            DataGridDaleList.ItemsSource = eSoftEntities.GetContext().Demand.Where(i => (i.DealNmobles != null && i.DeletedBy == null)).ToList();
        }
        private void addDale(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources["idUser"].ToString() == "null" && Application.Current.Resources["Role"].ToString() != "C")
            {
                MessageBox.Show("Warning 403\nНеобходимо автроизоваться под ролью Администратора или Риелтора");
            }
            else
            {
                this.NavigationService.Navigate(new AddDale());
            }
        }
        private void ButtClickButtonSearchClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
