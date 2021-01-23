using System;
using System.Collections.Generic;
using cdv_projekt_app.Api;
using cdv_projekt_app.ViewModels;
using cdv_projekt_app.Views;
using Xamarin.Forms;

namespace cdv_projekt_app
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
