using Microsoft.AspNetCore.Mvc;

namespace Actio.Api.Controllers
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
        /// <returns>A 200 OK response containing the API ID string</returns>
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Actio API!");
    }
}