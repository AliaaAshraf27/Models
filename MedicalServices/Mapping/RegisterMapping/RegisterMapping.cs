using MedicalServices.DTO;
using MedicalServices.Models.Identity;

namespace MedicalServices.Mapping.RegisterMapping
{
    public partial class RegisterProfile
    {
        public void RegisterMapping()
        {
            CreateMap<RegisterDTO, User>();
        }
    }
}
