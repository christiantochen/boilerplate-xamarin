using System.Threading.Tasks;
using System.Windows.Input;
using Boilerplate.Features;
using Boilerplate.Services.Authentication;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Boilerplate.Popups
{
    public class TopMenuPopupModel : ViewModelBase
    {
        readonly IAuthenticationService authenticationService;

        public TopMenuPopupModel(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public ICommand LogoutCommand => new AsyncCommand(Logout);

        Task Logout(object obj)
        {
            return Task.WhenAll(
                authenticationService.LogoutAsync(),
                NavigationService.NavigateToAsync<LoginViewModel>(),
                PopupNavigation.Instance.PopAsync()
            );
        }
    }
}