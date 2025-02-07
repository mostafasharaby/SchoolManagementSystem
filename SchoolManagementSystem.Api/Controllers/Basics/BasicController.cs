using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Core.Bases;
using System.Net;

namespace SchoolManagementSystem.Api.Controllers.Basics
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        public IMediator _mediator;
        public readonly ResponseHandler _responseHandler;
        public BasicController(IMediator _mediator, ResponseHandler responseHandler)
        {
            this._mediator = _mediator;
            _responseHandler = responseHandler;
        }

        #region Actions
        public ObjectResult NewResult<T>(Response<T> response)
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
