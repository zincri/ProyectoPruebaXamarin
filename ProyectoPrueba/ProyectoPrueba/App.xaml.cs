using ProyectoPrueba.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace ProyectoPrueba
{
	public partial class App : Application
	{
        public static double ScreenHeight;
        public static double ScreenWidth;
        public App ()
		{
			InitializeComponent();
            //MainPage = new StartPage();
            NavigationPage objeto = new NavigationPage(new Views.StartPage());
            MainPage = objeto;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
