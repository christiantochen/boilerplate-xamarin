using System.ComponentModel;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Boilerplate.Controls;

[assembly: Xamarin.Forms.ExportRenderer(typeof(ExtendedEntry), typeof(Boilerplate.Droid.Renderers.ExtendedEntryRenderer))]
namespace Boilerplate.Droid.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntry ExtendedElement => Element as ExtendedEntry;

        public ExtendedEntryRenderer(Context context) : base(context) => AutoPackage = false;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                UpdateLineColor();
                UpdatePadding();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(ExtendedEntry.CursorColor):
                    UpdateCursorColor();
                    break;
                case nameof(ExtendedEntry.LineColorToApply):
                    UpdateLineColor();
                    break;
                case nameof(ExtendedEntry.InvalidColor):
                case nameof(ExtendedEntry.InvalidIcon):
                case nameof(ExtendedEntry.IsValid):
                    //UpdateValidity();
                    break;
                case nameof(ExtendedEntry.Padding):
                    UpdatePadding();
                    break;
            }
        }

        //void UpdateValidity()
        //{
        //    if (!ExtendedElement.IsValid)
        //    {
        //        var invalidIcon = Context.GetIconizeDrawable(ExtendedElement.InvalidIcon,
        //                                                     (Int32)ExtendedElement.HeightRequest,
        //                                                     ExtendedElement.InvalidColor);

        //        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, invalidIcon, null);
        //    }
        //    else
        //    {
        //        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, null, null);
        //    }
        //}

        void UpdateCursorColor()
        {
            //Control?.color = ExtendedElement.CursorColor;
        }

        void UpdateLineColor()
        {
            Control?.Background?.SetColorFilter(ExtendedElement.LineColorToApply.ToAndroid(),
                                                Android.Graphics.PorterDuff.Mode.SrcAtop);
        }

        void UpdatePadding()
        {
            var padding = ExtendedElement.Padding;

            if (padding == default)
                return;

            Control?.SetPadding(
                (int)Context.ToPixels(padding.Left),
                (int)Context.ToPixels(padding.Top),
                (int)Context.ToPixels(padding.Right),
                (int)Context.ToPixels(padding.Bottom)
            );
        }
    }
}

