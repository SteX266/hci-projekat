using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class RideDTO:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public TimeTable TimeTable { get; set; }
        private string _polaziste;
        private string _odrediste;
        private TimeSpan _polazak;
        private TimeSpan _dolazak;
        private TimeSpan _trajanje;
        private double _cena;
        private string _linija;
        public RideDTO()
        {
        }

        public RideDTO(string polaziste, string odrediste, TimeSpan polazak, TimeSpan dolazak, double cena, string linija, TimeTable table)
        {
            _polaziste = polaziste;
            _odrediste = odrediste;
            _polazak = polazak;
            _dolazak = dolazak;
            TimeTable = table;
            if (_polazak > _dolazak)
            {
                _dolazak = _dolazak.Add(new TimeSpan(1,0,0,0));
            }
            _trajanje = _dolazak.Subtract(_polazak);

            if(_dolazak.Days > 0)
            {
                _dolazak = _dolazak.Subtract(new TimeSpan(1,0,0,0));  
            }

            _cena = cena;
            _linija = linija;
        }

        public string Polaziste { get { return _polaziste; } set { if (value!=_polaziste) { _polaziste = value; OnPropertyChanged("Polaziste"); } } }
        public string Odrediste { get { return _odrediste; } set { if (value != _odrediste) { _odrediste = value; OnPropertyChanged("Odrediste"); } } }
        public TimeSpan Polazak { get { return _polazak; } set { if (value != _polazak) { _polazak = value; OnPropertyChanged("Polazak"); } } }
        public TimeSpan Dolazak { get { return _dolazak; } set { if (value != _dolazak) { _dolazak = value; OnPropertyChanged("Dolazak"); } } }
        public TimeSpan Trajanje { get { return _trajanje; } set { if (value != _trajanje) { _trajanje = value; OnPropertyChanged("Trajanje"); } } }
        public double Cena { get { return _cena; } set { if (value != _cena) { _cena = value; OnPropertyChanged("Cena"); } } }
        public string Linija { get { return _linija; } set { if (value != _linija) { _linija = value; OnPropertyChanged("Linija"); } } }


        public string PolazakString { get { return _polazak.ToString(@"hh\:mm"); } }
        public string DolazakString { get { return _dolazak.ToString(@"hh\:mm"); } }
        public string TrajanjeString { get { return _trajanje.ToString(@"hh\:mm"); } }







    }
}
