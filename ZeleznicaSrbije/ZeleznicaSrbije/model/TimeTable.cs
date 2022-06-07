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
        
        private List<TimeSpan> starts { get; set; }

        private List<TimeSpan> returns { get; set; }

        public TimeTable(Train train, List<TimeSpan> starts, List<TimeSpan> returns)
        {
            this.train = train;
            this.starts = starts;
            this.returns = returns;
        }
    }
}
