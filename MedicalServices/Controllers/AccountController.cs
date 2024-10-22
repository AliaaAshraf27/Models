using MedicalServices.AppMetaData;
using MedicalServices.Features.ApplicationUser.Command.Models;
using MedicalServices.Genaric;
using Microsoft.AspNetCore.Mvc;

namespace MedicalServices.Controllers
{
    [ApiController]
    public class AccountController : AppControllerBase
    {
        [HttpPost(Router.AccountRouting.Register)]
        public async Task<IActionResult> Register([FromBody] AddUserCommandDTo command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}
