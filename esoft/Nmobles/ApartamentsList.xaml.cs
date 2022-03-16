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
    /// Логика взаимодействия для ApartamentsList.xaml
    /// </summary>
    public partial class ApartamentsList : Page
    {
        public ApartamentsList()
        {
            InitializeComponent();
            DataGridApartaments.ItemsSource = eSoftEntities.GetContext().Apartmens.ToList();
        }
        private void DeletedAt(object sender, RoutedEventArgs e)
        {

        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Nmobles.Edit.EditApartamentWindows editApartament = new Nmobles.Edit.EditApartamentWindows(DataGridApartaments.SelectedItem as Apartmens);
            editApartament.Show();
        }
    }
}
