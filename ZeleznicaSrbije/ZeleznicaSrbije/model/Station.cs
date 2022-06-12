using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;

namespace ZeleznicaSrbije.model
{
    public class Station:INotifyPropertyChanged
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
        private Location _location;
        public string Name { get { return _name; } set { if (value != _name) { _name = value; OnPropertyChanged("Name"); } } }

        public Location Location { get { return _location; } set { if (value != _location) { _location = value; OnPropertyChanged("Location"); } } }



        public Station(string name, Location location)
        {
            this._name = name;
            this._location = location;
        }
        public Station()
        {

        }
    }
}
