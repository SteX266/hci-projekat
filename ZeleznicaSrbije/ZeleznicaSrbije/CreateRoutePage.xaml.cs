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
using Microsoft.Maps.MapControl.WPF;
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for CreateRoutePage.xaml
    /// </summary>
    public partial class CreateRoutePage : Page
    {

        private List<Pushpin> pushpins;
        Dictionary<Station, TimeSpan> durations;
        Dictionary<Station, double> prices;

        public ObservableCollection<Station> routeStations
        {
            get;
            set;
        }

        private Point StartPoint;
        public CreateRoutePage()
        {
            InitializeComponent();
            DataContext = this;
            this.pushpins = new List<Pushpin>();
            this.routeStations = new ObservableCollection<Station>();
            this.durations = new Dictionary<Station, TimeSpan>();
            this.prices = new Dictionary<Station, double>();

            List<string> stationNames = new List<string>();
            foreach(Station station in SystemData.stations)
            {
                stationNames.Add(station.Name);
            }

            allStations.ItemsSource = stationNames;
        }

        public CreateRoutePage(TrainLine trainLine)
        {
            InitializeComponent();
            DataContext = this;
            this.pushpins = new List<Pushpin>();
            this.routeStations = new ObservableCollection<Station>();
            this.durations = trainLine.durations;
            this.prices = trainLine.prices;

            foreach(Station station in trainLine.stations)
            {
                Pushpin pin = new Pushpin
                {
                    Location = station.Location,
                    Content = station.Name

                };

                this.pushpins.Add(pin);
                this.routeStations.Add(station);
                MainMap.Children.Add(pin);
            }

            List<string> stationNames = new List<string>();
            foreach (Station station in SystemData.stations)
            {
                stationNames.Add(station.Name);
            }

            allStations.ItemsSource = stationNames;

            createButton.Content = "Izmeni";
        }

        private void MapView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StartPoint = e.GetPosition(null);
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = StartPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Image image = e.Source as Image;
                DataObject data = new DataObject(typeof(ImageSource), image.Source);
                DragDrop.DoDragDrop(image, data, DragDropEffects.Move);
            }
        }

        private void MainMap_Drop(object sender, DragEventArgs e)
        {
            Point mousePosition = e.GetPosition(MainMap);
            Location mouseLocation = MainMap.ViewportPointToLocation(mousePosition);

            Station station = Service.getClosestStation(mouseLocation);

            if (routeStations.Contains(station))
            {
                return;
            }    


            Pushpin pin = new Pushpin
            {
                Location = station.Location,
                Content = station.Name

            };

            durations[station] = new TimeSpan(0, 0, 0, 0);
            prices[station] = 0;
            routeStations.Add(station);
            pushpins.Add(pin);

            MainMap.Children.Add(pin);
        }

        private void MainMap_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }
        private void setPriceAndTime(object sender, RoutedEventArgs e)
        {

        }
        private void CloseStationModal(object sender, RoutedEventArgs e)
        {
            StationModal.IsOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (allStations.SelectedIndex != -1)
            {
                string stationName = allStations.SelectedItem.ToString();


                foreach(Station s in routeStations)
                {
                    if (s.Name == stationName)
                    {
                        return;
                    }    
                }

                Station station = Service.getStationByName(stationName);
                Pushpin pin = new Pushpin
                {
                    Location = station.Location,
                    Content = station.Name
                };

                durations[station] = new TimeSpan(0, 0, 0, 0);
                prices[station] = 0;


                routeStations.Add(station);
                pushpins.Add(pin);

                MainMap.Children.Add(pin);
                StationModal.IsOpen = true;
            }

        }
        public void deleteStation(object sender, RoutedEventArgs e)
        {
            int stationIndex = stations.SelectedIndex;

            Station station = routeStations.ElementAt(stationIndex);



            durations.Remove(station);
            prices.Remove(station);

            foreach (Pushpin pin in pushpins)
            {
                if (pin.Location.Equals(station.Location))
                {
                    MainMap.Children.Remove(pin);
                    pushpins.Remove(pin);
                    break;
                }
            }


            routeStations.RemoveAt(stationIndex);
        }

        public void createTrainLine(object sender, RoutedEventArgs e)
        {
            TrainLine trainLine = new TrainLine("naziv", routeStations.ToList(), durations, new List<TimeTable>(), prices);

            SystemData.trainsLines.Add(trainLine);
        }
    }
}
