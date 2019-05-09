using static Xamarin.Essentials.Preferences;

namespace Boilerplate
{
    public static class Preferences
    {
        public static bool UseFakes
        {
            get => Get(nameof(UseFakes), false);
            set => Set(nameof(UseFakes), value);
        }
    }
}

