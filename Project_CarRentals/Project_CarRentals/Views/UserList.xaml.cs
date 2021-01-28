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
    /// Logika interakcji dla klasy UserList.xaml
    /// </summary>
    public partial class UserList : Page
    {
        /// <summary>
        /// Showing the list of added users in the database
        /// </summary>
        public UserList()
        {
            InitializeComponent();
            this.loadUsers();
        }
        private void loadUsers()
        {
            var context = new CarRentalEntities();
            usersDataGrid.ItemsSource = context.Users.ToList();
        }
        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }
        private void GoListOfCars(object sender, RoutedEventArgs e)
        {
            var listOfCarsPage = new CarList();
            NavigationService.Navigate(listOfCarsPage);
        }
        private void GoListOfRentals(object sender, RoutedEventArgs e)
        {
            var listOfRentalsPage = new ListOfRentals();
            NavigationService.Navigate(listOfRentalsPage);
        }
        private void GoListOfPayments(object sender, RoutedEventArgs e)
        {
            var listOfPaymentsPage = new ListOfPayments();
            NavigationService.Navigate(listOfPaymentsPage);
        }
    }
}
