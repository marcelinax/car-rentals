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
            this.fillCallculationTypeCombobox();
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

            var selectedRentalId = int.Parse(returnSelect.SelectedValue.ToString());

            var rental = context.Rentals.First(r => r.RentalId == selectedRentalId);

            rental.DataTo = DateTime.Now;

            var rentedCar = context.Cars.First(c => c.CarId == rental.CarId);
            rentedCar.Availability = "Yes";

            context.SaveChanges();
        }
        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }
        private void fillCallculationTypeCombobox()
        {
            callculationTypeSelect.Items.Add("Price per hour");
            callculationTypeSelect.Items.Add("Price per kilometer");
            callculationTypeSelect.Items.Add("Price per day");
        }
    }
}
