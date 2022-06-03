using ProjetAppMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetAppMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditVillePage : ContentPage
    {
        private EditVilleViewModel _vm;

        public EditVillePage()
        {
            InitializeComponent();
            _vm = new EditVilleViewModel();
            BindingContext = _vm;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _vm.ExecuteLoadPaysCommand();
        }
    }
}