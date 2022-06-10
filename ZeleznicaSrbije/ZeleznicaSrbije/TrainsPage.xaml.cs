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
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for TrainsPage.xaml
    /// </summary>
    public partial class TrainsPage : Page
    {
        public ObservableCollection<TrainDTO> trainsToShow
        {
            get;
            set;
        }
        public TrainsPage()
        {
            InitializeComponent();
            Trace.WriteLine("ALOOO");
            List<Train> trains = SystemData.trains;
            DataContext = this;
            trainsToShow = new ObservableCollection<TrainDTO>();

            foreach (Train tr in trains)
            {
                Trace.WriteLine("ALOOO");
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
            Train t = new Train(Int32.Parse(VagonNumber.Text), Int32.Parse(RowNumber.Text), Int32.Parse(SeatsNumber.Text), TrainName.Text);
            SystemData.trains.Add(t);

            trainsToShow.Add(new TrainDTO(t));
            CloseCreateModal(sender, e);
        }


        public void OpenEditModal(object sender, RoutedEventArgs e)
        {
            EditModal.IsOpen = true;
            TrainDTO train = (TrainDTO)Trains.SelectedItem;
            string trainName = train.Naziv;

            ETrainName.Text = train.Naziv;
            EVagonNumber.Text = train.BrojVagona.ToString();
            ERowNumber.Text = train.BrojRedova.ToString();
            ESeatsNumber.Text = train.BrojSedista.ToString();
        }

        public void CloseEditModal(object sender, RoutedEventArgs e)
        {
            EditModal.IsOpen = false;
        }

        public void EditTrain(object sender, RoutedEventArgs e)
        {
            TrainDTO train = (TrainDTO) Trains.SelectedItem;
            foreach(TrainDTO t in trainsToShow)
            {
                if (train.Naziv.Equals(t.Naziv))
                {
                    t.BrojVagona = Int32.Parse(EVagonNumber.Text);
                    t.BrojSedista = Int32.Parse(ESeatsNumber.Text);
                    t.BrojRedova = Int32.Parse(ERowNumber.Text);
                }
            }
            foreach(Train t in SystemData.trains)
            {
                if (t.name.Equals(train.Naziv))
                {
                    t.numberOfWagons = Int32.Parse(EVagonNumber.Text);
                    t.numberOfRowsInWagon = Int32.Parse(ERowNumber.Text);
                    t.numberOfSeatsPerRow = Int32.Parse(ESeatsNumber.Text);
                }
            }
            CloseEditModal(sender, e);

        }

        public void OpenDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = true;


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
        }
    }
}
