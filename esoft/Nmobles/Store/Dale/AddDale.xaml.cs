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
    /// Логика взаимодействия для AddDale.xaml
    /// </summary>
    public partial class AddDale : Page
    {
        public AddDale()
        {
            InitializeComponent();
            ComboBoxType.ItemsSource = eSoftEntities.GetContext().TypeObjectNmobles.ToList();
            
        }

        private void ClickButtonSearch(object sender, RoutedEventArgs e)
        {
            ComboBoxSupply.IsEnabled = true;
            ComboBoxSupply.ItemsSource = eSoftEntities.GetContext().Supplies.Where(i => (i.DeletedAt == null && i.ObjectNmobles1.IsBuy == null && i.ObjectNmobles1.TypeId == ComboBoxType.SelectedValue.ToString())).ToList();
        }

        private void ChangedComboBoxType(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxType.SelectedIndex == -1)
            {
                ComboBoxDemand.IsEnabled = false;
            }
            else
            {
                ComboBoxDemand.IsEnabled = true;
                ComboBoxDemand.ItemsSource = eSoftEntities.GetContext().Demand.Where(i => (i.TypeObjectNmobles.TypeId == ComboBoxType.SelectedValue.ToString() && i.DeletedBy == null && i.DealNmobles == null)).ToList();
                ButtonSearch.IsEnabled = true;
                ButtonSearch.Background = (Brush)Application.Current.MainWindow.FindResource("Blue");
            }
            //Supplies supplies1 = new Supplies();

            //ComboBoxSupplice.ItemsSource = eSoftEntities.GetContext().Supplies.Where(i => (i.ObjectNmobles1.IsBuy == null && i.ObjectNmobles1.TypeId == ComboBoxType.SelectedValue.ToString())).ToList();
        }
        private void ChangedComboBoxDemand(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxDemand.SelectedIndex == -1)
            {
                DataGridDemandList.ItemsSource = null;
                ComboBoxSupply.IsEnabled = false;
            }
            else
            {
                ButtonAddDeal.IsEnabled = true;
                int id = int.Parse(ComboBoxDemand.SelectedValue.ToString());
                DataGridDemandList.ItemsSource = eSoftEntities.GetContext().Demand.Where(i => i.id == id).ToList();
            }
        }

        private void ButtonAddDeal_Click(object sender, RoutedEventArgs e)
        {
            Supplies editSupplies = ComboBoxSupply.SelectedItem as Supplies;
            editSupplies.ObjectNmobles1.IsBuy = int.Parse(Application.Current.Resources["idUser"].ToString());

            Demand editDemand = ComboBoxDemand.SelectedItem as Demand;
            editDemand.DealNmobles = editSupplies.ObjectNmobles1.ObjectNmoblesId;

            eSoftEntities.GetContext().SaveChanges();

            MessageBox.Show("Сделка проведена успешно");

        }

        private void ChangedComboBoxSupply(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBoxSupply.SelectedIndex != -1)
            {
            int id = int.Parse(ComboBoxSupply.SelectedValue.ToString());
            DataGridSupplyList.ItemsSource = eSoftEntities.GetContext().Supplies.Where(i => i.id == id).ToList();
            }
        }
    }
}
