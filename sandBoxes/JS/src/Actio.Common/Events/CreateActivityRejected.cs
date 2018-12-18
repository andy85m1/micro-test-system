using System;

namespace Actio.Common.Events
{
    /// <summary>
    /// Create activity rejected event
    /// </summary>
    public class CreateActivityRejected : IRejectedEvent
    {
        /// <summary>
        /// The activity ID
        /// </summary>
        public Guid Id { get; set; }
                
        /// <summary>
        /// The activity rejection code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The reasons for rejecting the activity
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Protected constructor
        /// </summary>
        protected CreateActivityRejected()
        {
        }

        /// <summary>
        /// Instantiates a create activity rejected event
        /// </summary>
        /// <param name="id">The activity ID</param>
        /// <param name="code">The rejection code</param>
        /// <param name="reason">The reason for rejecting the activity</param>
        public CreateActivityRejected(Guid id, string code, string reason)
        {
            Id = id;
            Code = code;
            Reason = reason;
        }
    }
}
