namespace Actio.Common.Auth
{
    public class JsonWebToken
    {
        /// <summary>
        /// The JWT token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The expire time
        /// </summary>
        public long Expires { get; set; }
    }
}
