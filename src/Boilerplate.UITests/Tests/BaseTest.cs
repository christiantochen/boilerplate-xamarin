using Boilerplate.Shared;
using NUnit.Framework;
using Xamarin.UITest;

namespace Boilerplate.UITests
{
    public abstract class BaseTest
    {
        readonly Platform platform;

        protected BaseTest(Platform platform) => this.platform = platform;

        protected IApp App { get; private set; }
        protected LoginView LoginView { get; private set; }
        protected MainView MainView { get; private set; }

        [SetUp]
        public virtual void Setup()
        {
            App = AppInitializer.StartApp(platform);

            LoginView = new LoginView(App, Fixtures.TITLE_LOGIN);
            MainView = new MainView(App, Fixtures.TITLE_MAIN);
        }
    }
}
