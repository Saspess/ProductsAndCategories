﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsAndCategories.Data.Contexts.Contracts;
using ProductsAndCategories.Data.Contexts.Implementation;

namespace ProductsAndCategories.Data.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSqlContext(configuration)
                .ConfigureDbContext();

            return services;
        }

        public static IServiceCollection ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")),
                ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}