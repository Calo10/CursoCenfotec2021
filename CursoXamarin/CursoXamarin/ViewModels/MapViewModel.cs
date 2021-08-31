using System;
using System.ComponentModel;

namespace CursoXamarin.ViewModels
{
    public class MapViewModel : INotifyPropertyChanged
    {
        public MapViewModel()
        {
        }

        #region PropertyChangedImplementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }       

        #endregion
    }
}
