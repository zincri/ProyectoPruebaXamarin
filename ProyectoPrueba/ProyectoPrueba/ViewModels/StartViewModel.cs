namespace ProyectoPrueba.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Command;
    using ProyectoPrueba.Services;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    public class StartViewModel : INotifyPropertyChanged
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Vars
        private string _email;
        private string _password;
        private bool _isRunning;
        private bool _isRemembered;
        private bool _isEnable;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }
        
        public bool IsEnable
        {
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand StartCommand
        {
            get
            {
                return new RelayCommand(ListadoMethod);
            }
        }
        #endregion

        #region Constructors
        public StartViewModel()
        {
            this.apiService = new ApiService();
            IsEnable = true;
            IsRunning = false;
        }
        #endregion

        #region Methods
        private async void ListadoMethod()
        {
            IsRunning = true;
            IsEnable = false;
            

            var conection = await this.apiService.CheckConnection();
            if (!conection.IsSuccess)
            {

                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                "Error",
                    conection.Message,
                "Ok");
                IsRunning = false;
                IsEnable = true;
                return;
            }
            await App.Current.MainPage.DisplayAlert(
                "Entro",
                    "Si entro al metodo",
                "Ok");
            /*
            var token = await this.apiService.GetToken(
                "http://landsapi1.azurewebsites.net",
                "user",
                "pass");
                */

            /*
            if (token == null)
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                Languages.Error,
                Languages.SomethingWrong,
                Languages.Ok);
                this.Password = string.Empty;
                return;

            }
            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                Languages.Error,
                    token.ErrorDescription,
                Languages.Ok);
                this.Password = string.Empty;
                return;
            }
            */

            var mainViewModel = MainViewModel.GetInstance();
            //mainViewModel.Token = token;

            mainViewModel.Users = new UsersViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new Views.UsersPage());

            IsRunning = false;
            IsEnable = true;

        }

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
