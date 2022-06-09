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
    /// Interaction logic for AdminTimeTablePage.xaml
    /// </summary>
    public partial class AdminTimeTablePage : Page
    {
        public AdminTimeTablePage()
        {
            InitializeComponent();

            List<RideDTO> routes = new List<RideDTO>();
            List<TimeTable> timeTables = SystemData.timeTables;

            foreach (TimeTable t in timeTables)
            {
                if (t.isReverse)
                {
                    TimeSpan end = Service.getArrivalTime(t.line.stations.First().Name, t, t.line);
                    double price = Service.getTicketPrice(t.line.stations.Last().Name, t.line.stations.First().Name, t.isReverse, t.line);
                    routes.Add(new RideDTO(t.line.stations.Last().Name, t.line.stations.First().Name, t.starts, end, price, t.line.Name));
                }
                else
                {
                    TimeSpan end = Service.getArrivalTime(t.line.stations.Last().Name, t, t.line);
                    double price = Service.getTicketPrice(t.line.stations.First().Name, t.line.stations.Last().Name, t.isReverse, t.line);
                    routes.Add(new RideDTO(t.line.stations.First().Name, t.line.stations.Last().Name, t.starts, end, price, t.line.Name));
                }

            }
            TimeTables.ItemsSource = routes;
        }
    }
}
