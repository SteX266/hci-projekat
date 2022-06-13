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
    /// Interaction logic for AdminTimeTablePage.xaml
    /// </summary>
    public partial class AdminTimeTablePage : Page
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

        RideDTO rideToEdit;
        public ObservableCollection<RideDTO> routes
        {
            get;
            set;
        }
        public AdminTimeTablePage()
        {


            InitializeComponent();
            DataContext = this;

            List<TrainLine> lines = SystemData.trainsLines;
            List<string>lineStrings = new List<string>();
            foreach (TrainLine line in lines)
            {
                lineStrings.Add(line.Name);
            }
            LinePicker.ItemsSource = lineStrings;
            EditLinePicker.ItemsSource = lineStrings;

            List<string> time = new List<string> {"12:00", "15:00", "17:00" };
            TimePicker.ItemsSource = time;
            EditTimePicker.ItemsSource = time;

            List<Train> trains = SystemData.trains;
            List<string> trainStrings = new List<string>();

            foreach(Train train in trains)
            {
                trainStrings.Add(train.name);
            }

            TrainPicker.ItemsSource = trainStrings;
            EditTrainPicker.ItemsSource = trainStrings;

            routes = new ObservableCollection<RideDTO>();



            List<TimeTable> timeTables = SystemData.timeTables;



            foreach (TimeTable t in timeTables)
            {
                if (t.isReverse)
                {
                    TimeSpan end = Service.getArrivalTime(t.line.stations.First().Name, t, t.line);
                    double price = Service.getTicketPrice(t.line.stations.Last().Name, t.line.stations.First().Name, t.isReverse, t.line);
                    routes.Add(new RideDTO(t.line.stations.Last().Name, t.line.stations.First().Name, t.starts, end, price, t.line.Name, t));
                }
                else
                {
                    TimeSpan end = Service.getArrivalTime(t.line.stations.Last().Name, t, t.line);
                    double price = Service.getTicketPrice(t.line.stations.First().Name, t.line.stations.Last().Name, t.isReverse, t.line);
                    routes.Add(new RideDTO(t.line.stations.First().Name, t.line.stations.Last().Name, t.starts, end, price, t.line.Name, t));
                }

            }
        }
        public void OpenCreateModal(object sender, RoutedEventArgs e)
        {
            CreateModal.IsOpen = true;
        }

        public void CloseCreateModal(object sender, RoutedEventArgs e)
        {
            CreateModal.IsOpen = false;
        }

        public void CreateTimetable(object sender, RoutedEventArgs e)
        {
            try
            {
                string trainName = TrainPicker.SelectedItem.ToString();

                string line = LinePicker.SelectedItem.ToString();
                string time = TimePicker.SelectedItem.ToString();
                bool isReverse = Reverse.IsChecked.Value;

                string[] tokens = time.Split(':');
                int hours = Int32.Parse(tokens[0]);
                int minutes = Int32.Parse(tokens[1]);

                TimeSpan startTime = new TimeSpan(hours, minutes, 0);

                TrainLine trainLine = SystemData.getTrainLineByName(line);
                Train train = SystemData.getTrainByName(trainName);

                TimeTable t = new TimeTable(train, startTime, isReverse, trainLine);
                SystemData.timeTables.Add(t);



                if (t.isReverse)
                {
                    TimeSpan end = Service.getArrivalTime(t.line.stations.First().Name, t, t.line);
                    double price = Service.getTicketPrice(t.line.stations.Last().Name, t.line.stations.First().Name, t.isReverse, t.line);
                    routes.Add(new RideDTO(t.line.stations.Last().Name, t.line.stations.First().Name, t.starts, end, price, t.line.Name, t));
                }
                else
                {
                    TimeSpan end = Service.getArrivalTime(t.line.stations.Last().Name, t, t.line);
                    double price = Service.getTicketPrice(t.line.stations.First().Name, t.line.stations.Last().Name, t.isReverse, t.line);
                    routes.Add(new RideDTO(t.line.stations.First().Name, t.line.stations.Last().Name, t.starts, end, price, t.line.Name, t));
                }
                CloseCreateModal(sender, e);
                notifier.ShowSuccess("Uspesno kreiran red voznje.");
            }
            catch (Exception)
            {
                notifier.ShowError("Niste popunili sva polja");
            }
            
        }

        public void OpenEditModal(object sender, RoutedEventArgs e)
        {
            if(TimeTables.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali nijedan red voznje!");
            } else
            {
                EditModal.IsOpen = true;
                RideDTO ride = (RideDTO)TimeTables.SelectedItem;

                TimeTable timeTable = SystemData.findTimeTable(ride);

                EditTrainPicker.Text = timeTable.train.name;
                EditLinePicker.Text = timeTable.line.Name;
                EditTimePicker.Text = timeTable.starts.ToString(@"hh\:mm");
            }
        }

        public void CloseEditModal(object sender, RoutedEventArgs e)
        {
            EditModal.IsOpen = false;
        }

        public void EditTimetable(object sender, RoutedEventArgs e)
        {
            RideDTO ride = (RideDTO)TimeTables.SelectedItem;
            

            rideToEdit = (RideDTO)TimeTables.SelectedItem;

            TimeTable timeTable = SystemData.findTimeTable(ride);

            string originStation="";
            string destination="";



            foreach(TimeTable tt in SystemData.timeTables)
            {
                if (tt.line.Name == rideToEdit.Linija && tt.starts == rideToEdit.Polazak)
                {
                    if (EditLinePicker.SelectedIndex != -1)
                    {
                        tt.line = SystemData.getTrainLineByName(EditLinePicker.SelectedItem.ToString());
                        originStation = tt.line.stations.First().Name;
                        destination = tt.line.stations.Last().Name;
                    }
                    if (EditTimePicker.SelectedIndex != -1)
                    {
                        string[] tokens = EditTimePicker.SelectedItem.ToString().Split(':');
                        int hours = Int32.Parse(tokens[0]);
                        int minutes = Int32.Parse(tokens[1]);

                        TimeSpan startTime = new TimeSpan(hours, minutes, 0);
                        tt.starts = startTime;
                    }
                    if (EditTrainPicker.SelectedIndex != -1)
                    {
                        tt.train = SystemData.getTrainByName(EditTrainPicker.SelectedItem.ToString());
                    }
                }
            }



            foreach (RideDTO r in routes)
            {
                if (rideToEdit.Linija == r.Linija && r.Polazak == rideToEdit.Polazak)
                {
                    if (EditLinePicker.SelectedIndex != -1)
                    {
                        r.Linija = EditLinePicker.SelectedItem.ToString();
                        r.Polaziste = originStation;
                        r.Odrediste = destination;
                    }
                    if (EditTimePicker.SelectedIndex != -1)
                    {

                        string[] tokens = EditTimePicker.SelectedItem.ToString().Split(':');
                        int hours = Int32.Parse(tokens[0]);
                        int minutes = Int32.Parse(tokens[1]);

                        TimeSpan startTime = new TimeSpan(hours, minutes, 0);
                        r.Polazak = startTime;
                        r.Dolazak = Service.getArrivalTime(ride.Odrediste, timeTable, timeTable.line);
                    }
                }
            }
            EditModal.IsOpen = false;
            notifier.ShowSuccess("Uspesno azuriran red voznje.");
        }

        public void OpenDeleteModal(object sender, RoutedEventArgs e)
        {
            if(TimeTables.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali nijedan red voznje!");
            } else
            {
                DeleteModal.IsOpen = true;
            }
        }

        public void CloseDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = false;
        }

        public void DeleteTimetable(object sender, RoutedEventArgs e)
        {
            RideDTO ride = (RideDTO)TimeTables.SelectedItem;
            routes.Remove(ride);
            SystemData.deleteTimeTable(ride);
            CloseDeleteModal(sender, e);
            notifier.ShowSuccess("Uspesno izbrisan red voznje.");
        }

    }
}
