using Xamarin.Forms.Internals;

namespace GarageApp.Validators.Rules
{
    /// <summary>
    /// Validation rule for check the email has empty or null.
    /// </summary>
    /// <typeparam name="T">Not null or empty rule parameter</typeparam>
    [Preserve(AllMembers = true)]
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the validation Message.
        /// </summary>
        public string ValidationMessage { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Check the Email has null or empty
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>returns bool value</returns>
        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = $"{value }";
            return !string.IsNullOrWhiteSpace(str);
        }

        public bool CheckForPairs(T value1, T value2)
        {
            if (value1 == null || value2 == null)
            {
                return false;
            }

            var str1 = $"{value1 }";
            var str2 = $"{value2 }";
            return !string.IsNullOrWhiteSpace(str1) && !string.IsNullOrWhiteSpace(str2);
        }

        #endregion
    }
}
