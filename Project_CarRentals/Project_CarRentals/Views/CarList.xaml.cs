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
    /// Logika interakcji dla klasy CarList.xaml
    /// </summary>
    public partial class CarList : Page
    {
        /// <summary>
        /// Showing the list of added cars in the database
        /// </summary>
        public CarList()
        {
            InitializeComponent();
            this.loadCarsList();
        }
        private void loadCarsList()
        {
            var context = new CarRentalEntities();
            carsDataGrid.ItemsSource = context.Cars.ToList();
        }
        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }
        private void GoListOfUsers(object sender, RoutedEventArgs e)
        {
            var listOfUsersPage = new UserList();
            NavigationService.Navigate(listOfUsersPage);
        }
    }
}
