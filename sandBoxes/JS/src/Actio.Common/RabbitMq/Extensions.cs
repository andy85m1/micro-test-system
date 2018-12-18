using Actio.Common.Commands;
using Actio.Common.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe.Middleware;
using System.Reflection;
using System.Threading.Tasks;

namespace Actio.Common.RabbitMq
{
    /// <summary>
    /// RabbitMq extension methods
    /// </summary>
    public static class Extensions
    {    
        /// <summary>
        /// Subscribes to a command and sets the handler
        /// </summary>
        /// <typeparam name="TCommand">The command to subscribe</typeparam>
        /// <param name="bus">The message bus</param>
        /// <param name="handler">The command handler</param>
        /// <returns></returns>
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumeConfiguration(
                    cfg => cfg.FromQueue(GetQueueName<TCommand>())));
        
        /// <summary>
        /// Subscribes to an event and sets the handler
        /// </summary>
        /// <typeparam name="TEvent">The event to subscribe</typeparam>
        /// <param name="bus">The message bus</param>
        /// <param name="handler">The event handler</param>
        /// <returns></returns>
        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumeConfiguration(
                    cfg => cfg.FromQueue(GetQueueName<TEvent>())));

        /// <summary>
        /// Gets the message queue name for a given type
        /// </summary>
        /// <typeparam name="T">The type of queue</typeparam>
        /// <returns>The queue name</returns>
        private static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}"; 

        /// <summary>
        /// Adds the RabbitMQ service
        /// </summary>
        /// <param name="services">Services collection</param>
        /// <param name="configuration">Configuration</param>
        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            services.AddSingleton<IBusClient>(_ => client);
        }
    }
}
