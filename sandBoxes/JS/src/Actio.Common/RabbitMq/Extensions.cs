using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;
using RawRabbit.Pipe;
using System.Reflection;
using System.Threading.Tasks;

namespace Actio.Common.RabbitMq
{
    /// <summary>
    /// Helper Extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="bus"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumerConfiguration(cfg =>
                cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="bus"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseConsumerConfiguration(cfg =>
                cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

        /// <summary>
        /// Gets the queue name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The name of the queue</returns>
        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
    }
}
