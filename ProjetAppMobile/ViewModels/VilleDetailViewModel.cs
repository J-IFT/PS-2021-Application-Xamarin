using ProjetAppMobile.Models;
using ProjetAppMobile.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetAppMobile.ViewModels
{
    [QueryProperty(nameof(VilleId), nameof(VilleId))]
    public class VilleDetailViewModel : VilleBaseViewModel
    {
        private string villeId;
        private string nom;
        private string description;
        private string nomPaysVille;
        public string nomville;
        private string meteo;
        private string temperature;
        public Command ModifierVilleCommand { get; }
        public VilleDetailViewModel()
        {
            ModifierVilleCommand = new Command(OnModifierVille);
        }
        public string Id { get; set; }

        public string Nom
        {
            get => nom;
            set => SetProperty(ref nom, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string NomPaysVille
        {
            get => nomPaysVille;
            set => SetProperty(ref nomPaysVille, value);
        }
        public string VilleId
        {
            get
            {
                return villeId;
            }
            set
            {
                villeId = value;
                ChargerVilleId(value);
            }
        }
        public string Meteo
        {
            get => meteo;
            set => SetProperty(ref meteo, value);
        }

        public string Temperature
        {
            get => temperature;
            set => SetProperty(ref temperature, value);
        }

        public void setdefaultvalue()
        {
            Meteo = "Chargement";
            Temperature = Meteo;
        }

        public async void ChargerVilleId(string villeId)
        {
            try
            {
                var ville = await DataStore.GetVilleAsync(villeId);
                Id = ville.Id;
                Nom = ville.Nom;
                Description = ville.Description;
                NomPaysVille = ville.PaysVille.Name;
            }
            catch (Exception)
            {
                Debug.WriteLine("Echec du chargement de la ville");
            }
        }

        private async void OnModifierVille()
        {
            var url = $"{ nameof(EditVillePage)}?{ nameof(EditVilleViewModel.VilleId)}={ VilleId}";
            await Shell.Current.GoToAsync($"{nameof(EditVillePage)}?{nameof(EditVilleViewModel.VilleId)}={VilleId}");
            
            //déclenche le bouton modifier
        }

        public async void Getvillenom(string villeid)
        {
            try
            {
                var ville = await DataStore.GetVilleAsync(villeid);
                var nom = ville.Nom;
                nomville = nom;
            }

            catch
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public void getMeteo(List<string> meteod)
        {
            Meteo = meteod[0];
            Temperature = meteod[1];
        }
    }
}
