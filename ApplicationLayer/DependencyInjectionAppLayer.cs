using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ApplicationLayer
{
    public static class DependencyInjectionAppLayer
    {
            public static IServiceCollection AddApplication(this IServiceCollection services)
            {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
            }
        
    }
    public class ApplicationAssemblyMarker { }

}
