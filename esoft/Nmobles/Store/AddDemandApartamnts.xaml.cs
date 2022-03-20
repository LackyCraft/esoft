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
    /// Логика взаимодействия для AddDemandApartamnts.xaml
    /// </summary>
    public partial class AddDemandApartamnts : Page
    {

        private string TypeDemand;
        private int PriceMinDemand;
        private int PriceMaxDemand;
        private int IdRealtorDemand;
        private int IdClientDemand;

        public AddDemandApartamnts(string type, int priceMin, int priceMax, int idRealtor, int idClient)
        {
            InitializeComponent();
            TypeDemand = type;
            PriceMinDemand = priceMin;
            PriceMaxDemand = priceMax;
            IdRealtorDemand = idRealtor;
            IdClientDemand = idClient;
            ComboBoxCity.ItemsSource = eSoftEntities.GetContext().City.ToList();
        }

        private void TextChangedTextBoxCountRooms(object sender, TextChangedEventArgs e)
        {
            int countRooms = 0;
            if (!int.TryParse((sender as TextBox).Text, out countRooms) || countRooms < 0)
            {
                MessageBox.Show("Количество комнат должно быть целым положительным числом");
                (sender as TextBox).Text = "1";
            }
        }

        private void TextChangedTextBoxArea(object sender, TextChangedEventArgs e)
        {
            float area;
            if (!float.TryParse((sender as TextBox).Text, out area) || area < 0)
            {
                MessageBox.Show("Площадь комнаты должна быть вещественныим положительным числом");
                (sender as TextBox).Text = "1";
            }
        }

        private void TextChangedTextBoxFloor(object sender, TextChangedEventArgs e)
        {
            int floor;
            if (!int.TryParse((sender as TextBox).Text, out floor) || floor < 0)
            {
                MessageBox.Show("Количество комнат должна быть целым положительным числом");
                (sender as TextBox).Text = "1";
            }
        }

        private void сheckWarning(object sender, RoutedEventArgs e)
        {
            TextBlockWarning.Text = "";
            if (ComboBoxCity.SelectedIndex == -1)
            {
                ComboBoxCity.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
                TextBlockWarning.Text = "Выберите город";
            }
            if (TextBlockWarning.Text == "")
            {
                try
                {

                    Demand newDemand = new Demand();
                    newDemand.MinPrice = PriceMinDemand;
                    newDemand.MaxPrice = PriceMaxDemand;
                    newDemand.RealtorId = IdRealtorDemand;
                    newDemand.ClientId = IdClientDemand;
                    newDemand.TypeDemand = TypeDemand;
                    newDemand.AddressCity = int.Parse(ComboBoxCity.SelectedValue.ToString());
                    newDemand.AddressHouse = TextBoxHouses.Text;
                    newDemand.AddressNumber = null;

                    eSoftEntities.GetContext().Demand.Add(newDemand);

                    DemandApartments newApartaments = new DemandApartments();
                    newApartaments.idDemand = newDemand.id;
                    newApartaments.MinFloor = int.Parse(TextBoxMinFloor.Text);
                    newApartaments.MaxFloor = int.Parse(TextBoxMaxFloor.Text);
                    newApartaments.MaxArea = int.Parse(TextBoxMaxArea.Text);
                    newApartaments.MinArea = int.Parse(TextBoxMinArea.Text);
                    newApartaments.MinRooms = int.Parse(TextBoxMinCountRooms.Text);
                    newApartaments.MaxRooms = int.Parse(TextBoxMaxCountRooms.Text);

                    eSoftEntities.GetContext().DemandApartments.Add(newApartaments);

                    eSoftEntities.GetContext().SaveChanges();


                    MessageBox.Show("Сохранение прошло успешно");
                    this.Content = null;
                }
                catch
                {
                    MessageBox.Show("Error 505\nПроизошла непредвидиная ошибка.\n Не удалось подключиться к базе данных.\nПерезапустите приложение.");
                }


            }
        }

    }
}
