using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class Train
    {
        public int numberOfWagons { get; set; }
        public int numberOfRowsInWagon { get; set; }

        public int numberOfSeatsPerRow { get; set; }

        public string name { get; set; }

        public Train(int numberOfWagons, int numberOfRowsInWagons, int numberOfSeatsPerRow, string name)
        {
            this.numberOfWagons = numberOfWagons;
            this.numberOfRowsInWagon = numberOfRowsInWagons;
            this.numberOfSeatsPerRow = numberOfSeatsPerRow;
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Train train &&
                   numberOfWagons == train.numberOfWagons &&
                   numberOfRowsInWagon == train.numberOfRowsInWagon &&
                   numberOfSeatsPerRow == train.numberOfSeatsPerRow &&
                   name == train.name;
        }
    }
}
