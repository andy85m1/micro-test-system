using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.RabbitMq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using System;

namespace Actio.Common.Services
{
    public class ServiceHost : IServiceHost
    {
        private readonly IWebHost _webHost;

        /// <summary>
        /// Constructor
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
        /// 
        /// </summary>
        /// <typeparam name="TStartup"></typeparam>
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
                .UseConfiguration(config)
                .UseStartup<TStartup>();

            //Return the host builder
            return new HostBuilder(webHostBuilder.Build());
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();
        }

        /// <summary>
        /// 
        /// </summary>
        public class HostBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IBusClient _bus;
               
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="webHost"></param>
            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public BusBuilder UseRabbitMq()
            {
                _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));

                return new BusBuilder(_webHost, _bus);
            }

            /// <summary>
            /// Builds the service host using the web host
            /// </summary>
            /// <returns></returns>
            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public class BusBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IBusClient _bus;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="webHost"></param>
            /// <param name="bus"></param>
            public BusBuilder(IWebHost webHost, IBusClient bus)
            {
                _webHost = webHost;
                _bus = bus;
            }

            /// <summary>
            /// Subscribes to commands
            /// </summary>
            /// <typeparam name="TCommand">The command to  subscribe to</typeparam>
            /// <returns></returns>
            public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                //using (var serviceScope = _webHost.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
                //{
                //    var handler = (ICommandHandler<TCommand>)serviceScope.ServiceProvider.GetService(typeof(ICommandHandler<TCommand>));
                //    _bus.WithCommandHandlerAsync(handler);
                //}

                var handler = (ICommandHandler<TCommand>)_webHost.Services
                    .GetService(typeof(ICommandHandler<TCommand>));

                _bus.WithCommandHandlerAsync(handler);

                return this;
            }

            /// <summary>
            /// Subscribes to events
            /// </summary>
            /// <typeparam name="TEvent">The event to subscribe to</typeparam>
            /// <returns></returns>
            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                //using (var serviceScope = _webHost.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
                //{
                //    var handler = (IEventHandler<TEvent>)serviceScope.ServiceProvider.GetService(typeof(IEventHandler<TEvent>));
                //    _bus.WithEventHandlerAsync(handler);
                //}

                var handler = (IEventHandler<TEvent>)_webHost.Services
                    .GetService(typeof(IEventHandler<TEvent>));

                _bus.WithEventHandlerAsync(handler);

                return this;
            }

            /// <summary>
            /// Builds the service host using the web host
            /// </summary>
            /// <returns></returns>
            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }
    }
}
