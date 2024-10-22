using AutoMapper;

namespace MedicalServices.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            AddUserCommandMapping();
        }
    }
}
