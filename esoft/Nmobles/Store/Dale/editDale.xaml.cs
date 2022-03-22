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
    public partial class editDale : Page
    {

        private Demand entityEditDemandItem;

        public editDale(Demand editDemandItem)
        {
            InitializeComponent();
            ComboBoxType.ItemsSource = eSoftEntities.GetContext().TypeObjectNmobles.ToList();
            ComboBoxType.SelectedValue = editDemandItem.ObjectNmobles.TypeId;

            ComboBoxDemand.ItemsSource = eSoftEntities.GetContext().Demand.Where(i => (i.TypeObjectNmobles.TypeId == ComboBoxType.SelectedValue.ToString() && i.DeletedBy == null && i.DealNmobles == null || i.id == editDemandItem.id)).ToList();
            ComboBoxDemand.SelectedValue = editDemandItem.id;

            int IdselectedSuplies = eSoftEntities.GetContext().Supplies.Where(i => i.ObjectNmobles1.ObjectNmoblesId == editDemandItem.ObjectNmobles.ObjectNmoblesId).ToList()[0].id;
            ComboBoxSupply.ItemsSource = eSoftEntities.GetContext().Supplies.Where(i => (i.id == IdselectedSuplies || i.DeletedAt == null && i.ObjectNmobles1.IsBuy == null && i.ObjectNmobles1.TypeId == ComboBoxType.SelectedValue.ToString())).ToList();

            
            ComboBoxSupply.SelectedValue = IdselectedSuplies;



            entityEditDemandItem = editDemandItem;
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
        }

        private void ChangedComboBoxDemand(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxDemand.SelectedIndex == -1)
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
            try
            {
                
                Supplies editSupplies = eSoftEntities.GetContext().Supplies.Where(i => i.ObjectNmobles1.ObjectNmoblesId == entityEditDemandItem.ObjectNmobles.ObjectNmoblesId).ToList()[0] as Supplies;
                editSupplies.ObjectNmobles1.IsBuy = int.Parse(Application.Current.Resources["idUser"].ToString());

                Demand editDemand = ComboBoxDemand.SelectedItem as Demand;
                entityEditDemandItem.DealNmobles = editSupplies.ObjectNmobles1.ObjectNmoblesId;

                eSoftEntities.GetContext().SaveChanges();

                MessageBox.Show("Сделка проведена успешно");

                this.Content = null;
                this.NavigationService.Navigate(new DaleList());
            }
            catch
            {
                MessageBox.Show("Error 505\nПроизошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
            }

        }

        private void ChangedComboBoxSupply(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxSupply.SelectedIndex != -1)
            {
                int id = int.Parse(ComboBoxSupply.SelectedValue.ToString());
                DataGridSupplyList.ItemsSource = eSoftEntities.GetContext().Supplies.Where(i => i.id == id).ToList();
            }
        }
    }
}
