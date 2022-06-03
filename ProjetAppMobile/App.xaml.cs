using ProjetAppMobile.Services;
using ProjetAppMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetAppMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockVilleService>();
            DependencyService.Register<PaysMockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
