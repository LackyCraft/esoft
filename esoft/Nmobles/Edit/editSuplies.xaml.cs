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
    /// Логика взаимодействия для editSuplies.xaml
    /// </summary>
    public partial class editSuplies : Page
    {

        private Supplies EditSuppliesItem;

        public editSuplies(Supplies editSupplies)
        {
            InitializeComponent();

            EditSuppliesItem = editSupplies;

            try
            {
                ComboBoxTypeNmobles.ItemsSource = eSoftEntities.GetContext().TypeObjectNmobles.ToList();
                ComboBoxClient.ItemsSource = eSoftEntities.GetContext().Client.ToList();
                ComboBoxRealtor.ItemsSource = eSoftEntities.GetContext().Realtor.ToList();

                TextBoxTitle.Text = editSupplies.ObjectNmobles1.Title;
                ComboBoxTypeNmobles.SelectedValue = editSupplies.ObjectNmobles1.TypeId;
                TextBoxPrice.Text = editSupplies.Price.ToString();
                ComboBoxClient.SelectedValue = editSupplies.ClientId;
                ComboBoxRealtor.SelectedValue = editSupplies.RialtorId;
                TextBoxLat.Text = editSupplies.ObjectNmobles1.Lat.ToString();
                TextBoxLng.Text = editSupplies.ObjectNmobles1.Lng.ToString();
            }
            catch
            {
                MessageBox.Show("Error 505\nПроизошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
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
            if (TextBoxTitle.Text.Length < 1)
            {
                TextBlockWarning.Text = "Заполните наименование";
            }
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
            if (TextBlockWarning.Text == "")
            {
                try
                { 
                EditSuppliesItem.ObjectNmobles1.Title = TextBoxTitle.Text;
                EditSuppliesItem.ObjectNmobles1.Lng = lng;
                EditSuppliesItem.ObjectNmobles1.Lat = lat;
                EditSuppliesItem.ObjectNmobles1.TypeId = ComboBoxTypeNmobles.SelectedValue.ToString();
                EditSuppliesItem.ObjectNmobles1.DeletedBy = null;

                eSoftEntities.GetContext().SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Error 505\nПроизошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
                }

                MainInfoSupplies.Children.Remove(ButtonAddSupline);
                MainInfoSupplies.IsEnabled = false;
                ButtonBackgroundMainInfoSuppline.Background = (Brush)Application.Current.FindResource("DarkGrey1");

                //Запишем id конкретной недвижимости в переменную
                int id = EditSuppliesItem.ObjectNmobles1.ObjectNmoblesId;

                //Открываем страницу для редактирования основных параметров потебности


                if (EditSuppliesItem.ObjectNmobles1.TypeId == "A")
                {
                    //Ищем квартиру с записанным id и открываем страницу для редактирование квартир
                    Apartmens editAprtaments = eSoftEntities.GetContext().Apartmens.Where(i => i.ObjectNmoblesId == id).ToList()[0] as Apartmens;
                    esoft.Nmobles.Edit.EditApartamentWindows editApertaments = new esoft.Nmobles.Edit.EditApartamentWindows(editAprtaments);
                    editApertaments.Show();
                }
                if (EditSuppliesItem.ObjectNmobles1.TypeId == "H")
                {
                    //Ищем квартиру с записанным id и открываем страницу для редактирование домов
                    Houses editHouses = eSoftEntities.GetContext().Houses.Where(i => i.ObjectNmoblesId == id).ToList()[0] as Houses;
                    esoft.Nmobles.Edit.EditHousesWindow editHousesWindows = new esoft.Nmobles.Edit.EditHousesWindow(editHouses);
                    editHousesWindows.Show();
                }
                if (EditSuppliesItem.ObjectNmobles1.TypeId == "L")
                {
                    //Ищем квартиру с записанным id и открываем страницу для редактирование земель
                    Land editLand = eSoftEntities.GetContext().Land.Where(i => i.ObjectNmoblesId == id).ToList()[0] as Land;
                    esoft.Nmobles.Edit.editLandWindows editLandWindows = new esoft.Nmobles.Edit.editLandWindows(editLand);
                    editLandWindows.Show();
                }
            }
        }

    }
}
