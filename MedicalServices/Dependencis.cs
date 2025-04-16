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
            services.AddScoped<IDoctorServices, DoctorServices>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ISpecializationService, SpecializationService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ILocationService, LocationService>();
            return services;
        }

    }
}
