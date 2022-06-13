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
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    /// 
    
    public partial class ReportPage : Page
    {
        List<Reservation> reservationList;

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

        ObservableCollection<ReservationDTO> reservationsToShow
        {

            get; set;
        }
        public ReportPage()
        {
            InitializeComponent();
            DataContext = this;
            reservationList = new List<Reservation>();
            reservationsToShow = new ObservableCollection<ReservationDTO>();

            List<string> trainLines = new List<string>();

            foreach (TrainLine tl in SystemData.trainsLines)
            {
                trainLines.Add(tl.Name);
            }

            LinePicker.ItemsSource = trainLines;


        }
        private void OpenLineChoiceModal(object sender, RoutedEventArgs e)
        {
            LineChoiceModal.IsOpen = true;
        }

        private void CloseLineChoiceModal(object sender, RoutedEventArgs e)
        {
            LineChoiceModal.IsOpen = false;
        }

        private void LineReport(object sender, RoutedEventArgs e)
        {
            if (LinePicker.SelectedIndex == -1)
            {
                notifier.ShowWarning("Niste izabrali nijednu liniju!");
            } else
            {
                reservationsToShow = new ObservableCollection<ReservationDTO>();
                string line = LinePicker.SelectedItem.ToString();

                foreach(Reservation r in SystemData.reservations)
                {
                    if(r.ride.line.Name.Equals(line))
                    {
                        reservationsToShow.Add(new ReservationDTO(r));
                    }
                }


                reservationsTable.ItemsSource = reservationsToShow;

                CloseLineChoiceModal(sender, e);
            }
        }

        private void MonthlyReport(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            reservationsToShow = new ObservableCollection<ReservationDTO>();
            foreach(Reservation r in SystemData.reservations)
            {
                if (DateTime.Compare(r.date.AddDays(31), now) > 0)
                {
                    Trace.WriteLine("Alo ba");
                    reservationList.Add(r);
                }
            }

            foreach(Reservation r in reservationList)
            {
                Trace.WriteLine("ALOOOOO");
                reservationsToShow.Add(new ReservationDTO(r));
            }

            reservationsTable.ItemsSource = reservationsToShow;
        }
    }
}
