﻿using System;
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

        User entityEditUser;

        public UserInfo()
        {
            InitializeComponent();
            
            int idUser = int.Parse(Application.Current.Resources["idUser"].ToString());
            entityEditUser = eSoftEntities.GetContext().User.Where(i => i.id == idUser).ToList()[0];

            if (entityEditUser.RoleId == "C")
            {
                TextBlockLabel.Text = "Карточка клиента";
                var clientInfo = eSoftEntities.GetContext().Client.Where(i => i.UserId == entityEditUser.id).ToList()[0];
                TextBoxLogin.Text = entityEditUser.login;
                TextBoxLastName.Text = clientInfo.LastName;
                TextBoxFirstName.Text = clientInfo.FirstName;
                TextBoxMidlName.Text = clientInfo.MidlName;
                TextBoxNumberPhone.Text = clientInfo.Phone;
                TextBoxEmail.Text = clientInfo.Email;
                PasswordBoxOldPassword.Password = entityEditUser.password;

                DataGridSupliesStore.ItemsSource = eSoftEntities.GetContext().Supplies.Where(i => (i.ClientId == clientInfo.Id && i.DeletedAt == null && i.ObjectNmobles1.IsBuy == null)).ToList();
                DataGridDemand.ItemsSource = eSoftEntities.GetContext().Demand.Where(i => (i.ClientId == clientInfo.Id && i.DeletedBy == null && i.DealNmobles == null)).ToList();
            }
            if (entityEditUser.RoleId == "R")
            {
                TextBlockLabel.Text = "Карточка риэлтора";
                var RieltorInfo = eSoftEntities.GetContext().Realtor.Where(i => i.idUser == entityEditUser.id).ToList()[0];
                TextBoxLogin.Text = entityEditUser.login;
                TextBoxLastName.Text = RieltorInfo.LastName;
                TextBoxFirstName.Text = RieltorInfo.FirstName;
                TextBoxMidlName.Text = RieltorInfo.MidlName;

                TextBlockMidlName.Text = "Отчество*:";
                TextBlockFirstName.Text = "Фамилия*:";
                TextBlockLastName.Text = "Имя*:";

                WarningContactItem.Text = "Поля номер телефона и Email для риелторов не заполняются.";


                TextBoxNumberPhone.IsEnabled = false;
                TextBoxEmail.IsEnabled = false;
                TextBoxNumberPhone.Background = (Brush)Application.Current.MainWindow.FindResource("Grey");
                TextBoxEmail.Background = (Brush)Application.Current.MainWindow.FindResource("Grey");

                PasswordBoxOldPassword.Password = entityEditUser.password;

                DataGridSupliesStore.ItemsSource = eSoftEntities.GetContext().Supplies.Where(i => (i.RialtorId == RieltorInfo.id && i.DeletedAt == null && i.ObjectNmobles1.IsBuy == null)).ToList();
                DataGridDemand.ItemsSource = eSoftEntities.GetContext().Demand.Where(i => (i.RealtorId == RieltorInfo.id && i.DeletedBy == null && i.DealNmobles == null)).ToList();
            }
        }

        private void SaveEditUser(object sender, RoutedEventArgs e)
        {
            var bc = new BrushConverter();
            string messageWarning = "";
            TextBlockWarning.Text = "";
            string newLogin = TextBoxLogin.Text;

            PasswordBoxNewPassword.Background = Brushes.White;
            PasswordBoxOldPassword.Background = Brushes.White;
            WarningContactItem.Foreground = (Brush)bc.ConvertFrom("#546e7a");
            TextBoxNumberPhone.Background = Brushes.White;

            if (PasswordBoxNewPassword.Password.ToString().Length < 6 && !(PasswordBoxNewPassword.Password is null))
            {
                MessageBox.Show("Error 422\n Пароль должен содержать не меньше 6 символов");
                messageWarning = "\nПароль должен содержать не меньше 6 символов";
                PasswordBoxNewPassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (PasswordBoxOldPassword.Password.ToString() != entityEditUser.password)
            {
                MessageBox.Show("Error 422\n Поле страый пароль заполнено неверно");
                messageWarning = "Поле страый пароль заполнено неверно";
                PasswordBoxOldPassword.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
            }
            if (entityEditUser.RoleId != "R")
            {
                if (TextBoxEmail.Text.Length < 3 && TextBoxNumberPhone.Text.Length != 12)
                {
                    WarningContactItem.Foreground = (Brush)Application.Current.MainWindow.FindResource("Warning");
                    if (TextBoxNumberPhone.Text.Length != 12)
                    {
                        TextBoxNumberPhone.Background = (Brush)Application.Current.MainWindow.FindResource("Warning");
                        messageWarning += "\nТелефон должен содержать ровно 12 цифр";
                    }
                }
            }


            if (messageWarning.Length > 2)
            {
                TextBlockWarning.Text = messageWarning;
            }
            else
            {
                entityEditUser.password = PasswordBoxNewPassword.Password.ToString();
                eSoftEntities.GetContext().SaveChanges();

                if (entityEditUser.RoleId == "C")
                {
                    var editClient = eSoftEntities.GetContext().Client.Where(i => i.UserId == entityEditUser.id).ToList()[0];
                    if (TextBoxLastName.Text.Length > 3)
                    {
                        editClient.LastName = TextBoxLastName.Text;
                    }
                    else
                    {
                        editClient.LastName = null;
                    }
                    if (TextBoxFirstName.Text.Length > 3)
                    {
                        editClient.FirstName = TextBoxFirstName.Text;
                    }
                    else
                    {
                        editClient.FirstName = null;
                    }
                    if (TextBoxMidlName.Text.Length > 1)
                    {
                        editClient.MidlName = TextBoxMidlName.Text;
                    }
                    else
                    {
                        editClient.MidlName = null;
                    }
                    if (TextBoxEmail.Text.Length > 3)
                    {
                        editClient.Email = TextBoxEmail.Text;
                    }
                    else
                    {
                        editClient.Email = null;
                    }
                    if (TextBoxNumberPhone.Text.Length == 12)
                    {
                        editClient.Phone = TextBoxNumberPhone.Text;
                    }
                    else
                    {
                        editClient.Phone = null;
                    }
                }


                if (entityEditUser.RoleId == "R")
                {
                    var editClient = eSoftEntities.GetContext().Realtor.Where(i => i.idUser == entityEditUser.id).ToList()[0];
                    if (TextBoxLastName.Text.Length > 3)
                        editClient.LastName = TextBoxLastName.Text;
                    if (TextBoxFirstName.Text.Length > 3)
                        editClient.FirstName = TextBoxFirstName.Text;
                    if (TextBoxMidlName.Text.Length > 1)
                        editClient.MidlName = TextBoxMidlName.Text;
                }

                eSoftEntities.GetContext().SaveChanges();

                MessageBox.Show("Изменения сохранены");
            }
        }
    }
}
