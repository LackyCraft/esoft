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
    /// Логика взаимодействия для Houses.xaml
    /// </summary>
    public partial class Houses : Page
    {
        public Houses()
        {
            InitializeComponent();
            DataGridHouses.ItemsSource = eSoftEntities.GetContext().Houses.ToList();
        }
        private void DeletedAt(object sender, RoutedEventArgs e)
        {

        }

        private void Edit(object sender, RoutedEventArgs e)
        {

        }
    }
}
