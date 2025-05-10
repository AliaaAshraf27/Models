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
                .ForMember(dest => dest.AvailableSlots, opt => opt.MapFrom(src => src.AvailableAppointments))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Average(r => r.Rating) : 0))
                .ForMember(x => x.ProfileImage, src => src.MapFrom(x => x.User.Photo));

            CreateMap<DoctorDetailsDto, User>()
                .ForMember(x => x.Email, src => src.MapFrom(x => x.Email));

            CreateMap<AvailableAppointments, AvailableSlotDTO>()
                    .ForMember(x => x.AppointmentId, src => src.MapFrom(x => x.Id))
                    .ForMember(x => x.Day, src => src.MapFrom(x => x.Day))
                    .ForMember(x => x.Name, src => src.MapFrom(x => x.Name))
                    .ForMember(x => x.TimeStart, src => src.MapFrom(x => x.TimeStart))
                    .ForMember(x => x.TimeEnd, src => src.MapFrom(x => x.TimeEnd))
                    .ForMember(x => x.Price, src => src.MapFrom(x => x.Price));




        }
    }
}
