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
            DataGridDemand.ItemsSource = eSoftEntities.GetContext().Demand.Where(i => (i.TypeObjectNmobles.TypeId == type && i.DeletedBy == null && i.DealNmobles == null)).ToList();
            demandList = eSoftEntities.GetContext().Demand.Where(i => (i.TypeObjectNmobles.TypeId == type && i.DeletedBy == null && i.DealNmobles == null)).ToList();

        }

        private void DeletedAt(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources["idUser"].ToString() == "null" && Application.Current.Resources["Role"].ToString() != "C")
            {
                MessageBox.Show("Warning 403\nНеобходимо автроизоваться под ролью Администратора или Риелтора");
            }
            else
            {
                if (MessageBox.Show("Вы точно хотите удалить данную запись?",
                    "Save file",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Demand editDemand = (DataGridDemand.SelectedItem as Demand);
                    editDemand.DeletedBy = int.Parse(Application.Current.Resources["idUser"].ToString());
                    eSoftEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись успешно удалена");

                    demandList = eSoftEntities.GetContext().Demand.Where(i => (i.TypeObjectNmobles.TypeId == selectedTypeId && i.DeletedBy == null && i.DealNmobles == null)).ToList();

                    DataGridDemand.ItemsSource = demandList;
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {

        }

        private void addSupplies(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DemandAddInStore(selectedTypeId));
        }

        private void ChangedTextBoxSearchBox(object sender, TextChangedEventArgs e)
        {
            List<Demand> filterList = new List<Demand>();//new List<ListUsers>();
            if (TextBoxSearchBox.Text.Length > 1)
            {
                foreach (Demand demands in demandList)
                {
                    if ((demands.MinPrice).ToString().Contains(TextBoxSearchBox.Text.ToString()) || (demands.MaxPrice).ToString().Contains(TextBoxSearchBox.Text.ToString()) || demands.City.CityName.ToString().Contains(TextBoxSearchBox.Text.ToString()) || demands.AddressStreet.ToString().Contains(TextBoxSearchBox.Text.ToString()) || demands.Client.LastName.ToString().Contains(TextBoxSearchBox.Text.ToString()) || demands.Client.FirstName.ToString().Contains(TextBoxSearchBox.Text.ToString()))
                    {
                        filterList.Add(demands);
                    }
                }
            }
            else
            {
                filterList = demandList;
            }
            DataGridDemand.ItemsSource = filterList;
        }

    }
}
