using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms.Maps;

namespace GarageApp.Models
{
	public class GarageLocation : INotifyPropertyChanged
	{
		private Position position;
		private string address;
		private string description;

		public event PropertyChangedEventHandler PropertyChanged;

		public Position Position
		{
			get { return position; }
			set
			{
				position = value;
				OnPropertyChanged();
			}
		}
		public string Address
		{
			get
			{
				return address;
			}
			set
			{
				address = value;
				OnPropertyChanged();
			}
		}
		public string Description
		{
			get { return description; }
			set
			{
				description = value;
				OnPropertyChanged();
			}
		}

		public GarageLocation()
		{

		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
