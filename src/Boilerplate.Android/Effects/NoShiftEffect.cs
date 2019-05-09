using Android.Views;
using Android.Support.Design.BottomNavigation;
using Android.Support.Design.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

[assembly: ResolutionGroupName("Boilerplate")]
[assembly: ExportEffect(typeof(Boilerplate.Droid.Effects.NoShiftEffect), "NoShiftEffect")]
namespace Boilerplate.Droid.Effects
{
    public class NoShiftEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (!(Container.GetChildAt(0) is ViewGroup layout))
                return;

            if (!(layout.GetChildAt(1) is BottomNavigationView bottomNavigationView))
                return;

            // This is what we set to adjust if the shifting happens
            bottomNavigationView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityLabeled;
        }

        protected override void OnDetached()
        {
        }
    }
}