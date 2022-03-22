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

        public editItemDemandNmobles(Demand editDemandItems)
        {
            InitializeComponent();
            editDemanteSoftEntity = editDemandItems;

            try
            {
            ComboBoxTypeNmobles.ItemsSource = eSoftEntities.GetContext().TypeObjectNmobles.ToList();
            ComboBoxTypeNmobles.SelectedValue = editDemandItems.TypeObjectNmobles.TypeId;
            TextBoxPriceMin.Text = editDemandItems.MinPrice.ToString();
            TextBoxPriceMax.Text = editDemandItems.MaxPrice.ToString();
            ComboBoxClient.ItemsSource = eSoftEntities.GetContext().Client.ToList();
            ComboBoxRealtor.ItemsSource = eSoftEntities.GetContext().Realtor.ToList();

            ComboBoxClient.SelectedValue = editDemandItems.ClientId;
            ComboBoxRealtor.SelectedValue = editDemandItems.RealtorId;
            }
            catch
            {
                MessageBox.Show("Error 505\nПроизошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
            }
            editDemanteSoftEntity = editDemandItems;

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
            if (int.Parse(TextBoxPriceMax.Text) < int.Parse(TextBoxPriceMin.Text))
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
                try
                {
                MainInfoSupplies.Children.Remove(ButtonAddSupline);
                MainInfoSupplies.IsEnabled = false;
                ButtonBackgroundMainInfoSuppline.Background = (Brush)Application.Current.FindResource("DarkGrey1");


                editDemanteSoftEntity.MinPrice = int.Parse(TextBoxPriceMin.Text);
                editDemanteSoftEntity.MaxPrice = int.Parse(TextBoxPriceMax.Text);
                editDemanteSoftEntity.RealtorId = int.Parse(ComboBoxRealtor.SelectedValue.ToString());
                editDemanteSoftEntity.ClientId = int.Parse(ComboBoxClient.SelectedValue.ToString());

                eSoftEntities.GetContext().SaveChanges();

                MessageBox.Show("Сохранение успешно сохранены");
                }
                catch
                {
                    MessageBox.Show("Error 505\nПроизошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
                }


            }
        }


    }
}

