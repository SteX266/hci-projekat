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

using ThinkSharp.FeatureTouring.Models;
using ThinkSharp.FeatureTouring.Navigation;

using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : Page
    {


        public ObservableCollection<RideDTO> ridesToShow;
        private Notifier notifier = new Notifier(cfg =>
        {
            cfg.PositionProvider = new WindowPositionProvider(
                parentWindow: Application.Current.Windows[1],
                corner: Corner.BottomRight,
                offsetX: 10,
                offsetY: 10);

            cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                notificationLifetime: TimeSpan.FromSeconds(3),
                maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            cfg.Dispatcher = Application.Current.Dispatcher;
        });
        public ReservationPage()
        {
            InitializeComponent();
            DataContext = this;
            ridesToShow = new ObservableCollection<RideDTO>();

            OriginPicker.ItemsSource = Service.getStationNames();
            DestinationPicker.ItemsSource = Service.getStationNames();

        }

        private void originSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OriginPicker.SelectedItem.ToString() == "Jagodina")
            {
                OriginPicker.IsEnabled = false;
                DestinationPicker.IsEnabled = true;
                var navigator = FeatureTour.GetNavigator();
                navigator.IfCurrentStepEquals(Elements.OriginPickerCombo).GoNext();
            }
        }
        private void destinationSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DestinationPicker.SelectedItem.ToString() == "Novi Sad")
            {
                DestinationPicker.IsEnabled = false;
                SearchBtn.IsEnabled = true;
                var navigator = FeatureTour.GetNavigator();
                navigator.IfCurrentStepEquals(Elements.DestinationPickerCombo).GoNext();
            }
        }
        private void searchButtonClickedEvent(object sender, RoutedEventArgs e)
        {
                var navigator = FeatureTour.GetNavigator();
                navigator.IfCurrentStepEquals(Elements.DestinationPickerCombo).GoNext();
        }

        public void startTutorial()
        {
            var navigator = FeatureTour.GetNavigator();

            navigator.ForStep(Elements.OriginPickerCombo).AttachDoable(s => OriginPicker.SelectedItem = "Jagodina");
            navigator.ForStep(Elements.DestinationPickerCombo).AttachDoable(s => DestinationPicker.SelectedItem = "Novi Sad");

            navigator.OnStepEntered(Elements.OriginPickerCombo).Execute(s => OriginPicker.Focus());
            navigator.OnStepEntered(Elements.DestinationPickerCombo).Execute(s => DestinationPicker.Focus());
            navigator.OnStepEntered(Elements.SearchButton).Execute(s => SearchBtn.Focus());

            OriginPicker.SelectionChanged += originSelectionChanged;
            DestinationPicker.SelectionChanged += destinationSelectionChanged;
            SearchBtn.Click += searchButtonClickedEvent;

            

            DestinationPicker.IsEnabled = false;
            SearchBtn.IsEnabled = false;

            StartReservationTour();

        }



        private void StartReservationTour()
        {
            var tour = new Tour
            {
                Name = "Reservation tour",
                ShowNextButtonDefault = false,
                Steps = new[]
    {
                    new Step(Elements.OriginPickerCombo, "Izaberite pocetnu stanicu", "Izaberite \"Jagodina\". "),
                    new Step(Elements.DestinationPickerCombo, "Izaberite krajnju stanicu", "Izaberite \"Novi Sad\". "),
                    new Step(Elements.SearchButton, "Pritisnite na dugme \"Pretraži\"", "Kliknite pretraži"),
                }
            };

            tour.Start();
        }

        public void Search()
        {
            if (OriginPicker.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali polaziste!");
            } else if (DestinationPicker.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali odrediste!");
            } else
            {

            
                String origin = OriginPicker.SelectedItem.ToString();
                String destination = DestinationPicker.SelectedItem.ToString();

                List<RideDTO> rides = Service.getRidesBetweenDestinations(origin, destination);
                ridesToShow = new ObservableCollection<RideDTO>();

                foreach (RideDTO ride in rides)
                {
                    ridesToShow.Add(ride);
                }

                if(ridesToShow.Count <= 0)
                {
                    notifier.ShowInformation("Nista nije nadjeno!");
                }
                ridesTable.ItemsSource = ridesToShow;
            }

            ridesTable.ItemsSource = ridesToShow;

        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            startTutorial();
        //    this.Search();
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
            if (DatePicker.SelectedDate == null)
            {
                notifier.ShowWarning("Niste izabrali datum rezervacije!");
            } else if (TicketNumberPicker.SelectedIndex == -1) 
            {
                notifier.ShowWarning("Niste izabrali broj karata!");
            } else
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
}
