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
    public partial class EditPaysPage : ContentPage
    {
        public EditPaysPage()
        {
            InitializeComponent();
            BindingContext = new EditPaysViewModel();
        }
    }
}