using ProjetAppMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProjetAppMobile.Views
{
    public partial class PaysDetailPage : ContentPage
    {

        public PaysDetailPage()
        {
            InitializeComponent();
            BindingContext = new PaysDetailViewModel();
        }
    }
}