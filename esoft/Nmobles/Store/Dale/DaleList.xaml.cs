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

        List<Demand> demandList;

        public DaleList()
        {
            InitializeComponent();
            demandList = eSoftEntities.GetContext().Demand.Where(i => (i.DealNmobles != null && i.DeletedBy == null)).ToList();
            DataGridDaleList.ItemsSource = demandList;
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

        private void DeletedAt(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources["idUser"].ToString() == "null" && Application.Current.Resources["Role"].ToString() != "C")
            {
                MessageBox.Show("Warning 403\nНеобходимо автроизоваться под ролью Администратора или Риелтора");
            }
            else
            {
                if (MessageBox.Show("Вы точно хотите отменить данную сделку?",
                    "Save file",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Demand editDemand = (DataGridDaleList.SelectedItem as Demand);
                    editDemand.ObjectNmobles.IsBuy = null;
                    editDemand.DealNmobles = null;

                    eSoftEntities.GetContext().SaveChanges();
                    MessageBox.Show("Сделка была успешно удалена");

                    demandList = eSoftEntities.GetContext().Demand.Where(i => (i.DealNmobles != null && i.DeletedBy == null)).ToList();

                    DataGridDaleList.ItemsSource = demandList;
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources["idUser"].ToString() == "null" && Application.Current.Resources["Role"].ToString() != "C")
            {
                MessageBox.Show("Warning 403\nНеобходимо автроизоваться под ролью Администратора или Риелтора");
            }
            else
            {
                editDale editDemandPage = new editDale(DataGridDaleList.SelectedItem as Demand);
                this.NavigationService.Navigate(editDemandPage);
            }
        }


        private void ChangedTextBoxSearchBox(object sender, TextChangedEventArgs e)
        {
            List<Demand> filterList = new List<Demand>();
            if (TextBoxSearchBox.Text.Length > 1)
            {
                foreach (Demand demands in demandList)
                {
                    if ((demands.MinPrice).ToString().Contains(TextBoxSearchBox.Text.ToString()) || (demands.MaxPrice).ToString().Contains(TextBoxSearchBox.Text.ToString()) || demands.City.CityName.ToString().Contains(TextBoxSearchBox.Text.ToString()) || demands.Client.LastName.ToString().Contains(TextBoxSearchBox.Text.ToString()) || demands.Client.FirstName.ToString().Contains(TextBoxSearchBox.Text.ToString()))
                    {
                        filterList.Add(demands);
                    }
                }
            }
            else
            {
                filterList = demandList;
            }
            DataGridDaleList.ItemsSource = filterList;
        }


    }
}
