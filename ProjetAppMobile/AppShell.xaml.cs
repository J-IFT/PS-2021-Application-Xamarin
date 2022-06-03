using ProjetAppMobile.ViewModels;
using ProjetAppMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ProjetAppMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(VilleDetailPage), typeof(VilleDetailPage));
            Routing.RegisterRoute(nameof(NewVillePage), typeof(NewVillePage));
            Routing.RegisterRoute(nameof(EditVillePage), typeof(EditVillePage));
            Routing.RegisterRoute(nameof(PaysDetailPage), typeof(PaysDetailPage));
            Routing.RegisterRoute(nameof(NewPaysPage), typeof(NewPaysPage));
            Routing.RegisterRoute(nameof(EditPaysPage), typeof(EditPaysPage));
        }
    }
}
