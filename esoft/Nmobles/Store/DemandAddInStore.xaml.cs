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
    /// Логика взаимодействия для DemandAddInStore.xaml
    /// </summary>
    public partial class DemandAddInStore : Page
    {
        public DemandAddInStore()
        {
            InitializeComponent();

            string selectedTypeId = "A";
        }

        private void changedCheck(object sender, TextChangedEventArgs e)
        {
            /* int price;
            if (!int.TryParse(TextBoxPriceMin.Text, out price) && sender == TextBoxPriceMin && price > 0)
            {
                MessageBox.Show("Warning 422\nМинимальная цена должна быть целым положительным числом!");
                TextBoxPriceMin.Text = "0";
            }
            if (!int.TryParse(TextBoxPriceMax.Text, out price) && sender == TextBoxPriceMax && price > 0)
            {
                MessageBox.Show("Warning 422\nМаксимальная цена должна быть целым положительным числом!");
                TextBoxPriceMax.Text = "0";
            } */
        }

        private void сheckWarning(object sender, RoutedEventArgs e)
        {
   
        }


    }
}
