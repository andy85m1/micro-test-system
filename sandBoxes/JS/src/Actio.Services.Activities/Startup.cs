using Actio.Common.Commands;
using Actio.Common.RabbitMq;
using Actio.Services.Activities.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Actio.Services.Activities
{
    /// <summary>
    /// Startup definition 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets the .NET Core configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Instantiates a <see cref="Startup"/>
        /// </summary>
        /// <param name="configuration">The .NET Core configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures the container
        /// This method gets called by the runtime. Use this method to add services to the container
        /// </summary>
        /// <param name="services">The collection of services to add to the container</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddRabbitMq(Configuration);
            services.AddScoped<ICommandHandler<CreateActivity>, CreateActivityHandler>();
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
