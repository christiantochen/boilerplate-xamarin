using System.ComponentModel.DataAnnotations;

namespace Boilerplate.Validations
{
    public class ValidUrlRule : IValidationRule<string>
    {
        public ValidUrlRule()
        {
            ValidationMessage = "Should be an URL";
        }

        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            return new UrlAttribute().IsValid(value);
        }
    }
}
