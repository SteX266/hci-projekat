using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class Station
    {
        private string name;
        private int x;
        private int y;

        public Station(string name, int x, int y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }
    }
}
