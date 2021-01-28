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
    /// Logika interakcji dla klasy ListOfPayments.xaml
    /// </summary>
    public partial class ListOfPayments : Page
    {
        /// <summary>
        /// Showing the list of payments in the database
        /// </summary>
        public ListOfPayments()
        {
            InitializeComponent();
            loadPayments();
        }
        private void loadPayments()
        {
            var context = new CarRentalEntities();
            paymentsDataGrid.ItemsSource = context.Payments.ToList();
        }
        private void GoListOfCars(object sender, RoutedEventArgs e)
        {
            var listOfCarsPage = new CarList();
            NavigationService.Navigate(listOfCarsPage);
        }
        private void GoListOfUsers(object sender, RoutedEventArgs e)
        {
            var listOfUsersPage = new UserList();
            NavigationService.Navigate(listOfUsersPage);
        }
        private void GoListOfRentals(object sender, RoutedEventArgs e)
        {
            var listOfRentalsPage = new ListOfRentals();
            NavigationService.Navigate(listOfRentalsPage);
        }
        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }

        private void paymentsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
