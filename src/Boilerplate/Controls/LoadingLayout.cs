using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Boilerplate.Controls
{
    public class LoadingLayout : StackLayout
    {
        public event EventHandler OnStarted;
        public event EventHandler OnCompleted;

        ActivityIndicator _loadingIndicator = new ActivityIndicator();

        public LoadingLayout()
        {
            AutomationId = Shared.AutomationId.Loading;
            BackgroundColor = Color.White;
            IsVisible = false;
            Opacity = 0;

            _loadingIndicator.Color = Color;
            _loadingIndicator.VerticalOptions = LayoutOptions.CenterAndExpand;
            _loadingIndicator.HorizontalOptions = LayoutOptions.CenterAndExpand;

            Children.Add(_loadingIndicator);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(IsRunning):
                    ToggleAnimation();
                    break;
                case nameof(Color):
                    _loadingIndicator.Color = Color;
                    break;
            }
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create("Color", typeof(Color), typeof(LoadingLayout), Color.Default);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty IsRunningProperty =
            BindableProperty.Create("IsRunning", typeof(bool), typeof(LoadingLayout), false);

        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        async void ToggleAnimation()
        {
            if (IsRunning)
            {
                ToggleIndicator();
                await this.FadeTo(1);

                OnStarted?.Invoke(this, null);
            }
            else
            {
                await this.FadeTo(0);
                ToggleIndicator();

                OnCompleted?.Invoke(this, null);
            }
        }

        void ToggleIndicator()
        {
            IsVisible =
            _loadingIndicator.IsVisible =
            _loadingIndicator.IsRunning =
                IsRunning;
        }
    }
}
