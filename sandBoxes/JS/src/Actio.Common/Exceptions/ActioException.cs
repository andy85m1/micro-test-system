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

        /// <summary>
        /// Instantiates an exception using the given message
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="args"></param>
        public ActioException(string message, params object[] args) 
            : this(string.Empty, message, args)
        {
        }

        /// <summary>
        /// Instantiates an exception using the given code and message
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public ActioException(string code, string message, params object[] args) 
            : this(null, code, message, args)
        {
        }

        /// <summary>
        /// Instantiates an exception using the given inner exception and message
        /// </summary>
        /// <param name="innerException"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public ActioException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        /// <summary>
        /// Instantiates an exception using the given inner exception, code and message
        /// </summary>
        /// <param name="innerException"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public ActioException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
