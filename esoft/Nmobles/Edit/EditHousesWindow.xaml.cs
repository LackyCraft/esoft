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
    /// Логика взаимодействия для EditHousesWindow.xaml
    /// </summary>
    public partial class EditHousesWindow : Window
    {
        Houses entityEditHous;
        public EditHousesWindow(Houses editHpuses)
        {
            
            InitializeComponent();
            entityEditHous = editHpuses;

            ComboBoxCity.ItemsSource = eSoftEntities.GetContext().City.ToList();
            TextBoxTitle.Text = entityEditHous.ObjectNmobles.Title.ToString();

            ComboBoxCity.Text = entityEditHous.ObjectNmobles.City.CityName.ToString();
            TextBoxStreet.Text = entityEditHous.ObjectNmobles.AddressStreet.ToString();
            TextBoxHouses.Text = entityEditHous.ObjectNmobles.AddressHouse.ToString();
            TextBoxLat.Text = entityEditHous.ObjectNmobles.Lat.ToString();
            TextBoxLng.Text = entityEditHous.ObjectNmobles.Lng.ToString();

            TextBoxCountFloor.Text = entityEditHous.CountFloor.ToString();
            TextBoxCountRooms.Text = entityEditHous.CountRoom.ToString();
            TextBoxArea.Text = entityEditHous.Area.ToString();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                entityEditHous.ObjectNmobles.Title = TextBoxTitle.Text;
                entityEditHous.ObjectNmobles.idCity = int.Parse(ComboBoxCity.SelectedValue.ToString());
                entityEditHous.ObjectNmobles.AddressStreet = TextBoxStreet.Text;
                entityEditHous.ObjectNmobles.AddressHouse = TextBoxHouses.Text;
                //entityEditHous.CountRoom = int.Parse(TextBoxCountRooms.Text);
                //entityEditHous.CountFloor = int.Parse(TextBoxCountFloor.Text);
                double lat = 0, lng = 0;
                if (double.TryParse(TextBoxLat.Text, out lat) && double.TryParse(TextBoxLng.Text, out lng))
                {
                    entityEditHous.ObjectNmobles.Lat = lat;
                    entityEditHous.ObjectNmobles.Lng = lng;
                }
                else
                {
                    entityEditHous.ObjectNmobles.Lat = null;
                    entityEditHous.ObjectNmobles.Lng = null;
                }
                double area;
                if (double.TryParse(TextBoxArea.Text, out area))
                {
                    entityEditHous.Area = area;
                }
                int countRoom;
                if (int.TryParse(TextBoxCountRooms.Text, out countRoom))
                {
                    entityEditHous.CountRoom = countRoom;
                }
                int countFloor;
                if (int.TryParse(TextBoxCountFloor.Text, out countFloor))
                {
                    entityEditHous.CountFloor = countFloor;
                }

                eSoftEntities.GetContext().SaveChanges();
                MessageBox.Show("Сохранение прошло успешно");
            }
            catch
            {
                MessageBox.Show("Произошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
            }
        }

    }
}
