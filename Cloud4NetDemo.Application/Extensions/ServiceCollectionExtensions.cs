using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cloud4NetDemo.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
        }

    }
}