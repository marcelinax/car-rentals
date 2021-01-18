
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

namespace Project_CarRentals.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UserCreate.xaml
    /// </summary>
    public partial class UserCreate : Page
    {
        /// <summary>
        /// Class that allows you to add a new user to the Database
        /// </summary>
        public UserCreate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CarRentalEntities();
            var newUser = new Users()
            {
                City = cityInput.Text,
                DateOfBirth = (DateTime)birthdateInput.SelectedDate,
                Email = emailInput.Text,
                LastName = surnameInput.Text,
                Login = loginInput.Text,
                Name = nameInput.Text,
                Password = passwordInput.Text,
                PESEL = peselInput.Text,
                Phone = phoneInput.Text,
            };
            context.Users.Add(newUser);
            context.SaveChanges();
        }
        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }


    }
}
