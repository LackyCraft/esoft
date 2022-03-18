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
    /// Логика взаимодействия для AddDemandInStore.xaml
    /// </summary>
    public partial class AddDemandInStore : Page
    {
        public AddDemandInStore(string selectedTypeId)
        {
            InitializeComponent();
            ComboBoxClient.ItemsSource = eSoftEntities.GetContext().Client.ToList();
            ComboBoxRealtor.ItemsSource = eSoftEntities.GetContext().Realtor.ToList();
            ComboBoxTypeNmobles.ItemsSource = eSoftEntities.GetContext().TypeObjectNmobles.ToList();
            ComboBoxTypeNmobles.SelectedValue = selectedTypeId;

            if (Application.Current.Resources["Role"].ToString() == "R")
            {
                int idAuthUSer = int.Parse(Application.Current.Resources["idUser"].ToString());
                ComboBoxRealtor.SelectedValue = eSoftEntities.GetContext().Realtor.Where(i => i.idUser == idAuthUSer).ToList()[0].id;
            }
            else if (Application.Current.Resources["Role"].ToString() == "C")
            {
                int idAuthUSer = int.Parse(Application.Current.Resources["idUser"].ToString());
                ComboBoxClient.SelectedValue = eSoftEntities.GetContext().Client.Where(i => i.UserId == idAuthUSer).ToList()[0].Id;
            }
        }

        private void changedCheck(object sender, TextChangedEventArgs e)
        {
            int price;
            if (!int.TryParse(TextBoxPriceMin.Text, out price) && sender == TextBoxPriceMin && price > 0)
            {
                MessageBox.Show("Warning 422\nМинимальная цена должна быть целым положительным числом!");
                TextBoxPriceMin.Text = "0";
            }
            if (!int.TryParse(TextBoxPriceMax.Text, out price) && sender == TextBoxPriceMax && price > 0)
            {
                MessageBox.Show("Warning 422\nМаксимальная цена должна быть целым положительным числом!");
                TextBoxPriceMax.Text = "0";
            }
        }

        private void сheckWarning(object sender, RoutedEventArgs e)
        {
            TextBlockWarning.Text = "";

            if (ComboBoxRealtor.SelectedItem is null)
            {
                TextBlockWarning.Text += "\nНе выбран ответственный риэлтор";
            }
            if (ComboBoxClient.SelectedItem is null)
            {
                TextBlockWarning.Text += "\nНе выбран клиент";
            }
            if (TextBlockWarning.Text == "")
            {
                MainInfoSupplies.Children.Remove(ButtonAddSupline);
                MainInfoSupplies.IsEnabled = false;
                ButtonBackgroundMainInfoSuppline.Background = (Brush)Application.Current.FindResource("DarkGrey1");

                FrameTypeInfo.Content = new AddDemandHouses(ComboBoxTypeNmobles.SelectedValue.ToString(), int.Parse(TextBoxPriceMin.Text), int.Parse(TextBoxPriceMax.Text), int.Parse(ComboBoxRealtor.SelectedValue.ToString()), int.Parse(ComboBoxClient.SelectedValue.ToString()));

            
            }

        }
    }
}
