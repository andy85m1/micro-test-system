using System;
using System.Security.Cryptography;

namespace Actio.Services.Identity.Domain.Services
{
    /// <summary>
    /// An encryptor for hashing (with a salt) a password
    /// </summary>
    public class Encryptor : IEncryptor
    {
        /// <summary>
        /// The salt byte array size
        /// </summary>
        private static readonly int SaltSize = 40;
        
        /// <summary>
        /// The number of iterations to derive
        /// </summary>
        private static readonly int DeriveBytesIterationsCount = 10000;
        
        /// <summary>
        /// Returns a salt derived from the given value
        /// </summary>
        /// <param name="value">The value to generate the salt from</param>
        /// <returns>The salt</returns>
        public string GetSalt()
        {
            var random = new Random();
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Returns a hash derived from the given value and salt
        /// </summary>
        /// <param name="value">The value to hash</param>
        /// <param name="salt">The salt (secured string) to use to generate the hash</param>
        /// <returns>The hash</returns>
        public string GetHash(string value, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }        

        /// <summary>
        /// Converts the value to a byte array
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <returns>The converted byte array</returns>
        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];

            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
