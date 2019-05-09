using System.Threading.Tasks;
using Boilerplate.Shared;
using Xamarin.Forms;

namespace Boilerplate.Features
{
    public class MainViewModel : ViewModelBase, IHandleViewAppearing, IHandleViewDisappearing
    {
        public MainViewModel()
        {
            Title = Fixtures.TITLE_MAIN;
        }

        public override Task InitializeAsync(object parameter)
        {
            return base.InitializeAsync(parameter);
        }

        public Task OnViewAppearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }

        public Task OnViewDisappearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }
    }
}
