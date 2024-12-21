using MedicalServices.DTO;
using MedicalServices.Models;

namespace MedicalServices.Mapping.DoctorMapping
{
    public partial class DoctorProfile
    {
        public void GetDoctorDetailsMapping()
        {
            CreateMap<Doctor, DoctorDetailsDto>()
                .ForMember(x => x.Name, src => src.MapFrom(x => x.User.Name))
                .ForMember(x => x.Specialization, src => src.MapFrom(x => x.Specialization.Name));
            CreateMap<AvailableAppointments, AvailableAppointmentDto>();
        }
    }
}
