using System;
using System.ComponentModel;
using System.Windows.Input;
using CursoXamarin.Models;
using CursoXamarin.Views;
using Xamarin.Forms;

namespace CursoXamarin.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Properties

        private UserModel _User = new UserModel();

        public UserModel User
        {
            get
            {
                return _User;
            }

            set
            {
                _User = value;
                OnPropertyChanged("User");
            }
        }
        #endregion

        #region Command

        public ICommand LoginCommand { get; set; }
        public ICommand EnterRegisterCommand { get; set; }
        public ICommand ExitRegisterCommand { get; set; }

        #endregion


        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            EnterRegisterCommand = new Command(EnterRegister);
            ExitRegisterCommand = new Command(ExitRegister);
        }

        public async void EnterRegister()
        {
            App.Current.MainPage = new RegisterView();
        }

        public async void ExitRegister()
        {
            App.Current.MainPage = new LoginView();
        }

        public async void Login()
        {
            try
            {
                if(User.Email.ToLower() == "test@test.com" && User.Password == "abc123")
                {
                    //Application.Current.MainPage = new HomeView();

                    NavigationPage navigation = new NavigationPage(new HomeView());

                    Application.Current.MainPage = new MasterDetailPage
                    {
                        Master = new MenuView() ,
                        Detail = navigation
                    };
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Wrong Credentials", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Login error:" + ex.Message, "OK");
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
