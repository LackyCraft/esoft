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
    public partial class SuppliesStore : Page
    {
        List<Supplies> landList;

        private string selectedTypeId;

        public SuppliesStore(string type)
        {
            InitializeComponent();
            selectedTypeId = type;
            DataGridLandsStore.ItemsSource = eSoftEntities.GetContext().Supplies.Where(i => i.ObjectNmobles1.TypeId == type).ToList();
            landList = eSoftEntities.GetContext().Supplies.Where(i => i.ObjectNmobles1.TypeId == type).ToList();
        }

        private void DeletedAt(object sender, RoutedEventArgs e)
        {

        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            /*
            if (Application.Current.Resources["idUser"].ToString() == "null" && Application.Current.Resources["Role"].ToString() != "C")
            {
                MessageBox.Show("Warning 403\nНеобходимо автроизоваться под ролью Администратора или Риелтора");
            }
            else
            {
                Nmobles.Edit.editLandWindows editApartament = new Nmobles.Edit.editLandWindows(DataGridLandsStore.SelectedItem as Land);
                editApartament.Show();
            } */
        }

        private void addSupplies(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddSupplies(selectedTypeId));
        }

        private void ButtClickButtonSearchClick(object sender, RoutedEventArgs e)
        {
            List<Supplies> filterList = landList;
            if (TextBoxSearchBox.Text.ToString().Length > 1)
            {
                filterList = filterList.Where(i => (i.ObjectNmobles1.Title.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles1.City.CityName.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles1.AddressStreet.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles1.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles1.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) )).ToList();
            }

            DataGridLandsStore.ItemsSource = filterList;
        }
    }
}
