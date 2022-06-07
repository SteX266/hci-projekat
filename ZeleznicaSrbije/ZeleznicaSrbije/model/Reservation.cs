using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class Reservation
    {
        private  Client client { get; set; }
        private TimeTable ride { get; set; }
        
        private DateTime date { get; set; }

        private bool isBought { get; set; }

        public Reservation(Client client, TimeTable ride, DateTime date, bool isBought)
        {
            this.client = client;
            this.ride = ride;
            this.date = date;
            this.isBought = isBought;
        }
    }
}
