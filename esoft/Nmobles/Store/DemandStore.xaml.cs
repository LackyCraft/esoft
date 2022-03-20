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
    /// Логика взаимодействия для DemandStore.xaml
    /// </summary>
    public partial class DemandStore : Page
    {

        List<Demand> demandList;

        private string selectedTypeId;

        public DemandStore(string type)
        {
            InitializeComponent();
            selectedTypeId = type;
            DataGridDemand.ItemsSource = eSoftEntities.GetContext().Demand.Where(i => i.TypeObjectNmobles.TypeId == type).ToList();
            demandList = eSoftEntities.GetContext().Demand.Where(i => i.TypeObjectNmobles.TypeId == type).ToList();

        }

        private void DeletedAt(object sender, RoutedEventArgs e)
        {

        }

        private void Edit(object sender, RoutedEventArgs e)
        {

        }

        private void addSupplies(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DemandAddInStore(selectedTypeId));
        }

        private void ButtClickButtonSearchClick(object sender, RoutedEventArgs e)
        {
            List<Demand> filterList = demandList;
            if (TextBoxSearchBox.Text.ToString().Length > 1)
            {
                filterList = filterList.Where(i => ((i.MinPrice).ToString().Contains(TextBoxSearchBox.Text.ToString()) || (i.MaxPrice).ToString().Contains(TextBoxSearchBox.Text.ToString()) || i.City.CityName.Contains(TextBoxSearchBox.Text.ToString()) || i.AddressStreet.Contains(TextBoxSearchBox.Text.ToString()) || i.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || i.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || i.Client.LastName.Contains(TextBoxSearchBox.Text.ToString()) || i.Client.FirstName.Contains(TextBoxSearchBox.Text.ToString()))).ToList();
            }

            DataGridDemand.ItemsSource = filterList;
        }

    }
}
