namespace ProyectoPrueba.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using ProyectoPrueba.Models;
    using ProyectoPrueba.Services;
    public class UsersViewModel : INotifyPropertyChanged
    {

        #region Services
        private ApiService apiService;
        private UserManager userManager;
        #endregion

        #region Atributes
        private ObservableCollection<User> _users;
        private bool _isRefreshing;
        #endregion

        #region Constructors
        public UsersViewModel()
        {
            this.userManager = new UserManager();
            this.apiService = new ApiService();
            this.LoadUsers();

        }
        #endregion

        #region Properties
        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        #region Methods
        private async void LoadUsers()
        {

            this.IsRefreshing = true;
            //Check Connection
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                return;

            }
            var response = await this.apiService.GetUsers("http://xamarin.addictphones.com/listado.php");

            //var response = await this.apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                return;
            }
            MainViewModel.GetInstance().UsersList = (List<User>)response.Result;
            this.IsRefreshing = false;
            this.Users = new ObservableCollection<User>(MainViewModel.GetInstance().UsersList);
                             
        }

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private async void SelectUser()
        {

            //this.IsRefreshing = true;
            //Check Connection
            /*
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                return;

            }
            var response = await this.apiService.GetUsers("http://xamarin.addictphones.com/listado.php");
            */
            //var response = await this.apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");
            //if (!response.IsSuccess)
            //{
            //    this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Message", "Entro a User", "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                //return;
            //}
            //MainViewModel.GetInstance().UsersList = (List<User>)response.Result;
            //this.IsRefreshing = false;
            //this.Users = new ObservableCollection<User>(MainViewModel.GetInstance().UsersList);

        }

        #endregion

        #region Commands

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadUsers);
            }
        }
        public ICommand SelectUserCommand
        {
            get
            {
                return new RelayCommand(SelectUser);
            }
        }

        #endregion

    }
}
