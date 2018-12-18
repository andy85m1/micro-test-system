using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Actio.Common.Services
{
    /// <summary>
    /// The service host
    /// </summary>
    public partial class ServiceHost : IServiceHost
    {
        private readonly IWebHost _webHost;

        /// <summary>
        /// Instantiates the service host
        /// </summary>
        /// <param name="webHost">The configured web host</param>
        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }

        /// <summary>
        /// Runs the configured web host
        /// </summary>
        public void Run() => _webHost.Run();

        /// <summary>
        /// Creates a <see cref="IStartup"/> type
        /// </summary>
        /// <typeparam name="TStartup">The startup type</typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static HostBuilder Create<TStartup>(string[] args) where TStartup : class
        {
            //Set the console window title to the namespace of the type
            Console.Title = typeof(TStartup).Namespace;

            //Create the configuration
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()  //Load the environment variables
                .AddCommandLine(args)       //Load the command line variables
                .Build();                   //Build the configuration

            //Create the web host builder
            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseConfiguration(config)
                .UseStartup<TStartup>()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    //logging.AddLog4Net();
                    logging.SetMinimumLevel(LogLevel.Debug);
                });

            //Return the host builder
            return new HostBuilder(webHostBuilder.Build());
        }
    }
}
