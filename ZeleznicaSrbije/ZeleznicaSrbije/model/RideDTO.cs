using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class RideDTO
    {
        public RideDTO()
        {
        }

        public RideDTO(string polaziste, string odrediste, TimeSpan polazak, TimeSpan dolazak, double cena, string linija)
        {
            Polaziste = polaziste;
            Odrediste = odrediste;
            Polazak = polazak;
            Dolazak = dolazak;
            
            if (Polazak > Dolazak)
            {
                Dolazak = Dolazak.Add(new TimeSpan(1,0,0,0));
            }
            Trajanje = Dolazak.Subtract(Polazak);

            if(Dolazak.Days > 0)
            {
                Dolazak = Dolazak.Subtract(new TimeSpan(1,0,0,0));  
            }

            Cena = cena;
            Linija = linija;
        }

        public string Polaziste { get; set; }
        public string Odrediste { get; set; }
        public TimeSpan Polazak { get; set; }
        public TimeSpan Dolazak { get; set; }
        public TimeSpan Trajanje { get; set; }

        public double Cena { get; set; }

        public string Linija { get; set; }




       


    }
}
