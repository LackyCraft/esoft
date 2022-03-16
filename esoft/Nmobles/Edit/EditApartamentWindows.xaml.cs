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
    /// Логика взаимодействия для EditApartamentWindows.xaml
    /// </summary>
    public partial class EditApartamentWindows : Window
    {

        private Apartmens entityEditApartment;

        public EditApartamentWindows(Apartmens editApartmens)
        {
            InitializeComponent();
            entityEditApartment = editApartmens;
            ComboBoxCity.ItemsSource = eSoftEntities.GetContext().City.ToList();
            TextBoxAddressNumber.Text = entityEditApartment.ObjectNmobles.AddressNumber.ToString(); 
            TextBoxTitle.Text = entityEditApartment.ObjectNmobles.Title.ToString();
            ComboBoxCity.Text = entityEditApartment.ObjectNmobles.City.CityName.ToString();
            TextBoxStreet.Text = entityEditApartment.ObjectNmobles.AddressStreet.ToString();
            TextBoxHouses.Text = entityEditApartment.ObjectNmobles.AddressHouse.ToString();
            TextBoxLat.Text = entityEditApartment.ObjectNmobles.Lat.ToString();
            TextBoxLng.Text = entityEditApartment.ObjectNmobles.Lng.ToString();

            TextBoxFloor.Text = entityEditApartment.Floor.ToString();
            TextBoxCountRooms.Text = entityEditApartment.CountRooms.ToString();
            TextBoxArea.Text = entityEditApartment.Area.ToString();

        }
        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                entityEditApartment.ObjectNmobles.Title = TextBoxTitle.Text;
                entityEditApartment.ObjectNmobles.idCity = int.Parse(ComboBoxCity.SelectedValue.ToString());
                entityEditApartment.ObjectNmobles.AddressStreet = TextBoxStreet.Text;
                entityEditApartment.ObjectNmobles.AddressHouse = TextBoxHouses.Text;
                //entityEditApartment.Floor = int.Parse(TextBoxFloor.Text);
                //entityEditApartment.CountRooms = int.Parse(TextBoxCountRooms.Text);
                double lat = 0, lng = 0;
                if (double.TryParse(TextBoxLat.Text, out lat) && double.TryParse(TextBoxLng.Text, out lng))
                {
                    entityEditApartment.ObjectNmobles.Lat = lat;
                    entityEditApartment.ObjectNmobles.Lng = lng;
                }
                else
                {
                    entityEditApartment.ObjectNmobles.Lat = null;
                    entityEditApartment.ObjectNmobles.Lng = null;
                }
                double area;
                if (double.TryParse(TextBoxArea.Text, out area))
                {
                    entityEditApartment.Area = area;
                }
                int countRooms;
                if (int.TryParse(TextBoxCountRooms.Text, out countRooms))
                {
                    entityEditApartment.CountRooms = countRooms;
                }
                int floor;
                if (int.TryParse(TextBoxFloor.Text, out floor))
                {
                    entityEditApartment.Floor = floor;
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
