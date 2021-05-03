using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace GarageApp.Validators.Rules
{
    [Preserve(AllMembers = true)]
    public class IsPasswordMatchingRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            throw new NotImplementedException();

        }

        public bool CheckForPairs(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }
}
