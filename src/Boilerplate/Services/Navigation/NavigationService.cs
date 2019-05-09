using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Boilerplate.Features;
using Boilerplate.Services.Authentication;

namespace Boilerplate.Services.Navigation
{
    public partial class NavigationService : INavigationService
    {
        readonly IAuthenticationService _authenticationService;

        protected Application CurrentApplication => Application.Current;

        public NavigationService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task InitializeAsync()
        {
            if (await _authenticationService.HasTokenAndValidAsync())
            {
                await NavigateToAsync<MainViewModel>();
            }
            else
            {
                await NavigateToAsync<LoginViewModel>();
            }
        }

        public Task NavigateToAsync<TViewModel>(object parameter = null) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter = null)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            return Task.FromResult(true);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var view = Bootstrap.Instance.GetView(viewModelType);

            if (view is LoginView)
            {
                CurrentApplication.MainPage = view;
            }
            else if (view is MainView)
            {
                var page = new NavigationPage(view);
                NavigationPage.SetHasNavigationBar(view, false);
                CurrentApplication.MainPage = page;
            }
            else if (CurrentApplication.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.PushAsync(view);
            }

            await (view.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

    }
}
