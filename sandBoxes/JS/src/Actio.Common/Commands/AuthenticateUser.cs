namespace Actio.Common.Commands
{
    public class AuthenticateUser : ICommand
    {
        /// <summary>
        /// The email address to authenticate
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The password to authenticate
        /// </summary>
        public string Password { get; set; }
    }
}
