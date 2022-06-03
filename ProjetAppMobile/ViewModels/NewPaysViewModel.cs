using ProjetAppMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjetAppMobile.ViewModels
{
    public class NewPaysViewModel : PaysBaseViewModel
    {
        private string name;

        public NewPaysViewModel()
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
            Pays newPays = new Pays()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name
            };

            await DataStore.AddPaysAsync(newPays);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
