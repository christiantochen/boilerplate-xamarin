using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Boilerplate.Services.Authentication;
using Boilerplate.Validations;
using Boilerplate.Shared;

namespace Boilerplate.Features
{
    public class LoginViewModel : ViewModelBase
    {
        ValidatableObject<string> username;
        ValidatableObject<string> password;

        readonly IAuthenticationService authenticationService;

        public LoginViewModel(IAuthenticationService authenticationService)
        {
            Title = Fixtures.TITLE_LOGIN;

            this.authenticationService = authenticationService;

            username = new ValidatableObject<string>();
            password = new ValidatableObject<string>();

            AddValidations();
        }

        public ValidatableObject<string> Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public ValidatableObject<string> Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        void AddValidations()
        {
            // TODO: FIXTURES
            username.Validations.Add(new IsNotNullOrEmptyRule<string>());
            password.Validations.Add(new IsNotNullOrEmptyRule<string>());
        }

        bool ValidateAll()
        {
            var usernameIsValid = username.Validate();
            var passwordIsValid = password.Validate();

            return usernameIsValid && passwordIsValid;
        }

        public ICommand LoginCommand => new AsyncCommand(LoginAsync);
        public ICommand ValidateCommand => new Command(Validate);

        async Task LoginAsync()
        {
            if (!ValidateAll())
                return;

            IsBusy = true;

            try
            {
                bool isAuth = await authenticationService.LoginAsync(username.Value, password.Value);

                if (isAuth)
                {
                    await NavigationService.NavigateToAsync<MainViewModel>();
                }
                else // TODO: FIXTURES
                {
                    DialogService.ShowToast("Username or Password incorrect");
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowToast(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        void Validate(object obj)
        {
            if (obj is ValidatableObject<string> validableObj)
            {
                validableObj.Validate();
            }
        }
    }
}
