using AutoMapper;
using MedicalServices.AppMetaData;
using MedicalServices.DTO;
using MedicalServices.Models.Identity;
using MedicalServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region fields
        private readonly IMapper _mapper;
        private readonly IRegisterServies _applicationUserServies;
        #endregion

        #region Constructors
        // Constructor for injecting dependencies
        public AccountController(IMapper mapper,
                                  IRegisterServies applicationUserServices)
        {
            _mapper = mapper;
            _applicationUserServies = applicationUserServices;
        }
        #endregion

        #region Controllers
        [HttpPost(Router.AccountRouting.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            // Mapping the AddUserCommandDTO to a User entity using AutoMapper
            var UserMapping = _mapper.Map<User>(register);

            // Calling the service to add the user and await the result
            var emailResult = await _applicationUserServies.AddUserAsync(UserMapping, register.Password);

            // Handling the result of the user addition
            switch (emailResult)
            {
                case "EmailIsExist":
                    return BadRequest("Email Is already Exist");
                case "Failed":
                    return BadRequest("Failed To Register ");
                case "Success":
                    return Ok("Register has been completed successfully");
                default:
                    return BadRequest();
            }
        }
        #endregion
    }
}
