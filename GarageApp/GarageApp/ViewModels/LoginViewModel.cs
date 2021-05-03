using GarageApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GarageApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public Command BackButtonCommand { get; set; }

        private bool isLoginClicked;

        public bool IsLoginClicked
        {
            get
            {
                return this.isLoginClicked;
            }

            set
            {
                if (this.isLoginClicked == value)
                {
                    return;
                }

                this.SetProperty(ref this.isLoginClicked, value);
            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            this.BackButtonCommand = new Command(this.ClosePressed);
        }

        private void ClosePressed(object obj)
        {
            App.Current.MainPage.Navigation.PopModalAsync(true);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
