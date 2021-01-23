using cdv_projekt_app.Api;
using cdv_projekt_app.Models;
using cdv_projekt_app.Views;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace cdv_projekt_app.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string id;
        private string name;
        private string email;
        public Command LogoutCommand { get; }

        public AboutViewModel()
        {
            Title = "Profil";
            GetUserInfo();

            LogoutCommand = new Command(OnLogoutClicked);
        }



        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        private async void GetUserInfo()
        {
            try
            {
                var userInfo = await ApiClient.GetUserInfo();

                Id = userInfo.Id;
                Name = userInfo.Name;
                Email = userInfo.Email;
            }
            catch
            {
                Debug.WriteLine("Failed to Load data");
            }
            
        }

        private async void OnLogoutClicked()
        {
            var response = await ApiClient.LogoutUser();

            if (response)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Błąd!", "Nie udało się wylogować.", "Zamknij");
            }
        }
    }
}