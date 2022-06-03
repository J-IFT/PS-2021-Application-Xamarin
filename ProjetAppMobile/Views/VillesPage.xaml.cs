using ProjetAppMobile.Models;
using ProjetAppMobile.ViewModels;
using ProjetAppMobile.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetAppMobile.Views
{
    public partial class VillesPage : ContentPage
    {
        VillesViewModel _viewModel;

        public VillesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new VillesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}