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
    /// Логика взаимодействия для AddSuplisesHouses.xaml
    /// </summary>
    public partial class AddSuplisesHouses : Page
    {

        private string TitleSuplises;
        private string TypeNmoblesSuplises;
        private int PriceSuplises;
        private int idReaaltorSuplises;
        private int idClientSuplises;
        private float latSuplises;
        private float lngSuplises;

        public AddSuplisesHouses(string title, string type, int price, int idReaaltor, int idClient, float lat, float lng)
        {
            InitializeComponent();
            ComboBoxCity.ItemsSource = eSoftEntities.GetContext().City.ToList();
            TitleSuplises = title;
            TypeNmoblesSuplises = type;
            PriceSuplises = price;
            idReaaltorSuplises = idReaaltor;
            idClientSuplises = idClient;
            latSuplises = lat;
            lngSuplises = lng;
        }

        private void сheckWarning(object sender, RoutedEventArgs e)
        {
            TextBlockWarning.Text = "";
            if (ComboBoxCity.SelectedIndex == -1)
            {
                ComboBoxCity.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
                TextBlockWarning.Text = "Выберите город";
            }
            if (TextBoxArea.Text.Length < 1)
            {
                TextBoxArea.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
                TextBlockWarning.Text += "\nВведите площадь";
            }
            if (TextBlockWarning.Text == "")
            {
                try
                {
                    ObjectNmobles newobjectNmobles = new ObjectNmobles();
                    newobjectNmobles.Title = TitleSuplises;
                    newobjectNmobles.Lng = lngSuplises;
                    newobjectNmobles.Lat = latSuplises;
                    newobjectNmobles.TypeId = TypeNmoblesSuplises;
                    newobjectNmobles.AddressStreet = TextBoxStreet.Text;
                    newobjectNmobles.AddressHouse = TextBoxHouses.Text;
                    newobjectNmobles.AddressNumber = null;
                    newobjectNmobles.idCity = int.Parse(ComboBoxCity.SelectedValue.ToString());
                    newobjectNmobles.DeletedBy = null;

                    eSoftEntities.GetContext().ObjectNmobles.Add(newobjectNmobles);


                    Supplies newobjectsuplises = new Supplies();
                    newobjectsuplises.Price = int.Parse(PriceSuplises.ToString());
                    newobjectsuplises.RialtorId = idReaaltorSuplises;
                    newobjectsuplises.ClientId = idClientSuplises;
                    newobjectsuplises.ObjectNmobles = newobjectNmobles.ObjectNmoblesId;

                    eSoftEntities.GetContext().Supplies.Add(newobjectsuplises);

                    Houses newHouses = new Houses();
                    newHouses.ObjectNmoblesId = newobjectsuplises.id;
                    newHouses.CountFloor = int.Parse(TextBoxFloor.Text);
                    newHouses.CountRoom = int.Parse(TextBoxCountRooms.Text);
                    newHouses.Area = int.Parse(TextBoxArea.Text);

                    eSoftEntities.GetContext().Houses.Add(newHouses);

                    eSoftEntities.GetContext().SaveChanges();


                    MessageBox.Show("Сохранение прошло успешно");
                    this.Content = null;
                    SuppliesStore newEdit = new SuppliesStore(TypeNmoblesSuplises);
                }
                catch
                {
                    MessageBox.Show("Error 505\nПроизошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
                }


            }
        }

        private void TextChangedTextBoxFloor(object sender, TextChangedEventArgs e)
        {
            int countRooms = 0;
            if (!int.TryParse(TextBoxCountRooms.Text, out countRooms) || countRooms < 0)
            {
                MessageBox.Show("Количество этажей должно быть целым положительным числом");
                TextBoxFloor.Text = "1";
            }
        }
        private void TextChangedTextBoxCountRooms(object sender, TextChangedEventArgs e)
        {
            int countRooms = 0;
            if (!int.TryParse(TextBoxCountRooms.Text, out countRooms) || countRooms < 0)
            {
                MessageBox.Show("Количество комнат должно быть целым положительным числом");
                TextBoxCountRooms.Text = "1";
            }
        }

        private void TextChangedTextBoxArea(object sender, TextChangedEventArgs e)
        {
            float area;
            if (!float.TryParse(TextBoxArea.Text, out area) || area < 0)
            {
                MessageBox.Show("Площадь комнаты должна быть вещественныим положительным числом");
                TextBoxArea.Text = "1";
            }

        }
    }
}
