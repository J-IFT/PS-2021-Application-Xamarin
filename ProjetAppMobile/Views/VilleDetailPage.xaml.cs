using ProjetAppMobile.Services;
using ProjetAppMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProjetAppMobile.Views
{
    public partial class VilleDetailPage : ContentPage
    {
        private MeteoData MeteoD;
        private VilleDetailViewModel VDP;
        private string villeid;
        private string nomville;
        public VilleDetailPage()
        {
            InitializeComponent();
            VDP = new VilleDetailViewModel();
            BindingContext = VDP;
            MeteoD = new MeteoData();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            VDP.setdefaultvalue();
            villeid = VDP.VilleId;
            VDP.Getvillenom(villeid);
            nomville = VDP.nomville;
            try
            {
                var meteo = await MeteoD.GetAllMeteos(nomville);
                VDP.getMeteo(meteo);
            }
            catch
            {
                VDP.Meteo = "Inconnue";
                VDP.Temperature = VDP.Meteo;
            }
        }
    }
}