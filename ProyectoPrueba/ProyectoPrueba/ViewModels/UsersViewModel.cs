namespace ProyectoPrueba.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using ProyectoPrueba.Services;
    public class UsersViewModel : INotifyPropertyChanged
    {

        #region Services
        private ApiService apiService;
        private UserManager userManager;
        #endregion

        #region Atributes
        private bool _isRefreshing;
        #endregion

        #region Constructors
        public UsersViewModel()
        {
            this.userManager = new UserManager();
            this.apiService = new ApiService();
            this.loadUsers();

        }
        #endregion

        #region Properties
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
        private async void loadUsers()
        {
            /*
            this.IsRefreshing = true;
            //http://restcountries.eu/rest/v2/all
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                return;

            }
            var response = await this.apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                return;
            }

            MainViewModel.GetInstance().LandsList = (List<Land>)response.Result;
            this.IsRefreshing = false;
            this.Lands = new ObservableCollection<LandItemViewModel>(
                this.ToLandItemViewModel());
                */               
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
