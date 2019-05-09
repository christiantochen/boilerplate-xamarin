using Xamarin.UITest;

namespace Boilerplate.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .PreferIdeSettings()
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}