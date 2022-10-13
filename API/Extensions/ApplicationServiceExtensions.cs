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


            services.AddSingleton<IInventoryRepository, InventoryRepository>();
            services.AddSingleton<ICompanyRepository, CompanyRepository>();
            services.AddSingleton<IProductRepository, ProductRepository>();

            return services;
         }
    }
}