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
    /// Логика взаимодействия для DemandAddInStore.xaml
    /// </summary>
    public partial class DemandAddInStore : Page
    {
        public DemandAddInStore(string selectedTypeId)
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
            if (!int.TryParse((sender as TextBox).Text, out price) || price < 0)
            {
                MessageBox.Show("Максимальная и минимальная ценеа доллжны быть целым положительным числом");
                (sender as TextBox).Text = "1";
            }
        }

        private void сheckWarning(object sender, RoutedEventArgs e)
        {
            TextBlockWarning.Text = "";
            TextBoxPriceMax.Background = Brushes.White;
            TextBoxPriceMin.Background = Brushes.White;
            if (ComboBoxRealtor.SelectedItem is null)
            {
                TextBlockWarning.Text += "\nНе выбран ответственный риэлтор";
            }
            if (int.Parse(TextBoxPriceMax.Text) > int.Parse(TextBoxPriceMin.Text))
            {
                TextBlockWarning.Text += "\nМасимальная цена должна быть больше минимальной";
                TextBoxPriceMax.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
                TextBoxPriceMin.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
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
                if(ComboBoxTypeNmobles.SelectedValue.ToString() == "H")
                    FrameTypeInfo.Content = new AddDemandHouses(ComboBoxTypeNmobles.SelectedValue.ToString(), int.Parse(TextBoxPriceMin.Text), int.Parse(TextBoxPriceMax.Text), int.Parse(ComboBoxRealtor.SelectedValue.ToString()), int.Parse(ComboBoxClient.SelectedValue.ToString()));
                if (ComboBoxTypeNmobles.SelectedValue.ToString() == "A")
                    FrameTypeInfo.Content = new AddDemandApartamnts(ComboBoxTypeNmobles.SelectedValue.ToString(), int.Parse(TextBoxPriceMin.Text), int.Parse(TextBoxPriceMax.Text), int.Parse(ComboBoxRealtor.SelectedValue.ToString()), int.Parse(ComboBoxClient.SelectedValue.ToString()));
                if (ComboBoxTypeNmobles.SelectedValue.ToString() == "L")
                    FrameTypeInfo.Content = new AddDemandLand(ComboBoxTypeNmobles.SelectedValue.ToString(), int.Parse(TextBoxPriceMin.Text), int.Parse(TextBoxPriceMax.Text), int.Parse(ComboBoxRealtor.SelectedValue.ToString()), int.Parse(ComboBoxClient.SelectedValue.ToString()));

            }
        }


    }
}
