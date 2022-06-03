using ProjetAppMobile.Models;
using ProjetAppMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetAppMobile.Views
{
    public partial class NewVillePage : ContentPage
    {
        private NewVilleViewModel _villeViewModel;

        public NewVillePage()
        {
            InitializeComponent();
            _villeViewModel = new NewVilleViewModel();
            BindingContext = _villeViewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _villeViewModel.ExecuteLoadPaysCommand();
        }
    }
}