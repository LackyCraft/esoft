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

namespace esoft.Nmobles
{
    /// <summary>
    /// Логика взаимодействия для Houses.xaml
    /// </summary>
    public partial class Houses1 : Page
    {
        List<Houses> housesList = eSoftEntities.GetContext().Houses.ToList();

        public Houses1()
        {
            InitializeComponent();
        DataGridHouses.ItemsSource = housesList;
        }
        private void DeletedAt(object sender, RoutedEventArgs e)
        {

        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources["idUser"].ToString() == "null" && Application.Current.Resources["Role"].ToString() != "C")
            {
                MessageBox.Show("Warning 403\nНеобходимо автроизоваться под ролью Администратора или Риелтора");
            }
            else
            {
                Nmobles.Edit.EditHousesWindow editApartament = new Nmobles.Edit.EditHousesWindow(DataGridHouses.SelectedItem as Houses);
                editApartament.Show();
            }
        }

        private void ButtClickButtonSearcon_Click(object sender, RoutedEventArgs e)
        {
            List<Houses> filterList = housesList;
            if (TextBoxSearchBox.Text.ToString().Length > 1)
            {
                filterList = filterList.Where(i => (i.ObjectNmobles.Title.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles.City.CityName.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles.AddressStreet.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || i.ObjectNmobles.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || i.CountFloor.ToString().Contains(TextBoxSearchBox.Text.ToString()) || i.CountRoom.ToString().Contains(TextBoxSearchBox.Text.ToString()) || i.Area.ToString().Contains(TextBoxSearchBox.Text.ToString()))).ToList();
            }

            DataGridHouses.ItemsSource = filterList;
        }

    }
}
