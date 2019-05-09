using Xamarin.Forms;

namespace Boilerplate.Features
{
    public partial class MainView : TabbedPage
    {
        public MainView()
        {
            InitializeComponent();

            Children.Add(Bootstrap.Instance.GetView<MapViewModel>());
            Children.Add(Bootstrap.Instance.GetView<WorkViewModel>());
            Children.Add(Bootstrap.Instance.GetView<PersonViewModel>());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is IHandleViewAppearing viewAware)
            {
                await viewAware.OnViewAppearingAsync(this);
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is IHandleViewDisappearing viewAware)
            {
                await viewAware.OnViewDisappearingAsync(this);
            }
        }
    }
}
