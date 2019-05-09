using System.Threading.Tasks;
using System.Windows.Input;
using Boilerplate.Popups;
using Boilerplate.Shared;
using Xamarin.Forms;

namespace Boilerplate.Features
{
    public class MapViewModel : ViewModelBase, IHandleViewAppearing, IHandleViewDisappearing
    {
        public MapViewModel()
        {
            Title = Fixtures.TITLE_MAP;
            Icon = Fixtures.ICON_MAP;
        }

        public ICommand TopMenuPopupCommand => new AsyncCommand(async () => await NavigationService.NavigateToPopupAsync<TopMenuPopupModel>(true));

        public override Task InitializeAsync(object parameter)
        {
            return base.InitializeAsync(parameter);
        }

        public async Task OnViewAppearingAsync(VisualElement view)
        {
            await Task.Delay(2000);
        }

        public Task OnViewDisappearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }
    }
}