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
    /// Interaction logic for Timetable.xaml
    /// </summary>
    public partial class TimetablePage : Page
    {
        public TimetablePage()
        {
            InitializeComponent();
            StationPicker.ItemsSource = Service.getStationNames();
            TypePicker.ItemsSource = new List<string> { "Polasci", "Dolasci" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string origin = StationPicker.SelectedItem.ToString();
            string type = TypePicker.SelectedItem.ToString();
            List<string> stations = Service.getEndStations(origin);
            List<RideDTO> leavingRides = new List<RideDTO>();
            List<RideDTO> arrivingRides = new List<RideDTO>();
            foreach (string station in stations)
            {
                leavingRides.AddRange(Service.getRidesBetweenDestinations(origin, station));
                arrivingRides.AddRange(Service.getRidesBetweenDestinations(station, origin));
            }

            if (type.Equals("Polasci"))
            {
                Timetables.ItemsSource = leavingRides;

            }
            else
            {
                Timetables.ItemsSource=arrivingRides;
            }
        }
    }
}
