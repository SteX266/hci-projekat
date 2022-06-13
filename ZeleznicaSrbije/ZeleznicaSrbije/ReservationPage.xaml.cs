using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<RideDTO> ridesToShow;
        public ReservationPage()
        {
            InitializeComponent();
            DataContext = this;
            ridesToShow = new ObservableCollection<RideDTO>();

            OriginPicker.ItemsSource = Service.getStationNames();
            DestinationPicker.ItemsSource = Service.getStationNames();


        }

        public void Search()
        {
            String origin = OriginPicker.SelectedItem.ToString();
            String destination = DestinationPicker.SelectedItem.ToString();

            List<RideDTO> rides = Service.getRidesBetweenDestinations(origin, destination);
            ridesToShow = new ObservableCollection<RideDTO>();

            foreach (RideDTO ride in rides)
            {
                ridesToShow.Add(ride);
            }


            ridesTable.ItemsSource = ridesToShow;
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Search();
        }

        

        private void OpenReservationModal(object sender, RoutedEventArgs e)
        {
            ReservationModal.IsOpen = true;
            List<string> cards = new List<string> { "1", "2", "3", "4" };

            TicketNumberPicker.ItemsSource = cards;
        }

        private void CloseReservationModal(object sender, RoutedEventArgs e)
        {
            ReservationModal.IsOpen = false;
        }
        private void MakeReservation(object sender, RoutedEventArgs e)
        {
            DateTime date = new DateTime();
            if (DatePicker.SelectedDate != null)
            {
                date = DatePicker.SelectedDate.Value.Date;

            }
            else
            {
                return;
            }
            if (DateTime.Compare(date, DateTime.Now) < 0)
            {
                return;
            }

            if (TicketNumberPicker.SelectedIndex == -1)
            {
                return;
            }
            int numberOfTickets = TicketNumberPicker.SelectedIndex + 1;

            int selectedRideIndex = ridesTable.SelectedIndex;

            RideDTO selectedRide = ridesToShow.ElementAt(selectedRideIndex);
            Service.reserveTickets(numberOfTickets,(Client)SystemData.currentUser, selectedRide.TimeTable, date, selectedRide.Polaziste, selectedRide.Odrediste);

            ReservationModal.IsOpen = false;

        }
    }
}
