namespace Actio.Common.Events
{
    /// <summary>
    /// User Authenticated event
    /// </summary>
    public class UserAuthenticated : IEvent
    {
        /// <summary>
        /// The authenticated user's email
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Protected constructor
        /// </summary>
        protected UserAuthenticated()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="email">The authenticated user's email</param>
        public UserAuthenticated(string email)
        {
            Email = email;
        }
    }
}
