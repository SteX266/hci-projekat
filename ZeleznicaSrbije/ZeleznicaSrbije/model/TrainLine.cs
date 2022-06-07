using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class TrainLine
    {

        private List<string> stations { get; set; }

        private Dictionary<string, TimeSpan> durations { get; set; }

        public TrainLine(List<string> stations, Dictionary<string, TimeSpan> durations)
        {
            this.stations = stations;
            this.durations = durations;
        }
    }
}
