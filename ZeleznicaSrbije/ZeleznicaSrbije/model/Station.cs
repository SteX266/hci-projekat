using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;

namespace ZeleznicaSrbije.model
{
    public class Station
    {   
        public string Name { get; set; }

        public Location Location { get; set; }



        public Station(string name, Location location)
        {
            this.Name = name;
            this.Location = location;
        }
    }
}
