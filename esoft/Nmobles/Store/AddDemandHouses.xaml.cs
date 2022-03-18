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
    /// Логика взаимодействия для AddDemandHouses.xaml
    /// </summary>
    public partial class AddDemandHouses : Page
    {
        public AddDemandHouses(string type, int priceMin, int priceMax, int idRealtor, int idClient)
        {
            InitializeComponent();
        }
    }
}
