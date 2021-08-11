using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using CursoXamarin.Models;
using CursoXamarin.Views;
using Xamarin.Forms;

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

        private DoctorModel _CurrentDoctor = new DoctorModel();

        public DoctorModel CurrentDoctor
        {
            get
            {
                return _CurrentDoctor;
            }
            set
            {
                _CurrentDoctor = value;
                OnPropertyChanged("CurrentDoctor");
            }
        }

        #endregion

        #region Commands

        public ICommand EnterDoctorDetailCommand { get; set; }

        #endregion

        #region Singleton

        private static HomeViewModel instance = null;

        private HomeViewModel()
        {
            InitClass();
            InitCommand();
        }

        public static HomeViewModel GetInstance()
        {
            if (instance == null)
                instance = new HomeViewModel();

            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
                instance = null;
        }

        #endregion

        public async void InitClass()
        {
            lstDoctors = await DoctorModel.GetAllDoctors();
        }

        public void InitCommand()
        {
            EnterDoctorDetailCommand = new Command<DoctorModel>(EnterDoctorDetail);
        }


        public void EnterDoctorDetail(DoctorModel doctor)
        {
            //CurrentDoctor = lstDoctors.Where(x => x.Id == doctor.Id).FirstOrDefault();
            CurrentDoctor = doctor;

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new DetailDoctorView());
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
