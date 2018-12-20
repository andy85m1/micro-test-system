using Microsoft.AspNetCore.Mvc;

namespace Actio.Services.Activities.Controllers
{
    /// <summary>
    /// The Home controller
    /// </summary>
    [Route("")]
    public class HomeController : Controller
    {
        /// <summary>
        /// GET HTTP request handler
        /// </summary>
        /// <returns>A 200 OK response containing the Activities service ID string</returns>
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Actio.Services.Activities API!");
    }
}