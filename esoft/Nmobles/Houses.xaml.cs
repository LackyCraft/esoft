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
        List<Houses> housesList = eSoftEntities.GetContext().Houses.Where(i => i.ObjectNmobles.DeletedBy == null).ToList();

        public Houses1()
        {
            InitializeComponent();
        DataGridHouses.ItemsSource = housesList;
        }
        private void DeletedAt(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources["idUser"].ToString() == "null" && Application.Current.Resources["Role"].ToString() != "C")
            {
                MessageBox.Show("Warning 403\nНеобходимо автроизоваться под ролью Администратора или Риелтора");
            }
            else
            {
                if (MessageBox.Show("Вы точно хотите удалить данную запись?",
                "Save file",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ObjectNmobles editObjectNmobles = (DataGridHouses.SelectedItem as Houses).ObjectNmobles;
                    editObjectNmobles.DeletedBy = int.Parse(Application.Current.Resources["idUser"].ToString());
                    eSoftEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись успешно удалена");

                    housesList = eSoftEntities.GetContext().Houses.Where(i => i.ObjectNmobles.DeletedBy == null).ToList();

                    DataGridHouses.ItemsSource = housesList;
                }
            }
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

        private void ChangedTextBoxSearchBox(object sender, TextChangedEventArgs e)
        {
            List<Houses> filterList = new List<Houses>();//new List<ListUsers>();
            if (TextBoxSearchBox.Text.Length > 1)
            {
                foreach (Houses houses in housesList)
                {
                    if (LevenshteinDistance(houses.ObjectNmobles.Title.ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || LevenshteinDistance(houses.ObjectNmobles.City.CityName.ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || LevenshteinDistance(houses.ObjectNmobles.AddressStreet.ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || LevenshteinDistance(houses.ObjectNmobles.AddressHouse.ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || LevenshteinDistance(houses.ObjectNmobles.AddressHouse.ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || LevenshteinDistance(houses.Area.ToString().ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || houses.ObjectNmobles.Title.Contains(TextBoxSearchBox.Text.ToString()) || houses.ObjectNmobles.City.CityName.Contains(TextBoxSearchBox.Text.ToString()) || houses.ObjectNmobles.AddressStreet.Contains(TextBoxSearchBox.Text.ToString()) || houses.ObjectNmobles.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || houses.ObjectNmobles.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || houses.Area.ToString().Contains(TextBoxSearchBox.Text.ToString()))
                        filterList.Add(houses);
                }
            }
            else
            {
                filterList = housesList;
            }
            DataGridHouses.ItemsSource = filterList;
        }


        public static int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null) string1 = "";
            if (string2 == null) string2 = "";
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
                }
            }
            return m[string1.Length, string2.Length];
        }


    }
}
