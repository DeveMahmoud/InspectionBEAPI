using ApplicationLayer.Interfaces;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(conn));
            //services.AddScoped(typeof(IGenericRepository<EntityToInspect>), typeof(GenericRepository<EntityToInspect>));

           services.AddScoped<IGenericRepository<EntityToInspect>, GenericRepository<EntityToInspect>>();
           services.AddScoped<IGenericRepository<InspectionVisit>, GenericRepository<InspectionVisit>>();
           services.AddScoped<IGenericRepository<Inspector>, GenericRepository<Inspector>>();
           services.AddScoped<IGenericRepository<Violation>, GenericRepository<Violation>>();

            return services;
        }
    }
}
