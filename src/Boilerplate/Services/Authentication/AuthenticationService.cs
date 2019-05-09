using System;
using System.Threading.Tasks;
using Boilerplate.Shared;
using RestEase;
using Xamarin.Essentials;

namespace Boilerplate.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IAuthenticationAPI api;

        public AuthenticationService()
        {
            api = RestClient.For<IAuthenticationAPI>(Fixtures.LOCALHOST_IP);
        }

        public async Task<bool> HasTokenAndValidAsync()
        {
            var token = await SecureStorage.GetAsync(Fixtures.SECURE_STORAGE_TOKEN_KEY);

            var hasToken = !token.IsNullOrWhiteSpace();

            // TODO: CHECK API
            var isValid = true;

            return hasToken && isValid;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var response = await api.Login(username, password);

            await SecureStorage.SetAsync(Fixtures.SECURE_STORAGE_TOKEN_KEY, response.Token);

            return true;
        }

        public Task LogoutAsync()
        {
            SecureStorage.Remove(Fixtures.SECURE_STORAGE_TOKEN_KEY);

            // TODO: LOGOUT API

            return Task.CompletedTask;
        }
    }
}
