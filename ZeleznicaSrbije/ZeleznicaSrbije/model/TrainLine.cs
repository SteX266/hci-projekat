using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class TrainLine
    {
        public string Name { get; set; }
        public List<Station> stations { get; set; }

        public Dictionary<Station, TimeSpan> durations { get; set; }

        public Dictionary<Station, double> prices { get; set; }

        public List<TimeTable> timeTables { get; set; }

        public TrainLine(string name,List<Station> stations, Dictionary<Station, TimeSpan> durations, List<TimeTable> timeTables, Dictionary<Station, double>  prices)
        {
            this.Name = name;
            this.stations = stations;
            this.durations = durations;
            this.timeTables = timeTables;
            this.prices = prices;
        }

        public override bool Equals(object obj)
        {
            return obj is TrainLine line &&
                   Name == line.Name &&
                   EqualityComparer<List<Station>>.Default.Equals(stations, line.stations) &&
                   EqualityComparer<Dictionary<Station, TimeSpan>>.Default.Equals(durations, line.durations) &&
                   EqualityComparer<Dictionary<Station, double>>.Default.Equals(prices, line.prices) &&
                   EqualityComparer<List<TimeTable>>.Default.Equals(timeTables, line.timeTables);
        }
    }
}
