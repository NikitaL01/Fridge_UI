using FridgeUI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestEase;
using System.Threading.Tasks;

namespace FridgeUI.Controllers
{
    public class FridgeController : Controller
    {
        private readonly ILogger<FridgeController> _logger;

        private readonly IFridgeApi _fridgeApi;

        public FridgeController(ILogger<FridgeController> logger)
        {
            _logger = logger;
            _fridgeApi = RestClient.For<IFridgeApi>("https://localhost:5001/");
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetFridges()
        {
            var result = await _fridgeApi.GetFridges();

            return View(result);
        }
    }
}
