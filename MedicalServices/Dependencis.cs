using FluentValidation;
using MedicalServices.Services;

using MedicalServices.ServicesImplementation;
using System.Reflection;

namespace MedicalServices
{


    public static class Dependencis
    {
        public static IServiceCollection AddDependencis(this IServiceCollection services)
        {
            // Configuration of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //Configuration of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            services.AddTransient<IApplicationUserServies, ApplicationUserServies>();

            return services;
        }

    }
}
