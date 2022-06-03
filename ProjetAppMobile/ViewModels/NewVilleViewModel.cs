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
    public class NewVilleViewModel : VilleBaseViewModel
    {
        private string nom;
        private string description;
        private Pays paysVille;

        private ObservableCollection<Pays> payss;
        public ObservableCollection<Pays> Payss
        {
            get { return payss; }
            set { SetProperty(ref payss, value); }
        }
        public PaysIDataStore<Pays> PaysMockDataStore => DependencyService.Get<PaysIDataStore<Pays>>();

        public NewVilleViewModel()
        {
            Payss = new ObservableCollection<Pays>();
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
                Payss=new ObservableCollection<Pays>();
                var items = await PaysMockDataStore.GetAllPaysAsync(true);
                foreach (var item in items)
                {
                    Payss.Add(item);
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
            Ville newVille = new Ville()
            {
                Id = Guid.NewGuid().ToString(),
                Nom = Nom,
                Description = Description,
                PaysVille = PaysVille
            };

            await DataStore.AjouterVilleAsync(newVille);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}