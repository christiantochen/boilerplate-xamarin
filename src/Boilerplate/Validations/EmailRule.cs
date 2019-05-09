using System;
using System.Text.RegularExpressions;
using Boilerplate.Shared;
using Xamarin.Forms;

namespace Boilerplate.Validations
{
    public class EmailRule : IValidationRule<string>
    {
        Regex regex = new Regex(Fixtures.REGEX_EMAIL);

        public EmailRule()
        {
            ValidationMessage = Fixtures.MESSAGE_INVALID_FORMAT_EMAIL;
        }

        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            if (value.IsNullOrWhiteSpace())
                return true;

            return regex.IsMatch(value.Trim());
        }
    }
}
