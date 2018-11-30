using System;

namespace Actio.Common.Exceptions
{
    /// <summary>
    /// Actio custom exceptions
    /// </summary>
    public class ActioException : Exception
    {
        /// <summary>
        /// Exception code
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Instantiates an exception using the given code
        /// </summary>
        /// <param name="code">The exception code</param>
        public ActioException(string code)
        {
            Code = code;
        }

        public ActioException(string message, params object[] args) 
            : this(string.Empty, message, args)
        {
        }

        public ActioException(string code, string message, params object[] args) 
            : this(null, code, message, args)
        {
        }

        public ActioException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public ActioException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
