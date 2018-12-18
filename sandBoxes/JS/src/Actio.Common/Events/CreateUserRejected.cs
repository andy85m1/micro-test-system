namespace Actio.Common.Events

{
    /// <summary>
    /// Create user rejected event
    /// </summary>
    public class CreateUserRejected : IRejectedEvent
    {
        /// <summary>
        /// The rejected user's email
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// The rejection code
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// The reason for rejection
        /// </summary>
        public string Reason { get; }

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
        /// /// <param name="code">The rejection code</param>
        /// <param name="reason">The reason for rejection</param>        
        public CreateUserRejected(string email, string code, string reason)
        {
            Email = email;
            Code = code;
            Reason = reason;   
        }
    }
}
