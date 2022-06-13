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
    /// Interaction logic for AdminRoutesPage.xaml
    /// </summary>
    public partial class AdminRoutesPage : Page
    {
        Frame f;

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

        public ObservableCollection<TrainLineDTO> allTrainLines
        {
            get;
            set;
        }
        public AdminRoutesPage(Frame f)
        {
            InitializeComponent();
            this.f = f;

            DataContext = this;

            allTrainLines = new ObservableCollection<TrainLineDTO>();

            foreach (TrainLine t in SystemData.trainsLines)
            {
                double price = Service.getTicketPrice(t.stations.First().Name, t.stations.Last().Name, false, t);
                allTrainLines.Add(new TrainLineDTO(t.Name, t.stations.First().Name,t.stations.Last().Name, price));
            }
        }

        public void NavigateToCreate(object sender, RoutedEventArgs e)
        {
            f.Content = new CreateRoutePage(f);
        }

        public void NavigateToEdit(object sender, RoutedEventArgs e)
        {

            if (trainLines.SelectedIndex != -1)
            {
                int trainLineId = trainLines.SelectedIndex;

                TrainLine line = SystemData.trainsLines.ElementAt(trainLineId);


                f.Content = new CreateRoutePage(line, f);
            } else
            {
                notifier.ShowError("Niste izabrali nijednu liniju!");
            }

        }

        public void OpenDeleteModal(object sender, RoutedEventArgs e)
        {
            if(trainLines.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali nijednu liniju!");
            } else
            {
                DeleteModal.IsOpen = true;
            }
        }
        public void CloseDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = false;
        }

        public void DeleteRoute(object sender, RoutedEventArgs e)
        {
            if (trainLines.SelectedIndex != -1)
            {
                int trainLineIndex = trainLines.SelectedIndex;
                TrainLine trainLine = SystemData.trainsLines.ElementAt(trainLineIndex);

                foreach(TrainLineDTO tl in allTrainLines)
                {
                    if (tl.Name.Equals(trainLine.Name))
                    {
                        allTrainLines.Remove(tl);
                        break;
                    }
                }

                SystemData.trainsLines.Remove(trainLine);

            }



            CloseDeleteModal(sender, e);
        }

        public void editTrainLine(object sender, RoutedEventArgs e)
        {

        }
        public void deleteTrainLine(object sender, RoutedEventArgs e)
        {

        }


    }
}
