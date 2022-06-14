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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for TicketsPage.xaml
    /// </summary>
    public partial class TicketsPage : Page
    {

        List<Reservation> reservationList;

        ObservableCollection<ReservationDTO> reservationsToShow
        {

            get;set;
        }

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

        public TicketsPage()
        {
            InitializeComponent();
            reservationList = ((Client)SystemData.currentUser).reservations;
            DataContext = this;
            OriginPicker.ItemsSource = Service.getStationNames();
            DestinationPicker.ItemsSource = Service.getStationNames();
            StatusPicker.ItemsSource = new List<String> { "Rezervisana", "Otkazana", "Istekla", "Kupljena" };
            reservationsToShow = new ObservableCollection<ReservationDTO>();

            List<string> stationNames = new List<string>(Service.getStationNames());
            stationNames.Insert(0,"Sve stanice");

            OriginPicker.ItemsSource = stationNames;
            
            DestinationPicker.ItemsSource = stationNames;

            List<string> statuses = new List<string> { "Svi statusi","Otkazana", "Istekla", "Rezervisana" };
            StatusPicker.ItemsSource = statuses;

            OriginPicker.SelectedIndex = 0;
            DestinationPicker.SelectedIndex = 0;
            StatusPicker.SelectedIndex = 0; 


            foreach(Reservation r in reservationList)
            {
                ReservationDTO reservationDTO = new ReservationDTO(r);
                reservationsToShow.Add(reservationDTO);
            }
            reservationsTable.ItemsSource = reservationsToShow;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(OriginPicker.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali validno polaziste!");
            } else if(DestinationPicker.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali validno odrediste!");
            }
            else if (StatusPicker.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali validan status!");
            } else
            {
                List<ReservationDTO> reservationDTOs = new List<ReservationDTO>();
                string origin = OriginPicker.SelectedItem.ToString();
                string destination = DestinationPicker.SelectedItem.ToString();
                string status = StatusPicker.SelectedItem.ToString();

                foreach(Reservation r in reservationList)
                {
                    if (r.startStation.Name.Contains(origin) || origin.Equals("Sve stanice"))
                    {
                        if (r.endStation.Name.Contains(destination) || destination.Equals("Sve stanice"))
                        {
                            if (r.status.ToString().ToLower().Equals(status.ToLower()) || status.Equals("Svi statusi"))
                            {
                                reservationDTOs.Add(new ReservationDTO(r));
                            }
                        }
                    }
                }
                if (reservationDTOs.Count <= 0)
                {
                    notifier.ShowInformation("Nista nije nadjeno!");
                }
                reservationsTable.ItemsSource = reservationDTOs;
            }
        }
    }
}
