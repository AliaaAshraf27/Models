using MedicalServices.Services;

using MedicalServices.ServicesImplementation;
using System.Reflection;

namespace MedicalServices
{


    public static class Dependencis
    {
        public static IServiceCollection AddDependencis(this IServiceCollection services)
        {

            //Configuration of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IRegisterServies, RegisterServies>();
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }

    }
}
