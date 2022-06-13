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
    /// Interaction logic for TrainsPage.xaml
    /// </summary>
    /// 

    public partial class TrainsPage : Page
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

        public ObservableCollection<TrainDTO> trainsToShow
        {
            get;
            set;
        }
        public TrainsPage()
        {
            InitializeComponent();
            List<Train> trains = SystemData.trains;
            DataContext = this;
            trainsToShow = new ObservableCollection<TrainDTO>();

            foreach (Train tr in trains)
            {
                trainsToShow.Add(new TrainDTO(tr));
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

        public void CreateTrain(object sender, RoutedEventArgs e)
        {
            try
            {
                Train t = new Train(Int32.Parse(VagonNumber.Text), Int32.Parse(RowNumber.Text), Int32.Parse(SeatsNumber.Text), TrainName.Text);
                SystemData.trains.Add(t);

                trainsToShow.Add(new TrainDTO(t));
                notifier.ShowSuccess($"Uspesno kreiran voz {t.name}.");

                CloseCreateModal(sender, e);
            }
            catch (Exception)
            {
                notifier.ShowError("Podaci forme nisu validni.");
            }
            
        }


        public void OpenEditModal(object sender, RoutedEventArgs e)
        {
            if (Trains.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali voz!");
            } else
            {
                EditModal.IsOpen = true;
                TrainDTO train = (TrainDTO)Trains.SelectedItem;
                string trainName = train.Naziv;
                ETrainName.Text = train.Naziv;
                EVagonNumber.Text = train.BrojVagona.ToString();
                ERowNumber.Text = train.BrojRedova.ToString();
                ESeatsNumber.Text = train.BrojSedista.ToString();
            }
            
        }

        public void CloseEditModal(object sender, RoutedEventArgs e)
        {
            EditModal.IsOpen = false;
        }

        public void EditTrain(object sender, RoutedEventArgs e)
        {
            try
            {
                TrainDTO train = (TrainDTO)Trains.SelectedItem;
                foreach (TrainDTO t in trainsToShow)
                {
                    if (train.Naziv.Equals(t.Naziv))
                    {
                        t.BrojVagona = Int32.Parse(EVagonNumber.Text);
                        t.BrojSedista = Int32.Parse(ESeatsNumber.Text);
                        t.BrojRedova = Int32.Parse(ERowNumber.Text);
                    }
                }
                foreach (Train t in SystemData.trains)
                {
                    if (t.name.Equals(train.Naziv))
                    {
                        t.numberOfWagons = Int32.Parse(EVagonNumber.Text);
                        t.numberOfRowsInWagon = Int32.Parse(ERowNumber.Text);
                        t.numberOfSeatsPerRow = Int32.Parse(ESeatsNumber.Text);
                    }
                }
                CloseEditModal(sender, e);
                notifier.ShowSuccess($"Uspesno azuriran voz {train.Naziv}.");
            }
            catch (Exception)
            {
                notifier.ShowError("Uneti podaci nisu validni!");
            }
            
        }

        public void OpenDeleteModal(object sender, RoutedEventArgs e)
        {
            if (Trains.SelectedIndex == -1)
            {
                notifier.ShowError("Niste izabrali voz!");
            } else
            {
                DeleteModal.IsOpen = true;
            }
            
        }

        public void CloseDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = false;
        }
        public void DeleteTrain(object sender, RoutedEventArgs e)
        {
            TrainDTO train = (TrainDTO)Trains.SelectedItem;
            trainsToShow.Remove(train);
            SystemData.deleteTrainByName(train.Naziv);
            CloseDeleteModal(sender, e);
            notifier.ShowSuccess($"Uspesno izbrisan voz {train.Naziv}.");
            
        }
    }
}
