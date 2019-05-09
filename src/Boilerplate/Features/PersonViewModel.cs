using System.Threading.Tasks;
using Boilerplate.Shared;
using Xamarin.Forms;

namespace Boilerplate.Features
{
    public class PersonViewModel : ViewModelBase, IHandleViewAppearing, IHandleViewDisappearing
    {
        public PersonViewModel()
        {
            Title = Fixtures.TITLE_PERSON;
            Icon = Fixtures.ICON_PERSON;
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