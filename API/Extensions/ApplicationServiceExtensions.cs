using Application.Inventories;
using Domain.Repositories;
using MediatR;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
         public static IServiceCollection AddApplicationServices(
                this IServiceCollection services) {
             
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddMediatR(typeof(AddProductHandler).Assembly);
            //services.AddAutoMapper(typeof(Application.Core.MappingProfiles).Assembly);

            services.AddSingleton<IInventoryRepository, InventoryRepository>();

            return services;
         }
    }
}