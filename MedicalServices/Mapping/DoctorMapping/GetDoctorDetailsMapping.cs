using MedicalServices.DTO;
using MedicalServices.Models;
using MedicalServices.Models.Identity;

namespace MedicalServices.Mapping.DoctorMapping
{
    public partial class DoctorProfile
    {
        public void GetDoctorDetailsMapping()
        {
            CreateMap<Doctor, DoctorDetailsDto>()
                .ForMember(x => x.Name, src => src.MapFrom(x => x.User.Name))
                .ForMember(x => x.Specialization, src => src.MapFrom(x => x.Specialization.Name))
                    .ForMember(x => x.Email, src => src.MapFrom(x => x.User.Email))
                    .ForMember(x => x.Prices, src => src.MapFrom(x => x.AvailableAppointments))
                    .ForMember(dest => dest.Rating, opt =>opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0));




            CreateMap<DoctorDetailsDto, User>()
                .ForMember(x => x.Email, src => src.MapFrom(x => x.Email));

            CreateMap<AvailableAppointments, DoctorPricesDto>()
                .ForMember(x => x.Price, src => src.MapFrom(x => x.Price))
                .ForMember(x => x.Name, src => src.MapFrom(x => x.Name));

            CreateMap<AvailableAppointments, AvailableAppointmentDto>()
                .ForMember(x => x.AppointmentId, src => src.MapFrom(x => x.Id));

        }
    }
}
