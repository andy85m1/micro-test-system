namespace Actio.Common.Services
{
    /// <summary>
    /// The base builder
    /// </summary>
    public abstract class BuilderBase
    {
        /// <summary>
        /// Builds the service host
        /// </summary>
        /// <returns></returns>
        public abstract ServiceHost Build();
    }
}
