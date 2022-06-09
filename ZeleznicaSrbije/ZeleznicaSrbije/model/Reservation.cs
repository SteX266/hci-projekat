using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public enum ReservationStatus
    {
        OTKAZANA, ISTEKLA, REZERVISANA

    }
    public class Reservation
    {
        public Reservation(Client client, TimeTable ride, Station startStation, Station endStation,  DateTime date, ReservationStatus status,int seat)
        {
            this.client = client;
            this.ride = ride;
            this.startStation = startStation;
            this.endStation = endStation;
            this.date = date;
            this.status = status;
            this.seatNumber = seat;
        }

        public Client client { get; set; }
        public TimeTable ride { get; set; }
        public Station startStation { get; set; }
        public Station endStation { get; set; }

        public DateTime date { get; set; }

        public ReservationStatus status { get; set; }

        public int seatNumber { get; set; }


    }
}
