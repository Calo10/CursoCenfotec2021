using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CursoXamarin.Models;

namespace CursoXamarin.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<DoctorModel> _lstDoctors = new ObservableCollection<DoctorModel>();

        public ObservableCollection<DoctorModel> lstDoctors
        {
            get
            {
                return _lstDoctors;
            }
            set
            {
                _lstDoctors = value;
                OnPropertyChanged("lstDoctors");
            }
        }

        #endregion




        public HomeViewModel()
        {
            lstDoctors.Add(new DoctorModel { Id = "1", FirstName = "Joe", LastName = "Doe", Icon = "https://eshendetesia.com/images/user-profile.png" });
            lstDoctors.Add(new DoctorModel { Id = "2", FirstName = "Nat", LastName = "Men", Icon = "" });
            lstDoctors.Add(new DoctorModel { Id = "3", FirstName = "Sof", LastName = "Bar", Icon = "https://image.flaticon.com/icons/png/512/219/219990.png" });
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
