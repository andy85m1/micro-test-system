using Actio.Common.Commands;
using Actio.Common.Services;

namespace Actio.Services.Identity
{
    public class Program
    {
        /// <summary>
        /// Main entry point into the service
        /// Creates, subscribes to the <see cref="CreateUser"/> event, builds and runs the webhost 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<CreateUser>()
                .Build()
                .Run();
        }
    }
}