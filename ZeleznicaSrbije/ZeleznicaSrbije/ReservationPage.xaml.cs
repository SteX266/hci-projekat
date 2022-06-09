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
            OriginPicker.ItemsSource = SystemData.getStationNames();
            DestinationPicker.ItemsSource = SystemData.getStationNames();
        }

        public void Search()
        {
            String origin = OriginPicker.SelectedItem.ToString();
            String destination = DestinationPicker.SelectedItem.ToString();

            List<TrainLine> trainLines = SystemData.getLinesBetweenLocations(origin, destination);
            List<RideDTO> rides = new List<RideDTO>(); 
            foreach (TrainLine line in trainLines)
            {

                bool isOriginFirst = isFirst(line, origin, destination);

                List<Station> stations = line.stations;


                foreach (TimeTable timeTable in line.timeTables)
                {
                    double price;
                    string startString;
                    string endString;
                    TimeSpan start;
                    TimeSpan end;
                    if ((isOriginFirst && timeTable.isReverse) || (!isOriginFirst && !timeTable.isReverse))
                    {
                        continue;
                    }

                    start = SystemData.getArrivalTime(origin, timeTable, line);
                    end = SystemData.getArrivalTime(destination, timeTable, line);
                    price = SystemData.getTicketPrice(origin, destination, timeTable.isReverse, line);

                    startString = start.ToString();
                    endString = end.ToString();
                    string lineName = line.Name;
                    RideDTO ride = new RideDTO(startString, endString, price, lineName);
                    rides.Add(ride);

                }

            }

            ridesTable.ItemsSource = rides;
        }

        private bool isFirst(TrainLine line, string origin, string destination)
        {
            foreach (Station station in line.stations)
            {
                if (station.Name == origin)
                {
                    return true;
                }
                if (station.Name == destination)
                {
                    return false;
                }
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Search();
        }
    }
}
