using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeleznicaSrbije.model;

namespace ZeleznicaSrbije
{
    public class SystemData
    {
        private List<Client> clients { get; set; }
        private List<Admin> admins { get; set; }
        private List<Reservation> reservations { get; set; }
        private List<Train> trains { get; set; }
        private List<TrainLine> trainsLines { get; set; }
        private List<TimeTable> timeTables { get; set; }
        private List<Station> stations { get; set; }


        public SystemData()
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
            Train train1 = new Train(45, "Soko1");
            Train train2 = new Train(85, "Soko2");
            Train train3 = new Train(150, "Cira");
            Train train4 = new Train(100, "Cira2");
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
            TimeTable timeTable1 = new TimeTable(train1, new TimeSpan(0, 6, 30, 0), new TimeSpan(0, 13, 30, 0));
            TimeTable timeTable2 = new TimeTable(train1, new TimeSpan(0, 9, 30, 0), new TimeSpan(0, 26, 30, 0));
            TimeTable timeTable3 = new TimeTable(train1, new TimeSpan(0, 15, 00, 0), new TimeSpan(0, 21, 45, 0));
            TimeTable timeTable4 = new TimeTable(train1, new TimeSpan(0, 7, 10, 0), new TimeSpan(0, 12, 30, 0));
            TimeTable timeTable5 = new TimeTable(train1, new TimeSpan(0, 10, 00, 0), new TimeSpan(0, 15, 00, 0));
            TimeTable timeTable6 = new TimeTable(train1, new TimeSpan(0, 14, 30, 0), new TimeSpan(0, 19, 35, 0));
            TimeTable timeTable7 = new TimeTable(train1, new TimeSpan(0, 17, 00, 0), new TimeSpan(0, 22, 10, 0));
            TimeTable timeTable8 = new TimeTable(train1, new TimeSpan(0, 6, 45, 0), new TimeSpan(0, 17, 00, 0));
            TimeTable timeTable9 = new TimeTable(train1, new TimeSpan(0, 18, 30, 0), new TimeSpan(0, 5, 30, 0));
            timeTables.Add(timeTable9);
            timeTables.Add(timeTable8);
            timeTables.Add(timeTable7);
            timeTables.Add(timeTable6);
            timeTables.Add(timeTable5);
            timeTables.Add(timeTable4);
            timeTables.Add(timeTable3);
            timeTables.Add(timeTable2);
            timeTables.Add(timeTable1);


            trainsLines = new List<TrainLine>();
            List<Station> line1 = new List<Station> { stationSU, stationSO, stationNS, stationSM, stationSA, stationLO };
            Dictionary<Station, TimeSpan> durations1 = new Dictionary<Station, TimeSpan> {
                [stationSO] = new TimeSpan(0, 1, 0, 0),
                [stationNS] = new TimeSpan(0, 2, 20, 0),
                [stationSM] = new TimeSpan(0, 1, 25, 0),
                [stationSA] = new TimeSpan(0, 0, 40, 0),
                [stationLO] = new TimeSpan(0, 1, 0, 0)
            };
            TrainLine tl1 = new TrainLine(line1,durations1, new List<TimeTable> { timeTable1,timeTable2,timeTable3});
            
            List<Station> line2 = new List<Station> { stationSU, stationKI, stationZR, stationVS, stationPA, stationBG };
            Dictionary<Station, TimeSpan> durations2 = new Dictionary<Station, TimeSpan>
            {
                [stationKI] = new TimeSpan(0, 1, 45, 0),
                [stationZR] = new TimeSpan(0, 1, 00, 0),
                [stationVS] = new TimeSpan(0, 1, 25, 0),
                [stationPA] = new TimeSpan(0, 0, 30, 0),
                [stationBG] = new TimeSpan(0, 0, 40, 0)
            };
            TrainLine tl2= new TrainLine(line2, durations2,new List<TimeTable> { timeTable4,timeTable5,timeTable6,timeTable7});

            List<Station> line3 = new List<Station> { stationSU, stationNS, stationBG, stationSD, stationJA, stationNI,stationVR };
            Dictionary<Station, TimeSpan> durations3 = new Dictionary<Station, TimeSpan>
            {
                [stationNS] = new TimeSpan(0, 2, 30, 0),
                [stationBG] = new TimeSpan(0, 1, 00, 0),
                [stationSD] = new TimeSpan(0, 1, 25, 0),
                [stationJA] = new TimeSpan(0, 2, 30, 0),
                [stationNI] = new TimeSpan(0, 2, 45, 0),
                [stationVR] = new TimeSpan(0, 2, 10, 0)
            };
            TrainLine tl3 = new TrainLine(line3, durations3, new List<TimeTable> { timeTable8,timeTable9});

            trainsLines.Add(tl1);
            trainsLines.Add(tl2);
            trainsLines.Add(tl3);


            reservations = new List<Reservation>();
            Reservation res1 = new Reservation(client1 ,timeTable3, new DateTime(), true);
            Reservation res2 = new Reservation(client1, timeTable4, new DateTime(), false);
            Reservation res3 = new Reservation(client1, timeTable4, new DateTime(), true);
            Reservation res4 = new Reservation(client2, timeTable5, new DateTime(), true);
            Reservation res5 = new Reservation(client2, timeTable6, new DateTime(), false);
            Reservation res6 = new Reservation(client2, timeTable7, new DateTime(), true);
            Reservation res7 = new Reservation(client2, timeTable8, new DateTime(), true);
            Reservation res8 = new Reservation(client3, timeTable5, new DateTime(), false);
            Reservation res9 = new Reservation(client3, timeTable9, new DateTime(), true);
            Reservation res10 = new Reservation(client3, timeTable1, new DateTime(), false);
            Reservation res11 = new Reservation(client3, timeTable4, new DateTime(), true);
            Reservation res12 = new Reservation(client1, timeTable5, new DateTime(), true);
            Reservation res13 = new Reservation(client1, timeTable6, new DateTime(), false);
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
            


        }
    }
}
