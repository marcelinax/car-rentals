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
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    public partial class CarCreate : Page
    {
        public CarCreate()
        {
            InitializeComponent();
            this.fillCombobox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CarRentalEntities();
            var newCar = new Cars()
            {
                Availability = availabilityInput.Text,
                Brand = brandInput.Text,
                CarYear = int.Parse(carYearInput.Text),
                FuelType = fuelTypeInput.Text,
                Mileage = int.Parse(mileageInput.Text),
                Model = modelInput.Text,
                PricePerKm = decimal.Parse(pircePerKmInput.Text),
                PricePerHour = decimal.Parse(pircePerHourInput.Text),
                PricePerDay = decimal.Parse(pircePerDayInput.Text),
                Type = typeInput.Text,
                UserId = int.Parse(userIDSelect.SelectedValue.ToString())
            };
            context.Cars.Add(newCar);
            context.SaveChanges();
        }

        public void fillCombobox()
        {
            var context = new CarRentalEntities();

            userIDSelect.DisplayMemberPath = "Text";
            userIDSelect.SelectedValuePath = "Value";

            var users = context.Users;
            foreach (var user in users)
            {
                userIDSelect.Items.Add(new { Text = user.Name + " " + user.LastName, Value = user.UserId });
            }
        }
        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }
    }
}

