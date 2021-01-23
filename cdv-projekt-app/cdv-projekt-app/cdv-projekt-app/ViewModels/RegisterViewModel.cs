using cdv_projekt_app.Api;
using cdv_projekt_app.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace cdv_projekt_app.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {

        public Command RegisterCommand { get; }
        public Command LoginCommand { get; }

        private string _password = "";
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _password_confirmation = "";
        public string PasswordConfirmation
        {
            get
            {
                return _password_confirmation;
            }
            set
            {
                _password_confirmation = value;
                OnPropertyChanged(nameof(PasswordConfirmation));
            }
        }

        private string _name = "";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _email = "";
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnRegisterClicked(object obj)
        {

            var response = await ApiClient.RegisterUser(Name, Email, Password, PasswordConfirmation);

            if (response)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
                //Application.Current.MainPage = new NavigationPage(new AboutPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Błąd!", "Prawdopodobnie podałeś błędne dane rejestracji. Spróbuj ponownie.", "Zamknij");
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

        }

        private async void OnLoginClicked(object obj)
        {
            //await App.Page.Navigation.PushAsync(new LoginPage());

            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
