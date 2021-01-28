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
    /// Logika interakcji dla klasy ReturnCar.xaml
    /// </summary>
    public partial class ReturnCar : Page
    {
        /// <summary>
        /// Class that allows you to return a car by selecting from the car rentals saved in the database
        /// </summary>
        public ReturnCar()
        {
            InitializeComponent();
            this.fillReturnSelect();

        }
        private void fillReturnSelect()
        {

            var context = new CarRentalEntities();
          



            returnSelect.DisplayMemberPath = "Text";
            returnSelect.SelectedValuePath = "Value";

            var rentals = context.Rentals.Join(context.Users, ep => ep.UserId, e => e.UserId, (ep, e) => new { ep, e }).Join(context.Cars, ep => ep.ep.CarId, e => e.CarId, (ep, e) => new { ep, e }).Where(e => e.e
            .Availability == "No").Where(e => e.ep.ep.DataTo > DateTime.Now);
            foreach (var rental in rentals)
            {
                returnSelect.Items.Add(new { Text = rental.e.Brand + " " + rental.e.Model + " [" + rental.e.CarYear + "] " + rental.ep.e.Name + " " + rental.ep.e.LastName, Value = rental.ep.ep.RentalId });
            }

            
        }

        private void ReturnCarFc(object sender, RoutedEventArgs e)
        {
            var context = new CarRentalEntities();
            successMessage.Text = "";
            paymentMessage.Text = "";

            var rentals = context.Rentals;

            if (returnSelect.SelectedValue == null)
            {
                errorMessage.Text = "Choose car to return!";
                return;
            }

            var selectedRentalId = int.Parse(returnSelect.SelectedValue.ToString());
            var rental = context.Rentals.First(r => r.RentalId == selectedRentalId);
            var distanceTraveled = 0;
            if (rental.CalculationType == "Price per kilometer")
            {
                try
                {
                    distanceTraveled = int.Parse(distanceTraveledInput.Text);

                    if (distanceTraveled <= 0)
                    {
                        errorMessage.Text = "Distance traveled must be higher than zero!";
                        return;
                    }
                }
                catch
                {
                    errorMessage.Text = "Invalid distance traveled!";
                    return;
                }

                if (distanceTraveled <= 0)
                {
                    errorMessage.Text = "You need to enter distance traveled";
                    return;
                }

                
            }
            rental.DataTo = DateTime.Now;

            var rentedCar = context.Cars.First(c => c.CarId == rental.CarId);
            rentedCar.Availability = "Yes";

            var payment = new Payments() {
                RentalId = rental.RentalId,
                TotalAmount = decimal.Parse(amountToPayInput.Text),
                UserId = rental.UserId,
            };
            context.Payments.Add(payment);

            context.SaveChanges();

            errorMessage.Text = "";
            successMessage.Text = "Car was returned.";
        }

        private void CalculateAmountToPay()
        {
            var context = new CarRentalEntities();
            decimal amount = 0;

            if (returnSelect.SelectedValue != null) { 
                var selectedRentalId = int.Parse(returnSelect.SelectedValue.ToString());
                var rental = context.Rentals.First(r => r.RentalId == selectedRentalId);
                var car = context.Cars.First(c => c.CarId == rental.CarId);

                var rentTime = rental.DataFrom;
                var returnTime = DateTime.Now;

                switch (rental.CalculationType)
                {
                    case "Price per kilometer":
                        try
                        {
                            amount = Math.Round(int.Parse(distanceTraveledInput.Text) * car.PricePerKm, 2);
                        }
                        catch { }
                        break;
                    case "Price per hour":
                        amount = Math.Round((decimal)((returnTime - rentTime).TotalSeconds / 60 / 60) * car.PricePerHour, 2);
                        break;
                    case "Price per day":
                        amount = Math.Round((decimal)((returnTime - rentTime).TotalSeconds / 60 / 60 / 24) * car.PricePerDay, 2);
                        break;
                }
            }

            amountToPayInput.Text = amount.ToString();
        }

        private void DrawPaymentMethodMessage()
        {
            var context = new CarRentalEntities();
            if (returnSelect.SelectedValue != null)
            {
                var selectedRentalId = int.Parse(returnSelect.SelectedValue.ToString());
                var rental = context.Rentals.First(r => r.RentalId == selectedRentalId);
                var car = context.Cars.First(c => c.CarId == rental.CarId);

                switch (rental.CalculationType)
                {
                    case "Price per kilometer":
                        paymentMessage.Text = $"Tariff per kilometer ({car.PricePerKm}/km PLN).";
                        break;
                    case "Price per hour":
                        paymentMessage.Text = $"Tariff per hour ({car.PricePerHour}/hour PLN).";
                        break;
                    case "Price per day":
                        paymentMessage.Text = $"Tariff per day ({car.PricePerDay}/day PLN).";
                        break;
                }
            }
        }

        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }

        private void returnSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrawPaymentMethodMessage();
            CalculateAmountToPay();
        }

        private void distanceTraveledInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateAmountToPay();
        }
    }
}
