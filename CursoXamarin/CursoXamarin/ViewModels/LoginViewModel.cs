using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using CursoXamarin.Models;
using CursoXamarin.Views;
using Realms;
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
        public ICommand RegisterCommand { get; set; }

        #endregion


        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
            EnterRegisterCommand = new Command(EnterRegister);
            ExitRegisterCommand = new Command(ExitRegister);
            RegisterCommand = new Command(Register);
        }

        public async void Register()
        {
            try
            {
                var realm = Realm.GetInstance();

                var users = realm.All<UserModel>();

                //Dar un consecutivo
                User.Id = users.Count() + 1;

                realm.Write(() =>
                {
                    realm.Add(User);
                });

                Clean();

                await App.Current.MainPage.DisplayAlert("Success", "User created successfully", "OK");

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Login error: " + ex.Message, "OK");
            }
            finally
            {
                App.Current.MainPage = new LoginView();
            }
        }

        private void Clean()
        {
            User = new UserModel();
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
                var realm = Realm.GetInstance();

                var dbUser = realm.All<UserModel>().Where(u => u.Email == User.Email).FirstOrDefault();

                if (dbUser == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Info", "User not exist", "OK");
                }
                else
                {
                    if (User.Password == dbUser.Password)
                    {

                        NavigationPage navigation = new NavigationPage(new HomeView());

                        Application.Current.MainPage = new MasterDetailPage
                        {
                            Master = new MenuView(),
                            Detail = navigation
                        };
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Wrong Credentials", "OK");
                    }
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
