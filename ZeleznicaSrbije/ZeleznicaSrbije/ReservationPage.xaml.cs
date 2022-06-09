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
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : Page
    {
        public ReservationPage()
        {
            InitializeComponent();
            OriginPicker.ItemsSource = Service.getStationNames();
            DestinationPicker.ItemsSource = Service.getStationNames();
        }

        public void Search()
        {
            String origin = OriginPicker.SelectedItem.ToString();
            String destination = DestinationPicker.SelectedItem.ToString();

            List<RideDTO> rides = Service.getRidesBetweenDestinations(origin, destination);

            ridesTable.ItemsSource = rides;
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Search();
        }

        private void OpenTicketModal(object sender, RoutedEventArgs e)
        {
            CreateTrainModal.IsOpen = true;
        }

        private void CloseTicketModal(object sender, RoutedEventArgs e)
        {
            CreateTrainModal.IsOpen = false;
        }
    }
}
