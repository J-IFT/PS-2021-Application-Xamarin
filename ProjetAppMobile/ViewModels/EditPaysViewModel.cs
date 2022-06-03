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
    [QueryProperty(nameof(PaysId), nameof(PaysId))]
    public class EditPaysViewModel : PaysBaseViewModel
    {
        private string name;
        private string paysId;

        
        
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

        public async void LoadPaysId(string paysId)
        {
            try
            {
                var pays = await DataStore.GetPaysAsync(paysId);
                Name = pays.Name;
            }
            catch (Exception)
            {
                Debug.WriteLine("Echec du chargement de la ville");
            }
        }
        public EditPaysViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
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
            Pays oldPays = new Pays()
            {
                Id = PaysId,
                Name = Name
            };

            await DataStore.UpdatePaysAsync(oldPays);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
