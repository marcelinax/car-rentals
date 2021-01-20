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
    /// Logika interakcji dla klasy MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        /// <summary>
        /// The class that enables navigation between the pages of the application
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }
        private void GoUserCreate(object sender, RoutedEventArgs e)
        {
            var userCreatePage = new UserCreate();
            NavigationService.Navigate(userCreatePage);
        }
        
        private void GoCarCreate(object sender, RoutedEventArgs e)
        {
            var carCreatePage = new CarCreate();
            NavigationService.Navigate(carCreatePage);
        }
        private void GoRentCar(object sender, RoutedEventArgs e)
        {
            var rentCarPage = new RentCar();
            NavigationService.Navigate(rentCarPage);
        }
        private void GoListofCars(object sender, RoutedEventArgs e)
        {
            var listOfCarsPage = new CarList();
            NavigationService.Navigate(listOfCarsPage);
        }
    }
}
