using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class TimeTable
    {
        private Train train { get; set; }
        
        private TimeSpan starts { get; set; }

        private TimeSpan returns { get; set; }


        public TimeTable(Train train, TimeSpan starts, TimeSpan returns)
        {
            this.train = train;
            this.starts = starts;
            this.returns = returns;
        }
    }
}
