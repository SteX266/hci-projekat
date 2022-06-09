using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class ReservationDTO
    {

        public ReservationDTO(Reservation r)
        {
            this.Datum = r.date;
            this.Polazak = SystemData.getArrivalTime(r.startStation.Name, r.ride, r.ride.line);
            this.Dolazak = SystemData.getArrivalTime(r.endStation.Name, r.ride, r.ride.line);
            this.Cena = SystemData.getTicketPrice(r.startStation.Name, r.endStation.Name,r.ride.isReverse, r.ride.line);
            this.Status = r.status;
            this.Polaziste = r.startStation.Name;
            this.Odrediste = r.endStation.Name;
            this.Linija = r.ride.line.Name;
        }

        public DateTime Datum { get; set; }
        public TimeSpan Polazak { get; set; }
        public TimeSpan Dolazak { get; set; }   
        public double Cena { get; set; }
        public ReservationStatus Status { get; set; }

        public string Polaziste { get; set; }

        public string Odrediste { get; set; }

        public string Linija { get; set; }

    }
}
