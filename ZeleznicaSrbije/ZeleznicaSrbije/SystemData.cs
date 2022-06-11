using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    public static class SystemData
    {
        public static List<Client> clients { get; set; }
        public static List<Admin> admins { get; set; }
        public static List<Reservation> reservations { get; set; }
        public static List<Train> trains { get; set; }
        public static List<TrainLine> trainsLines { get; set; }
        public static List<TimeTable> timeTables { get; set; }
        public static List<Station> stations { get; set; }

        public static User currentUser { get; set; }


        public static void setUser(User u)
        {
            currentUser = u;
        }

       


        public static void fillData()
        {
            clients = new List<Client>();
            Client client1 = new Client(1, "pera", "pera", new List<Reservation>());
            Client client2 = new Client(2, "Zumza", "pera", new List<Reservation>());
            Client client3 = new Client(3, "Esteban", "pera", new List<Reservation>());
            clients.Add(client1);
            clients.Add(client2);  
            clients.Add(client3);   


            admins = new List<Admin>();
            Admin admin1 = new Admin(4, "bubi", "bubisa");
            Admin admin2 = new Admin(5, "ficok", "pera");
            admins.Add(admin1);
            admins.Add(admin2);


            trains = new List<Train>();
            Train train1 = new Train(3,10,4,"Soko1");
            Train train2 = new Train(4, 12, 4, "Soko2");
            Train train3 = new Train(5, 10, 6, "Cira");
            Train train4 = new Train(6, 10, 6, "Cira2");
            trains.Add(train1);
            trains.Add(train2);
            trains.Add(train3);
            trains.Add(train4);

            stations = new List<Station>();
            Station stationNS = new Station("Novi Sad", 1,1);
            Station stationZR = new Station("Zrenjanin", 1, 1);
            Station stationKI = new Station("Kikinda", 1, 1);
            Station stationSU = new Station("Subotica", 1, 1);
            Station stationSO = new Station("Sombor", 1, 1);
            Station stationSM = new Station("Sremska Mitrovica", 1, 1);
            Station stationVS = new Station("Vrsac", 1, 1);
            Station stationPA = new Station("Pancevo", 1, 1);
            Station stationBG = new Station("Beograd", 1, 1);
            Station stationSD = new Station("Smederevo", 1, 1);
            Station stationSA = new Station("Sabac", 1, 1);
            Station stationLO= new Station("Loznica", 1, 1);
            Station stationCA = new Station("Cacak", 1, 1);
            Station stationKG = new Station("Kragujevac", 1, 1);
            Station stationKS = new Station("Krusevac", 1, 1);
            Station stationKV = new Station("Kraljevo", 1, 1);
            Station stationJA = new Station("Jagodina", 1, 1);
            Station stationNI = new Station("Nis", 1, 1);
            Station stationZA = new Station("Zajecar", 1, 1);
            Station stationVR = new Station("Vranje", 1, 1);
            stations.Add(stationVR);
            stations.Add(stationZA);
            stations.Add(stationNI);
            stations.Add(stationJA);
            stations.Add(stationKV);
            stations.Add(stationKS);
            stations.Add(stationKG);
            stations.Add(stationCA);
            stations.Add(stationLO);
            stations.Add(stationSA);
            stations.Add(stationSD);
            stations.Add(stationBG);
            stations.Add(stationSM);
            stations.Add(stationSO);
            stations.Add(stationSU);
            stations.Add(stationZR);
            stations.Add(stationNS);
            stations.Add(stationPA);
            stations.Add(stationKI);
            stations.Add(stationVS);


            timeTables = new List<TimeTable>();
            TimeTable timeTable1 = new TimeTable(train1, new TimeSpan(0, 6, 30, 0), true, null);
            TimeTable timeTable2 = new TimeTable(train1, new TimeSpan(0, 9, 30, 0), false, null);
            TimeTable timeTable3 = new TimeTable(train1, new TimeSpan(0, 15, 00, 0), true, null);
            TimeTable timeTable4 = new TimeTable(train1, new TimeSpan(0, 7, 10, 0), false, null);
            TimeTable timeTable5 = new TimeTable(train1, new TimeSpan(0, 10, 00, 0), true, null);
            TimeTable timeTable6 = new TimeTable(train1, new TimeSpan(0, 14, 30, 0), false, null);
            TimeTable timeTable7 = new TimeTable(train1, new TimeSpan(0, 17, 00, 0), true, null);
            TimeTable timeTable8 = new TimeTable(train1, new TimeSpan(0, 6, 45, 0), false, null);
            TimeTable timeTable9 = new TimeTable(train1, new TimeSpan(0, 18, 30, 0), true, null);


            TimeTable timeTable10 = new TimeTable(train1, new TimeSpan(0, 4, 30, 0), false, null);
            TimeTable timeTable12 = new TimeTable(train1, new TimeSpan(0, 7, 30, 0), true, null);
            TimeTable timeTable13 = new TimeTable(train1, new TimeSpan(0, 10, 00, 0), false, null);
            TimeTable timeTable14 = new TimeTable(train1, new TimeSpan(0, 13, 10, 0), true, null);
            TimeTable timeTable15 = new TimeTable(train1, new TimeSpan(0, 15, 00, 0), false, null);
            TimeTable timeTable16 = new TimeTable(train1, new TimeSpan(0, 17, 30, 0), true, null);
            TimeTable timeTable17 = new TimeTable(train1, new TimeSpan(0, 18, 00, 0), false, null);
            TimeTable timeTable18 = new TimeTable(train1, new TimeSpan(0, 22, 45, 0), true, null);
            TimeTable timeTable19 = new TimeTable(train1, new TimeSpan(0, 21, 30, 0), false, null);
            timeTables.Add(timeTable9);
            timeTables.Add(timeTable8);
            timeTables.Add(timeTable7);
            timeTables.Add(timeTable6);
            timeTables.Add(timeTable5);
            timeTables.Add(timeTable4);
            timeTables.Add(timeTable3);
            timeTables.Add(timeTable2);
            timeTables.Add(timeTable1);
            timeTables.Add(timeTable10);
            timeTables.Add(timeTable12);
            timeTables.Add(timeTable13);
            timeTables.Add(timeTable14);
            timeTables.Add(timeTable15);
            timeTables.Add(timeTable16);
            timeTables.Add(timeTable17);
            timeTables.Add(timeTable18);
            timeTables.Add(timeTable19);



            trainsLines = new List<TrainLine>();
            List<Station> line1 = new List<Station> { stationSU, stationSO, stationNS, stationSM, stationSA, stationLO };
            Dictionary<Station, TimeSpan> durations1 = new Dictionary<Station, TimeSpan> {
                [stationSU] = new TimeSpan(0, 0, 0, 0),
                [stationSO] = new TimeSpan(0, 1, 0, 0),
                [stationNS] = new TimeSpan(0, 2, 20, 0),
                [stationSM] = new TimeSpan(0, 1, 25, 0),
                [stationSA] = new TimeSpan(0, 0, 40, 0),
                [stationLO] = new TimeSpan(0, 1, 0, 0)
            };
            Dictionary<Station, double> prices1 = new Dictionary<Station, double>
            {
                [stationSU] = 0,
                [stationSO] = 200,
                [stationNS] = 400,
                [stationSM] = 220,
                [stationSA] = 150,
                [stationLO] = 200
            };
            TrainLine tl1 = new TrainLine("SU-LO",line1,durations1, new List<TimeTable> { timeTable1,timeTable2,timeTable3, timeTable10, timeTable12, timeTable18}, prices1);
            timeTable1.line = tl1;
            timeTable2.line = tl1;
            timeTable3.line = tl1;
            timeTable10.line = tl1;
            timeTable12.line = tl1;
            timeTable18.line = tl1; 
            List<Station> line2 = new List<Station> { stationSU, stationKI, stationZR, stationVS, stationPA, stationBG };
            Dictionary<Station, TimeSpan> durations2 = new Dictionary<Station, TimeSpan>
            {
                [stationSU] = new TimeSpan(0, 0, 0, 0),
                [stationKI] = new TimeSpan(0, 1, 45, 0),
                [stationZR] = new TimeSpan(0, 1, 00, 0),
                [stationVS] = new TimeSpan(0, 1, 25, 0),
                [stationPA] = new TimeSpan(0, 0, 30, 0),
                [stationBG] = new TimeSpan(0, 0, 40, 0)
            };

            Dictionary<Station, double> prices2 = new Dictionary<Station, double>
            {
                [stationSU] = 0,
                [stationKI] = 360,
                [stationZR] = 200,
                [stationVS] = 245,
                [stationPA] = 100,
                [stationBG] = 140
            };


            TrainLine tl2= new TrainLine("SU-BG",line2, durations2,new List<TimeTable> { timeTable4,timeTable5,timeTable6,timeTable7, timeTable13, timeTable17},prices2);
            timeTable4.line = tl2;
            timeTable5.line = tl2;
            timeTable6.line = tl2;
            timeTable7.line = tl2;
            timeTable13.line = tl2;
            timeTable17.line = tl2;
            List<Station> line3 = new List<Station> { stationSU, stationNS, stationBG, stationSD, stationJA, stationNI,stationVR };
            Dictionary<Station, TimeSpan> durations3 = new Dictionary<Station, TimeSpan>
            {
                [stationSU] = new TimeSpan(0,0,0,0),
                [stationNS] = new TimeSpan(0, 2, 30, 0),
                [stationBG] = new TimeSpan(0, 1, 00, 0),
                [stationSD] = new TimeSpan(0, 1, 25, 0),
                [stationJA] = new TimeSpan(0, 2, 30, 0),
                [stationNI] = new TimeSpan(0, 2, 45, 0),
                [stationVR] = new TimeSpan(0, 2, 10, 0)
            };
            Dictionary<Station, double> prices3 = new Dictionary<Station, double>
            {
                [stationSU] = 0,
                [stationNS] = 500,
                [stationBG] = 200,
                [stationSD] = 250,
                [stationJA] = 500,
                [stationNI] = 530,
                [stationVR] = 520
            };
            TrainLine tl3 = new TrainLine("SU-VR",line3, durations3, new List<TimeTable> { timeTable8,timeTable9, timeTable14, timeTable15, timeTable16, timeTable19}, prices3);
            timeTable8.line = tl3;
            timeTable9.line = tl3;
            timeTable14.line = tl3;
            timeTable15.line = tl3;
            timeTable16.line = tl3;
            timeTable19.line = tl3;
            trainsLines.Add(tl1);
            trainsLines.Add(tl2);
            trainsLines.Add(tl3);


            reservations = new List<Reservation>();
            Reservation res1 = new Reservation(client1 ,timeTable3, stationNS, stationSU, new DateTime(), ReservationStatus.REZERVISANA,1);
            Reservation res2 = new Reservation(client1, timeTable4, stationSU, stationBG, new DateTime(), ReservationStatus.REZERVISANA,2);
            Reservation res3 = new Reservation(client1, timeTable4, stationSU, stationBG, new DateTime(), ReservationStatus.REZERVISANA,3);
            Reservation res4 = new Reservation(client2, timeTable5, stationSU, stationBG, new DateTime(), ReservationStatus.REZERVISANA,4);
            Reservation res5 = new Reservation(client2, timeTable6, stationSU, stationBG, new DateTime(), ReservationStatus.REZERVISANA,5);
            Reservation res6 = new Reservation(client2, timeTable7, stationSU, stationBG, new DateTime(), ReservationStatus.REZERVISANA,6);
            Reservation res7 = new Reservation(client2, timeTable8, stationSU, stationBG, new DateTime(), ReservationStatus.REZERVISANA,7);
            Reservation res8 = new Reservation(client3, timeTable5, stationSU, stationBG, new DateTime(), ReservationStatus.REZERVISANA,8);
            Reservation res9 = new Reservation(client3, timeTable9, stationSU, stationBG, new DateTime(), ReservationStatus.REZERVISANA,9);
            Reservation res10 = new Reservation(client3, timeTable1, stationSU, stationNS, new DateTime(), ReservationStatus.REZERVISANA,10);
            Reservation res11 = new Reservation(client3, timeTable4, stationSU, stationBG, new DateTime(), ReservationStatus.REZERVISANA,6);
            Reservation res12 = new Reservation(client1, timeTable5, stationBG, stationSU, new DateTime(), ReservationStatus.REZERVISANA,12);
            Reservation res13 = new Reservation(client1, timeTable6, stationSU, stationBG, new DateTime(), ReservationStatus.REZERVISANA,13);



            reservations.Add(res1);
            reservations.Add(res2);
            reservations.Add(res3);
            reservations.Add(res4);
            reservations.Add(res5);
            reservations.Add(res6);
            reservations.Add(res7);
            reservations.Add(res8);    
            reservations.Add(res9);
            reservations.Add(res10);
            reservations.Add(res11);
            reservations.Add(res12);
            reservations.Add(res13);

            client1.reservations.Add(res1);
            client1.reservations.Add(res2);
            client1.reservations.Add(res3);
            client1.reservations.Add(res12);
            client1.reservations.Add(res13);





        }

        internal static Train getTrainByName(string trainName)
        {
            foreach(Train t in trains)
            {
                if (t.name == trainName)
                {
                    return t;
                }
            }
            return null;
        }

        public static TrainLine getTrainLineByName(string line)
        {
            foreach(TrainLine trainLine in trainsLines)
            {
                if (trainLine.Name == line)
                {
                    return trainLine;
                }
            }
            return null;
        }

        internal static void deleteTimeTable(RideDTO ride)
        {
            foreach(TimeTable table in timeTables)
            {
                if (table.line.Name == ride.Linija && ride.Polazak == table.starts)
                {
                    timeTables.Remove(table);
                    break;
                }
            }
        }

        internal static void deleteTrainByName(string naziv)
        {
            foreach (Train train in trains)
            {
                if (train.name.Equals(naziv))
                {
                    trains.Remove(train);
                    break;
                }
            }
        }
    }
}
