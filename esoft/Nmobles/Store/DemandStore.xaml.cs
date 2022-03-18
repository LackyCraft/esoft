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

        List<Demand> landList;

        private string selectedTypeId;

        public DemandStore(string type)
        {
            InitializeComponent();
            selectedTypeId = type;
            DataGridDemand.ItemsSource = eSoftEntities.GetContext().Demand.Where(i => i.TypeObjectNmobles.TypeId == type).ToList();
            landList = eSoftEntities.GetContext().Demand.Where(i => i.TypeObjectNmobles.TypeId == type).ToList();

        }

        private void DeletedAt(object sender, RoutedEventArgs e)
        {

        }

        private void Edit(object sender, RoutedEventArgs e)
        {

        }

        private void addSupplies(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DemandAddInStore());
        }

        private void ButtClickButtonSearchClick(object sender, RoutedEventArgs e)
        {
            /*List<Supplies> filterList = landList;
            if (TextBoxSearchBox.Text.ToString().Length > 1)
            {
                filterList = filterList.Where(i => (i.ObjectNmobles1.Title.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles1.City.CityName.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles1.AddressStreet.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles1.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles1.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()))).ToList();
            }

            DataGridLandsStore.ItemsSource = filterList;*/
        }

    }
}
