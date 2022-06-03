using ProjetAppMobile.Models;
using ProjetAppMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetAppMobile.Views
{
    public partial class NewPaysPage : ContentPage
    {
        public Pays Pays { get; set; }

        public NewPaysPage()
        {
            InitializeComponent();
            BindingContext = new NewPaysViewModel();
        }
    }
}