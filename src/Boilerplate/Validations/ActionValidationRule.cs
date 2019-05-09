using System;
using Xamarin.Forms;

namespace Boilerplate.Validations
{
    public class ActionValidationRule<T> : IValidationRule<T>
    {
        private readonly Func<T, bool> predicate;

        public string ValidationMessage { get; set; }

        public ActionValidationRule(Func<T, bool> predicate, string validationMessage)
        {
            this.predicate = predicate;
            ValidationMessage = validationMessage;
        }

        public bool Check(T value)
        {
            return predicate.Invoke(value);
        }
    }
}
