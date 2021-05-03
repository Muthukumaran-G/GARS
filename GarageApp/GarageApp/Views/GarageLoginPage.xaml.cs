using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GarageApp.Views
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GarageLoginPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GarageLoginPage" /> class.
        /// </summary>
        public GarageLoginPage()
        {
            this.InitializeComponent();
        }
    }
}