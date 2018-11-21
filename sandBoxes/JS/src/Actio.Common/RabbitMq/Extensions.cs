using Actio.Common.Commands;
using Actio.Common.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using RawRabbit.Pipe.Middleware;
using System.Reflection;
using System.Threading.Tasks;

namespace Actio.Common.RabbitMq
{
    /// <summary>
    /// Helper Extension methods
    /// </summary>
    public static class Extensions
    {
        #region Code from Q&A for new RawRabbit - working
        //public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand 
        //    => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg), 
        //        ctx => ctx.UseConsumeConfiguration(
        //            cfg => cfg.WithConsumerTag(GetQueueName<TCommand>()))); //Uses WithConsumerTag instead of FromQueue

        //public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler) where TEvent : IEvent
        //    => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
        //        ctx => ctx.UseConsumeConfiguration(
        //            cfg => cfg.WithConsumerTag(GetQueueName<TEvent>()))); //Uses WithConsumerTag instead of FromQueue
        #endregion
            
        #region Code from Q&A for new RawRabbit - working
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus, ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumeConfiguration(
                    cfg => cfg.FromQueue(GetQueueName<TCommand>()))); //Uses FromQueue instead of WithConsumerFlag

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus, IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumeConfiguration(
                    cfg => cfg.FromQueue(GetQueueName<TEvent>()))); //Uses FromQueue instead of WithConsumerFlag
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static string GetQueueName<T>() => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}"; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
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
