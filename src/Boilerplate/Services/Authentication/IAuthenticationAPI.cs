using System.Threading.Tasks;
using Boilerplate.Models;
using RestEase;

namespace Boilerplate.Services.Authentication
{
    [Header("Content-Type", "json/application")]
    public interface IAuthenticationAPI
    {
        [Post("login")]
        Task<AuthenticationResponse> Login(string username, string password);
    }
}
