using System.Threading.Tasks;
using Boilerplate.Shared;
using Xamarin.Forms;

namespace Boilerplate.Features
{
    public class WorkViewModel : ViewModelBase, IHandleViewAppearing, IHandleViewDisappearing
    {
        public WorkViewModel()
        {
            Title = Fixtures.TITLE_WORK;
            Icon = Fixtures.ICON_WORK;
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