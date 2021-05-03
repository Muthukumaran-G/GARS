using GarageApp.ViewModels;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GarageApp.Views
{
    /// <summary>
    /// Page to show the no internet connection error
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GarageNoInternetPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GarageNoInternetPage" /> class.
        /// </summary>
        public GarageNoInternetPage()
        {
            this.InitializeComponent();
            this.BindingContext = GarageNoInternetPageViewModel.BindingContext;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}