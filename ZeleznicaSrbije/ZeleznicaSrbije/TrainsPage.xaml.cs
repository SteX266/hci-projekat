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
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    /// <summary>
    /// Interaction logic for TrainsPage.xaml
    /// </summary>
    public partial class TrainsPage : Page
    {
        public TrainsPage()
        {
            InitializeComponent();

            List<Train> trains = SystemData.trains;

            List<TrainDTO> trainsToShow = new List<TrainDTO>();
            foreach (Train tr in trains)
            {
                trainsToShow.Add(new TrainDTO(tr));
            }   

            Trains.ItemsSource = trainsToShow;
        }
    }
}
