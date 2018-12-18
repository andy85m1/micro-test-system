using Microsoft.AspNetCore.Hosting;
using RawRabbit;

namespace Actio.Common.Services
{
    /// <summary>
    /// Builds a host
    /// </summary>
    public class HostBuilder : BuilderBase
    {
        private readonly IWebHost _webHost;
        private IBusClient _bus;

        /// <summary>
        /// Instantiates a host builder
        /// </summary>
        /// <param name="webHost">A configured webhost</param>
        public HostBuilder(IWebHost webHost)
        {
            _webHost = webHost;
        }

        /// <summary>
        /// Creates a RabbitMQ BusBuilder instance
        /// </summary>
        /// <returns>The BusBuilder</returns>
        public BusBuilder UseRabbitMq()
        {
            _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));

            return new BusBuilder(_webHost, _bus);
        }

        /// <summary>
        /// Builds the service host using the web host
        /// </summary>
        /// <returns>The ServiceHost instance</returns>
        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }
    }
}
