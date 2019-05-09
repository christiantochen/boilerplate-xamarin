using System.Linq;
using Boilerplate.Shared;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Boilerplate.UITests
{
    public class LoginView : BaseView
    {
        readonly Query loginButton, usernameEntry, usernameErrorLabel, passwordEntry, passwordErrorLabel;

        public string Username => App.Query(usernameEntry)?.FirstOrDefault()?.Text ?? string.Empty;
        public string Password => App.Query(passwordEntry)?.FirstOrDefault()?.Text ?? string.Empty;
        public string UsernameError => App.Query(usernameErrorLabel)?.FirstOrDefault()?.Text ?? string.Empty;
        public string PasswordError => App.Query(passwordErrorLabel)?.FirstOrDefault()?.Text ?? string.Empty;

        public LoginView(IApp app, string pageTitle, string pageIcon = null) : base(app, pageTitle, pageIcon)
        {
            loginButton = x => x.Marked(AutomationId.LoginView_LoginButton);
            usernameEntry = x => x.Marked(AutomationId.LoginView_UsernameEntry);
            usernameErrorLabel = x => x.Marked(AutomationId.LoginView_UsernameErrorLabel);
            passwordEntry = x => x.Marked(AutomationId.LoginView_PasswordEntry);
            passwordErrorLabel = x => x.Marked(AutomationId.LoginView_PasswordErrorLabel);
        }

        public void SetCredentials(string username, string password)
        {
            App.EnterText(usernameEntry, username);
            App.EnterText(passwordEntry, password);
        }

        public void TapLoginButton()
        {
            App.Tap(loginButton);
        }

        public void WaitForErrorLabel()
        {
            App.WaitForElement(usernameErrorLabel);
            App.WaitForElement(passwordErrorLabel);
        }

        public void WaitForNoErrorLabel()
        {
            App.WaitForNoElement(usernameErrorLabel);
            App.WaitForNoElement(passwordErrorLabel);
        }
    }
}
