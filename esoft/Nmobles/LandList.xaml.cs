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
    /// Логика взаимодействия для LandList.xaml
    /// </summary>
    public partial class LandList : Page
    {

        List<Land> HousesList = eSoftEntities.GetContext().Land.Where(i => i.ObjectNmobles.DeletedBy == null).ToList();

        public LandList()
        {
            InitializeComponent();
            DataGridLands.ItemsSource = HousesList;
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
                    ObjectNmobles editObjectNmobles = (DataGridLands.SelectedItem as Land).ObjectNmobles;
                    editObjectNmobles.DeletedBy = int.Parse(Application.Current.Resources["idUser"].ToString());
                    eSoftEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись успешно удалена");

                    HousesList = eSoftEntities.GetContext().Land.Where(i => i.ObjectNmobles.DeletedBy == null).ToList();

                    DataGridLands.ItemsSource = HousesList;
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
                Nmobles.Edit.editLandWindows editApartament = new Nmobles.Edit.editLandWindows(DataGridLands.SelectedItem as Land);
                editApartament.Show();
            }
        }

        private void ChangedTextBoxSearchBox(object sender, TextChangedEventArgs e)
        {
            List<Land> filterList = new List<Land>();//new List<ListUsers>();
            if (TextBoxSearchBox.Text.Length > 1)
            {
                foreach (Land lands in HousesList)
                {
                    if (LevenshteinDistance(lands.ObjectNmobles.Title.ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || LevenshteinDistance(lands.ObjectNmobles.City.CityName.ToString(), TextBoxSearchBox.Text.ToString()) <=2 || LevenshteinDistance(lands.ObjectNmobles.AddressStreet.ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || LevenshteinDistance(lands.ObjectNmobles.AddressHouse.ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || LevenshteinDistance(lands.ObjectNmobles.AddressHouse.ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || LevenshteinDistance(lands.Area.ToString().ToString(), TextBoxSearchBox.Text.ToString()) <= 2 || lands.ObjectNmobles.Title.Contains(TextBoxSearchBox.Text.ToString()) || lands.ObjectNmobles.City.CityName.Contains(TextBoxSearchBox.Text.ToString()) || lands.ObjectNmobles.AddressStreet.Contains(TextBoxSearchBox.Text.ToString()) || lands.ObjectNmobles.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || lands.ObjectNmobles.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || lands.Area.ToString().Contains(TextBoxSearchBox.Text.ToString()))
                        filterList.Add(lands);
                }
            }
            else
            {
                filterList = HousesList;
            }

            DataGridLands.ItemsSource = filterList;

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
