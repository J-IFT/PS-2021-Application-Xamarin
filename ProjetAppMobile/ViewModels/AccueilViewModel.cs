using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjetAppMobile.ViewModels
{
    public class AccueilViewModel : VilleBaseViewModel
    {
        public AccueilViewModel()
        {
            Title = "Accueil";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/juliette-ift/ProjetAppMobile_Juliette-Basile"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
