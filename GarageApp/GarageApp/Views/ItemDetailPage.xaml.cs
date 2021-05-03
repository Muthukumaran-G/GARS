using GarageApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace GarageApp.Views
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