using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class Client : User
    {
        private List<Reservation> reservations { get; set; }

        public Client(int x, string user, string pass ,List<Reservation> r) : base(user, pass, x)
        {
            reservations = r;
        }
    }
}
