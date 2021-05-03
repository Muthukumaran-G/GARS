using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GarageApp.Views
{
    /// <summary>
    /// Page to retrieve the password forgotten.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GarageForgotPasswordPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GarageForgotPasswordPage" /> class.
        /// </summary>
        public GarageForgotPasswordPage()
        {
            this.InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}