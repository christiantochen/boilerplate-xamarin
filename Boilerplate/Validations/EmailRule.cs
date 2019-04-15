using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Validations
{
    public class EmailRule : IValidationRule<string>
    {
        public EmailRule()
        {
            ValidationMessage = "Should be an email address";
        }

        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            return new EmailAddressAttribute().IsValid(value);
        }
    }
}
