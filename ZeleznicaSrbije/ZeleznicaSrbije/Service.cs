using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    public static class Service
    {

        public static List<TrainLine> getLinesBetweenLocations(string origin, string destination)
        {
            List<TrainLine> lines = new List<TrainLine>();
            bool hasOrigin = false;
            bool hasDestination = false;
            foreach (TrainLine t in SystemData.trainsLines)
            {
                hasOrigin = false;
                hasDestination = false;

                foreach (Station station in t.stations)
                {
                    if (station.Name == origin)
                    {
                        hasOrigin = true;
                    }
                    if (station.Name == destination)
                    {
                        hasDestination = true;
                    }
                }
                if (hasOrigin && hasDestination)
                {
                    lines.Add(t);
                }

            }
            return lines;
        }

        public static List<string> getEndStations(string origin)
        {
            List<string> locations = new List<string>();
            List<TrainLine> lines = new List<TrainLine>();
            Station station = getStationByName(origin);

            foreach(TrainLine trainLine in SystemData.trainsLines)
            {
                if (trainLine.stations.Contains(station))
                {
                    lines.Add(trainLine);
                }
            }
            foreach(TrainLine trainLine in lines)
            {
                if (!locations.Contains(trainLine.stations.First().Name)){

                    locations.Add(trainLine.stations.First().Name);

                }
                if (!locations.Contains(trainLine.stations.Last().Name)){
                    locations.Add(trainLine.stations.Last().Name);

                }
            }

            return locations;
        }

        public static List<RideDTO> getRidesBetweenDestinations(string origin, string destination)
        {
            List<TrainLine> trainLines = Service.getLinesBetweenLocations(origin, destination);
            List<RideDTO> rides = new List<RideDTO>();
            foreach (TrainLine line in trainLines)
            {

                bool isOriginFirst = isFirst(line, origin, destination);

                List<Station> stations = line.stations;


                foreach (TimeTable timeTable in line.timeTables)
                {
                    double price;
                    string startString;
                    string endString;
                    TimeSpan start;
                    TimeSpan end;
                    if ((isOriginFirst && timeTable.isReverse) || (!isOriginFirst && !timeTable.isReverse))
                    {
                        continue;
                    }

                    start = Service.getArrivalTime(origin, timeTable, line);
                    end = Service.getArrivalTime(destination, timeTable, line);
                    price = Service.getTicketPrice(origin, destination, timeTable.isReverse, line);

                   
                    string lineName = line.Name;
                    RideDTO ride = new RideDTO(origin, destination, start, end, price, lineName);
                    rides.Add(ride);

                }

            }

            return rides;
        }

        public static bool isFirst(TrainLine line, string origin, string destination)
        {
            foreach (Station station in line.stations)
            {
                if (station.Name == origin)
                {
                    return true;
                }
                if (station.Name == destination)
                {
                    return false;
                }
            }
            return false;
        }

        public static double getTicketPrice(string origin, string destination, bool isReverse, TrainLine line)
        {

            bool isPassed = false;
            double price = 0;
            if (!isReverse)
            {
                foreach (Station station in line.stations)
                {
                    if (isPassed)
                    {
                        price += line.prices[station];
                    }
                    if (station.Name.Equals(origin))
                    {
                        isPassed = true;
                    }
                    if (station.Name.Equals(destination))
                    {
                        break;
                    }
                }
            }
            else
            {
                foreach (Station station in line.stations.Reverse<Station>())
                {
                    if (station.Name.Equals(destination))
                    {
                        break;
                    }
                    if (station.Name.Equals(origin))
                    {
                        isPassed = true;
                    }
                    if (isPassed)
                    {
                        price += line.prices[station];
                    }

                }
            }
            return price;
        }

        public static TimeSpan getArrivalTime(string arrivalStation, TimeTable timeTable, TrainLine line)
        {
            TimeSpan start;
            if (!timeTable.isReverse)
            {
                start = timeTable.starts;

                foreach (Station station in line.stations)
                {

                    start = start.Add(line.durations[station]);
                    if (station.Name.Equals(arrivalStation))
                    {
                        break;
                    }
                }
            }
            else
            {
                start = timeTable.starts;
                foreach (Station station in line.stations.Reverse<Station>())
                {
                    if (station.Name.Equals(arrivalStation))
                    {
                        break;
                    }
                    start = start.Add(line.durations[station]);
                }

            }
            if (start.Days > 0)
            {
                start = start.Subtract(new TimeSpan(1, 0, 0, 0));
            }
            return start;
        }

        public static List<string> getStationNames()
        {
            List<string> names = new List<string>();
            foreach (Station station in SystemData.stations)
            {
                names.Add(station.Name);
            }
            return names;
        }
        public static List<int> emptySeatsInRide(TimeTable timeTable, DateTime date)
        {
            int seats = timeTable.train.numberOfWagons * timeTable.train.numberOfRowsInWagon * timeTable.train.numberOfSeatsPerRow;
            List<int> emptySeats = new List<int>();
            List<int> reservedSeatsInRide = new List<int>();
            foreach (Reservation r in SystemData.reservations)
            {
                if (r.ride.Equals(timeTable) && r.date.Equals(date) && r.status.Equals(ReservationStatus.REZERVISANA))
                {
                    reservedSeatsInRide.Add(r.seatNumber);
                }
            }
            for (int i = 1; i <= seats; i++)
            {
                if (!reservedSeatsInRide.Contains(i))
                {
                    emptySeats.Add(i);
                }
            }
            return emptySeats;
        }

        public static Station getStationByName(string name)
        {
            foreach(Station station in SystemData.stations)
            {
                if (station.Name.Equals(name)) { return station; }
            }
            return null;
        }

        public static bool areSeatsNextToEachoder(int x,int y ,TimeTable tl)
        {
            if(x != y+1 || x!= y - 1) { return false; }
            if(x%tl.train.numberOfSeatsPerRow != ( y % tl.train.numberOfSeatsPerRow + 1)) { return false; }
            return true;
        } 


        public static List<Reservation> reserveTickets(int numberOfTickets, Client client, TimeTable timeTable, DateTime date, string startStation, string destinationStation)
        {
            List<Reservation> reservations = new List<Reservation>();
            if (emptySeatsInRide(timeTable, date).Count < numberOfTickets)
            {
                return null;
            }
        
            bool canSeat = false;
            foreach(int seatNumber in emptySeatsInRide(timeTable, date))
            {
                bool breat = false;
                for (int i = 0; i < numberOfTickets; i++)
                {
                    if (!areSeatsNextToEachoder(seatNumber + i, seatNumber + i + 1, timeTable))
                    {
                        breat = true;
                        break;
                    }
                }
                if (!breat) {
                    canSeat = true;
                    for (int i = 0; i < numberOfTickets; i++)
                    {
                        Reservation r = new Reservation(client, timeTable, getStationByName(startStation), getStationByName(destinationStation), date, ReservationStatus.REZERVISANA,seatNumber+i);
                        reservations.Add(r);
                    }
                }
            }
            if (!canSeat)
            {

                for (int i = 0; i < numberOfTickets; i++)
                {
                    Reservation r = new Reservation(client, timeTable, getStationByName(startStation), getStationByName(destinationStation), date, ReservationStatus.REZERVISANA, emptySeatsInRide(timeTable, date)[i]);
                    reservations.Add(r);
                }
            }
            return reservations;
        }
    }
}
