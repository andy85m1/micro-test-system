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
        /// REST Get action
        /// </summary>
        /// <returns>A string content message</returns>
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Actio.Services.Activites API!");
    }
}