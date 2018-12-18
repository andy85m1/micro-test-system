using Actio.Common.Auth;
using Actio.Common.Commands;
using Actio.Common.Mongo;
using Actio.Common.RabbitMq;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Services.Identity.Domain.Services;
using Actio.Services.Identity.Handlers;
using Actio.Services.Identity.Repositories;
using Actio.Services.Identity.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Actio.Services.Identity
{
    public class Startup
    {
        /// <summary>
        /// Gets the .NET Core configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Instantiates a <see cref="Startup"/>
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures the container.
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The collection of services to add to the container</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddLogging();

            services.AddJwt(Configuration);
            services.AddMongoDB(Configuration);
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddRabbitMq(Configuration);
            services.AddScoped<ICommandHandler<CreateUser>, CreateUserHandler>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IEncryptor, Encryptor>(); 
        }

        /// <summary>
        /// Configures the HTTP request pipeline
        /// This method gets called by the runtime
        /// </summary>
        /// <param name="app">The application request pipeline</param>
        /// <param name="env">The web hosting environment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.ApplicationServices.GetService<IDatabaseInitializer>().InitialiseAsync();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
