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

        public Client(string user, string pass ,int x) : base(user, pass, x)
        {
        }
    }
}
