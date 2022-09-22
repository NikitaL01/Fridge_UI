using Microsoft.AspNetCore.Mvc;
using RestEase;

namespace FridgeUI.Interfaces
{
    public interface IRootApi
    {
        [Get("api")]
        IActionResult GetRoot([Header("Accept")] string mediaType);
    }
}
