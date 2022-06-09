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
    /// Interaction logic for TicketsPage.xaml
    /// </summary>
    public partial class TicketsPage : Page
    {

        List<Reservation> reservationList = ((Client)SystemData.currentUser).reservations;

        public TicketsPage()
        {
            InitializeComponent();
            OriginPicker.ItemsSource = Service.getStationNames();
            DestinationPicker.ItemsSource = Service.getStationNames();
            StatusPicker.ItemsSource = new List<String> { "Rezervisana", "Otkazana", "Istekla", "Kupljena" };

            List<ReservationDTO> reservationDTOs = new List<ReservationDTO>();

            List<string> stationNames = new List<string>(Service.getStationNames());
            stationNames.Insert(0,"Sve stanice");

            OriginPicker.ItemsSource = stationNames;
            
            DestinationPicker.ItemsSource = stationNames;

            List<string> statuses = new List<string> { "Svi statusi","Otkazana", "Istekla", "Rezervisana" };
            StatusPicker.ItemsSource = statuses;

            OriginPicker.SelectedIndex = 0;
            DestinationPicker.SelectedIndex = 0;
            StatusPicker.SelectedIndex = 0; 


            foreach(Reservation r in reservationList)
            {
                ReservationDTO reservationDTO = new ReservationDTO(r);
                reservationDTOs.Add(reservationDTO);
            }

            reservationsTable.ItemsSource = reservationDTOs;    
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<ReservationDTO> reservationDTOs = new List<ReservationDTO>();
            string origin = OriginPicker.SelectedItem.ToString();
            string destination = DestinationPicker.SelectedItem.ToString();
            string status = StatusPicker.SelectedItem.ToString();

            foreach(Reservation r in reservationList)
            {
                if (r.startStation.Name.Contains(origin) || origin.Equals("Sve stanice"))
                {
                    if (r.endStation.Name.Contains(destination) || destination.Equals("Sve stanice"))
                    {
                        if (r.status.ToString().ToLower().Equals(status.ToLower()) || status.Equals("Svi statusi"))
                        {
                            reservationDTOs.Add(new ReservationDTO(r));
                        }
                    }
                }
            }
            reservationsTable.ItemsSource = reservationDTOs;

        }
    }
}
