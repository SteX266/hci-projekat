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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
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
            if (RoutePicker.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali liniju!");
            }
            else
            {
                if (polylines.Count > 0)
                {
                    foreach (MapPolyline line in polylines)
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
                    foreach (TrainLine line in SystemData.trainsLines)
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
