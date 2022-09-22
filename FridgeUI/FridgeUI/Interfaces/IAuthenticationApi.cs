using FridgeUI.Models.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using RestEase;
using System.Threading.Tasks;

namespace FridgeUI.Interfaces
{
    [Header("Authentication-Agent", "RestEase")]
    public interface IAuthenticationApi
    {
        [Post("api/authentication")]
        Task<string> RegisterUser([Body] UserForRegistrationDto userForRegistration);

        [Post("api/authentication/login")]
        Task<string> Authenticate([Body] UserForAuthenticationDto user);
    }
}
