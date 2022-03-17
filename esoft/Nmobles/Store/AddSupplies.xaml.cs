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
            TextBoxTitle.Background = Brushes.White;
            if (TextBoxTitle.Text.Length < 1)
            {
                TextBlockWarning.Text = "Наименование должно быть заполнено";
                TextBoxTitle.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (ComboBoxRealtor.SelectedItem is null)
            {
                TextBlockWarning.Text += "\nНе выбран ответственный риэлтор";
            }
            if (ComboBoxClient.SelectedItem is null)
            {
                TextBlockWarning.Text += "\nНе выбран клиент";
            }
        }
    }
}
