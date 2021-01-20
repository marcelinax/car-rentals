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
    /// Logika interakcji dla klasy RentCar.xaml
    /// </summary>
    public partial class RentCar : Page
    {
        /// <summary>
        /// Class that allows you to rent a car by selecting the user and the car from the list in the Database
        /// </summary>
        public RentCar()
        {
            InitializeComponent();
            this.fillCarCombobox();
            this.fillUserCombobox();
        }
        
        private void fillCarCombobox()
        {
            var context = new CarRentalEntities();

            carSelect.DisplayMemberPath = "Text";
            carSelect.SelectedValuePath = "Value";

            var cars = context.Cars.Where(c => c.Availability == "Yes");
            foreach (var car in cars)
            {
                carSelect.Items.Add(new { Text = car.Brand + " " + car.Model + " [" + car.CarYear + "] " + car.FuelType + " " + car.Mileage + "km", Value = car.CarId });
            }
        }
        private void fillUserCombobox()
        {
            var context = new CarRentalEntities();

            userSelect.DisplayMemberPath = "Text";
            userSelect.SelectedValuePath = "Value";

            var users = context.Users;
            foreach (var user in users)
            {
                userSelect.Items.Add(new { Text = user.Name + " " + user.LastName + " " + user.Login, Value = user.UserId });
            }
        }
        private void RentCarFc(object sender, RoutedEventArgs e)
        {
            var context = new CarRentalEntities();
            var selectedCarId = int.Parse(carSelect.SelectedValue.ToString());

            var newRental = new Rentals()
            {
                CarId = selectedCarId,
                UserId = int.Parse(userSelect.SelectedValue.ToString()),
                DataFrom = DateTime.Now,
                DataTo = (DateTime)rentToInput.SelectedDate
            };

            context.Rentals.Add(newRental);

            var selectedCar = context.Cars.First(c => c.CarId == selectedCarId);
            selectedCar.Availability = "No";

            context.SaveChanges();
        }
       

        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }

    }
}

