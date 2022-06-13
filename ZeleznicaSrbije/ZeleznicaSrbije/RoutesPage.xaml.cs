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
using Microsoft.Maps.MapControl.WPF;
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for LinesPage.xaml
    /// </summary>
    public partial class RoutesPage : Page
    {

        List<Pushpin> pushpins = new List<Pushpin>();
        List<MapPolyline> polylines = new List<MapPolyline>();
        public RoutesPage()
        {
            InitializeComponent();

            List<TrainLine> trainLines = SystemData.trainsLines;
            List<string> lineStrings = new List<string>();

            foreach (TrainLine line in trainLines)
            {
                lineStrings.Add(line.Name);
            }
            lineStrings.Add("Sve linije");

            RoutePicker.ItemsSource = lineStrings;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (polylines.Count > 0)
            {
                foreach(MapPolyline line in polylines)
                {
                    MainMap.Children.Remove(line);
                }
                polylines = new List<MapPolyline>();
            }
            if (pushpins.Count > 0)
            {
                foreach (Pushpin pin in pushpins)
                {
                    MainMap.Children.Remove(pin);
                }
                pushpins = new List<Pushpin>();
            }

            string lineName = RoutePicker.SelectedItem.ToString();

            if (lineName == "Sve linije")
            {
                foreach(TrainLine line in SystemData.trainsLines)
                {
                    addPins(line.stations);
                    connectPins(line);
                }
            }

            else
            {
                TrainLine line = SystemData.getTrainLineByName(lineName);
                addPins(line.stations);
                connectPins(line);
            }
            

        }

        private void connectPins(TrainLine line)
        {
            MapPolyline polyLine = new MapPolyline()
            { 
                Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0)),
                Locations = new LocationCollection()
            };
            foreach (Station station in line.stations)
            {
                polyLine.Locations.Add(station.Location);
            }
            polylines.Add(polyLine);
            MainMap.Children.Add(polyLine);
        }

        private void addPins(List<Station> stations)
        {
            List<Pushpin> pins = new List<Pushpin>();

            foreach (Station station in stations)
            {
                Pushpin pin = new Pushpin
                {
                    Location = station.Location,
                    Content = station.Name
                };
                pins.Add(pin);
                pushpins.Add(pin);
                MainMap.Children.Add(pin);
            }
        }
    }
}
