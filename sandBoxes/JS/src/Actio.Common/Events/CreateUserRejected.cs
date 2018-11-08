namespace Actio.Common.Events

{
    /// <summary>
    /// Rejected create user event
    /// </summary>
    public class CreateUserRejected : IRejectedEvent
    {
        /// <summary>
        /// The rejected user's email
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// The reason for rejection
        /// </summary>
        public string Reason { get; }

        /// <summary>
        /// The rejection code
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Protected constructor
        /// </summary>
        protected CreateUserRejected()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="email">The rejected user's email</param>
        /// <param name="reason">The reason for rejection</param>
        /// <param name="code">The rejection code</param>
        public CreateUserRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
