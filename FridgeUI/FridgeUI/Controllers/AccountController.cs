using FridgeUI.Interfaces;
using FridgeUI.Models.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using RestEase;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;

namespace FridgeUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private readonly IAuthenticationApi _authenticationApi;

        private readonly IFridgeApi _fridgeApi;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;

            _authenticationApi = RestClient.For<IAuthenticationApi>("https://localhost:5001/");
            _fridgeApi = RestClient.For<IFridgeApi>("https://localhost:5001/");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserForAuthenticationDto authentication)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var token = string.Empty;
            try
            {
                token = await _authenticationApi.Authenticate(authentication);
            }
            catch (Exception ex)
            {
                var message = ((RestEase.ApiException)ex).Content;
                ModelState.AddModelError(string.Empty, message);
                return View();
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            HttpContext.Response.Cookies.Append("JWT", token,
                new CookieOptions
                {
                    MaxAge = TimeSpan.FromMinutes(Convert.ToDouble(jwtSecurityToken.Payload.Exp)),
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    Secure = true
                });

            return RedirectToAction("Index", "Home", null);
        }
    }
}
