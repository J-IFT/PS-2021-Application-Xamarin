using ProjetAppMobile.Models;
using ProjetAppMobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjetAppMobile.ViewModels
{
    public class PaysViewModel : PaysBaseViewModel
    {
        private Pays _selectedPays;

        public ObservableCollection<Pays> Payss { get; }
        public Command LoadPaysCommand { get; }
        public Command AddPaysCommand { get; }
        public Command<Pays> PaysTapped { get; }

        public PaysViewModel()
        {
            Title = "Liste des pays";
            Payss = new ObservableCollection<Pays>();
            LoadPaysCommand = new Command(async () => await ExecuteLoadPaysCommand());

            PaysTapped = new Command<Pays>(OnPaysSelected);

            AddPaysCommand = new Command(OnAddPays);
        }

        async Task ExecuteLoadPaysCommand()
        {
            IsBusy = true;

            try
            {
                Payss.Clear();
                var payss = await DataStore.GetAllPaysAsync(true);
                foreach (var pays in payss)
                {
                    Payss.Add(pays);
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
            SelectedPays = null;
        }

        public Pays SelectedPays
        {
            get => _selectedPays;
            set
            {
                SetProperty(ref _selectedPays, value);
                OnPaysSelected(value);
            }
        }

        private async void OnAddPays(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPaysPage));
        }

        async void OnPaysSelected(Pays pays)
        {
            if (pays == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PaysDetailPage)}?{nameof(PaysDetailViewModel.PaysId)}={pays.Id}");
        }
    }
}