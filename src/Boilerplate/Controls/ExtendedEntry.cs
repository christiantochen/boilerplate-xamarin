using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Boilerplate.Controls
{
    public class ExtendedEntry : Entry
    {
        public ExtendedEntry()
        {
            Focused += OnFocused;
            Unfocused += OnUnfocused;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(IsValid):
                    CheckValidity();
                    break;
            }
        }

        public static readonly BindableProperty PaddingProperty =
            BindableProperty.Create("Padding", typeof(Thickness), typeof(ExtendedEntry), default);

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        #region Validatable Extensions

        Color? _lineColorToApply;
        public Color LineColorToApply
        {
            get
            {
                return _lineColorToApply ?? GetNormalStateLineColor();
            }
            private set
            {
                _lineColorToApply = value;
                OnPropertyChanged(nameof(LineColorToApply));
            }
        }

        public static readonly BindableProperty CursorColorProperty =
            BindableProperty.Create("CursorColor", typeof(Color), typeof(ExtendedEntry), Color.Default);

        public Color CursorColor
        {
            get { return (Color)GetValue(CursorColorProperty); }
            set { SetValue(CursorColorProperty, value); }
        }

        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create("LineColor", typeof(Color), typeof(ExtendedEntry), Color.Default);

        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        public static readonly BindableProperty FocusLineColorProperty =
            BindableProperty.Create("FocusLineColor", typeof(Color), typeof(ExtendedEntry), Color.Default);

        public Color FocusLineColor
        {
            get { return (Color)GetValue(FocusLineColorProperty); }
            set { SetValue(FocusLineColorProperty, value); }
        }

        public static readonly BindableProperty InvalidColorProperty =
            BindableProperty.Create("InvalidColor", typeof(Color), typeof(ExtendedEntry), Color.Default);

        public Color InvalidColor
        {
            get { return (Color)GetValue(InvalidColorProperty); }
            set { SetValue(InvalidColorProperty, value); }
        }

        public static readonly BindableProperty InvalidIconProperty =
            BindableProperty.Create("InvalidIcon", typeof(FileImageSource), typeof(ExtendedEntry), null);

        public FileImageSource InvalidIcon
        {
            get { return (FileImageSource)GetValue(InvalidIconProperty); }
            set { SetValue(InvalidIconProperty, value); }
        }

        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create("IsValid", typeof(bool), typeof(ExtendedEntry), true);

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        void OnFocused(object sender, FocusEventArgs e)
        {
            IsValid = true;
            LineColorToApply = GetFocusStateLineColor();
        }

        void OnUnfocused(object sender, FocusEventArgs e) => LineColorToApply = GetNormalStateLineColor();

        void CheckValidity()
        {
            if (!IsValid) LineColorToApply = GetInvalidStateLineColor();
        }

        Color GetNormalStateLineColor() => LineColor != Color.Default ? LineColor : TextColor;
        Color GetFocusStateLineColor() => FocusLineColor != Color.Default ? FocusLineColor : TextColor;
        Color GetInvalidStateLineColor() => InvalidColor != Color.Default ? InvalidColor : GetNormalStateLineColor();

        #endregion  
    }
}
