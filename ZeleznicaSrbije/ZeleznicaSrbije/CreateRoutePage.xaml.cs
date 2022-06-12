using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        Station currentStation;
        TrainLine editTrainLine;

        Frame f;

        public ObservableCollection<Station> routeStations
        {
            get;
            set;
        }

        private Point StartPoint;
        public CreateRoutePage(Frame f)
        {
            InitializeComponent();
            DataContext = this;
            this.pushpins = new List<Pushpin>();
            this.routeStations = new ObservableCollection<Station>();
            this.durations = new Dictionary<Station, TimeSpan>();
            this.prices = new Dictionary<Station, double>();
            this.currentStation = new Station();
            this.f = f;

            List<string> stationNames = new List<string>();
            foreach(Station station in SystemData.stations)
            {
                stationNames.Add(station.Name);
            }

            allStations.ItemsSource = stationNames;
        }

        public CreateRoutePage(TrainLine trainLine, Frame f)
        {
            InitializeComponent();
            DataContext = this;
            this.pushpins = new List<Pushpin>();
            this.routeStations = new ObservableCollection<Station>();
            this.durations = trainLine.durations;
            this.prices = trainLine.prices;
            this.f = f;

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
            editTrainLine = trainLine;
        }

        public void MapView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StartPoint = e.GetPosition(null);
        }

        public void Image_MouseMove(object sender, MouseEventArgs e)
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

        public void MainMap_Drop(object sender, DragEventArgs e)
        {
            Point mousePosition = e.GetPosition(MainMap);
            Location mouseLocation = MainMap.ViewportPointToLocation(mousePosition);
            Station station = Service.getClosestStation(mouseLocation);
            handlePin(station);
        }

        public void MainMap_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }
        public void setPriceAndTime(object sender, RoutedEventArgs e)
        {

            int price = Int32.Parse(Price.Text);
            int minutes = Int32.Parse(Minutes.Text);

            durations[currentStation] = new TimeSpan(0, 0, minutes, 0);
            prices[currentStation] = price;
            CloseStationModal(sender, e);
        }
        public void CloseStationModal(object sender, RoutedEventArgs e)
        {
            StationModal.IsOpen = false;
        }

        public void addStation(object sender, RoutedEventArgs e)
        {
            if (allStations.SelectedIndex != -1)
            {
                string stationName = allStations.SelectedItem.ToString();
                Station station = Service.getStationByName(stationName);
                handlePin(station);
            }

        }


        public void handlePin(Station station)
        {

            if (routeStations.Contains(station))
            {
                return;
            }
            Pushpin pin = new Pushpin
            {
                Location = station.Location,
                Content = station.Name
            };


            routeStations.Add(station);
            pushpins.Add(pin);
            MainMap.Children.Add(pin);
            this.currentStation = station;
            if (routeStations.Count > 1)
            {
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



        public void openEditModal(object sender, RoutedEventArgs e)
        {
            int index = stations.SelectedIndex;
            Station station = routeStations.ElementAt(index);
            EPrice.Text = prices[station].ToString();
            EMinutes.Text = durations[station].TotalMinutes.ToString();
            currentStation = station;
            EditStationModal.IsOpen = true;
        }

        public void closeEditModal(object sender, RoutedEventArgs e)
        {
            EditStationModal.IsOpen=false; 
        }

        public void editStation(object sender, RoutedEventArgs e)
        {
            double price = Double.Parse(EPrice.Text);
            int minutes = Int32.Parse(EMinutes.Text);
            durations[currentStation] = new TimeSpan(0, 0, minutes, 0);
            prices[currentStation] = price;
            closeEditModal(sender, e);
        }


        public void OpenConfirmModal(object sender, RoutedEventArgs e)
        {
            ConfirmEditModal.IsOpen=true;
        }


        public void CloseConfirmModal(object sender, RoutedEventArgs e)
        {
            ConfirmEditModal.IsOpen = false;
        }

        public void confirmEdit(object sender, RoutedEventArgs e)
        {
            foreach (TrainLine trainLine in SystemData.trainsLines)
            {
                if (editTrainLine.Name.Equals(trainLine.Name))
                {
                    trainLine.stations = routeStations.ToList();
                    trainLine.durations = durations;
                    trainLine.prices = prices;
                }
            }
            CloseConfirmModal(sender, e);

            f.Content = new AdminRoutesPage(f);
        }


        public void OpenCreateModal(object sender, RoutedEventArgs e)
        {
            ConfirmCreateModal.IsOpen = true;
        }


        public void CloseCreateModal(object sender, RoutedEventArgs e)
        {
            ConfirmCreateModal.IsOpen = false;
        }


        public void createTrainLine(object sender, RoutedEventArgs e)
        {
            if (createButton.Content.ToString() == "Kreiraj")
            {
                OpenCreateModal(sender, e);

            }
            else
            {
                OpenConfirmModal(sender, e);
            }

        }

        public void confirmCreateTrainLine(object sender, RoutedEventArgs e)
        {
            string name = TrainLineName.Text;
            TrainLine trainLine = new TrainLine(name, routeStations.ToList(), durations, new List<TimeTable>(), prices);
            SystemData.trainsLines.Add(trainLine);
            CloseConfirmModal(sender, e);
            f.Content = new AdminRoutesPage(f);
        }

        
    }
}
