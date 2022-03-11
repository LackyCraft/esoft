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

namespace esoft.RolePage.Client
{
    /// <summary>
    /// Логика взаимодействия для UserInfo.xaml
    /// </summary>
    public partial class UserInfo : Page
    {
        public UserInfo()
        {
            InitializeComponent();
            int idUser = int.Parse(Application.Current.Resources["idUser"].ToString());
            var userInfo = eSoftEntities.GetContext().User.Where(i => i.id == idUser).ToList()[0];
            if(userInfo.RoleId == "C")
            {
                TextBlockLabel.Text = "Карточка клиента";
                var clientInfo = eSoftEntities.GetContext().Client.Where(i => i.UserId == userInfo.id).ToList()[0];
                TextBoxLogin.Text = userInfo.login;
                TextBoxLastName.Text = clientInfo.LastName;
                TextBoxFirstName.Text = clientInfo.FirstName;
                TextBoxMidlName.Text = clientInfo.MidlName;
                TextBoxNumberPhone.Text = clientInfo.Phone;
                TextBoxEmail.Text = clientInfo.Email;
                PasswordBoxOldPassword.Password = userInfo.password;
            }
            if (userInfo.RoleId == "R")
            {
                TextBlockLabel.Text = "Карточка риэлтора";
                var RieltorInfo = eSoftEntities.GetContext().Realtor.Where(i => i.idUser == userInfo.id).ToList()[0];
                TextBoxLogin.Text = userInfo.login;
                TextBoxLastName.Text = RieltorInfo.LastName;
                TextBoxFirstName.Text = RieltorInfo.FirstName;
                TextBoxMidlName.Text = RieltorInfo.MidlName;

                TextBlockMidlName.Text = "Фамилия*:";
                TextBlockFirstName.Text = "Имя*:";
                TextBlockLastName.Text = "Отчетсво*:";

                WarningContactItem.Text = "Поля номер телефона и Email для риелторов не заполняются.";


                TextBoxNumberPhone.IsEnabled = false;
                TextBoxEmail.IsEnabled = false;
                TextBoxNumberPhone.Background = Brushes.DimGray;
                TextBoxEmail.Background = Brushes.DimGray;

                PasswordBoxOldPassword.Password = userInfo.password;
            }

            MessageBox.Show("test");
            //TextBoxLogin.Text = userInfo.login;
            //TextBoxLastName.Text = 
        }
    }
}
