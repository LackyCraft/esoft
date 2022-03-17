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
    /// Логика взаимодействия для AddSupplies.xaml
    /// </summary>
    public partial class AddSupplies : Page
    {
        public AddSupplies(string selectedTypeId)
        {
            InitializeComponent();
            ComboBoxClient.ItemsSource = eSoftEntities.GetContext().Client.ToList();
            ComboBoxRealtor.ItemsSource = eSoftEntities.GetContext().Realtor.ToList();
            ComboBoxTypeNmobles.ItemsSource = eSoftEntities.GetContext().TypeObjectNmobles.ToList();
            ComboBoxTypeNmobles.SelectedValue = selectedTypeId;

            if(Application.Current.Resources["Role"].ToString() == "R")
            {
                int idAuthUSer = int.Parse(Application.Current.Resources["idUser"].ToString());
                ComboBoxRealtor.SelectedValue = eSoftEntities.GetContext().Realtor.Where(i => i.idUser == idAuthUSer).ToList()[0].id;
            }else if(Application.Current.Resources["Role"].ToString() == "C")
            {
                int idAuthUSer = int.Parse(Application.Current.Resources["idUser"].ToString());
                ComboBoxClient.SelectedValue = eSoftEntities.GetContext().Client.Where(i => i.UserId == idAuthUSer).ToList()[0].Id;
            }
        }

        private void changedCheck(object sender, TextChangedEventArgs e)
        {
            int price;
            if (!int.TryParse(TextBoxPrice.Text, out price) && sender == TextBoxPrice)
            {
                MessageBox.Show("Warning 422\nЦена должна быть целым положительным числом!");
                TextBoxPrice.Text = "0";
            }
        }

        private void сheckWarning(object sender, RoutedEventArgs e)
        {
            TextBlockWarning.Text = "";
            float lat = 0, lng = 0;
            if (!float.TryParse(TextBoxLat.Text, out lat) || !float.TryParse(TextBoxLng.Text, out lng))
            {
                TextBlockWarning.Text += "\nКоординаты должны быть числом вещественного типа";
                TextBoxLat.Text = "0";
                TextBoxLng.Text = "0";
            }
            if (ComboBoxRealtor.SelectedItem is null)
            {
                TextBlockWarning.Text += "\nНе выбран ответственный риэлтор";
            }
            if (ComboBoxClient.SelectedItem is null)
            {
                TextBlockWarning.Text += "\nНе выбран клиент";
            }
            if(TextBlockWarning.Text == "")
            {
                MainInfoSupplies.Children.Remove(ButtonAddSupline);
                MainInfoSupplies.IsEnabled = false;
                ButtonBackgroundMainInfoSuppline.Background = (Brush)Application.Current.FindResource("DarkGrey1");

                if(ComboBoxTypeNmobles.SelectedValue.ToString() == "A")
                    FrameTypeInfo.Content = new AddApartamentsSuplises(ComboBoxTypeNmobles.SelectedValuePath, int.Parse(TextBoxPrice.Text), int.Parse(ComboBoxRealtor.SelectedValue.ToString()), int.Parse(ComboBoxClient.SelectedValue.ToString()), float.Parse(TextBoxLat.Text), float.Parse(TextBoxLng.Text));

            }
        }

        private void TextBoxLat_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
