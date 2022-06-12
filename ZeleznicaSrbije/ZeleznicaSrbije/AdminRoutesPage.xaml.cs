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
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for AdminRoutesPage.xaml
    /// </summary>
    public partial class AdminRoutesPage : Page
    {
        Frame f;
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
            f.Content = new CreateRoutePage();
        }

        public void NavigateToEdit(object sender, RoutedEventArgs e)
        {

            if (trainLines.SelectedIndex != -1)
            {
                int trainLineId = trainLines.SelectedIndex;

                TrainLine line = SystemData.trainsLines.ElementAt(trainLineId);


                f.Content = new CreateRoutePage(line);
            }

        }

        public void OpenDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = true; 
        }
        public void CloseDeleteModal(object sender, RoutedEventArgs e)
        {
            DeleteModal.IsOpen = false;
        }

        public void DeleteRoute(object sender, RoutedEventArgs e)
        {
            // ovde ide kod za brisanje vozne linije
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
