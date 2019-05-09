using System.Threading.Tasks;
using Xamarin.Forms;
using Boilerplate.Services.Dialog;
using Boilerplate.Services.Navigation;

namespace Boilerplate.Features
{
    public class ViewModelBase : BindableObject
    {
        bool isBusy;
        string title;
        string icon;

        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        public ViewModelBase()
        {
            DialogService = Bootstrap.Instance.Resolve<IDialogService>();
            NavigationService = Bootstrap.Instance.Resolve<INavigationService>();
        }

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get => icon;
            set
            {
                icon = value;
                OnPropertyChanged();
            }
        }

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(false);
        }
    }
}
