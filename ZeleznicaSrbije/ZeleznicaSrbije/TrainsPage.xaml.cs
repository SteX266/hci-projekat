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
            // ovde ide logika za kreiranje voza
        }


        public void OpenEditModal(object sender, RoutedEventArgs e)
        {
            EditModal.IsOpen = true;
        }

        public void CloseEditModal(object sender, RoutedEventArgs e)
        {
            EditModal.IsOpen = false;
        }

        public void EditTrain(object sender, RoutedEventArgs e)
        {
            // ovde ide logika za azuriranje voza
        }

        public void OpenDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = true;
            trainsToShow.RemoveAt(0);

        }

        public void CloseDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = false;
        }
        public void DeleteTrain(object sender, RoutedEventArgs e)
        {
            // ovde ide logika za brisanje voza
        }
    }
}
