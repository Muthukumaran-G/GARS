using GarageApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GarageApp.ViewModels
{
	public class LocationsViewModel : BaseViewModel
	{
		private ObservableCollection<GarageLocation> locations;
		public ObservableCollection<GarageLocation> Locations
		{
			get
			{
				return locations;
			}
			set
			{
				locations = value;
				OnPropertyChanged();
			}
		}

		private string selectedPin;

		public string SelectedPin
		{
			get
			{
				return selectedPin;
			}
			set
			{
				selectedPin = value;
				OnPropertyChanged();
			}
		}

		private bool changeVerifyStackVisibility;

		public bool ChangeVerifyStackVisibility
		{
			get
			{
				return changeVerifyStackVisibility;
			}
			set
			{
				changeVerifyStackVisibility = value;
				OnPropertyChanged();
			}
		}

		private bool changeConfirmStackVisibility;

		public bool ChangeConfirmStackVisibility
		{
			get
			{
				return changeConfirmStackVisibility;
			}
			set
			{
				changeConfirmStackVisibility = value;
				OnPropertyChanged();
			}
		}

		private bool isIndicatorVisibile;

		public bool IsIndicatorVisibile
		{
			get
			{
				return isIndicatorVisibile;
			}
			set
			{
				isIndicatorVisibile = value;
				OnPropertyChanged();
			}
		}

		private double distanceFromLocation;

		public double DistanceFromLocation
		{
			get
			{
				return distanceFromLocation;
			}
			set
			{
				distanceFromLocation = value;
				OnPropertyChanged();
			}
		}

		private int otp;

		public int OTP
		{
			get
			{
				return otp;
			}
			set
			{
				otp = value;
				OnPropertyChanged();
			}
		}

		public Command ConfirmButtonCommand { get; set; }

		public LocationsViewModel()
		{
			ConfirmButtonCommand = new Command(ConfirmButtonClicked);
			IsIndicatorVisibile = false;
			Locations = new ObservableCollection<GarageLocation>();
			Locations.Add(new GarageLocation() { Position = new Position(12.9245841493887, 80.2083022892475), Address = "Velachery", Description = "Parking Space 1" });
			Locations.Add(new GarageLocation() { Position = new Position(12.9771921365245, 80.2195987477899), Address = "Pallikaranai", Description = "Parking Space 2" });
			Locations.Add(new GarageLocation() { Position = new Position(12.8902879847325, 80.1982098072767), Address = "Medavakkam", Description = "Parking Space 3" });
			Locations.Add(new GarageLocation() { Position = new Position(11.6248466541708, 79.4821642711759), Address = "Block-7", Description = "Parking Space 4" });
			Locations.Add(new GarageLocation() { Position = new Position(11.6176441157449, 79.4811829179526), Address = "Block-6", Description = "Parking Space 5" });
			Locations.Add(new GarageLocation() { Position = new Position(11.6201761254443, 79.4758637621999), Address = "Block 13", Description = "Parking Space 6" });
			Locations.Add(new GarageLocation() { Position = new Position(11.6265132737494, 79.4762865453959), Address = "Block-12", Description = "Parking Space 7" });
		}

		public Pin CurrentPin { get; set; }

		public Xamarin.Essentials.Location EssentialsLocation { get; set; }

		private async void ConfirmButtonClicked(object obj)
        {
			this.OTP = new Random().Next(1000, 9999);
			this.IsIndicatorVisibile = true;
			await Task.Delay(2000);
			this.ChangeConfirmStackVisibility = true;
			this.ChangeVerifyStackVisibility = false;
			App.notificationManager.SendNotification("OTP", this.OTP.ToString());
			this.IsIndicatorVisibile = false;
			await App.Current.MainPage.DisplayAlert("OTP sent", "Check notification for OTP", "OK");
			var result = await App.Current.MainPage.DisplayAlert("Navigate", "Do you wish to Navigate to the booked parking space?", "Sure", "Nope");
			if (result)
			{
				var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving, Name = CurrentPin.Label };
				await Xamarin.Essentials.Map.OpenAsync(new Xamarin.Essentials.Location(CurrentPin.Position.Latitude, CurrentPin.Position.Longitude), options);
			}
		}
    }
}
