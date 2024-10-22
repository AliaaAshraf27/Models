using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MedicalServices.Genaric
{
    [ApiController]
    // Generic base controller for all controllers in the application
    public class AppControllerBase : ControllerBase
    {

        private IMediator _mediatorInstance;
        // Property to get an instance of IMediator, retrieves it from the request services
        protected IMediator Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();


        #region Actions
        public ObjectResult NewResult<T>(Responses<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);
            }
        }
        #endregion

    }
}
