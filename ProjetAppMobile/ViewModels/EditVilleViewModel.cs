using ProjetAppMobile.Models;
using ProjetAppMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace ProjetAppMobile.ViewModels
{
    [QueryProperty(nameof(VilleId), nameof(VilleId))]
    public class EditVilleViewModel : VilleBaseViewModel
    {
        private string nom;
        private string description;
        private Pays paysVille;
        private ObservableCollection<Pays> payss = new ObservableCollection<Pays>();
        private string villeId;

        public ObservableCollection<Pays> Payss
        {
            get { return payss; }
            set { SetProperty(ref payss, value); }
        }
        public PaysIDataStore<Pays> PaysMockDataStore => DependencyService.Get<PaysIDataStore<Pays>>();
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

        public async void ChargerVilleId(string villeId)
        {
            try
            {
                var ville = await DataStore.GetVilleAsync(villeId);
                Nom = ville.Nom;
                Description = ville.Description;
                PaysVille = ville.PaysVille;
            }
            catch (Exception)
            {
                Debug.WriteLine("Echec du chargement de la ville");
            }
        }
        public EditVilleViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public async Task ExecuteLoadPaysCommand()
        {
            IsBusy = true;

            try
            {
                Payss.Clear();
                var items = await PaysMockDataStore.GetAllPaysAsync(true);
                foreach (var item in items)
                {
  
                    Payss.Add(item);
                }
                ChargerVilleId(VilleId);
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

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nom)
                && !String.IsNullOrWhiteSpace(description);
        }

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

        public Pays PaysVille
        {
            get => paysVille;
            set => SetProperty(ref paysVille, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Ville oldVille = new Ville()
            {
                Id = VilleId,
                Nom = Nom,
                Description = Description,
                PaysVille = PaysVille
            };

            await DataStore.ModifierVilleAsync(oldVille);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
