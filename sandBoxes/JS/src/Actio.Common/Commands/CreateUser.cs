namespace Actio.Common.Commands
{
    /// <summary>
    /// The create user command
    /// </summary>
    public class CreateUser : ICommand
    {
        /// <summary>
        /// The new user's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The new user's password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The new user's name
        /// </summary>
        public string Name { get; set; }
    }
}
