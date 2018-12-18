using Actio.Common.Commands;
using Actio.Common.Mongo;
using Actio.Common.RabbitMq;
using Actio.Services.Activities.Domain.Repositories;
using Actio.Services.Activities.Handlers;
using Actio.Services.Activities.Repositories;
using Actio.Services.Activities.Services;
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
        /// Configures the container.
        /// This method gets called by the runtime. Use this method to add services to the container
        /// </summary>
        /// <param name="services">The collection of services to add to the container</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddLogging();
            
            services.AddMongoDB(Configuration);
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDatabaseSeeder, CustomMongoSeeder>();

            services.AddRabbitMq(Configuration);
            services.AddScoped<ICommandHandler<CreateActivity>, CreateActivityHandler>();
            services.AddScoped<IActivityService, ActivityService>();
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
