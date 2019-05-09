using System;
using System.Threading.Tasks;
using Boilerplate.Models;

namespace Boilerplate.Services.Authentication
{
    public interface IAuthenticationService
    {
        //bool IsAuthenticated { get; }

        //User AuthenticatedUser { get; }

        Task<bool> LoginAsync(string email, string password);

        Task<bool> HasTokenAndValidAsync();

        Task LogoutAsync();
    }
}
