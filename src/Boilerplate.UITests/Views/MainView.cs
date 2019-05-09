using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Boilerplate.UITests
{
    public class MainView : BaseView
    {
        readonly Query loginButton, usernameEntry, usernameErrorLabel, passwordEntry, passwordErrorLabel;

        public MainView(IApp app, string pageTitle, string pageIcon = null) : base(app, pageTitle, pageIcon)
        {
        }
    }
}
