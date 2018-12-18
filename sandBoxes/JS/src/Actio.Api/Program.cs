using Actio.Common.Events;
using Actio.Common.Services;

namespace Actio.Api
{
    public class Program
    {
        /// <summary>
        /// The API main entry point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToEvent<ActivityCreated>()
                .SubscribeToEvent<UserCreated>()
                .SubscribeToEvent<UserAuthenticated>()
                .Build()
                .Run();                
        }
    }
}
