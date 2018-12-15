using Actio.Common.Commands;
using Actio.Common.Services;

namespace Actio.Services.Activities
{
    public class Program
    {
        /// <summary>
        /// Main entry point into the service
        /// Creates, subscribes to the <see cref="CreateActivity"/> event, builds and runs the webhost
        /// </summary>
        /// <param name="args">Command line arguements</param>
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<CreateActivity>()
                .Build()
                .Run();
        }
    }
}
