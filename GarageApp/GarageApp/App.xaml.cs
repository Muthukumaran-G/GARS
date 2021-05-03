using GarageApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using GarageApp.Interface;

[assembly: ExportFont("Montserrat-Bold.ttf",Alias="Montserrat-Bold")]
     [assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat-Medium")]
     [assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat-Regular")]
     [assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "Montserrat-SemiBold")]
     [assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
namespace GarageApp
{
	public partial class App : Application
	{
		public static string ImageServerPath { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

		internal static GeolocationRequest Request { get; set; } = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

		internal static CancellationTokenSource CancellationToken { get; set; } = new CancellationTokenSource();

		internal static INotificationManager notificationManager;

		public App()
		{
			InitializeComponent();
			notificationManager = DependencyService.Get<INotificationManager>();
			GetCurrentLocation();
			Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
			MainPage = new NavigationPage(new GarageLoginPage());
			if (Connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				MainPage.Navigation.PushAsync(new GarageNoInternetPage());
			}
		}

		private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
		{
			if (e.NetworkAccess == NetworkAccess.Internet)
			{
				MainPage.Navigation.PopAsync();
			}
			else
			{
				MainPage.Navigation.PushAsync(new GarageNoInternetPage());
			}
		}

		private async void GetCurrentLocation()
		{
			await GetLocation();
		}


		internal static async Task<Xamarin.Essentials.Location> GetLocation()
		{
			try
			{
				var location = await Geolocation.GetLocationAsync(Request, CancellationToken.Token).ConfigureAwait(false);
				return location;
			}
			catch (FeatureNotSupportedException fnsEx)
			{
				if (App.Current.MainPage != null)
				{
					await App.Current.MainPage.DisplayAlert("Alert", "Feature not supported", "OK");
				}
				else
				{
					notificationManager.SendNotification("Alert", "GPS feature not supported in this device");
				}
			}
			catch (FeatureNotEnabledException fneEx)
			{
				if (App.Current.MainPage != null)
				{ 
					//await App.Current.MainPage.DisplayAlert("Alert", "GPS is not enabled", "OK");
				}
				else
				{
					notificationManager.SendNotification("Alert", "GPS feature not enabled");
				}
			}
			catch (PermissionException pEx)
			{
				if (App.Current.MainPage != null)
				{
					await App.Current.MainPage.DisplayAlert("Alert", "GPS permission not granted", "OK");
				}
				else
				{
					notificationManager.SendNotification("Alert", "GPS Permission not granted");
				}
			}
			catch (Exception ex)
			{
				if (App.Current.MainPage != null)
				{
					await App.Current.MainPage.DisplayAlert("Alert", "Unable to get location", "OK");
				}
				else
				{
					notificationManager.SendNotification("Alert", "Unable to get location");
				}
			}

			return null;
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
