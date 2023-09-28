using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProductsAndCategories.Business.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureBusinessLayer(this IServiceCollection services)
        {
            services.ConfigureAutoMapper();

            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
