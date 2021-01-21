using System.ComponentModel;
using Xamarin.Forms;
using cdv_projekt_app.ViewModels;

namespace cdv_projekt_app.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}