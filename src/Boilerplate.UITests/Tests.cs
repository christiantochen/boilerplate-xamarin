using Boilerplate.Shared;
using NUnit.Framework;
using Xamarin.UITest;

namespace Boilerplate.UITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests : BaseTest
    {
        public Tests(Platform platform) : base(platform)
        {

        }

        [Test]
        public void FormHasAndValidErrorMessage()
        {
            // Act
            LoginView.TapLoginButton();

            LoginView.WaitForErrorLabel();

            // Assert
            Assert.IsEmpty(LoginView.Username);
            Assert.IsEmpty(LoginView.Password);
            Assert.AreEqual(LoginView.UsernameError, Fixtures.MESSAGE_INVALID_OBJECT_EMPTY);
            Assert.AreEqual(LoginView.PasswordError, Fixtures.MESSAGE_INVALID_OBJECT_EMPTY);
        }

        [Test]
        public void LoginExpectedToBeFail()
        {
            LoginView.WaitForViewToLoad();

            // Arrange
            var username = "fail";
            var password = "fail";

            // Act
            LoginView.SetCredentials(username, password);
            LoginView.WaitForNoErrorLabel();
            LoginView.TapLoginButton();
            LoginView.WaitForLoading();
            LoginView.WaitForLoadingFinish();
            LoginView.WaitForViewToLoad();
        }

        [Test]
        public void LoginExpectedToBeSucceed()
        {
            LoginView.WaitForViewToLoad();

            // Arrange
            var username = "54849";
            var password = "ppj";

            // Act
            LoginView.SetCredentials(username, password);
            LoginView.WaitForNoErrorLabel();
            LoginView.TapLoginButton();
            LoginView.WaitForLoading();
            LoginView.WaitForLoadingFinish();

            MainView.WaitForViewToLoad();
        }

        [Test]
        public void MainViewShouldBeFirstPageAfterLogin()
        {
            MainView.WaitForViewToLoad();
        }
    }
}
