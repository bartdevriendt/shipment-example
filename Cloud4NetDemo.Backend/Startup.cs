using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud4NetDemo.Application.Extensions;
using Cloud4NetDemo.Application.Services;
using Cloud4NetDemo.Backend.Extensions;
using Cloud4NetDemo.Backend.Middlewares;
using Cloud4NetDemo.Domain.Entities;
using Cloud4NetDemo.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Cloud4NetDemo.Backend
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
            services.AddControllers(options =>
            {
                options.UseGeneralRoutePrefix("/api");
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Cloud4NetDemo.Backend", Version = "v1"});
            });

            
            services.AddApplicationLayer();
            services.AddTransient<IWarehouseService, WarehouseService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IShipmentService, ShipmentService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cloud4NetDemo.Backend v1"));
            }
            
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}