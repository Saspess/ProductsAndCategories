using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProductsAndCategories.Business.Services.Contracts;
using ProductsAndCategories.Business.Services.Implementation;
using System.Reflection;

namespace ProductsAndCategories.Business.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureBusinessLayer(this IServiceCollection services)
        {
            services.ConfigureAutoMapper()
                .ConfigureServices()
                .ConfigureFluentValidation();

            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }

        public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
