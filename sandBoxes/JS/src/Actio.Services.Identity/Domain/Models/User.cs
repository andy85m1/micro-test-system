using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Services;
using System;

namespace Actio.Services.Identity.Domain.Models
{
    /// <summary>
    /// A user
    /// </summary>
    public class User
    {
        /// <summary>
        /// The user ID
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// The user email address
        /// </summary>
        public string Email { get; protected set; }

        /// <summary>
        /// The user name
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// The user password
        /// </summary>
        public string Password { get; protected set; }

        /// <summary>
        /// The secured string for the password
        /// </summary>
        public string Salt { get; protected set; }

        /// <summary>
        /// The user created timestamp
        /// </summary>
        public DateTime CreatedAt { get; protected set; }

        /// <summary>
        /// Protected constructor
        /// </summary>
        protected User()
        {
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="name">The user's name</param>
        public User(string email, string name)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ActioException("empty_user_email", $"User email cannot be empty.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ActioException("empty_user_name", $"User name cannot be empty.");

            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Set the user password
        /// </summary>
        /// <param name="password">The password to set</param>
        /// <param name="encryptor">The encryptor</param>
        public void SetPassword(string password, IEncryptor encryptor)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ActioException("empty_password", $"Password cannot be empty.");

            //Create the secured string from the password
            Salt = encryptor.GetSalt();

            //Apply the secured string to the password and return the hash
            Password = encryptor.GetHash(password, Salt);
        }

        /// <summary>
        /// Validate the user password
        /// </summary>
        /// <param name="password">The password to validate</param>
        /// <param name="encryptor">The encyptor</param>
        /// <returns>The outcome of the validation check</returns>
        public bool ValidatePassword(string password, IEncryptor encryptor)
            => Password.Equals(encryptor.GetHash(password, Salt));
    }
}
