using System;
using System.Diagnostics;
using System.Threading.Tasks;
using cdv_projekt_app.Api;
using cdv_projekt_app.Models;
using Xamarin.Forms;

namespace cdv_projekt_app.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private decimal weight;
        private DateTime date;
        private string description;
        public string Id { get; set; }

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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await ApiClient.GetOneWeightUser(itemId);
                Weight = item.weight;
                Date = item.date;
                Description = item.description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
