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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for Timetable.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {
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

        public TimetablePage()
        {
            InitializeComponent();
            StationPicker.ItemsSource = Service.getStationNames();
            TypePicker.ItemsSource = new List<string> { "Polasci", "Dolasci" };
            TypePicker.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(StationPicker.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali validnu stanicu.");
            } else
            {
                string origin = StationPicker.SelectedItem.ToString();
                string type = TypePicker.SelectedItem.ToString();
                List<string> stations = Service.getEndStations(origin);
                List<RideDTO> leavingRides = new List<RideDTO>();
                List<RideDTO> arrivingRides = new List<RideDTO>();
                foreach (string station in stations)
                {
                    if (!origin.Equals(station))
                    {
                        leavingRides.AddRange(Service.getRidesBetweenDestinations(origin, station));
                        arrivingRides.AddRange(Service.getRidesBetweenDestinations(station, origin));
                    }
                }

                if (type.Equals("Polasci"))
                {
                    if (leavingRides.Count <= 0)
                    {
                        notifier.ShowInformation("Nista nije nadjeno!");
                    }
                    Timetables.ItemsSource = leavingRides;

                }
                else
                {
                    if (arrivingRides.Count <= 0)
                    {
                        notifier.ShowInformation("Nista nije nadjeno!");
                    }
                    Timetables.ItemsSource=arrivingRides;
                }
            }
        }
    }
}
