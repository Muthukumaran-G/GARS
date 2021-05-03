using GarageApp.ViewModels;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GarageApp.Views
{
    /// <summary>
    /// Page to show the location denied
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GarageLocationDeniedPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GarageLocationDeniedPage" /> class.
        /// </summary>
        public GarageLocationDeniedPage()
        {
            this.InitializeComponent();
            var data = new GarageLocationDeniedPageViewModel(this.Navigation).BindingContext;
            data.Navigation = this.Navigation;
            this.BindingContext = data;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}