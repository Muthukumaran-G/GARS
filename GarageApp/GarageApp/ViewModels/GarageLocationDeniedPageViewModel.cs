using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace GarageApp.ViewModels
{
    /// <summary>
    /// ViewModel for location denied page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class GarageLocationDeniedPageViewModel : BaseViewModel
    {
        #region Fields
        public static GarageLocationDeniedPageViewModel locationDeniedPageViewModel;
        private string imagePath;

        private string header;

        private string content;

        private Command gobackCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="GarageLocationDeniedPageViewModel" /> class.
        /// </summary>
        public GarageLocationDeniedPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        #endregion

        #region Properties


        public GarageLocationDeniedPageViewModel BindingContext =>
            locationDeniedPageViewModel = PopulateData<GarageLocationDeniedPageViewModel>("errorAndEmpty.json");

        public INavigation navigation;
        public INavigation Navigation
        {
            get
            {
                return navigation;
            }
            set
            {
                navigation = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the ImagePath.
        /// </summary>
        [DataMember(Name = "locationDeniedImagePath")]
        public string ImagePath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.SetProperty(ref this.imagePath, value);
            }
        }

        /// <summary>
        /// Gets or sets the Header.
        /// </summary>
        [DataMember(Name = "locationDeniedHeader")]
        public string Header
        {
            get
            {
                return this.header;
            }

            set
            {
                this.SetProperty(ref this.header, value);
            }
        }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        [DataMember(Name = "locationDeniedContent")]
        public string Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.SetProperty(ref this.content, value);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the command that is executed when the Go back button is clicked.
        /// </summary>
        public Command GoBackCommand
        {
            get
            {
                return this.gobackCommand ?? (this.gobackCommand = new Command(this.GoBack));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "GarageApp.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T data;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                data = (T)serializer.ReadObject(stream);
            }

            return data;
        }

        /// <summary>
        /// Invoked when the Go back button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void GoBack(object obj)
        {
            var location = await App.GetLocation().ConfigureAwait(false);
            if (location != null)
                Device.BeginInvokeOnMainThread(() =>
                { Navigation.PopToRootAsync(); });
        }

        #endregion      
    }
}
