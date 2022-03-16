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

namespace esoft.RolePage.Admin
{
    /// <summary>
    /// Логика взаимодействия для addUser.xaml
    /// </summary>
    public partial class addUser : Page
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void clickScrol(object sender, RoutedEventArgs e)
        {
            if (sender == Client)
                this.NavigationService.Navigate(new Uri("/Register.xaml",UriKind.Relative));
            if (sender == Rieltor)
                this.NavigationService.Navigate(new Uri("/RolePage/Admin/RegisterRieltor.xaml", UriKind.Relative));
        }
    }
}
