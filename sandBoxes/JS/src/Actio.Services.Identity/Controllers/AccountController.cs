using Actio.Common.Commands;
using Actio.Services.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Actio.Services.Identity.Controllers
{
    /// <summary>
    /// The account controller
    /// </summary>
    [Route("")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Instantiates the account controller
        /// </summary>
        /// <param name="userService">The user service</param>
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// HTTP request handler: Sends the <see cref="AuthenticateUser"/> command to the bus and logs in using the credentials
        /// </summary>
        /// <param name="command">The <see cref="AuthenticateUser"/> command</param>
        /// <returns>A Json Web Token</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUser command)
            => Json(await _userService.LoginAsync(command.Email, command.Password));
    }
}
