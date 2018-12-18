namespace Actio.Common.Events
{
    /// <summary>
    /// User Created event
    /// </summary>
    public class UserCreated : IEvent
    {
        /// <summary>
        /// The created user's email address
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// The created user's name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Protected constructor
        /// </summary>
        protected UserCreated()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="email">The created user's email address</param>
        /// <param name="name">The created user's name</param>
        public UserCreated(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
