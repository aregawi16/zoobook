using Domain.IRepository;
using Infrastructure.Repository;
using Zoobook.Application.EmployeeService;

namespace Zoobook.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
           
            return services;

        }
    }
}
