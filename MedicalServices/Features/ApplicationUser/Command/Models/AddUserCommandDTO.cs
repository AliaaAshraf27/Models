using MediatR;
using MedicalServices.Genaric;

namespace MedicalServices.Features.ApplicationUser.Command.Models
{
    public class AddUserCommandDTo : IRequest<Responses<string>>
    {
        public required string Name { get; set; }
        public required string UserName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
        public string Phone { get; set; }

    }
}
