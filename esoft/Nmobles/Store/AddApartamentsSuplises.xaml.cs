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

namespace esoft.Nmobles.Store
{
    /// <summary>
    /// Логика взаимодействия для AddApartamentsSuplises.xaml
    /// </summary>
    public partial class AddApartamentsSuplises : Page
    {
        public AddApartamentsSuplises(string type, int price, int idReaaltor, int idClient, float lat, float lng)
        {
            InitializeComponent();
        }
        private void сheckWarning(object sender, RoutedEventArgs e)
        {

        }
    }
}
