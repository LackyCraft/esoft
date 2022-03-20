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
            DataGridSupliesStore.ItemsSource = eSoftEntities.GetContext().Supplies.Where(i => (i.ObjectNmobles1.TypeId == type && i.DeletedAt == null && i.ObjectNmobles1.IsBuy == null)).ToList();
            landList = eSoftEntities.GetContext().Supplies.Where(i => (i.ObjectNmobles1.TypeId == type && i.DeletedAt == null && i.ObjectNmobles1.IsBuy == null)).ToList();
        }

        private void DeletedAt(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources["idUser"].ToString() == "null" && Application.Current.Resources["Role"].ToString() != "C")
            {
                MessageBox.Show("Warning 403\nНеобходимо автроизоваться под ролью Администратора или Риелтора");
            }
            else
            {
                (DataGridSupliesStore.SelectedItem as Supplies).DeletedAt = int.Parse(Application.Current.Resources["idUser"].ToString());
                eSoftEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись успешгл удалена");
                landList = eSoftEntities.GetContext().Supplies.Where(i => (i.ObjectNmobles1.TypeId == selectedTypeId && i.DeletedAt == null && i.ObjectNmobles1.IsBuy == null)).ToList();
                DataGridSupliesStore.ItemsSource = landList;
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {

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

            DataGridSupliesStore.ItemsSource = filterList;
        }
    }
}
