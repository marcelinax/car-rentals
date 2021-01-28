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
        /// <summary>
        /// Class that allows you to add a new car to the Database
        /// </summary>
        public CarCreate()
        {
            InitializeComponent();
            this.fillCombobox();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CarRentalEntities();
            successMessage.Text = "";

            string availability = availabilityInput.Text;
            if (availability == "" || availability == "Availability")
            {
                errorMessage.Text = "Enter valid availability!";
                return;
            }
            if(availability != "Yes" && availability != "No")
            {
                errorMessage.Text = "Availability must be Yes or No!";
                return;
            }

            string brand = brandInput.Text;
            if (brand == "" || brand == "Brand")
            {
                errorMessage.Text = "Enter valid brand!";
                return;
            }
            string model = modelInput.Text;
            if (model == "" || model == "Model")
            {
                errorMessage.Text = "Enter valid model!";
                return;
            }
            if (!carYearInput.Text.All(char.IsDigit)) {
                errorMessage.Text = "Car year must be a number!";
                return;
            }
            var carYear = int.Parse(carYearInput.Text);
            if (carYear > DateTime.Now.Year)
            {
                errorMessage.Text = "Invalid date, car year cannot be higher than actual year!";
                return;
            }
            if (carYear < 1870)
            {
                errorMessage.Text = "Invalid date, car year must be higher than car invention year!";
                return;
            }
            string fuelType = fuelTypeInput.Text.ToLower();
            if (fuelType == "" || fuelType == "fuel type" )
            {
                errorMessage.Text = "Enter valid fuel type!";
                return;
            }
            if(fuelType != "petrol" && fuelType != "gas" && fuelType != "diesel")
            {
                errorMessage.Text = "Fuel type must be gas or diesel or petrol!";
                return;
            }

            if (!mileageInput.Text.All(char.IsDigit))
            {
                errorMessage.Text = "Mileage must be a number!";
                return;
            }
            var mileage = int.Parse(mileageInput.Text);
            if (mileage < 0)
            {
                errorMessage.Text = "Mileage cannot be negative!";
                return;
            }

            string type = typeInput.Text;
            if (type == "" || type == "Type")
            {
                errorMessage.Text = "Enter type!";
                return;
            }

            try
            {

                var pricePerKm = decimal.Parse(pircePerKmInput.Text);
                if(pricePerKm <= 0)
                {
                    errorMessage.Text = "Price per kilometer must be higher than zero!";
                    return;
                }
            }
            catch
            {
                errorMessage.Text = "Invalid price per kilometer!";
                return; 
            }
            try
            {

                var pricePerHour = decimal.Parse(pircePerHourInput.Text);
                if (pricePerHour <= 0)
                {
                    errorMessage.Text = "Price per hour must be higher than zero!";
                    return;
                }
            }
            catch
            {
                errorMessage.Text = "Invalid price per hour!";
                return;
            }
            try
            {

                var pricePerDay = decimal.Parse(pircePerDayInput.Text);
                if (pricePerDay <= 0)
                {
                    errorMessage.Text = "Price per day must be higher than zero!";
                    return;
                }
            }
            catch
            {
                errorMessage.Text = "Invalid price per day!";
                return;
            }

             ;
            if(userIDSelect.SelectedValue == null)
            {
                errorMessage.Text = "Choose user!";
                return;
            }
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

            errorMessage.Text = "";
            successMessage.Text = "Car was created.";
            ResetForm();
        }
      
        private void ResetForm()
        {
            userIDSelect.SelectedValue = null;
            fillCombobox();
            modelInput.Text = "";
            brandInput.Text = "";
            typeInput.Text = "";
            carYearInput.Text = "";
            fuelTypeInput.Text = "";
            mileageInput.Text = "";
            availabilityInput.Text = "";
            pircePerKmInput.Text = "";
            pircePerHourInput.Text = "";
            pircePerDayInput.Text = "";
        }

        /// <summary>
        /// User selection from the list of users from DataBase
        /// </summary>
        public void fillCombobox()
        {
            userIDSelect.Items.Clear();
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

