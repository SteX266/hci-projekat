using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeleznicaSrbije.model
{
    public class TrainLineDTO: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));

            }
        }
        private string _name;
        private string _firstStation;
        private string _lastStation;
        public double _totalPrice;


        public string Name { get { return _name; } set { if (value != _name) { _name = value; OnPropertyChanged("Name"); } } }

        public string FirstStation { get { return _firstStation; } set { if (value != _firstStation) { _firstStation = value; OnPropertyChanged("First name"); } } }

        public string LastStation { get { return _lastStation; } set { if (value != _lastStation) { _lastStation = value; OnPropertyChanged("Last name"); } } }

        public double TotalPrice { get { return _totalPrice; } set { if (value != _totalPrice) { _totalPrice = value; OnPropertyChanged("Total Price"); } } }

        public TrainLineDTO(string name, string firstStation, string lastStation, double totalPrice)
        {
            this._name = name;
            this._firstStation = firstStation;
            this._lastStation = lastStation;
            this._totalPrice = totalPrice;
        }
    }
}
