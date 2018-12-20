namespace Actio.Services.Identity.Domain.Services
{
    /// <summary>
    /// Encryptor interface
    /// </summary>
    public interface IEncryptor
    {
        /// <summary>
        /// The password secured string
        /// </summary>
        /// <param name="value">The password to apply the salt</param>
        /// <returns>?The secured string</returns>
        string GetSalt();

        /// <summary>
        /// The password hash
        /// </summary>
        /// <param name="value">The password to hash</param>
        /// <param name="salt">The secured string to apply</param>
        /// <returns>The password hash</returns>
        string GetHash(string value, string salt);
    }
}
