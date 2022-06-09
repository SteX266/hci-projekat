using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class TimeTable
    {
        public Train train { get; set; }

        public TimeSpan starts { get; set; }

        public bool isReverse { get; set; }

        public TrainLine line { get; set; }

        public TimeTable(Train train, TimeSpan starts, bool isReverse, TrainLine line)
        {
            this.train = train;
            this.starts = starts;
            this.isReverse = isReverse;
            this.line = line;
        }

        public override bool Equals(object obj)
        {
            return obj is TimeTable table &&
                   EqualityComparer<Train>.Default.Equals(train, table.train) &&
                   starts.Equals(table.starts) &&
                   isReverse == table.isReverse &&
                   EqualityComparer<TrainLine>.Default.Equals(line, table.line);
        }
    }
}
