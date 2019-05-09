using System;
using System.Threading.Tasks;
using Boilerplate.Shared;
using Xamarin.Essentials;

namespace Boilerplate.Services.Authentication
{
    public class FakeAuthenticationService : IAuthenticationService
    {
        public async Task<bool> LoginAsync(string username, string password)
        {
            await Task.Delay(2000);

            if (username == "fail" && password == "fail")
                return false;

            await SecureStorage.SetAsync(Fixtures.SECURE_STORAGE_TOKEN_KEY, "secret-oauth-token-value");

            return true;
        }

        public Task LogoutAsync()
        {
            SecureStorage.Remove(Fixtures.SECURE_STORAGE_TOKEN_KEY);

            return Task.FromResult(true);
        }

        public async Task<bool> HasTokenAndValidAsync()
        {
            var token = await SecureStorage.GetAsync(Fixtures.SECURE_STORAGE_TOKEN_KEY);

            return !token.IsNullOrWhiteSpace();
        }
    }
}
