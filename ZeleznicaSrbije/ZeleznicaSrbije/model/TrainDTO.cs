using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class TrainDTO: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private string _naziv;
        private int _broj_vagona;
        private int _broj_redova;
        private int _broj_sedista;

        public string Naziv { get { return _naziv; } set { if (value != _naziv) { _naziv = value; OnPropertyChanged("Naziv"); } } }
        public int BrojVagona { get { return _broj_vagona; } set { if (value != _broj_vagona) { _broj_vagona = value; OnPropertyChanged("BrojVagona"); } } }
        public int BrojRedova { get { return _broj_redova; } set { if (value != _broj_redova) { _broj_redova = value; OnPropertyChanged("BrojRedova"); } } }
        public int BrojSedista { get { return _broj_sedista; } set { if (value != _broj_sedista) { _broj_sedista = value; OnPropertyChanged("BrojSedista"); } } }

        public TrainDTO(string naziv, int brojVagona, int brojRedove, int brojSedista)
        {
            _naziv = naziv;
            _broj_vagona = brojVagona;
            _broj_redova = brojRedove;
            _broj_sedista = brojSedista;
        }

        public TrainDTO(Train t)
        {
            _naziv = t.name;
            _broj_vagona = t.numberOfWagons;
            _broj_redova = t.numberOfRowsInWagon;
            _broj_sedista = t.numberOfSeatsPerRow;
        }
    }
}
