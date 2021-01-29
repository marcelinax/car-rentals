
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
using System.Text.RegularExpressions;

namespace Project_CarRentals.Views
{
    /// <summary>
    /// Logika interakcji dla klasy UserCreate.xaml
    /// </summary>
    public partial class UserCreate : Page
    {
        /// <summary>
        /// Class that allows you to add a new user to the Database
        /// </summary>
        public UserCreate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CarRentalEntities();
            var users = context.Users;
            successMessage.Text = "";
            string city = cityInput.Text;
            if (city == "" || city == "City")
            {
                errorMessage.Text = "Enter valid city name!";
                return;
            }
            if (birthdateInput.SelectedDate == null)
            {
                errorMessage.Text = "Choose date!";
                return;
            }
            if (birthdateInput.SelectedDate >= DateTime.Now)
            {
                errorMessage.Text = "Wrong date!";
                return;
            }
            if (birthdateInput.SelectedDate > DateTime.Now.AddYears(-18))
            {
                errorMessage.Text = "You are too young!";
                return;
            }
            string email = emailInput.Text;
            string pattern3 = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            var regex3 = new Regex(pattern3, RegexOptions.IgnoreCase);
            if (users.Where(u => u.Email == email).ToList().Count == 1)
            {
                errorMessage.Text = "User with this e-mail already exists!";
                return;
            }
            if (!regex3.IsMatch(email))
            {
                errorMessage.Text = "Enter valid e-mail!";
                return;
            }

            string lastName = surnameInput.Text;
            if (lastName == "" || lastName == "Surname")
            {
                errorMessage.Text = "Enter surname!";
                return;
            }
            string login = loginInput.Text;
            if (login == "" || login == "Login")
            {
                errorMessage.Text = "Enter login!";
                return;
            }
            if (users.Where(u => u.Login == login).ToList().Count == 1) {
                errorMessage.Text = "User with this login already exists!";
                return;
            }
            if (login.Length < 3) {
                errorMessage.Text = "Login is too short!";
                return;
            }
            string name = nameInput.Text;
            if (name == "" || name == "Name")
            {
                errorMessage.Text = "Enter name!";
                return;
            }
            string password = passwordInput.Text;
            if (password == "" || password == "Password")
            {
                errorMessage.Text = "Enter password!";
                return;
            }
            if (password.Length < 8)
            {
                errorMessage.Text = "Your password is too short! Must be at least 8 characters long!";
                return;
            }
            string pattern = @"[A-Z]";
            var regex = new Regex(pattern);
            if (!regex.IsMatch(password))
            {
                errorMessage.Text = "Your password must have at least one upper case!";
                return;
            }
            string pattern2 = @"[0-9]";
            var regex2 = new Regex(pattern2);
            if (!regex2.IsMatch(password))
            {
                errorMessage.Text = "Your password must have at least one digit!";
                return;
            }
            string pesel = peselInput.Text;
            if (pesel == "" || pesel == "PESEL")
            {
                errorMessage.Text = "Enter PESEL!";
                return;
            }
            if (pesel.Length < 11)
            {
                errorMessage.Text = "Enter valid PESEL!";
                return;
            }if (pesel.Length > 11)
            {
                errorMessage.Text = "Enter valid PESEL!";
                return;
            }
            if (users.Where(u => u.PESEL == pesel).ToList().Count == 1)
            {
                errorMessage.Text = "User with this PESEL already exists!";
                return;
            }

            string phone = phoneInput.Text;
            if (phone == "" || phone == "Phone")
            {
                errorMessage.Text = "Enter phone!";
                return;
            }
            if (phone.Length < 9)
            {
                errorMessage.Text = "Enter valid phone!";
                return;
            }if (phone.Length > 9)
            {
                errorMessage.Text = "Enter valid phone!";
                return;
            }
            if (users.Where(u=>u.Phone == phone).ToList().Count == 1)
            {
                errorMessage.Text = "User with this phone already exists!";
                return;
            }




            var newUser = new Users()
            {
                City = cityInput.Text,
                DateOfBirth = (DateTime)birthdateInput.SelectedDate,
                Email = emailInput.Text,
                LastName = surnameInput.Text,
                Login = loginInput.Text,
                Name = nameInput.Text,
                Password = passwordInput.Text,
                PESEL = peselInput.Text,
                Phone = phoneInput.Text,
            };
            context.Users.Add(newUser);
            context.SaveChanges();

            errorMessage.Text = "";
            successMessage.Text = "User was created.";
            ResetForm();
        }
        private void ResetForm()
        {
            birthdateInput.SelectedDate = null;
            cityInput.Text = "City";
            emailInput.Text = "E-mail";
            surnameInput.Text = "Surname";
            loginInput.Text = "Login";
            nameInput.Text = "Name";
            passwordInput.Text = "Password";
            peselInput.Text = "PESEL";
            phoneInput.Text = "Phone";

        }

        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }


    }
}
