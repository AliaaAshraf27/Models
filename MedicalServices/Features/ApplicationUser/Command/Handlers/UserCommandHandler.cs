using AutoMapper;
using MediatR;
using MedicalServices.Features.ApplicationUser.Command.Models;
using MedicalServices.Genaric;
using MedicalServices.Models.Identity;
using MedicalServices.Services;

namespace MedicalServices.Features.ApplicationUser.Command.Handlers
{
    // Command handler for processing user-related commands, implements IRequestHandler for handling AddUserCommandDTO
    public class UserCommandHandler : ResponsesHandler,
        IRequestHandler<AddUserCommandDTo, Responses<string>>
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly IApplicationUserServies _applicationUserServies;
        #endregion

        #region Constructors
        // Constructor for injecting dependencies
        public UserCommandHandler(IMapper mapper,
                                  IApplicationUserServies applicationUserServices)
        {
            _mapper = mapper;
            _applicationUserServies = applicationUserServices;
        }
        #endregion

        #region Handle Functions 
        // Handles the AddUserCommandDTO request and returns a response
        public async Task<Responses<string>> Handle(AddUserCommandDTo request, CancellationToken cancellationToken)
        {
            // Mapping the AddUserCommandDTO to a User entity using AutoMapper
            var UserMapping = _mapper.Map<User>(request);

            // Calling the service to add the user and await the result
            var emailResult = await _applicationUserServies.AddUserAsync(UserMapping, request.Password);

            // Handling the result of the user addition
            switch (emailResult)
            {
                case "EmailIsExist":
                    return BadRequest<string>("Email Is already Exist");
                case "Failed":
                    return BadRequest<string>("Failed To Add User");
                case "Success":
                    return Created("Added Successfully");
                default:
                    return BadRequest<string>();
            }
        }
        #endregion
    }
}

