using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Persistence.Redis;
using Learn.Services.Deliveries.Messages.Events.External;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Learn.Services.Deliveries
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddConvey()
                //.AddCommandHandlers()
                .AddEventHandlers()
                //.AddServiceBusEventDispatcher()
                .AddRedis()
                .AddInMemoryEventDispatcher()
                .AddInMemoryQueryDispatcher()
                .AddInMemoryCommandDispatcher()
                .AddRabbitMq()
                .Build();
        }
        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assembly = typeof(Startup).Assembly;
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces();
            //builder.RegisterModule(new AutofacModule());
            //builder.RegisterType<MyType>().As<IMytype>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseSwaggerDocs();
            
            app.UseHttpsRedirection();
            app.UseInitializers();

            app.UseRouting();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseRabbitMq()
                .SubscribeEvent<OrderCreated>();
        }
    }
}
