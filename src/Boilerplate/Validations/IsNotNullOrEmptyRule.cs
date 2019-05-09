using System;
using Boilerplate.Shared;
using Xamarin.Forms;

namespace Boilerplate.Validations
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public IsNotNullOrEmptyRule()
        {
            ValidationMessage = Fixtures.MESSAGE_INVALID_OBJECT_EMPTY;
        }

        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value is string stringValue)
            {
                return !string.IsNullOrWhiteSpace(stringValue);
            }

            return !(value == default);
        }
    }
}
