using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GarageApp.Views
{
    /// <summary>
    /// Page to sign in with user details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GarageSignUpPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GarageSignUpPage" /> class.
        /// </summary>
        public GarageSignUpPage()
        {
            this.InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}