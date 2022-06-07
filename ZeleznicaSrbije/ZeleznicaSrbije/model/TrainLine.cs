using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class TrainLine
    {

        private List<Station> stations { get; set; }

        private Dictionary<Station, TimeSpan> durations { get; set; }

        private List<TimeTable> timeTables { get; set; }

        public TrainLine(List<Station> stations, Dictionary<Station, TimeSpan> durations, List<TimeTable> timeTables)
        {
            this.stations = stations;
            this.durations = durations;
            this.timeTables = timeTables;
        }
    }
}
