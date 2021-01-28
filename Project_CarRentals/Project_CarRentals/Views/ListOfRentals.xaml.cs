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
    /// Showing the list of rentals in the database
    /// </summary>
    public partial class ListOfRentals : Page
    {
        public ListOfRentals()
        {
            InitializeComponent();
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
        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }
        private void GoListOfPayments(object sender, RoutedEventArgs e)
        {
            var listOfPaymentsPage = new ListOfPayments();
            NavigationService.Navigate(listOfPaymentsPage);
        }
    }
}
