using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class TrainDTO
    {
        public string Naziv { get; set; }   
        public int BrojVagona { get; set; }
        public int BrojRedova { get; set; } 
        public int BrojSedista { get; set; }

        public TrainDTO(string naziv, int brojVagona, int brojRedove, int brojSedista)
        {
            Naziv = naziv;
            BrojVagona = brojVagona;
            BrojRedova = brojRedove;
            BrojSedista = brojSedista;
        }

        public TrainDTO(Train t)
        {
            this.Naziv = t.name;
            this.BrojVagona = t.numberOfWagons;
            this.BrojRedova = t.numberOfRowsInWagon;
            this.BrojSedista = t.numberOfSeatsPerRow;
        }
    }
}
