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

namespace esoft.Nmobles.Edit
{
    /// <summary>
    /// Логика взаимодействия для editItemDemandNmobles.xaml
    /// </summary>
    public partial class editItemDemandNmobles : Page
    {

        Demand editDemanteSoftEntity;

        public editItemDemandNmobles()
        {

            InitializeComponent();
            Demand editDemandItem = new Demand();
            editDemanteSoftEntity = editDemandItem;
            try
            {
                ComboBoxTypeNmobles.ItemsSource = eSoftEntities.GetContext().TypeObjectNmobles.ToList();
                ComboBoxTypeNmobles.SelectedValue = editDemandItem.TypeObjectNmobles.TypeId;
                TextBoxPriceMin.Text = editDemandItem.MinPrice.ToString();
                TextBoxPriceMax.Text = editDemandItem.MaxPrice.ToString();
                ComboBoxClient.ItemsSource = eSoftEntities.GetContext().Client.ToList();
                ComboBoxRealtor.ItemsSource = eSoftEntities.GetContext().Realtor.ToList();

                ComboBoxClient.SelectedValue = editDemandItem.ClientId;
                ComboBoxRealtor.SelectedValue = editDemandItem.RealtorId;

                editDemanteSoftEntity = editDemandItem;
            }
            catch
            {
                MessageBox.Show("Error 505\nПроизошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
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
                try
                {
                    MainInfoSupplies.Children.Remove(ButtonAddSupline);
                    MainInfoSupplies.IsEnabled = false;
                    ButtonBackgroundMainInfoSuppline.Background = (Brush)Application.Current.FindResource("DarkGrey1");

                    editDemanteSoftEntity.MinPrice = int.Parse(TextBoxPriceMin.Text);
                    editDemanteSoftEntity.MaxPrice = int.Parse(TextBoxPriceMax.Text);
                    editDemanteSoftEntity.RealtorId = int.Parse(ComboBoxRealtor.SelectedValue.ToString());
                    editDemanteSoftEntity.ClientId = int.Parse(ComboBoxClient.SelectedValue.ToString());
                    editDemanteSoftEntity.TypeDemand = ComboBoxTypeNmobles.SelectedValue.ToString();


                    eSoftEntities.GetContext().SaveChanges();

                    MessageBox.Show("Сохранение прошло успешно");
                }
                catch
                {
                    MessageBox.Show("Error 505\nПроизошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
                }
            }
        }
    }
}

