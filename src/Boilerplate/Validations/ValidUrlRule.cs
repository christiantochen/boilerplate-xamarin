using System;
using Boilerplate.Shared;
using Xamarin.Forms;

namespace Boilerplate.Validations
{
    public class ValidUrlRule : IValidationRule<string>
    {
        public ValidUrlRule()
        {
            ValidationMessage = Fixtures.MESSAGE_INVALID_FORMAT_URL;
        }

        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            return Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute);
        }
    }
}
