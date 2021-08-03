using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CursoXamarin.Models;
using CursoXamarin.Views;
using Xamarin.Forms;

namespace CursoXamarin.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {

        #region Properties

        private ObservableCollection<MenuModel> _lstMenu = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> lstMenu
        {
            get
            {
                return _lstMenu;
            }
            set
            {
                _lstMenu = value;
                OnPropertyChanged("lstMenu");
            }
        }

        #endregion

        #region Command

        public ICommand LogoutCommand { get; set; }

        #endregion


        public MenuViewModel()
        {
            LogoutCommand = new Command(Logout);

            lstMenu.Add(new MenuModel { Name = "Especialidades", Icon = "" });
            lstMenu.Add(new MenuModel { Name = "Contacto", Icon = "" });
        }

        public async void Logout()
        {
            App.Current.MainPage = new LoginView();
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
