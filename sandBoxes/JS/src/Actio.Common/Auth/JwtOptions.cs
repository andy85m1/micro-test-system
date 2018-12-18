namespace Actio.Common.Auth
{
    /// <summary>
    /// Json Web Token options
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// The secret key defined in the jwt jsonobject in the appsettings.json file
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// The amount of time (int minutes) which the token is valid for
        /// </summary>
        public int ExpiryMinutes { get; set; }

        /// <summary>
        /// The token issuer (url:port)
        /// </summary>
        public string Issuer { get; set; }
    }
}
