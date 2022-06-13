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
            this.Date = r.date;
            this.StartTime = Service.getArrivalTime(r.startStation.Name, r.ride, r.ride.line);
            this.ArrivalTime = Service.getArrivalTime(r.endStation.Name, r.ride, r.ride.line);
            this.Price = Service.getTicketPrice(r.startStation.Name, r.endStation.Name,r.ride.isReverse, r.ride.line);
            this.Status = r.status;
            this.OriginStation = r.startStation.Name;
            this.ArrivalStation = r.endStation.Name;
            this.Line = r.ride.line.Name;
            this.Client = r.client.username;
        }

        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }   
        public double Price { get; set; }
        public ReservationStatus Status { get; set; }

        public string OriginStation { get; set; }

        public string ArrivalStation { get; set; }

        public string Line { get; set; }

        public string Client { get; set; }

    }
}
