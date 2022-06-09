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

        public RideDTO(string polazak, string dolazak, double cena, string linija)
        {
            Polazak = polazak;
            Dolazak = dolazak;
            Cena = cena;
            Linija = linija;
        }

        public string Polazak { get; set; }
        public string Dolazak { get; set; }
        public double Cena { get; set; }

        public string Linija { get; set; }


    }
}
