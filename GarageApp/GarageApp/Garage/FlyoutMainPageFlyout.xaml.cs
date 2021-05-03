using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GarageApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMainPageFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutMainPageFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutMainPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class FlyoutMainPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutMainPageFlyoutMenuItem> MenuItems { get; set; }
            
            public FlyoutMainPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutMainPageFlyoutMenuItem>(new[]
                {
                    new FlyoutMainPageFlyoutMenuItem { Id = 0, Title = "Your Parkings" },
                    new FlyoutMainPageFlyoutMenuItem { Id = 1, Title = "Payments" },
                    new FlyoutMainPageFlyoutMenuItem { Id = 2, Title = "Support" },
                    new FlyoutMainPageFlyoutMenuItem { Id = 3, Title = "Membership Pass" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}