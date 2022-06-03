using ProjetAppMobile.Models;
using ProjetAppMobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetAppMobile.ViewModels
{
    public class VillesViewModel : VilleBaseViewModel
    {
        private Ville _selectedVille;

        public ObservableCollection<Ville> Villes { get; }
        public Command ChargerVillesCommand { get; }
        public Command AjouterVilleCommand { get; }
        public Command<Ville> VilleTapped { get; }

        public VillesViewModel()
        {
            Title = "Liste des villes";
            Villes = new ObservableCollection<Ville>();
            ChargerVillesCommand = new Command(async () => await ExecuteChargerVillesCommand());

            VilleTapped = new Command<Ville>(OnVilleSelected);

            AjouterVilleCommand = new Command(OnAjouterVille);
        }

        async Task ExecuteChargerVillesCommand()
        {
            IsBusy = true;

            try
            {
                Villes.Clear();
                var villes = await DataStore.GetVillesAsync(true);
                foreach (var ville in villes)
                {
                    Villes.Add(ville);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedVille = null;
        }

        public Ville SelectedVille
        {
            get => _selectedVille;
            set
            {
                SetProperty(ref _selectedVille, value);
                OnVilleSelected(value);
            }
        }

        private async void OnAjouterVille(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewVillePage));
            //déclenche le bouton ajouter
        }


        async void OnVilleSelected(Ville ville)
        {
            if (ville == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(VilleDetailPage)}?{nameof(VilleDetailViewModel.VilleId)}={ville.Id}");
        }
    }
}