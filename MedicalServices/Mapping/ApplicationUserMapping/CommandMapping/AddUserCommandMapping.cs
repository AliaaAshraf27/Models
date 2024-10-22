using MedicalServices.Features.ApplicationUser.Command.Models;
using MedicalServices.Models.Identity;

namespace MedicalServices.Mapping.ApplicationUserMapping
{
    public partial class ApplicationUserProfile
    {
        public void AddUserCommandMapping()
        {
            CreateMap<AddUserCommandDTo, User>();
        }
    }
}
