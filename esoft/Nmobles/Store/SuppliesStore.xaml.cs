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
    public partial class SuppliesStore : Page
    {
        List<Supplies> landList;

        private string selectedTypeId;

        public SuppliesStore(string type)
        {
            InitializeComponent();
            selectedTypeId = type;
            DataGridSupliesStore.ItemsSource = eSoftEntities.GetContext().Supplies.Where(i => (i.ObjectNmobles1.TypeId == type && i.DeletedAt == null && i.ObjectNmobles1.IsBuy == null)).ToList();
            landList = eSoftEntities.GetContext().Supplies.Where(i => (i.ObjectNmobles1.TypeId == type && i.DeletedAt == null && i.ObjectNmobles1.IsBuy == null)).ToList();
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
                (DataGridSupliesStore.SelectedItem as Supplies).DeletedAt = int.Parse(Application.Current.Resources["idUser"].ToString());
                eSoftEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись успешно удалена");
                landList = eSoftEntities.GetContext().Supplies.Where(i => (i.ObjectNmobles1.TypeId == selectedTypeId && i.DeletedAt == null && i.ObjectNmobles1.IsBuy == null)).ToList();
                DataGridSupliesStore.ItemsSource = landList;
                }
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {

        }

        private void addSupplies(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddSupplies(selectedTypeId));
        }

        private void ChangedTextBoxSearchBox(object sender, TextChangedEventArgs e)
        {
            List<Supplies> filterList = new List<Supplies>();//new List<ListUsers>();
            if (TextBoxSearchBox.Text.Length > 1)
            {
                foreach (Supplies suplises in landList)
                {
                    if (suplises.ObjectNmobles1.City.CityName.Contains(TextBoxSearchBox.Text.ToString()) || suplises.ObjectNmobles1.AddressStreet.Contains(TextBoxSearchBox.Text.ToString()) || suplises.ObjectNmobles1.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()) || suplises.ObjectNmobles1.AddressHouse.Contains(TextBoxSearchBox.Text.ToString()))
                    {
                        filterList.Add(suplises);
                    }
                }
            }
            else
            {
                filterList = landList;
            }
            DataGridSupliesStore.ItemsSource = filterList;
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
