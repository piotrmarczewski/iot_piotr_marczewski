using cdv_projekt_app.Api;
using cdv_projekt_app.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace cdv_projekt_app.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

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

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnLoginClicked(object obj)
        {

            var response = await ApiClient.LoginUser(Email, Password);

            if (response)
            {
                Application.Current.MainPage = new AppShell();

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Błąd!", "Prawdopodobnie podałeś błędne dane logowania. Spróbuj ponownie.", "Zamknij");
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

        }

        private async void OnRegisterClicked(object obj)
        {
            Application.Current.MainPage = new NavigationPage(new RegisterPage());
        }
    }
}
