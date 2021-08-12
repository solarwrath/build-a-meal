using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpApiControllerBase: ControllerBase
    {
        protected readonly IMediator _mediator;

        public HttpApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}