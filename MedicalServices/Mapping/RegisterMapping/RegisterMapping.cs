using MedicalServices.DTO;
using MedicalServices.Models.Identity;

namespace MedicalServices.Mapping.RegisterMapping
{
    public partial class RegisterProfile
    {
        public void RegisterMapping()
        {
            CreateMap<RegisterDTO, User>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                 .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                 .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                 .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));


        }
    }
}
