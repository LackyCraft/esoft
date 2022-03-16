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
            ComboBoxCity.ItemsSource = eSoftEntities.GetContext().City;
            TextBoxTitle.Text = entityEditApartment.ObjectNmobles.Title.ToString();
            ComboBoxCity.Text = entityEditApartment.ObjectNmobles.City.CityName.ToString();
            TextBoxStreet.Text = entityEditApartment.ObjectNmobles.AddressStreet.ToString();
            TextBoxHouses.Text = entityEditApartment.ObjectNmobles.AddressHouse.ToString();
            TextBoxFloor.Text = entityEditApartment.Floor.ToString();
            TextBoxCountRooms.Text = entityEditApartment.CountRooms.ToString();
            TextBoxArea.Text = entityEditApartment.Area.ToString();
            TextBoxLat.Text = entityEditApartment.ObjectNmobles.Lat.ToString();
            TextBoxLng.Text = entityEditApartment.ObjectNmobles.Lng.ToString();
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                entityEditApartment.ObjectNmobles.Title = TextBoxTitle.Text;
                entityEditApartment.ObjectNmobles.idCity = int.Parse(ComboBoxCity.SelectedValue.ToString());
                entityEditApartment.ObjectNmobles.AddressStreet = TextBoxStreet.Text;
                entityEditApartment.ObjectNmobles.AddressHouse = TextBoxHouses.Text;
                entityEditApartment.Floor = int.Parse(TextBoxFloor.Text);
                entityEditApartment.CountRooms = int.Parse(TextBoxCountRooms.Text);
                entityEditApartment.Area = double.Parse(TextBoxArea.Text);
                entityEditApartment.ObjectNmobles.Lng = double.Parse(TextBoxLat.Text);
                entityEditApartment.ObjectNmobles.Lng = double.Parse(TextBoxLng.Text);

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
