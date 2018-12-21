namespace ProyectoPrueba.ViewModels
{
    using System.Collections.Generic;
    using ProyectoPrueba.Models;
    public class MainViewModel
    {

        #region Properties
        public List<User> UsersList
        {
            get;
            set;
        }
        public TokenResponse Token
        {
            get;
            set;
        }
        #endregion
        private static MainViewModel instance;//Objeto principal
        #region ViewModels
        public StartViewModel Start
        {
            get;
            set;
        }
        public UsersViewModel Users
        {
            get;
            set;
        }
        #endregion
        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Start = new StartViewModel();
        }
        #endregion

        #region Methods

        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();
            return instance;
        }
        #endregion
    }
}
