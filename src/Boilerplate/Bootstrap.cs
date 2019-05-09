using System;
using System.Collections.Generic;
using Autofac;
using Boilerplate.Services.Authentication;
using Boilerplate.Services.Dialog;
using Boilerplate.Services.Navigation;
using Boilerplate.Features;
using Xamarin.Forms;
using Boilerplate.Popups;

namespace Boilerplate
{
    public class Bootstrap
    {
        private static readonly Lazy<Bootstrap> lazyInstance = new Lazy<Bootstrap>(() => new Bootstrap(), true);
        public static Bootstrap Instance => lazyInstance.Value;

        private IContainer container;
        private readonly ContainerBuilder containerBuilder = new ContainerBuilder();
        private readonly Dictionary<Type, Type> mappings = new Dictionary<Type, Type>();

        private Bootstrap()
        {
            RegisterAppViews();
            RegisterPopupViews();
            RegisterAppServices();
        }

        void RegisterAppViews()
        {
            RegisterView<LoginView, LoginViewModel>();
            RegisterView<MainView, MainViewModel>();
            RegisterView<MapView, MapViewModel>();
            RegisterView<PersonView, PersonViewModel>();
            RegisterView<WorkView, WorkViewModel>();
        }

        void RegisterPopupViews()
        {
            RegisterView<PickerPopup, PickerPopupModel>();
            RegisterView<TopMenuPopup, TopMenuPopupModel>();
        }

        void RegisterAppServices()
        {
            RegisterService<INavigationService, NavigationService>();
            RegisterService<IDialogService, DialogService>();

            if (Preferences.UseFakes)
            {
                RegisterFakeServices();
            }
            else
            {
                RegisterService<IAuthenticationService, AuthenticationService>();
            }
        }

        void RegisterFakeServices()
        {
            RegisterService<IAuthenticationService, FakeAuthenticationService>();
        }

        public T Resolve<T>() => container.Resolve<T>();

        public object Resolve(Type type) => container.Resolve(type);

        public void RegisterService<TInterface, TImplementation>() where TImplementation : TInterface
            => containerBuilder.RegisterType<TImplementation>().As<TInterface>();

        public void RegisterView<TView, TViewModel>()
            where TView : Page
            where TViewModel : ViewModelBase
        {
            containerBuilder.RegisterType<TViewModel>();
            mappings.Add(typeof(TViewModel), typeof(TView));
        }

        public void Build() => container = containerBuilder.Build();

        public Page GetView<TViewModel>() where TViewModel : ViewModelBase => GetView(typeof(TViewModel));

        public Page GetView(Type viewModelType)
        {
            var pageType = GetPageTypeForViewModel(viewModelType);
            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on mappings");

            return mappings[viewModelType];
        }
    }
}
