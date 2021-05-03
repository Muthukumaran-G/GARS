using GarageApp.Controls;
using GarageApp.Interface;
using GarageApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace GarageApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMainPageDetail : ContentPage
    {
		public FlyoutMainPageDetail()
        {
            InitializeComponent();
		}

		double previousTime = 0;

		protected override bool OnBackButtonPressed()
		{
			var currentTime = new TimeSpan(DateTime.Now.Ticks).TotalSeconds;
			if (previousTime == 0 || currentTime - previousTime > 7)
			{
				previousTime = currentTime;
				DependencyService.Get<IToastMessage>().ShowToast("Press back again to close");
				return true;
			}
			else
			{
				previousTime = 0;
				return base.OnBackButtonPressed();
			}
		}

        

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			viewModel.IsIndicatorVisibile = true;
			viewModel.EssentialsLocation = await App.GetLocation();
			if (viewModel.EssentialsLocation != null)
			{
				Console.WriteLine($"Latitude: {viewModel.EssentialsLocation.Latitude}, Longitude: {viewModel.EssentialsLocation.Longitude}, Altitude: {viewModel.EssentialsLocation.Altitude}");
				MapObject.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(viewModel.EssentialsLocation.Latitude, viewModel.EssentialsLocation.Longitude), Distance.FromKilometers(0.2)));
				await Task.Delay(1500);
			}
			else
            {
				Device.BeginInvokeOnMainThread(() =>
				{
					Navigation.PushAsync(new GarageLocationDeniedPage());
				});
            }

			viewModel.IsIndicatorVisibile = false;
		}

		CancellationTokenSource cts;

		protected override void OnDisappearing()
		{
			if (cts != null && !cts.IsCancellationRequested)
				cts.Cancel();
			base.OnDisappearing();
		}
	}
}