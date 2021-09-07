using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CursoXamarin.Models;

namespace CursoXamarin.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {
        #region Properties
        private ObservableCollection<LocationModel> _lstLocations = new ObservableCollection<LocationModel>();

        public ObservableCollection<LocationModel> lstLocations
        {
            get { return _lstLocations; }

            set
            {
                _lstLocations = value;
                OnPropertyChanged("lstLocations");
            }
        }
        #endregion


        public MapViewModel()
        {

            lstLocations.Add(new LocationModel { Latitude = 9.927482, Longitude = -84.049995, Description = "HOLA 1" });
            lstLocations.Add(new LocationModel { Latitude = 9.931794, Longitude = -84.038064, Description = "HOLA 2" });
        }


        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
