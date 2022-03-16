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
using System.Windows.Shapes;

namespace esoft.Nmobles.Edit
{
    /// <summary>
    /// Логика взаимодействия для editLandWindows.xaml
    /// </summary>
    public partial class editLandWindows : Window
    {

        private Land entityEditLand;

        public editLandWindows(Land editLans)
        {
            entityEditLand = editLans;
            InitializeComponent();

            ComboBoxCity.ItemsSource = eSoftEntities.GetContext().City.ToList();

            TextBoxTitle.Text = entityEditLand.ObjectNmobles.Title.ToString();
            ComboBoxCity.Text = entityEditLand.ObjectNmobles.City.CityName.ToString();
            TextBoxStreet.Text = entityEditLand.ObjectNmobles.AddressStreet.ToString();
            TextBoxHouses.Text = entityEditLand.ObjectNmobles.AddressHouse.ToString();
            TextBoxLat.Text = entityEditLand.ObjectNmobles.Lat.ToString();
            TextBoxLng.Text = entityEditLand.ObjectNmobles.Lng.ToString();
            TextBoxArea.Text = entityEditLand.Area.ToString();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
            entityEditLand.ObjectNmobles.Title = TextBoxTitle.Text;
            entityEditLand.ObjectNmobles.idCity = int.Parse(ComboBoxCity.SelectedValue.ToString());
            entityEditLand.ObjectNmobles.AddressStreet = TextBoxStreet.Text;
            entityEditLand.ObjectNmobles.AddressHouse = TextBoxHouses.Text;
            double lat = 0, lng = 0;
            if (double.TryParse(TextBoxLat.Text, out lat) && double.TryParse(TextBoxLng.Text, out lng))
            {
                entityEditLand.ObjectNmobles.Lat = lat;
                entityEditLand.ObjectNmobles.Lng = lng;
                }
                else
                {
                    entityEditLand.ObjectNmobles.Lat = null;
                    entityEditLand.ObjectNmobles.Lng = null;
                }
                double area;
            if (double.TryParse(TextBoxArea.Text, out area))
            {
                entityEditLand.Area = area;
            }

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
