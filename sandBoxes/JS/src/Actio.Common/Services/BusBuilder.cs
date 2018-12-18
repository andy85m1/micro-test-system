using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.RabbitMq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;

namespace Actio.Common.Services
{
    /// <summary>
    /// Builds the bus
    /// </summary>
    public class BusBuilder : BuilderBase
    {
        private readonly IWebHost _webHost;
        private IBusClient _bus;

        /// <summary>
        /// Instantiates a bus builder
        /// </summary>
        /// <param name="webHost">The configured webhost</param>
        /// <param name="bus">The RabbitMq message bus</param>
        public BusBuilder(IWebHost webHost, IBusClient bus)
        {
            _webHost = webHost;
            _bus = bus;
        }

        /// <summary>
        /// Subscribes to commands
        /// </summary>
        /// <typeparam name="TCommand">The command to  subscribe to</typeparam>
        /// <returns>This instance of the BusBuilder</returns>
        public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
        {
            using (var serviceScope = _webHost.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var handler = (ICommandHandler<TCommand>)serviceScope.ServiceProvider
                    .GetService(typeof(ICommandHandler<TCommand>));
                _bus.WithCommandHandlerAsync(handler);
            }

            return this;
        }

        /// <summary>
        /// Subscribes to events
        /// </summary>
        /// <typeparam name="TEvent">The event to subscribe to</typeparam>
        /// <returns>This instance of the BusBuilder</returns>
        public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
        {
            using (var serviceScope = _webHost.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var handler = (IEventHandler<TEvent>)serviceScope.ServiceProvider.GetService(typeof(IEventHandler<TEvent>));

                _bus.WithEventHandlerAsync(handler);
            }

            return this;
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
