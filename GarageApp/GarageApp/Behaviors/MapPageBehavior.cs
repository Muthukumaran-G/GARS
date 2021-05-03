using GarageApp.Controls;
using GarageApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GarageApp.Behaviors
{
    public class MapPageBehavior : Behavior<ContentPage>
    {
        CustomMap Map;
        Frame BackDropView;
        LocationsViewModel ViewModel;
        Button CloseButton;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            ViewModel = bindable.BindingContext as LocationsViewModel;
            Map = bindable.FindByName<CustomMap>("MapObject");
            BackDropView = bindable.FindByName<Frame>("BackDropView");
            CloseButton = bindable.FindByName<Button>("CloseButton");
            CloseButton.Clicked += CloseButton_Clicked;
            Map.MapClicked += Map_MapClicked;
            var template = new DataTemplate(() =>
            {
                var pin = new CustomPin();
                pin.SetBinding(CustomPin.PositionProperty, "Position");
                pin.SetBinding(CustomPin.AddressProperty, "Address");
                pin.SetBinding(CustomPin.LabelProperty, "Description");
                pin.MarkerClicked += Pin_MarkerClicked;
                return pin;
            });

            Map.ItemTemplate = template;
            base.OnAttachedTo(bindable);
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            BackDropView.TranslateTo(0, 250, 200);
        }

        private async void Pin_MarkerClicked(object sender, Xamarin.Forms.Maps.PinClickedEventArgs e)
        {
            ViewModel.CurrentPin = sender as CustomPin;
            var args = e.HideInfoWindow;
            ViewModel.IsIndicatorVisibile = true;
            ViewModel.EssentialsLocation = await App.GetLocation().ConfigureAwait(false);
            if (ViewModel.EssentialsLocation != null)
            {
                Distance distance = Distance.BetweenPositions(new Position(ViewModel.EssentialsLocation.Latitude, ViewModel.EssentialsLocation.Longitude), ViewModel.CurrentPin.Position);
                ViewModel.DistanceFromLocation = Math.Round(distance.Kilometers, 2, MidpointRounding.AwayFromZero);
            }
            ViewModel.SelectedPin = (sender as Pin).Label;
            ViewModel.ChangeConfirmStackVisibility = false;
            ViewModel.ChangeVerifyStackVisibility = true;
            await BackDropView.TranslateTo(0, 0, 200);
            ViewModel.IsIndicatorVisibile = false;
        }

        private void Map_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            BackDropView.TranslateTo(0, 250, 200);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
