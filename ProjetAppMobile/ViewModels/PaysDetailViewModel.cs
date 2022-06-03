using ProjetAppMobile.Models;
using ProjetAppMobile.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetAppMobile.ViewModels
{
    [QueryProperty(nameof(PaysId), nameof(PaysId))]
    public class PaysDetailViewModel : PaysBaseViewModel
    {
        private string paysId;
        private string name;
        private string namepays;

        public string Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string PaysId
        {
            get
            {
                return paysId;
            }
            set
            {
                paysId = value;
                LoadPaysId(value);
            }
        }
        public Command UpdatePaysCommand { get; }
        public PaysDetailViewModel()
        {
            UpdatePaysCommand = new Command(OnUpdatePays);
        }
        public async void LoadPaysId(string paysId)
        {
            try
            {
                var pays = await DataStore.GetPaysAsync(paysId);
                Id = pays.Id;
                Name = pays.Name;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Country");
            }
        }

        public async void Getpaysname(string paysid)
        {
            try
            {
                var pays = await DataStore.GetPaysAsync(paysid);
                var nom = pays.Name;
                namepays = nom;
            }

            catch
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        private async void OnUpdatePays()
        {
            var url = $"{ nameof(EditPaysPage)}?{ nameof(EditPaysViewModel.PaysId)}={ PaysId}";
            await Shell.Current.GoToAsync($"{nameof(EditPaysPage)}?{nameof(EditPaysViewModel.PaysId)}={PaysId}");
            //déclenche le bouton modifier
        }
    }
}
