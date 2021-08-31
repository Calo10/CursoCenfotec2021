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
        public ICommand EnterMenuOptionCommand { get; set; }

        #endregion


        public MenuViewModel()
        {
            LogoutCommand = new Command(Logout);
            EnterMenuOptionCommand = new Command<int>(EnterMenuOption);

            lstMenu.Add(new MenuModel { Id = 1, Name = "Especialidades", Icon = "" });
            lstMenu.Add(new MenuModel { Id = 2, Name = "Contacto", Icon = "" });
            lstMenu.Add(new MenuModel { Id = 3, Name = "Mapa", Icon = "" });
        }

        public async void Logout()
        {
            App.Current.MainPage = new LoginView();
        }

        public async void EnterMenuOption(int id)
        {
            switch (id)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:
                    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new MapView());

                    break;
                default:
                    break;
            }
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
