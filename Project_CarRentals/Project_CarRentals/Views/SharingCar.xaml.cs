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
    /// Logika interakcji dla klasy SharingCar.xaml
    /// </summary>
    public partial class SharingCar : Page
    {
        /// <summary>
        /// Class that allows you to lend your car to another user
        /// </summary>
        public SharingCar()
        {
            InitializeComponent();
        }
        private void GoMainMenu(object sender, RoutedEventArgs e)
        {
            var mainMenuPage = new MainMenu();
            NavigationService.Navigate(mainMenuPage);
        }
    }
}
