using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class Train
    {
        public int numberOfSeats { get; set; }
        public string name { get; set; }

        public Train(int numberOfSeats, string name)
        {
            this.numberOfSeats = numberOfSeats;
            this.name = name;
        }
    }
}
