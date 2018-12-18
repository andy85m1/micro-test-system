using Microsoft.AspNetCore.Mvc;

namespace Actio.Services.Identity.Controllers
{
    /// <summary>
    /// The home controller
    /// </summary>
    [Route("")]
    public class HomeController : Controller
    {
        /// <summary>
        /// GET HTTP request handler
        /// </summary>
        /// <returns>A 200 OK response containing the Identity service ID string</returns>
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Actio.Services.Identity API!");
    }
}