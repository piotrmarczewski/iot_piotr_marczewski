using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using cdv_projekt_app.Api;
using cdv_projekt_app.Models;
using Xamarin.Forms;

namespace cdv_projekt_app.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private decimal weight;
        private DateTime date;
        private string description;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(weight.ToString())
                && !String.IsNullOrWhiteSpace(date.ToString());
        }

        public decimal Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }

        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var response = await ApiClient.AddWeightUser(Weight, Date, Description);

            if (response)
            {
                await Shell.Current.GoToAsync("..");
                //Application.Current.MainPage = new AppShell();

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Błąd!", "Coś poszło nie tak.", "Zamknij");
            }
        }
    }
}
