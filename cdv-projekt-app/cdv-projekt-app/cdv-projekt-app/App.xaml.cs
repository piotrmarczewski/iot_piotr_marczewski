using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cdv_projekt_app.Services;
using cdv_projekt_app.Views;
using cdv_projekt_app.Api;

namespace cdv_projekt_app
{
    public partial class App : Application
    {
        public static Page Page { get; set; }

        public App()
        {
            InitializeComponent();

            /*DependencyService.Register<MockDataStore>();*/
            MainPage = new NavigationPage(new LoginPage());
            Page = MainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
