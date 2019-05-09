using System.Collections.Generic;
using System.Linq;
using Boilerplate.Validations;

namespace Xamarin.Forms
{
    public class ValidatableObject<T> : BindableObject, IValidableObject
    {
        private bool _isValid;
        private T _value;

        public List<string> Errors { get; private set; }
        public List<IValidationRule<T>> Validations { get; }

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject()
        {
            _isValid = true;
            Errors = new List<string>();
            Validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors = Validations.Where(v => !v.Check(Value))
                                .Select(v => v.ValidationMessage)
                                .ToList();

            OnPropertyChanged(nameof(Errors));

            return IsValid = !Errors.Any();
        }
    }
}
