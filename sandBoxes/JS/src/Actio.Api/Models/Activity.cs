using System;

namespace Actio.Api.Models
{
    /// <summary>
    /// Activity Data Transfer Object (DTO) model. 
    /// Allows a cut down version of a model to be returned to the client rather than serialising, 
    /// and pushing through the bus, a large model. Add or remove properties as required
    /// </summary>
    public class ActivityDTO
    {
        /// <summary>
        /// The activity ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The activity name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The activity description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The activity's creator
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// The activity created timestamp
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
