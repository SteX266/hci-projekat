using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class Station
    {   
        public string Name { get; set; }    
        public int X { get; set; }
        public int Y { get; set; }

        public Station(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }
    }
}
