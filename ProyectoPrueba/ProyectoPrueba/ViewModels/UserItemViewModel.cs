namespace ProyectoPrueba.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Models;
    public class UserItemViewModel :User
    {
        public UserItemViewModel()
        {
        }
        #region Commands
        public ICommand SelectUserCommand
        {
            get
            {
                return new RelayCommand(SelectUser);
            }
        }
        #endregion
        #region Methods
        private async void SelectUser()
        {

            var mainViewModel = MainViewModel.GetInstance();

            mainViewModel.Maps = new MapsViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new Views.MapsPage());
        }
        #endregion
    }
}
