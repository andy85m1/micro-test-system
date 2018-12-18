using System;

namespace Actio.Common.Commands
{
    /// <summary>
    /// The create activity command
    /// </summary>
    public class CreateActivity : IAuthenticatedCommand
    {
        /// <summary>
        /// The activity's unique ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The user ID of the activity creator 
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The category of the activity
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The name of the activity
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the activity
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The activity creation time stamp
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
