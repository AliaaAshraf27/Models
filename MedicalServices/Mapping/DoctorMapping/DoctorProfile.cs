using AutoMapper;

namespace MedicalServices.Mapping.DoctorMapping
{
    public partial class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            GetDoctorDetailsMapping();
        }
    }
}
