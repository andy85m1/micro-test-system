using System;

namespace Actio.Api.Models
{
    /// <summary>
    /// User Data Transfer Object (DTO) model. 
    /// Allows a cut down version of a model to be returned to the client rather than serialising, 
    /// and pushing through the bus, a large model. Add or remove properties as required
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// The user ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The user email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The user name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The secured string for the password
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// The user created timestamp
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
